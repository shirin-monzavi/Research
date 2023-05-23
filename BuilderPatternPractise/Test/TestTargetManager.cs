using BuilderPatternPractise.Managers;
using BuilderPatternPractise.Targets;

namespace BuilderPatternPractise.Test
{
    public class TestTargetManager : TestTargetManager<TestTargetManager, ITargetManager, ITarget>
    {
        protected override TargetManager CreateBuilder()
        {
            return new TargetManager();
        }
    }

    public abstract class TestTargetManager<TSelf, TManager, TITarget>
        where TSelf : TestTargetManager<TSelf, TManager, TITarget>
        where TManager : ITargetManager<TManager, TITarget>
        where TITarget : class, ITarget

    {
        public readonly TManager Manager;

        public TestTargetManager()
        {
            Manager = CreateBuilder();
        }

        protected abstract TManager CreateBuilder();

        public TSelf WithSomeProp()
        {
            Manager.WithProp1(1).WithProp2(2);
            return this;
        }

        public TSelf WithSomeOtherProp()
        {
            Manager.WithProp3("test3");
            return this;
        }

        public TITarget Build()
        {
            return Manager.Build();
        }

        public static implicit operator TSelf(TestTargetManager<TSelf, TManager, TITarget> manager)
        {
            return (TSelf)manager;
        }
    }
}