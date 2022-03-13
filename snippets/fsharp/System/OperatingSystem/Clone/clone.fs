//<Snippet1>
// Example for the OperatingSystem.Clone method.
open System

// Copy, clone, and duplicate an OperatingSystem object.
let copyOperatingSystemObjects () =
    // The Version object does not need to correspond to an
    // actual OS version.
    let verMMBVer = Version(5, 6, 7, 8)

    let opCreate1 = OperatingSystem(PlatformID.Win32NT, verMMBVer)

    // Create another OperatingSystem object with the same
    // parameters as opCreate1.
    let opCreate2 = OperatingSystem(PlatformID.Win32NT, verMMBVer)

    // Clone opCreate1 and copy the opCreate1 reference.
    let opClone = opCreate1.Clone() :?> OperatingSystem
    let opCopy = opCreate1

    // Compare the various objects for equality.
    printfn "%-50s%O" "Is the second object the same as the original?" (opCreate1.Equals opCreate2)
    printfn "%-50s%O" "Is the object clone the same as the original?" (opCreate1.Equals opClone)
    printfn "%-50s%O" "Is the copied object the same as the original?" (opCreate1.Equals opCopy)

printfn
    """This example of OperatingSystem.Clone( ) generates the following output.
    
Create an OperatingSystem object, and then create another object with the
same parameters. Clone and copy the original object, and then compare
each object with the original using the Equals( ) method. Equals( )
returns true only when both references refer to the same object.
"""

copyOperatingSystemObjects ()

// This example of OperatingSystem.Clone( ) generates the following output.
//
// Create an OperatingSystem object, and then create another object with the
// same parameters. Clone and copy the original object, and then compare
// each object with the original using the Equals( ) method. Equals( )
// returns true only when both references refer to the same object.
//
// Is the second object the same as the original?    False
// Is the object clone the same as the original?     False
// Is the copied object the same as the original?    True
//</Snippet1>