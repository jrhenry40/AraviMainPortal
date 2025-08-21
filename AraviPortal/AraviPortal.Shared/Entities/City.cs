using AraviPortal.Shared.Resources;
using System.ComponentModel.DataAnnotations;

namespace AraviPortal.Shared.Entities;

public class City : IEquatable<City>
{
    public int Id { get; set; }

    [Display(Name = "City", ResourceType = typeof(Literals))]
    [MaxLength(100, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(Literals))]
    [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Literals))]
    public string Name { get; set; } = null!;

    public ICollection<Hangar>? Hangars { get; set; }

    public int HangarsCount => Hangars == null ? 0 : Hangars.Count;

    public ICollection<User>? Users { get; set; }

    public int UsersCount => Users == null ? 0 : Users.Count;

    public bool Equals(City? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id == other.Id;
    }

    public override bool Equals(object? obj) => Equals(obj as City);

    public override int GetHashCode() => Id.GetHashCode();

    public override string ToString() => Name;
}