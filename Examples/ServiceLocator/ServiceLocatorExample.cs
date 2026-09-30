namespace DotNet10ExamplesStarter.Examples.ServiceLocator;

internal static class ServiceLocatorExample
{
    public static async Task Run()
    {
        var locator = new SimpleServiceLocator();
        locator.Register<IClock>(new SystemClock());

        Console.WriteLine($"{locator.Get<IClock>().Now:dd:MM:yyyy}");
    }
}

public sealed class SimpleServiceLocator
{
    private readonly Dictionary<Type, object> _services = [];

    public void Register<T>(T implementation) where T : notnull =>
        _services[typeof(T)] = implementation;

    public T Get<T>() where T: notnull =>
        (T)_services[typeof(T)];
}

public interface IClock
{
    DateTime Now { get; }
}

public sealed class SystemClock : IClock
{
    public DateTime Now => DateTime.Now;
}