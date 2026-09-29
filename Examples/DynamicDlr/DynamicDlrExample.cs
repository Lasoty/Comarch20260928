using System.Dynamic;

namespace DotNet10ExamplesStarter.Examples.DynamicDlr;

internal static class DynamicDlrExample
{
    public static async Task Run()
    {
        dynamic invoice = new ExpandoObject();
        invoice.Net = 100m;
        invoice.Vat = 0.23m;
        invoice.Gross = new Func<decimal>(() => invoice.Net * (1 + invoice.Vat));

        Console.WriteLine($"dynamic gross={invoice.Gross():0.00}");
    }
}
