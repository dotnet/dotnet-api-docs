open System
open System.Runtime.InteropServices

let performStringOperation () =
    // <Snippet1>
    let original = "This is a sentence. This is a second sentence."
    let sentence1 = original.Substring(0, original.IndexOf "." + 1)
    printfn $"{original}"
    printfn $"{sentence1}"
    // The example displays the following output:
    //    This is a sentence. This is a second sentence.
    //    This is a sentence.            
    // </Snippet1>

// <Snippet2>
let mergeSentence (span: Span<char>) =
    if span.Length = 0 then
        Span<char>.Empty
    else
        span[0] <- '\000'
        span[2] <- Char.ToLower span[2]
        span

let useMutableBuffer () =
    let original = "This is a sentence. This is a second sentence."
    let chars = original.ToCharArray()
    let span = Span chars
    let slice = span.Slice(span.IndexOf '.', 3)
    let slice = mergeSentence slice
    let span = span.ToString()
    printfn $"Original string: {original}"
    printfn $"Modified string: {span}"
// The example displays the following output:
//    Original string: This is a sentence. This is a second sentence.
//    Modified string: This is a sentence this is a second sentence.        
// </Snippet2>

// <Snippet3>
#nowarn "9"
open FSharp.NativeInterop

let useUnmanaged () =
    let original = "This is a single sentence."
    let mutable len = original.Length 
    let ptr = Marshal.StringToHGlobalUni original
    let mutable ch = ptr.ToPointer() |> NativePtr.ofVoidPtr<char> 
    while len > 0 do
        len <- len - 1
        Convert.ToUInt16(NativePtr.read ch) + 1us
        |> Convert.ToChar
        |> NativePtr.write (NativePtr.add ch 1)
        ch <- NativePtr.add ch 1

    let result = Marshal.PtrToStringUni ptr
    Marshal.FreeHGlobal ptr
    printfn $"Original string: {original}"
    printfn $"String from interop: '{result}'"

// The example displays the following output:
//    Original string: This is a single sentence.
//    String from interop: 'Uijt!jt!b!tjohmf!tfoufodf/'      
// </Snippet3>

performStringOperation ()
printfn "---"
useMutableBuffer ()
printfn "---"
useUnmanaged ()
