//<SNIPPET1>
open System
open System.IO
open System.Security.AccessControl

// Adds an ACL entry on the specified directory for the specified account.
let addDirectorySecurity fileName (account: string) rights controlType =
    // Create a new DirectoryInfo object.
    let dInfo = DirectoryInfo fileName

    // Get a DirectorySecurity object that represents the
    // current security settings.
    let dSecurity = dInfo.GetAccessControl()

    // Add the FileSystemAccessRule to the security settings.
    dSecurity.AddAccessRule(FileSystemAccessRule(account, rights, controlType))

    // Set the new access settings.
    dInfo.SetAccessControl dSecurity

// Removes an ACL entry on the specified directory for the specified account.
let removeDirectorySecurity fileName (account: string) rights controlType =
    // Create a new DirectoryInfo object.
    let dInfo = DirectoryInfo fileName

    // Get a DirectorySecurity object that represents the
    // current security settings.
    let dSecurity = dInfo.GetAccessControl()

    // Add the FileSystemAccessRule to the security settings.
    dSecurity.RemoveAccessRule(FileSystemAccessRule(account, rights, controlType)) |> ignore

    // Set the new access settings.
    dInfo.SetAccessControl dSecurity

try
    let DirectoryName = "TestDirectory"

    printfn $"Adding access control entry for {DirectoryName}"

    // Add the access control entry to the directory.
    addDirectorySecurity DirectoryName @"MYDOMAIN\MyAccount" FileSystemRights.ReadData AccessControlType.Allow

    printfn $"Removing access control entry from {DirectoryName}"

    // Remove the access control entry from the directory.
    removeDirectorySecurity DirectoryName @"MYDOMAIN\MyAccount" FileSystemRights.ReadData AccessControlType.Allow

    printfn "Done."
with e ->
    printfn $"{e}"
//</SNIPPET1>