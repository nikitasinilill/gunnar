using Abc.Data;
using Microsoft.EntityFrameworkCore;

namespace Abc.Infra;

public class MoviesRepo(ApplicationDbContext c)
    : EfBaseRepo<ApplicationDbContext, Movie>(c), IMoviesRepo { }
public class CurrenciesRepo(ApplicationDbContext c)
    : EfBaseRepo<ApplicationDbContext, Currency>(c), ICurrenciesRepo { }
public class CountriesRepo(ApplicationDbContext c)
    : EfBaseRepo<ApplicationDbContext, Country>(c), ICountriesRepo {
    protected override IQueryable<Country> Query() => db.Countries
        .Include(x => x.CountryCurrencies)
        .ThenInclude(x => x.Currency);
}
public class MoniesRepo(ApplicationDbContext c)
    : EfBaseRepo<ApplicationDbContext, Money>(c), IMoniesRepo { }
public class CountryCurrenciesRepo(ApplicationDbContext c)
    : EfBaseRepo<ApplicationDbContext, CountryCurrency>(c), ICountryCurrenciesRepo {
    protected override IQueryable<CountryCurrency> Query() => db.CountryCurrencies
        .Include(x => x.Country)
        .Include(x => x.Currency);
}
