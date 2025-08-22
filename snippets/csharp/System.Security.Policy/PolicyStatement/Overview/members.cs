// This sample demonstrates how to use each member of the PolicyStatement
// class.
//<Snippet1>
using System;
using System.Security;
using System.Security.Policy;
using System.Security.Principal;
using System.Security.Permissions;

class Members
{
    [STAThread]
    static void Main(string[] args)
    {
        // Create two new policy statements.
        PolicyStatement policyStatement = firstConstructorTest();
        PolicyStatement policyStatement2 = secondConstructorTest();

        // Add attributes to the first policy statement.
        //<Snippet4>
        policyStatement.Attributes = PolicyStatementAttribute.All;
        //</Snippet4>

        // Create a copy of the first policy statement.
        PolicyStatement policyStatementCopy = createCopy(policyStatement);
        addXmlMember(ref policyStatementCopy);

        summarizePolicyStatment(policyStatement);
        Console.WriteLine("This sample completed successfully; " +
            "press Enter to exit.");
        Console.ReadLine();
    }

    // If a class attribute is not found in the specified PolicyStatement,
    // add a child XML element with an added class attribute.
    private static void addXmlMember(ref PolicyStatement policyStatement)
    {
        //<Snippet6>
        SecurityElement xmlElement = policyStatement.ToXml();
        //</Snippet6>
        if (xmlElement.Attribute("class") == null)
        {
            //<Snippet7>
            SecurityElement newElement =
                new SecurityElement("PolicyStatement");
            newElement.AddAttribute("class", policyStatement.ToString());
            newElement.AddAttribute("version","1.1");

            newElement.AddChild(new SecurityElement("PermissionSet"));

            policyStatement.FromXml(newElement);
            //</Snippet7>

            Console.Write("Added the class attribute and modified its ");
            Console.WriteLine("version number.\n" + newElement.ToString());
        }
    }

    // Verify that the type of the specified object is a PolicyStatement type
    // then create a copy of the object.
    private static PolicyStatement createCopy(Object sourceObject)
    {
        PolicyStatement returnedStatement = new PolicyStatement(null);
        // Compare specified object type with the PolicyStatement type.
        //<Snippet8>
        if (sourceObject.GetType().Equals(typeof(PolicyStatement)))
            //</Snippet8>
        {
            returnedStatement = getCopy((PolicyStatement)sourceObject);
        }
        else
        {
            throw new ArgumentException("Expected the PolicyStatement type.");
        }

        return returnedStatement;
    }

    // Return a copy of the specified PolicyStatement if the result of the
    // Copy command is an equivalent object. Otherwise, return the
    // original PolicyStatement object.
    private static PolicyStatement getCopy(PolicyStatement policyStatement)
    {
        // Create an equivalent copy of the policy statement.
        //<Snippet9>
        PolicyStatement policyStatementCopy = policyStatement.Copy();
        //</Snippet9>

        // Compare the specified objects for equality.
        //<Snippet10>
        if (!policyStatementCopy.Equals(policyStatement))
            //</Snippet10>
        {
            return policyStatementCopy;
        }
        else
        {
            return policyStatement;
        }
    }

    // Summarize the attributes of the specified PolicyStatement on the
    // console window.
    private static void summarizePolicyStatment(
        PolicyStatement policyStatement)
    {
        // Retrieve the class path for policyStatement.
        //<Snippet11>
        string policyStatementClass = policyStatement.ToString();
        //</Snippet11>

        //<Snippet12>
        int hashCode = policyStatement.GetHashCode();
        //</Snippet12>

        string attributeString = "";
        // Retrieve the string representation of the PolicyStatement
        // attributes.
        //<Snippet13>
        if (policyStatement.AttributeString != null)
        {
            attributeString = policyStatement.AttributeString;
        }
        //</Snippet13>

        // Write a summary to the console window.
        Console.WriteLine("\n*** " + policyStatementClass + " summary ***");
        Console.Write("This PolicyStatement has been created with hash ");
        Console.Write("code(" + hashCode + ") ");

        Console.Write("and contains the following attributes: ");
        Console.WriteLine(attributeString);
    }
}
//
// This sample produces the following output:
//
// Added the class attribute and modified the version number.
// <PolicyStatement class="System.Security.Policy.PolicyStatement"
//                  version="1.1">
//    <PermissionSet/>
// </PolicyStatement>
//
// *** System.Security.Policy.PolicyStatement summary ***
// PolicyStatement has been created with hash code(20) containing the
// following attributes: Exclusive LevelFinal
// This sample completed successfully; press Enter to exit.
//</Snippet1>
