using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostSample
{
    public class MyClass : IMyClass
    {
        public int Do()
        {
            return 1;
        }

        public Task<int> DoAsync()
        {
            return Task.Factory.StartNew(() => { return 1; });
        }
    }
}
