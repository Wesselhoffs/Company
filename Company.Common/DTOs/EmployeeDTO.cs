namespace Company.Common.DTOs;
public record EmployeeDTO
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int DepartementId { get; set; }
    public decimal Salary { get; set; }
    public bool? UnionMember { get; set; }
}
