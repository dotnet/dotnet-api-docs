﻿using System;
using System.Data;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

public class Form1: Page

{
 protected Label Label2;
// <Snippet1>
void R1_ItemCommand(Object Sender, RepeaterCommandEventArgs e) {
    Label2.Text = "The index of the item is " + e.Item.ItemIndex.ToString();
 }

// </Snippet1>
}
