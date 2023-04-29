class OneAtATimePlease
{
    static void Main()
    {
        // Naming a Mutex makes it available computer-wide. Use a name that's
        // unique to your company and application (e.g., include your URL).
        bool createdNew;
        using (var mutex = new Mutex(false, "test", out createdNew))
        {
            if (createdNew)
            {
                RunProgram();
            }
            Console.WriteLine("Another app instance is running. Bye!");
            Thread.Sleep(TimeSpan.FromSeconds(10));
            return;
        }
    }

    static void RunProgram()
    {
        Console.WriteLine("Running. Press Enter to exit");
        Console.ReadLine();
    }
}