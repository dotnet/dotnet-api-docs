using System;
using System.Collections;

public class SamplesArrayList2
{
    public static void Run()
    {
        // <Snippet2>
        ArrayList myCollection = [];

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
