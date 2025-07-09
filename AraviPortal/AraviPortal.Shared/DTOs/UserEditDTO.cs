using AraviPortal.Shared.Enums;
using AraviPortal.Shared.Resources;
using System.ComponentModel.DataAnnotations;

namespace AraviPortal.Shared.DTOs;

public class UserEditDTO
{
    [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Literals))]
    public string Id { get; set; } = null!; // Se necesita el ID para identificar al usuario

    [Display(Name = "FirstName", ResourceType = typeof(Literals))]
    [MaxLength(50, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(Literals))]
    [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Literals))]
    public string FirstName { get; set; } = null!;

    [Display(Name = "LastName", ResourceType = typeof(Literals))]
    [MaxLength(50, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(Literals))]
    [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Literals))]
    public string LastName { get; set; } = null!;

    [Display(Name = "PhoneNumber", ResourceType = typeof(Literals))]
    public string? PhoneNumber { get; set; }

    [Display(Name = "City", ResourceType = typeof(Literals))]
    [Range(1, int.MaxValue, ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Literals))]
    public int CityId { get; set; }

    [Display(Name = "UserType", ResourceType = typeof(Literals))]
    [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Literals))]
    public UserType UserType { get; set; } // Permitir cambiar el tipo de usuario (rol)

    //public string Language { get; set; } = null!;
}