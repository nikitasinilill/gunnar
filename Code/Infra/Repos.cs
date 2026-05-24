using Abc.Data;

namespace Abc.Infra;

public class MoviesRepo(ApplicationDbContext c)
    : EfBaseRepo<ApplicationDbContext, Movie>(c), IMoviesRepo { }
public class CurrenciesRepo(ApplicationDbContext c)
    : EfBaseRepo<ApplicationDbContext, Currency>(c), ICurrenciesRepo { }
public class CountriesRepo(ApplicationDbContext c)
    : EfBaseRepo<ApplicationDbContext, Country>(c), ICountriesRepo { }
public class MoniesRepo(ApplicationDbContext c)
    : EfBaseRepo<ApplicationDbContext, Money>(c), IMoniesRepo { }
public class CountryCurrenciesRepo(ApplicationDbContext c)
    : EfBaseRepo<ApplicationDbContext, CountryCurrency>(c), ICountryCurrenciesRepo { }
