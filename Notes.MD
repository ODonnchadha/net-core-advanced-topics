# Udemy couse entitled "C# Advanced Topics Prepare for Technical Interviews."
- Mosh Hamedani
- <https://www.youtube.com/user/programmingwithmosh>

- Generics:
  - Boxing and unboxing has a performance cost. So does casting. 
  - Generics have angle-bracket parameters. <T> or <TKey, TValue>.
  - In practical terms, you will be using generics more than creating them.
  ```csharp
    public class Utilities
    {
      public T Max<T>(T a, T b) where T : IComparable => a.CompareTo(b) > 0 ? a : b;
    }
  ```
  ```csharp
    public class Utilities<T> where T : IComparable
    {
      public T Max(T a, T b) => a.CompareTo(b) > 0 ? a : b;
    }
  ```
  - Constraints:
    1. where T : IComparable
    2. where T : Product
    3. where T : struct // value type
    4. where T : class  // reference type
    5. where T : new()

  - We box to store the value and unbox within the GetValueOrDefault() method.
  - Note the defult keyword.
  ```csharp
    public class Nullable<T> where T : struct
    {
      private object _value;
      public Nullable() {}
      public Nullable(T value) => _value = value;
      public HasValue()
      {
        get { return _value != null ; }
      }
      public T GetValueOrDefault()
      {
        if (HasValue()) return (T)_value;
        return default(T);
      }
    }
  ```
  - With where T : new():
  ```csharp
    public class Utilities<T> where T : IComparable, new()
    {
      public void Process() => var obj = new T();
    }
  ```

- DELEGATES:
  - 
