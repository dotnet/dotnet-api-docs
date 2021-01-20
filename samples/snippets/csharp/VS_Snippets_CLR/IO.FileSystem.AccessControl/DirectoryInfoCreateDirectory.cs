using System.IO;
using System.Runtime.Versioning;
using System.Security.AccessControl;
using System.Security.Principal;

namespace MyNamespace
{
    public class MyClassCS
    {
        // Attribute to address CA1416 warning:
        // System.IO.FileSystem.AccessControl APIs are  only available on Windows
        [SupportedOSPlatform("windows")]
        static void Main()
        {
            // Create the file security object

            SecurityIdentifier identity = new SecurityIdentifier(
                WellKnownSidType.BuiltinUsersSid, // This maps to "Everyone" user group in Windows
                null); // null is OK for this particular user group. For others, a non-empty value might be required
            FileSystemAccessRule accessRule = new FileSystemAccessRule(identity, FileSystemRights.FullControl, AccessControlType.Allow);

            DirectorySecurity expectedSecurity = new DirectorySecurity();
            expectedSecurity.AddAccessRule(accessRule);

            // Make sure the directory does not exist, then create it

            string dirPath = Path.Combine(Path.GetTempPath(), "directoryToCreate");
            DirectoryInfo dirInfo = new DirectoryInfo(dirPath);
            if (dirInfo.Exists)
            {
                dirInfo.Delete(recursive: true);
            }

            dirInfo.Create(expectedSecurity);
        }
    }
}
