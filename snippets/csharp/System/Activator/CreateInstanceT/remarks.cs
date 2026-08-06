

class Dummy
{
    // <Snippet1>
    public static T Factory<T>() where T : new() => new T();
    // </Snippet1>
}

class ProgStubClass
{
    public static void Main() { }
}
