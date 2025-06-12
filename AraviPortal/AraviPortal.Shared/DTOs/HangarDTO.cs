using AraviPortal.Shared.Entities;
using AraviPortal.Shared.Resources;
using System.ComponentModel.DataAnnotations;

namespace AraviPortal.Shared.DTOs;

public class HangarDTO
{
    public int Id { get; set; }

    [Display(Name = "Hangar", ResourceType = typeof(Literals))]
    [MaxLength(100, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(Literals))]
    [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Literals))]
    public string Name { get; set; } = null!;

    [Display(Name = "City", ResourceType = typeof(Literals))]
    public int CityId { get; set; }
}