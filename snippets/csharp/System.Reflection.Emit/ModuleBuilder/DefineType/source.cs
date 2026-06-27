using System;
using System.Reflection;
using System.Reflection.Emit;

public class Sample
{
 public void Method()
 {
// <Snippet1>
 AssemblyName asmname = new AssemblyName();
 asmname.Name = "assemfilename.exe";
 AssemblyBuilder asmbuild =
             AssemblyBuilder.DefineDynamicAssembly(asmname, AssemblyBuilderAccess.Run);
 ModuleBuilder modbuild = asmbuild.DefineDynamicModule("modulename");
 TypeBuilder typebuild1 = modbuild.DefineType( "typename" );
 typebuild1.CreateType();
// </Snippet1>
 }
}
