using System;
using System.Data;
using System.Windows.Forms;

public class Form2 : Form
{
    protected DataSet DataSet1;

    // <Snippet1>
    private void AddUniqueConstraint(DataTable table)
    {
        DataColumn[] columns =
        [
            table.Columns["ID"],
            table.Columns["Name"]
        ];
        table.Constraints.Add("idNameConstraint", columns, true);
    }
    // </Snippet1>
}
