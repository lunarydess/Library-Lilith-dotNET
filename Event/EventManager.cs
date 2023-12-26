using System.Collections.Concurrent;
using Lilith.Utility;

namespace Library_Lilith.Event;

public sealed class EventManager {
    private delegate T EventAction<out T>() where T : IEvent;

    private readonly ConcurrentDictionary<System.Type, EventAction<IEvent>[]> _events = new();

    public void Register<TEvent>(Action<TEvent> action) where TEvent : IEvent {
        _events.TryRemove(key: typeof(TEvent), value: out var actions);
        actions ??= Array.Empty<EventAction<IEvent>>();
        _events.TryAdd(key: typeof(TEvent), value: ArrayKit.Add<EventAction<TEvent>>(array: actions, adding: action));
    }

    public void Call<TEvent>(in TEvent aEvent) where TEvent : IEvent {
        if (!_events.TryGetValue(typeof(TEvent), out var actions)) return;
        foreach (var action in actions) action.Invoke(aEvent);
    }
}