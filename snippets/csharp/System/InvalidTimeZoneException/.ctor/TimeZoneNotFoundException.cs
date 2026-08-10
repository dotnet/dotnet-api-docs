// <Snippet4>
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
         Console.WriteLine("The time zone display name is {0}.", tz.DisplayName);
      }
      catch (TimeZoneNotFoundException e)
      {
         Console.WriteLine("{0} thrown by application", e.GetType().Name);
         Console.WriteLine("   Message: {0}", e.Message);
         if (e.InnerException != null)
         {
            Console.WriteLine("   Inner Exception Information:");
            Exception innerEx = e.InnerException;
            while (innerEx != null)
            {
               Console.WriteLine("      {0}: {1}", innerEx.GetType().Name, innerEx.Message);
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
               String.Format("The time zone '{0}' cannot be found.", tzName), 
               ex1);
      }          
      catch (InvalidTimeZoneException ex2)
      {
         throw new InvalidTimeZoneException( 
               String.Format("The time zone {0} contains invalid data.", tzName), 
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
         StreamWriter fs = new StreamWriter("TimeZoneNotFound.dat");
         fs.Write(tZoneString);
         fs.Close();
      }   
      catch (TimeZoneNotFoundException e)
      {
         Console.WriteLine("A {0} has been thrown.", e.GetType().Name);
         // Create a new exception with an inner exception
         TimeZoneNotFoundException serializedException = new TimeZoneNotFoundException( 
                                 "Attempting to load a non-existent time zone", 
                                 e);
         // Serialize the exception message to a file
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
            StreamReader reader = new StreamReader("TimeZoneInfo.dat");
            string contents = reader.ReadToEnd();
            reader.Close();
            timeZone = TimeZoneInfo.FromSerializedString(contents);
            Console.WriteLine(timeZone.Id);
         }   
         catch (FileNotFoundException eInner)
         {
            Console.WriteLine(eInner.GetType().Name);
            // file not found, therefore object not serialized: 
            // Deserialize original exception message
            Console.WriteLine("Deserializing the original exception.");
            string exceptionMessage = File.ReadAllText("tzNotFound.json");
            string serializedExceptionMessage = JsonSerializer.Deserialize<string>(exceptionMessage);
            Console.WriteLine("Original error message: {0}", serializedExceptionMessage);
         }
      }              
   } 
   // </Snippet3>   
}
