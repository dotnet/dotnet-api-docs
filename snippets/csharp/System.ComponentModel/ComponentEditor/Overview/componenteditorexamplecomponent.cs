//<Snippet1>
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

// This example demonstrates how to implement a component editor that hosts
// component pages and associate it with a component. This example also
// demonstrates how to implement a component page that provides a panel-based
// control system and Help keyword support.

// The ExampleComponentEditor displays two ExampleComponentEditorPage pages.
public class ExampleComponentEditor : WindowsFormsComponentEditor
{
    //<Snippet2>
    // This method override returns an type array containing the type of
    // each component editor page to display.
    protected override Type[] GetComponentEditorPages() => [typeof(ExampleComponentEditorPage), typeof(ExampleComponentEditorPage)];
    //</Snippet2>

    //<Snippet3>
    // This method override returns the index of the page to display when the
    // component editor is first displayed.
    protected override int GetInitialComponentEditorPageIndex() => 1;
    //</Snippet3>
}

//<Snippet6>
// This example component editor page type provides an example
// ComponentEditorPage implementation.
class ExampleComponentEditorPage : ComponentEditorPage
{
    readonly Label _l1;
    readonly Button b1;
    readonly PropertyGrid pg1;

    public ExampleComponentEditorPage()
    {
        // Initialize the page, which inherits from Panel, and its controls.
        Size = new Size(400, 250);
        Icon = new Icon("myicon.ico");
        Text = "Example Page";

        b1 = new Button
        {
            Size = new Size(200, 20),
            Location = new Point(200, 0),
            Text = "Set a random background color"
        };
        b1.Click += randomBackColor;
        Controls.Add(b1);

        _l1 = new Label
        {
            Size = new Size(190, 20),
            Location = new Point(4, 2),
            Text = "Example Component Editor Page"
        };
        Controls.Add(_l1);

        pg1 = new PropertyGrid
        {
            Size = new Size(400, 280),
            Location = new Point(0, 30)
        };
        Controls.Add(pg1);
    }

    // This method indicates that the Help button should be enabled for this
    // component editor page.
    public override bool SupportsHelp() => true;

    //<Snippet4>
    // This method is called when the Help button for this component editor page is pressed.
    // This implementation uses the IHelpService to show the Help topic for a sample keyword.
    public override void ShowHelp()
    {
        // The GetSelectedComponent method of a ComponentEditorPage retrieves the
        // IComponent associated with the WindowsFormsComponentEditor.
        IComponent selectedComponent = GetSelectedComponent();

        // Retrieve the Site of the component, and return if null.
        ISite componentSite = selectedComponent.Site;
        if (componentSite == null)
        {
            return;
        }

        // Acquire the IHelpService to display a help topic using a indexed keyword lookup.
        IHelpService helpService = (IHelpService)componentSite.GetService(typeof(IHelpService));
        helpService?.ShowHelpFromKeyword("System.Windows.Forms.ComboBox");
    }
    //</Snippet4>

    // The LoadComponent method is raised when the ComponentEditorPage is displayed.
    protected override void LoadComponent() => pg1.SelectedObject = Component;

    // The SaveComponent method is raised when the WindowsFormsComponentEditor is closing
    // or the current ComponentEditorPage is closing.
    protected override void SaveComponent()
    {
    }

    // If the associated component is a Control, this method sets the BackColor to a random color.
    // This method is invoked by the button on this ComponentEditorPage.
    void randomBackColor(object sender, EventArgs e)
    {
        if (typeof(Control).IsAssignableFrom(Component.GetType()))
        {
            // Sets the background color of the Control associated with the
            // WindowsFormsComponentEditor to a random color.
            Random rnd = new();
            ((Control)Component).BackColor =
                Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
            pg1.Refresh();
        }
    }
}
//</Snippet6>

//<Snippet5>
// This example control is associated with the ExampleComponentEditor
// through the following EditorAttribute.
[Editor(typeof(ExampleComponentEditor), typeof(ComponentEditor))]
public class ExampleUserControl : UserControl;
//</Snippet5>
//</Snippet1>
