// The following example shows how to implement and use the NameObjectCollectionBase class.

// <snippet1>
using System;
using System.Collections;
using System.Collections.Specialized;

public class MyCollection : NameObjectCollectionBase
{
    // Creates an empty collection.
    public MyCollection()
    {
    }

    // Adds elements from an IDictionary into the new collection.
    public MyCollection(IDictionary d, bool bReadOnly)
    {
        foreach (DictionaryEntry de in d)
        {
            this.BaseAdd((string)de.Key, de.Value);
        }
        this.IsReadOnly = bReadOnly;
    }

    // Gets a key-and-value pair (DictionaryEntry) using an index.
    public DictionaryEntry this[int index]
    {
        get
        {
            return (new DictionaryEntry(
                this.BaseGetKey(index), this.BaseGet(index)));
        }
    }

    // Gets or sets the value associated with the specified key.
    public object this[string key]
    {
        get
        {
            return (this.BaseGet(key));
        }
        set
        {
            this.BaseSet(key, value);
        }
    }

    // Gets a String array that contains all the keys in the collection.
    public string[] AllKeys
    {
        get
        {
            return (this.BaseGetAllKeys());
        }
    }

    // Gets an Object array that contains all the values in the collection.
    public Array AllValues
    {
        get
        {
            return (this.BaseGetAllValues());
        }
    }

    // Gets a String array that contains all the values in the collection.
    public string[] AllStringValues
    {
        get
        {
            return ((string[])this.BaseGetAllValues(typeof(string)));
        }
    }

    // Gets a value indicating if the collection contains keys that are not null.
    public bool HasKeys
    {
        get
        {
            return (this.BaseHasKeys());
        }
    }

    // Adds an entry to the collection.
    public void Add(string key, object value)
    {
        this.BaseAdd(key, value);
    }

    // Removes an entry with the specified key from the collection.
    public void Remove(string key)
    {
        this.BaseRemove(key);
    }

    // Removes an entry in the specified index from the collection.
    public void Remove(int index)
    {
        this.BaseRemoveAt(index);
    }

    // Clears all the elements in the collection.
    public void Clear()
    {
        this.BaseClear();
    }
}

public class SamplesNameObjectCollectionBase
{

    public static void Run()
    {

        // Creates and initializes a new MyCollection that is read-only.
        IDictionary d = new ListDictionary
      {
          { "red", "apple" },
          { "yellow", "banana" },
          { "green", "pear" }
      };
        MyCollection myROCol = new(d, true);

        // Tries to add a new item.
        try
        {
            myROCol.Add("blue", "sky");
        }
        catch (NotSupportedException e)
        {
            Console.WriteLine(e);
        }

        // Displays the keys and values of the MyCollection.
        Console.WriteLine("Read-Only Collection:");
        PrintKeysAndValues(myROCol);

        // Creates and initializes an empty MyCollection that is writable.
        MyCollection myRWCol = new()
      {
          // Adds new items to the collection.
          { "purple", "grape" },
          { "orange", "tangerine" },
          { "black", "berries" }
      };
        Console.WriteLine("Writable Collection (after adding values):");
        PrintKeysAndValues(myRWCol);

        // Changes the value of one element.
        myRWCol["orange"] = "grapefruit";
        Console.WriteLine("Writable Collection (after changing one value):");
        PrintKeysAndValues(myRWCol);

        // Removes one item from the collection.
        myRWCol.Remove("black");
        Console.WriteLine("Writable Collection (after removing one value):");
        PrintKeysAndValues(myRWCol);

        // Removes all elements from the collection.
        myRWCol.Clear();
        Console.WriteLine("Writable Collection (after clearing the collection):");
        PrintKeysAndValues(myRWCol);
    }

    // Prints the indexes, keys, and values.
    public static void PrintKeysAndValues(MyCollection myCol)
    {
        for (int i = 0; i < myCol.Count; i++)
        {
            Console.WriteLine($"[{i}] : {myCol[i].Key}, {myCol[i].Value}");
        }
    }

    // Prints the keys and values using AllKeys.
    public static void PrintKeysAndValues2(MyCollection myCol)
    {
        foreach (string s in myCol.AllKeys)
        {
            Console.WriteLine($"{s}, {myCol[s]}");
        }
    }
}


/*
This code produces the following output.

System.NotSupportedException: Collection is read-only.
   at System.Collections.Specialized.NameObjectCollectionBase.BaseAdd(String name, Object value)
   at SamplesNameObjectCollectionBase.Run()
Read-Only Collection:
[0] : red, apple
[1] : yellow, banana
[2] : green, pear
Writable Collection (after adding values):
[0] : purple, grape
[1] : orange, tangerine
[2] : black, berries
Writable Collection (after changing one value):
[0] : purple, grape
[1] : orange, grapefruit
[2] : black, berries
Writable Collection (after removing one value):
[0] : purple, grape
[1] : orange, grapefruit
Writable Collection (after clearing the collection):

*/
// </snippet1>
