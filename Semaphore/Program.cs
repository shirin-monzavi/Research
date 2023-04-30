class Program
{

    static Semaphore sem = new Semaphore(2, 3);
    public static async Task Main(string[] arg)
    {
        for (int i = 0; i < 10; i++)
        {
            _ = DoSomeWorkAsync(i);
        }
        Console.ReadKey();
    }

    private static async Task<bool> DoSomeWorkAsync(int i)
    {
        try
        {
            sem.WaitOne();

            Console.WriteLine($"{i} doing its");
            await DoNothing(i);
            Console.WriteLine($"{i} exit");
        }
        finally
        {
            sem.Release();
        };

        return true;
    }

    private static async Task<string> DoNothing(int i)
    {
        Console.WriteLine($"Start to do nothing {i}");

        await Task.Delay(1000);

        Console.WriteLine($"Do nothing {i}");

        return "";
    }
}