namespace DotNet10ExamplesStarter.Examples.ExtensionMethods;

internal static class ExtensionMethodsExample
{
    public static void Run()
    {
        string mojTekst = "Ala ma kota, a kot ma Alę.";
        int count = mojTekst.WordCount();
        mojTekst.Reverse(true);
        Console.WriteLine($"Wynik: {count}");
    }
}

public static class StringExtensions
{
    // public static int WordCount(this string text)
    // {
    //     int result = text.Split([' ', '.', '?', '!'], StringSplitOptions.RemoveEmptyEntries).Length;
    //     return result;
    // }
    
    extension(string text)
    {
        public int WordCount()
        {
            int result = text.Split([' ', '.', '?', '!'], StringSplitOptions.RemoveEmptyEntries).Length;
            return result;
        }

        public string Reverse(bool includeLetters)
        {
            return "";
        }
    }
}