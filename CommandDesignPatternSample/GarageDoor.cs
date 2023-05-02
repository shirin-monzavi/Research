using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandDesignPatternSample
{
    public class GarageDoor
    {
        public void Up()
        {
            Console.WriteLine("Up");
        }

        public void Down()
        {
            Console.WriteLine("Down");
        }

        public void Stop()
        {
            Console.WriteLine("Stop");
        }

        public void LightOn()
        {
            Console.WriteLine("ON");
        }

        public void LightOff()
        {
            Console.WriteLine("Off");
        }
    }
}
