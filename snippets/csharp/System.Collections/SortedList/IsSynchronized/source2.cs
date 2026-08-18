using System;
using System.Collections;

public class SamplesSortedList2
{
    public static void Run()
    {
        // <Snippet2>
        SortedList myCollection = [];
        lock (myCollection.SyncRoot)
        {
            foreach (object item in myCollection)
            {
                // Insert your code here.
            }
        }
        // </Snippet2>
    }
}
