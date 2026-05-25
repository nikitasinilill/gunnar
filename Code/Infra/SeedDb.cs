using Abc.Aids;
using Abc.Data;
using Microsoft.EntityFrameworkCore;

namespace Abc.Infra;

public sealed class SeedDb(ApplicationDbContext db, int recordCount = 20) {
    public async Task Seed() {
        await db.Database.MigrateAsync();

        await SeedTable(db.Currencies, [nameof(Currency.Timestamp)]);
        await SeedTable(db.Countries, [nameof(Country.Currencies), nameof(Country.Timestamp)]);
        await SeedTable(db.Monies, [nameof(Money.CurrencyId), nameof(Money.Currency), nameof(Money.Timestamp)]);
        await SeedTable(db.CountryCurrencies, [
            nameof(CountryCurrency.CurrencyId),
            nameof(CountryCurrency.CountryId),
            nameof(CountryCurrency.Currency),
            nameof(CountryCurrency.Timestamp)
        ]);
        await SeedTable(db.Movies, [nameof(Movie.Country), nameof(Movie.Money), nameof(Movie.Timestamp)]);
    }

    private async Task SeedTable<TEntity>(DbSet<TEntity> set, string[] exclude = null) where TEntity : class {
        if (await set.AnyAsync()) return;

        var items = new List<TEntity>();
        for (var i = 0; i < recordCount; i++) {
            var item = (TEntity) GetRandom.Object(typeof(TEntity), exclude);
            items.Add(item);
        }

        await set.AddRangeAsync(items);
        await db.SaveChangesAsync();
    }
}
