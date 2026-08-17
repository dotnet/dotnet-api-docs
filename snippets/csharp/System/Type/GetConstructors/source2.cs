// <Snippet2>
using System;
using System.Reflection;

public class ConstructorSample2
{
    public ConstructorSample2() { }
    static ConstructorSample2() { }
    public ConstructorSample2(int i) { }
    public static void Run()
    {
        ConstructorInfo[] p = typeof(ConstructorSample2).GetConstructors(
           BindingFlags.Public | BindingFlags.Static |
           BindingFlags.NonPublic | BindingFlags.Instance);
        Console.WriteLine(p.Length);

        for (int i = 0; i < p.Length; i++)
        {
            Console.WriteLine(p[i].IsStatic);
        }
    }
}
// </Snippet2>
