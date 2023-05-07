using Xunit;

namespace XunitTestSample
{
    public class UnitTest1 : Calculator
    {
        private readonly Calculator sut;
        public UnitTest1()
        {
            sut = new Calculator();
        }
        [Fact]
        public void PassingTest()
        {
            //Arrange


            //Act
            var result = sut.Add(2, 2);

            //Assert
            Assert.Equal(4, result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(7)]
        public void MyFirstTheory(int value)
        {
            //Arrange

            //Act
            var result = sut.IsOdd(value);

            //Assert
            Assert.True(result);
        }
    }
}