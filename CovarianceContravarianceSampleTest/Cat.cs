using System;

namespace CovarianceContravarianceSampleTest
{
    public class Cat : Animal
    {
        //Covariance
        public override Cat Create()
        {
            return new Cat();
        }

        //Contravariant in Generics
        public override Animal Create1(IContravariant<Cat> cat)
        {
            return base.Create1(cat);
        }

        //Contravariant in Delegate
        public override Animal Create2(Action<Cat> cat)
        {
            return base.Create2(cat);
        }
    }
}
