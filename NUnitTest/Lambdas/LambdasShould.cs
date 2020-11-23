using Advanced.Lambdas;
using NUnit.Framework;
using System.Collections.Generic;
using NUnitTest.Lambdas.Helpers;

namespace NUnitTest.Delegates
{
    public class LambdasShould
    {
        List<Book> books;

        [SetUp()]
        public void Setup()
        {
            this.books = new BookRepository().Get();
        }

        [Test()]
        public void Get()
        {
            var cheapBooks = books.FindAll(Predicates.IsTenDollarsOrLess);

            Assert.IsNotNull(cheapBooks);
            Assert.AreEqual(cheapBooks.Count, 1);
        }

        [Test()]
        public void GetWithLambda()
        {
            var cheapBooks = books.FindAll(b => b.Price <= 10);

            Assert.IsNotNull(cheapBooks);
            Assert.AreEqual(cheapBooks.Count, 1);
        }
    }
}
