using System.Collections.Concurrent;
using Lilith.Utility;

namespace Library_Lilith.Event;

public sealed class EventManager {
    private readonly ConcurrentDictionary<System.Type, Action<IEvent>[]> _events = new();

    public void Register<TEvent>(Action<TEvent> action) where TEvent : IEvent {
        _events.TryRemove(key: typeof(TEvent), value: out var actions);
        actions ??= Array.Empty<Action<IEvent>>();
        _events.TryAdd(key: typeof(TEvent), value: ArrayKit.Add<>(array: actions, adding: action));
    }

    public void Call<TEvent>(in TEvent aEvent) where TEvent : IEvent {
        if (!_events.TryGetValue(typeof(TEvent), out var actions)) return;
        foreach (var action in actions) action.Invoke(aEvent);
    }
}