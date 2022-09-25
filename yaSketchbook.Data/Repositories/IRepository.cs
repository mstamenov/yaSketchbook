namespace yaSketchbook.Data.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    TEntity Add(TEntity entity);
    
    TEntity Find(int id);

    List<TEntity> ToList();

    TEntity Update(TEntity entity);

    void Delete(TEntity entity);
 
}
