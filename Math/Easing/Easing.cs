namespace Library_Lilith.Math.Easing;

public abstract class Easing {
    public enum Type { In, Out, InOut }
    private readonly double  _end;
    private readonly MsTimer _timer = new();
    private          bool    _backwards;
    private          long    _duration;

    public Easing(
        in long   millis,
        in double end
    ) {
        _duration  = millis;
        _end       = end;
        _backwards = false;
    }

    public Easing(
        in long   millis,
        in double end,
        in bool   backwards
    ) {
        _duration  = millis;
        _end       = end;
        _backwards = backwards;
    }

    protected abstract double Equation(in Type type, in double value);

    public void SetBackwards(in bool backwards) {
        if (_backwards == backwards) return;
        _timer.SetMillis(millis: DateTimeOffset.Now.ToUnixTimeMilliseconds()
                                 - (_duration - System.Math.Min(val1: _duration, val2: _timer.GetElapsedTime())));
        _backwards = backwards;
    }

    public MsTimer GetTimer() => _timer;

    public long   GetDuration()                 => _duration;
    public void   SetDuration(in long duration) => _duration = duration;
    public double GetEnd()                      => _end;

    public bool IsBackwards() => _backwards;
    public bool IsDone()      => GetTimer().HasElapsedInMillis(millis: _duration);

    public double Output(in Type type) => !_backwards ?
                                          IsDone() ? _end :
                                          Equation(type: type, value: _timer.GetElapsedTime()) * _end :
                                          IsDone() ? 0 :
                                          (1 - Equation(type: type, value: _timer.GetElapsedTime())) * _end;
}