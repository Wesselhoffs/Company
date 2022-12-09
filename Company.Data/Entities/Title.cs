namespace Company.Data.Entities;

public class Title
{
    public int Id { get; set; }
    [MaxLength(50), Required]
    public string? Name { get; set; }
    public virtual ICollection<Employee>? Employees { get; set; }
}