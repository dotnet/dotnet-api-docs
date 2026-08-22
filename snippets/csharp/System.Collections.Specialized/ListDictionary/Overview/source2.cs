using System;
using System.Collections;
using System.Collections.Specialized;

public class SamplesListDictionarySyncRoot
{
    public static void Run()
    {
        // <Snippet2>
        ListDictionary myCollection = [];
        lock (myCollection.SyncRoot)
        {
            foreach (object item in myCollection)
            {
                // Insert your code here.
            }
        }
        // </Snippet2>
    }

    public static void Dummy()
    {
        ListDictionary myListDictionary = [];
        // <Snippet3>
        foreach (DictionaryEntry de in myListDictionary)
        {
            //...
        }
        // </Snippet3>
    }
}
