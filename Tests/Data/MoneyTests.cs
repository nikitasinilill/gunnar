using Abc.Data;
using Abc.Tests.Aids;
namespace Abc.Tests.Data;

[TestClass] public sealed class MoneyTests: BaseTests<Money> {
    [TestMethod] public void AmountTest() => isProperty<decimal>(nameof(Money.Amount));
    [TestMethod] public void CurrencyIdTest() => isProperty<Guid?>(nameof(Money.CurrencyId));
    [TestMethod] public void CurrencyTest() => isProperty<Currency>(nameof(Money.Currency));
}
