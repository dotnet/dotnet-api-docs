module source
//<Snippet1>
open System
open System.Collections.Generic

let numbers = Stack()
numbers.Push "one"
numbers.Push "two"
numbers.Push "three"
numbers.Push "four"
numbers.Push "five"

// A stack can be enumerated without disturbing its contents.
for number in numbers do
    printfn $"{number}"

printfn $"\nPopping '{numbers.Pop()}'"
printfn $"Peek at next item to destack: {numbers.Peek()}"
numbers.Peek() |> ignore
printfn $"Popping '{numbers.Pop()}'"

// Create a copy of the stack, using the ToArray method and the
// constructor that accepts an IEnumerable<T>.
let stack2 = numbers.ToArray() |> Stack

printfn "\nContents of the first copy:"

for number in stack2 do
    printfn $"{number}"

// Create an array twice the size of the stack and copy the
// elements of the stack, starting at the middle of the
// array.
let array2 = numbers.Count * 2 |> Array.zeroCreate
numbers.CopyTo(array2, numbers.Count)

// Create a second stack, using the constructor that accepts an
// IEnumerable(Of T).
let stack3 = Stack array2

printfn "\nContents of the second copy, with duplicates and nulls:"

for number in stack3 do
    printfn $"{number}"

printfn
    $"""
stack2.Contains "four" = {stack2.Contains "four"}"""

printfn "\nstack2.Clear()"
stack2.Clear()
printfn $"\nstack2.Count = {stack2.Count}"

// This code example produces the following output:
//       five
//       four
//       three
//       two
//       one
//
//       Popping 'five'
//       Peek at next item to destack: four
//       Popping 'four'
//
//       Contents of the first copy:
//       one
//       two
//       three
//
//       Contents of the second copy, with duplicates and nulls:
//       one
//       two
//       three
//
//       stack2.Contains("four") = False
//
//       stack2.Clear()
//
//       stack2.Count = 0
//</Snippet1>
