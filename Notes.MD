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
  - An object that knows how to call a method or a group of methods.
  - A reference to a function.
  - We can call methods directly. Why is this needed?
  - For designing extensible and flexible applications. e.g.: a framework.

  - This is not extensible. Every new filter results in a change or two. So, delegates or interfaces.
  ```csharp
      var filters = new PhotoFilters { };
      filters.ApplyBrightness(photo);
      filters.ApplyContrast(photo);
      filters.Resize(photo);
  ```

  - PhotoFilterHandler is the delegated responsibilitity of the client to apply the filters desired.
  - Delegate: MulticlassDelegate. Ultimately there is a method and a target. Target is the class that 'holds' that method.
  - in .NET, there are two delegates that come standard: Action<> and Func<>.
  - Func<> points to a method that returns a value. Action<> points to a method that has a void return.
  - So:
  ```csharp
    public class PhotoProcessor
    {
      public void Process(string path, Action<Photo> filterHandler)
      {
        var photo = Photo.Load(path);
        filterHandler(photo);
        photo.Save();
      }
    }
  ```
  - Interfaces or delegates?
  - Use a delegate when:
    1. An eventing pattern is used.
    2. The caller doesn't need to access other properties or methods on the object implementing the method.

- Lambda Expressions:
  - An anonymous method.
    1. No access modifier.
    2. No name.
    3. No return statement.
  - Why do we use them? For convience. 
  ```csharp
    static int Square(int number) => number * number;
  ```
  - Lambda:
  ```csharp
    Func<int, int> square = number => number * number;
  ```
  - [Arguments] => (Lambda Operation) [Expression]
  - e.g.: number => number * number;
  - Scope:
  ```csharp
    static void Main(string[] args)
    {
      const int FACTOR = 5;
      Func<int, int> multiplier = n => n * FACTOR;

      int result = multiplier(10);
    }
  ```
  
- Events:
  - A mechanism for communication between objects.
  - Used in building loosely coupled applications.
  - Helps with extending applications.
  - Delegates:
    - Agreement/Contract between Publisher and Subscriber.
    - Determines the signature of the event handler method in Subscriber.

  - Three steps involved:
  1. Define a delegate. The contract /agreement between the publisher and trhe subscriber.
  2. Define an event beased upon the delegate.
  3. Raise/publish the event.
  ```csharp
    public class VideoEncoder
    {
        public delegate void VideoEncodedEventHandler(object source, EventArgs args);
        public event VideoEncodedEventHandler VideoEncoded;
        public void Encode(Video video) => OnVideoEncoded();
        protected virtual void OnVideoEncoded() => VideoEncoded?.Invoke(this, EventArgs.Empty);
    }
  ```

  - EventHandler and EventHandler<TEventArgs>
  ```csharp
    public class VideoEncoder
    {
        // public event EventHandler<VideoEncodedEventArgs> VideoEncoded;
        public event EventHandler<> VideoEncoded;
        public void Encode(Video video) => OnVideoEncoded();
        protected virtual void OnVideoEncoded() => VideoEncoded?.Invoke(this, EventArgs.Empty);
    }
  ```

- Extension Methods:
  - Unable to inherit from a sealed class. Use only when you have to.

- LINQ:
  - Stands for: *L*amguage *In*tegrated *Q*uery.
  - Provides one the capability to query objects.
  - You can Query:
    1. Onbjects in memory. e.g.: Collections (LINQ to Objects.)
    2. Databases. (LINQ to Entities.)
    3. XML. (LINQ to XML.)
    4. ADO.NET Data Sets. (LINQ to Data Sets.)
  
  - LINQ Query Operators : IOrderedEnumerable<T>
    - from b in books where b.Price < 10 orderby b.title select b.Title;
  - LINQ Extension Methods
    - .Where(b => b.Price < 10).OrderBy(b => b.Title).Select(b => b.Title);
  - Query methods translate to extension methods.

  - .Single(b => b.Title == "A"). Throws hard when one and only one object is returned.
  - .SingleOrDefault() will return null.
  - .First(b => b.Title == "A")
  - .FirstOrDefault() will return null.
  - .Last()
  - .LastOrDefault()
  - .Skip(2).Take(3): "Skip two objects and take three."

  - Aggregate functions:
    - .Count()
    - Highest price: .Max(b => b.Price)
    - .Min()
    - .Sum()
  
- Nullable Types:
  - Value types cannot be null.
  - We'd like to cator for NULL values. e.g.: Working with a database. Birthday can be optional.
  ```csharp
    // Datetime birthday = null;
    Nullable<DateTime> birthday = null;
    DateTime? birthday = null;
  ``
  - e.g.: With DateTime? date = null;
  1. GetValueOrDefault()
    - 1/01/0001 12:00:00 AM
  2. HasValue
    - False
  3. Value
    - InvalidOperationException.
  - NOTE: Try not to access Value directory.
  - Null Coalescing operator:
  ```csharp
    DateTime dt = date ?? DateTime.Today;
  ```
  
- Dynamic:
  - Programming languages:
  1. Statically-typed languages. C#. Java.
  2. Dynamically-typed languages: Ruby. JavaScript.
  - Resolution of types, members, properties, and methods is peformed at compile-time for static. Versus run-time.
  - Benefits:
  1. Static languages: early feedback at compile-time.
  2. Dynamic languages: easier and faster to code.
  - C# History:
  - Started as a static language.
  - .NET 4 added the dynamic capability to improve interoperability with:
  1. COM. e.g.: Office applications.
  2. Dynamic languages. e.g.: IronPython.
  - With reflection:
  ```csharp
    object obt = "X";
    // obj.GetHashCode();
    var methodInfo = obj.GetType().GetMethod("GetHashCode");
    methodInfo.Invoke(null, null);
  ```
  - With dynamic:
  ```csharp
    dynamic excel = "X";
    excel.Foo();
  ```
  - CLR: Common language runtime. From IL (Intermediate language) to machine code. 
  - DLR was added. Dynamic language runtime.
  - Runtime type. dynamic (string), dynamic (int). Watch out for RuntimeBinderException at runtime.
  - Dynamic types need far more unit testing.

- Exception Handling:
  - Stack trace: Sequence of methods called until the exception is thrown.
  - Use finally for manual clean-up. Unmanaged resources vis the IDosposable() interface.
  - Custom exceptions:

- Asynchronous Programming with Async/Await:
  - Synchronous programming execution:
    - Program is executed line by line, one at a time.
    - When a function is called, program execution has to wait until the function returns.
  - Asynchronous programming execution:
    - When a function is called, program execution continues to the next line without waiting for the function to complete.
      - Callback.
    - Asynchroous programming improves responsiveness. e.g.: Windows media player or Web browser.
    - When do we use asynchronous programming?
      - Accessing the Web. Working with files and databases. Working with images.
    - How?
      - Traditional approaches: Multithreading and callbacks.
      - New approach since .NET 4.5: Async/await. 
      - Use "Async" in the naming convention for each Task<T>.
      - "await" This operation may be costly and take it bit of time. So we return control.
      - And the runtime is in charge of executing the method. With an under-the-hood callback.
      - Task object represents that state of an asynchronous operation.

- What's next?
  - Additional tips:
  - Additional resources: Algorithms. Data structures. Object-oriented programming. Clean coding. Refactoring.