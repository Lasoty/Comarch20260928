namespace DotNet10ExamplesStarter.Examples.CovarianceContravariance;

internal static class CovarianceContravarianceExample
{
    public static async Task Run()
    {
        IEnumerable<Car> cars = [new Audi()];
        IEnumerable<Vehicle> vehicles = cars; //IEnumerable<out T> jest kowariantne 

        IComparer<Vehicle> vehicleComparer = Comparer<Vehicle>.Create(
            (a, b) => string.Compare(a.Name, b.Name, StringComparison.Ordinal));

        IComparer<Car> carComparer = vehicleComparer; //IComparer<in T> jest kontrwariantne.

        Console.WriteLine(vehicles.First().Name);
        Console.WriteLine(carComparer.Compare(new Car(), new Audi()));
    }
}

abstract class Vehicle
{
    public virtual string Name => "vehicle";
}

class Car : Vehicle
{
    public override string Name => "car";
}

class Audi : Car
{
    public override string Name => "audi";
}