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
        
        // All the test do the same but with different values for a,b
        // It´s better to create a test with parameters
        [Test]
        // We can pass the values of the parameters via TestCase
        [TestCase(2,1,2)]
        [TestCase(1,2,2)]
        [TestCase(1,1,1)]
        public void Max_WhenCalled_ReturnTheGreaterArgument(int a, int b, int expectedResult)
        {
            var result = _math.Max(a, b);
            
            Assert.That(result==expectedResult);
        }
        
        [Test]
        // We can ignore test and describe the reason
        [Ignore("Because we already test this in the previous test")]
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