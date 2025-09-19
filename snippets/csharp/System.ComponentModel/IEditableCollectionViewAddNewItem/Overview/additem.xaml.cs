//<SnippetAddItemLogic>
using System.Windows;
using System.Windows.Controls;

namespace IEditableCollectionViewAddItemExample;

public partial class AddItemWindow : Window
{
    public AddItemWindow() => InitializeComponent();

    void Submit_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = true;
        Close();
    }

    // Select all text when the TextBox gets focus.
    void TextBoxFocus(object sender, RoutedEventArgs e)
    {
        TextBox tbx = sender as TextBox;

        tbx.SelectAll();
    }
}
//</SnippetAddItemLogic>
