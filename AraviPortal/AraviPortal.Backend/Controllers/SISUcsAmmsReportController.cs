using AraviPortal.Backend.UnitsOfWork.Interfaces;
using AraviPortal.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AraviPortal.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SISUcsAmmsReportController : ControllerBase
{
    private readonly ISISUcsAmmsUnitOfWork _sISUcsAmmsUnitOfWork;

    public SISUcsAmmsReportController(ISISUcsAmmsUnitOfWork sISUcsAmmsUnitOfWork)
    {
        _sISUcsAmmsUnitOfWork = sISUcsAmmsUnitOfWork;
    }

    [HttpGet("report")]
    public async Task<ActionResult<IEnumerable<SISUcsAmmsReportDTO>>> GetReport()
    {
        var data = await _sISUcsAmmsUnitOfWork.GetSisuReportAsync();
        return Ok(data);
    }

    [HttpGet("export-excel")]
    public async Task<IActionResult> ExportReportToExcel()
    {
        var fileBytes = await _sISUcsAmmsUnitOfWork.ExportSisuReportToExcelAsync();
        string fileName = $"ReporteSISU_{DateTime.Now:yyyyMMddHHmmss}.xlsx";

        // Devolvemos un FileContentResult, que el navegador interpretará como una descarga.
        return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
    }
}