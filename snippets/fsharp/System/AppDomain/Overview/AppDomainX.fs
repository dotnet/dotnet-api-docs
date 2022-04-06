//<snippet1>
open System
open System.Reflection
open System.Threading

//<snippet3>
// Because this class is derived from MarshalByRefObject, a proxy
// to a MarshalByRefType object can be returned across an AppDomain
// boundary.
type MarshalByRefType() =
    inherit MarshalByRefObject()
    
    //  Call this method via a proxy.
    member _.SomeMethod(callingDomainName) =
        // Get this AppDomain's settings and display some of them.
        let ads = AppDomain.CurrentDomain.SetupInformation
        printfn $"AppName={ads.ApplicationName}, AppBase={ads.ApplicationBase}, ConfigFile={ads.ConfigurationFile}"

        // Display the name of the calling AppDomain and the name
        // of the second domain.
        // NOTE: The application's thread has transitioned between
        // AppDomains.
        printfn $"Calling from '{callingDomainName}' to '{Thread.GetDomain().FriendlyName}'."
//</snippet3>

//<snippet2>
// Get and display the friendly name of the default AppDomain.
let callingDomainName = Thread.GetDomain().FriendlyName
printfn $"{callingDomainName}"

// Get and display the full name of the EXE assembly.
let exeAssembly = Assembly.GetEntryAssembly().FullName
printfn $"{exeAssembly}"

// Construct and initialize settings for a second AppDomain.
let ads = AppDomainSetup()
ads.ApplicationBase <- AppDomain.CurrentDomain.BaseDirectory

ads.DisallowBindingRedirects <- false
ads.DisallowCodeDownload <- true
ads.ConfigurationFile <-
    AppDomain.CurrentDomain.SetupInformation.ConfigurationFile

// Create the second AppDomain.
let ad2 = AppDomain.CreateDomain("AD #2", null, ads)

// Create an instance of MarshalbyRefType in the second AppDomain.
// A proxy to the object is returned.
let mbrt =
    ad2.CreateInstanceAndUnwrap(
        exeAssembly,
        typeof<MarshalByRefType>.FullName) :?> MarshalByRefType

// Call a method on the object via the proxy, passing the
// default AppDomain's friendly name in as a parameter.
mbrt.SomeMethod callingDomainName

// Unload the second AppDomain. This deletes its object and
// invalidates the proxy object.
AppDomain.Unload ad2
try
    // Call the method again. Note that this time it fails
    // because the second AppDomain was unloaded.
    mbrt.SomeMethod callingDomainName
    printfn "Sucessful call."
with :? AppDomainUnloadedException ->
    printfn "Failed call this is expected."
//</snippet2>

(* This code produces output similar to the following:

AppDomainX.exe
AppDomainX, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
AppName=, AppBase=C:\AppDomain\bin, ConfigFile=C:\AppDomain\bin\AppDomainX.exe.config
Calling from 'AppDomainX.exe' to 'AD #2'.
Failed call this is expected.
 *)
//</snippet1>