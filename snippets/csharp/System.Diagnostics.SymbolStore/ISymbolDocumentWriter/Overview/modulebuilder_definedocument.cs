using System;
using System.Diagnostics.SymbolStore;
using System.Reflection;
using System.Reflection.Emit;

// <Snippet1>
AssemblyName assemblyName = new("TempAssembly");
PersistedAssemblyBuilder assemblyBuilder = new(assemblyName, typeof(object).Assembly);
ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("TempModule");

ISymbolDocumentWriter document = moduleBuilder.DefineDocument(
    "RTAsm.il",
    SymLanguageType.ILAssembly,
    SymLanguageVendor.Microsoft,
    SymDocumentType.Text);

Console.WriteLine($"The object representing the defined document is:{document}");
// </Snippet1>
