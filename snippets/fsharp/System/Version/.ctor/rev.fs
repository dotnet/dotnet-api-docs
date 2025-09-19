//<snippet1>
// This example demonstrates the Version.Revision,
// MajorRevision, and MinorRevision properties.
open System

let std = Version(2, 4, 1128, 2)
let interim = Version(2, 4, 1128, (100 <<< 16) + 2)

printfn $"Standard version:\n  major.minor.build.revision = {std.Major}.{std.Minor}.{std.Build}.{std.Revision}"
printfn $"Interim version:\n  major.minor.build.majRev/minRev = {interim.Major}.{interim.Minor}.{interim.Build}.{interim.MajorRevision}/{interim.MinorRevision}"

// This code example produces the following results:
//     Standard version:
//       major.minor.build.revision = 2.4.1128.2
//     Interim version:
//       major.minor.build.majRev/minRev = 2.4.1128.100/2
//</snippet1>