module EmptyString1

// <Snippet15>
open System

let getFirstCharacter (s: string) = s[0]

let words = [ "the"; "today"; "tomorrow"; " "; "" ]
for word in words do
    printfn $"First character of '{word}': '{getFirstCharacter word}'"

// The example displays the following output:
//    First character of 'the': 't'
//    First character of 'today': 't'
//    First character of 'tomorrow': 't'
//    First character of ' ': ' '
//
//    Unhandled Exception: System.IndexOutOfRangeException: Index was outside the bounds of the array.
//       at <StartupCode$argumentoutofrangeexception>.$EmptyString1.main@()
// </Snippet15>

module StringLib =
   // <Snippet16>
   let getFirstCharacter (s: string) =
      if String.IsNullOrEmpty s then
         '\u0000'
      else
         s[0]
   // </Snippet16>