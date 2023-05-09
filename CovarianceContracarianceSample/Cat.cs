using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovarianceContracarianceSample
{
    public class Cat : Animal
    {
        public override Cat Create1(Cat cat)
        {
            return new Cat();
        }
    }
}
