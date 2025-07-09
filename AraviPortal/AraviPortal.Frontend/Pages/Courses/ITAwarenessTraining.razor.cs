using AraviPortal.Shared.Resources;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using MudBlazor;

namespace AraviPortal.Frontend.Pages.Courses;

public partial class ITAwarenessTraining
{
    private string VideoUrl = "";
    private ElementReference videoElement;
    private bool _isNextButtonDisabled = true;
    private bool isPlaying = false;
    private double Volume = 1;
    private bool showControls = false;

    // Referencia al objeto .NET para pasar a JavaScript
    private DotNetObjectReference<ITAwarenessTraining>? dotNetObjectReference;

    [Inject] private IStringLocalizer<Literals> Localizer { get; set; } = null!;
    [Inject] private IDialogService DialogService { get; set; } = null!;
    [Inject] private ISnackbar Snackbar { get; set; } = null!;
    [Inject] private NavigationManager NavigationManager { get; set; } = null!;
    [Inject] private IJSRuntime JSRuntime { get; set; } = null!;

    private void GoHome()
    {
        NavigationManager.NavigateTo("/ITCourse");
    }

    private void GoToNextPage()
    {
        NavigationManager.NavigateTo("/AccessToPublications");
    }

    protected override void OnInitialized()
    {
        VideoUrl = "videos/Curso_de_Sensibilizacion_Anual_1.mov";
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        // Solo ejecuta este código la primera vez que se renderiza el componente
        if (firstRender && !string.IsNullOrEmpty(VideoUrl))
        {
            // Crea la referencia al objeto .NET solo una vez
            dotNetObjectReference = DotNetObjectReference.Create(this);

            // Llama a la función JavaScript para configurar el listener
            await JSRuntime.InvokeVoidAsync("setupVideoEndedListener", videoElement, dotNetObjectReference);
        }
    }

    // Este método es llamado desde JavaScript cuando el video termina.
    [JSInvokable]
    public void OnVideoEnded() // <-- Nombre del método corregido para que coincida con JS
    {
        _isNextButtonDisabled = false;
        StateHasChanged(); // Fuerza la actualización de la UI
    }

    // Método para limpiar recursos cuando el componente se destruye
    public void Dispose()
    {
        // Dispone de la referencia al objeto .NET para evitar fugas de memoria
        dotNetObjectReference?.Dispose();
    }

    // Tus otros métodos (TogglePlayPause, OnVolumeChanged, ToggleFullscreen)
    // van aquí, sin cambios.

    private async Task TogglePlayPause()
    {
        if (isPlaying)
        {
            await JSRuntime.InvokeVoidAsync("pauseVideo", videoElement);
        }
        else
        {
            await JSRuntime.InvokeVoidAsync("playVideo", videoElement);
        }
        isPlaying = !isPlaying;
    }

    private async Task OnVolumeChanged(double newVolume)
    {
        Volume = newVolume;
        await JSRuntime.InvokeVoidAsync("setVideoVolume", videoElement, Volume);
    }

    private async Task ToggleFullscreen()
    {
        await JSRuntime.InvokeVoidAsync("toggleFullscreen", videoElement);
    }
}