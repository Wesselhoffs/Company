namespace Company.Data.Entities;

public class Departement : IEntity
{
    public int Id { get; set; }
    [MaxLength(100), Required]
    public string? Name { get; set; }
    [Required]
    public int CompanyId { get; set; }
    public virtual Company? Company { get; set; }
}