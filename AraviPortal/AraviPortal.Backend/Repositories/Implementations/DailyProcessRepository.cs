using AraviPortal.Backend.Data;
using AraviPortal.Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AraviPortal.Backend.Repositories.Implementations;

public class DailyProcessRepository : IDailyProcessRepository
{
    private readonly DataContext _context;

    public DailyProcessRepository(DataContext context)
    {
        _context = context;
    }

    public async Task ExecuteDailyUpdateAsync()
    {
        await _context.Database.ExecuteSqlRawAsync("EXEC dbo.pro_ExecuteDailyReportUpdates");
    }
}