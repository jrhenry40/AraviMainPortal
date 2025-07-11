using AraviPortal.Frontend.Repositories;
using AraviPortal.Shared.DTOs;
using AraviPortal.Shared.Resources;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace AraviPortal.Frontend.Pages.Auth;

public partial class ResendConfirmationEmailToken
{
    private EmailDTO emailDTO = new();
    private bool loading;

    [Inject] private NavigationManager NavigationManager { get; set; } = null!;
    [Inject] private ISnackbar Snackbar { get; set; } = null!;
    [Inject] private IRepository Repository { get; set; } = null!;
    [Inject] private IStringLocalizer<Literals> Localizer { get; set; } = null!;
    [CascadingParameter] private IMudDialogInstance MudDialog { get; set; } = null!;

    private async Task ResendConfirmationEmailTokenAsync()
    {
        emailDTO.Language = System.Globalization.CultureInfo.CurrentCulture.Name.Substring(0, 2);
        loading = true;
        var responseHttp = await Repository.PostAsync("/api/accounts/ResedToken", emailDTO);
        loading = false;

        if (responseHttp.Error)
        {
            var message = await responseHttp.GetErrorMessageAsync();
            Snackbar.Add(Localizer[message!], Severity.Error);
            return;
        }

        MudDialog.Cancel();
        NavigationManager.NavigateTo("/");
        Snackbar.Add(Localizer["SendEmailConfirmationMessage"], Severity.Success);
    }
}