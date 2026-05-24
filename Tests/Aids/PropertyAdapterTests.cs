using Abc.Aids;

namespace Abc.Tests.Aids;

[TestClass] public class PropertyAdapterTests: BaseTests<PropertyAdapter> {
    private class TestClass {
        public int? IntProp { get; set; }
        public string StringProp { get; set; }
    }

    private TestClass item;
    private string propName = nameof(TestClass.IntProp);
    private PropertyAdapter stringAdapter;

    [TestInitialize] public override void Initialize() {
        base.Initialize();
        item = new TestClass();
        obj = new PropertyAdapter(item, propName);
        stringAdapter = new PropertyAdapter(item, nameof(TestClass.StringProp));
    }

    [TestMethod] public void ItemTypeTest() => areEqual(typeof(TestClass), obj.ItemType);
    [TestMethod] public void ItemTest() => areSame(item, obj.Item);
    [TestMethod] public void PropInfoTest() => areEqual(propName, obj.PropInfo.Name);
    [TestMethod] public void PropTypeTest() {
        areEqual(typeof(int?), obj.PropType);
        areEqual(typeof(string), stringAdapter.PropType);
    }
    [TestMethod] public void UnderlyingTypeTest() {
        areEqual(typeof(int), obj.UnderlyingType);
        areEqual(typeof(string), stringAdapter.UnderlyingType);
    }
    [TestMethod] public void PropValueTest() {
        areEqual(null, obj.PropValue);
        areEqual(null, stringAdapter.PropValue);
    }
    [TestMethod] public void SetValueTest() {
        var i = GetRandom.Int32();
        var s = GetRandom.String();
        obj.SetValue(i);
        stringAdapter.SetValue(s);
        areEqual(i, item.IntProp);
        areEqual(s, item.StringProp);
        areEqual(obj.PropValue, item.IntProp);
        areEqual(stringAdapter.PropValue, item.StringProp);
    }
}
