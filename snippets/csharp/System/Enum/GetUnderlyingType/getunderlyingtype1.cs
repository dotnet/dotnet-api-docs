// <Snippet1>
using System;

public class Example
{
    public static void Main()
    {
        Enum[] enumValues = { ConsoleColor.Red, DayOfWeek.Monday,
                            MidpointRounding.ToEven, PlatformID.Win32NT,
                            DateTimeKind.Utc, StringComparison.Ordinal };
        Console.WriteLine($"{"Member",-10} {"Enumeration",18}   {"Underlying Type",15}\n");
        foreach (var enumValue in enumValues)
            DisplayEnumInfo(enumValue);
    }

    static void DisplayEnumInfo(Enum enumValue)
    {
        Type enumType = enumValue.GetType();
        Type underlyingType = Enum.GetUnderlyingType(enumType);
        Console.WriteLine($"{enumValue,-10} {enumType.Name,18}   {underlyingType.Name,15}");
    }
}
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
