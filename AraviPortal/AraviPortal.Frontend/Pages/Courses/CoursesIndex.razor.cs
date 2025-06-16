using AraviPortal.Shared.Resources;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace AraviPortal.Frontend.Pages.Courses;

public partial class CoursesIndex
{
    private string VideoUrl = "";

    [Inject] private IStringLocalizer<Literals> Localizer { get; set; } = null!;

    [Inject] private NavigationManager NavigationManager { get; set; } = null!;

    [Parameter]
    public string VideoTitle { get; set; } = null!;

    [Parameter]
    public string VideoSource { get; set; } = "videos/mi_video.mp4"; // Ruta a tu archivo de video

    private void GoHome()
    {
        NavigationManager.NavigateTo("/"); ; // Asume que tu página de inicio es la raíz "/"
    }

    private void GoToNextPage()
    {
        NavigationManager.NavigateTo("/ITAwarenessTraining"); ; // Reemplaza "/nextpage" con la ruta de tu siguiente página
    }

    protected override void OnInitialized()
    {
        VideoUrl = "videos/Curso_de_Sensibilizacion_Anual_1.mov";
    }
}