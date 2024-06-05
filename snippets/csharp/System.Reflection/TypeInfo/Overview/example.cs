//<Snippet1>
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;

TypeInfo t = typeof(Calendar).GetTypeInfo();
IEnumerable<PropertyInfo> pList = t.DeclaredProperties;
IEnumerable<MethodInfo> mList = t.DeclaredMethods;

StringBuilder sb = new StringBuilder();

sb.Append("Properties:");
foreach (PropertyInfo p in pList)
{

    sb.Append("\n" + p.DeclaringType.Name + ": " + p.Name);
}
sb.Append("\nMethods:");
foreach (MethodInfo m in mList)
{
    sb.Append("\n" + m.DeclaringType.Name + ": " + m.Name);
}

Console.WriteLine(sb.ToString());

/* This code outputs the following text:
Properties:
Calendar: MinSupportedDateTime
Calendar: MaxSupportedDateTime
Calendar: AlgorithmType
Calendar: ID
Calendar: BaseCalendarID
Calendar: IsReadOnly
Calendar: CurrentEraValue
Calendar: Eras
Calendar: DaysInYearBeforeMinSupportedYear
Calendar: TwoDigitYearMax
Methods:
Calendar: get_MinSupportedDateTime
Calendar: get_MaxSupportedDateTime
Calendar: get_AlgorithmType
Calendar: get_ID
Calendar: get_BaseCalendarID
Calendar: get_IsReadOnly
Calendar: get_CurrentEraValue
Calendar: get_Eras
Calendar: get_DaysInYearBeforeMinSupportedYear
Calendar: get_TwoDigitYearMax
Calendar: set_TwoDigitYearMax
Calendar: Clone
Calendar: ReadOnly
Calendar: VerifyWritable
Calendar: SetReadOnlyState
Calendar: CheckAddResult
Calendar: Add
Calendar: AddMilliseconds
Calendar: AddDays
Calendar: AddHours
Calendar: AddMinutes
Calendar: AddMonths
Calendar: AddSeconds
Calendar: AddWeeks
Calendar: AddYears
Calendar: GetDayOfMonth
Calendar: GetDayOfWeek
Calendar: GetDayOfYear
Calendar: GetDaysInMonth
Calendar: GetDaysInMonth
Calendar: GetDaysInYear
Calendar: GetDaysInYear
Calendar: GetEra
Calendar: GetHour
Calendar: GetMilliseconds
Calendar: GetMinute
Calendar: GetMonth
Calendar: GetMonthsInYear
Calendar: GetMonthsInYear
Calendar: GetSecond
Calendar: GetFirstDayWeekOfYear
Calendar: GetWeekOfYearFullDays
Calendar: GetWeekOfYearOfMinSupportedDateTime
Calendar: GetWeekOfYear
Calendar: GetYear
Calendar: IsLeapDay
Calendar: IsLeapDay
Calendar: IsLeapMonth
Calendar: IsLeapMonth
Calendar: GetLeapMonth
Calendar: GetLeapMonth
Calendar: IsLeapYear
Calendar: IsLeapYear
Calendar: ToDateTime
Calendar: ToDateTime
Calendar: TryToDateTime
Calendar: IsValidYear
Calendar: IsValidMonth
Calendar: IsValidDay
Calendar: ToFourDigitYear
Calendar: TimeToTicks
Calendar: GetSystemTwoDigitYearSetting
*/

//</Snippet1>
