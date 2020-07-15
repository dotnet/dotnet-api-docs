﻿/*
   System.Type.GetInterface(String)
   System.Type.GetInterface(String, bool)
   System.Type.GetInterfaceMap

   The following program get the type of Hashtable class and searches for the interface
   with the specified name. Then prints the method name of that interface.
*/

using System;
using System.Reflection;
using System.Collections;

class MyInterfaceClass
{
// <Snippet1>
// <Snippet2>
// <Snippet3>
    public static void Main()
    {
        Hashtable hashtableObj = new Hashtable();
        Type objType = hashtableObj.GetType();
        MethodInfo[] arrayMethodInfo;
        MemberInfo[] arrayMemberInfo;
        try
        {
            // Get the methods implemented in 'IDeserializationCallback' interface.
            arrayMethodInfo =objType.GetInterface("IDeserializationCallback").GetMethods();
            Console.WriteLine ("\nMethods of 'IDeserializationCallback' Interface :");
            foreach(MethodInfo methodInfo in arrayMethodInfo)
                Console.WriteLine (methodInfo);

            // Get FullName for interface by using Ignore case search.
            Console.WriteLine ("\nMethods of 'IEnumerable' Interface");
            arrayMethodInfo = objType.GetInterface("ienumerable",true).GetMethods();
            foreach(MethodInfo methodInfo in arrayMethodInfo)
               Console.WriteLine (methodInfo);

            //Get the Interface methods for 'IDictionary' interface
            InterfaceMapping interfaceMappingOb = objType.GetInterfaceMap(typeof(IDictionary));
            arrayMemberInfo = interfaceMappingObj.InterfaceMethods;
            Console.WriteLine ("\nHashtable class Implements the following IDictionary Interface methods :");
            foreach(MemberInfo memberInfo in arrayMemberInfo)
               Console.WriteLine (memberInfo);
        }
        catch (Exception e)
        {
            Console.WriteLine ("Exception : " + e.ToString());
        }
    }
// </Snippet3>
// </Snippet2>
// </Snippet1>
}
