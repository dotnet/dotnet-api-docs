// <Snippet12>
using System;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.Serialization;

public class NullReferenceExample
{
    public static void Main()
    {
        var listType = GetListType();
        var listObj = GetList(listType);
    }

    private static Type GetListType()
    {
        return typeof(List<int>);
    }

    private static IList GetList(Type type)
    {
        var emptyList = (IList)FormatterServices.GetUninitializedObject(type); // Does not call list constructor
        var value = 1;
        emptyList.Add(value);
        return emptyList;
    }
}
// The example displays output like the following:
//    Unhandled Exception: System.NullReferenceException: 'Object reference
//    not set to an instance of an object.'
//    at System.Collections.Generic.List`1.System.Collections.IList.Add(Object item)
//    at Example.GetList(Type type): line 24
// </Snippet12>
