using Lilith.Event;

namespace Lilith;

public class Start {
    private static readonly EventManager EventManager = new();

    private static Action<EventA>
    HandlerA1 = aEvent => Console.WriteLine($"a1 says {aEvent.GetTest()}"),
    HandlerA2 = aEvent => Console.WriteLine($"a2 says {aEvent.GetTest()}");

    private static Action<EventB>
    HandlerB1 = bEvent => Console.WriteLine($"b1 says {bEvent.GetTest()}"),
    HandlerB2 = bEvent => Console.WriteLine($"b1 says {bEvent.GetTest()}");

    public static void Main(params string[] args) {
        EventManager.Register(HandlerA1);
        EventManager.Register(HandlerA2);
        EventManager.Register(HandlerB1);
        EventManager.Register(HandlerB2);

        const int iters = 10000;
        for (int i = 0 ; i < iters ; i++) {
            EventManager.Call(new EventA("woah"));
            EventManager.Call(new EventB("hellow"));

            if (i != iters / 2) continue;
            // EventManager.Unregister(HandlerA2); TODO: ... | finish smh.
            // EventManager.Unregister(HandlerB1); TODO: ... | finish smh.
            Console.WriteLine("hi!");
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