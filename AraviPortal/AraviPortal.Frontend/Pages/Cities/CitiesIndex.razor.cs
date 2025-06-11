using AraviPortal.Frontend.Repositories;
using AraviPortal.Shared.Entities;
using AraviPortal.Shared.Resources;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace AraviPortal.Frontend.Pages.Cities;

public partial class CitiesIndex
{
    [Inject] private IRepository Repository { get; set; } = null!;

    [Inject] private IStringLocalizer<Literals> Localizer { get; set; } = null!;

    private List<City>? Cities { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var responseHppt = await Repository.GetAsync<List<City>>("api/cities");
        Cities = responseHppt.Response!;
    }
}