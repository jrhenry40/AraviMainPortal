using AraviPortal.Backend.Data;
using AraviPortal.Backend.UnitsOfWork.Interfaces;
using AraviPortal.Shared.DTOs;
using AraviPortal.Shared.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AraviPortal.Backend.Controllers;

[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[Route("api/[controller]")]
public class CategoriesController : Controller
{
    private readonly DataContext _context;

    public CategoriesController(DataContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(Category category)
    {
        _context.Add(category);
        await _context.SaveChangesAsync();
        return Ok(category);
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var categories = await _context.Categories
            .Include(x => x.Questions)
            .OrderBy(x => x.Name)
            .ToListAsync();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(int id)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        if (category == null)
        {
            return NotFound();
        }

        return Ok(category);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        if (category == null)
        {
            return NotFound();
        }

        _context.Remove(category);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> PutAsync(Category category)
    {
        _context.Update(category);
        await _context.SaveChangesAsync();
        return Ok(category);
    }

    //private readonly ICategoriesUnitOfWork _categoriesUnitOfWork;

    //public CategoriesController(IGenericUnitOfWork<Category> unitOfWork, ICategoriesUnitOfWork categoriesUnitOfWork) : base(unitOfWork)
    //{
    //    _categoriesUnitOfWork = categoriesUnitOfWork;
    //}

    //[HttpGet]
    //public override async Task<IActionResult> GetAsync()
    //{
    //    var response = await _categoriesUnitOfWork.GetAsync();
    //    if (response.WasSuccess)
    //    {
    //        return Ok(response.Result);
    //    }
    //    return BadRequest();
    //}

    //[HttpGet("{id}")]
    //public override async Task<IActionResult> GetAsync(int id)
    //{
    //    var response = await _categoriesUnitOfWork.GetAsync(id);
    //    if (response.WasSuccess)
    //    {
    //        return Ok(response.Result);
    //    }
    //    return NotFound(response.Message);
    //}

    //[HttpGet("paginated")]
    //public override async Task<IActionResult> GetAsync(PaginationDTO pagination)
    //{
    //    var response = await _categoriesUnitOfWork.GetAsync(pagination);
    //    if (response.WasSuccess)
    //    {
    //        return Ok(response.Result);
    //    }
    //    return BadRequest();
    //}

    //[HttpGet("totalRecordsPaginated")]
    //public async Task<IActionResult> GetTotalRecordsAsync([FromQuery] PaginationDTO pagination)
    //{
    //    var action = await _categoriesUnitOfWork.GetTotalRecordsAsync(pagination);
    //    if (action.WasSuccess)
    //    {
    //        return Ok(action.Result);
    //    }
    //    return BadRequest();
    //}

    //[HttpGet("combo")]
    //public async Task<IActionResult> GetComboAsync()
    //{
    //    return Ok(await _categoriesUnitOfWork.GetComboAsync());
    //}
}