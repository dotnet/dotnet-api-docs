module iformattable3

// <Snippet9>
open System

let guidString = "ba748d5c-ae5f-4cca-84e5-1ac5291c38cb"
printfn $"""{Guid.ParseExact(guidString, "G")}"""
// The example displays the following output:
//    Unhandled Exception: System.FormatException:
//       Format String can be only "D", "d", "N", "n", "P", "p", "B", "b", "X" or "x".
//       at System.Guid.ParseExact(String input, String format)
//       at <StartupCode$fs>.$Example.main@()
// </Snippet9>