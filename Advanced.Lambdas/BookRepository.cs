using System.Collections.Generic;

namespace Advanced.Lambdas
{
    public class BookRepository
    {
        public List<Book> Get()
        {
            return new List<Book>
            {
                new Book { Title = "A", Price = 10 },
                new Book { Title = "B", Price = 40 }
            };
        }
    }
}
