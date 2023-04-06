// <Snippet1>
open System.Collections.Generic

printfn "\nInterfaces implemented by Dictionary<int, string>:\n"

for tinterface in typeof<Dictionary<int, string>>.GetInterfaces() do
    printfn $"{tinterface}"

(* This example produces output similar to the following:

Interfaces implemented by Dictionary<int, string>:

System.Collections.Generic.IDictionary`2[System.Int32,System.String]
System.Collections.Generic.ICollection`1[System.Collections.Generic.KeyValuePair`2[System.Int32,System.String]]
System.Collections.Generic.IEnumerable`1[System.Collections.Generic.KeyValuePair`2[System.Int32,System.String]]
System.Collection.IEnumerable
System.Collection.IDictionary
System.Collection.ICollection
System.Runtime.Serialization.ISerializable
System.Runtime.Serialization.IDeserializationCallback
 *)
// </Snippet1>