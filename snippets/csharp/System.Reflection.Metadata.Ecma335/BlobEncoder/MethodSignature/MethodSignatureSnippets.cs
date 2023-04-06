using System;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Reflection;

namespace MethodSignatureSnippets
{
    static class MethodSignatureSnippets
    {
        // <SnippetEncodeSignatures>
        static BlobBuilder EncodeMethodSignatureParameterless()
        {
            // void Method()
            var methodSignature = new BlobBuilder();

            new BlobEncoder(methodSignature).
                MethodSignature().
                Parameters(0, returnType => returnType.Void(), parameters => { });
            
            return methodSignature;
        }

        static BlobBuilder EncodeMethodSignaturePrimitiveTypes()
        {
            // double Method(double x, double y)
            var methodSignature = new BlobBuilder();

            new BlobEncoder(methodSignature).
                MethodSignature().
                Parameters(2, returnType => returnType.Type().Double(),
                parameters => {
                    parameters.AddParameter().Type().Double();
                    parameters.AddParameter().Type().Double();
                });

            return methodSignature;
        }

        static BlobBuilder EncodeMethodSignatureClassType(MetadataBuilder metadataBuilder)
        {
            // void Method(System.Threading.Thread x)
            var methodSignature = new BlobBuilder();
            
            AssemblyReferenceHandle mscorlibAssemblyRef = metadataBuilder.AddAssemblyReference(
                name: metadataBuilder.GetOrAddString("System.Threading.Thread"),
                version: new Version(4, 0, 0, 0),
                culture: default(StringHandle),
                publicKeyOrToken: default(BlobHandle),
                flags: default(AssemblyFlags),
                hashValue: default(BlobHandle));

            TypeReferenceHandle typeRef = metadataBuilder.AddTypeReference(
                mscorlibAssemblyRef,
                metadataBuilder.GetOrAddString("System.Threading"),
                metadataBuilder.GetOrAddString("Thread"));

            new BlobEncoder(methodSignature).
                MethodSignature().
                Parameters(1, returnType => returnType.Void(),
                parameters => {
                    parameters.AddParameter().Type().Type(typeRef, false);
                });

            return methodSignature;
        }

        static BlobBuilder EncodeMethodSignatureModifiedTypes()
        {
            // void Method(ref int x, int[] y)
            var methodSignature = new BlobBuilder();

            new BlobEncoder(methodSignature).
                MethodSignature().
                Parameters(2, returnType => returnType.Void(),
                parameters => {
                    parameters.AddParameter().Type(isByRef: true).Int32();
                    parameters.AddParameter().Type().SZArray().Int32();
                });

            return methodSignature;
        }
        
        public static BlobBuilder EncodeMethodSignatureGeneric()
        {
            // void Method<T>(T x)
            var methodSignature = new BlobBuilder();

            new BlobEncoder(methodSignature).
                MethodSignature(genericParameterCount: 1).
                Parameters(1, returnType => returnType.Void(),
                parameters => {
                    parameters.AddParameter().Type().GenericMethodTypeParameter(0);
                });

            return methodSignature;
        }
        // </SnippetEncodeSignatures>

        public static void Run()
        {
            var metadataBuilder = new MetadataBuilder();
            EncodeMethodSignatureParameterless();
            EncodeMethodSignaturePrimitiveTypes();
            EncodeMethodSignatureClassType(metadataBuilder);
            EncodeMethodSignatureModifiedTypes();
            EncodeMethodSignatureGeneric();
        }
    }
}
