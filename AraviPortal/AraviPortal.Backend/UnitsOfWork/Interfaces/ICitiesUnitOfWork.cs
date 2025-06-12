using AraviPortal.Shared.Entities;
using AraviPortal.Shared.Responses;

namespace AraviPortal.Backend.UnitsOfWork.Interfaces;

public interface ICitiesUnitOfWork
{
    Task<ActionResponse<City>> GetAsync(int id);

    Task<ActionResponse<IEnumerable<City>>> GetAsync();

    Task<IEnumerable<City>> GetComboAsync();
}