using System.Linq.Expressions;

namespace DotNet10ExamplesStarter.Examples.LambdaClosuresExpressionTrees;

internal static class LambdaClosuresExpressionTreesExample
{
    public static async Task Run()
    {
        var treeshold = 100m;
        Func<Product, bool> compiled = p => p.Price >= treeshold;
        Expression<Func<Product, bool>> tree = p => p.Price >= treeshold;

        Console.WriteLine(compiled(new("Monitor", "black", 1200m)));

        Console.WriteLine($"Drzewo: {tree.Body.NodeType}, {tree.Body}");
    }
}

public sealed record Product(string Name, string Color, decimal Price);
