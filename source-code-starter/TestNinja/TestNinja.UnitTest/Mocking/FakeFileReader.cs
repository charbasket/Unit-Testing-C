using TestNinja.Mocking;

namespace TestNinja.UnitTest.Mocking
{
    // We can create fake objects with a framework
    public class FakeFileReader : IFileReader
    {
        public string Read(string path)
        {
            // if video is null
            return "";
        }
    }
}