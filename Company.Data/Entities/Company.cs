namespace Company.Data.Entities;

public class Company : IEntity
{
    public int Id { get; set; }
    [MaxLength(100), Required]
    public string? Name { get; set; }
    [MaxLength(50), Required]
    public string? OrganizationNr { get; set; }
    public virtual ICollection<Departement>? Departements { get; set; }
}