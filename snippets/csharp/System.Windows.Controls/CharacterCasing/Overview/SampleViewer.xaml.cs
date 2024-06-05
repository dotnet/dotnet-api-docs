using System.Windows.Controls;

namespace SDKSample
{
    public partial class SampleViewer : Page
    {
        public SampleViewer()
        {
            InitializeComponent();
            MyTextBoxExampleFrame.Content = new TextBoxExample();           
            MyCharacterCasingExampleFrame.Content = new CharacterCasingExample();
            MySpellCheckExampleFrame.Content = new SpellCheckExample();
            MyBeginChangeEndChangeExampleFrame.Content = new BeginChangeEndChangeExample();
        }
    }
}
