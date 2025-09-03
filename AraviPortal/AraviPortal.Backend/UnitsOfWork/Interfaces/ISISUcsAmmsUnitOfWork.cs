using AraviPortal.Shared.DTOs;

namespace AraviPortal.Backend.UnitsOfWork.Interfaces;

public interface ISISUcsAmmsUnitOfWork
{
    Task<IEnumerable<SISUcsAmmsReportDTO>> GetSisuReportAsync();

    Task<byte[]> ExportSisuReportToExcelAsync();
}