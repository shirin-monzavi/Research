using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorDesingPatternSample
{
    public abstract class CondimentsDecorator : Beverage
    {
        public abstract override string Description { get; }
    }
}
