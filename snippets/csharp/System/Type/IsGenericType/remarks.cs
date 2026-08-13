


// <Snippet2>
public class RemarksBase<T, U> { }

public class RemarksDerived<V> : RemarksBase<string, V>
{
    public RemarksG<RemarksDerived<V>> F;

    public class Nested { }
}

public class RemarksG<T> { }
// </Snippet2>

class IsGenericTypeRemarksExample
{
    public static void Run()
    {
    }
}
