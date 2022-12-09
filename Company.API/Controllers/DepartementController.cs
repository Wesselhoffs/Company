namespace Company.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepartementController : ControllerBase
{
    private readonly CompanyContext _context;

    public DepartementController(CompanyContext context)
    {
        _context = context;
    }

    // GET: api/Departement
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Departement>>> GetDepartements()
    {
        return await _context.Departements.ToListAsync();
    }

    // GET: api/Departement/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Departement>> GetDepartement(int id)
    {
        var departement = await _context.Departements.FindAsync(id);

        if (departement == null)
        {
            return NotFound();
        }

        return departement;
    }

    // PUT: api/Departement/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutDepartement(int id, Departement departement)
    {
        if (id != departement.Id)
        {
            return BadRequest();
        }

        _context.Entry(departement).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!DepartementExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Departement
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Departement>> PostDepartement(Departement departement)
    {
        _context.Departements.Add(departement);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetDepartement", new { id = departement.Id }, departement);
    }

    // DELETE: api/Departement/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDepartement(int id)
    {
        var departement = await _context.Departements.FindAsync(id);
        if (departement == null)
        {
            return NotFound();
        }

        _context.Departements.Remove(departement);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool DepartementExists(int id)
    {
        return _context.Departements.Any(e => e.Id == id);
    }
}
