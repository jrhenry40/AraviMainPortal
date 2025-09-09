using AraviPortal.Frontend.Repositories;
using AraviPortal.Shared.DTOs;
using AraviPortal.Shared.Resources;
using AraviPortal.Shared.Responses;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using MudBlazor;
using System.Net.Http.Json;

namespace AraviPortal.Frontend.Pages.QrCodeGenerator
{
    public partial class QrCodeGenerator
    {
        private string urlToEncode = string.Empty;
        private string? qrCodeBase64;
        private bool isLoading;
        private const string BackendApiUrl = "api/QrCode";

        [Inject] private IStringLocalizer<Literals> Localizer { get; set; } = null!;
        [Inject] private HttpClient HttpClient { get; set; } = null!;
        [Inject] private ISnackbar Snackbar { get; set; } = null!;
        [Inject] private IJSRuntime JSRuntime { get; set; } = null!;

        private async Task GenerateQrCode()
        {
            if (string.IsNullOrWhiteSpace(urlToEncode))
            {
                Snackbar.Add(Localizer["UrlRequired"], Severity.Warning);
                return;
            }

            isLoading = true;
            qrCodeBase64 = null;
            StateHasChanged();

            try
            {
                var request = new QrCodeRequest { Url = urlToEncode };
                var response = await HttpClient.PostAsJsonAsync(BackendApiUrl, request);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<ActionResponse<QrCodeResponse>>();
                    if (result is { WasSuccess: true, Result: not null })
                    {
                        qrCodeBase64 = result.Result.Base64Image;
                        Snackbar.Add(Localizer["QrGeneratedSuccess"], Severity.Success);
                    }
                    else
                    {
                        var messageKey = result?.Message ?? "QrGenerationFailed";
                        Snackbar.Add(Localizer[messageKey], Severity.Error);
                    }
                }
                else
                {
                    var messageKey = await response.Content.ReadAsStringAsync();
                    Snackbar.Add(Localizer[messageKey], Severity.Error);
                }
            }
            catch (Exception)
            {
                Snackbar.Add(Localizer["ConnectionError"], Severity.Error);
            }
            finally
            {
                isLoading = false;
                StateHasChanged();
            }
        }

        private async Task DownloadQrCodeAsync()
        {
            if (!string.IsNullOrEmpty(qrCodeBase64))
            {
                var fileName = $"QR_{DateTime.Now:yyyyMMddHHmmss}.png";
                await JSRuntime.InvokeVoidAsync("downloadFileFromBase64", fileName, qrCodeBase64);
            }
        }

        private void Reset()
        {
            qrCodeBase64 = null;
            urlToEncode = string.Empty;
        }

        private async Task HandleKeyUp(KeyboardEventArgs e)
        {
            if (e.Key == "Enter")
            {
                await GenerateQrCode();
            }
        }
    }
}