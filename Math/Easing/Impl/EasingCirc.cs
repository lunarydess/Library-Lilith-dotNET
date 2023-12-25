namespace Library_Lilith.Math.Easing.Impl;

public sealed class EasingCirc: Easing {
    public EasingCirc(in long millis, in double end): base(millis: millis, end: end) {}

    public EasingCirc(in long millis, in double end, in bool backwards): base(millis: millis,
                                                                              end: end,
                                                                              backwards: backwards) {
    }

    protected override double Equation(in Type type, in double value) {
        double x = value / GetDuration();

        return type switch {
            Type.In => 1.0D - System.Math.Sqrt(d: 1.0D - System.Math.Pow(x: x, y: 2.0D)),
            Type.Out => System.Math.Sqrt(d: 1.0D - System.Math.Pow(x: x - 1.0D, y: 2.0D)),
            Type.InOut => x < 0.5 ? (1.0D - System.Math.Sqrt(d: 1.0D - System.Math.Pow(x: 2.0D * x, y: 2.0D))) * 0.5D :
                          (System.Math.Sqrt(d: 1.0D - System.Math.Pow(x: -2.0D * x + 2.0D, y: 2.0D)) + 1.0D) * 0.5D,
            _ => -1.0D
        };
    }
}