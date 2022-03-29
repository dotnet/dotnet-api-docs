module ArrayListSample

//<snippet7>
open System
open System.Text
open System.Collections.Generic

//<snippet6>
type ReverseStringComparer() =
    interface IComparer<string> with
        member _.Compare(x, y) =
            -String.Compare(x, y)
//</snippet6>

//<snippet2>
let printValues title (myList: #seq<string>) =
    printf $"{title,10}: "
    let sb = StringBuilder()
    for s in myList do
        sb.Append $"{s}, " |> ignore
    sb.Remove(sb.Length - 2, 2) |> ignore
    printfn $"{sb}"
//</snippet2>

//<snippet1>
// Creates and initializes a new ResizeArray.
let myAL = ResizeArray()
myAL.Add "Eric"
myAL.Add "Mark"
myAL.Add "Lance"
myAL.Add "Rob"
myAL.Add "Kris"
myAL.Add "Brad"
myAL.Add "Kit"
myAL.Add "Bradley"
myAL.Add "Keith"
myAL.Add "Susan"

// Displays the properties and values of	the	ArrayList.
printfn $"Count: {myAL.Count}"
//</snippet1>

printValues "Unsorted" myAL
//<snippet3>
myAL.Sort()
printValues "Sorted" myAL
//</snippet3>
//<snippet4>
myAL.Sort(ReverseStringComparer())
printValues "Reverse" myAL
//</snippet4>

//</snippet7>