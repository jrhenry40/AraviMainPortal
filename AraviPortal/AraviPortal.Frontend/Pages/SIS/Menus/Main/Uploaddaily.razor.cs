using AraviPortal.Shared.Resources;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace AraviPortal.Frontend.Pages.SIS.Menus.Main;

public partial class Uploaddaily
{
    [Inject] private IStringLocalizer<Literals> Localizer { get; set; } = null!;
    [Inject] private NavigationManager NavigationManager { get; set; } = null!;

    private void GoHome()
    {
        NavigationManager.NavigateTo("/sis");
    }
}