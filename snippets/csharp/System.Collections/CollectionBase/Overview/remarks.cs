// The following code example implements the CollectionBase class and uses that implementation to create a collection of Int16 objects.

using System;
using System.Collections;

public class SynchronizedInt16Collection : CollectionBase
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

public class SamplesSynchronizedCollectionBase
{
    public static void Run()
    {
        // Create and initialize a new CollectionBase.
        SynchronizedInt16Collection myCollectionBase =
        [
            // Add elements to the collection.
            (short)1,
            (short)2,
            (short)3,
            (short)5,
            (short)7,
        ];

        // <Snippet2>
        // Get the ICollection interface from the CollectionBase
        // derived class.
        ICollection myCollection = myCollectionBase;
        lock (myCollection.SyncRoot)
        {
            foreach (object item in myCollection)
            {
                // Insert your code here.
            }
        }
        // </Snippet2>
    }
}
