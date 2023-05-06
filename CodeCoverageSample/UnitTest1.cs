using Xunit;
using Xunit.Abstractions;

namespace CodeCoverageSample
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper outputHelper;
        public UnitTest1(ITestOutputHelper outputHelper)
        {
            this.outputHelper = outputHelper;
        }

        [Fact]
        public void X_Divide_Y_Should_Be_2()
        {
            //Arrage
            int x = 4;
            int y = 2;
            var divider = new Divider();

            //Act
            var result=divider.Divide(x, y);

            this.outputHelper.WriteLine("Result is: "+result.ToString());

            //Assert

            Assert.Equal(2, result);
        }

        [Fact]
        public void X_Divide_Y_Should_Be_0()
        {
            //Arrage
            int x = 4;
            int y = 0;
            var divider = new Divider();

            //Act
            var result = divider.Divide(x, y);
            //Assert

            Assert.Equal(0, result);
        }
    }
}