using Microsoft.VisualBasic;

namespace DotNet10ExamplesStarter.Examples.Iterators;

internal static class IteratorsExample
{
    public static void Run()
    {
        //Console.WriteLine(string.Join(", ", Fibonacci(7)));

        var items = Fibonacci(5);
        foreach (int item in items)
        {
            Console.Write($"{item}, ");
        }

        Console.WriteLine();

        var root = new Node("root", new Node("left"), new Node("right", new Node("leaf")));

        Console.WriteLine(string.Join("->", root.DepthFirst()));
    }

    private static IEnumerable<int> Fibonacci(int count)
    {
        var a = 0;
        var b = 1;

        for (int i = 0; i < count; i++)
        {
            yield return a;
            (a, b) = (b, a + b);
        }
    }

    private sealed record Node(string Name, params Node[] childreen)
    {
        public IEnumerable<string> DepthFirst()
        {
            yield return Name;

            foreach (Node child in childreen)
            {
                foreach (var name in child.DepthFirst())
                {
                    yield return name;
                }
            }
        }
    }
}
