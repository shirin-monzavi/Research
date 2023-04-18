using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPatternPractise
{
    public interface ITargetOptions
    {
        int Prop1 { get; }

        int Prop2 { get; }

        string Prop3 { get; }

        string Prop4 { get; }
    }
}
