namespace Library_Lilith.Math;

public sealed class Arithmetics {
    #region Clamp
    public static byte Clamp(byte value, byte minimum, byte maximum)
        => value < minimum ? minimum :
           value > maximum ? maximum : value;

    public static short Clamp(short value, short minimum, short maximum)
        => value < minimum ? minimum :
           value > maximum ? maximum : value;

    public static int Clamp(int value, int minimum, int maximum)
        => value < minimum ? minimum :
           value > maximum ? maximum : value;

    public static long Clamp(long value, long minimum, long maximum)
        => value < minimum ? minimum :
           value > maximum ? maximum : value;

    public static float Clamp(float value, float minimum, float maximum)
        => value < minimum ? minimum :
           value > maximum ? maximum : value;

    public static double Clamp(double value, double minimum, double maximum)
        => value < minimum ? minimum :
           value > maximum ? maximum : value;
    #endregion
}