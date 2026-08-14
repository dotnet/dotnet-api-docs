// System.Type.GetMembers()

/*
  This program demonstrates GetMembers() method of System.Type Class.
  Get the members (properties, methods, fields, events, and so on)
  of the class 'MyClass' and displays the same to the console.
*/

using System;
using System.Reflection;
using System.Security;

// <Snippet1>
class MembersSampleClass
{
    public int myInt = 0;
    public string myString = null;

    public MembersSampleClass()
    {
    }
    public void Myfunction()
    {
    }
}

class Type_GetMembers
{
    public static void Run()
    {
        try
        {
            MembersSampleClass myObject = new();
            MemberInfo[] myMemberInfo;

            // Get the type of 'MyClass'.
            Type myType = myObject.GetType();

            // Get the information related to all public member's of 'MyClass'.
            myMemberInfo = myType.GetMembers();

            Console.WriteLine($"\nThe members of class '{myType}' are :\n");
            for (int i = 0; i < myMemberInfo.Length; i++)
            {
                // Display name and type of the concerned member.
                Console.WriteLine($"'{myMemberInfo[i].Name}' is a {myMemberInfo[i].MemberType}");
            }
        }
        catch (SecurityException e)
        {
            Console.WriteLine("Exception : " + e.Message);
        }
    }
}
// </Snippet1>
