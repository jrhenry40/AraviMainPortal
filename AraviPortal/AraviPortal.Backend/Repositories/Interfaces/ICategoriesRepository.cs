using AraviPortal.Shared.DTOs;
using AraviPortal.Shared.Entities;
using AraviPortal.Shared.Responses;

namespace AraviPortal.Backend.Repositories.Interfaces;

public interface ICategoriesRepository
{
    Task<ActionResponse<Category>> GetAsync(int id);

    Task<ActionResponse<IEnumerable<Category>>> GetAsync();

    Task<IEnumerable<Category>> GetComboAsync();

    Task<ActionResponse<IEnumerable<Category>>> GetAsync(PaginationDTO pagination);

    Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination);
}