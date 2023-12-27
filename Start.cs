﻿using Lilith.Event;

namespace Lilith;

public class Start {
    private static readonly EventManager EventManager = new();

    private static Action<EventA>
    _handlerA1 = aEvent => Console.WriteLine($"a1 says {aEvent.GetTest()}"),
    _handlerA2 = aEvent => Console.WriteLine($"a2 says {aEvent.GetTest()}");

    private static Action<EventB>
    _handlerB1 = bEvent => Console.WriteLine($"b1 says {bEvent.GetTest()}"),
    _handlerB2 = bEvent => Console.WriteLine($"b2 says {bEvent.GetTest()}");

    public static void Main(params string[] args) {
        EventManager.Register(_handlerA1);
        EventManager.Register(_handlerA2);
        EventManager.Register(_handlerB1);
        EventManager.Register(_handlerB2);

        const int iters = 100;
        for (int i = 0 ; i < iters ; i++) {
            EventManager.Call(new EventA("woah"));
            EventManager.Call(new EventB("hellow"));

            if (i == iters / 2) {
                EventManager.Unregister(_handlerA2);
                EventManager.Unregister(_handlerB1);
                Console.WriteLine("hi!");
            }
        }
    }

    public sealed class EventA: IEvent {
        private readonly string _test;
        public EventA(in string test) { _test = test; }
        public string GetTest() => _test;

        public override string ToString() => $"EventA{GetTest()}";
    }

    public sealed class EventB: IEvent {
        private readonly string _test;
        public EventB(in string test) { _test = test; }
        public          string GetTest()  => _test;
        public override string ToString() => $"EventB{GetTest()}";
    }
}