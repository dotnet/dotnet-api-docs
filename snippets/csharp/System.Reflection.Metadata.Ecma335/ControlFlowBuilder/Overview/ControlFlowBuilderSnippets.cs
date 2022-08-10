using System;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;

namespace ControlFlowBuilderSnippets
{
    public class ControlFlowBuilderSnippets
    {
        //<SnippetControlFlowBuilder>
        // The following code emits method body similar to this C# code:

        /* public static void ExceptionBlockTest(int x, int y)
           {
              try
              {
                 Console.WriteLine(x / y);
              }
              catch (DivideByZeroException)
              {
                 Console.WriteLine("Error: division by zero");
              }
           }
        */

        public static InstructionEncoder ControlFlowBuilderDemo(MetadataBuilder metadata, 
            AssemblyReferenceHandle corlibAssemblyRef)
        {
            var codeBuilder = new BlobBuilder();
            var flowBuilder = new ControlFlowBuilder();
            var encoder = new InstructionEncoder(codeBuilder, flowBuilder);

            // Get reference to System.Console
            AssemblyReferenceHandle systemConsoleAssemblyRef = metadata.AddAssemblyReference(
                name: metadata.GetOrAddString("System.Console"),
                version: new Version(4, 0, 0, 0),
                culture: default(StringHandle),
                publicKeyOrToken: default(BlobHandle),
                flags: default(AssemblyFlags),
                hashValue: default(BlobHandle));
            
            TypeReferenceHandle consoleTypeRefHandle = metadata.AddTypeReference(
                systemConsoleAssemblyRef,
                metadata.GetOrAddString("System"),
                metadata.GetOrAddString("Console"));

            // Get reference to void System.Console::WriteLine(int32)
            var methodSignature = new BlobBuilder();

            new BlobEncoder(methodSignature).
                MethodSignature(isInstanceMethod: false).
                Parameters(1, returnType => returnType.Void(), parameters => parameters.AddParameter().Type().Int32());

            BlobHandle sigBlobIndex1 = metadata.GetOrAddBlob(methodSignature);

            MemberReferenceHandle refWriteLineInt32 = metadata.AddMemberReference(
                consoleTypeRefHandle,
                metadata.GetOrAddString("WriteLine"),
                sigBlobIndex1);

            // Get reference to void System.Console::WriteLine(string)
            methodSignature = new BlobBuilder();

            new BlobEncoder(methodSignature).
                MethodSignature(isInstanceMethod: false).
                Parameters(1, returnType => returnType.Void(), parameters => parameters.AddParameter().Type().String());

            BlobHandle sigBlobIndex2 = metadata.GetOrAddBlob(methodSignature);

            MemberReferenceHandle refWriteLineString = metadata.AddMemberReference(
                consoleTypeRefHandle,
                metadata.GetOrAddString("WriteLine"),
                sigBlobIndex2);

            // Get reference to System.DivideByZeroException
            TypeReferenceHandle exceptionTypeRefHandle = metadata.AddTypeReference(
                corlibAssemblyRef,
                metadata.GetOrAddString("System"),
                metadata.GetOrAddString("DivideByZeroException"));
            
            LabelHandle labelTryStart = encoder.DefineLabel();
            LabelHandle labelTryEnd = encoder.DefineLabel();
            LabelHandle labelCatchStart = encoder.DefineLabel();
            LabelHandle labelCatchEnd = encoder.DefineLabel();
            LabelHandle labelExit = encoder.DefineLabel();

            flowBuilder.AddCatchRegion(labelTryStart, labelTryEnd, labelCatchStart, labelCatchEnd,
                exceptionTypeRefHandle);

            // .try {
            encoder.MarkLabel(labelTryStart);

            // ldarg.0
            encoder.OpCode(ILOpCode.Ldarg_0);

            // ldarg.1
            encoder.OpCode(ILOpCode.Ldarg_1);

            // div
            encoder.OpCode(ILOpCode.Div);

            // call void [System.Console]System.Console::WriteLine(int32)
            encoder.Call(refWriteLineInt32);

            // leave.s EXIT            
            encoder.Branch(ILOpCode.Leave_s, labelExit);
            encoder.MarkLabel(labelTryEnd);

            // } 
            // catch [System.Runtime]System.DivideByZeroException {
            encoder.MarkLabel(labelCatchStart);

            // pop
            encoder.OpCode(ILOpCode.Pop);
            
            // ldstr "Error: division by zero"
            encoder.LoadString(metadata.GetOrAddUserString("Error: division by zero"));

            // call void [System.Console]System.Console::WriteLine(string)
            encoder.Call(refWriteLineString);

            // leave.s EXIT            
            encoder.Branch(ILOpCode.Leave_s, labelExit);
            encoder.MarkLabel(labelCatchEnd);

            // } EXIT: ret
            encoder.MarkLabel(labelExit);
            encoder.OpCode(ILOpCode.Ret);
            
            return encoder;
        }
        //</SnippetControlFlowBuilder>
        
        public static void Run()
        {
            var metadataBuilder = new MetadataBuilder();

            AssemblyReferenceHandle corlibAssemblyRef = metadataBuilder.AddAssemblyReference(
                name: metadataBuilder.GetOrAddString("System.Runtime"),
                version: new Version(4, 0, 0, 0),
                culture: default(StringHandle),
                publicKeyOrToken: default(BlobHandle),
                flags: default(AssemblyFlags),
                hashValue: default(BlobHandle));

            ControlFlowBuilderDemo(metadataBuilder, corlibAssemblyRef);
        }
    }
}
