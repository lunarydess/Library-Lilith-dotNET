namespace Library_Lilith.Math.Easing.Impl;

public class EasingQuint: Easing {
    public EasingQuint(in long millis, in double end): base(millis: millis, end: end) {}

    public EasingQuint(in long millis, in double end, in bool backwards): base(millis: millis,
                                                                               end: end,
                                                                               backwards: backwards) {
    }

    protected override double Equation(in Type type, in double value) {
        double x = value / GetDuration();

        return type switch {
            Type.In  => System.Math.Pow(x: x, y: 5.0D),
            Type.Out => 1.0D - System.Math.Pow(x: 1.0D - x, y: 6.0D),
            Type.InOut => x < 0.5D ?
                          16.0D * System.Math.Pow(x: x, y: 5.0D) :
                          1.0D - System.Math.Pow(x: -2.0D * x + 2.0D, y: 5.0D) * 0.5D,
            _ => -1.0D
        };
    }
}