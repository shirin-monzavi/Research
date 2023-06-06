using System.Threading;
using Xunit;

namespace XunitTestSample
{
    [Collection("First")]
    public class TestClass1
    {
        [Fact]
        public void Test4()
        {
            Thread.Sleep(3000);
        }
    }

    [Collection("First")]
    public class TestClass2
    {
        [Fact]
        public void Test5()
        {
            Thread.Sleep(3000);
        }
    }
}