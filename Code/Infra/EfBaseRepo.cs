using Abc.Data.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace Abc.Infra;

public class EfBaseRepo<TContext, TEntity> (TContext c): IRepo<TEntity>
    where TContext : DbContext
    where TEntity : BaseEntity {
    protected readonly TContext db = c;
    protected virtual IQueryable<TEntity> Query() => db.Set<TEntity>();
    private static readonly BindingFlags Flags
        = BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance;

    public async Task<int> CountAsync(Query query) {
        return await AddSearch(Query(), query ?? new Query()).CountAsync();
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
        return await Query().FirstOrDefaultAsync(x => x.Id == id);
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
        return await Query().ToListAsync();
    }
    private async Task<IEnumerable<TEntity>> GetPageCoreAsync(Query query) {
        var result = AddSearch(Query(), query);
        result = AddSort(result, query);
        result = AddPaging(result, query);

        return await result
            .AsNoTracking()
            .ToListAsync();
    }
    private static IQueryable<TEntity> AddSearch(IQueryable<TEntity> source, Query query) {
        var predicate = SearchBy(query.SearchBy, query.SearchStr);
        return predicate is null ? source : source.Where(predicate);
    }
    private static IQueryable<TEntity> AddSort(IQueryable<TEntity> source, Query query) {
        var key = SortBy(query.SortBy);
        if (key is null) return source.OrderBy(x => x.ValidTo);
        return query.SortDir == "desc"
            ? source.OrderByDescending(key)
            : source.OrderBy(key);
    }
    private static IQueryable<TEntity> AddPaging(IQueryable<TEntity> source, Query query) {
        var skip = (query.Page - 1) * query.PageSize;
        var take = query.PageSize;
        return source.Skip(skip).Take(take);
    }
    private static PropertyInfo GetProperty(string propertyName)
        => string.IsNullOrWhiteSpace(propertyName)
            ? null
            : typeof(TEntity).GetProperty(propertyName, Flags);
    private static Expression<Func<TEntity, object>> SortBy(string propertyName) {
        var property = GetProperty(propertyName);
        if (property is null) return null;

        var parameter = Expression.Parameter(typeof(TEntity), "x");
        var member = Expression.Property(parameter, property);
        var converted = Expression.Convert(member, typeof(object));
        return Expression.Lambda<Func<TEntity, object>>(converted, parameter);
    }
    private static Expression<Func<TEntity, bool>> SearchBy(string propertyName, string searchString) {
        var property = GetProperty(propertyName);
        if (property?.PropertyType != typeof(string)) return null;
        if (string.IsNullOrWhiteSpace(searchString)) return null;

        var parameter = Expression.Parameter(typeof(TEntity), "x");
        var member = Expression.Property(parameter, property);
        var notNull = Expression.NotEqual(member, Expression.Constant(null, typeof(string)));
        var contains = Expression.Call(
            member,
            nameof(string.Contains),
            Type.EmptyTypes,
            Expression.Constant(searchString));
        var body = Expression.AndAlso(notNull, contains);
        return Expression.Lambda<Func<TEntity, bool>>(body, parameter);
    }
}
