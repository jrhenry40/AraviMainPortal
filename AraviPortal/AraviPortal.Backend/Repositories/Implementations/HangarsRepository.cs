using AraviPortal.Backend.Data;
using AraviPortal.Backend.Helpers;
using AraviPortal.Backend.Repositories.Interfaces;
using AraviPortal.Shared.DTOs;
using AraviPortal.Shared.Entities;
using AraviPortal.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace AraviPortal.Backend.Repositories.Implementations;

public class HangarsRepository : GenericRepository<Hangar>, IHangarsRepository
{
    private readonly DataContext _context;

    public HangarsRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<ActionResponse<IEnumerable<Hangar>>> GetAsync()
    {
        var hangars = await _context.Hangars
            .Include(x => x.City)
            .OrderBy(x => x.Name)
            .ToListAsync();
        return new ActionResponse<IEnumerable<Hangar>>
        {
            WasSuccess = true,
            Result = hangars
        };
    }

    public override async Task<ActionResponse<Hangar>> GetAsync(int id)
    {
        var hangar = await _context.Hangars
             .Include(x => x.City)
             .FirstOrDefaultAsync(c => c.Id == id);

        if (hangar == null)
        {
            return new ActionResponse<Hangar>
            {
                WasSuccess = false,
                Message = "ERR001"
            };
        }

        return new ActionResponse<Hangar>
        {
            WasSuccess = true,
            Result = hangar
        };
    }

    public override async Task<ActionResponse<IEnumerable<Hangar>>> GetAsync(PaginationDTO pagination)
    {
        var queryable = _context.Hangars
            .Include(x => x.City)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(pagination.Filter))
        {
            //queryable = queryable.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));
            queryable = queryable.Where(x => x.City!.Name.ToLower().Contains(pagination.Filter.ToLower()));
        }

        return new ActionResponse<IEnumerable<Hangar>>
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
        var queryable = _context.Hangars.AsQueryable();

        if (!string.IsNullOrWhiteSpace(pagination.Filter))
        {
            //queryable = queryable.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));
            queryable = queryable.Where(x => x.City!.Name.ToLower().Contains(pagination.Filter.ToLower()));
        }

        double count = await queryable.CountAsync();
        return new ActionResponse<int>
        {
            WasSuccess = true,
            Result = (int)count
        };
    }

    public async Task<ActionResponse<Hangar>> AddAsync(HangarDTO hangarDTO)
    {
        var city = await _context.Cities.FindAsync(hangarDTO.CityId);
        if (city == null)
        {
            return new ActionResponse<Hangar>
            {
                WasSuccess = false,
                Message = "ERR004"
            };
        }

        var hangar = new Hangar
        {
            City = city,
            Name = hangarDTO.Name,
        };

        _context.Add(hangar);
        try
        {
            await _context.SaveChangesAsync();
            return new ActionResponse<Hangar>
            {
                WasSuccess = true,
                Result = hangar
            };
        }
        catch (DbUpdateException)
        {
            return new ActionResponse<Hangar>
            {
                WasSuccess = false,
                Message = "ERR003"
            };
        }
        catch (Exception exception)
        {
            return new ActionResponse<Hangar>
            {
                WasSuccess = false,
                Message = exception.Message
            };
        }
    }

    public async Task<IEnumerable<Hangar>> GetComboAsync(int cityId)
    {
        return await _context.Hangars
            .Where(x => x.CityId == cityId)
            .OrderBy(x => x.Name)
            .ToListAsync();
    }

    public async Task<ActionResponse<Hangar>> UpdateAsync(HangarDTO hangarDTO)
    {
        var currentHangar = await _context.Hangars.FindAsync(hangarDTO.Id);
        if (currentHangar == null)
        {
            return new ActionResponse<Hangar>
            {
                WasSuccess = false,
                Message = "ERR005"
            };
        }

        var city = await _context.Cities.FindAsync(hangarDTO.CityId);
        if (city == null)
        {
            return new ActionResponse<Hangar>
            {
                WasSuccess = false,
                Message = "ERR004"
            };
        }

        currentHangar.City = city;
        currentHangar.Name = hangarDTO.Name;

        _context.Update(currentHangar);
        try
        {
            await _context.SaveChangesAsync();
            return new ActionResponse<Hangar>
            {
                WasSuccess = true,
                Result = currentHangar
            };
        }
        catch (DbUpdateException)
        {
            return new ActionResponse<Hangar>
            {
                WasSuccess = false,
                Message = "ERR003"
            };
        }
        catch (Exception exception)
        {
            return new ActionResponse<Hangar>
            {
                WasSuccess = false,
                Message = exception.Message
            };
        }
    }
}