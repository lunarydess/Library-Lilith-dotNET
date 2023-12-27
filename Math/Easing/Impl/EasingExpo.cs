namespace Lilith.Math.Easing.Impl;

public class EasingExpo: Easing {
    public EasingExpo(in long millis, in double end): base(millis: millis, end: end) {}

    public EasingExpo(in long millis, in double end, in bool backwards): base(millis: millis,
                                                                              end: end,
                                                                              backwards: backwards) {
    }

    protected override double Equation(in Type type, in double value) {
        double x = value / GetDuration();

        return type switch {
            Type.In  => x == 0.0D ? 0.0D : System.Math.Pow(x: 2.0D, y: 10.0D         * x - 10.0D),
            Type.Out => x == 1.0D ? 1.0D : 1.0D - System.Math.Pow(x: 2.0D, y: -10.0D * x),
            Type.InOut => x == 0.0D || x == 1.0D ? x :
                          x < 0.5D ?
                          System.Math.Pow(x: 2.0D, y: 20.0D * x - 10.0D)           * 0.5D :
                          (2.0D - System.Math.Pow(x: 2.0D, y: -20.0D * x + 10.0D)) * 0.5D,
            _ => -1.0D
        };
    }
}