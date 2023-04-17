using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPatternPractise
{
    public interface ITargetOptions
    {
        public int Prop1 { get; }

        public int Prop2 { get; }

        public string Prop3 { get; }

        public string Prop4 { get;  }
    }
}
