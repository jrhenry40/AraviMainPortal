namespace AraviPortal.Backend.Repositories.Interfaces;

public interface IFileConversionService
{
    Task<Stream> ConvertXlsxToCsvAsync(IFormFile excelFile, string worksheetName);
}