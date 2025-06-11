using AraviPortal.Frontend.Repositories;
using AraviPortal.Shared.Entities;
using AraviPortal.Shared.Resources;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace AraviPortal.Frontend.Pages.Cities;

public partial class CitiesIndex
{
    [Inject] private IRepository Repository { get; set; } = null!;
    [Inject] private IStringLocalizer<Literals> Localizer { get; set; } = null!;
    [Inject] private NavigationManager NavigationManager { get; set; } = null!;
    [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;

    private List<City>? Cities { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await LoadAsync();
    }

    private async Task LoadAsync()
    {
        var responseHppt = await Repository.GetAsync<List<City>>("api/cities");
        if (responseHppt.Error)
        {
            var message = await responseHppt.GetErrorMessageAsync();
            await SweetAlertService.FireAsync(Localizer["Error"], message, SweetAlertIcon.Error);
            return;
        }
        Cities = responseHppt.Response!;
    }

    private async Task DeleteAsync(City city)
    {
        var result = await SweetAlertService.FireAsync(new SweetAlertOptions
        {
            Title = Localizer["Confirmation"],
            Text = string.Format(Localizer["DeleteConfirm"], Localizer["City"], city.Name),
            Icon = SweetAlertIcon.Question,
            ShowCancelButton = true,
            CancelButtonText = Localizer["Cancel"]
        });

        var confirm = string.IsNullOrEmpty(result.Value);

        if (confirm)
        {
            return;
        }

        var responseHttp = await Repository.DeleteAsync($"api/cities/{city.Id}");
        if (responseHttp.Error)
        {
            if (responseHttp.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                NavigationManager.NavigateTo("/");
            }
            else
            {
                var messageError = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync(Localizer["Error"], Localizer[messageError!], SweetAlertIcon.Error);
            }
            return;
        }

        await LoadAsync();
        var toast = SweetAlertService.Mixin(new SweetAlertOptions
        {
            Toast = true,
            Position = SweetAlertPosition.BottomEnd,
            ShowConfirmButton = true,
            Timer = 3000,
            ConfirmButtonText = Localizer["Yes"]
        });
        toast?.FireAsync(icon: SweetAlertIcon.Success, message: Localizer["RecordDeletedOk"]);
    }
}