using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorDesingPatternSample
{
    public class HouseBlend : Beverage
    {
        public HouseBlend()
        {
            Description = "HouseBlend";
        }
        public override double Cost()
        {
            return 0.98;
        }
    }
}
