using AraviPortal.Shared.Resources;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;

namespace AraviPortal.Frontend.Pages.Courses;

public partial class ITAwarenessTraining
{
    private string VideoUrl = "";
    private ElementReference videoElement; // Referencia al elemento <video>
    private bool _isNextButtonDisabled = true; // Inicialmente desactivado

    [Inject] private IStringLocalizer<Literals> Localizer { get; set; } = null!;

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

    // Método que será invocado desde JavaScript
    [JSInvokable] // ¡Importante! Marca este método para que sea invocable desde JS
    public void VideoEnded()
    {
        _isNextButtonDisabled = false; // Activar el botón cuando el video termine
        StateHasChanged(); // Forzar la actualización de la UI
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender && !string.IsNullOrEmpty(VideoUrl))
        {
            // Llamar a una función JavaScript para configurar el listener del evento 'ended'
            await JSRuntime.InvokeVoidAsync("setupVideoEndedListener", videoElement, DotNetObjectReference.Create(this));
        }
    }
}