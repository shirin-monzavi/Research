using FluentAssertions;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Xunit;

namespace FluentAssertionSample
{
    public partial class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Arrage
            object theObject = null;

            //Act

            //Assert
            theObject.Should().BeNull(because: "becuase the value is null");
        }

        [Fact]
        public void Test2()
        {
            //Arrage
            object theObject = new object();

            //Act

            //Assert
            theObject.Should().NotBeNull(because: "becuase the value is not null");
        }

        [Fact]
        public void Test3()
        {
            //Arrage
            string theObject = "whatever";

            //Act

            //Assert
            theObject.Should().BeOfType<string>().Which.Should().NotBeNull();
        }

        [Fact]
        public void Test4()
        {
            //Arrage
            string theObject = "whatever";

            //Act

            //Assert
            theObject.Should().Be(theObject);
        }

        [Fact]
        public void Test5()
        {
            //Arrage
            string theObject1 = "whatever";
            string theObject2 = theObject1;

            //Act

            //Assert
            theObject1.Should().BeSameAs(theObject2);
        }

        [Fact]
        public void Test6()
        {
            //Arrage
            var ex = new Exception("the an exception message");

            //Act

            //Assert
            ex.Should().BeAssignableTo<Exception>();
        }

        [Fact]
        public void Test7()
        {
            //Arrage
            short? theShort = null;

            //Act

            //Assert
            theShort.Should().Match(x => !x.HasValue);
        }

        [Fact]
        public void Test8()
        {
            //Arrage
            short? theShort = 1;

            //Act

            //Assert
            theShort.Should().HaveValue();
        }


        [Fact]
        public void Test9()
        {
            //Arrage
            bool theBoolean = false;

            //Act

            //Assert
            theBoolean.Should().BeFalse();
        }

        [Fact]
        public void Test10()
        {
            //Arrage
            bool theBoolean = true;

            //Act

            //Assert
            theBoolean.Should().Be(true);
        }

        [Fact]
        public void Test11()
        {
            //Arrage
            string theString = "";

            //Act

            //Assert
            theString.Should().NotBeNull();
        }

        [Fact]
        public void Test12()
        {
            //Arrage
            string theString = string.Empty;

            //Act

            //Assert
            theString.Should().BeEmpty();
        }


        [Fact]
        public void Test13()
        {
            //Arrage
            string theString = "should not be empty";

            //Act

            //Assert
            theString.Should().NotBeEmpty();
        }


        [Fact]
        public void Test14()
        {
            //Arrage
            string theString = " ";

            //Act

            //Assert
            theString.Should().BeNullOrWhiteSpace();
        }

        [Fact]
        public void Test15()
        {
            //Arrage
            string theString = "Hello!";

            //Act

            //Assert
            theString.Should().HaveLength(6);
        }

        [Fact]
        public void Test16()
        {
            //Arrage
            string theString = "HELLO";

            //Act

            //Assert
            theString.Should().BeUpperCased();
        }

        [Fact]
        public void Test17()
        {
            //Arrage
            string theString = "hello";

            //Act

            //Assert
            theString.Should().BeLowerCased();
        }

        [Fact]
        public void Test18()
        {
            //Arrage
            string theString = "Hello!";

            //Act

            //Assert
            theString.Should().BeEquivalentTo("Hello!");
        }

        [Fact]
        public void Test19()
        {
            //Arrage
            string theString = "Hello!";

            //Act

            //Assert
            theString.Should().BeOneOf("Hello!", "hello");
        }

        [Fact]
        public void Test20()
        {
            //Arrage
            string theString = "Hello!";

            //Act

            //Assert
            theString.Should().Contain("!", Exactly.Once());
        }

        [Fact]
        public void Test21()
        {
            //Arrage
            string theString = "Hello!";

            //Act

            //Assert
            theString.Should().ContainAll("!", "H");
        }

        [Fact]
        public void Test22()
        {
            //Arrage
            string theString = "Hello!";

            //Act

            //Assert
            theString.Should().NotContain("$", "*");
        }

        [Fact]
        public void Test23()
        {
            //Arrage
            string theString = "Hello!";

            //Act

            //Assert
            theString.Should().StartWith("H");
            theString.Should().EndWith("!");
        }

        [Fact]
        public void Test24()
        {
            //Arrage
            string theEmailAddress = "test@dev.com";

            //Act

            //Assert
            theEmailAddress.Should().Match("*@*.com");
        }

        [Fact]
        public void Test25()
        {
            //Arrage
            string theEmailAddress = "test@dev.com";

            //Act

            //Assert
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            theEmailAddress.Should().MatchRegex(regex);
        }

        [Fact]
        public void Test26()
        {
            //Arrage
            int theInt = 5;

            //Act

            //Assert

            theInt.Should().BeGreaterThan(2);
            theInt.Should().BeGreaterThanOrEqualTo(5);
            theInt.Should().BePositive();
            theInt.Should().BeInRange(1, 5);
            theInt.Should().Be(5);
        }

        [Fact]
        public void Test27()
        {
            //Arrage
            float theFloat = 5.5f;

            //Act

            //Assert

            theFloat.Should().BeApproximately(4.5f, 5.5f);
        }


        [Fact]
        public void Test28()
        {
            //Arrage
            IEnumerable<int> collection = new[] { 1, 2, 3, 4, 5 };

            //Act

            //Assert

            collection.Should().BeEquivalentTo(new[] { 1, 2, 3, 4, 5 });
            collection.Should().OnlyHaveUniqueItems().And.HaveCount(5);
            collection.Should().BeSubsetOf(new[] { 1, 2, 3, 4, 5, 6 });
            collection.Should().OnlyContain(x => x <= 5);
            collection.Should().BeInAscendingOrder();
        }

        [Fact]
        public void Test29()
        {
            //Arrage
            var collection = new[]
            {
                new { Id=1,Name="Sam",},
                new { Id=2, Name="Sara"}
            };

            //Act

            //Assert

            collection.Should().SatisfyRespectively(

                first =>
                {
                    first.Id.Should().Be(1);
                    first.Name.Should().NotBeEmpty();
                },
                seccod =>
                {
                    seccod.Id.Should().Be(2);
                    seccod.Name.Should().NotBeEmpty();
                });

            collection.Should().Satisfy(
                x => x.Id == 1,
                e => e.Id == 2
                );
        }


        [Fact]
        public void Test30()
        {
            //Arrage
            MyEnum theEnum = MyEnum.One;
            //Act

            //Assert

            theEnum.Should().HaveFlag(MyEnum.One);
            theEnum.Should().NotHaveFlag(MyEnum.Two);
        }

        [Fact]
        public void Test31()
        {
            //Arrage
            var theEnum1 = (MyEnum)1;
            var theEnum2 = (MyEnum)9;

            //Act

            //Assert

            theEnum1.Should().BeDefined();
            theEnum2.Should().NotBeDefined();
            theEnum1.Should().HaveValue(1);
        }

        [Fact]
        public void Test32()
        {
            //Arrage
            MyEnum theEnum1 = MyEnum.One;
            AnotherMyEnum theEnum2 = AnotherMyEnum.One;

            //Act

            //Assert

            theEnum1.Should().HaveSameValueAs(theEnum2);
        }
    }
}
