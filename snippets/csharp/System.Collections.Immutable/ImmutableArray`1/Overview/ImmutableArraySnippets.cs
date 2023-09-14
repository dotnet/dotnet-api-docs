using System;
using System.Collections.Immutable;

static class ImmutableArraySnippets
{
    static void ImmutableArrayNumbers()
    {
        // <SnippetIterate>
        // Create an immutable array of numbers
        ImmutableArray<int> numbers = ImmutableArray.Create(1, 2, 3, 4, -1, -2);

        // Iterate over all items in the array and print them
        foreach (int n in numbers)
        {
            Console.Write(n);
            Console.Write(' ');
        }
        // Output: 1 2 3 4 -1 -2
        // </SnippetIterate>
        
        // <SnippetModify>
        ImmutableArray<int> numbers2 = numbers.RemoveAt(0).Add(-3);
        // numbers2 will contain: 2 3 4 -1 -2 -3
        // </SnippetModify>

        // <SnippetBuilder>
        // Create immutable array builder
        ImmutableArray<int>.Builder builder = ImmutableArray.CreateBuilder<int>();

        // Iterate over all items in the original array and add positive elements to the builder
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] > 0) builder.Add(numbers[i]);
        }

        // Create an immutable array from the contents of the builder
        ImmutableArray<int> numbers3 = builder.ToImmutable();
        // numbers3 will contain: 1 2 3 4
        // </SnippetBuilder>
    }

    public static void Run()
    {
        ImmutableArrayNumbers();
    }
}

