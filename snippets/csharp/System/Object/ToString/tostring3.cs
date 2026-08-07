// <Snippet3>
using System;

public class Object2
{
    private object value;

    public Object2(object value) => this.value = value;

    public override string ToString() => base.ToString() + ": " + value.ToString();
}

public class Example6
{
    public static void Main()
    {
        Object2 obj2 = new('a');
        Console.WriteLine(obj2.ToString());
    }
}
// The example displays the following output:
//       Object2: a
// </Snippet3>
