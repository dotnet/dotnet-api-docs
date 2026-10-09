// The following code example implements the CollectionBase class and uses that implementation to create a collection of Int16 objects.

// <Snippet1>
using System;
using System.Collections;

public class Int16Collection : CollectionBase
{

    public short this[int index]
    {
        get => ((short)List[index]); set => List[index] = value;
    }

    public int Add(short value) => (List.Add(value));

    public int IndexOf(short value) => (List.IndexOf(value));

    public void Insert(int index, short value) => List.Insert(index, value);

    public void Remove(short value) => List.Remove(value);

    public bool Contains(short value) =>
        // If value isn't of type Int16, this returns false.
        (List.Contains(value));

    protected override void OnInsert(int index, object value)
    {
        // Insert additional code to be run only when inserting values.
    }

    protected override void OnRemove(int index, object value)
    {
        // Insert additional code to be run only when removing values.
    }

    protected override void OnSet(int index, object oldValue, object newValue)
    {
        // Insert additional code to be run only when setting values.
    }

    protected override void OnValidate(object value)
    {
        if (value.GetType() != typeof(short))
        {
            throw new ArgumentException("value must be of type Int16.", "value");
        }
    }
}

public class SamplesCollectionBase
{

    public static void Run()
    {

        // Create and initialize a new CollectionBase.
        Int16Collection myI16 =
        [
            // Add elements to the collection.
            (short)1,
            (short)2,
            (short)3,
            (short)5,
            (short)7,
        ];

        // Display the contents of the collection using foreach. This is the preferred method.
        Console.WriteLine("Contents of the collection (using foreach):");
        PrintValues1(myI16);

        // Display the contents of the collection using the enumerator.
        Console.WriteLine("Contents of the collection (using enumerator):");
        PrintValues2(myI16);

        // Display the contents of the collection using the Count property and the Item property.
        Console.WriteLine("Initial contents of the collection (using Count and Item):");
        PrintIndexAndValues(myI16);

        // Search the collection with Contains and IndexOf.
        Console.WriteLine($"Contains 3: {myI16.Contains(3)}");
        Console.WriteLine($"2 is at index {myI16.IndexOf(2)}.");
        Console.WriteLine();

        // Insert an element into the collection at index 3.
        myI16.Insert(3, (short)13);
        Console.WriteLine("Contents of the collection after inserting at index 3:");
        PrintIndexAndValues(myI16);

        // Get and set an element using the index.
        myI16[4] = 123;
        Console.WriteLine("Contents of the collection after setting the element at index 4 to 123:");
        PrintIndexAndValues(myI16);

        // Remove an element from the collection.
        myI16.Remove((short)2);

        // Display the contents of the collection using the Count property and the Item property.
        Console.WriteLine("Contents of the collection after removing the element 2:");
        PrintIndexAndValues(myI16);
    }

    // Uses the Count property and the Item property.
    public static void PrintIndexAndValues(Int16Collection myCol)
    {
        for (int i = 0; i < myCol.Count; i++)
        {
            Console.WriteLine($"   [{i}]:   {myCol[i]}");
        }

        Console.WriteLine();
    }

    // Uses the foreach statement which hides the complexity of the enumerator.
    // NOTE: The foreach statement is the preferred way of enumerating the contents of a collection.
    public static void PrintValues1(Int16Collection myCol)
    {
        foreach (short i16 in myCol)
        {
            Console.WriteLine($"   {i16}");
        }

        Console.WriteLine();
    }

    // Uses the enumerator.
    // NOTE: The foreach statement is the preferred way of enumerating the contents of a collection.
    public static void PrintValues2(Int16Collection myCol)
    {
        System.Collections.IEnumerator myEnumerator = myCol.GetEnumerator();
        while (myEnumerator.MoveNext())
        {
            Console.WriteLine($"   {myEnumerator.Current}");
        }

        Console.WriteLine();
    }
}


/*
This code produces the following output.

Contents of the collection (using foreach):
   1
   2
   3
   5
   7

Contents of the collection (using enumerator):
   1
   2
   3
   5
   7

Initial contents of the collection (using Count and Item):
   [0]:   1
   [1]:   2
   [2]:   3
   [3]:   5
   [4]:   7

Contains 3: True
2 is at index 1.

Contents of the collection after inserting at index 3:
   [0]:   1
   [1]:   2
   [2]:   3
   [3]:   13
   [4]:   5
   [5]:   7

Contents of the collection after setting the element at index 4 to 123:
   [0]:   1
   [1]:   2
   [2]:   3
   [3]:   13
   [4]:   123
   [5]:   7

Contents of the collection after removing the element 2:
   [0]:   1
   [1]:   3
   [2]:   13
   [3]:   123
   [4]:   7

*/

// </Snippet1>
