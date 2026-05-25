namespace Abc.Aids;

[AttributeUsage(AttributeTargets.Property)]
public sealed class RandomAttribute(int min, int max): Attribute {
    public int Min { get; } = min;
    public int Max { get; } = max;
    public int? Scale { get; }
    public string Chars { get; }

    public RandomAttribute(int min, int max, int scale): this(min, max) => Scale = scale;
    public RandomAttribute(int min, int max, string chars): this(min, max) => Chars = chars;

    public object CreateValue(Type type) {
        type = Nullable.GetUnderlyingType(type) ?? type;
        if (type == typeof(string)) return GetRandom.String((byte) Min, (byte) Max, Chars);
        if (type == typeof(DateTime)) return GetRandom.DateTime(Date(Min), Date(Max));
        if (type == typeof(double)) return Round(GetRandom.Double(Min, Max));
        if (type == typeof(decimal)) return Round(GetRandom.Decimal(Min, Max));
        if (type == typeof(int)) return GetRandom.Int32(Min, Max);
        return GetRandom.Value(type);
    }

    private static DateTime Date(int years) => DateTime.Now.AddYears(years);
    private double Round(double value) => Scale.HasValue ? Math.Round(value, Scale.Value) : value;
    private decimal Round(decimal value) => Scale.HasValue ? Math.Round(value, Scale.Value) : value;
}
