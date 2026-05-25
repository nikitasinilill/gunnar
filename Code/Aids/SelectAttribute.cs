namespace Abc.Aids;

[AttributeUsage(AttributeTargets.Property)]
public sealed class SelectAttribute(Type entityType, string displayProperty = null) : Attribute {
    public Type EntityType { get; } = entityType;
    public string DisplayProperty { get; } = string.IsNullOrWhiteSpace(displayProperty)
        ? "Name"
        : displayProperty;
}
