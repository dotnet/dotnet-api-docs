﻿using System;
using System.Xml;
using System.Data;
using System.Data.Odbc;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
  protected DataSet DataSet1;
  protected DataGrid dataGrid1;

// <Snippet1>
 public void CreateOdbcParameter()
 {
    OdbcParameter parameter = new OdbcParameter();
    parameter.ParameterName = "Description";
    parameter.OdbcType = OdbcType.VarChar;
    parameter.Direction = ParameterDirection.Output;
    parameter.Size = 88;
 }
   // </Snippet1>
}
