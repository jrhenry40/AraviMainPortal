using AraviPortal.Shared.Enums;
using AraviPortal.Shared.Resources;
using System.ComponentModel.DataAnnotations;

namespace AraviPortal.Shared.Entities;

public class Question
{
    public int Id { get; set; }

    [Display(Name = "Statement", ResourceType = typeof(Literals))]
    [MaxLength(500, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(Literals))]
    [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Literals))]
    public string Statement { get; set; } = null!;

    [Display(Name = "QuestionType", ResourceType = typeof(Literals))]
    public QuestionType QuestionType { get; set; }

    [Display(Name = "Score", ResourceType = typeof(Literals))]
    [MaxLength(500, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(Literals))]
    [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Literals))]
    public int Score { get; set; } = 10;

    public Category? Category { get; set; }

    public int CategoryId { get; set; }

    public CorrectAnswer? CorrectAnswer { get; set; }

    public int CorrectAnswerId { get; set; }

    public ICollection<Option>? Options { get; set; }
}