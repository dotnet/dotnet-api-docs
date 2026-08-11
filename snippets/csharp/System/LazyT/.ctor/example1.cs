//<SnippetAll>
using System;
using System.Threading;
using LargeObject = LargeObjectCtorExample2;

class LazyCtorExample2
{
    static Lazy<LargeObject> lazyLargeObject = null;

    public static void Run()
    {
        // The lazy initializer is created here. LargeObject is not created until the
        // ThreadProc method executes.
        //<SnippetNewLazy>
        lazyLargeObject = new Lazy<LargeObject>(false);

        // The following lines show how to use other constructors to achieve exactly the
        // same result as the previous line:
        //lazyLargeObject = new Lazy<LargeObject>(LazyThreadSafetyMode.None);
        //</SnippetNewLazy>

        Console.WriteLine(
            "\r\nLargeObject is not created until you access the Value property of the lazy" +
            "\r\ninitializer. Press Enter to create LargeObject.");
        Console.ReadLine();

        //<SnippetValueProp>
        LargeObject large = lazyLargeObject.Value;
        //</SnippetValueProp>

        large.Data[11] = 89;

        Console.WriteLine("\r\nPress Enter to end the program");
        Console.ReadLine();
    }
}

class LargeObjectCtorExample2
{
    public LargeObjectCtorExample2() => Console.WriteLine($"LargeObject was created on thread id {Thread.CurrentThread.ManagedThreadId}.");
    public long[] Data = new long[100000000];
}

/* This example produces output similar to the following:

LargeObject is not created until you access the Value property of the lazy
initializer. Press Enter to create LargeObject.

LargeObject was created on thread id 1.

Press Enter to end the program
 */
//</SnippetAll>
