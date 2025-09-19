open System
// <Snippet1>
let timeZones = TimeZoneInfo.GetSystemTimeZones()
let timeZoneArray = Array.ofSeq timeZones
// Iterate array from top to bottom
for ctr = timeZoneArray.GetUpperBound 0 - 1 downto 0 do
    // Get next item from top
    let thisTimeZone = timeZoneArray[ctr]
    for compareCtr = 0 to ctr - 1 do
        // Determine if time zones have the same rules
        if thisTimeZone.HasSameRules timeZoneArray[compareCtr] then
            printfn $"{thisTimeZone.StandardName} has the same rules as {timeZoneArray[compareCtr].StandardName}"
// </Snippet1>