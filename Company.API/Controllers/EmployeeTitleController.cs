namespace Company.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeTitleController : ControllerBase
{
    private readonly IDbService _db;

    public EmployeeTitleController(IDbService dbService)
    {
        _db = dbService;
    }
    // POST api/<EmployeeTitleController>
    [HttpPost]
    public async Task<IResult> Post([FromBody] EmployeeTitleDTO employeeTitleDTO)
    {
        return await _db.HttpAddRefEntityAsync<EmployeeTitle, EmployeeTitleDTO>(employeeTitleDTO);
    }

    // DELETE api/<EmployeeTitleController>/5
    [HttpDelete("{id}")]
    public async Task<IResult> Delete(EmployeeTitleDTO employeeTitleDTO)
    {
        return await _db.HttpDeleteAsync<EmployeeTitle, EmployeeTitleDTO>(employeeTitleDTO);
    }
}
