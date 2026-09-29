namespace DotNet10ExamplesStarter.Examples.AspectOrientedProgramming;

internal static class AspectOrientedProgrammingExample
{
    public static async Task Run()
    {
        IOrderService service = new LoggingOrderService(new OrderService());
        Console.WriteLine(service.PlaceOrder("ABC"));
    }
}

interface IOrderService
{
    string PlaceOrder(string sku);
}

sealed class OrderService : IOrderService
{
    public string PlaceOrder(string sku)
    {
        return $"Zamówiono {sku}";
    }
}

// Docelowo można użyć CastleProxy.
sealed class LoggingOrderService(IOrderService inner) : IOrderService
{
    public string PlaceOrder(string sku)
    {
        Console.WriteLine($"[LOG] start {sku}");
        var result = inner.PlaceOrder(sku);
        Console.WriteLine($"[LOG] end {sku}");
        return result;
    }
}