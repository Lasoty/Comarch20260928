namespace DotNet10ExamplesStarter.Examples.PartialClassesMethods;

internal static class PartialClassesMethodsExample
{
    public static async Task Run()
    {
        Employee employee = new("Jan");
        employee.Rename("Jan Kowalski");
        Console.WriteLine(employee.Description);
    }
}

partial class Employee(string name)
{
    public string Name { get; private set; } = name;
    public string Description => $"Pracownik {Name}";

    public void Rename(string value)
    {
        Name = value;
        OnNameChange(value);
    }

    partial void OnNameChange(string newName);
}
