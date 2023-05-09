using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovarianceContravarianceSampleTest
{
    public class Animal
    {
        public virtual Animal Create()
        {
            return new Animal();
        }

        public virtual Animal Create1(IContravariant<Cat> dog)
        {
            return new Animal();
        }

        public virtual Animal Create2(Action<Cat> dog)
        {
            return new Animal();
        }
    }
}
