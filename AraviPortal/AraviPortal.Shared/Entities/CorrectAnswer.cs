using AraviPortal.Shared.Resources;
using System.ComponentModel.DataAnnotations;

namespace AraviPortal.Shared.Entities;

public class CorrectAnswer
{
    public int Id { get; set; }

    [Display(Name = "ValueFalseTrue", ResourceType = typeof(Literals))]
    [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Literals))]
    public bool? ValueFalseTrue { get; set; }

    public Question? Question { get; set; }

    public int QuestionId { get; set; }

    public Option? Option { get; set; }

    public int OptionId { get; set; }
}