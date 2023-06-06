internal class Program
{
    public static void Main(string[] args)
    {
        var t = EvaluateValue("1");
        Console.WriteLine(t.IsCompleted);
        Console.WriteLine(t.IsCanceled);
        Console.WriteLine(t.IsFaulted);
    }

    public static Task EvaluateValue(string value)
    {
        var tcs = new TaskCompletionSource<object>();

        if (value == "1")
        {
            tcs.SetResult("1");
        }
        else if (value == "2")
        {
            tcs.SetCanceled();
        }
        else
        {
            tcs.SetException(new ArgumentNullException(value));
        }

        return tcs.Task;
    }
}