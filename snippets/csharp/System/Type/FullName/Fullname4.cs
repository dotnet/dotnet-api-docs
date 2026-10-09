// <Snippet4>
using System;
using System.Reflection;

public class GenericType1<T>
{
    public void Display(T[] elements)
    { }

    public void HandleT(T obj)
    { }

    public bool ChangeValue(ref T arg) => true;
}

public class FullName4Example
{
    public static void Run()
    {
        Type t = typeof(GenericType1<>);
        Console.WriteLine($"Type Name: {t.FullName}");
        MethodInfo[] methods = t.GetMethods(BindingFlags.Instance |
                                            BindingFlags.DeclaredOnly |
                                            BindingFlags.Public);
        foreach (var method in methods)
        {
            Console.WriteLine($"   Method: {method.Name}");
            // Get method parameters.
            ParameterInfo param = method.GetParameters()[0];
            Type paramType = param.ParameterType;
            if (method.Name == "HandleT")
                paramType = paramType.MakePointerType();
            Console.WriteLine($"      Parameter: {paramType.FullName ??
                              paramType + " (unassigned)"}");
        }
    }
}
// The example displays the following output:
//       Type Name: GenericType1`1
//          Method: Display
//             Parameter: T[] (unassigned))
//          Method: HandleT
//             Parameter: T* (unassigned)
//          Method: ChangeValue
//             Parameter: T& (unassigned)
// </Snippet4>
