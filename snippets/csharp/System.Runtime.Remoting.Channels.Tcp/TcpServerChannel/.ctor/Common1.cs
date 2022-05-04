using System;
using System.Runtime.Remoting;

// Remote object.
public class RemoteObject1 : MarshalByRefObject
{
    private int callCount = 0;

    public int GetCount()
    {
        callCount++;
        return(callCount);
    }
}
