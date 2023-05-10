using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitBreakerSample
{
    public class Config
    {
        public static int CircuitOpenTimeout => 4000;
        public static int CircuitClosedErrorLimit = 2;
        public static int CircuitHalfOpenSuccessLimit = 1;
    }
}
