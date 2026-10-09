// <Snippet1>
using System;

public abstract class AbstractClass
{ }

public class DerivedClass : AbstractClass
{ }

public sealed class SingleClass
{ }

public interface ITypeInfo
{
    string GetName();
}

public class ImplementingClass : ITypeInfo
{
    public string GetName() => this.GetType().FullName;
}

delegate string InputOutput(string inp);

public class Example
{
    public static void Main()
    {
        Type[] types = [typeof(AbstractClass),
                        typeof(DerivedClass),
                        typeof(ITypeInfo),
                        typeof(SingleClass),
                        typeof(ImplementingClass),
                        typeof(InputOutput)];
        foreach (var type in types)
            Console.WriteLine($"{type.Name} is abstract: {type.IsAbstract}");
    }
}
// The example displays the following output:
//       AbstractClass is abstract: True
//       DerivedClass is abstract: False
//       ITypeInfo is abstract: True
//       SingleClass is abstract: False
//       ImplementingClass is abstract: False
//       InputOutput is abstract: False
// </Snippet1>
