using SQLite;
using yaSketchbook.Models.Core;

namespace yaSketchbook.Data.Repositories;

internal abstract class Repository<T> : IRepository<T>
    where T : class, IModel, new()
{
    private SQLiteConnection _db;

    public Repository()
    {
        string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "my.db");
        
        _db = new SQLiteConnection(dbPath);

        _db.CreateTable<T>();
    }

    public T Add(T entity)
    {
        _db.Insert(entity, typeof(T));

        return entity;
    }

    public void Delete(T entity)
    {
        _db.Delete(entity);
    }

    public T Find(int id) => _db.Get<T>(id);

    public List<T> ToList() => _db.Table<T>().ToList();

    public T Update(T entity)
    {
        _db.Update(entity, typeof(T));

        return entity;
    }
}
