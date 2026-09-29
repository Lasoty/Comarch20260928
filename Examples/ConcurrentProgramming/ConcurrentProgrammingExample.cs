using System.Collections.Concurrent;
using System.Diagnostics;

namespace DotNet10ExamplesStarter.Examples.ConcurrentProgramming;

internal static class ConcurrentProgrammingExample
{
    private const int Iterations = 500_000;
    public static async Task Run()
    {
        Console.WriteLine($"Expected result: {Iterations}");
        Console.WriteLine();

        RunBrokenCounter();
        RunWithLock();
        RunWithInterlocked();
        await RunWithSemaphoreSlim();
        RunWithConcurrentDictionary();
    }

    private static void RunBrokenCounter()
    {
        var counter = 0;
        var stopwatch = Stopwatch.StartNew();

        Parallel.For(0, Iterations, _ => { counter++; });

        stopwatch.Stop();
        Console.WriteLine($"Broken counter:\t\t\t\t{counter} ({stopwatch.ElapsedMilliseconds} ms)");
    }

    private static void RunWithLock()
    {
        var counter = 0;
        var sync = new object();
        var stopwatch = Stopwatch.StartNew();

        Parallel.For(0, Iterations, _ =>
        {
            lock (sync)
            {
                counter++;
            }
        });

        stopwatch.Stop();
        Console.WriteLine($"Counter with Lock:\t\t\t{counter} ({stopwatch.ElapsedMilliseconds} ms)");
    }

    private static void RunWithInterlocked()
    {
        var counter = 0;
        var stopwatch = Stopwatch.StartNew();

        Parallel.For(0, Iterations, _ =>
        {
            Interlocked.Increment(ref counter);
        });

        stopwatch.Stop();
        Console.WriteLine($"Counter with Interlocked:\t\t{counter} ({stopwatch.ElapsedMilliseconds} ms)");
    }

    private static async Task RunWithSemaphoreSlim()
    {
        var counter = 0;
        using var semaphore = new SemaphoreSlim(1, 1);
        var stopwatch = Stopwatch.StartNew();

        var tasks = Enumerable.Range(0, Iterations).Select(async _ =>
            {
                await semaphore.WaitAsync();
                try
                {
                    counter++;
                }
                finally
                {
                    semaphore.Release();
                }
            }
        );

        await Task.WhenAll(tasks);
        stopwatch.Stop();
        Console.WriteLine($"Counter with SemaphoreSlim:\t\t{counter} ({stopwatch.ElapsedMilliseconds} ms)");
    }

    private static void RunWithConcurrentDictionary()
    {
        var dictionary = new ConcurrentDictionary<string, int>();
        var stopwatch = Stopwatch.StartNew();

        Parallel.For(0, Iterations, _ =>
        {
            dictionary.AddOrUpdate("counter", 1, (_, oldV) => oldV + 1);
        });


        stopwatch.Stop();
        Console.WriteLine($"Counter in dictionary:\t\t\t{dictionary["counter"]} ({stopwatch.ElapsedMilliseconds} ms)");
    }
}