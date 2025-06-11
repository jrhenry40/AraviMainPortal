using AraviPortal.Backend.UnitsOfWork.Interfaces;
using AraviPortal.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AraviPortal.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HangarsController : GenericController<Hangar>
{
    public HangarsController(IGenericUnitOfWork<Hangar> unitOfWork) : base(unitOfWork)
    {
    }
}