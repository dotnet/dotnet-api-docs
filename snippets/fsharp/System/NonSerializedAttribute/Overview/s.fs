// <Snippet1>
open System
open System.IO
open System.Runtime.Serialization.Formatters.Soap

// A test object that needs to be serialized.
[<Serializable>]
type TestSimpleObject() =
    let member1 = 11
    let member2 = "hello"
    let member3 = "hello"
    let member4 = 3.14159265

    // A field that is not serialized.
    [<NonSerialized>]
    let member5 = "hello world!"

    member _.Print() =
        printfn $"member1 = '{member1}'"
        printfn $"member2 = '{member2}'"
        printfn $"member3 = '{member3}'"
        printfn $"member4 = '{member4}'"
        printfn $"member5 = '{member5}'"

[<EntryPoint>]
let main _ =
    // Creates a new TestSimpleObject object.
    let obj = TestSimpleObject()

    printfn "Before serialization the object contains: "
    obj.Print()

    // Opens a file and serializes the object into it in binary format.
    let stream = File.Open("data.xml", FileMode.Create)
    let formatter = SoapFormatter()

    formatter.Serialize(stream, obj)
    stream.Close()

    // Opens file "data.xml" and deserializes the object from it.
    let stream = File.Open("data.xml", FileMode.Open)
    let formatter = new SoapFormatter()

    let obj = formatter.Deserialize stream :?> TestSimpleObject
    stream.Close()

    printfn "\nAfter deserialization the object contains: "
    obj.Print()
    0
// </Snippet1>
