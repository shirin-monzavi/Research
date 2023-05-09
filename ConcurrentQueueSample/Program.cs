using System.Collections.Concurrent;

class Program
{
    public static void Main(string[] args)
    {
        var concurrentQueue = new ConcurrentQueue<int>();

        for (int i = 0; i < 100; i++)
        {
            concurrentQueue.Enqueue(i);
        }

        var sum = 0;
        Parallel.For(0, 100, i =>
        {
            var localSum = 0;
            int localValue;

            while (concurrentQueue.TryDequeue(out localValue))
            {
                Thread.Sleep(10);
                localSum += localValue;
            }
            Interlocked.Add(ref sum, localSum);
        });

        Console.WriteLine("Concurrent queue");

        Console.WriteLine($"outerSum= {sum} ");
    }
}
