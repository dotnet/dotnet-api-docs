//<snippet00>
using System;
using System.Collections;
using System.Collections.Specialized;

//<snippet01>
public class People : IOrderedDictionary
{
    private ArrayList _people;

    public People(int numItems)
    {
        _people = new(numItems);
    }

    public int IndexOfKey(object key)
    {
        for (int i = 0; i < _people.Count; i++)
        {
            if (((DictionaryEntry)_people[i]).Key == key)
                return i;
        }

        // Key not found.
        return -1;
    }

    public object this[object key]
    {
        get
        {
            return ((DictionaryEntry)_people[IndexOfKey(key)]).Value;
        }
        set
        {
            _people[IndexOfKey(key)] = new DictionaryEntry(key, value);
        }
    }

    // IOrderedDictionary members.
    public IDictionaryEnumerator GetEnumerator()
    {
        return new PeopleEnum(_people);
    }

    public void Insert(int index, object key, object value)
    {
        if (IndexOfKey(key) != -1)
        {
            throw new ArgumentException("An element with the same key already exists in the collection.");
        }
        _people.Insert(index, new DictionaryEntry(key, value));
    }

    public void RemoveAt(int index)
    {
        _people.RemoveAt(index);
    }

    public object this[int index]
    {
        get
        {
            return ((DictionaryEntry)_people[index]).Value;
        }
        set
        {
            object key = ((DictionaryEntry)_people[index]).Key;
            _people[index] = new DictionaryEntry(key, value);
        }
    }
    // IDictionary members.

    public void Add(object key, object value)
    {
        if (IndexOfKey(key) != -1)
        {
            throw new ArgumentException("An element with the same key already exists in the collection.");
        }
        _people.Add(new DictionaryEntry(key, value));
    }

    public void Clear()
    {
        _people.Clear();
    }

    public bool Contains(object key)
    {
        if (IndexOfKey(key) == -1)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public bool IsFixedSize => false;

    public bool IsReadOnly => false;

    public ICollection Keys
    {
        get
        {
            ArrayList KeyCollection = new(_people.Count);
            for (int i = 0; i < _people.Count; i++)
            {
                KeyCollection.Add(((DictionaryEntry)_people[i]).Key);
            }
            return KeyCollection;
        }
    }

    public void Remove(object key)
    {
        _people.RemoveAt(IndexOfKey(key));
    }

    public ICollection Values
    {
        get
        {
            ArrayList ValueCollection = new(_people.Count);
            for (int i = 0; i < _people.Count; i++)
            {
                ValueCollection.Add(((DictionaryEntry)_people[i]).Value);
            }
            return ValueCollection;
        }
    }

    // ICollection members.

    public void CopyTo(Array array, int index)
    {
        _people.CopyTo(array, index);
    }

    public int Count => _people.Count;

    public bool IsSynchronized => _people.IsSynchronized;

    public object SyncRoot => _people.SyncRoot;

    // IEnumerable members.

    IEnumerator IEnumerable.GetEnumerator() => new PeopleEnum(_people);
}

public class PeopleEnum : IDictionaryEnumerator
{
    public ArrayList _people;

    // Enumerators are positioned before the first element
    // until the first MoveNext() call.
    int _position = -1;

    public PeopleEnum(ArrayList list) => _people = list;

    public bool MoveNext()
    {
        _position++;
        return (_position < _people.Count);
    }

    public void Reset() => _position = -1;

    public object Current
    {
        get
        {
            try
            {
                return _people[_position];
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }

    public DictionaryEntry Entry => (DictionaryEntry)Current;

    public object Key
    {
        get
        {
            try
            {
                return ((DictionaryEntry)_people[_position]).Key;
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }

    public object Value
    {
        get
        {
            try
            {
                return ((DictionaryEntry)_people[_position]).Value;
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
//</snippet01>

class PeopleApp
{
    public static void Run()
    {
        People peopleCollection = new(3)
        {
            { "John", "Smith" },
            { "Jim", "Johnson" },
            { "Sue", "Rabon" }
        };

        Console.WriteLine("Displaying the entries in peopleCollection:");
        foreach (DictionaryEntry de in peopleCollection)
        {
            Console.WriteLine($"{de.Key} {de.Value}");
        }

        Console.WriteLine();
        Console.WriteLine("Displaying the entries in the modified peopleCollection:");
        peopleCollection["Jim"] = "Jackson";
        peopleCollection.Remove("Sue");
        peopleCollection.Insert(0, "Fred", "Anderson");

        // <SnippetDictionaryEntry>
        foreach (DictionaryEntry de in peopleCollection)
        {
            Console.WriteLine($"{de.Key} {de.Value}");
        }
        // </SnippetDictionaryEntry>
    }
}

/* This code produces output similar to the following:
 *
 * Displaying the entries in peopleCollection:
 * John Smith
 * Jim Johnson
 * Sue Rabon
 *
 * Displaying the entries in the modified peopleCollection:
 * Fred Anderson
 * John Smith
 * Jim Jackson
 */
 
//</snippet00>
