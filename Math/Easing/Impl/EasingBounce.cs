namespace Lilith.Math.Easing.Impl;

public sealed class EasingBounce: Easing {
    public EasingBounce(in long millis, in double end): base(millis: millis, end: end) {}

    public EasingBounce(in long millis, in double end, in bool backwards): base(millis: millis,
                                                                                end: end,
                                                                                backwards: backwards) {
    }

    protected override double Equation(in Type type, in double value) {
        double x = value / GetDuration();

        const double
        n1 = 7.5625D,
        d1 = 2.75D;

        return x < 1.0D / d1 ? n1 * x * x :
               x < 2.0D / d1 ? n1 * (x -= 1.5D  / d1) * x + 0.75D :
               x < 2.5D / d1 ? n1 * (x -= 2.25D / d1) * x + 0.9375D : n1 * (x -= 2.625 / d1) * x + 0.984375D;
    }
}