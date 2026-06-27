// <snippet1>
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.ComponentModel;

public class MyIconButton : Button
{
    private Icon _icon;

    public MyIconButton()
    {
        // Set the button's FlatStyle property.
        FlatStyle = FlatStyle.System;
    }

    public MyIconButton(Icon ButtonIcon)
        : this()
    {
        // Assign the icon to the private field.   
        _icon = ButtonIcon;

        // Size the button to 4 pixels larger than the icon.
        Height = _icon.Height + 4;
        Width = _icon.Width + 4;
    }

    //<snippet3>
    protected override CreateParams CreateParams
    {
        get
        {
            // Extend the CreateParams property of the Button class.
            CreateParams cp = base.CreateParams;
            // Update the button Style.
            cp.Style |= 0x00000040; // BS_ICON value

            return cp;
        }
    }
    //</snippet3>     

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public Icon Icon
    {
        get
        {
            return _icon;
        }

        set
        {
            _icon = value;
            UpdateIcon();
            // Size the button to 4 pixels larger than the icon.
            Height = _icon.Height + 4;
            Width = _icon.Width + 4;
        }
    }

    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);

        // Update the icon on the button if there is
        // currently an icon assigned to the icon field.
        if (_icon != null)
        {
            UpdateIcon();
        }
    }

    private void UpdateIcon()
    {
        IntPtr iconHandle = IntPtr.Zero;

        // Get the icon's handle.
        if (_icon != null)
        {
            iconHandle = _icon.Handle;
        }

        // Send Windows the message to update the button. 
        SendMessage(
            Handle,
            0x00F7 /*BM_SETIMAGE value*/,
            1 /*IMAGE_ICON value*/,
            (int)iconHandle);
    }

    // Import the SendMessage method of the User32 DLL.   
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
}
// </snippet1>

/////////////////////////////////////////////////////////////////////////////////////////////////////////////

// <snippet2>
public class MyApplication : Form
{
    private readonly MyIconButton _myIconButton;
    private readonly Button _stdButton;
    private OpenFileDialog _openDlg;

    static void Main()
    {
        Application.Run(new MyApplication());
    }

    public MyApplication()
    {
        try
        {
            // Create the button with the default icon.
            _myIconButton = new MyIconButton(new Icon(Application.StartupPath + "\\Default.ico"));
        }
        catch (Exception ex)
        {
            // If the default icon does not exist, create the button without an icon.
            _myIconButton = new MyIconButton();
            Debug.WriteLine(ex.ToString());
        }
        finally
        {
            _stdButton = new Button();

            // Add the Click event handlers.
            _myIconButton.Click += new EventHandler(myIconButton_Click);
            _stdButton.Click += new EventHandler(stdButton_Click);

            // Set the location, text and width of the standard button.
            _stdButton.Location = new Point(
                _myIconButton.Location.X,
                _myIconButton.Location.Y + _myIconButton.Height + 20);
            _stdButton.Text = "Change Icon";
            _stdButton.Width = 100;

            // Add the buttons to the Form.
            Controls.Add(_stdButton);
            Controls.Add(_myIconButton);
        }
    }

    private void myIconButton_Click(object Sender, EventArgs e)
    {
        // Make sure MyIconButton works.
        MessageBox.Show("MyIconButton was clicked!");
    }

    private void stdButton_Click(object Sender, EventArgs e)
    {
        // Use an OpenFileDialog to allow the user
        // to assign a new image to the derived button.
        _openDlg = new OpenFileDialog
        {
            InitialDirectory = Application.StartupPath,
            Filter = "Icon files (*.ico)|*.ico",
            Multiselect = false
        };
        _openDlg.ShowDialog();

        if (_openDlg.FileName != "")
        {
            _myIconButton.Icon = new Icon(_openDlg.FileName);
        }
    }
}
// </snippet2>
