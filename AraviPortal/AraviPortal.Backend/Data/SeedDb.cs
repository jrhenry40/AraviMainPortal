using AraviPortal.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace AraviPortal.Backend.Data;

public class SeedDb
{
    private readonly DataContext _context;

    public SeedDb(DataContext context)
    {
        _context = context;
    }

    public async Task SeedAsync()
    {
        await _context.Database.EnsureCreatedAsync();
        await CheckCitiesAsync();
        await CheckHangarsAsync();
    }

    private async Task CheckCitiesAsync()
    {
        if (!_context.Cities.Any())
        {
            var citiesSQLScript = File.ReadAllText("Data\\Cities.sql");
            await _context.Database.ExecuteSqlRawAsync(citiesSQLScript);
        }
    }

    private async Task CheckHangarsAsync()
    {
        if (!_context.Hangars.Any())
        {
            foreach (var city in _context.Cities)
            {
                if (city.Name == "Bogotá")
                {
                    _context.Hangars.Add(new Hangar { Name = "GYM H1", City = city! });
                    _context.Hangars.Add(new Hangar { Name = "GYM H2", City = city! });
                    _context.Hangars.Add(new Hangar { Name = "GYM H3", City = city! });
                }
                else if (city.Name == "Tuluá")
                {
                    _context.Hangars.Add(new Hangar { Name = "TUL H1", City = city! });
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}