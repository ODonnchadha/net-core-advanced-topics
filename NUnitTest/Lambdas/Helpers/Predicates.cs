using Advanced.Lambdas;

namespace NUnitTest.Lambdas.Helpers
{
    public static class Predicates
    {
        public static bool IsTenDollarsOrLess(Book book) => book.Price <= 10;
    }
}
