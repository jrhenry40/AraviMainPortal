namespace AraviPortal.Backend.UnitsOfWork.Interfaces;

public interface IDailyProcessUnitOfWork
{
    Task ExecuteDailyUpdateAsync();
}