// <Snippet1>
open System
open System.Text

let mutable nAlphabeticChars = 0
let mutable nWhitespace = 0
let mutable nPunctuation = 0  
let sb = StringBuilder "This is a simple sentence."

for i = 0 to sb.Length - 1 do
    let ch = sb[i]
    if Char.IsLetter ch then
        nAlphabeticChars <- nAlphabeticChars + 1
    elif Char.IsWhiteSpace ch then
        nWhitespace <- nWhitespace + 1
    elif Char.IsPunctuation ch then
        nPunctuation <- nPunctuation + 1

printfn $"The sentence '{sb}' has:"
printfn $"   Alphabetic characters: {nAlphabeticChars}"
printfn $"   White-space characters: {nWhitespace}"
printfn $"   Punctuation characters: {nPunctuation}"

// The example displays the following output:
//       The sentence 'This is a simple sentence.' has:
//          Alphabetic characters: 21
//          White-space characters: 4
//          Punctuation characters: 1
// </Snippet1>