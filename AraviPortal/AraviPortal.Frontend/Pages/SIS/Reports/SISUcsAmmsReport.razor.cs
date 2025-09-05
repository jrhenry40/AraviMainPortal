using AraviPortal.Shared.Resources;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using MudBlazor;

namespace AraviPortal.Frontend.Pages.SIS.Reports
{
    public partial class SISUcsAmmsReport
    {
        [Inject] private IStringLocalizer<Literals> Localizer { get; set; } = null!;
        [Inject] private HttpClient HttpClient { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [Inject] private IJSRuntime JSRuntime { get; set; } = null!;
        [Inject] private ISnackbar Snackbar { get; set; } = null!;

        [Parameter]
        [SupplyParameterFromQuery]
        public string? Source { get; set; }

        private bool isExporting = false;

        private async Task ExportToExcel()
        {
            isExporting = true;

            var response = await HttpClient.GetAsync("api/SISUcsAmmsReport/export-excel");

            if (response.IsSuccessStatusCode)
            {
                var fileBytes = await response.Content.ReadAsByteArrayAsync();
                var fileName = response.Content.Headers?.ContentDisposition?.FileNameStar ??
                               response.Content.Headers?.ContentDisposition?.FileName ??
                               "Reporte.xlsx";

                await JSRuntime.InvokeVoidAsync("triggerFileDownload", fileName, Convert.ToBase64String(fileBytes));

                Snackbar.Add(Localizer["ReportGeneratedSuccess"], Severity.Success);

                await Task.Delay(2500); // Espera 2.5 segundos

                NavigationManager.NavigateTo("/sis");
            }
            else
            {
                Snackbar.Add(Localizer["ReportGeneratedError"], Severity.Error);
            }

            isExporting = false;
            StateHasChanged();
        }

        private void GoToReportsMenu()
        {
            NavigationManager.NavigateTo("/sis");
        }
    }
}