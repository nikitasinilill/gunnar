using Abc.Aids;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Abc.Shared.Components;

public interface IEditorAdapter {
    string DisplayName { get; }
    PropertyInfo PropInfo { get; }
    Type Editor { get; }
    Type Validator { get; }
    IDictionary<string, object> EditorParams { get; }
    IDictionary<string, object> ValidationParams { get; }
}

public sealed partial class EditorAdapter(ComponentBase component, object item, string propName): IEditorAdapter {
    public PropertyInfo PropInfo => adapter?.PropInfo;
    public string DisplayName => hasName ? toName : string.Empty;
    public Type Editor => isSelect ? typeof(MyEntitiesSelect)
        : underlyingType.IsString() ? typeof(InputText)
        : underlyingType.IsBool() ? typeof(InputCheckbox)
        : underlyingType.IsDate() ? generic(typeof(InputDate<>), propType)
        : underlyingType.IsNumeric() ? generic(typeof(InputNumber<>), propType)
        : null;
    public Type Validator => generic(typeof(ValidationMessage<>), propType);
    public IDictionary<string, object> EditorParams => new Dictionary<string, object> {
        ["id"] = propName,
        ["name"] = inputName,
        ["class"] = "form-control",
        ["Value"] = adapter.PropValue,
        ["ValueChanged"] = valueChanged(),
        ["ValueExpression"] = valueExpression()
    }.WithSelectParams(select);
    public IDictionary<string, object> ValidationParams => new Dictionary<string, object> {
        ["For"] = valueExpression(),
        ["class"] = "text-danger"
    };

    private readonly IPropertyAdapter adapter = new PropertyAdapter(item, propName);
    private const BindingFlags flags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic;
    private bool hasName => !string.IsNullOrWhiteSpace(propName);
    private string inputName => adapter?.ItemType is null ? propName : $"{adapter.ItemType.Name}.{propName}";
    private Type propType => adapter?.PropType ?? typeof(object);
    private SelectAttribute select => adapter?.PropInfo?.GetCustomAttribute<SelectAttribute>();
    private string toName => nameRegex().Replace(propName, " $1");
    private Type underlyingType => adapter?.UnderlyingType ?? typeof(object);
    private bool isSelect => select is not null && propType == typeof(Guid?);

    private EventCallback<TValue> changed<TValue>() => EventCallback.Factory.Create<TValue>(component, value => {
        adapter.SetValue(value);
        return Task.CompletedTask;
    });
    private Expression<Func<TValue>> expression<TValue>() {
        var i = Expression.Constant(item);
        var p = Expression.Property(Expression.Convert(i, adapter.ItemType), adapter.PropInfo);
        return Expression.Lambda<Func<TValue>>(p);
    }
    private object makeGeneric(MethodInfo methodInfo) => methodInfo.MakeGenericMethod(propType).Invoke(this, null);
    private static MethodInfo method(string name) => typeof(EditorAdapter).GetMethod(name, flags);
    private object valueChanged() => makeGeneric(method(nameof(changed)));
    private object valueExpression() => makeGeneric(method(nameof(expression)));
    private static Type generic(Type editor, Type t) => editor.MakeGenericType(t);

    [GeneratedRegex("(\\B[A-Z])")] private static partial Regex nameRegex();
}

file static class EditorParamsExtensions {
    public static IDictionary<string, object> WithSelectParams(
        this IDictionary<string, object> parameters,
        SelectAttribute attribute) {
        if (attribute is null) return parameters;

        parameters[nameof(SelectAttribute.EntityType)] = attribute.EntityType;
        parameters[nameof(SelectAttribute.DisplayProperty)] = attribute.DisplayProperty;
        return parameters;
    }
}
