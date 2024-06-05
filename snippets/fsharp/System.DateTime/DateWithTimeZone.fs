// <Snippet6>
namespace DateTimeExtensions

open System

[<Serializable>]
type DateWithTimeZone =
    struct
        val TimeZone: TimeZoneInfo
        val DateTime: DateTime
        new (dateValue, timeZone) = 
            { DateTime = dateValue; 
              TimeZone = 
                if isNull timeZone then TimeZoneInfo.Local
                else timeZone }
    end
    
// </Snippet6>