using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPatternPractise
{
    public class SubTarget : Target, ISubTargetOptions
    {
        public string Prop5 => prop5;
        private string prop5;

        public SubTarget(ISubTargetOptions options) : base(options)
        {
            prop5 = options.Prop5;
        }

        public void Update(ISubTargetOptions options)
        {
            base.Update(options);
            setUp(options);
        }

        private void setUp(ISubTargetOptions options)
        {
            prop5 = options.Prop5;
        }
    }
}
