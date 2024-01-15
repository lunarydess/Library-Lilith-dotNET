namespace Lilith.Event;

public abstract class AbstractEvent {
    public abstract override bool Equals(object? obj);
    public abstract override int  GetHashCode();
}