using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTest
{
    [TestFixture]
    public class StackTests
    {
        [Test]
        public void Push_ObjectIsNull_ThrowArgumentNullException()
        {
            var stack = new Stack<object>();

            Assert.That(() => stack.Push(null), Throws.ArgumentNullException);
        }

        [Test]
        public void Push_ObjectIsNotNull_AddObjectToList()
        {
            var stack = new Stack<int>();
            stack.Push(1);

            Assert.That(stack.Peek(), Is.EqualTo(1));
        }
    }
}