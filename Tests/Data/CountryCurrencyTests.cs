using Abc.Data;
using Abc.Tests.Aids;
namespace Abc.Tests.Data;

[TestClass] public sealed class CountryCurrencyTests: BaseTests<CountryCurrency> {
    [TestMethod] public void CountryIdTest() => isProperty<Guid>(nameof(CountryCurrency.CountryId));
    [TestMethod] public void CurrencyIdTest() => isProperty<Guid>(nameof(CountryCurrency.CurrencyId));
    [TestMethod] public void CurrencyTest() => isProperty<Currency>(nameof(CountryCurrency.Currency));
}
