using System;
using System.Collections;

public class SamplesStack2
{
    public static void Run()
    {
        // <Snippet2>
        Stack myCollection = new();

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
