﻿using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
    // <Snippet1>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
     public int MyProperty {
        get {
           // Insert code here.
           return(0);
        }
        set {
           // Insert code here.
        }
     }
    // </Snippet1>
}
