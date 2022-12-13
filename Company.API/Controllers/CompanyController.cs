using Company.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Company.API.Controllers
{
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
            return Results.Ok(await _db.GetAsync<Data.Entities.Company, CompanyDTO>());
        }

        // GET api/<CompanyController>/5
        [HttpGet("{id}")]
        public async Task<IResult> Get(int id)
        {
            var result = await _db.SingleAsync<Data.Entities.Company, CompanyDTO>(c => c.Id.Equals(id));
            if (result is null)
            {
                return Results.NotFound();
            }
            else
            {
                return Results.Ok(result);
            }
        }

        // POST api/<CompanyController>
        [HttpPost]
        public async Task<IResult> Post([FromBody] CompanyDTO dto)
        {
            try
            {
                var entity = await _db.AddAsync<Data.Entities.Company, CompanyDTO>(dto);
                if (await _db.SaveChangesAsync())
                {
                    var node = typeof(Data.Entities.Company).Name.ToLower();                   
                    return Results.Created($"/{node}/{entity.Id}",entity);
                }
            }
            catch (Exception ex)
            {
                return Results.BadRequest($"Couldn't add the {typeof(Data.Entities.Company).Name} entity.\n{ex}.");
            }
            return Results.BadRequest($"Couldn't add the {typeof(Data.Entities.Company).Name}entity.");

        }

        // PUT api/<CompanyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
