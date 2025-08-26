using AraviPortal.Backend.Repositories.Interfaces;
using AraviPortal.Backend.UnitsOfWork.Interfaces;

namespace AraviPortal.Backend.UnitsOfWork.Implementations;

public class DailyProcessUnitOfWork : IDailyProcessUnitOfWork
{
    private readonly IDailyProcessRepository _repository;

    public DailyProcessUnitOfWork(IDailyProcessRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteDailyUpdateAsync()
    {
        await _repository.ExecuteDailyUpdateAsync();
    }
}