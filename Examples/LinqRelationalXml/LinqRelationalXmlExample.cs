using System.Xml.Linq;

namespace DotNet10ExamplesStarter.Examples.LinqRelationalXml;

internal static class LinqRelationalXmlExample
{
    public static void Run()
    {
        string[] words = ["Jeden", "Dwa", "Trzy", "Cztery", "Piec"];

        var query1 = words
            .Where(w => w.Length == 5)
            .OrderBy(w => w)
            .Select(w => w.ToUpperInvariant());

        var query2 = from w in words
            where w.Length == 5
            orderby w
            select w.ToLowerInvariant();


        //XLINQ

        XElement xml = new("Person",
            new XAttribute("CanCode", true),
            new XElement("Name", "Loren David"),
            new XElement("Age", "31"));

        Console.WriteLine(string.Join(", ", query1));
        Console.WriteLine(string.Join(", ", query2));
        Console.WriteLine(xml.Element("Name")?.Value);
    }
}
