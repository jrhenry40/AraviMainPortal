using AraviPortal.Shared.DTOs;
using AraviPortal.Shared.Responses;

namespace AraviPortal.Backend.Repositories.Interfaces;

public interface IQrCodeService
{
    Task<ActionResponse<QrCodeResponse>> GenerateQrCodeAsync(QrCodeRequest request);
}