using System;
using System.IO;
using System.Runtime.Versioning;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;

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

            var identity = new SecurityIdentifier(WellKnownSidType.BuiltinUsersSid, null);
            var accessRule = new FileSystemAccessRule(identity, FileSystemRights.FullControl, AccessControlType.Allow);

            var security = new FileSecurity();
            security.AddAccessRule(accessRule);

            // Make sure the file does not exist, or FileMode.CreateNew will throw

            string filePath = Path.Combine(Path.GetTempPath(), "temp.txt");
            var fileInfo = new FileInfo(filePath);
            if (fileInfo.Exists)
            {
                fileInfo.Delete();
            }

            // Create the file with the specified security and write some text

            using (FileStream stream = fileInfo.Create(
                FileMode.CreateNew,
                FileSystemRights.FullControl,
                FileShare.ReadWrite,
                4096, // Default buffer size
                FileOptions.None,
                security))
            {
                string text = "Hello world!";
                byte[] writeBuffer = new UTF8Encoding(encoderShouldEmitUTF8Identifier: true).GetBytes(text);

                stream.Write(writeBuffer, 0, writeBuffer.Length);
            } // Dispose flushes the file to disk
        }
    }
}
