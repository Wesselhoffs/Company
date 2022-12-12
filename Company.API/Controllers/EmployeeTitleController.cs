namespace Company.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeTitleController : ControllerBase
{
    private readonly CompanyContext _context;

    public EmployeeTitleController(CompanyContext context)
    {
        _context = context;
    }

    // GET: api/EmployeeTitle
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EmployeeTitle>>> GetEmployeeTitles()
    {
        return await _context.EmployeeTitles.ToListAsync();
    }

    // GET: api/EmployeeTitle/5
    [HttpGet("{id}")]
    public async Task<ActionResult<EmployeeTitle>> GetEmployeeTitle(int id)
    {
        var employeeTitle = await _context.EmployeeTitles.FindAsync(id);

        if (employeeTitle == null)
        {
            return NotFound();
        }

        return employeeTitle;
    }

    // PUT: api/EmployeeTitle/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutEmployeeTitle(int id, EmployeeTitle employeeTitle)
    {
        if (id != employeeTitle.EmployeeId)
        {
            return BadRequest();
        }

        _context.Entry(employeeTitle).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EmployeeTitleExists(id))
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

    // POST: api/EmployeeTitle
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<EmployeeTitle>> PostEmployeeTitle(EmployeeTitle employeeTitle)
    {
        _context.EmployeeTitles.Add(employeeTitle);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException)
        {
            if (EmployeeTitleExists(employeeTitle.EmployeeId))
            {
                return Conflict();
            }
            else
            {
                throw;
            }
        }

        return CreatedAtAction("GetEmployeeTitle", new { id = employeeTitle.EmployeeId }, employeeTitle);
    }

    // DELETE: api/EmployeeTitle/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployeeTitle(int id)
    {
        var employeeTitle = await _context.EmployeeTitles.FindAsync(id);
        if (employeeTitle == null)
        {
            return NotFound();
        }

        _context.EmployeeTitles.Remove(employeeTitle);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool EmployeeTitleExists(int id)
    {
        return _context.EmployeeTitles.Any(e => e.EmployeeId == id);
    }
}
