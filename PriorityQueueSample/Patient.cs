using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueueSample
{
    public class Patient
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Patient(string name, int age)
        {
            Name = name;
            Age = age;
        }



    }
}
