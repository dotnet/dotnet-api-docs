//<Snippet1>
type TestGetElementType() = class end
do
    let array = [| 1; 2; 3 |]
    let t = array.GetType()
    let t2 = t.GetElementType()
    printfn $"The element type of {array} is {t2}."
    
    let newMe = TestGetElementType()
    let t = newMe.GetType()
    let t2 = t.GetElementType()
    printfn $"""The element type of {newMe} is {if t2 = null then "null" else string t2}."""

(* This code produces the following output:

The element type of System.Int32[] is System.Int32.
The element type of TestGetElementType is null.
 *)
//</Snippet1>