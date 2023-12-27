namespace Lilith.Math.Easing.Impl;

public class EasingSine: Easing {
    public EasingSine(in long millis, in double end): base(millis: millis, end: end) {}

    public EasingSine(in long millis, in double end, in bool backwards): base(millis: millis,
                                                                              end: end,
                                                                              backwards: backwards) {
    }

    protected override double Equation(in Type type, in double value) {
        double x = value / GetDuration();

        return type switch {
            Type.In    => 1.0D - System.Math.Cos(d: x * System.Math.PI * 0.5D),
            Type.Out   => System.Math.Sin(a: x * System.Math.PI * 0.5D),
            Type.InOut => -(System.Math.Cos(d: System.Math.PI * x) - 1.0D) * 0.5D,
            _          => -1.0D
        };
    }
}