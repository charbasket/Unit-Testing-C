using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTest.Fundamentals
{
    [TestFixture]
    public class HtmlFormatterTests
    {
        [Test]
        public void FormatAsBold_WhenCalled_ShouldEncloseTheStringWithStringElement()
        {
            var formatter = new HtmlFormatter();
            var result = formatter.FormatAsBold("abc");

            // Specific:
            // We can ignore caps with .IgnoreCase
            Assert.That(result, Is.EqualTo("<strong>abc</strong>").IgnoreCase);

            // More general:
            Assert.That(result, Does.StartWith("<strong>"));
            Assert.That(result, Does.EndWith("</strong>"));
            Assert.That(result, Does.Contain("abc"));
        }
    }
}