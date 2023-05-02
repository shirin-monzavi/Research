using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandDesignPatternSample
{
    public class CeillingFan
    {
        public static int HIGH = 3;
        public static int MEDIUM = 2;
        public static int LOW = 1;
        public static int OFF = 1;

        string location;
        int speed;

        public CeillingFan(string location)
        {
            this.location = location;
            speed = OFF;
        }

        public void High()
        {
            speed = HIGH;
        }
        public void Medium()
        {
            speed = MEDIUM;
        }
        public void Low()
        {
            speed = LOW;
        }
        public void Off()
        {
            speed = LOW;
        }
        public int GetSpeed()
        {
            return speed;
        }
    }
}
