﻿using System;
using System.Data;
using System.Security.Principal;
using System.Windows.Forms;

public class Form1: Form
{
 protected void Method()
 {
// <Snippet1>

 WindowsIdentity wi = WindowsIdentity.GetCurrent();
 WindowsPrincipal wp = new WindowsPrincipal(wi);

// </Snippet1>
 }
}
