# Udemy couse entitled "C# Advanced Topics Prepare for Technical Interviews."
- Mosh Hamedani
- <https://www.youtube.com/user/programmingwithmosh>

- Generics:
  - Boxing and unboxing has a performance cost. So does casting. 
  - Generics have angle-bracket parameters. <T> or <TKey, TValue>.
  - In practical terms, you will be using generics more than creating them.
  ```csharp
    public class Utilities<T> where T : IComparable
    {
      public T Max(T a, T b) => a.CompareTo(b) > 0 ? a : b;
    }
  ```

  - Constraints:
    1. where T : IComparable
    2. where T : [Strongly-typed class]
    3. where T : struct
    4. where T : class
    5. where T : new()

  - With where T : new():
  ```csharp
    public class Utilities<T> where T : IComparable, new()
    {
      public void DoSomething() => var obj = new T();
    }
  ```

- Delegates:
  - 