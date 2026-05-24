using Abc.Aids;

namespace Abc.Tests.Aids;

[TestClass] public class TypeExtensionTests: TestAids {
    [TestInitialize] public void Initialize() => type = typeof(TypeExtension);

    [TestMethod] public void IsBoolTest() {
        Assert.IsTrue(TypeExtension.IsBool(typeof(bool)));
        Assert.IsTrue(typeof(bool).IsBool());
        Assert.IsTrue(typeof(bool?).IsBool());
        Assert.IsFalse(TypeExtension.IsBool(typeof(string)));
    }
    [TestMethod] public void IsDateTest() {
        Assert.IsTrue(typeof(DateTime).IsDate());
        Assert.IsTrue(typeof(DateTime?).IsDate());
        Assert.IsTrue(typeof(DateOnly).IsDate());
        Assert.IsTrue(typeof(DateOnly?).IsDate());
        Assert.IsFalse(typeof(string).IsDate());
    }
    [TestMethod] public void IsStringTest() {
        Assert.IsTrue(typeof(string).IsString());
        Assert.IsFalse(typeof(int).IsString());
    }

    [DataRow(typeof(sbyte))]
    [DataRow(typeof(sbyte?))]
    [DataRow(typeof(byte))]
    [DataRow(typeof(byte?))]
    [DataRow(typeof(short))]
    [DataRow(typeof(short?))]
    [DataRow(typeof(ushort))]
    [DataRow(typeof(ushort?))]
    [DataRow(typeof(int))]
    [DataRow(typeof(int?))]
    [DataRow(typeof(uint))]
    [DataRow(typeof(uint?))]
    [DataRow(typeof(long))]
    [DataRow(typeof(long?))]
    [DataRow(typeof(ulong))]
    [DataRow(typeof(ulong?))]
    [DataRow(typeof(float))]
    [DataRow(typeof(float?))]
    [DataRow(typeof(double))]
    [DataRow(typeof(double?))]
    [DataRow(typeof(decimal))]
    [DataRow(typeof(decimal?))]
    [TestMethod] public void IsNumericTest(Type t) {
        Assert.IsTrue(TypeExtension.IsNumeric(t));
        Assert.IsTrue(t.IsNumeric());
    }
}
