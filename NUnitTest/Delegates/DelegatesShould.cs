using Advanced.Delegates;
using NUnit.Framework;
using NUnitTest.Delegates.Helpers;

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
        public void ApplyFilters()
        {
            filterHandler += filters.ApplyBrightness;
            filterHandler += filters.ApplyContrast;

            processor.Process(PATH, filterHandler);
        }

        [Test()]
        public void ApplyClientFilters()
        {
            ClientPhotoFilterHandler handler = new ClientPhotoFilterHandler { };

            filterHandler += filters.ApplyContrast;
            filterHandler += handler.RemoveRedEyeFilter;

            processor.Process(PATH, filterHandler);
        }
    }
}
