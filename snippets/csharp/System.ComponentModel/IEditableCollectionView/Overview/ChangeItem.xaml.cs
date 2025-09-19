using System.Windows;

namespace EditingCollectionsSnippets;

/// <summary>
/// Interaction logic for ChangeItem.xaml
/// </summary>
public partial class ChangeItemWindow : Window
{
    public ChangeItemWindow() => InitializeComponent();

    void Submit_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = true;
        Close();
    }
}
