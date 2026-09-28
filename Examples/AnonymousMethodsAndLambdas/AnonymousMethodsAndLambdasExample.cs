namespace DotNet10ExamplesStarter.Examples.AnonymousMethodsAndLambdas;

internal static class AnonymousMethodsAndLambdasExample
{
    public static void Run()
    {
        Func<int, int> old = delegate (int x) { return x * x; };
        Func<int, int> lambdaBlock = x => { return x * x; };
        Func<int, int> lambdaExpression = x => x * x;

        Console.WriteLine($"{old(5)}, {lambdaBlock(6)}, {lambdaExpression(7)}");
    }
}
