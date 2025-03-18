module source
//<Snippet1>
open System
open System.Collections.Generic

let numbers = Queue()
numbers.Enqueue "one"
numbers.Enqueue "two"
numbers.Enqueue "three"
numbers.Enqueue "four"
numbers.Enqueue "five"

// A queue can be enumerated without disturbing its contents.
for number in numbers do
    printfn $"{number}"

printfn $"\nDequeuing '{numbers.Dequeue()}'"
printfn $"Peek at next item to dequeue: {numbers.Peek()}"
printfn $"Dequeuing '{numbers.Dequeue()}'"

// Create a copy of the queue, using the ToArray method and the
// constructor that accepts an IEnumerable<T>.
let queueCopy = numbers.ToArray() |> Queue

printfn $"\nContents of the first copy:"
for number in queueCopy do
    printfn $"{number}"

// Create an array twice the size of the queue and copy the
// elements of the queue, starting at the middle of the
// array.
let array2 = numbers.Count * 2 |> Array.zeroCreate
numbers.CopyTo(array2, numbers.Count)

// Create a second queue, using the constructor that accepts an
// IEnumerable(Of T).
let queueCopy2 = Queue array2

printfn $"\nContents of the second copy, with duplicates and nulls:"
for number in queueCopy2 do
    printfn $"{number}"
printfn $"""\nqueueCopy.Contains "four" = {queueCopy.Contains "four"}"""

printfn $"\nqueueCopy.Clear()"
queueCopy.Clear()
printfn $"queueCopy.Count = {queueCopy.Count}"

// This code example produces the following output:
//       one
//       two
//       three
//       four
//       five
//       
//       Dequeuing 'one'
//       Peek at next item to dequeue: two
//       Dequeuing 'two'
//       
//       Contents of the first copy:
//       three
//       four
//       five
//       
//       Contents of the second copy, with duplicates and nulls:
//       
//       
//       
//       three
//       four
//       five
//       
//       queueCopy.Contains "four" = True
//       
//       queueCopy.Clear()
//       
//       queueCopy.Count = 0
//</Snippet1>
