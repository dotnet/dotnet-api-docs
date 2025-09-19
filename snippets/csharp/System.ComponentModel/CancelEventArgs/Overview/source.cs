using System.ComponentModel;
using System.Windows.Forms;

public class Form1 : Form
{
    protected bool isDataSaved;
    // <Snippet1>
    // Call this method from the constructor of your form
    void OtherInitialize()
    {
        Closing += Form1_Closing;
        // Exchange commented line and note the difference.
        isDataSaved = true;
        //this.isDataSaved = false;
    }

    void Form1_Closing(object sender, CancelEventArgs e)
    {
        if (!isDataSaved)
        {
            e.Cancel = true;
            _ = MessageBox.Show("You must save first.");
        }
        else
        {
            e.Cancel = false;
            _ = MessageBox.Show("Goodbye.");
        }
    }

    // </Snippet1>
}
