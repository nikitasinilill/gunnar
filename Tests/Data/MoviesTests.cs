using Abc.Data;
using Abc.Tests.Aids;
namespace Abc.Tests.Data;

[TestClass] public sealed class MovieTests : BaseTests<Movie> {
    [TestMethod] public void IdTest() => isProperty<Guid>(nameof(Movie.Id));
    [TestMethod] public void NameTest() => isProperty<string>(nameof(Movie.Name));
    [TestMethod] public void ValidFromTest() => isProperty<DateTime?>(nameof(Movie.ValidFrom));
    [TestMethod] public void GenreTest() => isProperty<string>(nameof(Movie.Genre));
    [TestMethod] public void PriceTest() => isProperty<decimal>(nameof(Movie.Price));
    [TestMethod] public void MoneyTest() => isProperty<Money>(nameof(Movie.Money));
    [TestMethod] public void CountryTest() => isProperty<Country>(nameof(Movie.Country));
}
