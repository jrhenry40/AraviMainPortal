namespace AraviPortal.Backend.Repositories.Interfaces;

public interface IDailyProcessRepository
{
    Task ExecuteDailyUpdateAsync();
}