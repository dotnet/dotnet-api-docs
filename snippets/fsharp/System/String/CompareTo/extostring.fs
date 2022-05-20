module extostring

//<Snippet1>
open System

type TestClass() = class end

let test = TestClass()
let objectsToCompare: obj list =
    [ test; string test; 123
      string 123; "some text"
      "Some Text" ]
let s = "some text"
for objectToCompare in objectsToCompare do
    try
        let i = s.CompareTo objectToCompare
        printfn $"Comparing '{s}' with '{objectToCompare}': {i}"
    with :? ArgumentException ->
        printfn $"Bad argument: {objectToCompare} (type {objectToCompare.GetType().Name})"
// The example displays the following output:
//    Bad argument: TestClass (type TestClass)
//    Comparing 'some text' with 'TestClass': -1
//    Bad argument: 123 (type Int32)
//    Comparing 'some text' with '123': 1
//    Comparing 'some text' with 'some text': 0
//    Comparing 'some text' with 'Some Text': -1
//</Snippet1>