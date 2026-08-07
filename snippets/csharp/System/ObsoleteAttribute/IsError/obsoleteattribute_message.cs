// <Snippet1>
using System;
using System.Reflection;

public class Example
{
    // Mark OldProperty As Obsolete.
    [ObsoleteAttribute("This property is obsolete. Use NewProperty instead.", false)]
    public string OldProperty => "The old property value.";

    public string NewProperty => "The new property value.";

    // Mark OldMethod As Obsolete.
    [ObsoleteAttribute("This method is obsolete. Call NewMethod instead.", true)]
    public string OldMethod() => "You have called OldMethod.";

    public string NewMethod() => "You have called NewMethod.";

    public static void Main()
    {
        // Get all public members of this type.
        MemberInfo[] members = typeof(Example).GetMembers();
        // Count total obsolete members.
        int n = 0;

        // Try to get the ObsoleteAttribute for each public member.
        Console.WriteLine("Obsolete members in the Example class:\n");
        foreach (var member in members)
        {
            ObsoleteAttribute[] attribs = (ObsoleteAttribute[])
                                           member.GetCustomAttributes(typeof(ObsoleteAttribute),
                                                                      false);
            if (attribs.Length > 0)
            {
                ObsoleteAttribute attrib = attribs[0];
                Console.WriteLine($"Member Name: {member.DeclaringType.FullName}.{member.Name}");
                Console.WriteLine($"   Message: {attrib.Message}");
                Console.WriteLine($"   Warning/Error: {(attrib.IsError ? "Error" : "Warning")}");
                n++;
            }
        }

        if (n == 0)
            Console.WriteLine("The Example type has no obsolete attributes.");
    }
}
// The example displays the following output:
//       Obsolete members in the Example class:
//
//       Member Name: Example.OldMethod
//          Message: This method is obsolete. Call NewMethod instead.
//          Warning/Error: Error
//       Member Name: Example.OldProperty
//          Message: This property is obsolete. Use NewProperty instead.
//          Warning/Error: Warning
// </Snippet1>
