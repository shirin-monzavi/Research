using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovarianceContravarianceSampleTest
{
    public class Dog : Animal
    {
        //Covariance
        public override Dog Create()
        {
            return new Dog();
        }

        //Contravariant in Generics
        public override Animal Create1(IContravariant<Cat> animal)
        {
            return base.Create1(animal);    
        }

        //Contravariant in Delegate
        public override Animal Create2(Action<Cat> cat)
        {
            return base.Create2(cat);
        }
    }
}
