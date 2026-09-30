namespace DotNet10ExamplesStarter.Examples.FunctionalProgramming;

internal static class FunctionalProgrammingExample
{
    public static async Task Run()
    {
        Func<int, int> square = x => x * x;
        Func<int, bool> isEven = x => x % 2 == 0;

        var result = Enumerable.Range(1, 6)
            .Where(isEven)
            .Select(square)
            .Aggregate(0, (sum, next) => sum + next);

        Console.WriteLine(result);
    }
}
