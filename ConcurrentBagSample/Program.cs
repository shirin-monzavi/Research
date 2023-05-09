using System.Collections.Concurrent;

class Program
{
    public static void Main(string [] args)
    {
        var concurrentBag = new ConcurrentBag<int>();

        for (int i = 1; i <= 10; i++)
        {
            concurrentBag.Add(i);
        }

        while (concurrentBag.Count>0)
        {
            int element;
            if(concurrentBag.TryTake(out element))
            {
                Console.WriteLine(element);
            }
        }
    }
}