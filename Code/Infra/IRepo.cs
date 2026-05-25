using Abc.Data;
using Abc.Data.Common;

namespace Abc.Infra;

public sealed class Query(Dictionary<string, string> values = null) {
    public static int[] PageSizes => [7, 15, 25, 50, 100];
    public int Page => ToInt(Get(nameof(Page)), 1);
    public int PageSize => ToInt(Get(nameof(PageSize)), PageSizes[0]);
    public string SortBy => Get(nameof(SortBy));
    public string SortDir => Get(nameof(SortDir));
    public string SearchBy => Get(nameof(SearchBy));
    public string SearchStr => Get(nameof(SearchStr));

    private string Get(string name) => (values ?? []).TryGetValue(name, out var value) ? value : null;
    private static int ToInt(string value, int defaultValue)
        => int.TryParse(value, out var result) ? result : defaultValue;
}

public interface IRepo<TEntity> where TEntity : BaseEntity {
    Task<TEntity> GetAsync(Guid id);
    Task<IEnumerable<TEntity>> GetAsync();
    Task<int> CountAsync(Query query);
    Task<IEnumerable<TEntity>> GetAsync(Query query);
    Task<TEntity> CreateAsync(TEntity e);
    Task<TEntity> UpdateAsync(TEntity e);
    Task DeleteAsync(Guid id);
}

public interface IMoviesRepo: IRepo<Movie> { }
public interface ICountriesRepo: IRepo<Country> { }
public interface ICurrenciesRepo: IRepo<Currency> { }
public interface IMoniesRepo: IRepo<Money> { }
public interface ICountryCurrenciesRepo: IRepo<CountryCurrency> { }
