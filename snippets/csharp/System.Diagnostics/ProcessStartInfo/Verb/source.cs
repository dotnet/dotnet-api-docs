// <Snippet1>
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

class ProcessInformation
{
    [STAThread]
    static void Main()
    {
        OpenFileDialog openFileDialog1 = new()
        {
            InitialDirectory = "c:\\",
            Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*",
            FilterIndex = 2,
            RestoreDirectory = true,
            CheckFileExists = true
        };

        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            string fileName = openFileDialog1.FileName;

            // <Snippet4>
            int i = 0;
            ProcessStartInfo startInfo = new(fileName);

            // Display the possible verbs.
            foreach (string verb in startInfo.Verbs)
            {
                Console.WriteLine($"  {i++}. {verb}");
            }

            Console.Write("Select the index of the verb: ");
            string indexInput = Console.ReadLine();
            if (int.TryParse(indexInput, out int index))
            {
                if (index < 0 || index >= i)
                {
                    Console.WriteLine("Invalid index value.");
                    return;
                }

                string verbToUse = startInfo.Verbs[index];

                startInfo.Verb = verbToUse;
                if (verbToUse.ToLower().IndexOf("printto") >= 0)
                {
                    // printto implies a specific printer. Ask for the network address.
                    // The address must be in the form \\server\printer.
                    // The printer address is passed as the Arguments property.
                    Console.Write("Enter the network address of the target printer: ");
                    string arguments = Console.ReadLine();
                    startInfo.Arguments = arguments;
                }

                try
                {
                    using Process newProcess = new();
                    newProcess.StartInfo = startInfo;
                    newProcess.Start();

                    Console.WriteLine($"{newProcess.ProcessName} for file {fileName} " +
                                      $"started successfully with verb '{startInfo.Verb}'!");
                }
                catch (Win32Exception e)
                {
                    Console.WriteLine("  Win32Exception caught!");
                    Console.WriteLine($"  Win32 error = {e.Message}");
                }
                catch (InvalidOperationException)
                {
                    // Catch this exception if the process exits quickly,
                    // and the properties are not accessible.
                    Console.WriteLine($"Unable to start '{fileName}' with verb {verbToUse}");
                }
            }
            // </Snippet4>
        }
        else
        {
            {
                Console.WriteLine("You did not enter a number.");
            }
        }
    }
}
// </Snippet1>
