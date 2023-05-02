using System.Collections.Concurrent;

class Program
{
    public static async Task Main(string[] args)
    {
        var blockingCollection1 = new BlockingCollection<int>(2);

        blockingCollection1.Add(1);
        blockingCollection1.Add(2);
        if (blockingCollection1.TryAdd(1, 1000))
        {
            Console.WriteLine("It is added");
        }
        else
        {
            Console.WriteLine("It is not added");
        }

        Console.WriteLine(blockingCollection1.Take());

        int item = 0;

        if (blockingCollection1.TryTake(out item, 1000))
        {
            Console.WriteLine($"{item} is taken");
        }
        else
        {
            Console.WriteLine("It is not taken");
        }


        var blockingCollection2 = new BlockingCollection<int>(10);


        var producer = Task.Run(() =>
        {
            for (int i = 0; i < 10; i++)
            {
                blockingCollection2.Add(i);
            }

            blockingCollection2.CompleteAdding();
        });

        Console.WriteLine("----------------------");
        var consumer = Task.Run(() =>
        {
            while (!blockingCollection2.IsCompleted)
            {
                var item = blockingCollection2.Take();
                Console.WriteLine(item);
            }

            blockingCollection2.CompleteAdding();
        });

        await Task.WhenAll(consumer, producer);

    }
}
