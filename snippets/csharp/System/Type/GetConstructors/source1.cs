// <Snippet1>
using System;
using System.Reflection;

public class ConstructorSample1
{
    public ConstructorSample1() { }
    static ConstructorSample1() { }
    public ConstructorSample1(int i) { }
    public static void Run()
    {
        ConstructorInfo[] p = typeof(ConstructorSample1).GetConstructors();
        Console.WriteLine(p.Length);

        for (int i = 0; i < p.Length; i++)
        {
            Console.WriteLine(p[i].IsStatic);
        }
    }
}
// </Snippet1>
