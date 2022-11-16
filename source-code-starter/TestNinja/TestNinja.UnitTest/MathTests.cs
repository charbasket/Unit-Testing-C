using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTest
{
    [TestFixture]
    public class MathTests
    {
        // Not optimal to reuse instances, so we create it inside SetUp
        private Math _math;
        
        // Setup: it get´s called before each test
        // We can call this method however we like
        [SetUp]
        public void SetUp()
        {
            _math = new Math();
        }
        
        // TearDown: it get`s called after each test
        
        
        
        [Test]
        public void Add_WhenCalled_ReturnSumOfArguments()
        {
            
            var result = _math.Add(1, 2);
            
            Assert.That(result==3);
        }

        [Test]
        public void Max_FirstArgumentIsGreater_ReturnTheFirstArgument()
        {
            var result = _math.Max(2, 1);
            
            Assert.That(result == 2);
        }
        [Test]
        public void Max_SecondArgumentIsGreater_ReturnTheSecondArgument()
        {
            var result = _math.Max(1, 2);
            
            Assert.That(result == 2);
        }
        
        [Test]
        public void Max_ArgumentsAreEqual_ReturnTheSameArgument()
        {
            var result = _math.Max(1, 1);
            
            Assert.That(result == 1);
        }
        
    }
}