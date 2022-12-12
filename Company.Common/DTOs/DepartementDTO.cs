namespace Company.Common.DTOs;
public record DepartementDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int CompanyId { get; set; }
}
