namespace Lilith.Math;

public sealed class Polynomials {
    #region Lerp
    public static float Lerp(in float min, in float max, in float delta) =>
    Arithmetics.Clamp(value: (1.0F - delta) * min + delta * max, minimum: min, maximum: max);

    public static double Lerp(in double min, in double max, in double delta) =>
    Arithmetics.Clamp(value: (1.0D - delta) * min + delta * max, minimum: min, maximum: max);
    #endregion
}