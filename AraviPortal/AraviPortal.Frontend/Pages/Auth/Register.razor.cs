using AraviPortal.Frontend.Repositories;
using AraviPortal.Frontend.Services;
using AraviPortal.Shared.DTOs;
using AraviPortal.Shared.Entities;
using AraviPortal.Shared.Enums;
using AraviPortal.Shared.Resources;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace AraviPortal.Frontend.Pages.Auth;

public partial class Register
{
    private UserDTO userDTO = new();
    private List<City>? cities;
    private bool loading;
    private string? titleLabel;

    private City selectedCity = new();

    [Inject] private NavigationManager NavigationManager { get; set; } = null!;
    [Inject] private ILoginService LogInService { get; set; } = null!;
    [Inject] private IDialogService DialogService { get; set; } = null!;
    [Inject] private ISnackbar Snackbar { get; set; } = null!;
    [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;
    [Inject] private IRepository Repository { get; set; } = null!;
    [Inject] private IStringLocalizer<Literals> Localizer { get; set; } = null!;
    [Parameter, SupplyParameterFromQuery] public bool IsAdmin { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await LoadCitiesAsync();
    }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        titleLabel = IsAdmin ? Localizer["AdminRegister"] : Localizer["UserRegister"];
    }

    private async Task LoadCitiesAsync()
    {
        var responseHttp = await Repository.GetAsync<List<City>>("/api/cities/combo");
        if (responseHttp.Error)
        {
            var message = await responseHttp.GetErrorMessageAsync();
            Snackbar.Add(Localizer[message!], Severity.Error);
            return;
        }
        cities = responseHttp.Response;
    }

    private void CityChanged(City city)
    {
        selectedCity = city;
    }

    private async Task<IEnumerable<City>> SearchCities(string searchText, CancellationToken cancellationToken)
    {
        await Task.Delay(5);
        if (string.IsNullOrWhiteSpace(searchText))
        {
            return cities!;
        }

        return cities!
            .Where(c => c.Name.Contains(searchText, StringComparison.InvariantCultureIgnoreCase))
            .ToList();
    }

    private void ReturnAction()
    {
        NavigationManager.NavigateTo("/");
    }

    private async Task CreateUserAsync()
    {
        if (!ValidateForm())
        {
            return;
        }

        userDTO.UserType = UserType.User;
        userDTO.UserName = userDTO.Email;
        userDTO.City = selectedCity;
        userDTO.CityId = selectedCity.Id;
        userDTO.Language = System.Globalization.CultureInfo.CurrentCulture.Name.Substring(0, 2);

        if (IsAdmin)
        {
            userDTO.UserType = UserType.Superadmin;
        }

        loading = true;
        var responseHttp = await Repository.PostAsync<UserDTO>("/api/accounts/CreateUser", userDTO);
        loading = false;
        if (responseHttp.Error)
        {
            var message = await responseHttp.GetErrorMessageAsync();
            if (message!.Contains("DuplicateUserName"))
            {
                Snackbar.Add(Localizer["EmailAlreadyExists"], Severity.Error);
                return;
            }
            Snackbar.Add(Localizer[message], Severity.Error);
            return;
        }

        NavigationManager.NavigateTo("/");
        await SweetAlertService.FireAsync(new SweetAlertOptions
        {
            Title = Localizer["Confirmation"],
            Text = Localizer["SendEmailConfirmationMessage"],
            Icon = SweetAlertIcon.Info,
        });
    }

    private bool ValidateForm()
    {
        var hasErrors = false;
        if (string.IsNullOrEmpty(userDTO.FirstName))
        {
            Snackbar.Add(string.Format(Localizer["RequiredField"], string.Format(Localizer["FirstName"])), Severity.Error);
            hasErrors = true;
        }
        if (string.IsNullOrEmpty(userDTO.LastName))
        {
            Snackbar.Add(string.Format(Localizer["RequiredField"], string.Format(Localizer["LastName"])), Severity.Error);
            hasErrors = true;
        }
        if (string.IsNullOrEmpty(userDTO.PhoneNumber))
        {
            Snackbar.Add(string.Format(Localizer["RequiredField"], string.Format(Localizer["PhoneNumber"])), Severity.Error);
            hasErrors = true;
        }
        if (string.IsNullOrEmpty(userDTO.Email))
        {
            Snackbar.Add(string.Format(Localizer["RequiredField"], string.Format(Localizer["Email"])), Severity.Error);
            hasErrors = true;
        }
        if (string.IsNullOrEmpty(userDTO.Password))
        {
            Snackbar.Add(string.Format(Localizer["RequiredField"], string.Format(Localizer["Password"])), Severity.Error);
            hasErrors = true;
        }
        if (string.IsNullOrEmpty(userDTO.PasswordConfirm))
        {
            Snackbar.Add(string.Format(Localizer["RequiredField"], string.Format(Localizer["PasswordConfirm"])), Severity.Error);
            hasErrors = true;
        }
        if (selectedCity.Id == 0)
        {
            Snackbar.Add(string.Format(Localizer["RequiredField"], string.Format(Localizer["City"])), Severity.Error);
            hasErrors = true;
        }

        return !hasErrors;
    }
}