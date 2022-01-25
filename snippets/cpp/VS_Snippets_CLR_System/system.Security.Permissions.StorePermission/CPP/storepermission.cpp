

//<SNIPPET1>
#using <System.dll>
#using <System.Security.dll>

using namespace System;
using namespace System::Security::Permissions;
using namespace System::Security::Cryptography;
using namespace System::Security::Cryptography::X509Certificates;
using namespace System::Security;
using namespace System::IO;

[assembly:StorePermissionAttribute(SecurityAction::RequestMinimum,
Flags=StorePermissionFlags::DeleteStore)];
void AddToStore( X509Certificate2 ^ cert );
void ShowMembers();
int main()
{
   
   //<Snippet2>
   Console::WriteLine( "Creating a permission with Flags = OpenStore." );
   StorePermission^ sp = gcnew StorePermission( StorePermissionFlags::OpenStore );
   
   //</Snippet2>
   //Create a new X509 store named teststore from the local certificate store.
   //You must put in a valid path to a certificate in the following constructor.
   X509Certificate2^ certificate = gcnew X509Certificate2( "c:\\certificates\\*****.cer" );

   //      Deny the permission to open a store.
   sp->Deny();

   // The following code results in an exception due to an attempt to open a store.
   AddToStore( certificate );

   // Remove the deny for opening a store.
   CodeAccessPermission::RevertDeny();

   // The following code results in an exception due to an attempt to add a certificate.
   // The exception is thrown due to a StorePermissionAttribute on the method denying AddToStore permission.
   AddToStore( certificate );

   // The current code is not affected by the attribute in the previously called method, so the following
   // intructions execute without an exception.
   X509Store^ store = gcnew X509Store( "teststore",StoreLocation::CurrentUser );
   store->Open( OpenFlags::ReadWrite );
   store->Add( certificate );

   // Demonstrate the behavior of the class members.
   ShowMembers();
   Console::WriteLine( "Press the Enter key to exit." );
   Console::ReadKey();
}


//<Snippet8>
//Deny the permission the ability to add to a store.

[StorePermission(SecurityAction::Deny,Flags=StorePermissionFlags::AddToStore)]
void AddToStore( X509Certificate2^ cert )
{
   try
   {
      X509Store^ store = gcnew X509Store( "teststore",StoreLocation::CurrentUser );
      store->Open( OpenFlags::ReadWrite );

      // The following attempt to add a certificate results in an exception being thrown.
      store->Add( cert );
      return;
   }
   catch ( SecurityException^ e )
   {
      Console::WriteLine( "Security exception thrown when attempting: {0}",
		  (dynamic_cast<StorePermission^>(e->FirstPermissionThatFailed))->Flags );
      return;
   }

}


//</Snippet8>
// The following function is intended to demonstrate only the behavior of
// StorePermission class members,and not their practical usage.  Most properties
// and methods in this class are used for the resolution and enforcement of
// security policy by the security infrastructure code.
void ShowMembers()
{
   Console::WriteLine( "Creating first permission with Flags = OpenStore." );
   StorePermission^ sp1 = gcnew StorePermission( StorePermissionFlags::OpenStore );
   Console::WriteLine( "Creating second permission with Flags = AllFlags." );
   StorePermission^ sp2 = gcnew StorePermission( StorePermissionFlags::AllFlags );
   Console::WriteLine( "Creating third permission as Unrestricted." );

   //<Snippet9>
   StorePermission^ sp3 = gcnew StorePermission( PermissionState::Unrestricted );

   //</Snippet9>
   Console::WriteLine( "Creating fourth permission with a permission state of none." );
   StorePermission^ sp4 = gcnew StorePermission( PermissionState::None );

   //<Snippet3>
   bool rc = sp2->IsSubsetOf( sp3 );
   Console::WriteLine( "Is the permission with complete store access (AllFlags) a subset of \n"
   "\tthe permission with an Unrestricted permission state? {0}", (rc ? (String^)"Yes" : "No") );
   rc = sp1->IsSubsetOf( sp2 );
   Console::WriteLine( "Is the permission with OpenStore access a subset of the permission with \n"
   "\tcomplete store access (AllFlags)? {0}", (rc ? (String^)"Yes" : "No") );

   //</Snippet3>
   //<Snippet4>
   rc = sp3->IsUnrestricted();
   Console::WriteLine( "Is the third permission unrestricted? {0}", (rc ? (String^)"Yes" : "No") );

   //</Snippet4>
   //<Snippet5>
   Console::WriteLine( "Copying the second permission to the fourth permission." );
   sp4 = dynamic_cast<StorePermission^>(sp2->Copy());
   rc = sp4->Equals( sp2 );
   Console::WriteLine( "Is the fourth permission equal to the second permission? {0}", (rc ? (String^)"Yes" : "No") );

   //</Snippet5>
   //<Snippet10>
   Console::WriteLine( "Creating the intersection of the second and first permissions." );
   sp4 = dynamic_cast<StorePermission^>(sp2->Intersect( sp1 ));
   Console::WriteLine( "Value of the Flags property is: {0}", sp4->Flags );

   //</Snippet10>
   //<Snippet6>
   Console::WriteLine( "Creating the union of the second and first permissions." );
   sp4 = dynamic_cast<StorePermission^>(sp2->Union( sp1 ));
   Console::WriteLine( "Result of the union of the second permission with the first:  {0}", sp4->Flags );

   //</Snippet6>
   //<Snippet7>
   Console::WriteLine( "Using an XML roundtrip to reset the fourth permission." );
   sp4->FromXml( sp2->ToXml() );
   rc = sp4->Equals( sp2 );
   Console::WriteLine( "Does the XML roundtrip result equal the original permission? {0}", (rc ? (String^)"Yes" : "No") );

   //</Snippet7>
}

//</SNIPPET1>
