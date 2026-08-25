using System;
using System.Collections;
using System.Collections.Specialized;

public class OrderedDictionarySyncRootSample
{
    public static void Run()
    {
        OrderedDictionary myOrderedDictionary = [];
        // <Snippet06>
        foreach (DictionaryEntry de in myOrderedDictionary)
        {
            //...
        }
        // </Snippet06>
    }
}
