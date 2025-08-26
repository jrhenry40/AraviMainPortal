using AraviPortal.Backend.Data;
using AraviPortal.Backend.Helpers;
using AraviPortal.Backend.UnitsOfWork.Interfaces;
using AraviPortal.Shared.DTOs;
using AraviPortal.Shared.Entities;
using AraviPortal.Shared.Resources;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System.Globalization;
using System.Text;

namespace AraviPortal.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UploadSISSummaryAWBController : ControllerBase
{
    private readonly DataContext _context;
    private readonly ILogger<UploadSISSummaryAWBController> _logger;
    private readonly IFileConversionServiceUnitOfWork _unitOfWork;
    private readonly IStringLocalizer<Literals> _localizer;
    private readonly IDailyProcessUnitOfWork _dailyProcessUnitOfWork;

    public UploadSISSummaryAWBController(DataContext context, ILogger<UploadSISSummaryAWBController> logger, IFileConversionServiceUnitOfWork unitOfWork, IStringLocalizer<Literals> localizer, IDailyProcessUnitOfWork dailyProcessUnitOfWork)
    {
        _context = context;
        _logger = logger;
        _unitOfWork = unitOfWork;
        _localizer = localizer;
        _dailyProcessUnitOfWork = dailyProcessUnitOfWork;
    }

    [HttpPost("upload-summary-awb")]
    public async Task<IActionResult> UploadSummaryAwb([FromForm] UploadFileDto model)
    {
        var file = model.File;
        if (file == null || file.Length == 0)
        {
            return BadRequest("ERR010");
        }

        var worksheetName = "Sheet1";
        Stream csvStream = null!;

        try
        {
            csvStream = await _unitOfWork.FileConversionService.ConvertXlsxToCsvAsync(file, worksheetName);

            using var streamReader = new StreamReader(csvStream, Encoding.UTF8);
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                BadDataFound = args =>
                {
                    _logger.LogWarning("Datos incorrectos encontrados en la fila {Row}. Valor: {Field}", args.Context.Parser!.RawRow, args.Field);
                }
            };

            using var csvReader = new CsvReader(streamReader, config);
            csvReader.Context.RegisterClassMap<SISSummaryAWBMap>();

            await _context.Database.ExecuteSqlRawAsync("EXEC TruncateSISData @TableName", new SqlParameter("@TableName", "SISSummaryAWB"));

            var records = csvReader.GetRecords<SISSummaryAWB>().ToList();

            await _context.SISSummaryAWB.AddRangeAsync(records);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Carga de archivo AWB exitosa. Iniciando proceso de actualización de datos...");
            await _dailyProcessUnitOfWork.ExecuteDailyUpdateAsync();
            _logger.LogInformation("Proceso de actualización de datos finalizado exitosamente.");

            return Ok(new { Message = "Archivo Summary AWB subido y datos procesados correctamente." });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al guardar en la base de datos (Summary AWB): {Message}", ex.Message);
            var formatString = _localizer["DatabaseSaveError"];
            var finalMessage = string.Format(formatString, ex.Message);
            return StatusCode(500, finalMessage);
        }
        finally
        {
            csvStream?.Dispose();
        }
    }
}