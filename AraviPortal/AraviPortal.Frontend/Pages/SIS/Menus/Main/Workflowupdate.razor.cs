using AraviPortal.Shared.Resources;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace AraviPortal.Frontend.Pages.SIS.Menus.Main;

public partial class Workflowupdate
{
    [Inject] private IStringLocalizer<Literals> Localizer { get; set; } = null!;
}