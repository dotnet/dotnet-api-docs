// <Snippet1>
using System;
using System.Runtime.Remoting;

public class SetObjectUriForMarshalTest  {

    class TestClass : MarshalByRefObject {
    }

    public static void Main()  {

        TestClass obj = new TestClass();

        RemotingServices.SetObjectUriForMarshal(obj, "testUri");
        RemotingServices.Marshal(obj);

        Console.WriteLine(RemotingServices.GetObjectUri(obj));
    }
}
// </Snippet1>