namespace DotNet10ExamplesStarter.Examples.EventBroker;

internal static class EventBrokerExample
{
    public static async Task Run()
    {
        var broker = new EventBroker();

        broker.Subscribe<OrderCreated>(OrderCreatedEmailHandler);
        broker.Subscribe<OrderCreated>(OrderCreatedStoreHandler);

        broker.Publish(new OrderCreated(123));
    }

    private static void OrderCreatedStoreHandler(OrderCreated e)
    {
        Console.WriteLine($"Magazyn dostał {e.Id}");
    }

    private static void OrderCreatedEmailHandler(OrderCreated e)
    {
        Console.WriteLine($"Mail dla zamówienia {e.Id}");
    }
}

public sealed class EventBroker
{
    private readonly Dictionary<Type, List<Delegate>> _handlers = [];

    public void Subscribe<TEvent>(Action<TEvent> handler)
    {
        var type = typeof(TEvent);
        if (!_handlers.TryGetValue(type, out var handlers))
            _handlers[type] = handlers = [];

        handlers.Add(handler);
    }

    public void Publish<TEvent>(TEvent message)
    {
        if (!_handlers.TryGetValue(typeof(TEvent), out var handlers))
            return;

        foreach (var handler in handlers.Cast<Action<TEvent>>())
        {
            handler(message);
        }
    }
}

public sealed record OrderCreated(int Id);