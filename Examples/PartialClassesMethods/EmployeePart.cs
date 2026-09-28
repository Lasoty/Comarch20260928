namespace DotNet10ExamplesStarter.Examples.PartialClassesMethods;

partial class Employee
{
    partial void OnNameChange(string newName)
    {
        Console.WriteLine($"Zmieniono nazwą na {newName}");
    }
}
