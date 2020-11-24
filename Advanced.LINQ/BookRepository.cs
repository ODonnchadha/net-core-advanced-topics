using System.Collections.Generic;

namespace Advanced.LINQ
{
    public class BookRepository
    {
        public IEnumerable<Book> Get()
        {
            return new List<Book>
            {
                new Book { Title = "A", Price = 10 },
                new Book { Title = "B", Price = 40 },
                new Book { Title = "C", Price = 75 }
            };
        }
    }
}
