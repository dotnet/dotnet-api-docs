using System;
using System.Collections.Generic;

public class ListSortExample
{
    public static void Run()
    {
        // <Snippet2>
        ReadOnlySpan<string> names = [ "Samuel", "Dakota", "Koani", "Saya", "Vanya", "Jody",
                         "Yiska", "Yuma", "Jody", "Nikita" ];
        List<string> nameList = [];
        nameList.AddRange(names);
        Console.WriteLine("List in unsorted order: ");
        foreach (string name in nameList)
            Console.Write("   {0}", name);

        Console.WriteLine(Environment.NewLine);

        nameList.Sort();
        Console.WriteLine("List in sorted order: ");
        foreach (string name in nameList)
            Console.Write("   {0}", name);

        Console.WriteLine();

        // The example displays the following output:
        //    List in unsorted order:
        //       Samuel   Dakota   Koani   Saya   Vanya   Jody   Yiska   Yuma   Jody   Nikita
        //
        //    List in sorted order:
        //       Dakota   Jody   Jody   Koani   Nikita   Samuel   Saya   Vanya   Yiska   Yuma

        // </Snippet2>
    }
}
