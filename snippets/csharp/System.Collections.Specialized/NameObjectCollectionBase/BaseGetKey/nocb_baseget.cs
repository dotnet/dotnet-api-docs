// The following example uses BaseGetKey and BaseGet to get specific keys and values.
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

    // Adds elements from an IDictionary into the new collection.
    public MyCollection(IDictionary d)
    {
        foreach (DictionaryEntry de in d)
        {
            this.BaseAdd((string)de.Key, de.Value);
        }
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

        // Gets specific keys and values.
        Console.WriteLine($"The key at index 0 is {myCol[0].Key}.");
        Console.WriteLine($"The value at index 0 is {myCol[0].Value}.");
        Console.WriteLine($"The value associated with the key \"green\" is {myCol["green"]}.");
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
The key at index 0 is red.
The value at index 0 is apple.
The value associated with the key "green" is pear.

*/
// </snippet1>
