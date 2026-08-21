// The following code example implements the ReadOnlyCollectionBase class.

using System;
using System.Collections;

public class SynchronizedROCollection : ReadOnlyCollectionBase
{

    public SynchronizedROCollection(IList sourceList) => InnerList.AddRange(sourceList);

    public object this[int index] => (InnerList[index]);

    public int IndexOf(object value) => (InnerList.IndexOf(value));

    public bool Contains(object value) => (InnerList.Contains(value));
}

public class SamplesSynchronizedReadOnlyCollectionBase
{
    public static void Run()
    {
        // Create an ArrayList.
        ArrayList myAL = ["red", "blue", "yellow", "green", "orange", "purple"];

        // Create a new SynchronizedROCollection that contains the elements in myAL.
        SynchronizedROCollection myReadOnlyCollection = new(myAL);

        // <Snippet2>
        // Get the ICollection interface from the ReadOnlyCollectionBase
        // derived class.
        ICollection myCollection = myReadOnlyCollection;
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
