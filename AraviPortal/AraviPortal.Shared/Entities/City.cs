using System.ComponentModel.DataAnnotations;

namespace AraviPortal.Shared.Entities;

public class City
{
    public int Id { get; set; }

    [MaxLength(100)]
    [Required]
    public string Name { get; set; } = null!;
}