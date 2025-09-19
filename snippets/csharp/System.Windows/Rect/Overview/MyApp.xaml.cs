using System;
using System.Windows;
using System.IO;

namespace SDKSample
{
    public partial class MyApp : Application
    {
        [STAThread]
        public static void Main()
        {
            MyApp app = new MyApp();
            app.InitializeComponent();
            app.Run();
        }

        public MyApp()
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
        }        
    
        void myAppStartup(object sender, StartupEventArgs e)
        {
            Window myWindow = new Window();
            myWindow.Content = new SampleViewer();
            MainWindow = myWindow;
            myWindow.Show();
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs args)
        {
            try {
                StreamWriter wr = new StreamWriter("error.txt");
                wr.Write(args.ExceptionObject.ToString());
                wr.Close();
            }
            catch(Exception)
            {
                throw;
            }
            MessageBox.Show("Unhandled exception: " + args.ExceptionObject.ToString());
        }
    }
}
