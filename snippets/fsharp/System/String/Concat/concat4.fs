module concat4

// <Snippet1>
open System
open System.Collections

let WORD_SIZE = 4
      
// Define some 4-letter words to be scrambled.
let words = [| "home"; "food"; "game"; "rest" |]
// Define two arrays equal to the number of letters in each word.
let keys = Array.zeroCreate<float> WORD_SIZE
let letters = Array.zeroCreate<string> WORD_SIZE
// Initialize the random number generator.
let rnd = Random()

// Scramble each word.
for word in words do
    for i = 0 to word.Length - 1 do
        // Populate the array of keys with random numbers.
        keys[i] <- rnd.NextDouble()
        // Assign a letter to the array of letters.
        letters[i] <- string word[i]
    // Sort the array. 
    Array.Sort(keys, letters, 0, WORD_SIZE, Comparer.Default)      
    // Display the scrambled word.
    let scrambledWord = String.Concat(letters[0], letters[1], letters[2], letters[3])
    printfn $"{word} --> {scrambledWord}"
// The example displays output like the following:
//       home --> mheo
//       food --> oodf
//       game --> aemg
//       rest --> trse
// </Snippet1>