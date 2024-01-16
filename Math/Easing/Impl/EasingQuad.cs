﻿namespace Lilith.Math.Easing.Impl;

public class EasingQuad: Easing {
    public EasingQuad(in long millis, in double end): base(millis: millis, end: end) {}

    public EasingQuad(in long millis, in double end, in bool backwards): base(millis: millis,
                                                                              end: end,
                                                                              backwards: backwards) {
    }

    protected override double Equation(in Type type, in double value) {
        double x = value / GetDuration();

        return type switch {
            Type.In  => System.Math.Pow(x: x, y: 2.0D),
            Type.Out => 1.0D - System.Math.Pow(x: 1.0D - x, y: 2.0D),
            Type.InOut => x < 0.5D ? 2.0D * System.Math.Pow(x: x, y: 2.0D) :
                          1.0D - System.Math.Pow(x: -2.0D * x + 2.0D, y: 2.0D) * 0.5D,
            _ => -1.0D
        };
    }
}