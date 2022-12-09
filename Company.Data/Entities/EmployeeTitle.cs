namespace Company.Data.Entities;

public class EmployeeTitle : IReferenceEntity
{
    [Required]
    public int EmployeeId { get; set; }
    [Required]
    public int TitleId { get; set; }
    public virtual Employee? Employee { get; set; }
    public virtual Title? Title { get; set; }
}