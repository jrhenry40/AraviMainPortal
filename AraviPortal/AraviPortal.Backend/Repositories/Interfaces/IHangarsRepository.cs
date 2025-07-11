﻿using AraviPortal.Shared.DTOs;
using AraviPortal.Shared.Entities;
using AraviPortal.Shared.Responses;

namespace AraviPortal.Backend.Repositories.Interfaces;

public interface IHangarsRepository
{
    Task<IEnumerable<Hangar>> GetComboAsync(int cityId);

    Task<ActionResponse<Hangar>> AddAsync(HangarDTO hangarDTO);

    Task<ActionResponse<Hangar>> UpdateAsync(HangarDTO hangarDTO);

    Task<ActionResponse<Hangar>> GetAsync(int id);

    Task<ActionResponse<IEnumerable<Hangar>>> GetAsync();

    Task<ActionResponse<IEnumerable<Hangar>>> GetAsync(PaginationDTO pagination);

    Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination);
}