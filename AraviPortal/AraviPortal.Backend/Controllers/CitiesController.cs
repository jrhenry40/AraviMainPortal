using AraviPortal.Backend.Data;
using AraviPortal.Backend.UnitsOfWork.Interfaces;
using AraviPortal.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AraviPortal.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CitiesController : GenericController<City>
{
    private readonly ICitiesUnitOfWork _citiesUnitOfWork;

    public CitiesController(IGenericUnitOfWork<City> unitOfWork, ICitiesUnitOfWork citiesUnitOfWork) : base(unitOfWork)
    {
        _citiesUnitOfWork = citiesUnitOfWork;
    }

    [HttpGet]
    public override async Task<IActionResult> GetAsync()
    {
        var response = await _citiesUnitOfWork.GetAsync();
        if (response.WasSuccess)
        {
            return Ok(response.Result);
        }
        return BadRequest();
    }

    [HttpGet("{id}")]
    public override async Task<IActionResult> GetAsync(int id)
    {
        var response = await _citiesUnitOfWork.GetAsync(id);
        if (response.WasSuccess)
        {
            return Ok(response.Result);
        }
        return NotFound(response.Message);
    }

    [HttpGet("combo")]
    public async Task<IActionResult> GetComboAsync()
    {
        return Ok(await _citiesUnitOfWork.GetComboAsync());
    }
}