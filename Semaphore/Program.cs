internal class Program
{
    private static Semaphore sem = new Semaphore(0, 3);

    public static void Main(string[] arg)
    {
        for (int i = 0; i < 10; i++)
        {
            Thread threadObject = new Thread(() => DoSomeWorkAsync(i))
            {
                Name = "Thread " + i
            };
            threadObject.Start();
        }
        Console.ReadKey();
    }

    private static bool DoSomeWorkAsync(int i)
    {
        try
        {
            sem.WaitOne();

            Console.WriteLine($"{i} doing its");
            DoNothing(i);
            Console.WriteLine($"{i} exit");
        }
        finally
        {
            sem.Release();
        };

        return true;
    }

    private static string DoNothing(int i)
    {
        Console.WriteLine($"Start to do nothing {i}");

        Task.Delay(1000);

        Console.WriteLine($"Do nothing {i}");

        return "";
    }
}