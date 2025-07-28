using Microsoft.EntityFrameworkCore;
using TheEasyBazar.Data.DbContexts;
using TheEasyBazar.Data.IRepositories;
using TheEasyBazar.Domain.Commons;

namespace TheEasyBazar.Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
{
    private readonly AppDbContext? dbContext;
    private readonly DbSet<TEntity>? dbSet;

    public Repository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
        this.dbSet = this.dbContext.Set<TEntity>();
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var entity = await this.dbSet.FirstOrDefaultAsync(e => e.Id == id);
        this.dbSet.Remove(entity);
        await this.dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<TEntity> InsertAsync(TEntity entity)
    {
        var model = await this.dbSet.AddAsync(entity);
        await this.dbContext.SaveChangesAsync();

        return model.Entity;
    }

    public async Task<bool> SaveChangeAsync()
    {
        return await this.dbContext?.SaveChangesAsync() > 0;
    }

    public IQueryable<TEntity> SelectAll()
    {
        return dbSet;
    }

    public async Task<TEntity> SelectByIdAsync(long id)
    {
        var entity = await this.dbSet.FirstOrDefaultAsync(entity => entity.Id == id);

        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        var model = this.dbSet.Update(entity);
        await this.dbContext.SaveChangesAsync();

        return model.Entity;
    }
}
