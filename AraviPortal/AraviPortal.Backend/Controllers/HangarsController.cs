using AraviPortal.Backend.UnitsOfWork.Interfaces;
using AraviPortal.Shared.DTOs;
using AraviPortal.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AraviPortal.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HangarsController : GenericController<Hangar>
{
    private readonly IHangarsUnitOfWork _hangarsUnitOfWork;

    public HangarsController(IGenericUnitOfWork<Hangar> unitOfWork, IHangarsUnitOfWork hangarsUnitOfWork) : base(unitOfWork)
    {
        _hangarsUnitOfWork = hangarsUnitOfWork;
    }

    [HttpGet]
    public override async Task<IActionResult> GetAsync()
    {
        var response = await _hangarsUnitOfWork.GetAsync();
        if (response.WasSuccess)
        {
            return Ok(response.Result);
        }
        return BadRequest();
    }

    [HttpGet("{id}")]
    public override async Task<IActionResult> GetAsync(int id)
    {
        var response = await _hangarsUnitOfWork.GetAsync(id);
        if (response.WasSuccess)
        {
            return Ok(response.Result);
        }
        return NotFound(response.Message);
    }

    [HttpGet("combo/{cityId:int}")]
    public async Task<IActionResult> GetComboAsync(int cityId)
    {
        return Ok(await _hangarsUnitOfWork.GetComboAsync(cityId));
    }

    [HttpPost("full")]
    public async Task<IActionResult> PostAsync(HangarDTO hangarDTO)
    {
        var action = await _hangarsUnitOfWork.AddAsync(hangarDTO);
        if (action.WasSuccess)
        {
            return Ok(action.Result);
        }
        return BadRequest(action.Message);
    }

    [HttpPut("full")]
    public async Task<IActionResult> PutAsync(HangarDTO hangarDTO)
    {
        var action = await _hangarsUnitOfWork.UpdateAsync(hangarDTO);
        if (action.WasSuccess)
        {
            return Ok(action.Result);
        }
        return BadRequest(action.Message);
    }
}