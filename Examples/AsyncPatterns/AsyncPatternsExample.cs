namespace DotNet10ExamplesStarter.Examples.AsyncPatterns;

internal static class AsyncPatternsExample
{
    public static async Task Run()
    {
        var apm = Task<int>.Factory.FromAsync(BeginAdd, EndAdd, 2, null);
        using var downloader = new FakeDownloader();
        var eapTask = downloader.DownloadAsync("plik.txt");
        var tap = AddTapAsync(3, 4);

        downloader.Start("plik.txt");
        Console.WriteLine($"APM={await apm}, EAP={await eapTask}, TAP={await tap}");
    }

    private static IAsyncResult BeginAdd(int value, AsyncCallback? callback, object? state)
    {
        var task = Task.Run(() => value + 1);
        if (callback is not null)
            task.ContinueWith(t => callback(t), TaskScheduler.Default);
        return task;
    }

    private static int EndAdd(IAsyncResult asyncResult) =>
        ((Task<int>)asyncResult).GetAwaiter().GetResult();

    private static async Task<int> AddTapAsync(int a, int b)
    {
        await Task.Delay(100);
        return a + b;
    }

    private sealed class FakeDownloader : IDisposable
    {
        public event EventHandler<DownloadCompletedEventArgs>? DownloadCompleted;

        public void Start(string name) => Task.Run(async () =>
        {
            await Task.Delay(100);
            DownloadCompleted?.Invoke(this, new(name.Length));
        });

        public Task<int> DownloadAsync(string name)
        {
            var source = new TaskCompletionSource<int>();

            void Handler(object? sender, DownloadCompletedEventArgs args)
            {
                DownloadCompleted -= Handler;
                source.SetResult(args.Bytes);
            }

            DownloadCompleted += Handler;
            return source.Task;
        }

        public void Dispose() => DownloadCompleted = null;
    }

    private sealed class DownloadCompletedEventArgs(int bytes) : EventArgs
    {
        public int Bytes { get; } = bytes;
    }
}
