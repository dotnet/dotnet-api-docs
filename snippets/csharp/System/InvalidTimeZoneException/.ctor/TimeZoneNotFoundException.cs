﻿// <Snippet4>
using System;
using System.IO;
using System.Text.Json;
// </Snippet4>

[assembly: CLSCompliant(true)]
public class TestTimeZoneExceptions
{
   public static void Main()
   {
      TestTimeZoneExceptions test = new TestTimeZoneExceptions();
      // test.HandleInnerException();
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
         Console.WriteLine($"The time zone display name is {{0}}.", tz.DisplayName);
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
               string.Format($"The time zone '{tzName}' cannot be found."),
               ex1);
      }
      catch (InvalidTimeZoneException ex2)
      {
         throw new InvalidTimeZoneException(
               string.Format($"The time zone '{tzName}' contains invalid data."),
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
         using StreamWriter fs = new("TimeZoneNotFound.dat");
         fs.Write(tZoneString);
      }
      catch (TimeZoneNotFoundException e)
      {
         Console.WriteLine("A {0} has been thrown.", e.GetType().Name);
         // Create a new exception with an inner exception
         TimeZoneNotFoundException serializedException = new(
                                 "Attempting to load a non-existent time zone",
                                 e);
         // Serialize the exception message to a file.
         string exceptionMessage = JsonSerializer.Serialize(serializedException.Message);
         File.WriteAllText("tzNotFound.json", exceptionMessage);
         Console.WriteLine("Serialized the exception message.");
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
            using StreamReader reader = new("TimeZoneInfo.dat");
            string contents = reader.ReadToEnd();
            timeZone = TimeZoneInfo.FromSerializedString(contents);
            Console.WriteLine(timeZone.Id);
         }
         catch (FileNotFoundException eInner)
         {
            Console.WriteLine(eInner.GetType().Name);
            // File not found, therefore object not serialized:
            // Deserialize original exception message.
            Console.WriteLine("Deserializing the original exception.");
            string exceptionMessage = File.ReadAllText("tzNotFound.json");
            string serializedExceptionMessage = JsonSerializer.Deserialize<string>(exceptionMessage);
            Console.WriteLine($"Original error message: {serializedExceptionMessage}");
         }
      }
   }
   // </Snippet3>
}
