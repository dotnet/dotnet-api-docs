﻿using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataColumnMappingCollection mappings;

    // <Snippet1>

    public void RemoveDataColumnMapping()
    {
        // ...
        // create mappings
        // ...
        if (mappings.Contains(7))
            mappings.RemoveAt(7);
    }
    // </Snippet1>
}
