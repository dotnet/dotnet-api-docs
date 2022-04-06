//<Snippet1>
open System

let root = AppDomain.CurrentDomain

let setup = AppDomainSetup()
setup.ApplicationBase <-
    root.SetupInformation.ApplicationBase + @"MyAppSubfolder\"

let domain = AppDomain.CreateDomain("MyDomain", null, setup)

printfn $"Application base of {root.FriendlyName}:\r\n\t{root.SetupInformation.ApplicationBase}"
printfn $"Application base of {domain.FriendlyName}:\r\n\t{domain.SetupInformation.ApplicationBase}"

AppDomain.Unload domain

(* This example produces output similar to the following:

Application base of MyApp.exe:
        C:\Program Files\MyApp\
Application base of MyDomain:
        C:\Program Files\MyApp\MyAppSubfolder\
 *)
//</Snippet1>