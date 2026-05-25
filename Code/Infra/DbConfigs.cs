using Abc.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Abc.Infra;

public sealed class CountryConfig: IEntityTypeConfiguration<Country> {
    public void Configure(EntityTypeBuilder<Country> builder) {
        builder.HasMany(x => x.CountryCurrencies)
            .WithOne(x => x.Country)
            .HasForeignKey(x => x.CountryId);
    }
}

public sealed class CurrencyConfig: IEntityTypeConfiguration<Currency> {
    public void Configure(EntityTypeBuilder<Currency> builder) { }
}

public sealed class MovieConfig: IEntityTypeConfiguration<Movie> {
    public void Configure(EntityTypeBuilder<Movie> builder) { }
}

public sealed class MoneyConfig: IEntityTypeConfiguration<Money> {
    public void Configure(EntityTypeBuilder<Money> builder) {
        builder.Property(x => x.Amount).HasColumnType("decimal(18, 2)");
    }
}

public sealed class CountryCurrencyConfig: IEntityTypeConfiguration<CountryCurrency> {
    public void Configure(EntityTypeBuilder<CountryCurrency> builder) {
        builder.HasOne(x => x.Country)
            .WithMany(x => x.CountryCurrencies)
            .HasForeignKey(x => x.CountryId);

        builder.HasOne(x => x.Currency)
            .WithMany()
            .HasForeignKey(x => x.CurrencyId);
    }
}
