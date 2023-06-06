using System.Collections.Generic;
using Xunit;

namespace XunitTestSample
{
    public class StackTest //: IDisposable
    {
        private Stack<int> stack = new Stack<int>();

        //public StackTest()
        //{
        //    stack = new Stack<int>();
        //}

        public void Dispose()
        {
            stack.Clear();
        }

        [Fact]
        public void WithNoItems()
        {
            stack.Push(1);
            Assert.Equal(1, stack.Count);
        }

        [Fact]
        public void WithItems()
        {
            stack.Push(2);
            Assert.Equal(1, stack.Count);
        }
    }
}