using AraviPortal.Backend.Data;
using AraviPortal.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AraviPortal.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CitiesController : ControllerBase
{
    private readonly DataContext _context;

    public CitiesController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        return Ok(await _context.Cities.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(int id)
    {
        var city = await _context.Cities.FirstOrDefaultAsync(c => c.Id == id);
        if (city == null)
        {
            return NotFound();
        }

        return Ok(city);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(City city)
    {
        _context.Add(city);
        await _context.SaveChangesAsync();
        return Ok(city);
    }

    [HttpPut]
    public async Task<IActionResult> PutAsync(City city)
    {
        var currentCity = await _context.Cities.FindAsync(city.Id);
        if (currentCity == null)
        {
            return NotFound();
        }

        currentCity.Name = city.Name;
        _context.Update(currentCity);
        await _context.SaveChangesAsync();
        return Ok(currentCity);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var city = await _context.Cities.FirstOrDefaultAsync(c => c.Id == id);
        if (city == null)
        {
            return NotFound();
        }

        _context.Remove(city);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}