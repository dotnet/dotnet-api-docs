//  <SNIPPET1>
open System
open System.IO

// Create application domain setup information
let domaininfo = AppDomainSetup()
domaininfo.ConfigurationFile <- Environment.CurrentDirectory + string Path.DirectorySeparatorChar + "ADSetup.exe.config"
domaininfo.ApplicationBase <- Environment.CurrentDirectory

//Create evidence for the new appdomain from evidence of the current application domain
let adEvidence = AppDomain.CurrentDomain.Evidence

// Create appdomain
let domain = AppDomain.CreateDomain("Domain2", adEvidence, domaininfo)

// Display application domain information.
printfn $"Host domain: {AppDomain.CurrentDomain.FriendlyName}"
printfn $"Child domain: {domain.FriendlyName}\n"
printfn $"Configuration file: {domain.SetupInformation.ConfigurationFile}"
printfn $"Application Base Directory: {domain.BaseDirectory}"

AppDomain.Unload domain
// The example displays output like the following:
//    Host domain: adsetup.exe
//    Child domain: Domain2
//
//    Configuration file: C:\Test\ADSetup.exe.config
//    Application Base Directory: C:\Test
//  </SNIPPET1>