using AraviPortal.Backend.Repositories.Interfaces;

namespace AraviPortal.Backend.UnitsOfWork.Interfaces;

public interface IFileConversionServiceUnitOfWork
{
    public IFileConversionService FileConversionService { get; }
}