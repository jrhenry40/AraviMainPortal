using AraviPortal.Shared.Resources;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace AraviPortal.Frontend.Pages.SIS.Uploads;

public partial class UploadMROBacklog
{
    private string statusMessage = string.Empty;
    private Severity alertSeverity = Severity.Normal;
    private IBrowserFile? wProgramFile;
    private IBrowserFile? wBuyerFile;
    private IBrowserFile? wSupplierFile;

    private bool isUploading = false;
    private bool isWProgramUploaded = false;
    private bool isWBuyerUploaded = false;
    private bool isWSupplierUploaded = false;
    private bool allFilesUploaded = false;

    [Inject] private IStringLocalizer<Literals> Localizer { get; set; } = null!;
    [Inject] private HttpClient HttpClient { get; set; } = null!;
    [Inject] private NavigationManager NavigationManager { get; set; } = null!;
    [Inject] private ISnackbar Snackbar { get; set; } = null!;

    private void HandleWProgramFileSelected(InputFileChangeEventArgs e)
    {
        wProgramFile = e.File;
        statusMessage = string.Empty;
        isWProgramUploaded = false;
    }

    private void HandleWBuyerFileSelected(InputFileChangeEventArgs e)
    {
        wBuyerFile = e.File;
        statusMessage = string.Empty;
        isWBuyerUploaded = false;
    }

    private void HandleWSupplierFileSelected(InputFileChangeEventArgs e)
    {
        wSupplierFile = e.File;
        statusMessage = string.Empty;
        isWSupplierUploaded = false;
    }

    private void GoHome()
    {
        NavigationManager.NavigateTo("/uploaddaily");
    }

    // ELIMINAR: El método Reset() ya no es necesario
    // private void Reset() { ... }

    // AÑADIR: Nuevo método para navegar al siguiente menú
    private void GoToNextProcess()
    {
        NavigationManager.NavigateTo("/uploadMROReceiving");
    }

    private void CheckForAllFilesUploaded()
    {
        if (isWProgramUploaded && isWBuyerUploaded && isWSupplierUploaded)
        {
            allFilesUploaded = true;
        }
    }

    private async Task UploadWProgramFile()
    {
        await UploadFileAsync(wProgramFile, "api/UploadMROBacklog/upload-wprogram", Localizer["WProgram"]);
    }

    private async Task UploadWBuyerFile()
    {
        await UploadFileAsync(wBuyerFile, "api/UploadMROBacklog/upload-wbuyer", Localizer["WBuyer"]);
    }

    private async Task UploadWSupplierFile()
    {
        await UploadFileAsync(wSupplierFile, "api/UploadMROBacklog/upload-wsupplier", Localizer["WSupplier"]);
    }

    private async Task UploadFileAsync(IBrowserFile? file, string apiEndpoint, string fileName)
    {
        if (file == null)
        {
            Snackbar.Add(string.Format(Localizer["FileNotSelected"], fileName), Severity.Warning);
            return;
        }

        if (Path.GetExtension(file.Name).ToLower() != ".xlsx")
        {
            Snackbar.Add(string.Format(Localizer["WrongFileFormatExcel"], fileName), Severity.Error);
            return;
        }

        isUploading = true;
        StateHasChanged();

        try
        {
            using var content = new MultipartFormDataContent();
            content.Add(new StreamContent(file.OpenReadStream(file.Size)), "file", file.Name);

            var response = await HttpClient.PostAsync(apiEndpoint, content);

            if (response.IsSuccessStatusCode)
            {
                Snackbar.Add(string.Format(Localizer["FileUploadSuccess"], fileName), Severity.Success);
                statusMessage = string.Empty;

                if (file == wProgramFile) isWProgramUploaded = true;
                else if (file == wBuyerFile) isWBuyerUploaded = true;
                else if (file == wSupplierFile) isWSupplierUploaded = true;

                CheckForAllFilesUploaded();
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Snackbar.Add(errorContent, Severity.Error);
                statusMessage = $"Error al subir el archivo: {errorContent}";
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
            StateHasChanged();
        }
    }
}