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