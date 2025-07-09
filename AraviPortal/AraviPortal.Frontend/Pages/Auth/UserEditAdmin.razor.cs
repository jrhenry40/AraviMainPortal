using AraviPortal.Frontend.Repositories;
using AraviPortal.Shared.DTOs;
using AraviPortal.Shared.Entities;
using AraviPortal.Shared.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace AraviPortal.Frontend.Pages.Auth;

[Authorize(Roles = "Superadmin")]
public partial class UserEditAdmin
{
    [Parameter] public Guid UserId { get; set; }

    private UserEditDTO? userEditDTO;
    private bool loading = true;

    [Inject] private IRepository Repository { get; set; } = null!;
    [Inject] private ISnackbar Snackbar { get; set; } = null!;
    [Inject] private NavigationManager NavigationManager { get; set; } = null!;
    [Inject] private IStringLocalizer<Literals> Localizer { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        loading = true;
        var responseHttp = await Repository.GetAsync<User>($"/api/accounts/{UserId}"); // Obtener usuario por ID
        if (responseHttp.Error)
        {
            var message = await responseHttp.GetErrorMessageAsync();
            Snackbar.Add(Localizer[message!], Severity.Error);
            // Opcional: Navegar a una página de error o de lista de usuarios
        }
        else if (responseHttp.Response != null)
        {
            // Mapear la entidad User al DTO para el formulario
            userEditDTO = new UserEditDTO
            {
                Id = responseHttp.Response.Id!,
                FirstName = responseHttp.Response.FirstName,
                LastName = responseHttp.Response.LastName,
                PhoneNumber = responseHttp.Response.PhoneNumber,
                CityId = responseHttp.Response.CityId,
                UserType = responseHttp.Response.UserType // Asignar el rol actual
            };
        }
        loading = false;
    }

    private async Task EditUser()
    {
        if (userEditDTO == null) return;

        loading = true;
        // Llamar al nuevo endpoint PUT en el controlador de Accounts
        var responseHttp = await Repository.PutAsync("/api/accounts/UpdateUserByAdmin", userEditDTO);
        loading = false;

        if (responseHttp.Error)
        {
            var message = await responseHttp.GetErrorMessageAsync();
            Snackbar.Add(Localizer[message!], Severity.Error);
        }
        else
        {
            Snackbar.Add(Localizer["UserUpdatedSuccessfully"], Severity.Success);
            NavigationManager.NavigateTo("/users"); // Redirigir a la lista de usuarios
        }
    }

    private void Return()
    {
        NavigationManager.NavigateTo("/users");
    }
}