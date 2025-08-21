using AraviPortal.Shared.Resources;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace AraviPortal.Frontend.Pages.SIS.Uploads;

public partial class UploadSummaryAWB
{
    private IBrowserFile? selectedFile;
    private string statusMessage = string.Empty;
    private Severity alertSeverity = Severity.Normal;
    private bool isUploading = false;
    private bool isFileUploaded = false;

    [Inject] private IStringLocalizer<Literals> Localizer { get; set; } = null!;
    [Inject] private HttpClient HttpClient { get; set; } = null!;
    [Inject] private NavigationManager NavigationManager { get; set; } = null!;
    [Inject] private ISnackbar Snackbar { get; set; } = null!;

    private void HandleFileSelected(InputFileChangeEventArgs e)
    {
        selectedFile = e.File;
        statusMessage = string.Empty;
        isFileUploaded = false;
    }

    private void GoHome()
    {
        NavigationManager.NavigateTo("/uploaddaily");
    }

    private void GoToNextProcess()
    {
        NavigationManager.NavigateTo("/uploaddaily");
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

            var response = await HttpClient.PostAsync("api/UploadSISSummaryAWB/upload-summary-awb", content);

            if (response.IsSuccessStatusCode)
            {
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
            StateHasChanged();
        }
    }
}