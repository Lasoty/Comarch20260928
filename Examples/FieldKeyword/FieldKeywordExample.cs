namespace DotNet10ExamplesStarter.Examples.FieldKeyword;

/*
Słowo kluczowe field (C# 14) pozwala pisać logikę w getterze/setterze bez ręcznego deklarowania 
prywatnego pola (backing field). Kompilator tworzy ukryte pole automatycznie, 
a field daje do niego dostęp wewnątrz akcesorów. Dzięki temu właściwości z walidacją, 
normalizacją czy wartością domyślną nie wymagają już osobnego pola prywatnego, 
a pełną właściwość dopisujemy dopiero tam, gdzie faktycznie jest potrzebna logika — bez zmiany publicznego API
*/

internal static class FieldKeywordExample
{
    public static async Task Run()
    {
        var user = new User { Name = "  Ada  " };
        Console.WriteLine($"Name='{user.Name}', Country='{user.Country}'");

        user.Country = "pl";
        Console.WriteLine($"Country po zmianie='{user.Country}'");

        var empty = new User();
        Console.WriteLine($"Domyślne Name='{empty.Name}'");

        var temperature = new Temperature { Celsius = 21.5 };
        Console.WriteLine($"Celsius={temperature.Celsius}");

        try
        {
            temperature.Celsius = -300;
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Odrzucono wartość parametru: {ex.ParamName}");
        }

    }

    private sealed class User
    {
        // Normalizacja w setterze - bez ręcznie deklarowanego pola.
        public string Name
        {
            get => field ?? "n/d";
            set => field = value?.Trim();
        }

        // Inicjalizator właściwości działa razem z field.
        public string Country
        {
            get => field;
            set => field = value.ToUpperInvariant();
        } = "PL";
    }

    private sealed class Temperature
    {
        // Walidacja w setterze; backing field tworzy kompilator.
        public double Celsius
        {
            get => field;
            set => field = value < -273.15
                ? throw new ArgumentOutOfRangeException(nameof(value), "Poniżej zera absolutnego.")
                : value;
        }
    }
}
