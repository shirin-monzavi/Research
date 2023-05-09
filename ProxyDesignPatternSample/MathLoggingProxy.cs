using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyDesignPatternSample
{
    public class MathLoggingProxy : IMath
    {
        public MathLoggingProxy()
        {
            Console.WriteLine("Calling the Math functions via Proxy");
        }

        private Math math = new Math();

        public int Add(int x, int y)
        {
            return math.Add(x, y);  
        }

        public int Divide(int x, int y)
        {
         return math.Divide(x, y);
        }

        public int Multiply(int x, int y)
        {
           return math.Multiply(x, y);
        }

        public int Subtract(int x, int y)
        {
           return math.Subtract(x, y);
        }
    }
}
