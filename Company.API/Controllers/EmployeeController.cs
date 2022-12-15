namespace Company.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IDbService _db;

    public EmployeeController(IDbService dbService)
    {
        _db = dbService;
    }
    // GET: api/<EmployeeController>
    [HttpGet]
    public async Task<IResult> Get()
    {
        return await _db.HttpGetAsync<Employee, EmployeeDTO>();
    }

    // GET api/<EmployeeController>/5
    [HttpGet("{id}")]
    public async Task<IResult> Get(int id)
    {
        return await _db.HttpSingleAsync<Employee, EmployeeDTO>(id);
    }

    // POST api/<EmployeeController>
    [HttpPost]
    public async Task<IResult> Post([FromBody] EmployeeDTO dto)
    {
        return await _db.HttpAddAsync<Employee, EmployeeDTO>(dto);
    }

    // PUT api/<EmployeeController>/5
    [HttpPut("{id}")]
    public async Task<IResult> Put(int id, [FromBody] EmployeeDTO dto)
    {
        return await _db.HttpUpdate<Employee, EmployeeDTO>(dto, id);
    }

    // DELETE api/<EmployeeController>/5
    [HttpDelete("{id}")]
    public async Task<IResult> Delete(int id)
    {
        return await _db.HttpDeleteAsync<Employee>(id);
    }
}
