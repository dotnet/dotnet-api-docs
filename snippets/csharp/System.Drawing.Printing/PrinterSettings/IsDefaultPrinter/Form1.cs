using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

public class Form1 : Form
{
    public static void Main()
    {
        Application.Run(new Form1());
    }

    public Form1()
    {
        Load += Form1_Load;
    }

    //<snippet1>
    private readonly ComboBox _comboInstalledPrinters = new();
    private readonly PrintDocument _printDoc = new();

    private void PopulateInstalledPrintersCombo()
    {
        _comboInstalledPrinters.Dock = DockStyle.Top;
        Controls.Add(_comboInstalledPrinters);

        // Add list of installed printers found to the combo box.
        // The pkInstalledPrinters string will be used to provide the display string.
        for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
        {
            string pkInstalledPrinters = PrinterSettings.InstalledPrinters[i];
            _comboInstalledPrinters.Items.Add(pkInstalledPrinters);
            if (_printDoc.PrinterSettings.IsDefaultPrinter)
            {
                _comboInstalledPrinters.Text = _printDoc.PrinterSettings.PrinterName;
            }
        }
    }
    //</snippet1>

    private void Form1_Load(object sender, EventArgs e) => PopulateInstalledPrintersCombo();
}
