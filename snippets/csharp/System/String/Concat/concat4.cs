// <Snippet1>
using System;
using System.Collections;

public class ConcatScrambleExample
{
    public static void Run()
    {
        const int WORD_SIZE = 4;

        // Define some 4-letter words to be scrambled.
        string[] words = { "home", "food", "game", "rest" };
        // Define two arrays equal to the number of letters in each word.
        double[] keys = new double[WORD_SIZE];
        string[] letters = new string[WORD_SIZE];
        // Initialize the random number generator.
        Random rnd = new();

        // Scramble each word.
        foreach (string word in words)
        {
            for (int ctr = 0; ctr < word.Length; ctr++)
            {
                // Populate the array of keys with random numbers.
                keys[ctr] = rnd.NextDouble();
                // Assign a letter to the array of letters.
                letters[ctr] = word[ctr].ToString();
            }
            // Sort the array.
            Array.Sort(keys, letters, 0, WORD_SIZE, Comparer.Default);
            // Display the scrambled word.
            string scrambledWord = string.Concat(letters[0], letters[1],
                                                 letters[2], letters[3]);
            Console.WriteLine($"{word} --> {scrambledWord}");
        }
    }
}
// The example displays output like the following:
//       home --> mheo
//       food --> oodf
//       game --> aemg
//       rest --> trse
// </Snippet1>
