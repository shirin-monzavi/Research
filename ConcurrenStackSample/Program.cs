using System.Collections.Concurrent;

class Program
{
    static void Main(string [] args)
    {
        var concurrentStack = new ConcurrentStack<int>();

        for (int i = 0; i < 100; i++)
        {
            concurrentStack.Push(i);
        }


        while (concurrentStack.Count>0)
        {
            int data;
            bool success = concurrentStack.TryPop(out data);
            if (success)
            {
                Console.WriteLine(data);
            }
        }
    }
}