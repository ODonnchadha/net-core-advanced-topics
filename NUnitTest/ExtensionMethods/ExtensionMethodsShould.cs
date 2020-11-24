using Advanced.ExtensionMethods;
using NUnit.Framework;

namespace NUnitTest.ExtensionMethods
{
    public class ExtensionMethodsShould
    {
        private string words;

        [SetUp()]
        public void Setup()
        {
            this.words = "In my younger and more vulnerable years my father gave me some advice that I've been turning over in my mind ever since.";
        }

        [Test()]
        public void Shorten()
        {
            Assert.AreEqual(words.Shorten(7), "In my younger and more vulnerable years...");
        }
    }
}
