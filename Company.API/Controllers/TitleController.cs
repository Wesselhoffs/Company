namespace Company.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TitleController : ControllerBase
{
    private readonly IDbService _db;

    public TitleController(IDbService dbService)
    {
        _db = dbService;
    }
    // GET: api/<TitleController>
    [HttpGet]
    public async Task<IResult> Get()
    {
        return await _db.HttpGetAsync<Title, TitleDTO>();
    }

    // GET api/<TitleController>/5
    [HttpGet("{id}")]
    public async Task<IResult> Get(int id)
    {
        return await _db.HttpSingleAsync<Title, TitleDTO>(id);
    }

    // POST api/<TitleController>
    [HttpPost]
    public async Task<IResult> Post([FromBody] TitleDTO dto)
    {
        return await _db.HttpAddAsync<Title, TitleDTO>(dto);
    }

    // PUT api/<TitleController>/5
    [HttpPut("{id}")]
    public async Task<IResult> Put(int id, [FromBody] TitleDTO dto)
    {
        return await _db.HttpUpdate<Title, TitleDTO>(dto, id);
    }

    // DELETE api/<TitleController>/5
    [HttpDelete("{id}")]
    public async Task<IResult> Delete(int id)
    {
        return await _db.HttpDeleteAsync<Title>(id);
    }
}
