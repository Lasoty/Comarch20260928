namespace DotNet10ExamplesStarter.Examples.DistributedCommunication;

//[AttributeUsage(AttributeTargets.Interface)]
//public sealed class ServiceContractAttribute : Attribute;

//[AttributeUsage(AttributeTargets.Method)]
//public sealed class OperationContractAttribute : Attribute;

//public sealed class DistributedCommunicationExample : IExample
//{
//    public string Title => "Slajdy 98-104: komunikacja rozproszona, WCF i Web API";

//    public ValueTask RunAsync()
//    {
//        IService1 service = new Service1();
//        Console.WriteLine(service.GetData("klient"));

//        WebApplication app = CreateApi([]); // W normalnej aplikacji: await app.RunAsync();
//        return ValueTask.CompletedTask;
//    }

//    [ServiceContract]
//    private interface IService1
//    {
//        [OperationContract]
//        string GetData(string value);
//    }

//    private sealed class Service1 : IService1
//    {
//        public string GetData(string value) => $"Hello {value}";
//    }

//    public static WebApplication CreateApi(string[] args)
//    {
//        var builder = WebApplication.CreateSlimBuilder(args);
//        var app = builder.Build();
//        app.MapGet("/orders/{id:int}", (int id) => Results.Ok(new { id, status = "accepted" }));
//        return app;
//    }
//}
