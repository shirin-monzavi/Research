namespace HostSample
{
    public class ServiceA : IMyService
    {
        public void Log()
        {
            Console.WriteLine("This Log Comes From Service A");
        }
    }
}