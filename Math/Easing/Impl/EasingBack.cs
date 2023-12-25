namespace Library_Lilith.Math.Easing.Impl;

public sealed class EasingBack: Easing {
    public EasingBack(in long millis, in double end): base(millis: millis, end: end) {}
    public EasingBack(in long millis, in double end, in bool backwards): base(millis: millis, end: end, backwards: backwards) {}

    protected override double Equation(in Type type, in double value) {
        const double c2 = 2.5949095D;
        double       x  = value / GetDuration();

        return type switch {
            Type.In => 2.70158D * System.Math.Pow(x: x, y: 3) - 1.70158D * System.Math.Pow(x: x, y: 2),
            Type.Out => 1.0D
                        + 2.70158D * System.Math.Pow(x: x - 1.0D, y: 3.0D)
                        + 1.70158D * System.Math.Pow(x: x - 1.0D, y: 2.0D),
            Type.InOut => x < 0.5 ?
                          System.Math.Pow(x: 2.0D * x, y: 2.0D) * ((c2 + 1.0D) * 2.0D * x - c2) * 0.5D :
                          (System.Math.Pow(x: 2.0D * x - 2.0D, y: 2.0D) * ((c2 + 1.0D) * (x * 2.0D - 2.0D) + c2) + 2.0D)
                          * 0.5D,
            _ => -1.0D
        };
    }
}