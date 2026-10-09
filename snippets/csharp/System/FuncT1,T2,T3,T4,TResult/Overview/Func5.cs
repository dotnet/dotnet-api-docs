// <Snippet2>
using System;

public class FuncDelegateExample
{
    public static void Run()
    {
        string title = "The House of the Seven Gables";
        int position = 0;
        Func<string, int, int, StringComparison, int> finder = title.IndexOf;
        do
        {
            int characters = title.Length - position;
            position = finder("the", position, characters,
                            StringComparison.InvariantCultureIgnoreCase);
            if (position >= 0)
            {
                position++;
                Console.WriteLine($"'The' found at position {position} in {title}.");
            }
        } while (position > 0);
    }
}
// </Snippet2>
