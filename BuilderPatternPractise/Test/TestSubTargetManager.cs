using BuilderPatternPractise.Managers;
using BuilderPatternPractise.Targets;

namespace BuilderPatternPractise.Test
{
    public class TestSubTargetManager : TestSubTargetManager<TestSubTargetManager, ISubTargetManager, ISubTarget>
    {
        protected override SubTargetManager CreateBuilder()
        {
            return new SubTargetManager();
        }
    }

    public abstract class TestSubTargetManager<TSelf, TBuilder, TITarget> : TestTargetManager<TSelf, TBuilder, TITarget>
        where TSelf : TestSubTargetManager<TSelf, TBuilder, TITarget>
        where TBuilder : ISubTargetManager<TBuilder, TITarget>
        where TITarget : class, ISubTarget
    {
        public TSelf WithSomeSomeProp()
        {
            Manager.WithProp1(1);

            return this;
        }
    }
}