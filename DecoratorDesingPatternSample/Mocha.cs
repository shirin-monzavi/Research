using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorDesingPatternSample
{
    public class Mocha : CondimentsDecorator
    {
        private readonly Beverage _beverage;

        public Mocha(Beverage beverage)
        {
            _beverage = beverage;
        }
        public override string Description => _beverage.Description + ",Mocha";

        public override double Cost()
        {
            return _beverage.Cost() + 5;
        }
    }
}
