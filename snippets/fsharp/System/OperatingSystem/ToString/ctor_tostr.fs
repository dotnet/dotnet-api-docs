//<Snippet1>
// Example for the OperatingSystem constructor and the
// OperatingSystem.ToString( ) method.
open System

// Create and display an OperatingSystem object.
let buildOSObj pID ver =
    let os = OperatingSystem(pID, ver)
    // String Interpolation calls .ToString()
    printfn $"   {os}"

let buildOperatingSystemObjects () =
    // The Version object does not need to correspond to an
    // actual OS version.
    let verNull   = Version()
    let verMajMin = Version(3, 11)
    let verMMBld  = Version(5, 25, 625)
    let verMMBVer = Version(5, 6, 7, 8)
    let verString = Version("3.5.8.13")

    // All PlatformID members are shown here.
    buildOSObj PlatformID.Win32NT verNull
    buildOSObj PlatformID.Win32S verMajMin
    buildOSObj PlatformID.Win32Windows verMMBld
    buildOSObj PlatformID.WinCE verMMBVer
    buildOSObj PlatformID.Win32NT verString

printfn "This example of the OperatingSystem constructor and \nOperatingSystem.ToString( ) generates the following output.\n"
printfn "Create and display several different OperatingSystem objects:\n"

buildOperatingSystemObjects ()

printfn $"\nThe OS version of the host computer is:\n\n   {Environment.OSVersion}"

// This example of the OperatingSystem constructor and
// OperatingSystem.ToString( ) generates the following output.
//
// Create and display several different OperatingSystem objects:
//
//    Microsoft Windows NT 0.0
//    Microsoft Win32S 3.11
//    Microsoft Windows 98 5.25.625
//    Microsoft Windows CE 5.6.7.8
//    Microsoft Windows NT 3.5.8.13
//
// The OS version of the host computer is:
//
//    Microsoft Windows NT 5.1.2600.0
//</Snippet1>