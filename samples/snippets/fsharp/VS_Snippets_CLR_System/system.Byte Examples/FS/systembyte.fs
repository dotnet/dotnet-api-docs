open System

//<Snippet1>
let minMaxFields numberToSet =
    if numberToSet <= int Byte.MaxValue && numberToSet >= int Byte.MinValue then
        // You must explicitly convert an integer to a byte.
        let myByte = byte numberToSet

        printfn $"The MemberByte value is {myByte}"
    else
        printfn $"The value {numberToSet} is outside of the range of possible Byte values"

//</Snippet1>

//<Snippet3>
let compare (byte1: byte) byte2 =
    let myCompareResult = byte1.CompareTo byte2

    if myCompareResult > 0 then
        printfn $"{byte1} is less than the MemberByte value {byte2}"

    elif myCompareResult < 0 then
        printfn $"{byte1} is greater than the MemberByte value {byte2}"
    
    else
        printfn $"{byte1} is equal to the MemberByte value {byte2}"
//</Snippet3>
