// <SNIPPET1>
open System
open System.Security
open System.Security.Policy
open System.Security.Permissions

// Create a new application domain.
let domain = AppDomain.CreateDomain "MyDomain"

// Create a new AppDomain PolicyLevel.
let polLevel = PolicyLevel.CreateAppDomainLevel()
// Create a new, empty permission set.
let permSet = PermissionSet PermissionState.None
// Add permission to execute code to the permission set.
permSet.AddPermission(SecurityPermission SecurityPermissionFlag.Execution) |> ignore
// Give the policy level's root code group a new policy statement based
// on the new permission set.
polLevel.RootCodeGroup.PolicyStatement <- PolicyStatement permSet
// Give the new policy level to the application domain.
domain.SetAppDomainPolicy polLevel

// Try to execute the assembly.
try
    // This will throw a PolicyException if the executable tries to
    // access any resources like file I/O or tries to create a window.
    domain.ExecuteAssembly "Assemblies\\MyWindowsExe.exe"
    |> ignore
with :? PolicyException as e ->
    printfn $"PolicyException: {e.Message}"

AppDomain.Unload domain
// </SNIPPET1>