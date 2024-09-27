using System;
using System.Data;
// <Snippet1>
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        try
        {
            string connectString =
                "Data Source=(local);User ID=ab;Password=myPassw0rd;" +
                "Initial Catalog=AdventureWorks";

            SqlConnectionStringBuilder builder = new(connectString);
            Console.WriteLine($"Original: {builder.ConnectionString}");

            // Remove the User ID and Password.
            builder.Remove("User ID");
            builder.Remove("Password");

            // Enable integrated security.
            builder.IntegratedSecurity = true;

            Console.WriteLine($"Modified: {builder.ConnectionString}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
/* This code example produces the following output:
 * Original: Data Source=(local);Initial Catalog=AdventureWorks;User ID=ab;Password=myPassw0rd
 * Modified: Data Source=(local);Initial Catalog=AdventureWorks;Integrated Security=True
 */
// </Snippet1>
