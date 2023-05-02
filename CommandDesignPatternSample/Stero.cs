using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandDesignPatternSample
{
    public class Stero
    {
        public void On()
        {
            Console.WriteLine("Stero is on");
        }

        public void SetCD()
        {
            Console.WriteLine("Stero Set CD");
        }

        public void SetVolume()
        {
            Console.WriteLine("Volume is set");
        }
    }
}
