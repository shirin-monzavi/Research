using System.Collections.Concurrent;

class Program
{
    static Dictionary<string, int> _myDic = new();
    static ConcurrentDictionary<string, int> _myDicContr = new();
    public static void Main(string[] args)
    {
        ConcurrentDictionary<string, string> dictionary = new();
        //var t1 = new Thread(() => InsertData());
        //var t2 = new Thread(() => InsertData());
        //t1.Start();
        //t2.Start();
        //t1.Join();
        //t2.Join();

        var t3 = new Thread(() => InsertDataC());
        var t4 = new Thread(() => InsertDataC());
        t3.Start();
        t4.Start();
        t3.Join();
        t4.Join();

        Console.WriteLine($"_myDic {_myDic.Count}");
        Console.WriteLine("********************************************");
        Console.WriteLine($"_myDicContr {_myDicContr.Count}");

        bool r1 = dictionary.TryAdd("1", "A");
        Console.WriteLine(r1);
        bool r2 = dictionary.TryAdd("2", "B");
        Console.WriteLine(r2);
        bool r3 = dictionary.TryAdd("1", "C");
        Console.WriteLine(r3);

        Console.WriteLine("********************************************");

        string item1;
        bool r4 = dictionary.TryGetValue("1", out item1);

        Console.WriteLine(item1);

        string item2;
        bool r5 = dictionary.TryGetValue("3", out item2);

        Console.WriteLine(item2);

        Console.WriteLine("********************************************");
        string removedItem;
        bool r6 = dictionary.TryRemove("2", out removedItem);
        Console.WriteLine($"Removed Item {removedItem}");

        Console.WriteLine("********************************************");

        string updatedItem;
        bool r7 = dictionary.TryUpdate("1", "P", "A");
        bool r8 = dictionary.TryGetValue("1", out updatedItem);
        Console.WriteLine($"updatedItem Item {updatedItem}");

        Console.WriteLine("********************************************");
        bool r9 = dictionary.ContainsKey("1");
        Console.WriteLine($"R9 {r9}");

        bool r10 = dictionary.ContainsKey("5");
        Console.WriteLine($"r10 {r10}");

        Console.WriteLine("********************************************");

        Dictionary<string, string> pairs = dictionary.ToDictionary(k => k.Key, v => v.Value);

        KeyValuePair<string, string>[] keyValuePairs = dictionary.ToArray();

        List<KeyValuePair<string, string>> lst = dictionary.ToList();

        foreach (var item in pairs)
        {
            Console.WriteLine(item.Key + " : " + item.Value);
        }

        Console.WriteLine("********************************************");
        dictionary.Clear();
    }

    static void InsertData()
    {
        for (int i = 0; i < 100; i++)
        {
            _myDic.Add(Guid.NewGuid().ToString(), i);
        }
    }

    static void InsertDataC()
    {
        for (int i = 0; i < 100; i++)
        {
            _myDicContr.TryAdd(Guid.NewGuid().ToString(), i);
        }
    }
}