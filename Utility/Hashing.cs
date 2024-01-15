namespace Lilith.Utility;

public class Hashing {
    public static int Hash(params object[] objects) {
        unchecked { return objects.Aggregate(seed: 17, (current, obj) => current * 23 + obj.GetHashCode()); }
    }
}