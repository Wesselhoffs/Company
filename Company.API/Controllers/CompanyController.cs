namespace Company.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompanyController : ControllerBase
{
    private readonly IDbService _db;

    public CompanyController(IDbService dbService)
    {
        _db = dbService;
    }

    // GET: api/<CompanyController>
    [HttpGet]
    public async Task<IResult> Get()
    {
       return await _db.HttpGetAsync<Data.Entities.Company, CompanyDTO>();
    }

    // GET api/<CompanyController>/5
    [HttpGet("{id}")]
    public async Task<IResult> Get(int id)
    {
        return await _db.HttpSingleAsync<Data.Entities.Company, CompanyDTO>(id);
    }

    // POST api/<CompanyController>
    [HttpPost]
    public async Task<IResult> Post([FromBody] CompanyDTO dto)
    {
        return await _db.HttpAddAsync<Data.Entities.Company, CompanyDTO>(dto);
    }

    // PUT api/<CompanyController>/5
    [HttpPut("{id}")]
    public async Task<IResult> Put(int id, [FromBody] CompanyDTO dto)
    {
        return await _db.HttpUpdate<Data.Entities.Company, CompanyDTO>(dto, id);
    }

    // DELETE api/<CompanyController>/5
    [HttpDelete("{id}")]
    public async Task<IResult> Delete(int id)
    {
        return await _db.HttpDeleteAsync<Data.Entities.Company>(id);
    }
}
