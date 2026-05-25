using Abc.Aids;
using Abc.Data.Common;
using System.Collections;
using System.Reflection;

namespace Abc.Shared.Code;

public static class MyGridAids {
    public static bool Show(PropertyInfo property) {
        if (property is null) return false;
        if (property.Name == nameof(BaseEntity.Id)) return false;

        var type = property.PropertyType;
        if (type == typeof(string)) return true;
        if (typeof(IEnumerable).IsAssignableFrom(type)) return false;
        if (type.IsClass) return false;
        return true;
    }

    public static string Value(PropertyInfo property, object entity) {
        var value = IsSelect(property)
            ? SelectValue(property, entity)
            : property?.GetValue(entity);
        return value?.ToString() ?? string.Empty;
    }

    private static bool IsSelect(PropertyInfo property)
        => property?.GetCustomAttribute<SelectAttribute>() is not null;

    private static object SelectValue(PropertyInfo property, object entity) {
        var attribute = property?.GetCustomAttribute<SelectAttribute>();
        var id = property?.GetValue(entity) as Guid?;
        if (attribute?.EntityType is null || id is null) return null;

        var navigation = entity?.GetType().GetProperty(attribute.EntityType.Name);
        var selected = navigation?.GetValue(entity);
        var displayProperty = selected?.GetType().GetProperty(attribute.DisplayProperty);
        return displayProperty?.GetValue(selected) ?? id.Value;
    }
}
