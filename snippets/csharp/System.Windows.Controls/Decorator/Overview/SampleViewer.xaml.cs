using System.Windows.Controls;

namespace SDKSample
{
    public partial class SampleViewer : Page
    {
        public SampleViewer()
        {
            InitializeComponent();
            MyBasicBorderExampleFrame.Content = new BasicBorderExample();           
        }
    }
}
