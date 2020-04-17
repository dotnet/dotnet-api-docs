﻿using System;
using System.Windows.Forms;
using System.Diagnostics;

public class Form1: Form
{
    protected TextBox textBox1;

    // <Snippet1>
    private void GetFileMinorPart()
    {
        // Get the file version for the notepad.
        FileVersionInfo myFileVersionInfo =
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\\Notepad.exe");

        // Print the file minor part number.
        textBox1.Text = "File minor part number: " + myFileVersionInfo.FileMinorPart;
    }
    // </Snippet1>
}
