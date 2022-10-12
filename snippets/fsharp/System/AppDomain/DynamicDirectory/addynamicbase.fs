//<Snippet1>
open System
open System.Reflection
open System.Reflection.Emit

type Example() =
    inherit MarshalByRefObject()
    member _.Test() =
        let dynAssem = 
            Assembly.Load "DynamicHelloWorld, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"

        let myType = dynAssem.GetType "HelloWorld"
        myType.InvokeMember("HelloFromAD", BindingFlags.Public |||
            BindingFlags.Static ||| BindingFlags.InvokeMethod,
            Type.DefaultBinder, null, null)
        |> ignore

    static member GenerateDynamicAssembly(location: string) =
        // Define the dynamic assembly and the module. There is only one
        // module in this assembly. Note that the call to DefineDynamicAssembly
        // specifies the location where the assembly will be saved. The
        // assembly version is 1.0.0.0.
        let asmName = AssemblyName "DynamicHelloWorld"
        asmName.Version <- Version "1.0.0.0"

        let ab = AppDomain.CurrentDomain.DefineDynamicAssembly(asmName, AssemblyBuilderAccess.Save, location)

        let moduleName = asmName.Name + ".exe"
        let mb = ab.DefineDynamicModule(asmName.Name, moduleName)

        // Define the "HelloWorld" type, with one static method.
        let tb = mb.DefineType("HelloWorld", TypeAttributes.Public)
        let hello = 
            tb.DefineMethod("HelloFromAD", MethodAttributes.Public ||| MethodAttributes.Static, null, null)

        // The method displays a message that contains the name of the application
        // domain where the method is executed.
        let il = hello.GetILGenerator()
        il.Emit(OpCodes.Ldstr, "Hello from '{0}'!")
        il.Emit(OpCodes.Call, typeof<AppDomain>.GetProperty("CurrentDomain").GetGetMethod())
        il.Emit(OpCodes.Call, typeof<AppDomain>.GetProperty("FriendlyName").GetGetMethod())
        il.Emit(OpCodes.Call, typeof<Console>.GetMethod("WriteLine", [| typeof<string>; typeof<String> |]))
        il.Emit OpCodes.Ret

        // Complete the HelloWorld type and save the assembly. The assembly
        // is placed in the location specified by DefineDynamicAssembly.
        let myType = tb.CreateType()
        ab.Save moduleName

// Prepare to create a new application domain.
let setup = AppDomainSetup()

// Set the application name before setting the dynamic base.
setup.ApplicationName <- "Example"

// Set the location of the base directory where assembly resolution
// probes for dynamic assemblies. Note that the hash code of the
// application name is concatenated to the base directory name you
// supply.
setup.DynamicBase <- "C:\\DynamicAssemblyDir"
printfn $"DynamicBase is set to '{setup.DynamicBase}'."

let ad = AppDomain.CreateDomain("MyDomain", null, setup)

// The dynamic directory name is the dynamic base concatenated with
// the application name: <DynamicBase>\<hash code>\<ApplicationName>
let dynamicDir = ad.DynamicDirectory
printfn $"Dynamic directory is '{dynamicDir}'."

// The AssemblyBuilder won't create this directory automatically.
if not (System.IO.Directory.Exists dynamicDir) then
    printfn "Creating the dynamic directory."
    System.IO.Directory.CreateDirectory dynamicDir
    |> ignore

// Generate a dynamic assembly and store it in the dynamic
// directory.
Example.GenerateDynamicAssembly dynamicDir

// Create an instance of the Example class in the application domain,
// and call its Test method to load the dynamic assembly and use it.
let ex = ad.CreateInstanceAndUnwrap(typeof<Example>.Assembly.FullName, "Example") :?> Example
ex.Test()

(* This example produces output similar to the following:

DynamicBase is set to 'C:\DynamicAssemblyDir\5e4a7545'.
Dynamic directory is 'C:\DynamicAssemblyDir\5e4a7545\Example'.
Creating the dynamic directory.
Hello from 'MyDomain'!
 *)
//</Snippet1>
