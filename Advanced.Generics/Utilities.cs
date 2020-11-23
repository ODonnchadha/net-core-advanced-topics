using System;

namespace Advanced.Generics
{
    public class Utilities
    {
        public T Max<T>(T a, T b) where T : IComparable => a.CompareTo(b) > 0 ? a : b;
    }
}
