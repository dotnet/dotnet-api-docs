using System;
using System.Collections;

public class SamplesHashtable
{
    public static void Run()
    {
        // <Snippet2>
        Hashtable myCollection = [];
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
