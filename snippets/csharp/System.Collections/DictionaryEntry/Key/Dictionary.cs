//Types:System.Collections.DictionaryEntry
//Types:System.Collections.IDictionary
//Types:System.Collections.IDictionaryEnumerator
//<snippet1>
using System;
using System.Collections;

//<snippet2>
// This class implements a simple dictionary using an array of DictionaryEntry objects (key/value pairs).
public class SimpleDictionary : IDictionary
{
    // The array of items.
    private DictionaryEntry[] items;

    // Construct the SimpleDictionary with the desired number of items.
    // The number of items cannot change for the life time of this SimpleDictionary.
    public SimpleDictionary(int numItems) => items = new DictionaryEntry[numItems];

    #region IDictionary Members
    //<snippet4>
    public bool IsReadOnly => false;
    //</snippet4>
    //<snippet5>	
    public bool Contains(object key)
    {
        int index;
        return TryGetIndexOfKey(key, out index);
    }
    //</snippet5>
    //<snippet6>		
    public bool IsFixedSize => false;
    //</snippet6>
    //<snippet7>	
    public void Remove(object key)
    {
        if (key == null)
        {
            throw new ArgumentNullException("key");
        }
        // Try to find the key in the DictionaryEntry array.
        int index;
        if (TryGetIndexOfKey(key, out index))
        {
            // If the key is found, slide all the items up.
            Array.Copy(items, index + 1, items, index, Count - index - 1);
            Count--;
        }
        else
        {
            // If the key is not in the dictionary, just return.
        }
    }
    //</snippet7>
    //<snippet8>		
    public void Clear() => Count = 0;
    //</snippet8>
    //<snippet9>	
    public void Add(object key, object value)
    {
        // Add the new key/value pair even if this key already exists in the dictionary.
        if (Count == items.Length)
        {
            throw new InvalidOperationException("The dictionary cannot hold any more items.");
        }

        items[Count++] = new(key, value);
    }
    //</snippet9>
    //<snippet10>	
    public ICollection Keys
    {
        get
        {
            // Return an array where each item is a key.
            object[] keys = new object[Count];
            for (int n = 0; n < Count; n++)
            {
                keys[n] = items[n].Key;
            }

            return keys;
        }
    }
    //</snippet10>
    //<snippet11>
    public ICollection Values
    {
        get
        {
            // Return an array where each item is a value.
            object[] values = new object[Count];
            for (int n = 0; n < Count; n++)
            {
                values[n] = items[n].Value;
            }

            return values;
        }
    }
    //</snippet11>
    //<snippet13>
    public object this[object key]
    {
        get
        {
            // If this key is in the dictionary, return its value.
            int index;
            if (TryGetIndexOfKey(key, out index))
            {
                // The key was found; return its value.
                return items[index].Value;
            }
            else
            {
                // The key was not found; return null.
                return null;
            }
        }

        set
        {
            // If this key is in the dictionary, change its value.
            int index;
            if (TryGetIndexOfKey(key, out index))
            {
                // The key was found; change its value.
                items[index].Value = value;
            }
            else
            {
                // This key is not in the dictionary; add this key/value pair.
                Add(key, value);
            }
        }
    }
    //</snippet13>
    private bool TryGetIndexOfKey(object key, out int index)
    {
        for (index = 0; index < Count; index++)
        {
            // If the key is found, return true (the index is also returned).
            if (items[index].Key.Equals(key))
            {
                return true;
            }
        }

        // Key not found, return false (index should be ignored by the caller).
        return false;
    }
    //<snippet3>
    private class SimpleDictionaryEnumerator : IDictionaryEnumerator
    {
        // A copy of the SimpleDictionary object's key/value pairs.
        DictionaryEntry[] items;
        int index = -1;

        public SimpleDictionaryEnumerator(SimpleDictionary sd)
        {
            // Make a copy of the dictionary entries currently in the SimpleDictionary object.
            items = new DictionaryEntry[sd.Count];
            Array.Copy(sd.items, 0, items, 0, sd.Count);
        }

        // Return the current item.
        public object Current { get { ValidateIndex(); return items[index]; } }

        // Return the current dictionary entry.
        public DictionaryEntry Entry => (DictionaryEntry)Current;

        // Return the key of the current item.
        public object Key { get { ValidateIndex(); return items[index].Key; } }

        // Return the value of the current item.
        public object Value { get { ValidateIndex(); return items[index].Value; } }

        // Advance to the next item.
        public bool MoveNext()
        {
            if (index < items.Length - 1) { index++; return true; }
            return false;
        }

        // Validate the enumeration index and throw an exception if the index is out of range.
        private void ValidateIndex()
        {
            if (index < 0 || index >= items.Length)
            {
                throw new InvalidOperationException("Enumerator is before or after the collection.");
            }
        }

        // Reset the index to restart the enumeration.
        public void Reset() => index = -1;
    }
    //<snippet12>
    public IDictionaryEnumerator GetEnumerator() =>
        // Construct and return an enumerator.
        new SimpleDictionaryEnumerator(this);
    //</snippet12>
    #endregion

    #region ICollection Members
    public bool IsSynchronized => false;
    public object SyncRoot => throw new NotImplementedException();
    public int Count { get; private set; } = 0;
    public void CopyTo(Array array, int index) => throw new NotImplementedException();
    #endregion

    #region IEnumerable Members
    IEnumerator IEnumerable.GetEnumerator() =>
        // Construct and return an enumerator.
        ((IDictionary)this).GetEnumerator();
    #endregion
}
//</snippet3>
//</snippet2>

public sealed class App
{
    public static void Run()
    {
        // Create a dictionary that contains no more than three entries.
        IDictionary d = new SimpleDictionary(3)
        {
            // Add three people and their ages to the dictionary.
            { "Jeff", 40 },
            { "Kristin", 34 },
            { "Aidan", 1 }
        };

        Console.WriteLine($"Number of elements in dictionary = {d.Count}");

        Console.WriteLine($"Does dictionary contain 'Jeff'? {d.Contains("Jeff")}");
        Console.WriteLine($"Jeff's age is {d["Jeff"]}");

        // Display every entry's key and value.
        foreach (DictionaryEntry de in d)
        {
            Console.WriteLine($"{de.Key} is {de.Value} years old.");
        }

        // Remove an entry that exists.
        d.Remove("Jeff");

        // Remove an entry that does not exist, but do not throw an exception.
        d.Remove("Max");

        // Show the names (keys) of the people in the dictionary.
        foreach (string s in d.Keys)
        {
            Console.WriteLine(s);
        }

        // Show the ages (values) of the people in the dictionary.
        foreach (int age in d.Values)
        {
            Console.WriteLine(age);
        }
    }
}

// This code produces the following output.
//
// Number of elements in dictionary = 3
// Does dictionary contain 'Jeff'? True
// Jeff's age is 40
// Jeff is 40 years old.
// Kristin is 34 years old.
// Aidan is 1 years old.
// Kristin
// Aidan
// 34
// 1
//</snippet1>
