using AraviPortal.Shared.Entities;
using AraviPortal.Shared.Responses;

namespace AraviPortal.Backend.Repositories.Interfaces;

public interface ICitiesRepository
{
    Task<ActionResponse<City>> GetAsync(int id);

    Task<ActionResponse<IEnumerable<City>>> GetAsync();

    Task<IEnumerable<City>> GetComboAsync();
}