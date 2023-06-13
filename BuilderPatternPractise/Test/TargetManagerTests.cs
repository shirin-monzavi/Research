using BuilderPatternPractise.Managers;
using BuilderPatternPractise.Targets;
using System;
using Xunit;

namespace BuilderPatternPractise.Test
{
    public class TargetManagerTests : TargetManagerTests<TestTargetManager, ITargetManager, ITarget>
    {
    }

    public abstract class TargetManagerTests<TManager, TIManager, TITarget>
        where TManager : TestTargetManager<TManager, TIManager, TITarget>
        where TIManager : ITargetManager<TIManager, TITarget>
        where TITarget : class, ITarget
    {
        protected TManager sut;

        public TargetManagerTests()
        {
            sut = CreateInstance();
        }

        public TManager CreateInstance()
        {
            return Activator.CreateInstance<TManager>();
        }

        [Fact]
        public void Test1()
        {
            //Arrange

            //Act
            var actual = sut.WithSomeProp().WithSomeOtherProp().Manager.Build();

            //Assert
            Assert.Equal(1, actual.Prop1);
        }
    }
}