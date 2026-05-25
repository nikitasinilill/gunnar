using Abc.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Abc.Infra;

public class EfBaseRepo<TContext, TEntity> (TContext c): IRepo<TEntity>
    where TContext : DbContext
    where TEntity : BaseEntity {
    protected readonly TContext db = c;
    private IQueryable<TEntity> Set => db.Set<TEntity>();

    public async Task<int> CountAsync(Query query) {
        return await Set.CountAsync();
    }

    public async Task<TEntity> CreateAsync(TEntity e) {
        await db.AddAsync(e);
        await db.SaveChangesAsync();
        return e;
    }
    public Task DeleteAsync(Guid id) {
        return DeleteCoreAsync(id);
    }
    public async Task<TEntity> GetAsync(Guid id) {
        return await Set.FirstOrDefaultAsync(x => x.Id == id);
    }
    public async Task<IEnumerable<TEntity>> GetAsync() {
        return await GetAllCoreAsync();
    }
    public async Task<IEnumerable<TEntity>> GetAsync(Query query) {
        return await GetPageCoreAsync(query ?? new Query());
    }
    public async Task<TEntity> UpdateAsync(TEntity e) {
        db.Update(e);
        await db.SaveChangesAsync();
        return e;
    }
    private async Task DeleteCoreAsync(Guid id) {
        var entity = await GetAsync(id);
        if (entity is null) return;
        db.Remove(entity);
        await db.SaveChangesAsync();
    }
    private async Task<IEnumerable<TEntity>> GetAllCoreAsync() {
        return await Set.ToListAsync();
    }
    private async Task<IEnumerable<TEntity>> GetPageCoreAsync(Query query) {
        var skip = (query.Page - 1) * query.PageSize;
        var take = query.PageSize;
        return await Set
            .OrderBy(x => x.ValidTo)
            .Skip(skip)
            .Take(take)
            .AsNoTracking()
            .ToListAsync();
    }
}
