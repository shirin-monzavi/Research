using BuilderPatternPractise.Managers;
using BuilderPatternPractise.Targets;
using Xunit;

namespace BuilderPatternPractise.Test
{
    public class SubTargetManagerTests : SubTargetManagerTests<TestSubTargetManager, ISubTargetManager, ISubTarget>
    {
    }

    public abstract class SubTargetManagerTests<TManager, TIManager, TITarget> : TargetManagerTests<TManager, TIManager, TITarget>
        where TManager : TestSubTargetManager<TManager, TIManager, TITarget>
        where TIManager : ISubTargetManager<TIManager, TITarget>
        where TITarget : class, ISubTarget
    {
        [Fact]
        public void Test2()
        {
            //Arrange

            //Act
            var actual = sut.Manager.WithProp5("hello").Build();

            //Assert
            Assert.Equal("hello", actual.Prop5);
        }
    }
}