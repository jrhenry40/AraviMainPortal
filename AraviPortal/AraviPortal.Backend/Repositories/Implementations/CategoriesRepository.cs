using AraviPortal.Backend.Data;
using AraviPortal.Backend.Helpers;
using AraviPortal.Backend.Repositories.Interfaces;
using AraviPortal.Shared.DTOs;
using AraviPortal.Shared.Entities;
using AraviPortal.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace AraviPortal.Backend.Repositories.Implementations;

public class CategoriesRepository : GenericRepository<Category>, ICategoriesRepository
{
    private readonly DataContext _context;

    public CategoriesRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<ActionResponse<Category>> GetAsync(int id)
    {
        var category = await _context.Categories
             .Include(x => x.Questions)
             .FirstOrDefaultAsync(x => x.Id == id);

        if (category == null)
        {
            return new ActionResponse<Category>
            {
                WasSuccess = false,
                Message = "ERR001"
            };
        }

        return new ActionResponse<Category>
        {
            WasSuccess = true,
            Result = category
        };
    }

    public override async Task<ActionResponse<IEnumerable<Category>>> GetAsync()
    {
        var categories = await _context.Categories
            .Include(x => x.Questions)
            .OrderBy(x => x.Name)
            .ToListAsync();
        return new ActionResponse<IEnumerable<Category>>
        {
            WasSuccess = true,
            Result = categories
        };
    }

    public override async Task<ActionResponse<IEnumerable<Category>>> GetAsync(PaginationDTO pagination)
    {
        var queryable = _context.Categories
            .Include(x => x.Questions)
            .OrderBy(x => x.Name)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(pagination.Filter))
        {
            queryable = queryable.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));
        }

        return new ActionResponse<IEnumerable<Category>>
        {
            WasSuccess = true,
            Result = await queryable
                .OrderBy(x => x.Name)
                .Paginate(pagination)
                .ToListAsync()
        };
    }

    public async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination)
    {
        var queryable = _context.Categories.AsQueryable();

        if (!string.IsNullOrWhiteSpace(pagination.Filter))
        {
            queryable = queryable.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));
        }

        double count = await queryable.CountAsync();
        return new ActionResponse<int>
        {
            WasSuccess = true,
            Result = (int)count
        };
    }

    public async Task<IEnumerable<Category>> GetComboAsync()
    {
        return await _context.Categories
            .OrderBy(x => x.Name)
            .ToListAsync();
    }
}