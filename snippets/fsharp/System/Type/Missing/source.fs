// <Snippet1>
open System
open System.Reflection
open System.CodeDom.Compiler

let generateObjectFromSource objectName (sourceLines: string) providerName =
    let codeProvider = CodeDomProvider.CreateProvider providerName
    let cp = CompilerParameters()

    cp.GenerateExecutable <- false
    cp.GenerateInMemory <- true

    let results = codeProvider.CompileAssemblyFromSource(cp, sourceLines)
    if results.Errors.Count = 0 then
        results.CompiledAssembly.CreateInstance objectName
    else 
        null


// VB source for example. Not all versions of CS and CPP compilers
// support optional arguments.
let codeLines =
    """Imports System
Public Class OptionalArg
  Public Sub MyMethod(ByVal a As Integer, _
    Optional ByVal b As Double = 1.2, _
    Optional ByVal c As Integer = 1)

    Console.WriteLine(\"a = \" & a & \" b = \" & b & \" c = \" & c)
  End Sub
End Class"""

// Generate a OptionalArg instance from the source above.
let o = generateObjectFromSource "OptionalArg" codeLines "VisualBasic"

let t = o.GetType()
let bf = BindingFlags.Public ||| BindingFlags.Instance ||| BindingFlags.InvokeMethod ||| BindingFlags.OptionalParamBinding

t.InvokeMember("MyMethod", bf, null, o, [| 10; 55.3; 12 |]) |> ignore
t.InvokeMember("MyMethod", bf, null, o, [| 10; 1.3; Type.Missing |]) |> ignore
t.InvokeMember("MyMethod", bf, null, o, [| 10; Type.Missing; Type.Missing |]) |> ignore

// </Snippet1>