// <Snippet4>
using System;
using System.IO;
using System.Runtime.Serialization;

// </Snippet4>

[assembly: CLSCompliant(true)]
public class TestTimeZoneExceptions
{
    public static void Main()
    {
        TestTimeZoneExceptions test = new();
        //      test.HandleInnerException();
        test.SerializeException();
        test.DeserializeException();
    }

    // <Snippet1>
    private void HandleInnerException()
    {
        string timeZoneName = "Any Standard Time";
        TimeZoneInfo tz;
        try
        {
            tz = RetrieveTimeZone(timeZoneName);
            Console.WriteLine($"The time zone display name is {tz.DisplayName}.");
        }
        catch (TimeZoneNotFoundException e)
        {
            Console.WriteLine($"{e.GetType().Name} thrown by application");
            Console.WriteLine($"   Message: {e.Message}");
            if (e.InnerException != null)
            {
                Console.WriteLine("   Inner Exception Information:");
                Exception innerEx = e.InnerException;
                while (innerEx != null)
                {
                    Console.WriteLine($"      {innerEx.GetType().Name}: {innerEx.Message}");
                    innerEx = innerEx.InnerException;
                }
            }
        }
    }

    private TimeZoneInfo RetrieveTimeZone(string tzName)
    {
        try
        {
            return TimeZoneInfo.FindSystemTimeZoneById(tzName);
        }
        catch (TimeZoneNotFoundException ex1)
        {
            throw new TimeZoneNotFoundException(
                  $"The time zone '{tzName}' cannot be found.",
                  ex1);
        }
        catch (InvalidTimeZoneException ex2)
        {
            throw new InvalidTimeZoneException(
                  $"The time zone {tzName} contains invalid data.",
                  ex2);
        }
    }
    // </Snippet1>

    // <Snippet2>
    private void SerializeException()
    {
        // Generate exception object so that it can be serialized
        try
        {
            Console.WriteLine("Attempting to load a non-existent time zone");
            TimeZoneInfo tZone = TimeZoneInfo.FindSystemTimeZoneById("Imaginary Time Zone");
            // Serialize time zone so it can be loaded by main routine
            string tZoneString = tZone.ToSerializedString();
            StreamWriter fs = new("TimeZoneNotFound.dat");
            fs.Write(tZoneString);
            fs.Close();
        }
        catch (TimeZoneNotFoundException e)
        {
            Console.WriteLine($"A {e.GetType().Name} has been thrown.");
            // Create a new exception with an inner exception
            TimeZoneNotFoundException serializedException = new(
                                    "Attempting to load a non-existent time zone",
                                    e);
            // Serialize the exception to a file
            IFormatter exceptionFormatter = new SoapFormatter();
            Stream exceptionStream = new FileStream("tzNotFound.xml", FileMode.Create);
            exceptionFormatter.Serialize(exceptionStream, serializedException);
            exceptionStream.Close();
            Console.WriteLine("Serialized the exception object.");
        }
    }
    // </Snippet2>

    // <Snippet3>
    private void DeserializeException()
    {
        TimeZoneInfo timeZone;
        try
        {
            Console.WriteLine("Attempting to load a non-existent time zone again");
            timeZone = TimeZoneInfo.FindSystemTimeZoneById("Imaginary Time Zone");
        }
        catch (TimeZoneNotFoundException)
        {
            try
            {
                // Attempt to deserialize time zone to throw FileNotFoundException
                StreamReader reader = new("TimeZoneInfo.dat");
                string contents = reader.ReadToEnd();
                reader.Close();
                timeZone = TimeZoneInfo.FromSerializedString(contents);
                Console.WriteLine(timeZone.Id);
            }
            catch (FileNotFoundException eInner)
            {
                Console.WriteLine(eInner.GetType().Name);
                // file not found, therefore object not serialized:
                // deserialize original exception information
                Console.WriteLine("Deserializing the original exception.");
                FileStream exceptionStream = new("tzNotFound.xml", FileMode.Open);
                IFormatter exceptionFormatter = new SoapFormatter();
                TimeZoneNotFoundException serializedException =
                    exceptionFormatter.Deserialize(exceptionStream) as TimeZoneNotFoundException;
                Console.WriteLine($"Original error message: {serializedException.Message}");
            }
        }
    }
    // </Snippet3>
}
