//<snippet1>
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace CustomToolboxItem;

public class Form1 : Form
{
    readonly IContainer _components;
    UserControl1 userControl11;
    Label label1;

    public Form1() => InitializeComponent();

    void InitializeComponent()
    {
        label1 = new Label();
        userControl11 = new UserControl1();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Location = new Point(15, 16);
        label1.Name = "label1";
        label1.Size = new Size(265, 62);
        label1.TabIndex = 0;
        label1.Text = "Build the project and drop UserControl1 from the toolbox onto the form.";
        // 
        // userControl11
        // 
        userControl11.LabelText = "This is a custom user control.  The text you see here is provided by a custom too" +
            "lbox item when the user control is dropped on the form.";
        userControl11.Location = new Point(74, 81);
        userControl11.Name = "userControl11";
        userControl11.Padding = new Padding(6);
        userControl11.Size = new Size(150, 150);
        userControl11.TabIndex = 1;
        // 
        // Form1
        // 
        ClientSize = new Size(292, 266);
        Controls.Add(userControl11);
        Controls.Add(label1);
        Name = "Form1";
        Text = "Form1";
        ResumeLayout(false);
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && (_components != null))
        {
            _components.Dispose();
        }
        base.Dispose(disposing);
    }

    static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new Form1());
    }
}

// Configure this user control to have a custom toolbox item.
//<snippet2>
[ToolboxItem(typeof(MyToolboxItem))]
public class UserControl1 : UserControl
//</snippet2>
{
    readonly IContainer _components;
    Label label1;

    public UserControl1() => InitializeComponent();

    public string LabelText
    {
        get => label1.Text; set => label1.Text = value;
    }

    void InitializeComponent()
    {
        label1 = new Label();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Dock = DockStyle.Fill;
        label1.Location = new Point(6, 6);
        label1.Name = "label1";
        label1.Size = new Size(138, 138);
        label1.TabIndex = 0;
        label1.Text = "This is a custom user control.  " +
            "The text you see here is provided by a custom toolbox" +
            " item when the user control is dropped on the form.\r\n";
        label1.TextAlign =
            ContentAlignment.MiddleCenter;
        // 
        // UserControl1
        // 
        Controls.Add(label1);
        Name = "UserControl1";
        Padding = new Padding(6);
        ResumeLayout(false);
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && (_components != null))
        {
            _components.Dispose();
        }
        base.Dispose(disposing);
    }
}

//<snippet3>
// Toolbox items must be serializable.
[Serializable]
class MyToolboxItem : ToolboxItem
{
    // The add components dialog in Visual Studio looks for a public
    // constructor that takes a type.
    public MyToolboxItem(Type toolType)
        : base(toolType)
    {
    }

    // And you must provide this special constructor for serialization.
    // If you add additional data to MyToolboxItem that you
    // want to serialize, you may override Deserialize and
    // Serialize methods to add that data.  
    //<snippet4>
    MyToolboxItem(SerializationInfo info, StreamingContext context) => Deserialize(info, context);
    //</snippet4>

    // Let's override the creation code and pop up a dialog.
    //<snippet5>
    protected override IComponent[] CreateComponentsCore(
        System.ComponentModel.Design.IDesignerHost host,
        System.Collections.IDictionary defaultValues)
    {
        // Get the string we want to fill in the custom
        // user control.  If the user cancels out of the dialog,
        // return null or an empty array to signify that the 
        // tool creation was canceled.
        using (ToolboxItemDialog d = new())
        {
            if (d.ShowDialog() == DialogResult.OK)
            {
                string text = d.CreationText;

                IComponent[] comps =
                    base.CreateComponentsCore(host, defaultValues);
                // comps will have a single component: our data type.
                ((UserControl1)comps[0]).LabelText = text;
                return comps;
            }
            else
            {
                return null;
            }
        }
    }
    //</snippet5>
}
//</snippet3>

public class ToolboxItemDialog : Form
{
    readonly IContainer _components;
    Label label1;
    TextBox textBox1;
    Button button1;
    Button button2;

    public ToolboxItemDialog() => InitializeComponent();

    void InitializeComponent()
    {
        label1 = new Label();
        textBox1 = new TextBox();
        button1 = new Button();
        button2 = new Button();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Location = new Point(10, 9);
        label1.Name = "label1";
        label1.Size = new Size(273, 43);
        label1.TabIndex = 0;
        label1.Text = "Enter the text you would like" +
            " to have the user control populated with:";
        // 
        // textBox1
        // 
        textBox1.AutoSize = false;
        textBox1.Location = new Point(10, 58);
        textBox1.Multiline = true;
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(270, 67);
        textBox1.TabIndex = 1;
        textBox1.Text = "This is a custom user control.  " +
            "The text you see here is provided by a custom toolbox" +
            " item when the user control is dropped on the form.";
        // 
        // button1
        // 
        button1.DialogResult = DialogResult.OK;
        button1.Location = new Point(124, 131);
        button1.Name = "button1";
        button1.TabIndex = 2;
        button1.Text = "OK";
        // 
        // button2
        // 
        button2.DialogResult = DialogResult.Cancel;
        button2.Location = new Point(205, 131);
        button2.Name = "button2";
        button2.TabIndex = 3;
        button2.Text = "Cancel";
        // 
        // ToolboxItemDialog
        // 
        AcceptButton = button1;
        CancelButton = button2;
        ClientSize = new Size(292, 162);
        ControlBox = false;
        Controls.Add(button2);
        Controls.Add(button1);
        Controls.Add(textBox1);
        Controls.Add(label1);
        FormBorderStyle =
            FormBorderStyle.FixedDialog;
        Name = "ToolboxItemDialog";
        Text = "ToolboxItemDialog";
        ResumeLayout(false);
    }

    public string CreationText => textBox1.Text;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (_components != null))
        {
            _components.Dispose();
        }
        base.Dispose(disposing);
    }
}
//</snippet1>
