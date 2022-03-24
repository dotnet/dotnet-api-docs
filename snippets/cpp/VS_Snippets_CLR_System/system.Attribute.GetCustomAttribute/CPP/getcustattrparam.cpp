
//<Snippet1>
// Example for the Attribute::GetCustomAttribute( ParameterInfo*, Type* ) 
// method.
using namespace System;
using namespace System::Collections;
using namespace System::Reflection;

namespace NDP_UE_CPP
{

   //<Snippet2> 
   // Define a custom parameter attribute that takes a single message argument.

   [AttributeUsage(AttributeTargets::Parameter)]
   public ref class ArgumentUsageAttribute: public Attribute
   {
   protected:

      // usageMsg is storage for the attribute message.
      String^ usageMsg;

   public:

      // This is the attribute constructor.
      ArgumentUsageAttribute( String^ UsageMsg )
      {
         this->usageMsg = UsageMsg;
      }


      property String^ Message 
      {
         // This is the Message property for the attribute.
         String^ get()
         {
            return usageMsg;
         }

         void set( String^ value )
         {
            this->usageMsg = value;
         }
      }
   };
   //</Snippet2>

   public ref class BaseClass
   {
   public:

      // Assign an ArgumentUsage attribute to the strArray parameter.
      // Assign a ParamArray attribute to strList.
      virtual void TestMethod( [ArgumentUsage("Must pass an array here.")]array<String^>^strArray,
                               ...array<String^>^strList ){}
   };

   public ref class DerivedClass: public BaseClass
   {
   public:

      // Assign an ArgumentUsage attributes to the strList parameter.
      virtual void TestMethod( array<String^>^strArray, [ArgumentUsage(
      "Can pass a parameter list or array here.")]array<String^>^strList ) override {}
   };
}

int main()
{
   Console::WriteLine( "This example of Attribute::GetCustomAttribute( Param"
   "eterInfo*, Type* )\ngenerates the following output." );

   // Get the class type, and then get the MethodInfo object 
   // for TestMethod to access its metadata.
   Type^ clsType = NDP_UE_CPP::DerivedClass::typeid;
   MethodInfo^ mInfo = clsType->GetMethod( "TestMethod" );

   // Iterate through the ParameterInfo array for the method parameters.
   array<ParameterInfo^>^pInfoArray = mInfo->GetParameters();
   if ( pInfoArray != nullptr )
   {
      // This implements foreach( ParameterInfo* paramInfo in pInfoArray ).
      IEnumerator^ myEnum = pInfoArray->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         ParameterInfo^ paramInfo = safe_cast<ParameterInfo^>(myEnum->Current);

         // See if the ParamArray attribute is defined.
         bool isDef = Attribute::IsDefined( paramInfo, ParamArrayAttribute::typeid );
         if ( isDef )
                  Console::WriteLine( "\nThe ParamArray attribute is defined for \n"
         "parameter {0} of method {1}.", paramInfo->Name, mInfo->Name );

         // See if ParamUsageAttribute is defined.  
         // If so, display a message.
         NDP_UE_CPP::ArgumentUsageAttribute^ usageAttr = static_cast<NDP_UE_CPP::ArgumentUsageAttribute^>(Attribute::GetCustomAttribute( paramInfo, NDP_UE_CPP::ArgumentUsageAttribute::typeid ));
         if ( usageAttr != nullptr )
         {
            Console::WriteLine( "\nThe ArgumentUsage attribute is defined for \n"
            "parameter {0} of method {1}.", paramInfo->Name, mInfo->Name );
            Console::WriteLine( "\n    The usage "
            "message for {0} is:\n    \"{1}\".", paramInfo->Name, usageAttr->Message );
         }
      }
   }
   else
      Console::WriteLine( "The parameters information could "
   "not be retrieved for method {0}.", mInfo->Name );
}

/*
This example of Attribute::GetCustomAttribute( ParameterInfo*, Type* )
generates the following output.

The ArgumentUsage attribute is defined for
parameter strArray of method TestMethod.

    The usage message for strArray is:
    "Must pass an array here.".

The ParamArray attribute is defined for
parameter strList of method TestMethod.

The ArgumentUsage attribute is defined for
parameter strList of method TestMethod.

    The usage message for strList is:
    "Can pass a parameter list or array here.".
*/
//</Snippet1>
