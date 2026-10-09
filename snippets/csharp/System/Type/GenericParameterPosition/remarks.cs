

// <Snippet1>
public class B<T, U> { }
public class A<V>
{
    public B<V, X> GetSomething<X>() => new B<V, X>();
}
// </Snippet1>

class ProgStubClass
{
    public static void Main() { }
}
