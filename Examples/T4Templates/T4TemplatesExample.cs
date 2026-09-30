namespace DotNet10ExamplesStarter.Examples.T4Templates;

internal static class T4TemplatesExample
{
    public static async Task Run()
    {
        Console.WriteLine(string.Join(", ", Enum.GetValues<States>()));
    }
}
