
using System.Threading.Tasks;
using System.Windows;

namespace WPFCrossThreadCS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static void Main() { }

        public MainWindow() => InitializeComponent();

        private async void threadExampleBtn_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text = string.Empty;

            textBox1.Text = "Simulating work on UI thread.\n";
            DoSomeWork(20);
            textBox1.Text += "Work completed...\n";

            textBox1.Text += "Simulating work on non-UI thread.\n";
            await Task.Run(() => DoSomeWork(1000));
            textBox1.Text += "Work completed...\n";
        }

        // <Snippet3>
        private async void DoSomeWork(int milliseconds)
        {
            // Simulate work.
            await Task.Delay(milliseconds);

            // Report completion.
            bool uiAccess = textBox1.Dispatcher.CheckAccess();
            string msg = $"Some work completed in {milliseconds} ms. on {(uiAccess ? string.Empty : "non-")}UI thread\n";
            if (uiAccess)
                textBox1.Text += msg;
            else
                textBox1.Dispatcher.Invoke(() => { textBox1.Text += msg; });
        }
        // </Snippet3>
    }
}
