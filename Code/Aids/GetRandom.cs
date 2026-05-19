
namespace Abc.Aids;

public static class GetRandom {
    private static readonly Random r = Random.Shared;
    public static int Int32(int min = int.MinValue, int max = int.MaxValue) {
        if (min == max) return min;
        if (min > max) (min, max) = (max, min);
        return r.Next(min, max);
    }
    public static long Int64(long min = long.MinValue, long max = long.MaxValue) {
        if (min == max) return min;
        if (min > max) (min, max) = (max, min);
        return r.NextInt64(min, max);
    }
    public static double Double(double min = double.MinValue, double max = double.MaxValue) {
        if (min == max) return min;
        if (min > max) (min, max) = (max, min);
        return min + r.NextDouble() * (max - min);
    }
    // iseseisvalt teha ja testida
    //    Int8, Int16, UInt8, UInt16, UInt32, UInt64, Decimal, Float
    //    string, char, bool, DateTime, TimeSpan, Guid
}
