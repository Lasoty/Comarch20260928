using DotNet10ExamplesStarter.Examples.ServiceLocator;
using Microsoft.Extensions.DependencyInjection;

namespace DotNet10ExamplesStarter.Examples.DependencyInjection;

internal static class DependencyInjectionExample
{
    public static async Task Run()
    {
        ServiceProvider services = new ServiceCollection()
            .AddSingleton<IClock, SystemClock>()
            .AddTransient<ReportGenerator>()
            .BuildServiceProvider();

        var reportGenerator = services.GetRequiredService<ReportGenerator>();
        Console.WriteLine(reportGenerator.Create());
        reportGenerator.CreateJob("Job1");
        
    }
}

class ReportGenerator(IClock clock, IServiceProvider sp)
{
    public string Create() => $"Raport: {clock.Now:yyyy-MM-dd}";

    public void CreateJob(string jobName)
    {
        ThreadPool.QueueUserWorkItem(_ =>
        {
            using IServiceScope scope = sp.CreateScope();
            IClock localClock = scope.ServiceProvider.GetRequiredService<IClock>();
            Thread.Sleep(TimeSpan.FromSeconds(3));
            Console.WriteLine($"Job {jobName} finished at {localClock.Now:HH:mm:ss}");
        });
    }
}