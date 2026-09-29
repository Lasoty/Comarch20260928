using System.ComponentModel;

namespace DotNet10ExamplesStarter.Examples.GenericTypes;

internal static class GenericTypesExample
{
    public static async Task Run()
    {
        var buffer = new MyGenericArray<string>(3);
        buffer.Add("C#");
        buffer.Add(".NET");
        buffer.Add("10");

        var left = 10;
        var right = 20;

        Swap(ref left, ref right);

        NumberChange<decimal> gross = Gross;

        IRepository<Person> repo = new InMemoryRepository<Person>();
        repo.Add(new Person("Ala", true));

        Console.WriteLine($"{buffer[1]}, swap={left}/{right}, brutto={gross(100):0.00}, repo={repo.GetAll().Count}");

    }

    private static decimal Gross(decimal amount)
    {
        return amount * 1.23m;
    }


    private static void Swap<T>(ref T first, ref T second)
    {
        (first, second) = (second, first);
    }
}

delegate T NumberChange<T>(T value) ;

class MyGenericArray<T>(int capacity) 
{
    private readonly T[] _items = new T[capacity];
    private int _count;

    public void Add(T item)
    {
        _items[_count++] = item;
    }

    public T this[int index] => _items[index];
}

interface IRepository<T> where T : class
{
    void Add(T item);
    IReadOnlyList<T> GetAll();
}

public sealed class InMemoryRepository<T>: IRepository<T> where T : class
{
    private readonly List<T> _items = [];
 
    public void Add(T item)
    {
        _items.Add(item);
    }

    public IReadOnlyList<T> GetAll()
    {
        return _items;
    }
}

public sealed record Person(string Name, bool CanCode);
