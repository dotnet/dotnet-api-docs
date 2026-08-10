using System;

public class WriteLineObjectExample
{
    public static void Run()
    {
        // <Snippet3>
        object[] values = { true, 12.632, 17908, "stringValue",
                                 'a', 16907.32m };
        foreach (object value in values)
            Console.WriteLine(value);

        // The example displays the following output:
        //    True
        //    12.632
        //    17908
        //    stringValue
        //    a
        //    16907.32
        // </Snippet3>
    }
}
