namespace BuilderPatternPractise
{

    //public class SubTargetManagerTest : TargetManagerTest<ISubTargetManager<ISubTargetManager, ISubTarget>>
    //{
    //}

    //public class TargetManagerTest : TargetManagerTest<TargetManager>
    //{
    //}

    //public abstract class TargetManagerTest
    //{
    //    private readonly ITarget target;
    //    public TargetManagerTest()
    //    {
    //        target = Substitute.For<ITarget>();
    //    }

    //    public TSelf CreateInstance()
    //    {
    //        return (TSelf)Activator.CreateInstance(typeof(TSelf), null)!;
    //    }

    //    [Fact]
    //    public void WithProp1_OneIsEntered_PropOneShouldBeOne()
    //    {
    //        //Arrange
    //        var sut = CreateInstance();

    //        //Act
    //        var actual = sut.WithProp1(1).Build();

    //        //Assert
    //        Assert.Equal(1, actual.Prop1);
    //    }

    //    [Fact]
    //    public void WithProp2_TwoIsEntered_PropTwoShouldBTwo()
    //    {
    //        //Arrange
    //        var sut = CreateInstance();

    //        //Act
    //        var actual = sut.WithProp2(2).Build();

    //        //Assert
    //        Assert.Equal(2, actual.Prop2);
    //    }
    //}
}
