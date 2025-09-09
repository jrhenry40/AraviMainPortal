using AraviPortal.Backend.Repositories.Interfaces;
using AraviPortal.Shared.DTOs;
using AraviPortal.Shared.Responses;
using QRCoder;

namespace AraviPortal.Backend.Repositories.Implementations;

public class QrCodeService : IQrCodeService
{
    public Task<ActionResponse<QrCodeResponse>> GenerateQrCodeAsync(QrCodeRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Url))
        {
            var response = new ActionResponse<QrCodeResponse>
            {
                WasSuccess = false,
                Message = "UrlRequired" // Clave del mensaje de error
            };
            return Task.FromResult(response);
        }

        try
        {
            using var qrGenerator = new QRCodeGenerator();
            using var qrCodeData = qrGenerator.CreateQrCode(request.Url, QRCodeGenerator.ECCLevel.Q);
            using var qrCode = new PngByteQRCode(qrCodeData);
            var qrCodeImageBytes = qrCode.GetGraphic(20);
            var base64Image = Convert.ToBase64String(qrCodeImageBytes);

            var response = new ActionResponse<QrCodeResponse>
            {
                WasSuccess = true,
                Result = new QrCodeResponse { Base64Image = base64Image }
            };
            return Task.FromResult(response);
        }
        catch (Exception)
        {
            // Si la librería de QR falla (ej. URL muy larga o con formato incorrecto)
            var response = new ActionResponse<QrCodeResponse>
            {
                WasSuccess = false,
                Message = "QrGenerationFailed" // Clave del mensaje de error
            };
            return Task.FromResult(response);
        }
    }

    //public byte[] GenerateQrCodeImage(string url)
    //{
    //    using var qrGenerator = new QRCodeGenerator();
    //    QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);

    //    using var pngQrCode = new PngByteQRCode(qrCodeData);
    //    byte[] qrCodeImageBytes = pngQrCode.GetGraphic(20);

    //    return qrCodeImageBytes;
    //}
}