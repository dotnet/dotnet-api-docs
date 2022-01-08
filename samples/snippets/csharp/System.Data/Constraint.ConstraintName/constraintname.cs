using System;
using System.Data;
using System.Windows.Forms;

public class Form2: Form
{

// <Snippet1>
 private void PrintConstraintNames(DataTable myTable){
    foreach(Constraint cs in myTable.Constraints){
       Console.WriteLine(cs.ConstraintName);
    }
 }
// </Snippet1>
}
