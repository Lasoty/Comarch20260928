namespace DotNet10ExamplesStarter.Examples.Ranges;

internal static class RangesExample
{
    public static async Task Run()
    {
        int[] numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

        Console.WriteLine(string.Join(", ", numbers[2..5])); // 3,4,5
        Console.WriteLine(string.Join(", ", numbers[..3])); // 1,2,3
        Console.WriteLine(string.Join(", ", numbers[7..])); //8,9,10
        Console.WriteLine(string.Join(", ", numbers[^3..])); //8,9,10

        Range center = 2..^2;
        Console.WriteLine(string.Join(", ", numbers[center])); //3, 4, 5, 6, 7, 8

        Console.WriteLine("Kraków"[..3]);
    }
}
