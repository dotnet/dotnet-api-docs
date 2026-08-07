// <Snippet2>
using System;

public class Example
{
    public static void Main()
    {
        string title = "The House of the Seven Gables";
        string searchString = "the";
        StringComparison comparison = StringComparison.InvariantCulture;
        Console.WriteLine($"'{title}':");
        Console.WriteLine($"   Starts with '{searchString}' ({comparison:G} comparison): {title.StartsWith(searchString, comparison)}");

        comparison = StringComparison.InvariantCultureIgnoreCase;
        Console.WriteLine($"   Starts with '{searchString}' ({comparison:G} comparison): {title.StartsWith(searchString, comparison)}");
    }
}
// The example displays the following output:
//       'The House of the Seven Gables':
//          Starts with 'the' (InvariantCulture comparison): False
//          Starts with 'the' (InvariantCultureIgnoreCase comparison): True
// </Snippet2>
