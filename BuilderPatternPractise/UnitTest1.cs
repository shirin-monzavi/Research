using Xunit;

namespace BuilderPatternPractise
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //arrange
            var sut = new TargetManager();

            //act
            var target = sut.WithProp1(1).WithProp2(2).Build();

            //assert

            Assert.Equal(1, target.Prop1);
            Assert.Equal(2, target.Prop2);
        }

        [Fact]
        public void Test2()
        {
            //arrange
            var sut = new SubTargetManager();

            //act
            var target = sut.WithProp5("test5").WithProp4("test4").Build();

            //assert
            Assert.Equal("test5", target.Prop5);
        }

        [Fact]
        public void Test3()
        {
            //arrange
            var sut = new TargetManager();
            var target = sut.WithProp1(1).WithProp2(2).Build();

            //act
            new TargetManager(target)
            .WithProp1(2)
            .Update(target)
            ;


            //assert
            Assert.Equal(2, target.Prop1);
        }

        [Fact]
        public void Test4()
        {
            //arrange
            var sut = new SubTargetManager();
            var target = sut.WithProp1(1).WithProp2(2).Build();

            //act

            new SubTargetManager(target)
           .WithProp1(2)
           .Update(target);

            //assert
            Assert.Equal(2, target.Prop1);
        }
    }
}