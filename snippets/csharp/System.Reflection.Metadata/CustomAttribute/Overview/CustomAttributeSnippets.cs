using System;
using System.IO;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;

static class CustomAttributeSnippets
{
    // <SnippetPrintAttributes>
    class MyAttribute : Attribute
    {
        public int X { get; set; }
    }

    [My(X = 1)]
    class ExampleType1 { }

    [My(X = 2)]
    class ExampleType2 { }

    static void PrintCustomAttributes(MetadataReader mr, TypeDefinition t)
    {
        // Enumerate custom attributes on the type definition
        foreach (CustomAttributeHandle attrHandle in t.GetCustomAttributes())
        {
            CustomAttribute attr = mr.GetCustomAttribute(attrHandle);

            // Display the attribute type full name
            if (attr.Constructor.Kind == HandleKind.MethodDefinition)
            {
                MethodDefinition mdef = mr.GetMethodDefinition((MethodDefinitionHandle)attr.Constructor);
                TypeDefinition tdef = mr.GetTypeDefinition(mdef.GetDeclaringType());
                Console.WriteLine($"Type:  {mr.GetString(tdef.Namespace)}.{mr.GetString(tdef.Name)}");
            }
            else if (attr.Constructor.Kind == HandleKind.MemberReference)
            {
                MemberReference mref = mr.GetMemberReference((MemberReferenceHandle)attr.Constructor);

                if (mref.Parent.Kind == HandleKind.TypeReference)
                {
                    TypeReference tref = mr.GetTypeReference((TypeReferenceHandle)mref.Parent);
                    Console.WriteLine($"Type:  {mr.GetString(tref.Namespace)}.{mr.GetString(tref.Name)}");
                }
                else if (mref.Parent.Kind == HandleKind.TypeDefinition)
                {
                    TypeDefinition tdef = mr.GetTypeDefinition((TypeDefinitionHandle)mref.Parent);
                    Console.WriteLine($"Type:  {mr.GetString(tdef.Namespace)}.{mr.GetString(tdef.Name)}");
                }
            }

            // Display the attribute value
            byte[] data = mr.GetBlobBytes(attr.Value);
            Console.Write("Value: ");

            for (int i = 0; i < data.Length; i++) Console.Write($"{data[i]:X2} ");

            Console.WriteLine();
        }
    }

    static void PrintTypesCustomAttributes(MetadataReader mr)
    {
        foreach (TypeDefinitionHandle tdh in mr.TypeDefinitions)
        {
            TypeDefinition t = mr.GetTypeDefinition(tdh);
            Console.WriteLine($"{mr.GetString(t.Namespace)}.{mr.GetString(t.Name)}");
            PrintCustomAttributes(mr, t);
        }
    }
    // </SnippetPrintAttributes>

    public static void Run()
    {
        using var fs = new FileStream(typeof(Program).Assembly.Location, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        using var peReader = new PEReader(fs);
        MetadataReader mr = peReader.GetMetadataReader();
        PrintTypesCustomAttributes(mr);
    }
}
