// <Snippet1>
open System
open System.Security.Policy

// Set up the AppDomainSetup
let setup = AppDomainSetup()
setup.ApplicationBase <- "(some directory)"
setup.ConfigurationFile <- "(some file)"

// Set up the Evidence
let baseEvidence = AppDomain.CurrentDomain.Evidence
let evidence = Evidence baseEvidence
evidence.AddAssembly "(some assembly)"
evidence.AddHost "(some host)" 

// Create the AppDomain
let newDomain = AppDomain.CreateDomain("newDomain", evidence, setup)
// </Snippet1>