' <snippet15>
Imports System.IO
Imports System.Security.AccessControl

Partial Class Program
    Shared Sub DirectorySecurityExample()

        Dim securityRules As DirectorySecurity = New DirectorySecurity()
        securityRules.AddAccessRule(New FileSystemAccessRule("Domain\account1", FileSystemRights.Read, AccessControlType.Allow))
        securityRules.AddAccessRule(New FileSystemAccessRule("Domain\account2", FileSystemRights.FullControl, AccessControlType.Allow))

        Dim di As DirectoryInfo = Directory.CreateDirectory("C:\destination\NewDirectory", securityRules)

    End Sub
End Class
' </snippet15>
