//<Snippet1>
#define CONTRACTS_FULL

using System.Diagnostics.Contracts;

// An IArray is an ordered collection of objects.
[ContractClass(typeof(IArrayContract))]
public interface IArray
{
    // The Item property provides methods to read and edit entries in the array.
    object this[int index]
    {
        get;
        set;
    }

    int Count
    {
        get;
    }

    // Adds an item to the list.
    // The return value is the position the new element was inserted in.
    int Add(object value);

    // Removes all items from the list.
    void Clear();

    // Inserts value into the array at position index.
    // Index must be non-negative and less than or equal to the
    // number of elements in the array. If index equals the number
    // of items in the array, then value is appended to the end.
    void Insert(int index, object value);

    // Removes the item at position index.
    void RemoveAt(int index);
}

//<Snippet4>
[ContractClassFor(typeof(IArray))]
internal abstract class IArrayContract : IArray
{
    //<Snippet3>
    int IArray.Add(object value)
    {
        // Returns the index in which an item was inserted.
        Contract.Ensures(Contract.Result<int>() >= -1);
        Contract.Ensures(Contract.Result<int>() < ((IArray)this).Count);
        return default;
    }
    //</Snippet3>
    object IArray.this[int index]
    {
        get
        {
            Contract.Requires(index >= 0);
            Contract.Requires(index < ((IArray)this).Count);
            return default;
        }
        set
        {
            Contract.Requires(index >= 0);
            Contract.Requires(index < ((IArray)this).Count);
        }
    }
    //<Snippet2>
    public int Count
    {
        get
        {
            Contract.Requires(Count >= 0);
            Contract.Requires(Count <= ((IArray)this).Count);
            return default;
        }
    }
    //</Snippet2>

    void IArray.Clear()
    {
        Contract.Ensures(((IArray)this).Count == 0);
    }

    //<Snippet5>
    void IArray.Insert(int index, object value)
    {
        Contract.Requires(index >= 0);
        Contract.Requires(index <= ((IArray)this).Count);  // For inserting immediately after the end.
        Contract.Ensures(((IArray)this).Count == Contract.OldValue(((IArray)this).Count) + 1);
    }
    //</Snippet5>

    void IArray.RemoveAt(int index)
    {
        Contract.Requires(index >= 0);
        Contract.Requires(index < ((IArray)this).Count);
        Contract.Ensures(((IArray)this).Count == Contract.OldValue(((IArray)this).Count) - 1);
    }
}
//</Snippet4>
//</Snippet1>
