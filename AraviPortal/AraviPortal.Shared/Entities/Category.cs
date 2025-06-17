using AraviPortal.Shared.Resources;
using System.ComponentModel.DataAnnotations;

namespace AraviPortal.Shared.Entities;

public class Category
{
    public int Id { get; set; }

    [Display(Name = "Category", ResourceType = typeof(Literals))]
    [MaxLength(100, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(Literals))]
    [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Literals))]
    public string Name { get; set; } = null!;

    [Display(Name = "Description", ResourceType = typeof(Literals))]
    [MaxLength(100, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(Literals))]
    [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Literals))]
    public string? Description { get; set; }

    public ICollection<Question>? Questions { get; set; }

    public int QuestionsCount => Questions == null ? 0 : Questions.Count;
}