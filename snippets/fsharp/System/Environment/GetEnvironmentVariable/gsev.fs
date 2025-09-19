module Sample

open System

// Environment variable names for default, process, user, and machine targets.
let rec defaultEnvVar = nameof defaultEnvVar
let rec processEnvVar = nameof processEnvVar
let rec userEnvVar = nameof userEnvVar
let rec machineEnvVar = nameof machineEnvVar

let rec dft = nameof dft
let rec proc = nameof proc
let rec user = nameof user
let rec machine = nameof machine

// Set the environment variable for each target.
printfn "Setting environment variables for each target...\n"
// The default target (the current process).
Environment.SetEnvironmentVariable(defaultEnvVar, dft)
// The current process.
Environment.SetEnvironmentVariable(processEnvVar, proc, EnvironmentVariableTarget.Process)
// The current user.
Environment.SetEnvironmentVariable(userEnvVar, user, EnvironmentVariableTarget.User)
// The local machine.
Environment.SetEnvironmentVariable(machineEnvVar, machine, EnvironmentVariableTarget.Machine)

// Define a list of environment variables.
let envVars = [ defaultEnvVar; processEnvVar; userEnvVar; machineEnvVar ]

// Try to get the environment variables from each target.
// The default (no specified target).
printfn "Retrieving environment variables from the default target:"
for envVar in envVars do
    let value = 
        match Environment.GetEnvironmentVariable envVar with
        | null -> "(none)"
        | v -> v
    printfn $"   {envVar}: {value}"

// The process block.
printfn "\nRetrieving environment variables from the Process target:"
for envVar in envVars do
    let value = 
        match Environment.GetEnvironmentVariable(envVar, EnvironmentVariableTarget.Process) with
        | null -> "(none)"
        | v -> v
    printfn $"   {envVar}: {value}"

// The user block.
printfn "\nRetrieving environment variables from the User target:"
for envVar in envVars do
    let value = 
        match Environment.GetEnvironmentVariable(envVar, EnvironmentVariableTarget.User) with
        | null -> "(none)"
        | v -> v
    printfn $"   {envVar}: {value}"

// The machine block.
printfn "\nRetrieving environment variables from the Machine target:"
for envVar in envVars do
    let value = 
        match Environment.GetEnvironmentVariable(envVar, EnvironmentVariableTarget.Machine) with
        | null -> "(none)"
        | v -> v
    printfn $"   {envVar}: {value}"

// Delete the environment variable for each target.
printfn "\nDeleting environment variables for each target...\n"
// The default target (the current process).
Environment.SetEnvironmentVariable(defaultEnvVar, null)
// The current process.
Environment.SetEnvironmentVariable(processEnvVar, null, EnvironmentVariableTarget.Process)
// The current user.
Environment.SetEnvironmentVariable(userEnvVar, null, EnvironmentVariableTarget.User)
// The local machine.
Environment.SetEnvironmentVariable(machineEnvVar, null, EnvironmentVariableTarget.Machine)

// The example displays the following output if run on a Windows system:
//      Setting environment variables for each target...
//
//      Retrieving environment variables from the default target:
//        defaultEnvVar: dft
//        processEnvVar: process
//        userEnvVar: user
//        machineEnvVar: (none)
//
//      Retrieving environment variables from the Process target:
//        defaultEnvVar: dft
//        processEnvVar: process
//        userEnvVar: user
//        machineEnvVar: (none)
//
//      Retrieving environment variables from the User target:
//        defaultEnvVar: (none)
//        processEnvVar: (none)
//        userEnvVar: user
//        machineEnvVar: (none)
//
//      Retrieving environment variables from the Machine target:
//        defaultEnvVar: (none)
//        processEnvVar: (none)
//        userEnvVar: (none)
//        machineEnvVar: machine
//
//      Deleting environment variables for each target...
//
// The example displays the following output if run on a Unix-based system:
//
//      Setting environment variables for each target...
//
//      Retrieving environment variables from the default target:
//        defaultEnvVar: dft
//        processEnvVar: process
//        userEnvVar: (none)
//        machineEnvVar: (none)
//
//      Retrieving environment variables from the Process target:
//        defaultEnvVar: dft
//        processEnvVar: process
//        userEnvVar: (none)
//        machineEnvVar: (none)
//
//      Retrieving environment variables from the User target:
//        defaultEnvVar: (none)
//        processEnvVar: (none)
//        userEnvVar: (none)
//        machineEnvVar: (none)
//
//      Retrieving environment variables from the Machine target:
//        defaultEnvVar: (none)
//        processEnvVar: (none)
//        userEnvVar: (none)
//        machineEnvVar: (none)
//
//      Deleting environment variables for each target...