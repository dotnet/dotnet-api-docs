//<Snippet1>
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;

// This example demonstrates how to implement a component editor that hosts 
// component pages and associate it with a component. This example also 
// demonstrates how to implement a component page that provides a panel-based 
// control system and Help keyword support.
namespace ComponentEditorExample
{
    // The ExampleComponentEditor displays two ExampleComponentEditorPage pages.
    public class ExampleComponentEditor : System.Windows.Forms.Design.WindowsFormsComponentEditor
    {
        //<Snippet2>
        // This method override returns an type array containing the type of 
        // each component editor page to display.
        protected override Type[] GetComponentEditorPages()
        {
            return new Type[] { typeof(ExampleComponentEditorPage),
                                typeof(ExampleComponentEditorPage) };
        }
        //</Snippet2>

        //<Snippet3>
        // This method override returns the index of the page to display when the 
        // component editor is first displayed.
        protected override int GetInitialComponentEditorPageIndex()
        {
            return 1;
        }
        //</Snippet3>
    }

    //<Snippet6>
    // This example component editor page type provides an example 
    // ComponentEditorPage implementation.
    internal class ExampleComponentEditorPage : System.Windows.Forms.Design.ComponentEditorPage
    {
        Label l1;
        Button b1;
        PropertyGrid pg1;

        public ExampleComponentEditorPage()
        {
            // Initialize the page, which inherits from Panel, and its controls.
            this.Size = new Size(400, 250);
            this.Icon = new Icon("myicon.ico");
            this.Text = "Example Page";

            b1 = new Button();
            b1.Size = new Size(200, 20);
            b1.Location = new Point(200, 0);
            b1.Text = "Set a random background color";
            b1.Click += new EventHandler(this.randomBackColor);
            this.Controls.Add(b1);

            l1 = new Label();
            l1.Size = new Size(190, 20);
            l1.Location = new Point(4, 2);
            l1.Text = "Example Component Editor Page";
            this.Controls.Add(l1);

            pg1 = new PropertyGrid();
            pg1.Size = new Size(400, 280);
            pg1.Location = new Point(0, 30);
            this.Controls.Add(pg1);
        }

        // This method indicates that the Help button should be enabled for this 
        // component editor page.
        public override bool SupportsHelp()
        {
            return true;
        }

        //<Snippet4>
        // This method is called when the Help button for this component editor page is pressed.
        // This implementation uses the IHelpService to show the Help topic for a sample keyword.
        public override void ShowHelp()
        {
            // The GetSelectedComponent method of a ComponentEditorPage retrieves the
            // IComponent associated with the WindowsFormsComponentEditor.
            IComponent selectedComponent = this.GetSelectedComponent();

            // Retrieve the Site of the component, and return if null.
            ISite componentSite = selectedComponent.Site;
            if (componentSite == null)
                return;

            // Acquire the IHelpService to display a help topic using a indexed keyword lookup.
            IHelpService helpService = (IHelpService)componentSite.GetService(typeof(IHelpService));
            if (helpService != null)
                helpService.ShowHelpFromKeyword("System.Windows.Forms.ComboBox");
        }
        //</Snippet4>

        // The LoadComponent method is raised when the ComponentEditorPage is displayed.
        protected override void LoadComponent()
        {
            this.pg1.SelectedObject = this.Component;
        }

        // The SaveComponent method is raised when the WindowsFormsComponentEditor is closing 
        // or the current ComponentEditorPage is closing.
        protected override void SaveComponent()
        {
        }

        // If the associated component is a Control, this method sets the BackColor to a random color.
        // This method is invoked by the button on this ComponentEditorPage.
        private void randomBackColor(object sender, EventArgs e)
        {
            if (typeof(System.Windows.Forms.Control).IsAssignableFrom(this.Component.GetType()))
            {
                // Sets the background color of the Control associated with the
                // WindowsFormsComponentEditor to a random color.
                Random rnd = new Random();
                ((System.Windows.Forms.Control)this.Component).BackColor =
                    Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
                pg1.Refresh();
            }
        }
    }
    //</Snippet6>

    //<Snippet5>
    // This example control is associated with the ExampleComponentEditor 
    // through the following EditorAttribute.
    [EditorAttribute(typeof(ExampleComponentEditor), typeof(ComponentEditor))]
    public class ExampleUserControl : System.Windows.Forms.UserControl
    {
    }
    //</Snippet5>
}
//</Snippet1>
