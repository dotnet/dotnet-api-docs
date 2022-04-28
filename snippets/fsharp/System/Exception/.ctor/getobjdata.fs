module NDP_UE_FS_3

//<Snippet1>
open System
open System.IO
open System.Runtime.Serialization
open System.Runtime.Serialization.Formatters.Soap
open System.Security.Permissions

 // Define a serializable derived exception class.
 [<Serializable>]
 type SecondLevelException =
    inherit Exception

    interface ISerializable with
        // GetObjectData performs a custom serialization.
        member this.GetObjectData(info: SerializationInfo, context: StreamingContext) =
            // Change the case of two properties, and then use the
            // method of the base class.
            this.HelpLink <- this.HelpLink.ToLower()
            this.Source <- this.Source.ToUpperInvariant()

            base.GetObjectData( info, context )
    // This public constructor is used by class instantiators.
    new (message: string, inner: Exception) as this =
        { inherit Exception(message, inner) }
        then
            this.HelpLink <- "http://MSDN.Microsoft.com"
            this.Source <- "Exception_Class_Samples" 

    // This protected constructor is used for deserialization.
    new (info: SerializationInfo, context: StreamingContext) =
        { inherit Exception(info, context) }

printfn 
    """This example of the Exception constructor and Exception.GetObjectData
with SerializationInfo and StreamingContext parameters generates 
the following output.
"""

try
    // This code forces a division by 0 and catches the
    // resulting exception.
    try
        let zero = 0
        let ecks = 1 / zero
        ()
    with ex ->
        // Create a new exception to throw again.
        let newExcept = SecondLevelException("Forced a division by 0 and threw another exception.", ex)

        printfn "Forced a division by 0, caught the resulting exception, \nand created a derived exception:\n"
        printfn $"HelpLink: {newExcept.HelpLink}"
        printfn $"Source:   {newExcept.Source}"

        // This FileStream is used for the serialization.
        use stream = new FileStream("NewException.dat", FileMode.Create)

        try
            // Serialize the derived exception.
            let formatter = SoapFormatter(null, StreamingContext StreamingContextStates.File)
            formatter.Serialize(stream, newExcept)

            // Rewind the stream and deserialize the
            // exception.
            stream.Position <- 0L
            let deserExcept = formatter.Deserialize stream :?> SecondLevelException

            printfn 
                """
Serialized the exception, and then deserialized the resulting stream into a 
new exception. The deserialization changed the case of certain properties:
"""

            // Throw the deserialized exception again.
            raise deserExcept
        with :? SerializationException as se -> 
            printfn $"Failed to serialize: {se}"

with ex ->
    printfn $"HelpLink: {ex.HelpLink}"
    printfn $"Source:   {ex.Source}"
    printfn $"\n{ex}"

// This example displays the following output.
//     Forced a division by 0, caught the resulting exception,
//     and created a derived exception:
//    
//     HelpLink: http://MSDN.Microsoft.com
//     Source:   Exception_Class_Samples
//    
//     Serialized the exception, and then deserialized the resulting stream into a
//     new exception. The deserialization changed the case of certain properties:
//    
//     HelpLink: http://msdn.microsoft.com
//     Source:   EXCEPTION_CLASS_SAMPLES
//    
//     NDP_UE_FS_3+SecondLevelException: Forced a division by 0 and threw another except
//     ion. ---> System.DivideByZeroException: Attempted to divide by zero.
//        at <StartupCode$fs>.$NDP_UE_FS_3.main@()
//        --- End of inner exception stack trace ---
//        at <StartupCode$fs>.$NDP_UE_FS_3.main@()
//</Snippet1>
