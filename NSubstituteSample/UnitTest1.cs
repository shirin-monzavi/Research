using NSubstitute;
using System;
using Xunit;

namespace NSubstituteSample
{
    public class UnitTest1
    {
        [Fact]
        public void ADD_NUMBER_ONE_AND_NUMBER_TWO_THE_RESULT_ADD_SHOULD_RECIEVE_ONE_CALL()
        {
            //Arrange
            var calc = Substitute.For<ICalculator>();

            //Act
            calc.Add(1, 2);

            //Assert
            calc.Received(1).Add(1, 2);
        }

        [Fact]
        public void ADD_NUMBER_ONE_AND_NUMBER_TWO_THE_RESULT_SHOULD_BE_THREE()
        {
            //Arrange
            var calc = Substitute.For<ICalculator>();
            calc.Add(1, 2).Returns(3);

            //Act
            calc.Add(1, 2);

            //Assert
            calc.Received(1).Add(1, 2);
        }

        [Fact]
        public void Divide_NUMBER_TEN_AND_NUMBER_TWO_THE_RESULT_SHOULD_BE_FIVE()
        {
            //Arrange
            var calc = Substitute.For<ICalculator>();

            float x;

            calc.Divide(Arg.Any<int>(), Arg.Any<int>(), out x).Returns(5);

            //Act
            calc.Divide(1, 2, out x);

            //Assert
            calc.Received(1).Divide(1, 2, out x);
        }

        [Fact]
        public void Divide_NUMBER_TEN_AND_NUMBER_ZERO_THEN_IT_SHOULD_THROW_EXCEPTION()
        {
            //Arrange
            var calc = Substitute.For<ICalculator>();

            float x;

            calc.Divide(Arg.Any<int>(), Arg.Any<int>(), out x).Returns(x => throw new Exception("Divion on zero"));

            //Act


            //Assert
            calc.Received(0).Divide(1, 2, out x);

            Assert.Throws<Exception>(() => calc.Divide(1, 2, out x));
        }
    }
}