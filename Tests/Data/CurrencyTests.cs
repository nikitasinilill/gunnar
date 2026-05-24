using Abc.Data;
using Abc.Tests.Aids;
namespace Abc.Tests.Data;

[TestClass] public sealed class CurrencyTests: BaseTests<Currency> {
    [TestMethod] public void NumericCodeTest() => isProperty<string>(nameof(Currency.NumericCode));
    [TestMethod] public void MajorUnitSymbolTest() => isProperty<string>(nameof(Currency.MajorUnitSymbol));
    [TestMethod] public void MinorUnitSymbolTest() => isProperty<string>(nameof(Currency.MinorUnitSymbol));
    [TestMethod] public void RatioOfMinorUnitTest() => isProperty<double>(nameof(Currency.RatioOfMinorUnit));
    [TestMethod] public void IsIsoCurrencyTest() => isProperty<bool>(nameof(Currency.IsIsoCurrency));
}
