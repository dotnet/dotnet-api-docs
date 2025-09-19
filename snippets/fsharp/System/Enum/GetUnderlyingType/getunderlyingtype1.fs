// <Snippet1>
open System

let displayEnumInfo (enumValue: Enum) =
    let enumType = enumValue.GetType()
    let underlyingType = Enum.GetUnderlyingType enumType
    printfn $"{enumValue,-10} {enumType.Name, 18}   {underlyingType.Name,15}"

let enumValues: Enum list =
    [ ConsoleColor.Red; DayOfWeek.Monday
      MidpointRounding.ToEven; PlatformID.Win32NT
      DateTimeKind.Utc; StringComparison.Ordinal ]

printfn "%-10s %18s   %15s\n" "Member" "Enumeration" "Underlying Type"
for enumValue in enumValues do
    displayEnumInfo enumValue

// The example displays the following output:
//       Member            Enumeration   Underlying Type
//
//       Red              ConsoleColor             Int32
//       Monday              DayOfWeek             Int32
//       ToEven       MidpointRounding             Int32
//       Win32NT            PlatformID             Int32
//       Utc              DateTimeKind             Int32
//       Ordinal      StringComparison             Int32
// </Snippet1>