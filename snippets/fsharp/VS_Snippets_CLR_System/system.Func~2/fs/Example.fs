module Example

// <Snippet5>
open System
open System.Linq

// Declare a Func variable and assign a lambda expression to the
// variable. The function takes a string and converts it to uppercase.
let selector = Func<string, string>(fun str -> str.ToUpper())

// Create a list of strings.
let words = [ "orange"; "apple"; "Article"; "elephant" ]

// Query the list and select strings according to the selector function.
let aWords = words.Select selector

// Output the results to the console.
for word in aWords do
    printfn $"{word}"

// This code example produces the following output:
//     ORANGE
//     APPLE
//     ARTICLE
//     ELEPHANT
// </Snippet5>