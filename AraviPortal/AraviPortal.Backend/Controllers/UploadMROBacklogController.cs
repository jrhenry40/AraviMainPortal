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

namespace AraviPortal.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UploadMROBacklogController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ILogger<UploadMROBacklogController> _logger;
        private readonly IFileConversionServiceUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<Literals> _localizer;

        public UploadMROBacklogController(DataContext context, ILogger<UploadMROBacklogController> logger, IFileConversionServiceUnitOfWork unitOfWork, IStringLocalizer<Literals> localizer)
        {
            _context = context;
            _logger = logger;
            _unitOfWork = unitOfWork;
            _localizer = localizer;
        }

        [HttpPost("upload-wprogram")]
        public async Task<IActionResult> UploadWProgramFile([FromForm] UploadFileDto model)
        {
            var file = model.File;
            if (file == null || file.Length == 0)
            {
                return BadRequest("ERR010");
            }

            var worksheetName = "W PROGRAM";
            Stream csvStream = null!;

            try
            {
                csvStream = await _unitOfWork.FileConversionService.ConvertXlsxToCsvAsync(file, worksheetName);

                using var streamReader = new StreamReader(csvStream, Encoding.UTF8);
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ",",
                    HasHeaderRecord = true,
                    BadDataFound = args =>
                    {
                        _logger.LogWarning("Datos incorrectos encontrados en la fila {Row}. Valor: {Field}", args.Context.Parser!.RawRow, args.Field);
                    }
                };

                using var csvReader = new CsvReader(streamReader, config);
                csvReader.Context.RegisterClassMap<SISWProgramMap>();

                await _context.Database.ExecuteSqlRawAsync("EXEC TruncateSISData @TableName", new SqlParameter("@TableName", "SISWProgram"));

                var records = csvReader.GetRecords<SISWProgram>().ToList();
                await _context.SISWProgram.AddRangeAsync(records);
                await _context.SaveChangesAsync();

                return Ok(new { Message = "Archivo subido y datos guardados correctamente." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al guardar en la base de datos: {Message}", ex.Message);

                var formatString = _localizer["DatabaseSaveError"];

                var finalMessage = string.Format(formatString, ex.Message);

                return StatusCode(500, finalMessage);
            }
            finally
            {
                csvStream?.Dispose();
            }
        }

        [HttpPost("upload-wbuyer")]
        public async Task<IActionResult> UploadWBuyerFile([FromForm] UploadFileDto model)
        {
            var file = model.File;
            if (file == null || file.Length == 0)
            {
                return BadRequest("ERR010");
            }

            var worksheetName = "W BUYER";
            Stream csvStream = null!;

            try
            {
                csvStream = await _unitOfWork.FileConversionService.ConvertXlsxToCsvAsync(file, worksheetName);

                using var streamReader = new StreamReader(csvStream, Encoding.UTF8);
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ",",
                    HasHeaderRecord = true,
                    BadDataFound = args =>
                    {
                        _logger.LogWarning("Datos incorrectos encontrados en la fila {Row}. Valor: {Field}", args.Context.Parser!.RawRow, args.Field);
                    }
                };

                using var csvReader = new CsvReader(streamReader, config);
                csvReader.Context.RegisterClassMap<SISWBuyerMap>();

                await _context.Database.ExecuteSqlRawAsync("EXEC TruncateSISData @TableName", new SqlParameter("@TableName", "SISWProgram"));

                var records = csvReader.GetRecords<SISWBuyer>().ToList();
                await _context.SISWBuyer.AddRangeAsync(records);
                await _context.SaveChangesAsync();

                return Ok(new { Message = "Archivo subido y datos guardados correctamente." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al guardar en la base de datos: {Message}", ex.Message);

                var formatString = _localizer["DatabaseSaveError"];

                var finalMessage = string.Format(formatString, ex.Message);

                return StatusCode(500, finalMessage);
            }
            finally
            {
                csvStream?.Dispose();
            }
        }

        [HttpPost("upload-wsupplier")]
        public async Task<IActionResult> UploadWSupplierFile([FromForm] UploadFileDto model)
        {
            var file = model.File;
            if (file == null || file.Length == 0)
            {
                return BadRequest("ERR010");
            }

            var worksheetName = "W SUPPLIER";
            Stream csvStream = null!;

            try
            {
                csvStream = await _unitOfWork.FileConversionService.ConvertXlsxToCsvAsync(file, worksheetName);

                using var streamReader = new StreamReader(csvStream, Encoding.UTF8);
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ",",
                    HasHeaderRecord = true,
                    BadDataFound = args =>
                    {
                        _logger.LogWarning("Datos incorrectos encontrados en la fila {Row}. Valor: {Field}", args.Context.Parser!.RawRow, args.Field);
                    }
                };

                using var csvReader = new CsvReader(streamReader, config);
                csvReader.Context.RegisterClassMap<SISWSupplierMap>();

                await _context.Database.ExecuteSqlRawAsync("EXEC TruncateSISData @TableName", new SqlParameter("@TableName", "SISWProgram"));

                var records = csvReader.GetRecords<SISWSupplier>().ToList();
                await _context.SISWSupplier.AddRangeAsync(records);
                await _context.SaveChangesAsync();

                return Ok(new { Message = "Archivo subido y datos guardados correctamente." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al guardar en la base de datos: {Message}", ex.Message);

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
}