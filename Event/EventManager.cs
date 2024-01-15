using System.Collections.Concurrent;
using Lilith.Utility;

namespace Lilith.Event;

public sealed class EventManager {
    private static readonly Action<Exception> DefaultOnError = exception =>
    Console.Write(value: $"A \"{exception.GetType().Name}\" occured!\n"
                         + $"\u0009Message: {exception.Message}\n"
                         + $"\u0009Stack Trace: {exception.StackTrace}\n");

    private readonly Action<Exception> _onError;

    private readonly ConcurrentDictionary<object, Action<AbstractEvent>>        _cachedActions = new();
    private readonly ConcurrentDictionary<System.Type, Action<AbstractEvent>[]> _actions       = new();

    public EventManager(): this(onError: DefaultOnError) {}

    public EventManager(Action<Exception> onError) { _onError = onError; }

    public void Register<TEvent>(Action<TEvent> action) where TEvent : AbstractEvent {
        try {
            _actions.TryRemove(key: typeof(TEvent), value: out var actions);
            actions ??= Array.Empty<Action<AbstractEvent>>();
            var newAction = (AbstractEvent e) => action((TEvent) e);
            if (_actions.TryAdd(key: typeof(TEvent), value: ArrayKit.Add(array: actions, adding: newAction)))
                _cachedActions.TryAdd(action, newAction);
        } catch (Exception exception) { _onError.Invoke(exception); }
    }

    public void Unregister<TEvent>(Action<TEvent> action) where TEvent : AbstractEvent {
        try {
            _actions.TryGetValue(key: typeof(TEvent), value: out var actions);
            actions ??= Array.Empty<Action<AbstractEvent>>();
            if (actions.Length is not 0 && _cachedActions.TryGetValue(action, out var removingAction))
                _actions.TryUpdate(typeof(TEvent), ArrayKit.Remove(actions, removingAction), actions);
        } catch (Exception exception) { _onError.Invoke(exception); }
    }

    public void Call<TEvent>(in TEvent @event) where TEvent : AbstractEvent {
        if (!_actions.TryGetValue(typeof(TEvent), out var actions)) return;
        foreach (var action in actions) {
            try { action.Invoke(@event); } catch (Exception exception) { _onError.Invoke(exception); }
        }
    }
}