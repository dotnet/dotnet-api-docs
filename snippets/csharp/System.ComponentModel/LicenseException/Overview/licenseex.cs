﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace test2;

/// <summary>
/// Summary description for Form1.
/// </summary>
[LicenseProvider(typeof(LicFileLicenseProvider))]
public class Form1 : Form
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    readonly Container _components;

    public Form1()
    {
        InitializeComponent();
        //TODO: Add any constructor code after InitializeComponent call
    }

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _components?.Dispose();
            Dispose();
        }
    }

    #region Windows Form Designer generated code
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    void InitializeComponent()
    {
        // 
        // Form1
        // 
        ClientSize = new Size(292, 273);
        Name = "Form1";
        Text = "Form1";
        Load += Form1_Load;
    }
    #endregion

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main() => Application.Run(new Form1());

    void Form1_Load(object sender, EventArgs e)
    {
        //<snippet1>
        try
        {
            License licTest = null;
            licTest = LicenseManager.Validate(typeof(Form1), this);
        }
        catch (LicenseException licE)
        {
            Console.WriteLine(licE.Message);
            Console.WriteLine(licE.LicensedType);
            Console.WriteLine(licE.StackTrace);
            Console.WriteLine(licE.Source);
        }
        //</snippet1>
    }
}
