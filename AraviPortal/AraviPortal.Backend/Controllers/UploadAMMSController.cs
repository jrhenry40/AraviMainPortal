using AraviPortal.Backend.Data;
using AraviPortal.Backend.Helpers;
using AraviPortal.Backend.UnitsOfWork.Interfaces;
using AraviPortal.Shared.DTOs;
using AraviPortal.Shared.Entities;
using AraviPortal.Shared.Resources;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System.Globalization;
using System.Text;

namespace AraviPortal.Backend.Controllers;

[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[Route("api/[controller]")]
public class UploadAMMSController : ControllerBase
{
    private readonly DataContext _context;
    private readonly ILogger<UploadAMMSController> _logger;
    private readonly IFileConversionServiceUnitOfWork _unitOfWork;
    private readonly IStringLocalizer<Literals> _localizer;

    public UploadAMMSController(DataContext context, ILogger<UploadAMMSController> logger, IFileConversionServiceUnitOfWork unitOfWork, IStringLocalizer<Literals> localizer)
    {
        _context = context;
        _logger = logger;
        _unitOfWork = unitOfWork;
        _localizer = localizer;
    }

    [HttpPost("UCSAMMS")]
    public async Task<IActionResult> UploadAmmsFile([FromForm] UploadFileDto model)
    {
        var file = model.File;
        if (file == null || file.Length == 0)
        {
            return BadRequest("ERR010");
        }

        // Nombre de la hoja a procesar para este controlador.
        var worksheetName = "Sheet1";
        Stream csvStream = null!;

        try
        {
            // Llama al servicio de conversión y le pasa el nombre de la hoja.
            csvStream = await _unitOfWork.FileConversionService.ConvertXlsxToCsvAsync(file, worksheetName);

            using var streamReader = new StreamReader(csvStream, Encoding.UTF8);
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ",",
                HasHeaderRecord = false,
                // Agregamos esta línea para manejar los datos mal formados.
                BadDataFound = args =>
                {
                    _logger.LogWarning("Datos incorrectos encontrados en la fila {Row}. Valor: {Field}", args.Context.Parser!.RawRow, args.Field);
                }
            };

            using var csvReader = new CsvReader(streamReader, config);
            csvReader.Context.RegisterClassMap<SISUcsAmmsMap>();

            await _context.Database.ExecuteSqlRawAsync("EXEC TruncateSISData @TableName", new SqlParameter("@TableName", "SISUcsAmms"));

            var records = csvReader.GetRecords<SISUcsAmms>().ToList();
            await _context.SISUcsAmms.AddRangeAsync(records);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Archivo subido y datos guardados correctamente." });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al guardar en la base de datos: {Message}", ex.Message);

            // Obtenemos la plantilla de texto localizada.
            var formatString = _localizer["DatabaseSaveError"];

            // Usamos string.Format para insertar el detalle de la excepción.
            var finalMessage = string.Format(formatString, ex.Message);

            // Enviamos el mensaje final, ya construido y localizado.
            return StatusCode(500, finalMessage);
        }
        finally
        {
            // Cerramos el stream convertido para liberar recursos.
            csvStream?.Dispose();
        }
    }
}