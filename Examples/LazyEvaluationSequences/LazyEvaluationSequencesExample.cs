namespace DotNet10ExamplesStarter.Examples.LazyEvaluationSequences;

/*
LINQ i iteratory dają leniwą ewaluację: operatory takie jak Select czy Where nie liczą niczego w momencie wywołania,
lecz dopiero podczas iteracji (deferred execution). Dzięki temu można komponować przekształcenia, 
pracować z potencjalnie nieskończonymi sekwencjami i policzyć tylko tyle elementów, 
ile faktycznie skonsumujemy (np. przez Take).
*/

internal static class LazyEvaluationSequencesExample
{
    public static async Task Run()
    {
        var lazySequence = Enumerable.Range(1, 10).Select(x =>
        {
            Console.WriteLine($"Ewaluacja elementu: {x}");
            return x * 2;
        });

        var filtered = lazySequence.Where(x => x % 4 == 0);

        Console.WriteLine("Sekwencja zdefiniowana - nic jeszcze nie policzono.");

        foreach (var item in filtered.Take(3))
            Console.WriteLine($"Wynik: {item}");

        // Nieskończona sekwencja: leniwość pozwala pobrać tylko kilka elementów.
        var parzyste = Naturalne().Where(n => n % 2 == 0).Take(5);
        Console.WriteLine(string.Join(", ", parzyste));
    }

    private static IEnumerable<int> Naturalne()
    {
        int i = 1;
        while (true)
            yield return i++;
    }
}
