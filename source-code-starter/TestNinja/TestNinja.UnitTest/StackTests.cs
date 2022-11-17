using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTest
{
    [TestFixture]
    public class StackTests
    {
        [SetUp]
        public void SetUp()
        {
            _stack = new Stack<string>();
        }

        private Stack<string> _stack;

        [Test]
        public void Push_ArgIsNull_ThrowArgumentNullException()
        {
            Assert.That(() => _stack.Push(null), Throws.ArgumentNullException);
        }

        [Test]
        public void Push_ValidArgument_AddObjectToTheStack()
        {
            _stack.Push("a");

            // We can not use this 
            // Assert.That(_stack.Peek(), Is.EqualTo(1));
            // We can not access the list because is private
            // We only test the public API, so we assert only that the object has been pushed,
            // but not if the object pushed is our object
            Assert.That(_stack.Count, Is.EqualTo(1));
        }

        // We also need to test the Count property
        // We test that when the _stack is empty, count = 0
        [Test]
        public void Count_EmptyStack_ReturnZero()
        {
            Assert.That(_stack.Count, Is.EqualTo(0));
        }

        [Test]
        public void Pop_EmptyStack_ThrowsInvalidOperationException()
        {
            Assert.That(() => _stack.Pop(), Throws.InvalidOperationException);
        }

        [Test]
        public void Pop_StackWithFewObjects_ReturnsObjectOnTop()
        {
            _stack.Push("a");
            _stack.Push("b");
            var result = _stack.Pop();

            Assert.That(result, Is.EqualTo("b"));
        }

        [Test]
        public void Pop_StackWithFewObjects_RemovesObjectOnTop()
        {
            _stack.Push("a");
            _stack.Push("b");
            _stack.Pop();

            Assert.That(_stack.Count, Is.EqualTo(1));
        }

        [Test]
        public void Peek_EmptyStack_ThrowsInvalidOperationException()
        {
            Assert.That(() => _stack.Peek(), Throws.InvalidOperationException);
        }

        [Test]
        public void Peek_StackWithFewObjects_ReturnsObjectOnTop()
        {
            _stack.Push("a");
            _stack.Push("b");
            var result = _stack.Peek();

            Assert.That(result, Is.EqualTo("b"));
        }

        [Test]
        public void Peek_StackWithFewObjects_DoesNotRemoveObjectOnTop()
        {
            _stack.Push("a");
            _stack.Push("b");
            _stack.Peek();

            Assert.That(_stack.Count, Is.EqualTo(2));
        }
    }
}