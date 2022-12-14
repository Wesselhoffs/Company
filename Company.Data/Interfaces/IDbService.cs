namespace Company.Data.Interfaces;

public interface IDbService
{
    Task<List<TDto>> GetAsync<TEntity, TDto>() where TEntity : class, IEntity where TDto : class;

    Task<TDto> SingleAsync<TEntity, TDto>(Expression<Func<TEntity, bool>> expression) where TEntity : class, IEntity where TDto : class;

    Task<bool> AnyAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class, IEntity;

    Task<TEntity> AddAsync<TEntity, TDto>(TDto dto) where TEntity : class, IEntity where TDto : class;

    Task<bool> SaveChangesAsync();

    void Update<TEntity, TDto>(int id, TDto dto) where TEntity : class, IEntity where TDto: class;
}
