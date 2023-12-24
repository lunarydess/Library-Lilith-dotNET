namespace Library_Lilith.Math;

public sealed class Polynomials {
    #region Lerp
    public static float Lerp(float min, float max, float delta) =>
    Arithmetics.Clamp(value: (1.0F - delta) * min + delta * max, minimum: min, maximum: max);

    public static double Lerp(double min, double max, double delta) =>
    Arithmetics.Clamp(value: (1.0D - delta) * min + delta * max, minimum: min, maximum: max);
    #endregion
}