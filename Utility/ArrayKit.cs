namespace Lilith.Utility;

public sealed class ArrayKit {
    #region SubAndMerge
    public static T[] Sub<T>(in T[] array, in int start, in int end) {
        int min = System.Math.Min(val1: start, val2: end),
            max = System.Math.Max(val1: start, val2: end);

        if (min == array.Length || array.Length <= 1) return Array.Empty<T>();
        var objs = new T[max - min + 1];

        Array.Copy(sourceArray: array,
                   sourceIndex: min,
                   destinationArray: objs,
                   destinationIndex: 0,
                   length: objs.Length);

        return objs;
    }

    public static T[] Merge<T>(in T[] array1, in T[] array2) {
        var objs = new T[array1.Length + array2.Length];

        Array.Copy(sourceArray: array1,
                   sourceIndex: 0,
                   destinationArray: objs,
                   destinationIndex: 0,
                   length: array1.Length);
        Array.Copy(sourceArray: array2,
                   sourceIndex: 0,
                   destinationArray: objs,
                   destinationIndex: array1.Length,
                   length: array2.Length);

        return objs;
    }
    #endregion

    #region Add
    public static T[] Add<T>(in T[] array, in T adding) => Add(array: in array, adding: in adding, index: array.Length - 1);

    public static T[] Add<T>(in T[] array, in T adding, in int index) {
        var result = new T[array.Length + 1];

        if (result.Length == 0 || index < -1 || index > array.Length - 1) return Array.Empty<T>();

        Array.Copy(sourceArray: array,
                   sourceIndex: 0,
                   destinationArray: result,
                   destinationIndex: 0,
                   length: index + 1);

        int removeIndex = index < 0 ? 0 : index;
        Array.Copy(sourceArray: array,
                   sourceIndex: removeIndex,
                   destinationArray: result,
                   destinationIndex: removeIndex + 1,
                   length: array.Length          - removeIndex);

        result[index + 1] = adding;

        return result;
    }
    #endregion

    #region Indices
    public static int IndexOf<T>(in T[] array, in T searching) {
        for (int i = 0 ; i < array.Length ; i++)
            if (array[i]?.Equals(obj: searching)??false)
                return i;

        return -1;
    }

    public static int[] IndicesOf<T>(T[] array, params T[] searching) {
        return searching.Aggregate(seed: new int[searching.Length],
                                   (current, variable) =>
                                   Add(array: current, adding: IndexOf(array: array, searching: variable)));
    }
    #endregion

    #region Remove
    public static T[] Remove<T>(in T[] array, in int index) {
        var result = new T[array.Length - 1];

        if (result.Length == 0 || index < 0 || index > array.Length - 1) return Array.Empty<T>();

        Array.Copy(sourceArray: array,
                   sourceIndex: 0,
                   destinationArray: result,
                   destinationIndex: 0,
                   length: index);
        Array.Copy(sourceArray: array,
                   sourceIndex: index + 1,
                   destinationArray: result,
                   destinationIndex: index,
                   length: array.Length - (index + 1));

        return result;
    }

    public static T[] Remove<T>(in T[] array, in T removing) =>
    Remove(array: array, index: IndexOf(array: array, searching: removing));
    #endregion

    #region ToString
    public static string ToString<T>(params T[] values) {
        return values.Length is 0 ? "[]" : ToString(arg => arg?.ToString()??"", values: values);
    }

    // @formatter:off
    public static string ToString<T>(
        in Func<T, string> stringFunc,
        params T[] values
    ) {
        if (values.Length is 0) return "[]";

        string returnVal = $"[{values[0]}";
        if (values.Length is not 1)
        for (int i = 1; i < values.Length; i++)
        returnVal += $", {stringFunc.Invoke(arg:values[i])}";
        
        return returnVal += "]";
    }
    #endregion
}