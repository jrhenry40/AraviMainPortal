using AraviPortal.Shared.DTOs;
using AraviPortal.Shared.Entities;
using AraviPortal.Shared.Responses;

namespace AraviPortal.Backend.UnitsOfWork.Interfaces;

public interface IHangarsUnitOfWork
{
    Task<IEnumerable<Hangar>> GetComboAsync(int cityId);

    Task<ActionResponse<Hangar>> AddAsync(HangarDTO hangarDTO);

    Task<ActionResponse<Hangar>> UpdateAsync(HangarDTO hangarDTO);

    Task<ActionResponse<Hangar>> GetAsync(int id);

    Task<ActionResponse<IEnumerable<Hangar>>> GetAsync();
}