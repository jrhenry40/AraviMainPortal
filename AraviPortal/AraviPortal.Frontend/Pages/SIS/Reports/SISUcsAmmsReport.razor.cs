using AraviPortal.Shared.DTOs;
using AraviPortal.Shared.Resources;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using MudBlazor;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace AraviPortal.Frontend.Pages.SIS.Reports
{
    public partial class SISUcsAmmsReport
    {
        [Inject] private IStringLocalizer<Literals> Localizer { get; set; } = null!;
        [Inject] private HttpClient HttpClient { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [Inject] private ISnackbar Snackbar { get; set; } = null!;
        [Inject] private IJSRuntime JSRuntime { get; set; } = null!;

        private IEnumerable<SISUcsAmmsReportDTO>? reportData;
        private bool isExporting = false;

        protected override async Task OnInitializedAsync()
        {
            // Asegúrate de que tu HttpClient base address esté bien configurado en Program.cs
            reportData = await HttpClient.GetFromJsonAsync<IEnumerable<SISUcsAmmsReportDTO>>("api/SISUcsAmmsReport/report");
        }

        private async Task ExportToExcel()
        {
            isExporting = true;

            var response = await HttpClient.GetAsync("api/SISUcsAmmsReport/export-excel");

            if (response.IsSuccessStatusCode)
            {
                var fileBytes = await response.Content.ReadAsByteArrayAsync();

                // Extraer el nombre del archivo de las cabeceras de la respuesta
                var fileName = response.Content.Headers?.ContentDisposition?.FileNameStar ??
                               response.Content.Headers?.ContentDisposition?.FileName ??
                               "Reporte.xlsx";

                // Aquí está la corrección: llamar al método desde la variable JSRuntime
                await JSRuntime.InvokeVoidAsync("triggerFileDownload", fileName, Convert.ToBase64String(fileBytes));
            }

            isExporting = false;
            StateHasChanged(); // Notifica a Blazor que actualice la UI
        }
    }
}