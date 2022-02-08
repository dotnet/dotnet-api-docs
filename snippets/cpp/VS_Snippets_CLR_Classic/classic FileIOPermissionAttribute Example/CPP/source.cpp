using namespace System;
using namespace System::Security::Permissions;

namespace Snippet1
{
// <Snippet1>
[FileIOPermissionAttribute(SecurityAction::PermitOnly,ViewAndModify="C:\\example\\sample.txt")]
// </Snippet1>
   public ref class SampleClass{};
}
namespace Snippet2
{
// <Snippet2>
 [FileIOPermissionAttribute(SecurityAction::Demand,Unrestricted=true)]
// </Snippet2>
   public ref class SampleClass{};
}

namespace Snippet3
{
// <Snippet3>
 //[FileIOPermissionAttribute(SecurityAction::Assert,Unrestricted=true)]
// </Snippet3>
   public ref class SampleClass{};
}
