namespace Library_Lilith.Math.Easing.Impl;

public class EasingElastic: Easing {
    public EasingElastic(in long millis, in double end): base(millis: millis, end: end) {}

    public EasingElastic(in long millis, in double end, in bool backwards):
    base(millis: millis, end: end, backwards: backwards) {
    }

    protected override double Equation(in Type type, in double value) {
        double       x = value / GetDuration();
        const double a = 2.0943951023931953D;

        return type switch {
            Type.In => x == 0.0D || x == 1.0D ? x : -System.Math.Pow(x: 2.0D, y: 10.0D * x - 10.0D)
                                                    * System.Math.Sin(a: (x * 10.0D - 10.75D) * a),
            Type.Out => x == 0.0D || x == 1.0D ? x :
                        System.Math.Pow(x: 2.0D, y: -10.0D * x) * System.Math.Sin(a: (x * 10.0D - 0.75D) * a) + 1.0D,
            Type.InOut => x == 0.0D || x == 1.0D ? x :
                          x < 0.5D ?
                          -(System.Math.Pow(x: 2.0D, y: 20.0D * x - 10.0D)
                            * System.Math.Sin(a: (20.0D * x - 11.125D) * 1.3962634015954636D))
                          * 0.5D :
                          System.Math.Pow(x: 2.0D, y: -20.0D * x + 10.0D)
                          * System.Math.Sin(a: (20.0D * x - 11.125D) * 1.3962634015954636D)
                          * 0.5D
                          + 1.0D,
            _ => -1.0D
        };
    }
}