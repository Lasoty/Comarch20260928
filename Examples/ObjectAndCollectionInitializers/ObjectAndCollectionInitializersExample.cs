using System.Collections;

namespace DotNet10ExamplesStarter.Examples.ObjectAndCollectionInitializers;

internal static class ObjectAndCollectionInitializersExample
{
    public static async Task Run()
    {
        Cat cat = new() { Age = 10, Name = "Fluffy" };
        List<Cat> cats = [cat, new() { Name = "Kicia", Age = 5 }];
        Dictionary<int, string> names = new() { [7] = "seven", [9] = "nine" };
        int[,] matrix = { { 1, 2, 3 }, { 1, 2, 3 } };
        var matrix2 = new MatrixRows() { { 1, 2, 3 }, { 1, 2, 3 } };

        Console.WriteLine($"{cats.Count} koty, key 7 = {names[7]}, suma = {matrix2.Sum()}");
    }
}

public sealed record Cat
{
    public Cat()
    {
        
    }

    public string Name { get; set; } = "";
    public int Age { get; set; } = 1;
}

class MatrixRows : IEnumerable<int[]>
{
    private readonly List<int[]> rows = [];
    public void Add(params int[] values) => rows.Add(values);
    public int Sum() => rows.SelectMany(row => row).Sum();

    public IEnumerator<int[]> GetEnumerator()
    {
        return rows.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}