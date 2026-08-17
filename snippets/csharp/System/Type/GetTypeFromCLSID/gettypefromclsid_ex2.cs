// <Snippet2>
using System;
using System.Reflection;


public class GetTypeFromClsidExample2
{
    private const string WORD_CLSID = "{000209FF-0000-0000-C000-000000000046}";

    public static void Run()
    {
        try
        {
            // Start an instance of the Word application.
            var word = Type.GetTypeFromCLSID(Guid.Parse(WORD_CLSID), true);
            Console.WriteLine("Instantiated Type object from CLSID {0}",
                              WORD_CLSID);
            object wordObj = Activator.CreateInstance(word);
            Console.WriteLine("Instantiated {0}",
                              wordObj.GetType().FullName, WORD_CLSID);

            // Close Word.
            word.InvokeMember("Quit", BindingFlags.InvokeMethod, null,
                              wordObj, [0, 0, false]);
        }
        catch (Exception)
        {
            Console.WriteLine("Unable to instantiate an object for {0}", WORD_CLSID);
        }
    }
}
// The example displays the following output:
//    Instantiated Type object from CLSID {000209FF-0000-0000-C000-000000000046}
//    Instantiated Microsoft.Office.Interop.Word.ApplicationClass
// </Snippet2>
