namespace Library_Lilith.Math;

public sealed class Arithmetics {
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