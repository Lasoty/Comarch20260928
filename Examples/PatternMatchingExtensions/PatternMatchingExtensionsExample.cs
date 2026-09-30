namespace DotNet10ExamplesStarter.Examples.PatternMatchingExtensions;

internal static class PatternMatchingExtensionsExample
{
    public static async Task Run()
    {

        foreach (object? obiekt in new object?[] { "tekst", 42, null })
            Console.WriteLine(Execute(obiekt));

        foreach (int liczba in new[] { -5, 5, 42 })
            Console.WriteLine(DescribeScope(liczba));

        foreach (int? wynik in new int?[] { -1, 5, 10, null })
            Console.WriteLine(DescribeResult(wynik));

    }

    // Klasyczny switch ze wzorcem typu i klauzulą when.
    private static string Execute(object? obiekt)
    {
        switch (obiekt)
        {
            case string tekst:
                return $"Przetworzono łańcuch: {tekst}";
            case int liczba when liczba > 0:
                return $"Przetworzono dodatnią liczbę: {liczba}";
            case null:
                return "Przetworzono wartość null";
            default:
                return "Nie udało się przetworzyć";
        }
    }

    // switch-expression ze wzorcami relacyjnymi i logicznymi.
    private static string DescribeScope(int liczba) => liczba switch
    {
        < 0 => "Liczba ujemna",
        >= 0 and <= 10 => "Liczba z przedziału 0-10",
        > 10 => "Liczba większa niż 10",
    };

    // Wzorzec not oraz dopasowanie do null.
    private static string DescribeResult(int? wynik) => wynik switch
    {
        < 0 => "Wynik jest mniejszy od zera",
        >= 0 and not 10 => "Wynik jest >= 0, ale różny od 10",
        10 => "Wynik jest równy 10",
        null => "Wynik jest null",
    };
}
