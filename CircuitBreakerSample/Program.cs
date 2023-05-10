using CircuitBreakerSample;

class Program
{
    static int counter = 0;
    public static async Task Main(string[] args)
    {
        var circuitBreaker = new CircuitBreaker();

        while (true)
        {
            try
            {
                await circuitBreaker.ExecuteService(() => Task.FromResult(Sum(5, 5)));
            }
            catch (Exception)
            {
                Console.WriteLine("Service is unavailable");
                continue;
            }

        }
    }

    public static int Sum(int x, int y)
    {
        counter++;

        if (counter > 1)
        {
            counter = 0;
            throw new Exception("Service is unavailable");
        }

        int z = x + y;
        Console.WriteLine($"reuslt: {z}");
        return z;
    }
}