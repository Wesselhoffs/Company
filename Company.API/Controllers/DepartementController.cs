namespace Company.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepartementController : ControllerBase
{
    private readonly IDbService _db;

    public DepartementController(IDbService dbService)
    {
        _db = dbService;
    }

    // GET: api/<DepartementController>
    [HttpGet]
    public async Task<IResult> Get()
    {
        return await _db.HttpGetAsync<Departement, DepartementDTO>();
    }

    // GET api/<DepartementController>/5
    [HttpGet("{id}")]
    public async Task<IResult> Get(int id)
    {
        return await _db.HttpSingleAsync<Departement, DepartementDTO>(id);
    }

    // POST api/<DepartementController>
    [HttpPost]
    public async Task<IResult> Post([FromBody] DepartementDTO dto)
    {
        return await _db.HttpAddAsync<Departement, DepartementDTO>(dto);
    }

    // PUT api/<DepartementController>/5
    [HttpPut("{id}")]
    public async Task<IResult> Put(int id, [FromBody] DepartementDTO dto)
    {
        return await _db.HttpUpdate<Departement, DepartementDTO>(dto, id);
    }

    // DELETE api/<DepartementController>/5
    [HttpDelete("{id}")]
    public async Task<IResult> Delete(int id)
    {
        return await _db.HttpDeleteAsync<Departement>(id);
    }
}
