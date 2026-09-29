namespace DotNet10ExamplesStarter.Examples.DelegatesFuncAction;

internal static class DelegatesFuncActionExample
{
    public static async Task Run()
    {
        PriceRule rule = AddVat;
        rule += AddServiceFee;


        
        Func<int, int, int> add = Add;
        Action<string> log = Console.WriteLine;

        log($"Multicast zwraca wynik ostatniej metody: {rule(100):0.00}");
        log($"Func: 2 + 3 = {add(2, 3)}");

    }

    private static int Add(int a, int b)
    {
        return a + b;
    }


    static decimal AddVat(decimal net)
    {
        return net * 1.23m;
    }

    static decimal AddServiceFee(decimal net)
    {
        return net + 10m;
    }
}

delegate decimal PriceRule(decimal net);