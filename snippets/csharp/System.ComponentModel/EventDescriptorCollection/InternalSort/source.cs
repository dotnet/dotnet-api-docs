using System.ComponentModel;

public abstract class Coll1 : EventDescriptorCollection
{
    public Coll1() : base(null)
    {
    }

    protected void Method() =>
        // <Snippet1>
        InternalSort(["D", "B"]);// </Snippet1>
}
