module class7

// <snippet15>
open System.IO
open System.Security.AccessControl

let securityRules = DirectorySecurity()
securityRules.AddAccessRule(FileSystemAccessRule(@"Domain\account1", FileSystemRights.Read, AccessControlType.Allow))
securityRules.AddAccessRule(FileSystemAccessRule(@"Domain\account2", FileSystemRights.FullControl, AccessControlType.Allow))

let di = Directory.CreateDirectory(@"C:\destination\NewDirectory", securityRules)
// </snippet15>

()