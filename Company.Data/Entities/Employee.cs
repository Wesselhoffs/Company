namespace Company.Data.Entities;

public class Employee : IEntity
{
    public int Id { get; set; }
    [MaxLength(50), Required]
    public string? FirstName { get; set; }
    [MaxLength(50), Required]
    public string? LastName { get; set; }
    [Required]
    public int DepartementId { get; set; }
    [Required]
    public decimal Salary { get; set; }
    public bool? UnionMember { get; set; }
    public virtual Departement? Departement { get; set; }
    public virtual ICollection<Title>? Titles { get; set; }
}
