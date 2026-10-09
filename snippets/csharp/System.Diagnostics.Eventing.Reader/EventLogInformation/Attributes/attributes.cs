using System.Diagnostics.Eventing.Reader;
using System.IO;

using EventLogSession session = new();
EventLogInformation eventLogInformation =
    session.GetLogInformation("Application", PathType.LogName);

// <snippet1>
FileAttributes? fileAttributes = (FileAttributes?)eventLogInformation.Attributes;
// </snippet1>
