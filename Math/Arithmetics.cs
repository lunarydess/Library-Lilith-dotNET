namespace Library_Lilith.Math;

public sealed class Arithmetics {
    #region Average
    public static int AverageInt(params int[]    numbers) => numbers.Sum()       / numbers.Length;
    public static int AverageInt(params float[]  numbers) => (int) numbers.Sum() / numbers.Length;
    public static int AverageInt(params double[] numbers) => (int) numbers.Sum() / numbers.Length;

    public static float AverageFloat(params int[]    numbers) => numbers.Sum()         / (float) numbers.Length;
    public static float AverageFloat(params float[]  numbers) => numbers.Sum()         / numbers.Length;
    public static float AverageFloat(params double[] numbers) => (float) numbers.Sum() / numbers.Length;

    public static double AverageDouble(params int[]    numbers) => numbers.Sum()          / (double) numbers.Length;
    public static double AverageDouble(params float[]  numbers) => (double) numbers.Sum() / numbers.Length;
    public static double AverageDouble(params double[] numbers) => numbers.Sum()          / numbers.Length;
    #endregion

    #region Clamp
    public static byte Clamp(in byte value, in byte minimum, in byte maximum)
        => value < minimum ? minimum :
           value > maximum ? maximum : value;

    public static short Clamp(in short value, in short minimum, in short maximum)
        => value < minimum ? minimum :
           value > maximum ? maximum : value;

    public static int Clamp(in int value, in int minimum, in int maximum)
        => value < minimum ? minimum :
           value > maximum ? maximum : value;

    public static long Clamp(in long value, in long minimum, in long maximum)
        => value < minimum ? minimum :
           value > maximum ? maximum : value;

    public static float Clamp(in float value, in float minimum, in float maximum)
        => value < minimum ? minimum :
           value > maximum ? maximum : value;

    public static double Clamp(in double value, in double minimum, in double maximum)
        => value < minimum ? minimum :
           value > maximum ? maximum : value;
    #endregion
}