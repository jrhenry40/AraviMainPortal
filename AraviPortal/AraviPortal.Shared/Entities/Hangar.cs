using System.ComponentModel.DataAnnotations;

namespace AraviPortal.Shared.Entities;

public class Hangar
{
    public int Id { get; set; }

    [MaxLength(100)]
    [Required]
    public string Name { get; set; } = null!;

    public City City { get; set; } = null!;

    public int CityId { get; set; }
}