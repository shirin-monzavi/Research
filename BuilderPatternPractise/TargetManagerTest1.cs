using System;
using Xunit;

namespace BuilderPatternPractise
{
    public class TargetManagerTest2 : TargetManagerTest2<SubTargetManager, ISubTargetManager, ISubTarget, SubTarget>
    {
    }

    public abstract class TargetManagerTest2<TManager, TIManager, TITarget, TTarget> : TargetManagerTest1<TManager, TIManager, TITarget, TTarget>
        where TManager : SubTargetManager<TIManager, TITarget, TTarget>
        where TIManager : ISubTargetManager<TIManager, TITarget>
        where TITarget : class, ISubTarget
        where TTarget : TITarget
    {
        [Fact]
        public void Test2()
        {
            //Arrange

            //Act
            var actual = sut.WithProp5("hello").Build();

            //Assert
            Assert.Equal("hello", actual.Prop5);
        }

    }


    public class TargetManagerTest1 : TargetManagerTest1<TargetManager, ITargetManager, ITarget, Target>
    {
    }

    public abstract class TargetManagerTest1<TManager, TIManager, TITarget, TTarget>
        where TManager : TargetManager<TIManager, TITarget, TTarget>
        where TIManager : ITargetManager<TIManager, TITarget>
        where TITarget : class, ITarget
        where TTarget : TITarget
    {
        protected TManager sut;
        private TITarget target;
        public TargetManagerTest1()
        {
            sut = CreateInstance();
        }

        public TManager CreateInstance()
        {
            return (TManager)Activator.CreateInstance(typeof(TManager), target)!;
        }

        [Fact]
        public void Test1()
        {
            //Arrange

            //Act
            var actual = sut.WithProp1(1).Build();

            //Assert
            Assert.Equal(1, actual.Prop1);
        }
    }
}
