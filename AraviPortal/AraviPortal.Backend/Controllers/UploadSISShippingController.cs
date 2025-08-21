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
public class UploadSISShippingController : ControllerBase
{
    private readonly DataContext _context;
    private readonly ILogger<UploadSISShippingController> _logger;
    private readonly IFileConversionServiceUnitOfWork _unitOfWork;
    private readonly IStringLocalizer<Literals> _localizer;

    public UploadSISShippingController(DataContext context, ILogger<UploadSISShippingController> logger, IFileConversionServiceUnitOfWork unitOfWork, IStringLocalizer<Literals> localizer)
    {
        _context = context;
        _logger = logger;
        _unitOfWork = unitOfWork;
        _localizer = localizer;
    }

    [HttpPost("upload-shipping")]
    public async Task<IActionResult> UploadShippingFile([FromForm] UploadFileDto model)
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
            // LÓGICA: Se añade la conversión de Excel a CSV
            csvStream = await _unitOfWork.FileConversionService.ConvertXlsxToCsvAsync(file, worksheetName);

            using var streamReader = new StreamReader(csvStream, Encoding.UTF8);
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true, // Asumimos que el archivo tiene encabezado
                BadDataFound = args =>
                {
                    _logger.LogWarning("Datos incorrectos encontrados en la fila {Row}. Valor: {Field}", args.Context.Parser!.RawRow, args.Field);
                }
            };

            using var csvReader = new CsvReader(streamReader, config);
            csvReader.Context.RegisterClassMap<SISShippingMap>();

            await _context.Database.ExecuteSqlRawAsync("EXEC TruncateSISData @TableName", new SqlParameter("@TableName", "SISShipping"));

            var records = csvReader.GetRecords<SISShipping>().ToList();

            await _context.SISShipping.AddRangeAsync(records);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Archivo SHIPPING subido y datos guardados correctamente." });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al guardar en la base de datos (Shipping): {Message}", ex.Message);
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