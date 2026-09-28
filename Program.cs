using DotNet10ExamplesStarter.Examples.AnonymousMethodsAndLambdas;
using DotNet10ExamplesStarter.Examples.AnonymousTypes;
using DotNet10ExamplesStarter.Examples.AspectOrientedProgramming;
using DotNet10ExamplesStarter.Examples.AsyncAwait;
using DotNet10ExamplesStarter.Examples.AsyncPatterns;
using DotNet10ExamplesStarter.Examples.AutoImplementedProperties;
using DotNet10ExamplesStarter.Examples.ConcurrentProgramming;
using DotNet10ExamplesStarter.Examples.CovarianceContravariance;
using DotNet10ExamplesStarter.Examples.DelegatesFuncAction;
using DotNet10ExamplesStarter.Examples.DependencyInjection;
using DotNet10ExamplesStarter.Examples.DistributedCommunication;
using DotNet10ExamplesStarter.Examples.DynamicDlr;
using DotNet10ExamplesStarter.Examples.EventBroker;
using DotNet10ExamplesStarter.Examples.ExtensionMethods;
using DotNet10ExamplesStarter.Examples.FieldKeyword;
using DotNet10ExamplesStarter.Examples.FunctionalProgramming;
using DotNet10ExamplesStarter.Examples.GenericTypes;
using DotNet10ExamplesStarter.Examples.Iterators;
using DotNet10ExamplesStarter.Examples.LambdaClosuresExpressionTrees;
using DotNet10ExamplesStarter.Examples.AsyncStreams;
using DotNet10ExamplesStarter.Examples.LazyEvaluationSequences;
using DotNet10ExamplesStarter.Examples.LinqRelationalXml;
using DotNet10ExamplesStarter.Examples.NamedOptionalArguments;
using DotNet10ExamplesStarter.Examples.ObjectAndCollectionInitializers;
using DotNet10ExamplesStarter.Examples.PartialClassesMethods;
using DotNet10ExamplesStarter.Examples.PatternMatching;
using DotNet10ExamplesStarter.Examples.PatternMatchingExtensions;
using DotNet10ExamplesStarter.Examples.Ranges;
using DotNet10ExamplesStarter.Examples.ReflectionAttributes;
using DotNet10ExamplesStarter.Examples.ServiceLocator;
using DotNet10ExamplesStarter.Examples.T4Templates;
using DotNet10ExamplesStarter.Examples.UnitTestsAaa;

namespace DotNet10ExamplesStarter;

internal static class Program
{
    private static readonly ExampleMenuItem[] Examples =
    [
        new(1, "Typy generyczne", GenericTypesExample.Run),
        new(2, "Iteratory", IteratorsExample.Run),
        new(3, "Delegaty, Func i Action", DelegatesFuncActionExample.Run),
        new(4, "Metody anonimowe i lambdy", AnonymousMethodsAndLambdasExample.Run),
        new(5, "Inicjalizatory obiektów i kolekcji", ObjectAndCollectionInitializersExample.Run),
        new(6, "Automatycznie implementowane właściwości", AutoImplementedPropertiesExample.Run),
        new(7, "Typy anonimowe", AnonymousTypesExample.Run),
        new(8, "Wyrażenia lambda, domknięcia i drzewa wyrażeń", LambdaClosuresExpressionTreesExample.Run),
        new(9, "Metody rozszerzające", ExtensionMethodsExample.Run),
        new(10, "LINQ, dane relacyjne i XML", LinqRelationalXmlExample.Run),
        new(11, "Klasy i metody częściowe", PartialClassesMethodsExample.Run),
        new(12, "Argumenty nazwane i opcjonalne", NamedOptionalArgumentsExample.Run),
        new(13, "Kowariancja i kontrawariancja", CovarianceContravarianceExample.Run),
        new(14, "dynamic i DLR", DynamicDlrExample.Run),
        new(15, "Metody asynchroniczne async/await", AsyncAwaitExample.Run),
        new(16, "Refleksja i atrybuty", ReflectionAttributesExample.Run),
        new(17, "Komunikacja rozproszona: WCF i Web API", DistributedCommunicationExample.Run),
        new(18, "Programowanie współbieżne: ThreadPool, Task, TPL i PLINQ", ConcurrentProgrammingExample.Run),
        new(19, "Modele asynchroniczne APM, EAP i TAP", AsyncPatternsExample.Run),
        new(20, "Programowanie aspektowe AOP", AspectOrientedProgrammingExample.Run),
        new(21, "Programowanie funkcyjne", FunctionalProgrammingExample.Run),
        new(22, "Service Locator", ServiceLocatorExample.Run),
        new(23, "Dependency Injection", DependencyInjectionExample.Run),
        new(24, "Event Broker", EventBrokerExample.Run),
        new(25, "Testy jednostkowe i wzorzec AAA", UnitTestsAaaExample.Run),
        new(26, "Szablony T4", T4TemplatesExample.Run),
        new(27, "Dopasowanie do wzorca (pattern matching)", PatternMatchingExample.Run),
        new(28, "Rozszerzenia dopasowania do wzorca", PatternMatchingExtensionsExample.Run),
        new(29, "Asynchroniczne strumienie", AsyncStreamsExample.Run),
        new(30, "Przedziały (operator ..)", RangesExample.Run),
        new(31, "Leniwa ewaluacja i sekwencje", LazyEvaluationSequencesExample.Run),
        new(32, "Słowo kluczowe field (C# 14)", FieldKeywordExample.Run)
    ];

    private static void Main()
    {
        while (true)
        {
            PrintMenu();

            Console.Write("Wybierz przykład (0 - wyjście): ");
            string? input = Console.ReadLine();

            if (input == "0")
            {
                return;
            }

            if (int.TryParse(input, out int selectedNumber))
            {
                ExampleMenuItem? selectedExample = Examples.FirstOrDefault(example => example.Number == selectedNumber);

                if (selectedExample is not null)
                {
                    ClearConsole();
                    Console.WriteLine($"{selectedExample.Number}. {selectedExample.Title}");
                    Console.WriteLine();

                    selectedExample.Run();

                    Console.WriteLine();
                    Console.WriteLine("Naciśnij Enter, aby wrócić do menu...");
                    Console.ReadLine();
                    continue;
                }
            }

            Console.WriteLine("Nieprawidłowy wybór. Naciśnij Enter, aby spróbować ponownie...");
            Console.ReadLine();
        }
    }

    private static void PrintMenu()
    {
        ClearConsole();
        Console.WriteLine("Przykłady C#/.NET 10");
        Console.WriteLine("====================");
        Console.WriteLine();

        foreach (ExampleMenuItem example in Examples)
        {
            Console.WriteLine($"{example.Number,2}. {example.Title}");
        }

        Console.WriteLine();
    }

    private static void ClearConsole()
    {
        if (!Console.IsOutputRedirected)
        {
            Console.Clear();
        }
    }
}

internal sealed record ExampleMenuItem(int Number, string Title, Action Run);
