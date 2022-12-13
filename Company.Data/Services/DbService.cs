using AutoMapper;

namespace Company.Data.Services;

public class DbService : IDbService
{
    private readonly CompanyContext _db;
    private readonly IMapper _mapper;

    public DbService(CompanyContext dbContext, IMapper mapper)
	{
        _db = dbContext;
        _mapper = mapper;
    }
}
