// The following example uses the net view command to list the
// available network resources available on a remote computer,
// and displays the results to the console. Specifying the optional
// error log file redirects error output to that file.

// <Snippet2>
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace ProcessAsyncStreamSamples
{
    class ProcessNetStreamRedirection
    {
        // Define static variables shared by class methods.
        private static StreamWriter? s_streamError;
        private static string? s_netErrorFile = "";
        private static StringBuilder? s_netOutput;
        private static bool s_errorRedirect = false;
        private static bool s_errorsWritten = false;

        public static void RedirectNetCommandStreams()
        {
            string? netArguments;
            Process netProcess;

            // Get the input computer name.
            Console.WriteLine("Enter the computer name for the net view command:");
            netArguments = Console.ReadLine()?.ToUpper(CultureInfo.InvariantCulture);
            if (string.IsNullOrEmpty(netArguments))
            {
                // Default to the help command if there is not an input argument.
                netArguments = "/?";
            }

            // Check if errors should be redirected to a file.
            s_errorsWritten = false;
            Console.WriteLine("Enter a fully qualified path to an error log file");
            Console.WriteLine("  or just press Enter to write errors to console:");
            s_netErrorFile = Console.ReadLine()?.ToUpper(CultureInfo.InvariantCulture);
            if (!string.IsNullOrEmpty(s_netErrorFile))
            {
                s_errorRedirect = true;
            }

            // Note that at this point, netArguments and netErrorFile
            // are set with user input.  If the user did not specify
            // an error file, then errorRedirect is set to false.

            // Initialize the process and its StartInfo properties.
            netProcess = new Process();
            netProcess.StartInfo.FileName = "Net.exe";

            // Build the net command argument list.
            netProcess.StartInfo.Arguments = $"view {netArguments}";

            // Set UseShellExecute to false for redirection.
            netProcess.StartInfo.UseShellExecute = false;

            // Redirect the standard output of the net command.
            // This stream is read asynchronously using an event handler.
            netProcess.StartInfo.RedirectStandardOutput = true;
            netProcess.OutputDataReceived += new DataReceivedEventHandler(NetOutputDataHandler);
            s_netOutput = new StringBuilder();

            if (s_errorRedirect)
            {
                // Redirect the error output of the net command.
                netProcess.StartInfo.RedirectStandardError = true;
                netProcess.ErrorDataReceived += new DataReceivedEventHandler(NetErrorDataHandler);
            }
            else
            {
                // Do not redirect the error output.
                netProcess.StartInfo.RedirectStandardError = false;
            }

            Console.WriteLine($"\nStarting process: net {netProcess.StartInfo.Arguments}");
            if (s_errorRedirect)
            {
                Console.WriteLine($"Errors will be written to the file {s_netErrorFile}");
            }

            // Start the process.
            netProcess.Start();

            // Start the asynchronous read of the standard output stream.
            netProcess.BeginOutputReadLine();

            if (s_errorRedirect)
            {
                // Start the asynchronous read of the standard
                // error stream.
                netProcess.BeginErrorReadLine();
            }

            // Let the net command run, collecting the output.
            netProcess.WaitForExit();

            if (s_streamError != null)
            {
                // Close the error file.
                s_streamError.Close();
            }
            else
            {
                // Set errorsWritten to false if the stream is not
                // open.   Either there are no errors, or the error
                // file could not be opened.
                s_errorsWritten = false;
            }

            if (s_netOutput.Length > 0)
            {
                // If the process wrote more than just
                // white space, write the output to the console.
                Console.WriteLine($"\nPublic network shares from net view:\n{s_netOutput}\n");
            }

            if (s_errorsWritten)
            {
                // Signal that the error file had something
                // written to it.
                string[] errorOutput = File.ReadAllLines(s_netErrorFile);
                if (errorOutput.Length > 0)
                {
                    Console.WriteLine($"\nThe following error output was appended to {s_netErrorFile}:");
                    foreach (string errLine in errorOutput)
                    {
                        Console.WriteLine($"  {errLine}");
                    }
                }
                Console.WriteLine();
            }

            netProcess.Close();
        }

        private static void NetOutputDataHandler(object sendingProcess,
            DataReceivedEventArgs outLine)
        {
            // Collect the net view command output.
            if (!string.IsNullOrEmpty(outLine.Data))
            {
                // Add the text to the collected output.
                s_netOutput.Append(Environment.NewLine + "  " + outLine.Data);
            }
        }

        private static void NetErrorDataHandler(object sendingProcess,
            DataReceivedEventArgs errLine)
        {
            // Write the error text to the file if there is something
            // to write and an error file has been specified.

            if (!string.IsNullOrEmpty(errLine.Data))
            {
                if (!s_errorsWritten)
                {
                    if (s_streamError == null)
                    {
                        // Open the file.
                        try
                        {
                            s_streamError = new StreamWriter(s_netErrorFile, true);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Could not open error file!");
                            Console.WriteLine(e.Message.ToString());
                        }
                    }

                    if (s_streamError != null)
                    {
                        // Write a header to the file if this is the first
                        // call to the error output handler.
                        s_streamError.WriteLine();
                        s_streamError.WriteLine(DateTime.Now.ToString());
                        s_streamError.WriteLine("Net View error output:");
                    }
                    s_errorsWritten = true;
                }

                if (s_streamError != null)
                {
                    // Write redirected errors to the file.
                    s_streamError.WriteLine(errLine.Data);
                    s_streamError.Flush();
                }
            }
        }
    }
}
// </Snippet2>

namespace ProcessAsyncStreamSamples
{
    class ProcessAsyncSample
    {
        /// The main entry point for the application.
        static void Run()
        {
            try
            {
                ProcessNetStreamRedirection.RedirectNetCommandStreams();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Exception:");
                Console.WriteLine(e.ToString());
            }
        }
    }
}
