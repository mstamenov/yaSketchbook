using SQLite;
using yaSketchbook.Models.Core;

namespace yaSketchbook.Data.Repositories;

internal abstract class Repository<T> : IRepository<T>
    where T : class, IModel, new()
{
    private SQLiteAsyncConnection db;

    public Repository()
    {
        string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "my1.db");
        
        this.db = new SQLiteAsyncConnection(dbPath);
    }

    public async Task<T> AddAsync(T entity)
    {
        await this.db.InsertAsync(entity, typeof(T));

        return entity;
    }

    public async Task DeleteAsync(T entity)
    {
        await this.PrepareTable();
        await this.db.DeleteAsync(entity);
    }

    public async Task<T> FindAsync(int id)
    {
        await this.PrepareTable();
        return await this.db.GetAsync<T>(id);
    }

    public async Task<List<T>> ToListAsync()
    {
        await this.PrepareTable();
        return await this.db.Table<T>().ToListAsync();
    }

    public async Task<T> UpdateAsync(T entity)
    {
        await this.PrepareTable();
        await this.db.UpdateAsync(entity, typeof(T));

        return entity;
    }

    protected async Task PrepareTable()
    {
        await this.db.CreateTableAsync<T>();
    }
}
