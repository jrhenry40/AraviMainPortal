using AraviPortal.Backend.Repositories.Interfaces;
using AraviPortal.Shared.Resources;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.Extensions.Localization;
using OfficeOpenXml;
using System.Globalization;
using System.Text;

namespace AraviPortal.Backend.Repositories.Implementations;

public class FileConversionService : IFileConversionService
{
    private readonly ILogger<FileConversionService> _logger;
    private readonly IStringLocalizer<Literals> _localizer;

    public FileConversionService(ILogger<FileConversionService> logger, IStringLocalizer<Literals> localizer)
    {
        _logger = logger;
        _localizer = localizer;
        ExcelPackage.License.SetNonCommercialOrganization("AMENTUM");
    }

    public async Task<Stream> ConvertXlsxToCsvAsync(IFormFile excelFile, string worksheetName)
    {
        if (string.IsNullOrEmpty(worksheetName))
        {
            throw new ArgumentException(_localizer["ERR012"]);
        }

        if (!Path.GetExtension(excelFile.FileName).ToLowerInvariant().Equals(".xlsx"))
        {
            throw new ArgumentException(_localizer["ERR011"]);
        }

        _logger.LogInformation("Excel file detected. Converting to CSV...");

        var csvStream = new MemoryStream();

        try
        {
            using (var excelTempStream = new MemoryStream())
            {
                await excelFile.CopyToAsync(excelTempStream);
                excelTempStream.Position = 0;

                using (var package = new ExcelPackage(excelTempStream))
                {
                    var worksheet = package.Workbook.Worksheets.FirstOrDefault(ws => ws.Name.Equals(worksheetName, StringComparison.OrdinalIgnoreCase));

                    if (worksheet == null)
                    {
                        throw new InvalidOperationException(_localizer["WorkSheetNotFound", worksheetName]);
                    }

                    using (var writer = new StreamWriter(csvStream, Encoding.UTF8, leaveOpen: true))
                    using (var csvWriter = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
                    {
                        var rowCount = worksheet.Dimension.Rows;
                        var colCount = worksheet.Dimension.Columns;

                        for (int row = 1; row <= rowCount; row++)
                        {
                            for (int col = 1; col <= colCount; col++)
                            {
                                var cellValue = worksheet.Cells[row, col].Text;
                                csvWriter.WriteField(cellValue);
                            }
                            csvWriter.NextRecord();
                        }
                    }
                }
            }

            csvStream.Position = 0;
            return csvStream;
        }
        catch (Exception ex)
        {
            //_logger.LogError(ex, "Error al convertir el archivo de Excel a CSV: {Message}", ex.Message);
            _logger.LogError(ex, _localizer["ERRO13"], ex.Message); //ERR013 en literals es igual Error converting Excel file to CSV: {0}
            csvStream.Dispose();
            throw;
        }
    }
}