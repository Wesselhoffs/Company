namespace Company.Common.DTOs;

public record EmployeeTitleDTO
{
    public int EmployeeId { get; set; }
    public int TitleId { get; set; }

    public EmployeeTitleDTO(int emplyeeId, int titleId)
    {
        EmployeeId = emplyeeId;
        TitleId = titleId;
    }
}
