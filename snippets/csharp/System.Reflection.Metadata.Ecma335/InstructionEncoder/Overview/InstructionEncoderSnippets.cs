using System;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;

namespace InstructionEncoderSnippets
{
    class InstructionEncoderSnippets
    {
        //<SnippetEmitMethodBody>
        // The following code emits a method body similar to this C# code:

        /*public static double CalcRectangleArea(double length, double width)
        {
            if (length < 0.0)
            {
                throw new ArgumentOutOfRangeException("length");
            }

            if (width < 0.0)
            {
                throw new ArgumentOutOfRangeException("width");
            }

            return length * width;
        }*/
        
        private static InstructionEncoder EmitMethodBody(MetadataBuilder metadata, AssemblyReferenceHandle corlibAssemblyRef)
        {
            var codeBuilder = new BlobBuilder();
            var encoder = new InstructionEncoder(codeBuilder, new ControlFlowBuilder());

            // Get a reference to the System.ArgumentOutOfRangeException type
            TypeReferenceHandle typeRefHandle = metadata.AddTypeReference(
            corlibAssemblyRef,
            metadata.GetOrAddString("System"),
            metadata.GetOrAddString("ArgumentOutOfRangeException"));

            // Signature: .ctor(string)
            var ctorSignature = new BlobBuilder();

            new BlobEncoder(ctorSignature).
                MethodSignature(isInstanceMethod: true).
                Parameters(1, returnType => returnType.Void(), parameters => parameters.AddParameter().Type().String());

            BlobHandle ctorBlobIndex = metadata.GetOrAddBlob(ctorSignature);

            // Get a reference to the System.ArgumentOutOfRangeException constructor
            MemberReferenceHandle ctorMemberRef = metadata.AddMemberReference(
                typeRefHandle,
                metadata.GetOrAddString(".ctor"),
                ctorBlobIndex);

            LabelHandle label1 = encoder.DefineLabel();
            LabelHandle label2 = encoder.DefineLabel();

            // ldarg.0
            encoder.OpCode(ILOpCode.Ldarg_0);

            // ldc.r8 0
            encoder.LoadConstantR8(0);

            // bge.un.s LABEL1
            encoder.Branch(ILOpCode.Bge_un_s, label1);

            // ldstr "length"
            encoder.LoadString(metadata.GetOrAddUserString("length"));

            // newobj instance void [System.Runtime]System.ArgumentOutOfRangeException::.ctor(string)
            encoder.OpCode(ILOpCode.Newobj);
            encoder.Token(ctorMemberRef);

            // throw
            encoder.OpCode(ILOpCode.Throw);

            // LABEL1: ldarg.1
            encoder.MarkLabel(label1);
            encoder.OpCode(ILOpCode.Ldarg_1);

            // ldc.r8 0
            encoder.LoadConstantR8(0);

            // bge.un.s LABEL2
            encoder.Branch(ILOpCode.Bge_un_s, label2);

            // ldstr "width"
            encoder.LoadString(metadata.GetOrAddUserString("width"));

            // newobj instance void [System.Runtime]System.ArgumentOutOfRangeException::.ctor(string)
            encoder.OpCode(ILOpCode.Newobj);
            encoder.Token(ctorMemberRef);

            // throw
            encoder.OpCode(ILOpCode.Throw);

            // LABEL2: ldarg.0
            encoder.MarkLabel(label2);
            encoder.OpCode(ILOpCode.Ldarg_0);

            // ldarg.1
            encoder.OpCode(ILOpCode.Ldarg_1);

            // mul
            encoder.OpCode(ILOpCode.Mul);

            // ret
            encoder.OpCode(ILOpCode.Ret);

            return encoder;
        }
        //</SnippetEmitMethodBody>

        public static void Run()
        {
            MetadataBuilder metadata = new MetadataBuilder();
            
            AssemblyReferenceHandle corlibAssemblyRef = metadata.AddAssemblyReference(
                name: metadata.GetOrAddString("System.Runtime"),
                version: new Version(4, 0, 0, 0),
                culture: default(StringHandle),
                publicKeyOrToken: default(BlobHandle),
                flags: default(AssemblyFlags),
                hashValue: default(BlobHandle));

            EmitMethodBody(metadata, corlibAssemblyRef);            
        }
    }
}
