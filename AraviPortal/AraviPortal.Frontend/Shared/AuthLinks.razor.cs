using AraviPortal.Frontend.Pages.Auth;
using AraviPortal.Shared.Resources;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace AraviPortal.Frontend.Shared;

public partial class AuthLinks
{
    [Inject] private IStringLocalizer<Literals> Localizer { get; set; } = null!;
    [Inject] private NavigationManager NavigationManager { get; set; } = null!;
    [Inject] private IDialogService DialogService { get; set; } = null!;
    [CascadingParameter] private Task<AuthenticationState> AuthenticationStateTask { get; set; } = null!;

    protected override async Task OnParametersSetAsync()
    {
        var authenticationState = await AuthenticationStateTask;
        var claims = authenticationState.User.Claims.ToList();
        var nameClaim = claims.FirstOrDefault(x => x.Type == "UserName");
    }

    private void EditAction()
    {
        NavigationManager.NavigateTo("/EditUser");
    }

    private void ShowModalLogIn()
    {
        var closeOnEscapeKey = new DialogOptions() { CloseOnEscapeKey = true };
        DialogService.Show<Login>(Localizer["Login"], closeOnEscapeKey);
    }

    private void ShowModalLogOut()
    {
        var closeOnEscapeKey = new DialogOptions() { CloseOnEscapeKey = true };
        DialogService.Show<Logout>(Localizer["Logout"], closeOnEscapeKey);
    }
}