using System.Windows;

namespace DrawingAttributesSample
{
    /// <summary>
    /// Interaction logic for MyApp.xaml
    /// </summary>

    public partial class MyApp : Application
    {
        public static void Main() { }

        void AppStartingUp(object sender, StartupEventArgs e)
        {
            Window1 mainWindow = new Window1();
            mainWindow.Show();
        }
    }
}
