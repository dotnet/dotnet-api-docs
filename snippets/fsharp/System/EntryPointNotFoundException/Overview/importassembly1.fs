module importassembly1

// <Snippet4>
open System
open System.Runtime.InteropServices

[<DllImport("StringUtilities.dll", CharSet = CharSet.Unicode )>]
extern String SayGoodMorning(String name)

printfn $"""{SayGoodMorning "Dakota"}"""
// The example displays the following output:
//    Unhandled Exception: System.EntryPointNotFoundException: Unable to find an entry point
//    named 'GoodMorning' in DLL 'StringUtilities.dll'.
//       at Example.GoodMorning(String& name)
//       at Example.Main()
// </Snippet4>