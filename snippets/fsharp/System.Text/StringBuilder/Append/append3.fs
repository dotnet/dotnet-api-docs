module append3

open System
open System.Text

let appendInt16 () =
    // <Snippet10>
    let sb = StringBuilder "The range of a 16-bit integer: "
    sb.Append(Int16.MinValue).Append(" to ").Append Int16.MaxValue |> ignore
    printfn $"{sb}"
    // The example displays the following output:
    //       The range of a 16-bit integer: -32768 to 32767
    // </Snippet10>

let appendInt32 () =
    // <Snippet11>
    let sb = StringBuilder "The range of a 32-bit integer: "
    sb.Append(Int32.MinValue).Append(" to ").Append Int32.MaxValue |> ignore
    printfn $"{sb}"
    // The example displays the following output:
    //       The range of a 32-bit integer: -2147483648 to 2147483647
    // </Snippet11>

let appendInt64 () =
    // <Snippet12>
    let sb = StringBuilder "The range of a 64-bit integer: "
    sb.Append(Int64.MinValue).Append(" to ").Append Int64.MaxValue |> ignore
    printfn $"{sb}"
    // The example displays the following output:
    //       The range of a 64-bit integer:  -9223372036854775808 to 9223372036854775807
    // </Snippet12>

let appendSByte () =
    // <Snippet13>
    let sb = StringBuilder "The range of an 8-bit signed integer: "
    sb.Append(SByte.MinValue).Append(" to ").Append SByte.MaxValue |> ignore
    printfn $"{sb}"
    // The example displays the following output:
    //       The range of an 8-bit unsigned integer: -128 to 127
    // </Snippet13>

let appendSingle () =
    // <Snippet14>
    let value = 1034769.47f
    let sb = StringBuilder()
    sb.Append('*', 5).Append(value).Append('*', 5) |> ignore
    printfn $"{sb}"
    // The example displays the following output:
    //       *****1034769.47*****
    // </Snippet14>

let appendUInt16 () =
    // <Snippet15>
    let sb = StringBuilder "The range of a 16-bit unsigned integer: "
    sb.Append(UInt16.MinValue).Append(" to ").Append UInt16.MaxValue |> ignore
    printfn $"{sb}"
    // The example displays the following output:
    //       The range of a 16-bit unsigned integer: 0 to 65535
    // </Snippet15>

let appendUInt32 () =
    // <Snippet16>
    let sb = StringBuilder "The range of a 32-bit unsigned integer: "
    sb.Append(UInt32.MinValue).Append(" to ").Append UInt32.MaxValue |> ignore
    printfn $"{sb}"
    // The example displays the following output:
    //       The range of a 32-bit unsigned integer: 0 to 4294967295
    // </Snippet16>

let appendUInt64 () =
    // <Snippet17>
    let sb = StringBuilder "The range of a 64-bit unsigned integer: "
    sb.Append(UInt64.MinValue).Append(" to ").Append UInt64.MaxValue |> ignore
    printfn $"{sb}"
    // The example displays the following output:
    //       The range of a 64-bit unsigned integer: 0 to 18446744073709551615
    // </Snippet17>

let appendString () =
    // <Snippet19>
    let str = "First;George Washington;1789;1797"
    let mutable index = 0
    let sb = StringBuilder()
    let length = str.IndexOf(';', index)

    sb.Append(str, index, length).Append " President of the United States: "
    |> ignore

    index <- index + length + 1
    let length = str.IndexOf(';', index) - index
    sb.Append(str, index, length).Append ", from " |> ignore
    index <- index + length + 1
    let length = str.IndexOf(';', index) - index
    sb.Append(str, index, length).Append " to " |> ignore
    index <- index + length + 1
    sb.Append(str, index, str.Length - index) |> ignore
    printfn $"{sb}"
    // The example displays the following output:
    //    First President of the United States: George Washington, from 1789 to 1797
    // </Snippet19>


appendInt16 ()
printfn "---"
appendInt32 ()
printfn "---"
appendInt64 ()
printfn "---"
appendSByte ()
printfn "---"
appendSingle ()
printfn "---"
appendUInt16 ()
printfn "---"
appendUInt32 ()
printfn "---"
appendUInt64 ()
printfn "---"
appendString ()
printfn "---"
