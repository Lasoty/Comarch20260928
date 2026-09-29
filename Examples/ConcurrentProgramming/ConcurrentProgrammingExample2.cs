using System.Collections.Concurrent;

namespace DotNet10ExamplesStarter.Examples.ConcurrentProgramming;

internal static class ConcurrentProgrammingExample2
{
    public static async Task Run()
    {
        var events = GenerateEvents(20_000);
        var counts = new ConcurrentDictionary<string, int>();
        var errors = 0;

        Parallel.ForEach(events, logEvent =>
        {
            counts.AddOrUpdate(
                logEvent.Category,
                addValue: 1,
                updateValueFactory: (_, oldValue) => oldValue + 1);

            if (!logEvent.IsSuccess)
            {
                Interlocked.Increment(ref errors);
            }
        });

        Console.WriteLine("Counts:");
        foreach (var item in counts.OrderBy(x => x.Key))
        {
            Console.WriteLine($"{item.Key,-12}:{item.Value}");
        }

        Console.WriteLine();
        Console.WriteLine($"Errors:\t\t{errors}");
        Console.WriteLine($"Total counted:\t{counts.Values.Sum()}");
        Console.WriteLine($"Expected:\t{events.Count}");
    }

    private static List<LogEvent> GenerateEvents(int count)
    {
        var categories = new[] { "Orders", "Payments", "Invoices", "Users", "Reports" };
        var random = new Random(123);
        var result = new List<LogEvent>();

        for (var i = 0; i < count; i++)
        {
            result.Add(new LogEvent(
                Category: categories[random.Next(categories.Length)],
                IsSuccess: random.NextDouble() > 0.15));
        }

        return result;
    }
}

internal sealed record LogEvent(string Category, bool IsSuccess);