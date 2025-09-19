module double

// <Snippet1>
open System
open System.Numerics

let ERROR_BAD_ARGUMENTS = 0xA0
let ERROR_ARITHMETIC_OVERFLOW = 0x216
let ERROR_INVALID_COMMAND_LINE = 0x667

let args = Environment.GetCommandLineArgs()
if args.Length = 1 then
    Environment.ExitCode <- ERROR_INVALID_COMMAND_LINE
else
    match BigInteger.TryParse args[1] with
    | true, value ->
        if value <= bigint Int32.MinValue || value >= bigint Int32.MaxValue then
            Environment.ExitCode <- ERROR_ARITHMETIC_OVERFLOW
        else
            printfn $"Result: {value * 2I}"
    | _ ->
        Environment.ExitCode <- ERROR_BAD_ARGUMENTS
// </Snippet1>