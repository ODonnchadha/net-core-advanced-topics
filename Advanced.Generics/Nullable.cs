namespace Advanced.Generics
{
    /// <summary>
    /// We 'box' to store the value and 'unbox' within the GetValueOrDefault() method.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Nullable<T> where T : struct
    {
        private object _value;
        public Nullable() { }
        public Nullable(T value) => _value = value;
        public bool HasValue() => _value != null;

        /// <summary>
        /// Note the 'default' keyword.
        /// </summary>
        /// <returns></returns>
        public T GetValueOrDefault()
        {
            if (HasValue())
            {
                return (T)_value;
            }
                
            return default(T);
        }
    }
}
