using System;
using System.Collections;

public class SamplesSortedList
{
    public static void Run()
    {
        // Creates and initializes a new SortedList.
        SortedList mySortedList = new()
        {
            { "Third", "!" },
            { "Second", "World" },
            { "First", "Hello" }
        };

        // <Snippet2>
        foreach (DictionaryEntry de in mySortedList)
        {
            //...
        }
        // </Snippet2>
    }
}
