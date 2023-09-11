using System;

// <Snippet2>
[Serializable]
public class CallbackByValSnippet
{
    private string greetings = "PING!";

    public static void Main()
    {
        AppDomain otherDomain = AppDomain.CreateDomain("otherDomain");

        CallbackByValSnippet pp = new CallbackByValSnippet();
        pp.MyCallBack();
        pp.greetings = "PONG!";
        otherDomain.DoCallBack(new CrossAppDomainDelegate(pp.MyCallBack));

        // Output:
        //   PING! from defaultDomain
        //   PONG! from otherDomain
    }

    public void MyCallBack()
    {
        string name = AppDomain.CurrentDomain.FriendlyName;

        if (name == AppDomain.CurrentDomain.SetupInformation.ApplicationName)
        {
            name = "defaultDomain";
        }
        Console.WriteLine(greetings + " from " + name);
    }
}
// </Snippet2>
