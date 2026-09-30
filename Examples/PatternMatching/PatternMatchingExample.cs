namespace DotNet10ExamplesStarter.Examples.PatternMatching;

internal static class PatternMatchingExample
{
    public static async Task Run()
    {
        int? maybe = 12;
        if (maybe is int number)
            Console.WriteLine($"Wartość nullable to {number}");

        Console.WriteLine();

        object?[] values = ["tekst", 123, new List<int> { 1, 2, 3, 4 }, null];

        foreach (object value in values)
        {
            Console.WriteLine(Describe(value));
        }

        Console.WriteLine();

        Console.WriteLine(WaterState(10));
        Console.WriteLine(WaterState(100));
        Console.WriteLine(WaterState(300));
        Console.WriteLine(WaterState(-1));
        Console.WriteLine();

        Console.WriteLine($"Rabat {CalculateDiscount(new Order(12, 2000m)):P0}");
        Console.WriteLine($"Rabat {CalculateDiscount(new Order(1, 300m)):P0}");
        Console.WriteLine();

        string[][] transakcje =
        [
            ["2024-01-01", "DEPOSIT", "PLN", "100"],
            ["2024-01-02", "WITHDRAW", "PLN", "40"],
            ["2024-01-03", "INTEREST", "5"],
        ];
        Console.WriteLine($"Saldo: {Saldo(transakcje)}");
    }


    // wzorce deklaracji
    public static string Describe(object? value) => value switch
    {
        null => "brak wartości",
        string s => $"łańcuch długości {s.Length}",
        int n when n > 0 => $"dodatnia liczna {n}",
        IList<int> list => $"lista z {list.Count} elementami",
        _ => "nieznany typ"
    };

    // wzorce relacyjne (<, > itp) oraz logiczne (and, or)
    private static string WaterState(int tempC) => tempC switch
    {
        (> 0) and (< 100) => "ciecz",
        <= 0 => "ciało stałe",
        _ => "gaz"
    };

    // Wzorzec pozycyjny (dekonstrukcja rekordu) i wzorzec właściwości
    private static decimal CalculateDiscount(Order order) => order switch
    {
        (> 10, > 1000m) => 0.10m,
        (> 5, > 50m) => 0.05m,
        { Cost: > 250m } => 0.02m,
        _ => 0m
    };

    private static decimal Saldo(IEnumerable<string[]> records)
    {
        decimal saldo = 0m;

        foreach (string[] record in records)
        {
            saldo += record switch
            {
                [_, "DEPOSIT", _ , var amount] => decimal.Parse(amount),
                [_, "WITHDRAW", .. , var amount] => -decimal.Parse(amount),
                [_, "INTEREST", var amount] => decimal.Parse(amount),
                _ => 0m
            };
        }

        return saldo;
    }


    private readonly record struct Order(int Items, decimal Cost);
}


