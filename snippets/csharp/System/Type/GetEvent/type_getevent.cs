// <Snippet1>
using System;
using System.Reflection;
using System.Security;

class EventExample
{
    public static void Run()
    {
        try
        {

            Type myType = typeof(System.Windows.Forms.Button);
            EventInfo myEvent = myType.GetEvent("Click");
            if (myEvent != null)
            {
                Console.WriteLine("Looking for the Click event in the Button class.");
                Console.WriteLine(myEvent);
            }
            else
            {
                Console.WriteLine("The Click event is not available in the Button class.");
            }
        }
        catch (SecurityException e)
        {
            Console.WriteLine("An exception occurred.");
            Console.WriteLine("Message :" + e.Message);
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine("An exception occurred.");
            Console.WriteLine("Message :" + e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine($"The following exception was raised : {e.Message}");
        }
    }
}
// </Snippet1>
