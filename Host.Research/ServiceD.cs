using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostSample
{
    public class ServiceD : IServiceD
    {
        private readonly IMyService _myService;
        public ServiceD(IMyService myService)
        {
            _myService = myService;
        }

        public void Print()
        {
            _myService.Log();
        }
    }
}
