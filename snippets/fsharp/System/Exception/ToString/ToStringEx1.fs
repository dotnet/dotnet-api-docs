module Example

//<Snippet1>
open System

type TestClass() = class end

let test = TestClass()
let objectsToCompare: obj[] =
    [| test; test.ToString(); 123
       string 123; "some text"
       "Some Text" |]

let s = "some text"
for objectToCompare in objectsToCompare do
    try
        let i = s.CompareTo objectToCompare
        printfn $"Comparing '{s}' with '{objectToCompare}': {i}"
    with :? ArgumentException as e ->
        printfn $"Bad argument: {objectToCompare} (type {objectToCompare.GetType().Name})"
        printfn $"Exception information: {e}"
    printfn ""

// The example displays the following output:
//     Bad argument: Example+TestClass (type TestClass)
//     Exception information: System.ArgumentException: Object must be of type String.
//        at System.String.CompareTo(Object value)
//        at <StartupCode$fs>.$Example.main@()
//
//     Comparing 'some text' with 'Example+TestClass': -1
//
//     Bad argument: 123 (type Int32)
//     Exception information: System.ArgumentException: Object must be of type String.
//        at System.String.CompareTo(Object value)
//        at <StartupCode$fs>.$Example.main@()
//
//     Comparing 'some text' with '123': 1
//
//     Comparing 'some text' with 'some text': 0
//
//     Comparing 'some text' with 'Some Text': -1
//</Snippet1>