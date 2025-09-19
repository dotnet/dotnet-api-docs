﻿using System;
using System.IO;
using System.Printing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Xps.Packaging;

namespace PrintDialog_Sample
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {
        // <Snippet1>
        private void InvokePrint(object sender, RoutedEventArgs e)
        {
            // Create the print dialog object and set options
            PrintDialog pDialog = new PrintDialog();
            pDialog.PageRangeSelection = PageRangeSelection.AllPages;
            pDialog.UserPageRangeEnabled = true;

            // Display the dialog. This returns true if the user presses the Print button.
            Nullable<Boolean> print = pDialog.ShowDialog();
            if (print.Value)
            {
                XpsDocument xpsDocument = new XpsDocument("C:\\FixedDocumentSequence.xps", FileAccess.ReadWrite);
                FixedDocumentSequence fixedDocSeq = xpsDocument.GetFixedDocumentSequence();
                pDialog.PrintDocument(fixedDocSeq.DocumentPaginator, "Test print job");
            }
        }
        // </Snippet1>
        // <Snippet5>
        private void GetHeight(object sender, RoutedEventArgs e)
        {
            PrintDialog pDialog = new PrintDialog();
            PrintTicket pt = pDialog.PrintTicket;   //force initialization of the dialog's PrintTicket or PrintQueue
            txt1.Text = pDialog.PrintableAreaHeight.ToString() + " is the printable height";
        }
        // </Snippet5>
        // <Snippet6>
        private void GetWidth(object sender, RoutedEventArgs e)
        {
            PrintDialog pDialog = new PrintDialog();
            PrintQueue pq = pDialog.PrintQueue;     //force initialization of the dialog's PrintTicket or PrintQueue
            txt2.Text = pDialog.PrintableAreaWidth.ToString() + " is the printable width";
        }
        // </Snippet6>
    }
}
