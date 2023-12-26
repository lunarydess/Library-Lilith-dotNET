using Library_Lilith.Event;

namespace Library_Lilith;

public class Start {
    private static readonly EventManager EventManager = new();
    
    public static void Main(params string[] args) {
        EventManager.Register<EventA>(aEvent => Console.WriteLine($"Event A says hello with {aEvent.GetTest()}!"));
        EventManager.Register<EventB>(bEvent => Console.WriteLine($"Event B says hello with {bEvent.GetTest()}!"));
        for (int i = 0 ; i < 10000 ; i++) {
            EventManager.Call(new EventA("woah"));
            EventManager.Call(new EventB("hellow"));
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