using AraviPortal.Backend.Data;
using AraviPortal.Backend.Repositories.Interfaces;
using AraviPortal.Shared.Entities;
using AraviPortal.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace AraviPortal.Backend.Repositories.Implementations;

public class CitiesRepository : GenericRepository<City>, ICitiesRepository
{
    private readonly DataContext _context;

    public CitiesRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<ActionResponse<City>> GetAsync(int id) // Get a city by its ID, including its hangars, Obtener una ciudad por su ID, incluidos sus hangares
    {
        var city = await _context.Cities
             .Include(x => x.Hangars)
             .FirstOrDefaultAsync(x => x.Id == id);

        if (city == null)
        {
            return new ActionResponse<City>
            {
                WasSuccess = false,
                Message = "ERR001"
            };
        }

        return new ActionResponse<City>
        {
            WasSuccess = true,
            Result = city
        };
    }

    public override async Task<ActionResponse<IEnumerable<City>>> GetAsync()
    {
        var cities = await _context.Cities
            .Include(x => x.Hangars)
            .ToListAsync();
        return new ActionResponse<IEnumerable<City>>
        {
            WasSuccess = true,
            Result = cities
        };
    }

    public async Task<IEnumerable<City>> GetComboAsync()
    {
        return await _context.Cities
            .OrderBy(x => x.Name)
            .ToListAsync();
    }
}