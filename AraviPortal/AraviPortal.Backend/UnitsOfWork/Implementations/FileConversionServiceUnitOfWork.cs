using AraviPortal.Backend.Repositories.Interfaces;
using AraviPortal.Backend.UnitsOfWork.Interfaces;

namespace AraviPortal.Backend.UnitsOfWork.Implementations;

public class FileConversionServiceUnitOfWork : IFileConversionServiceUnitOfWork
{
    public IFileConversionService FileConversionService { get; }

    public FileConversionServiceUnitOfWork(IFileConversionService fileConversionService)
    {
        FileConversionService = fileConversionService;
    }
}