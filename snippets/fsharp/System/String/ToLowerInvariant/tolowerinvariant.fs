// <Snippet1>
open System

let words = 
    [| "Tuesday"; "Salı"; "Вторник"; "Mardi" 
       "Τρίτη"; "Martes"; "יום שלישי" 
       "الثلاثاء"; "วันอังคาร" |]
// Display array in unsorted order.
for word in words do
    printfn $"{word}"
printfn ""

// Create parallel array of words by calling ToLowerInvariant.
let lowerWords = 
    words |> Array.map (fun x -> x.ToLowerInvariant())

// Sort the words array based on the order of lowerWords.
Array.Sort(lowerWords, words, StringComparer.InvariantCulture)

// Display the sorted array.
for word in words do
    printfn $"{word}"

// The example displays the following output:
//       Tuesday
//       Salı
//       Вторник
//       Mardi
//       Τρίτη
//       Martes
//       יום שלישי
//       الثلاثاء
//       วันอังคาร
//       
//       Mardi
//       Martes
//       Salı
//       Tuesday
//       Τρίτη
//       Вторник
//       יום שלישי
//       الثلاثاء
//       วันอังคาร
// </Snippet1>