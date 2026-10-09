using System;
using System.Collections;

public class SynchronizedShortStringDictionary : DictionaryBase
{

    public string this[string key]
    {
        get => ((string)Dictionary[key]); set => Dictionary[key] = value;
    }

    public ICollection Keys => (Dictionary.Keys);

    public ICollection Values => (Dictionary.Values);

    public void Add(string key, string value) => Dictionary.Add(key, value);

    public bool Contains(string key) => (Dictionary.Contains(key));

    public void Remove(string key) => Dictionary.Remove(key);

    protected override void OnInsert(object key, object value)
    {
        if (key.GetType() != typeof(string))
        {
            throw new ArgumentException("key must be of type string.", "key");
        }
        else
        {
            string strKey = (string)key;
            if (strKey.Length > 5)
            {
                throw new ArgumentException("key must be no more than 5 characters in length.", "key");
            }
        }

        if (value.GetType() != typeof(string))
        {
            throw new ArgumentException("value must be of type string.", "value");
        }
        else
        {
            string strValue = (string)value;
            if (strValue.Length > 5)
            {
                throw new ArgumentException("value must be no more than 5 characters in length.", "value");
            }
        }
    }

    protected override void OnRemove(object key, object value)
    {
        if (key.GetType() != typeof(string))
        {
            throw new ArgumentException("key must be of type string.", "key");
        }
        else
        {
            string strKey = (string)key;
            if (strKey.Length > 5)
            {
                throw new ArgumentException("key must be no more than 5 characters in length.", "key");
            }
        }
    }

    protected override void OnSet(object key, object oldValue, object newValue)
    {
        if (key.GetType() != typeof(string))
        {
            throw new ArgumentException("key must be of type string.", "key");
        }
        else
        {
            string strKey = (string)key;
            if (strKey.Length > 5)
            {
                throw new ArgumentException("key must be no more than 5 characters in length.", "key");
            }
        }

        if (newValue.GetType() != typeof(string))
        {
            throw new ArgumentException("newValue must be of type string.", "newValue");
        }
        else
        {
            string strValue = (string)newValue;
            if (strValue.Length > 5)
            {
                throw new ArgumentException("newValue must be no more than 5 characters in length.", "newValue");
            }
        }
    }

    protected override void OnValidate(object key, object value)
    {
        if (key.GetType() != typeof(string))
        {
            throw new ArgumentException("key must be of type string.", "key");
        }
        else
        {
            string strKey = (string)key;
            if (strKey.Length > 5)
            {
                throw new ArgumentException("key must be no more than 5 characters in length.", "key");
            }
        }

        if (value.GetType() != typeof(string))
        {
            throw new ArgumentException("value must be of type string.", "value");
        }
        else
        {
            string strValue = (string)value;
            if (strValue.Length > 5)
            {
                throw new ArgumentException("value must be no more than 5 characters in length.", "value");
            }
        }
    }
}

public class SamplesSynchronizedDictionaryBase
{
    public static void Run()
    {
        DictionaryBase myDictionary = new SynchronizedShortStringDictionary();

        // <Snippet2>
        foreach (DictionaryEntry de in myDictionary)
        {
            //...
        }
        // </Snippet2>

        // <Snippet3>
        ICollection myCollection = new SynchronizedShortStringDictionary();
        lock (myCollection.SyncRoot)
        {
            foreach (object item in myCollection)
            {
                // Insert your code here.
            }
        }
        // </Snippet3>
    }
}
