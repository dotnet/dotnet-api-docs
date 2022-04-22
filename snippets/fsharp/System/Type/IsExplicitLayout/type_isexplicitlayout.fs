// <Snippet1>
open System.Runtime.InteropServices

// Class to test for the ExplicitLayout property.
[<StructLayout(LayoutKind.Explicit, Size=16, CharSet=CharSet.Ansi)>]
type MySystemTime =
   [<FieldOffset 0>] val public wYear: uint16
   [<FieldOffset 2>] val public wMonth: uint16
   [<FieldOffset 4>] val public wDayOfWeek: uint16
   [<FieldOffset 6>] val public wDay: uint16
   [<FieldOffset 8>] val public wHour: uint16
   [<FieldOffset 10>] val public wMinute: uint16
   [<FieldOffset 12>] val public wSecond: uint16
   [<FieldOffset 14>] val public wMilliseconds: uint16

// Create an instance of the type using the GetType method.
let t = typeof<MySystemTime>
// Get and display the IsExplicitLayout property.
printfn $"\nIsExplicitLayout for MySystemTime is {t.IsExplicitLayout}."
// </Snippet1>