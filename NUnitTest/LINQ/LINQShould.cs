using Advanced.LINQ;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace NUnitTest.LINQ
{
    public class LINQShould
    {
        IEnumerable<Book> books;

        [SetUp()]
        public void Setup()
        {
            this.books = new BookRepository().Get();
        }

        [Test()]
        public void Get()
        {
            var inexpensive = books.Where(b => b.Price <= 40).OrderBy(b => b.Title);

            Assert.IsNotNull(inexpensive);
            Assert.AreEqual(inexpensive.ToList().Count, 2);
            Assert.AreEqual(inexpensive.ToList()[0].Title, "A");
        }

        [Test()]
        public void GetWithStringConversion()
        {
            var inexpensive = books.Where(b => b.Price <= 40).OrderByDescending(b => b.Title).Select(b => b.Title);

            Assert.IsNotNull(inexpensive);
            Assert.AreEqual(inexpensive.ToList().Count, 2);
            Assert.AreEqual(inexpensive.ToList()[0], "B");
            Assert.AreEqual(inexpensive.ToList()[1], "A");
        }
    }
}
