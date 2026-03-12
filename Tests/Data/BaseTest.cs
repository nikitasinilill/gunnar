namespace Abc.Tests.Data;

public abstract class BaseTest<TClass> where TClass : class, new() {
    private TClass obj;
    [TestInitialize] public void Initialize() => obj = new TClass();
    [TestMethod] public void CanCreateTest() => Assert.IsNotNull(obj);
}