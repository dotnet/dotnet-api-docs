using System.Security;
using System.Net;
using System;

//<Snippet1>
public class MyClass
{
    public static IPAddress GetIPAddress()
    {
        IPAddress ipAddress = Dns.Resolve("localhost").AddressList[0];
        return ipAddress;
    }
    public static void Main()
    {
        try
        {
            //Grants Access.
            Console.WriteLine(" Access granted\n The local host IP Address is :" +
                                  MyClass.GetIPAddress().ToString());
        }
        // Denies Access.
        catch (SecurityException securityException)
        {
            Console.WriteLine("Access denied");	
            Console.WriteLine(securityException.ToString());
        }
    }
}
//</Snippet1>
