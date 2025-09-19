//<SnippetMainWindowGetPropertyCODEBEHIND>
using System;
using System.Windows;
using System.Windows.Controls;

namespace CSharp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        void MainWindow_Loaded(object sender, EventArgs e)
        {
            // Check for safe mode
            if ((bool)Application.Current.Properties["SafeMode"])
            {
                this.Title += " [SafeMode]";
            }
        }
    }
}
//</SnippetMainWindowGetPropertyCODEBEHIND>