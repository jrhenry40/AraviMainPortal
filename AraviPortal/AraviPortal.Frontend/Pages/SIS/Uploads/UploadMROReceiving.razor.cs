using AraviPortal.Shared.Resources;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace AraviPortal.Frontend.Pages.SIS.Uploads;

public partial class UploadMROReceiving
{
    private IBrowserFile? selectedFile;
    private string statusMessage = string.Empty;
    private Severity alertSeverity = Severity.Normal;
    private bool isUploading = false;

    // AÑADIR: Estado para controlar la pantalla de éxito
    private bool isFileUploaded = false;

    [Inject] private IStringLocalizer<Literals> Localizer { get; set; } = null!;
    [Inject] private HttpClient HttpClient { get; set; } = null!;
    [Inject] private NavigationManager NavigationManager { get; set; } = null!;
    [Inject] private ISnackbar Snackbar { get; set; } = null!;

    private void HandleFileSelected(InputFileChangeEventArgs e)
    {
        selectedFile = e.File;
        statusMessage = string.Empty;
        isFileUploaded = false; // <-- AÑADIR
    }

    private void GoHome()
    {
        NavigationManager.NavigateTo("/uploaddaily");
    }

    // AÑADIR: Método para navegar al siguiente paso
    private void GoToNextProcess()
    {
        // Viendo el menú, después de "Receiving" viene "Shipping"
        NavigationManager.NavigateTo("/uploadMROShipping");
    }

    private async Task UploadFile()
    {
        if (selectedFile == null)
        {
            Snackbar.Add(Localizer["FileNotSelected"], Severity.Warning);
            return;
        }

        isUploading = true;
        StateHasChanged();

        try
        {
            using var content = new MultipartFormDataContent();
            content.Add(new StreamContent(selectedFile.OpenReadStream(selectedFile.Size)), "file", selectedFile.Name);

            var response = await HttpClient.PostAsync("api/UploadReceiving/upload-receiving", content);

            if (response.IsSuccessStatusCode)
            {
                // LÓGICA DE ÉXITO: Actualizada para mostrar la nueva vista
                statusMessage = string.Empty;
                isFileUploaded = true;
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                Snackbar.Add(error, Severity.Error);
                statusMessage = error;
                alertSeverity = Severity.Error;
            }
        }
        catch (Exception ex)
        {
            statusMessage = Localizer["FileUploadUnexpectedError"];
            Snackbar.Add(statusMessage, Severity.Error);
            alertSeverity = Severity.Error;
        }
        finally
        {
            isUploading = false;
            StateHasChanged(); // <-- Se asegura de actualizar la UI
        }
    }
}