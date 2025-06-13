using AraviPortal.Frontend.Repositories;
using AraviPortal.Shared.DTOs;
using AraviPortal.Shared.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace AraviPortal.Frontend.Pages.Hangars;

[Authorize(Roles = "Superadmin")]
public partial class HangarCreate
{
    private HangarForm? hangarForm;
    private HangarDTO hangarDTO = new();

    [Inject] private IRepository Repository { get; set; } = null!;
    [Inject] private NavigationManager NavigationManager { get; set; } = null!;
    [Inject] private ISnackbar Snackbar { get; set; } = null!;
    [Inject] private IStringLocalizer<Literals> Localizer { get; set; } = null!;

    private async Task CreateAsync()
    {
        var responseHttp = await Repository.PostAsync("/api/hangars/full", hangarDTO);
        if (responseHttp.Error)
        {
            var message = await responseHttp.GetErrorMessageAsync();
            Snackbar.Add(Localizer[message!], Severity.Error);
            return;
        }

        Return();
        Snackbar.Add(Localizer["RecordCreatedOk"], Severity.Success);
    }

    private void Return()
    {
        hangarForm!.FormPostedSuccessfully = true;
        NavigationManager.NavigateTo("/hangars");
    }
}