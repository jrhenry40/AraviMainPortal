using AraviPortal.Frontend.Repositories;
using AraviPortal.Frontend.Shared;
using AraviPortal.Shared.Entities;
using AraviPortal.Shared.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;
using System.Net;

namespace AraviPortal.Frontend.Pages.Auth;

[Authorize(Roles = "Superadmin")]
public partial class UserIndex
{
    public List<User>? Users { get; set; }

    private MudTable<User> table = new();
    private readonly int[] pageSizeOptions = { 10, 25, 50, int.MaxValue };
    private int totalRecords = 0;
    private bool loading;
    private string baseUrl = "api/accounts";
    private string infoFormat = "{first_item}-{last_item} => {all_items}";

    [Inject] private IRepository Repository { get; set; } = null!;
    [Inject] private ISnackbar Snackbar { get; set; } = null!;
    [Inject] private IDialogService DialogService { get; set; } = null!;
    [Inject] private IStringLocalizer<Literals> Localizer { get; set; } = null!;
    [Inject] private NavigationManager NavigationManager { get; set; } = null!;

    [Parameter, SupplyParameterFromQuery] public string Filter { get; set; } = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        await LoadAsync();
    }

    private async Task LoadAsync()
    {
        await LoadTotalRecordsAsync();
    }

    private async Task<bool> LoadTotalRecordsAsync()
    {
        loading = true;
        var url = $"{baseUrl}/totalRecordsPaginated";
        if (!string.IsNullOrWhiteSpace(Filter))
        {
            url += $"?filter={Filter}";
        }
        var responseHttp = await Repository.GetAsync<int>(url);
        if (responseHttp.Error)
        {
            var message = await responseHttp.GetErrorMessageAsync();
            Snackbar.Add(Localizer[message!], Severity.Error);
            return false;
        }
        totalRecords = responseHttp.Response;
        loading = false;
        return true;
    }

    private async Task<TableData<User>> LoadListAsync(TableState state, CancellationToken cancellationToken)
    {
        int page = state.Page + 1;
        int pageSize = state.PageSize;
        var url = $"{baseUrl}/paginated?page={page}&recordsnumber={pageSize}";

        if (!string.IsNullOrWhiteSpace(Filter))
        {
            url += $"&filter={Filter}";
        }

        var responseHttp = await Repository.GetAsync<List<User>>(url);
        if (responseHttp.Error)
        {
            var message = await responseHttp.GetErrorMessageAsync();
            Snackbar.Add(Localizer[message!], Severity.Error);
            return new TableData<User> { Items = [], TotalItems = 0 };
        }
        if (responseHttp.Response == null)
        {
            return new TableData<User> { Items = [], TotalItems = 0 };
        }
        return new TableData<User>
        {
            Items = responseHttp.Response,
            TotalItems = totalRecords
        };
    }

    private async Task SetFilterValue(string value)
    {
        Filter = value;
        await LoadAsync();
        await table.ReloadServerData();
    }

    private async Task DeleteUserAsync(User user) // Cambia el parámetro para recibir el objeto User
    {
        var parameters = new DialogParameters
        {
            { "Message", string.Format(Localizer["DeleteConfirm"], Localizer["User"], $"{user.FirstName} {user.LastName}") } // Usa los literales y el nombre completo del usuario
        };
        var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.ExtraSmall, CloseOnEscapeKey = true };
        var dialog = DialogService.Show<ConfirmDialog>(Localizer["Confirmation"], parameters, options);
        var result = await dialog.Result;

        if (result!.Canceled)
        {
            return;
        }

        loading = true;
        var responseHttp = await Repository.DeleteAsync($"{baseUrl}/{user.Id}"); // Usa user.Id que es string
        loading = false;

        if (responseHttp.Error)
        {
            if (responseHttp.HttpResponseMessage?.StatusCode == HttpStatusCode.NotFound) // Usa HttpResponseMessage?.StatusCode
            {
                NavigationManager.NavigateTo("/users"); // Redirige a la página de usuarios
            }
            else
            {
                var message = await responseHttp.GetErrorMessageAsync();
                Snackbar.Add(Localizer[message!], Severity.Error);
            }
        }
        else
        {
            Snackbar.Add(Localizer["RecordDeletedOk"], Severity.Success); // Reutiliza este literal si ya lo tienes
            await LoadTotalRecordsAsync(); // Si usas paginación o conteo total
            await table.ReloadServerData(); // Recarga la tabla de usuarios
        }
    }
}