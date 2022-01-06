using System;
using System.Data;
using System.Windows.Forms;

public class Form3: Form
{
  protected DataSet DataSet1;

// <Snippet1>
 private void AddUniqueConstraint(DataTable table){
    table.Constraints.Add("idConstraint", table.Columns["id"], true);
 }
// </Snippet1>
}
