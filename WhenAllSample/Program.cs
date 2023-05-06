class Prgoram
{
    public static async Task Main(string[] arg)
    {
        var task1 = Task.Run(() =>
          {
              DoWork(1);
          });

        var task2 = Task.Run(() =>
         {
             DoWork(2);
         });


        var task3 = Task.Run(() =>
        {
            DoWork(3);
        });

        await Task.WhenAll(task1, task2, task3);

    }

    static async Task<int> DoWork(int taskId)
    {
        Console.WriteLine("Task is started {0}", taskId);

        Console.WriteLine("Task Is Finished {0}", taskId);

        return taskId;
    }
}
