﻿using System;
using System.Data;
using System.Security.Principal;
using System.Windows.Forms;

public class Form1: Form
{
 protected void Method()
 {
// <Snippet1>
Console.WriteLine(Uri.CheckHostName("www.contoso.com"));

// </Snippet1>
 }
}
