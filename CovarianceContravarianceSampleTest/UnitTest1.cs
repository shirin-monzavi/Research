using System;
using System.Collections.Generic;
using Xunit;

namespace CovarianceContravarianceSampleTest
{
    public class UnitTest1
    {
        [Fact]
        public void CovarianceSample1()
        {
            //Arrange
            var dog = new Dog();


            //Act
            var actual = dog.Create();


            //Assert
            Assert.NotNull(actual);
        }

        [Fact]
        public void CovarianceSample2()
        {
            //Arrange

            //Act
            IEnumerable<object> obj = new List<string>();

            //Assert
        }

        [Fact]
        public void CovarianceSample3()
        {
            //Arrange

            //Act
            object[] objArray = new string[10];

            //Assert
        }


        [Fact]
        public void ContravarianceSample1WithGenerics()
        {
            //Arrange
            var cat = new Cat();

            IContravariant<Animal> animal = new Contravariant();

            //Act
            cat.Create1(animal);


            //Assert

        }


        [Fact]
        public void ContravarianceSample2WithDelegate()
        {
            //Arrange
            var cat = new Cat();

            Action<Animal> animal = (a) => { new Animal(); };

            //Act
            cat.Create2(animal);


            //Assert

        }
    }
}