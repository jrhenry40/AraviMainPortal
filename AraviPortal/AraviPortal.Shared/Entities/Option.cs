using AraviPortal.Shared.Resources;
using System.ComponentModel.DataAnnotations;

namespace AraviPortal.Shared.Entities;

public class Option
{
    public int Id { get; set; }

    [Display(Name = "TextOption", ResourceType = typeof(Literals))]
    [MaxLength(500, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(Literals))]
    [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Literals))]
    public string TextOption { get; set; } = null!;

    [Display(Name = "IsCorrect", ResourceType = typeof(Literals))]
    public bool IsCorrect { get; set; }

    public Question? Question { get; set; }

    public int QuestionId { get; set; }
}