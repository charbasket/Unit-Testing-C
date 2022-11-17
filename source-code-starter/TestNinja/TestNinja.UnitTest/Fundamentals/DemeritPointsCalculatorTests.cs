using System;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTest.Fundamentals
{
    [TestFixture]
    public class DemeritPointsCalculatorTests
    {
        // All of this returns zero, it´s better to have one with multiple TestCases
        // [Test]
        // public void DemeritPointsCalculator_SpeedIsNegative_ThrowArgumentOutOfRangeException()
        // {
        // }
        //
        // [Test]
        // public void DemeritPointsCalculator_SpeedIsZero_ReturnZero()
        // {
        // }
        //
        // [Test]
        // public void DemeritPointsCalculator_SpeedIsLowerThanSpeedLimit_ReturnZero()
        // {
        // }
        //
        // [Test]
        // public void DemeritPointsCalculator_()
        // {
        // }

        [Test]
        [TestCase(-1)]
        [TestCase(301)]
        public void CalculateDemeritPoints_SpeedIsNegativeOrAboveSpeedLimit_ThrowArgumentOutOfRangeException(int speed)
        {
            var calculator = new DemeritPointsCalculator();

            Assert.That(() => calculator.CalculateDemeritPoints(speed),
                Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(15, 0)]
        [TestCase(65, 0)]
        [TestCase(66, 0)]
        [TestCase(70, 1)]
        [TestCase(76, 2)]
        public void CalculateDemeritPoints_WhenCalled_ReturnsDemeritPoints(int speed, int expectedResult)
        {
            var calculator = new DemeritPointsCalculator();
            var result = calculator.CalculateDemeritPoints(speed);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}