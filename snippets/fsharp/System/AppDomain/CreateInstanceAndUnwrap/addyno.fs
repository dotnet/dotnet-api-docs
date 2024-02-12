module addyno

// <Snippet1>
open System
open System.IO
open System.Threading
open System.Reflection
open System.Reflection.Emit

let createADynamicAssembly (myNewDomain: byref<AppDomain>) executableNameNoExe =
    let executableName = executableNameNoExe + ".exe"

    let myAsmName = AssemblyName()
    myAsmName.Name <- executableNameNoExe
    myAsmName.CodeBase <- Environment.CurrentDirectory

    let myAsmBuilder = 
        myNewDomain.DefineDynamicAssembly(myAsmName, AssemblyBuilderAccess.RunAndSave)
    printfn "-- Dynamic Assembly instantiated."

    let myModBuilder = 
        myAsmBuilder.DefineDynamicModule(executableNameNoExe, executableName)

    let myTypeBuilder = 
        myModBuilder.DefineType(executableNameNoExe,
                        TypeAttributes.Public,
                        typeof<MarshalByRefObject>)

    let myFCMethod = 
        myTypeBuilder.DefineMethod("CountLocalFiles",
                        MethodAttributes.Public |||
                        MethodAttributes.Static,
                        null,
                        [||])

    let currentDirGetMI = typeof<Environment>.GetProperty("CurrentDirectory").GetGetMethod()
    let writeLine0objMI = typeof<Console>.GetMethod("WriteLine", [| typeof<string> |])
    let writeLine2objMI = typeof<Console>.GetMethod("WriteLine", [| typeof<string>; typeof<obj>; typeof<obj> |])
    let getFilesMI = typeof<Directory>.GetMethod("GetFiles", [| typeof<string> |])

    myFCMethod.InitLocals <- true

    let myFCIL = myFCMethod.GetILGenerator()

    printfn "-- Generating MSIL method body..."
    let v0 = myFCIL.DeclareLocal typeof<string>
    let v1 = myFCIL.DeclareLocal typeof<int>
    let v2 = myFCIL.DeclareLocal typeof<string>
    let v3 = myFCIL.DeclareLocal typeof<string[]>

    let evalForEachLabel = myFCIL.DefineLabel()
    let topOfForEachLabel = myFCIL.DefineLabel()

    // Build the method body.

    myFCIL.EmitCall(OpCodes.Call, currentDirGetMI, null)
    myFCIL.Emit(OpCodes.Stloc_S, v0)
    myFCIL.Emit(OpCodes.Ldc_I4_0)
    myFCIL.Emit(OpCodes.Stloc_S, v1)
    myFCIL.Emit(OpCodes.Ldstr, "---")
    myFCIL.EmitCall(OpCodes.Call, writeLine0objMI, null)
    myFCIL.Emit(OpCodes.Ldloc_S, v0)
    myFCIL.EmitCall(OpCodes.Call, getFilesMI, null)
    myFCIL.Emit(OpCodes.Stloc_S, v3)

    myFCIL.Emit(OpCodes.Br_S, evalForEachLabel)

    // foreach loop starts here.
    myFCIL.MarkLabel topOfForEachLabel
    
        // Load array of strings and index, store value at index for output.
    myFCIL.Emit(OpCodes.Ldloc_S, v3)
    myFCIL.Emit(OpCodes.Ldloc_S, v1)
    myFCIL.Emit OpCodes.Ldelem_Ref
    myFCIL.Emit(OpCodes.Stloc_S, v2)

    myFCIL.Emit(OpCodes.Ldloc_S, v2)
    myFCIL.EmitCall(OpCodes.Call, writeLine0objMI, null)

    // Increment counter by one.
    myFCIL.Emit(OpCodes.Ldloc_S, v1)
    myFCIL.Emit(OpCodes.Ldc_I4_1)
    myFCIL.Emit OpCodes.Add
    myFCIL.Emit(OpCodes.Stloc_S, v1)

    // Determine if end of file list array has been reached.
    myFCIL.MarkLabel evalForEachLabel
    myFCIL.Emit(OpCodes.Ldloc_S, v1)
    myFCIL.Emit(OpCodes.Ldloc_S, v3)
    myFCIL.Emit OpCodes.Ldlen
    myFCIL.Emit OpCodes.Conv_I4
    myFCIL.Emit(OpCodes.Blt_S, topOfForEachLabel)
    //foreach loop end here.

    myFCIL.Emit(OpCodes.Ldstr, "---")
    myFCIL.EmitCall(OpCodes.Call, writeLine0objMI, null)
    myFCIL.Emit(OpCodes.Ldstr, "There are {0} files in {1}.")
    myFCIL.Emit(OpCodes.Ldloc_S, v1)
    myFCIL.Emit(OpCodes.Box, typeof<int>)
    myFCIL.Emit(OpCodes.Ldloc_S, v0)
    myFCIL.EmitCall(OpCodes.Call, writeLine2objMI, null)

    myFCIL.Emit OpCodes.Ret

    let myType = myTypeBuilder.CreateType()

    myAsmBuilder.SetEntryPoint myFCMethod
    myAsmBuilder.Save executableName
    printfn "-- Method generated, type completed, and assembly saved to disk."

    myType


printf "Enter a name for the file counting assembly: "
let executableNameNoExe = stdin.ReadLine()
let executableName = executableNameNoExe + ".exe"
printfn "---"

let domainDir = Environment.CurrentDirectory

let mutable curDomain = Thread.GetDomain()

// Create a new AppDomain, with the current directory as the base.

printfn $"Current Directory: {Environment.CurrentDirectory}"
let mySetupInfo = AppDomainSetup()
mySetupInfo.ApplicationBase <- domainDir
mySetupInfo.ApplicationName <- executableNameNoExe
mySetupInfo.LoaderOptimization <- LoaderOptimization.SingleDomain

let myDomain = 
    AppDomain.CreateDomain(executableNameNoExe, null, mySetupInfo)

printfn $"Creating a new AppDomain '{executableNameNoExe}'..."

printfn $"-- Base Directory = '{myDomain.BaseDirectory}'"
printfn $"-- Shadow Copy? = '{myDomain.ShadowCopyFiles}'"

printfn "---"
let myFCType = 
    createADynamicAssembly &curDomain executableNameNoExe

printfn $"Loading '{executableName}' from '{myDomain.BaseDirectory}'..."

let bFlags = 
    BindingFlags.Public ||| BindingFlags.CreateInstance ||| BindingFlags.Instance

let myObjInstance = 
    myDomain.CreateInstanceAndUnwrap(executableNameNoExe,
            executableNameNoExe, false, bFlags,
            null, null, null, null, null)

printfn $"Executing method 'CountLocalFiles' in {myObjInstance}..."

myFCType.InvokeMember("CountLocalFiles", BindingFlags.InvokeMethod, null, myObjInstance, [||])
// </Snippet1>