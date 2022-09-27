namespace yaSketchbook.Data.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    Task<TEntity> AddAsync(TEntity entity);
    
    Task<TEntity> FindAsync(int id);

    Task<List<TEntity>> ToListAsync();

    Task<TEntity> UpdateAsync(TEntity entity);

    Task DeleteAsync(TEntity entity);
 
}
