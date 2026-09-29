namespace DotNet10ExamplesStarter.Examples.AsyncAwait;

internal static class AsyncAwaitExample
{
    public static async Task Run()
    {
        var result = await CalculateAsync(2, 3, CancellationToken.None);
        Console.WriteLine($"2 + 3 = {result}");
    }

    private static async Task<int> CalculateAsync(int first, int second, CancellationToken cancellationToken)
    {
        await Task.Delay(200, cancellationToken);
        return first + second;
    }
}
