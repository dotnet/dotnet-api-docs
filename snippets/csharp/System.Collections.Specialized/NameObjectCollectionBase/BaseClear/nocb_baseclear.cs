// The following example uses BaseClear to remove all elements from a NameObjectCollectionBase.
// For an expanded version of this example, see the NameObjectCollectionBase class topic.

// <snippet1>
using System;
using System.Collections;
using System.Collections.Specialized;

public class MyCollection : NameObjectCollectionBase
{

    private DictionaryEntry _de = new();

    // Gets a key-and-value pair (DictionaryEntry) using an index.
    public DictionaryEntry this[int index]
    {
        get
        {
            _de.Key = this.BaseGetKey(index);
            _de.Value = this.BaseGet(index);
            return (_de);
        }
    }

    // Adds elements from an IDictionary into the new collection.
    public MyCollection(IDictionary d)
    {
        foreach (DictionaryEntry de in d)
        {
            this.BaseAdd((string)de.Key, de.Value);
        }
    }

    // Clears all the elements in the collection.
    public void Clear()
    {
        this.BaseClear();
    }
}

public class SamplesNameObjectCollectionBase
{

    public static void Main()
    {

        // Creates and initializes a new MyCollection instance.
        IDictionary d = new ListDictionary
      {
          { "red", "apple" },
          { "yellow", "banana" },
          { "green", "pear" }
      };
        MyCollection myCol = new(d);
        Console.WriteLine($"Initial state of the collection (Count = {myCol.Count}):");
        PrintKeysAndValues(myCol);

        // Removes all elements from the collection.
        myCol.Clear();
        Console.WriteLine($"After clearing the collection (Count = {myCol.Count}):");
        PrintKeysAndValues(myCol);
    }

    public static void PrintKeysAndValues(MyCollection myCol)
    {
        for (int i = 0; i < myCol.Count; i++)
        {
            Console.WriteLine($"[{i}] : {myCol[i].Key}, {myCol[i].Value}");
        }
    }
}


/*
This code produces the following output.

Initial state of the collection (Count = 3):
[0] : red, apple
[1] : yellow, banana
[2] : green, pear
After clearing the collection (Count = 0):

*/
// </snippet1>
