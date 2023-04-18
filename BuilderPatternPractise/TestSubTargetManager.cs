using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPatternPractise
{
    public class TestSubTargetManager : TestTargetManager<TestSubTargetManager, ISubTargetManager, ISubTarget>
    {
        public TestSubTargetManager WithSomeSomeProp()
        {
            targetManager.WithProp1(1);

            return this;
        }

        protected override SubTargetManager CreateBuilder()
        {
            return new SubTargetManager();
        }
    }
}
