using SQLite;
using yaSketchbook.Models.Core;

namespace yaSketchbook.Data.Repositories;

internal abstract class Repository<T> : IRepository<T>
    where T : class, IModel, new()
{
    private SQLiteAsyncConnection _db;

    public Repository()
    {
        string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "my1.db");
        
        _db = new SQLiteAsyncConnection(dbPath);

        Task.Run(async () => await _db.CreateTableAsync<T>());
        
    }

    public async Task<T> AddAsync(T entity)
    {
        await _db.InsertAsync(entity, typeof(T));

        return entity;
    }

    public async Task DeleteAsync(T entity)
    {
        await _db.DeleteAsync(entity);
    }

    public async Task<T> FindAsync(int id) => await _db.GetAsync<T>(id);

    public async Task<List<T>> ToListAsync() => await _db.Table<T>().ToListAsync();

    public async Task<T> UpdateAsync(T entity)
    {
        await _db.UpdateAsync(entity, typeof(T));

        return entity;
    }
}
