using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovarianceContracarianceSample
{
    public class Dog : Animal
    {
        public override Cat Create1(Cat cat)
        {
            return new Cat();
        }
    }
}
