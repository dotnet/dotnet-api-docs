using System;
using System.Collections;

public class SamplesQueue2
{
    public static void Run()
    {
        // <Snippet2>
        Queue myCollection = new();
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
