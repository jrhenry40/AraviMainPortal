using AraviPortal.Backend.Repositories.Interfaces;
using AraviPortal.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AraviPortal.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QrCodeController : ControllerBase
{
    private readonly ILogger<QrCodeController> _logger;
    private readonly IQrCodeService _qrCodeService;

    public QrCodeController(ILogger<QrCodeController> logger, IQrCodeService qrCodeService)
    {
        _logger = logger;
        _qrCodeService = qrCodeService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] QrCodeRequest request)
    {
        var response = await _qrCodeService.GenerateQrCodeAsync(request);

        if (response.WasSuccess)
        {
            // --- CORRECCIÓN ---
            // Ahora devolvemos el objeto 'ActionResponse' completo.
            // El frontend ya está preparado para recibirlo así.
            return Ok(response);
        }

        // Si hubo un error, se devuelve un 'BadRequest' con el MENSAJE CLAVE.
        return BadRequest(response.Message);
    }
}