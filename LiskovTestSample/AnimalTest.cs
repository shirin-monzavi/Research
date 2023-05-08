using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LiskovTestSample
{
    public abstract class AnimalTest<T> where T : Animal
    {
        public T Make(int weight)
        {
            return (T)Activator.CreateInstance(typeof(T), weight)!;
        }

        [Fact]
        public void CalculateDozeOfMedicine_When_The_Wieght_Is_10_The_Doze_Should_Be_20()
        {
            //Arrange
            var createInstance = Make(10);

            //Act
            var result = createInstance.CalculateDozeOfMedicine();

            //Assert
            Assert.Equal(20, result);
        }
    }
}
