using System;
using System.Collections;
using System.Collections.Specialized;

public class SamplesStringCollectionSyncRoot
{
    public static void Run()
    {
        // <Snippet2>
        StringCollection myCollection = [];
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
