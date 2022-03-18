//<Snippet1>
// Example for the OperatingSystem.Platform and
// OperatingSystem.Version properties.
open System

// Create an OperatingSystem object and display the Platform
// and Version properties.
let buildOSObj pID ver =
    let opSys = OperatingSystem(pID, ver)
    let platform = opSys.Platform
    let version = opSys.Version

    printfn $"   Platform: {platform,-15} Version: {version}"

let buildOperatingSystemObjects () =
    // The Version object does not need to correspond to an
    // actual OS version.
    let verNull   = Version()
    let verString = Version("3.5.8.13")
    let verMajMin = Version(6, 10)
    let verMMBld  = Version(5, 25, 5025)
    let verMMBVer = Version(5, 6, 7, 8)

    // All PlatformID members are shown here.
    buildOSObj PlatformID.Win32NT verNull
    buildOSObj PlatformID.Win32S verString
    buildOSObj PlatformID.Win32Windows verMajMin
    buildOSObj PlatformID.WinCE verMMBld
    buildOSObj PlatformID.Win32NT verMMBVer

printfn "This example of OperatingSystem.Platform and OperatingSystem.Version \ngenerates the following output.\n"
printfn  "Create several OperatingSystem objects and display their properties:\n"

buildOperatingSystemObjects ()

printfn "\nThe operating system of the host computer is:\n" 

buildOSObj Environment.OSVersion.Platform Environment.OSVersion.Version

// This example of OperatingSystem.Platform and OperatingSystem.Version
// generates the following output.
//
// Create several OperatingSystem objects and display their properties:
//
// Platform: Win32NT         Version: 0.0
// Platform: Win32S          Version: 3.5.8.13
// Platform: Win32Windows    Version: 6.10
// Platform: WinCE           Version: 5.25.5025
// Platform: Win32NT         Version: 5.6.7.8
//
// The operating system of the host computer is:
//
// Platform: Win32NT         Version: 5.1.2600.0
//</Snippet1>