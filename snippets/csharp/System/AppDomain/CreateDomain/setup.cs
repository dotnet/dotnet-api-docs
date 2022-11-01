using System;
using System.Security.Policy;

class CreateDomainSnippet1 {

   public static void Main() {
      // <Snippet1>
      // Set up the AppDomainSetup
      AppDomainSetup setup = new AppDomainSetup();
      setup.ApplicationBase = "(some directory)";
      setup.ConfigurationFile = "(some file)";

      // Set up the Evidence
      Evidence baseEvidence = AppDomain.CurrentDomain.Evidence;
      Evidence evidence = new Evidence(baseEvidence);
      evidence.AddAssembly("(some assembly)");
      evidence.AddHost("(some host)");

      // Create the AppDomain
      AppDomain newDomain = AppDomain.CreateDomain("newDomain", evidence, setup);
      // </Snippet1>
   }
}
