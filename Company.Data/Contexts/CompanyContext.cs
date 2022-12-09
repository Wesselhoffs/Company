namespace Company.Data.Contexts;

public class CompanyContext : DbContext
{
	public DbSet<Entities.Company> Companies => Set<Entities.Company>();
	public DbSet<Departement> Departements => Set<Departement>();
	public DbSet<Title> Titles => Set<Title>();
	public DbSet<Employee> Employees => Set<Employee>();
	public DbSet<EmployeeTitle> EmployeeTitles => Set<EmployeeTitle>();


	public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<EmployeeTitle>().HasKey(et => new { et.EmployeeId, et.TitleId });
	}
}
