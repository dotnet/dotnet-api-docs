using System;
using System.Data;
using System.Windows.Forms;

public class Form2 : Form
{
    // <Snippet1>
    private void PrintConstraintNames(DataTable myTable)
    {
        foreach (Constraint constraint in myTable.Constraints)
        {
            Console.WriteLine(constraint.ConstraintName);
        }
    }
    // </Snippet1>
}
