namespace HostSample
{
    public class ServiceC : IServiceC
    {
        private readonly IMyService _myService;

        public ServiceC(IMyService myService)
        {
            _myService = myService;
        }

        public void Print()
        {
            _myService.Log();
        }
    }
}