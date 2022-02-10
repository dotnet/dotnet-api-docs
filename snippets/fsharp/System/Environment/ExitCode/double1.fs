module double1

// <Snippet2>
open System
open System.Numerics

let ERROR_SUCCESS = 0
let ERROR_BAD_ARGUMENTS = 0xA0
let ERROR_ARITHMETIC_OVERFLOW = 0x216
let ERROR_INVALID_COMMAND_LINE = 0x667

[<EntryPoint>]
let main _ =
    let args = Environment.GetCommandLineArgs()
    if args.Length = 1 then
        ERROR_INVALID_COMMAND_LINE
    else
        match BigInteger.TryParse args[1] with
        | true, value ->
            if value <= bigint Int32.MinValue || value >= bigint Int32.MaxValue then
                ERROR_ARITHMETIC_OVERFLOW
            else
                printfn $"Result: {value * 2I}"
                ERROR_SUCCESS
        | _ ->
            ERROR_BAD_ARGUMENTS
// </Snippet2>