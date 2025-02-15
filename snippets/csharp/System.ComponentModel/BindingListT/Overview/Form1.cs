//<snippet1>
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace BindingListOfTExamples;

public partial class Form1 : Form
{
    readonly TextBox textBox2;
    readonly ListBox listBox1;
    readonly Button button1;
    readonly TextBox textBox1;
    readonly Random randomNumber = new();

    public Form1()
    {
        AutoScaleMode = AutoScaleMode.Font;
        textBox1 = new TextBox();
        textBox2 = new TextBox();
        listBox1 = new ListBox();
        button1 = new Button();
        textBox1.Location = new Point(169, 26);
        textBox1.Size = new Size(100, 20);
        textBox1.Text = "Bracket";
        textBox2.Location = new Point(169, 57);
        textBox2.ReadOnly = true;
        textBox2.Size = new Size(100, 20);
        textBox2.Text = "4343";
        listBox1.FormattingEnabled = true;
        listBox1.Location = new Point(12, 12);
        listBox1.Size = new Size(120, 95);
        button1.Location = new Point(180, 83);
        button1.Size = new Size(75, 23);
        button1.Text = "Add New Item";
        button1.Click += button1_Click;
        ClientSize = new Size(292, 266);
        Controls.Add(button1);
        Controls.Add(listBox1);
        Controls.Add(textBox2);
        Controls.Add(textBox1);
        Text = "Parts Form";
        Load += Form1_Load;
    }

    void Form1_Load(object sender, EventArgs e)
    {
        InitializeListOfParts();
        listBox1.DataSource = listOfParts;
        listBox1.DisplayMember = "PartName";
        listOfParts.AddingNew += listOfParts_AddingNew;
        listOfParts.ListChanged += listOfParts_ListChanged;
    }

    //<snippet2>
    // Declare a new BindingListOfT with the Part business object.
    BindingList<Part> listOfParts;
    void InitializeListOfParts()
    {
        // Create the new BindingList of Part type.
        listOfParts = new BindingList<Part>
        {
            // Allow new parts to be added, but not removed once committed.        
            AllowNew = true,
            AllowRemove = false,

            // Raise ListChanged events when new parts are added.
            RaiseListChangedEvents = true,

            // Do not allow parts to be edited.
            AllowEdit = false
        };

        // Add a couple of parts to the list.
        listOfParts.Add(new Part("Widget", 1234));
        listOfParts.Add(new Part("Gadget", 5647));
    }
    //</snippet2>

    //<snippet3>
    // Create a new part from the text in the two text boxes.
    void listOfParts_AddingNew(object sender, AddingNewEventArgs e) => e.NewObject = new Part(textBox1.Text, int.Parse(textBox2.Text));
    //</snippet3>

    //<snippet4>
    // Add the new part unless the part number contains
    // spaces. In that case cancel the add.
    void button1_Click(object sender, EventArgs e)
    {
        Part newPart = listOfParts.AddNew();

        if (newPart.PartName.Contains(' '))
        {
            _ = MessageBox.Show("Part names cannot contain spaces.");
            listOfParts.CancelNew(listOfParts.IndexOf(newPart));
        }
        else
        {
            textBox2.Text = randomNumber.Next(9999).ToString();
            textBox1.Text = "Enter part name";
        }
    }
    //</snippet4>

    //<snippet5>
    void listOfParts_ListChanged(object sender, ListChangedEventArgs e) => MessageBox.Show(e.ListChangedType.ToString());
    //</snippet5>

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new Form1());
    }
}

// A simple business object for example purposes.
public class Part
{
    public Part() { }
    public Part(string nameForPart, int numberForPart)
    {
        PartName = nameForPart;
        PartNumber = numberForPart;
    }

    public string PartName { get; set; }

    public int PartNumber { get; set; }
}
//</snippet1>
