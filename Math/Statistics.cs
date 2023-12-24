namespace Library_Lilith.Math;

public class Statistics {
    #region Median
    public static float Median(params float[] data) {
        int   dataLengthHalf = data.Length / 2;
        float valueAtHalf    = data[dataLengthHalf];

        return data.Length % 2 != 0 ?
               valueAtHalf :
               (valueAtHalf + data[dataLengthHalf - 1]) * 0.5F;
    }

    public static double Median(params double[] data) {
        int    dataLengthHalf = data.Length / 2;
        double valueAtHalf    = data[dataLengthHalf];

        return data.Length % 2 != 0 ?
               valueAtHalf :
               (valueAtHalf + data[dataLengthHalf - 1]) * 0.5F;
    }
    #endregion

    #region Variance
    public static float Variance(params float[] data) =>
    data.Sum(number => (float) System.Math.Pow(x: number - data.Sum() / data.Length, y: 2.0D)) / data.Length;

    public static double Variance(params double[] data) =>
    data.Sum(number => System.Math.Pow(x: number - data.Sum() / data.Length, y: 2.0D)) / data.Length;
    #endregion

    #region StandardDeviation
    public static float StandardDeviation(params float[] data) =>
    (float) System.Math.Sqrt(d: Variance(data: data));

    public static double StandardDeviation(params double[] data) =>
    System.Math.Sqrt(d: Variance(data: data));
    #endregion
}