class Program
{
    static object monitor = new object();
    public static void Main(string[] arg)
    {
        Thread t1 = new Thread(Worker);
        Thread t2 = new Thread(Boss);
        t1.Start();
        Thread.Sleep(1000);
        t2.Start();

    }

    static void Worker()
    {
        lock (monitor)
        {
            Console.WriteLine("i am free");
            Monitor.Wait(monitor);
            Console.WriteLine("Working");
            Monitor.Pulse(monitor);
        }
    }

    static void Boss()
    {
        lock (monitor)
        {
            Console.WriteLine("Do it");

            Monitor.Pulse(monitor);

            Monitor.Wait(monitor);
            Console.WriteLine("well done");
        }
    }

}