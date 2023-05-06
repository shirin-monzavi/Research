class Program
{
    public static async Task Main(string[] args)
    {
        await Task.FromResult(Calculate(10, 5));
    }

    public static int Calculate(int x, int y)
    {
        return x + y;
    }
}