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


    async Task<List<TDto>> IDbService.GetAsync<TEntity, TDto>()
    {
        var entities = await _db.Set<TEntity>().ToListAsync();
        return _mapper.Map<List<TDto>>(entities);
    }

    private async Task<TEntity?> SingleAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class, IEntity
    {
        return await _db.Set<TEntity>().SingleOrDefaultAsync(expression);
    }

    async Task<TDto> IDbService.SingleAsync<TEntity, TDto>(Expression<Func<TEntity, bool>> expression)
    {
        var entity = await SingleAsync(expression);
        return _mapper.Map<TDto>(entity);
    }

    async Task<bool> IDbService.AnyAsync<TEntity>(Expression<Func<TEntity, bool>> expression)
    {
        return await _db.Set<TEntity>().AnyAsync(expression);
    }

    async public Task<bool> SaveChangesAsync()
    {
        return await _db.SaveChangesAsync() >= 0;
    }

    async Task<TEntity> IDbService.AddAsync<TEntity, TDto>(TDto dto)
    {
        var entity = _mapper.Map<TEntity>(dto);
        await _db.Set<TEntity>().AddAsync(entity);
        return entity;
    }
}
