class Program
{
    static int counter = 0;
    static ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();
    public static async Task Main(string[] args)
    {
        for (int i = 1; i <= 4; i++)
        {
            new Thread(() => ReadIt()).Start();
        }

        for (int i = 1; i <= 2; i++)
        {
            new Thread(() => WriteIt()).Start();
        }
    }

    public static void ReadIt()
    {
        while (true)
        {
            try
            {
                _lock.EnterReadLock();

                Console.WriteLine($"R : thread {Thread.CurrentThread.ManagedThreadId} is reading {counter}");
            }
            finally
            {
                _lock.ExitReadLock();

            }
            Thread.Sleep(1000);
        }
    }

    public static void WriteIt()
    {
        try
        {
            _lock.EnterWriteLock();

            Console.WriteLine($"W: Thread {Thread.CurrentThread.ManagedThreadId} is writing {counter++}");

        }
        finally
        {
            _lock.ExitWriteLock();
        }

        Thread.Sleep(2000);
    }
}
