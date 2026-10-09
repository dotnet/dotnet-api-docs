// <Snippet1>
using System;
using System.Xml;
using System.Reflection;

public class MyFindInterfacesSample
{
    public static void Main()
    {
        try
        {
            XmlDocument myXMLDoc = new();
            myXMLDoc.LoadXml("<book genre='novel' ISBN='1-861001-57-5'>" +
                "<title>Pride And Prejudice</title>" + "</book>");
            Type myType = myXMLDoc.GetType();

            // Specify the TypeFilter delegate that compares the
            // interfaces against filter criteria.
            TypeFilter myFilter = new(MyInterfaceFilter);
            string[] myInterfaceList =
                ["System.Collections.IEnumerable",
                "System.Collections.ICollection"];
            for (int index = 0; index < myInterfaceList.Length; index++)
            {
                Type[] myInterfaces = myType.FindInterfaces(myFilter,
                    myInterfaceList[index]);
                if (myInterfaces.Length > 0)
                {
                    Console.WriteLine($"\n{myType} implements the interface {myInterfaceList[index]}.");
                    for (int j = 0; j < myInterfaces.Length; j++)
                        Console.WriteLine($"Interfaces supported: {myInterfaces[j]}.");
                }
                else
                    Console.WriteLine($"\n{myType} does not implement the interface {myInterfaceList[index]}.");
            }
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine("ArgumentNullException: " + e.Message);
        }
        catch (TargetInvocationException e)
        {
            Console.WriteLine("TargetInvocationException: " + e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
    }

    public static bool MyInterfaceFilter(Type typeObj, object criteriaObj)
    {
        if (typeObj.FullName == criteriaObj as string)
            return true;
        else
            return false;
    }
}
// </Snippet1>
