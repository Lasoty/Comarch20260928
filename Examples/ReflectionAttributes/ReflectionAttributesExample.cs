using System.Reflection;

namespace DotNet10ExamplesStarter.Examples.ReflectionAttributes;

internal static class ReflectionAttributesExample
{
    public static async Task Run()
    {
        Type type = typeof(Plugin);
        var attribute = type.GetCustomAttribute<DemoAttribute>();
        var instance = Activator.CreateInstance(type);
        var message = type.GetMethod(nameof(Plugin.Execute))?.Invoke(instance, ["kurs"]);

        Console.WriteLine($"{attribute?.Description}: {message}");
    }
}

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public sealed class DemoAttribute(string description) : Attribute
{
    public string Description { get; } = description;
}

[Demo("Przykładowy plugin")]
sealed class Plugin
{
    public string Execute(string input) => input.ToUpperInvariant();
}