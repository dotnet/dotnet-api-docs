// This sample demonstrates how to use each member of the StringBuilder class.
//<Snippet2>
open System.Text

let constructorWithNothing () =
    // Initialize a new StringBuilder object.
    //<Snippet1>
    let stringBuilder = StringBuilder()
    //</Snippet1>
    ()

let constructorWithCapacity () =
    // Initialize a new StringBuilder object with the specified capacity.
    //<Snippet3>
    let capacity = 255
    let stringBuilder = StringBuilder capacity
    //</Snippet3>
    ()

let constructorWithString () =
    // Initialize a new StringBuilder object with the specified string.
    //<Snippet4>
    let initialString = "Initial string."
    let stringBuilder = StringBuilder initialString
    //</Snippet4>
    ()

let constructorWithCapacityAndMax () =
    // Initialize a new StringBuilder object with the specified capacity
    // and maximum capacity.
    //<Snippet5>
    let capacity = 255
    let maxCapacity = 1024
    let stringBuilder = StringBuilder(capacity, maxCapacity)
    //</Snippet5>
    ()

let constructorWithSubstring () =
    // Initialize a new StringBuilder object with the specified substring.
    //<Snippet6>
    let initialString = "Initial string for stringbuilder."
    let startIndex = 0
    let substringLength = 14
    let capacity = 255

    let stringBuilder =
        StringBuilder(initialString, startIndex, substringLength, capacity)
    //</Snippet6>
    ()

let constructorWithStringAndMax () =
    // Initialize a new StringBuilder object with the specified string
    // and maximum capacity.
    //<Snippet7>
    let initialString = "Initial string. "
    let capacity = 255
    let stringBuilder = StringBuilder(initialString, capacity)
    //</Snippet7>

    // Ensure that appending the specified string will not exceed the
    // maximum capacity of the object.
    //<Snippet8>
    let phraseToAdd = "Sentence to be appended."

    if (stringBuilder.Length + phraseToAdd.Length) <= stringBuilder.MaxCapacity then
        stringBuilder.Append phraseToAdd |> ignore
    //</Snippet8>

    // Retrieve the string value of the StringBuilder object.
    //<Snippet9>
    let builderResults = stringBuilder.ToString()
    // let builderResults = string stringBuilder
    //</Snippet9>

    // Retrieve the last 10 characters of the StringBuilder object.
    //<Snippet10>
    let sentenceLength = 10
    let startPosition = stringBuilder.Length - sentenceLength
    let endPhrase = stringBuilder.ToString(startPosition, sentenceLength)
    //</Snippet10>

    // Retrieve the last character of the StringBuilder object.
    //<Snippet11>
    let lastCharacterPosition = stringBuilder.Length - 1
    let lastCharacter = stringBuilder[lastCharacterPosition]
    //</Snippet11>
    ()

constructorWithNothing ()
constructorWithCapacity ()
constructorWithString ()
constructorWithCapacityAndMax ()
constructorWithSubstring ()
constructorWithStringAndMax ()

printfn "This sample completed successfully press Enter to exit."
stdin.ReadLine() |> ignore

// This sample produces the following output:
//
// This sample completed successfully press Enter to exit.
//</Snippet2>
