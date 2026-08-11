// <Snippet1>
using System;

delegate int Searcher(string searchString, int start, int count,
                         StringComparison type);

public class NamedDelegateExample
{
    public static void Run()
    {
        string title = "The House of the Seven Gables";
        int position = 0;
        Searcher finder = title.IndexOf;
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
// </Snippet1>
