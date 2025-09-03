using AraviPortal.Shared.DTOs;

namespace AraviPortal.Backend.Repositories.Interfaces;

public interface ISISUcsAmmsRepository
{
    Task<IEnumerable<SISUcsAmmsReportDTO>> GetReportDataAsync();
}