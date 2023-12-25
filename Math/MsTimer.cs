namespace Library_Lilith.Math;

public class MsTimer {
    private double _millis = DateTimeOffset.Now.ToUnixTimeMilliseconds();

    public double GetMillis()                 => _millis;
    public void   SetMillis(in double millis) => _millis = millis;

    public void UpdateMillis() =>
    SetMillis(millis: DateTimeOffset.Now.ToUnixTimeMilliseconds());

    public double GetElapsedTime() =>
    DateTimeOffset.Now.ToUnixTimeMilliseconds() - GetMillis();

    public bool HasElapsedInMillis(in  double millis)  => GetElapsedTime() >= millis;
    public bool HasElapsedInSeconds(in long   seconds) => HasElapsedInMillis(millis: seconds * 1000L);
}