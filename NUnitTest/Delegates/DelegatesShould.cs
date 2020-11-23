using Advanced.Delegates;
using NUnit.Framework;

namespace NUnitTest.Delegates
{
    public class DelegatesShould
    {
        private string PATH = string.Empty;
        private PhotoProcessor.PhotoFilterHandler filterHandler;
        private PhotoFilters filters;
        private PhotoProcessor processor;

        [SetUp()]
        public void Setup()
        {
            this.filterHandler = null;

            this.filters = new PhotoFilters { };
            this.processor = new PhotoProcessor { };
        }

        [Test()]
        public void Test()
        {
            filterHandler += filters.ApplyBrightness;
            filterHandler += filters.ApplyContrast;

            processor.Process(PATH, filterHandler);
        }
    }
}
