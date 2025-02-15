using System.ComponentModel;

public abstract class Coll1 : EventDescriptorCollection
{
    protected object myNewColl;

    public Coll1() : base(null)
    {
    }
    protected void Method() =>
        // <Snippet1>
        myNewColl = Sort(["D", "B"]);// </Snippet1>
}
