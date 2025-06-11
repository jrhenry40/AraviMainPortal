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
    public CitiesController(IGenericUnitOfWork<City> unitOfWork) : base(unitOfWork)
    {
    }
}