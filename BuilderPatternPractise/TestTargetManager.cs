using System;

namespace BuilderPatternPractise
{
    public class TestTargetManager : TestTargetManager<TestTargetManager, ITargetManager, ITarget>
    {
        protected override TargetManager CreateBuilder()
        {
            return new TargetManager();
        }
    }

    public abstract class TestTargetManager<TSelf,TBuilder, TITarget>
        where TSelf : TestTargetManager<TSelf, TBuilder, TITarget>
        where TBuilder : ITargetManager<TBuilder, TITarget>
        where TITarget :class, ITarget

    {
        public readonly TBuilder targetManager;
        public TestTargetManager()
        {
            targetManager = CreateBuilder();
        }

        protected abstract TBuilder CreateBuilder();

        public TSelf WithSomeProp()
        {
            targetManager.WithProp1(1).WithProp2(2);
            return this;
        }

        public TSelf WithSomeOtherProp()
        {
            targetManager.WithProp3("test3");
            return this;
        }

        public TITarget Build()
        {
            return targetManager.Build();
        }

        public static implicit operator TSelf(TestTargetManager<TSelf, TBuilder, TITarget> manager)
        {
            return (TSelf)manager;
        }
    }
}
