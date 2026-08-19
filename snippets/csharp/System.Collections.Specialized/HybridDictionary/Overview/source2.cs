using System;
using System.Collections;
using System.Collections.Specialized;

public class HybridDictSample
{
    public static void Run()
    {
        // Creates and initializes a new HybridDictionary.
        HybridDictionary myHybridDictionary = [];

        // <snippet2>
        foreach (DictionaryEntry de in myHybridDictionary)
        {
            //...
        }
        // </snippet2>

        // <snippet3>
        HybridDictionary myCollection = [];
        lock (myCollection.SyncRoot)
        {
            foreach (object item in myCollection)
            {
                // Insert your code here.
            }
        }
        // </snippet3>
    }
}
