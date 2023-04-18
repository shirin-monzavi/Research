using NSubstitute;
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
            var target = sut.WithProp1(1)
                .WithProp2(2)
                .Build();

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
            new TargetManager(target as Target)
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

        [Fact]
        public void Test5()
        {
            //arrange
            var sut = Substitute.For<ITargetManager>();

            //act
            sut.WithProp1(1);

            //assert
            sut.Received(1).WithProp1(1);
        }

        [Fact]
        public void Test6()
        {
            //arrange
            var sut = Substitute.For<ITargetManager>();

            sut.WithProp1(1).Returns(ci => sut);

            //act
            sut.WithProp1(1).Build();

            //assert
            sut.Received(1).WithProp1(1);
            sut.Received(1).Build();
        }

        [Fact]
        public void Test7()
        {
            //arrange
            var sut = Substitute.For<ISubTargetManager>();

            sut.WithProp5("test5").Returns(ci => sut);

            //act
            sut.WithProp5("test5").Build();

            //assert
            sut.Received(1).WithProp5("test5");
            sut.Received(1).Build();
        }


        [Fact]
        public void Test8()
        {
            //arrange
            var sut = Substitute.For<ISubTargetManager>();

            sut.WithProp5("test5").Returns(ci => sut);

            //act
            var subTarget = sut.WithProp5("test5").Build();

            //assert
            sut.Received(1).WithProp5("test5");
            sut.Received(1).Build();
        }


        [Fact]
        public void Test9()
        {
            //arrange
            var sut = new SubTargetManager();


            //act
            var target = sut.WithProp1(1).WithProp2(2).Build();

            //assert
            Assert.Equal(1, target.Prop1);
        }

        [Fact]
        public void Test10()
        {
            //arrange
            var sut = new TestTargetManager();


            //act
            var target = sut
                .WithSomeProp()
                .WithSomeOtherProp()
                .targetManager.WithProp4("test4")
                .Build();

            //assert
            Assert.Equal(1, target.Prop1);
            Assert.Equal(2, target.Prop2);
            Assert.Equal("test4", target.Prop4);
        }

        //[Fact]
        //public void Test11()
        //{
        //    //arrange
        //    var sut = new TestTargetManager();


        //    //act
        //    var target = sut.WithSomeProp()
        //        .WithSomeOtherProp()
        //        .Build();

        //    //assert
        //    Assert.Equal(1, target.Prop1);
        //    Assert.Equal(2, target.Prop2);
        //}
    }
}