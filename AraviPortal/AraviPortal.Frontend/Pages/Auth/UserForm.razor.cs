using AraviPortal.Frontend.Repositories;
using AraviPortal.Shared.DTOs;
using AraviPortal.Shared.Entities;
using AraviPortal.Shared.Resources;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.Extensions.Localization;

namespace AraviPortal.Frontend.Pages.Auth;

public partial class UserForm
{
    private EditContext editContext = null!;
    private City selectedCity = new();
    private List<City> cities = new List<City>();

    [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;
    [Inject] private IStringLocalizer<Literals> Localizer { get; set; } = null!;
    [Inject] private IRepository Repository { get; set; } = null!;
    [EditorRequired, Parameter] public UserEditDTO UserEditDTO { get; set; } = null!; // Aquí se usa el nuevo DTO
    [EditorRequired, Parameter] public EventCallback OnValidSubmit { get; set; }
    [EditorRequired, Parameter] public EventCallback ReturnAction { get; set; }

    public bool FormPostedSuccessfully { get; set; } = false;

    protected override void OnInitialized()
    {
        editContext = new(UserEditDTO);
    }

    protected override async Task OnInitializedAsync()
    {
        await LoadCitiesAsync();

        if (cities != null && cities.Any() && UserEditDTO.CityId > 0)
        {
            selectedCity = cities.FirstOrDefault(c => c.Id == UserEditDTO.CityId) ?? new City();
        }
        else
        {
            selectedCity = new City();
        }

        StateHasChanged();
    }

    private async Task LoadCitiesAsync()
    {
        var responseHttp = await Repository.GetAsync<List<City>>("/api/cities/combo");
        if (responseHttp.Error)
        {
            var message = await responseHttp.GetErrorMessageAsync();
            await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
            cities = new List<City>();
            return;
        }
        cities = responseHttp.Response ?? new List<City>();
    }

    private async Task OnBeforeInternalNavigation(LocationChangingContext context)
    {
        var formWasEdited = editContext.IsModified();
        if (!formWasEdited || FormPostedSuccessfully)
        {
            return;
        }

        var result = await SweetAlertService.FireAsync(new SweetAlertOptions
        {
            Title = Localizer["Confirmation"],
            Text = Localizer["LeaveAndLoseChanges"],
            Icon = SweetAlertIcon.Warning,
            ShowCancelButton = true,
            CancelButtonText = Localizer["Cancel"],
        });

        var confirm = !string.IsNullOrEmpty(result.Value);
        if (confirm)
        {
            return;
        }
        context.PreventNavigation();
    }

    private async Task<IEnumerable<City>> SearchCity(string searchText, CancellationToken cancellationToken)
    {
        await Task.Delay(5);
        if (cities == null || !cities.Any())
        {
            return Enumerable.Empty<City>();
        }

        if (string.IsNullOrWhiteSpace(searchText))
        {
            return cities;
        }
        return cities
            .Where(x => x.Name.Contains(searchText, StringComparison.InvariantCultureIgnoreCase))
            .ToList();
    }

    private void CityChanged(City city)
    {
        selectedCity = city;
        UserEditDTO.CityId = city.Id;
    }
}