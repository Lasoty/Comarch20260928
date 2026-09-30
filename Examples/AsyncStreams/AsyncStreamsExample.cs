namespace DotNet10ExamplesStarter.Examples.AsyncStreams;

internal static class AsyncStreamsExample
{
    public static async Task Run()
    {
        await foreach(var element in GetAsync())
            Console.WriteLine($"Otrzymano {element}");
    }

    private static async IAsyncEnumerable<int> GetAsync()
    {
        for (int i = 0; i < 50; i++)
        {
            await Task.Delay(200);
            yield return i;
        }
    }
}
