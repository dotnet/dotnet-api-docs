//<snippet0>
//<snippet1>
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
//</snippet1>

//<snippet2>
namespace BindingSourceExamples;

public class Form1 : Form
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new Form1());
    }

    public Form1() => Load += Form1_Load;

    TextBox textBox1;
    Button button1;
    ListBox listBox1;

    BindingSource binding1;
    void Form1_Load(object sender, EventArgs e)
    {
        listBox1 = new ListBox();
        textBox1 = new TextBox();
        binding1 = [];
        button1 = new Button();
        listBox1.Location = new Point(140, 25);
        listBox1.Size = new Size(123, 160);
        textBox1.Location = new Point(23, 70);
        textBox1.Size = new Size(100, 20);
        textBox1.Text = "Wingdings";
        button1.Location = new Point(23, 25);
        button1.Size = new Size(75, 23);
        button1.Text = "Search";
        button1.Click += button1_Click;
        ClientSize = new Size(292, 266);
        Controls.Add(button1);
        Controls.Add(textBox1);
        Controls.Add(listBox1);

        MyFontList fonts = [];
        for (int i = 0; i < FontFamily.Families.Length; i++)
        {
            if (FontFamily.Families[i].IsStyleAvailable(FontStyle.Regular))
            {
                fonts.Add(new Font(FontFamily.Families[i], 11.0F, FontStyle.Regular));
            }
        }
        binding1.DataSource = fonts;
        listBox1.DataSource = binding1;
        listBox1.DisplayMember = "Name";
    }

    //<snippet4>
    void button1_Click(object sender, EventArgs e)
    {
        if (!binding1.SupportsSearching)
        {
            _ = MessageBox.Show("Cannot search the list.");
        }
        else
        {
            int foundIndex = binding1.Find("Name", textBox1.Text);
            if (foundIndex > -1)
            {
                listBox1.SelectedIndex = foundIndex;
            }
            else
            {
                _ = MessageBox.Show("Font was not found.");
            }
        }
    }
    //</snippet4>
}

//</snippet2>
//<snippet3>
public class MyFontList : BindingList<Font>
{
    protected override bool SupportsSearchingCore => true;
    protected override int FindCore(PropertyDescriptor prop, object key)
    {
        // Ignore the prop value and search by family name.
        for (int i = 0; i < Count; ++i)
        {
            if (Items[i].FontFamily.Name.Equals((string)key, StringComparison.CurrentCultureIgnoreCase))
            {
                return i;
            }
        }
        return -1;
    }
}
//</snippet3>
//</snippet0>
