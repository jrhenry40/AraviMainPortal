using AraviPortal.Backend.Repositories.Interfaces;
using AraviPortal.Backend.UnitsOfWork.Interfaces;
using AraviPortal.Shared.DTOs;
using AraviPortal.Shared.Entities;
using AraviPortal.Shared.Responses;

namespace AraviPortal.Backend.UnitsOfWork.Implementations
{
    public class HangarsUnitOfWork : GenericUnitOfWork<Hangar>, IHangarsUnitOfWork
    {
        private readonly IHangarsRepository _hangarsRepository;

        public HangarsUnitOfWork(IGenericRepository<Hangar> repository, IHangarsRepository hangarsRepository) : base(repository)
        {
            _hangarsRepository = hangarsRepository;
        }

        public override async Task<ActionResponse<Hangar>> GetAsync(int id) => await _hangarsRepository.GetAsync(id);

        public override async Task<ActionResponse<IEnumerable<Hangar>>> GetAsync() => await _hangarsRepository.GetAsync();

        public override async Task<ActionResponse<IEnumerable<Hangar>>> GetAsync(PaginationDTO pagination) => await _hangarsRepository.GetAsync(pagination);

        public async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination) => await _hangarsRepository.GetTotalRecordsAsync(pagination);

        public async Task<ActionResponse<Hangar>> AddAsync(HangarDTO hangarDTO) => await _hangarsRepository.AddAsync(hangarDTO);

        public async Task<IEnumerable<Hangar>> GetComboAsync(int cityId) => await _hangarsRepository.GetComboAsync(cityId);

        public async Task<ActionResponse<Hangar>> UpdateAsync(HangarDTO hangarDTO) => await _hangarsRepository.UpdateAsync(hangarDTO);
    }
}