using System.Diagnostics;
using System.Text;

// <Snippet3>
namespace ProcessAsyncStreamSamples
{
    class ProcessNMakeStreamRedirection
    {
        // Define static variables shared by class methods.
        private static StreamWriter? s_buildLogStream;
        private static readonly Mutex s_logMutex = new();
        private static int s_maxLogLines = 25;
        private static int s_currentLogLines = 0;

        public static void RedirectNMakeCommandStreams()
        {
            string? nmakeArguments = null;
            Process nmakeProcess;

            // Get the input nmake command-line arguments.
            while (string.IsNullOrEmpty(nmakeArguments))
            {
                Console.WriteLine("Enter the NMake command line arguments " +
                    "(@commandfile or /f makefile, etc):");
                nmakeArguments = Console.ReadLine();
            }

            Console.WriteLine("Enter max line limit for log file (default is 25):");
            string? inputText = Console.ReadLine();
            if (!string.IsNullOrEmpty(inputText))
            {
                if (!int.TryParse(inputText, out s_maxLogLines))
                {
                    s_maxLogLines = 25;
                }
            }
            Console.WriteLine($"Output beyond {s_maxLogLines} lines will be ignored.");

            // Initialize the process and its StartInfo properties.
            nmakeProcess = new Process();
            nmakeProcess.StartInfo.FileName = "NMake.exe";

            // Build the nmake command argument list.
            if (!string.IsNullOrEmpty(nmakeArguments))
            {
                nmakeProcess.StartInfo.Arguments = nmakeArguments;
            }

            // Set UseShellExecute to false for redirection.
            nmakeProcess.StartInfo.UseShellExecute = false;

            // Redirect the standard output of the nmake command.
            // Read the stream asynchronously using an event handler.
            nmakeProcess.StartInfo.RedirectStandardOutput = true;
            nmakeProcess.OutputDataReceived += new DataReceivedEventHandler(NMakeOutputDataHandler);

            // Redirect the error output of the nmake command.
            nmakeProcess.StartInfo.RedirectStandardError = true;
            nmakeProcess.ErrorDataReceived += new DataReceivedEventHandler(NMakeErrorDataHandler);

            s_logMutex.WaitOne();

            s_currentLogLines = 0;

            // Write a header to the log file.
            const string buildLogFile = "NmakeCmd.Txt";
            try
            {
                s_buildLogStream = new StreamWriter(buildLogFile, true);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Could not open output file {buildLogFile}");
                Console.WriteLine($"Exception = {e}");
                Console.WriteLine(e.Message);

                s_buildLogStream = null;
            }

            if (s_buildLogStream != null)
            {
                Console.WriteLine($"Nmake output logged to {buildLogFile}");

                s_buildLogStream.WriteLine();
                s_buildLogStream.WriteLine(DateTime.Now);
                if (!string.IsNullOrEmpty(nmakeArguments))
                {
                    s_buildLogStream.Write("Command line = NMake {0}",
                        nmakeArguments);
                }
                else
                {
                    s_buildLogStream.Write("Command line = Nmake");
                }
                s_buildLogStream.WriteLine();
                s_buildLogStream.Flush();

                s_logMutex.ReleaseMutex();

                // Start the process.
                Console.WriteLine();
                Console.WriteLine("\nStarting Nmake command...");
                Console.WriteLine();
                nmakeProcess.Start();

                // Start the asynchronous read of the error stream.
                nmakeProcess.BeginErrorReadLine();

                // Start the asynchronous read of the output stream.
                nmakeProcess.BeginOutputReadLine();

                // Let the nmake command run, collecting the output.
                nmakeProcess.WaitForExit();

                nmakeProcess.Close();
                s_buildLogStream.Close();
                s_logMutex.Dispose();
            }
        }

        private static void NMakeOutputDataHandler(object sendingProcess,
            DataReceivedEventArgs outLine)
        {
            // Collect the output, displaying it to the screen and
            // logging it to the output file.  Cancel the read
            // operation when the maximum line limit is reached.

            if (!string.IsNullOrEmpty(outLine.Data))
            {
                s_logMutex.WaitOne();

                s_currentLogLines++;
                if (s_currentLogLines > s_maxLogLines)
                {
                    // Display the line to the console.
                    // Skip writing the line to the log file.
                    Console.WriteLine($"StdOut: {outLine.Data}");
                }
                else if (s_currentLogLines == s_maxLogLines)
                {
                    LogToFile("StdOut", "<Max build log limit reached!>",
                        true);

                    // Stop reading the output streams.
                    if (sendingProcess is Process p)
                    {
                        p.CancelOutputRead();
                        p.CancelErrorRead();
                    }
                }
                else
                {
                    // Write the line to the log file.
                    LogToFile("StdOut", outLine.Data, true);
                }
                s_logMutex.ReleaseMutex();
            }
        }

        private static void NMakeErrorDataHandler(object sendingProcess,
            DataReceivedEventArgs errLine)
        {
            // Collect error output, displaying it to the screen and
            // logging it to the output file.  Cancel the error output
            // read operation when the maximum line limit is reached.

            if (!string.IsNullOrEmpty(errLine.Data))
            {
                s_logMutex.WaitOne();

                s_currentLogLines++;
                if (s_currentLogLines > s_maxLogLines)
                {
                    // Display the error line to the console.
                    // Skip writing the line to the log file.
                    Console.WriteLine($"StdErr: {errLine.Data}");
                }
                else if (s_currentLogLines == s_maxLogLines)
                {
                    LogToFile("StdErr", "<Max build log limit reached!>",
                        true);

                    // Stop reading the output streams.
                    if (sendingProcess is Process p)
                    {
                        p.CancelErrorRead();
                        p.CancelOutputRead();
                    }
                }
                else
                {
                    // Write the line to the log file.
                    LogToFile("StdErr", errLine.Data, true);
                }

                s_logMutex.ReleaseMutex();
            }
        }

        private static void LogToFile(string logPrefix,
            string logText, bool echoToConsole)
        {
            // Write the specified line to the log file stream.
            StringBuilder logString = new StringBuilder();

            if (!string.IsNullOrEmpty(logPrefix))
            {
                logString.AppendFormat("{0}> ", logPrefix);
            }

            if (!string.IsNullOrEmpty(logText))
            {
                logString.Append(logText);
            }

            if (s_buildLogStream != null)
            {
                s_buildLogStream.WriteLine("[{0}] {1}", DateTime.Now, logString);
                s_buildLogStream.Flush();
            }

            if (echoToConsole)
            {
                Console.WriteLine(logString);
            }
        }
    }
}
// </Snippet3>

namespace ProcessAsyncStreamSamples
{
    class ProcessSample
    {
        /// The main entry point for the application.
        public static void Run()
        {
            try
            {
                ProcessNMakeStreamRedirection.RedirectNMakeCommandStreams();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Exception:");
                Console.WriteLine(e);
            }
        }
    }
}
