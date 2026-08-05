// <Snippet4>
using System;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

public class RegexEx1
{
    public static void Run()
    {
        AppDomain domain = AppDomain.CurrentDomain;
        // Set a timeout interval of -2 seconds.
        domain.SetData("REGEX_DEFAULT_MATCH_TIMEOUT", TimeSpan.FromSeconds(-2));

        Regex rgx = new Regex("[aeiouy]");
        Console.WriteLine($"Regular expression pattern: {rgx.ToString()}");
        Console.WriteLine($"Timeout interval for this regex: {rgx.MatchTimeout.TotalSeconds} seconds");
    }
}

// The example displays the following output:

//    Unhandled exception. System.TypeInitializationException:
//       The type initializer for 'System.Text.RegularExpressions.Regex' threw an exception. --->
//       System.ArgumentOutOfRangeException: Specified argument was out of the range of valid values.
//       (Parameter 'AppDomain data 'REGEX_DEFAULT_MATCH_TIMEOUT' contains the invalid value or object
//       '-00:00:02' for specifying a default matching timeout for System.Text.RegularExpressions.Regex.')
//       at System.Text.RegularExpressions.Regex.InitDefaultMatchTimeout()
//       at System.Text.RegularExpressions.Regex..cctor()
//       --- End of inner exception stack trace ---
//       at System.Text.RegularExpressions.Regex..ctor(String pattern, CultureInfo culture)
//       at RegexEx1.Run()

// </Snippet4>
