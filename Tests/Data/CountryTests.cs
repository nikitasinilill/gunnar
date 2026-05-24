using Abc.Data;
using Abc.Tests.Aids;
namespace Abc.Tests.Data;

[TestClass] public sealed class CountryTests: BaseTests<Country> {
    [TestMethod] public void OfficialNameTest() => isProperty<string>(nameof(Country.OfficialName));
    [TestMethod] public void NativeNameTest() => isProperty<string>(nameof(Country.NativeName));
    [TestMethod] public void NumericCodeTest() => isProperty<string>(nameof(Country.NumericCode));
    [TestMethod] public void IsoCodeTest() => isProperty<string>(nameof(Country.IsoCode));
    [TestMethod] public void CurrenciesTest()
        => isProperty<IEnumerable<CountryCurrency>>(nameof(Country.Currencies));
}
