//This is a list of commonly used namespaces for a pane.
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Windows.Media;

namespace ButtonProps
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>

    public partial class Page1 : StackPanel
    {
        void OnClickDefault(object sender, RoutedEventArgs e)
        {
            //<Snippet3>
            if (btnDefault.IsDefault)
            {
                btnDefault.Content = "This is the default button.";
            }
            if (btnDefault.IsDefaulted)
            {
                btnDefault.Content = "The button is defaulted.";
            }

            //</Snippet3>
        }
        void OnClickCancel(object sender, RoutedEventArgs e)
        {
            if (btnCancel.IsCancel)
            {
                btnCancel.Content = "This is the cancel button.";
            }
        }
    }
}