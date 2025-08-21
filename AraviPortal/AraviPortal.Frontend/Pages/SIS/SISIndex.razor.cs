using AraviPortal.Shared.Resources;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace AraviPortal.Frontend.Pages.SIS;

public partial class SISIndex
{
    [Inject] private IStringLocalizer<Literals> Localizer { get; set; } = null!;

    protected override void OnInitialized()
    {
        // Example: You could add some logging or data loading if necessary
    }
}