using AraviPortal.Frontend.Repositories;
using AraviPortal.Shared.Entities;
using AraviPortal.Shared.Resources;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace AraviPortal.Frontend.Pages.Cities;

public partial class CityEdit
{
    private City? city;
    private CityForm? cityForm;

    [Inject] private NavigationManager NavigationManager { get; set; } = null!;
    [Inject] private IRepository Repository { get; set; } = null!;
    [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;
    [Inject] private IStringLocalizer<Literals> Localizer { get; set; } = null!;

    [Parameter] public int Id { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var responseHttp = await Repository.GetAsync<City>($"api/cities/{Id}");

        if (responseHttp.Error)
        {
            if (responseHttp.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                NavigationManager.NavigateTo("cities");
            }
            else
            {
                var messageError = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync(Localizer["Error"], Localizer[messageError!], SweetAlertIcon.Error);
            }
        }
        else
        {
            city = responseHttp.Response;
        }
    }

    private async Task EditAsync()
    {
        var responseHttp = await Repository.PutAsync("api/cities", city);

        if (responseHttp.Error)
        {
            var mensajeError = await responseHttp.GetErrorMessageAsync();
            await SweetAlertService.FireAsync(Localizer["Error"], Localizer[mensajeError!], SweetAlertIcon.Error);
            return;
        }

        Return();
        var toast = SweetAlertService.Mixin(new SweetAlertOptions
        {
            Toast = true,
            Position = SweetAlertPosition.BottomEnd,
            ShowConfirmButton = true,
            Timer = 3000
        });
        await toast.FireAsync(icon: SweetAlertIcon.Success, message: Localizer["RecordSavedOk"]);
    }

    private void Return()
    {
        cityForm!.FormPostedSuccessfully = true;
        NavigationManager.NavigateTo("cities");
    }
}