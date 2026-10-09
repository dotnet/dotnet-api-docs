using System;
using System.Collections;
using System.Collections.Specialized;

public class SamplesStringDictionarySyncRoot
{
    public static void Run()
    {
        // <Snippet2>
        StringDictionary myCollection = [];
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
