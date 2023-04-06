//<SNIPPET1>
open System.IO
open System.Security.AccessControl

// Adds an ACL entry on the specified file for the specified account.
let addFileSecurity fileName (account: string) rights controlType =
    // Get a FileSecurity object that represents the
    // current security settings.
    let fSecurity = File.GetAccessControl fileName

    // Add the FileSystemAccessRule to the security settings.
    FileSystemAccessRule(account, rights, controlType)
    |> fSecurity.AddAccessRule

    // Set the new access settings.
    File.SetAccessControl(fileName, fSecurity)

// Removes an ACL entry on the specified file for the specified account.
let removeFileSecurity fileName (account: string) rights controlType =
    // Get a FileSecurity object that represents the
    // current security settings.
    let fSecurity = File.GetAccessControl fileName

    // Remove the FileSystemAccessRule from the security settings.
    fSecurity.RemoveAccessRule(FileSystemAccessRule(account, rights, controlType))
    |> ignore

    // Set the new access settings.
    File.SetAccessControl(fileName, fSecurity)

let fileName = "test.xml"

printfn $"Adding access control entry for {fileName}"

// Add the access control entry to the file.
addFileSecurity fileName @"DomainName\AccountName" FileSystemRights.ReadData AccessControlType.Allow

printfn $"Removing access control entry from {fileName}"

// Remove the access control entry from the file.
removeFileSecurity fileName @"DomainName\AccountName" FileSystemRights.ReadData AccessControlType.Allow

printfn "Done."
//</SNIPPET1>
