<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void Button_Click(Object sender, EventArgs e)
  {

    HtmlTableRow current_row;

    // Create an IEnumerator enumerator.
    IEnumerator myEnum = Table1.Rows.GetEnumerator();

    Span1.InnerText = "The items in the rows of the table are: ";

    // Iterate through the IEnumerator and display its contents.
    while (myEnum.MoveNext())
    {

      current_row = (HtmlTableRow)myEnum.Current;
      Span1.InnerText = Span1.InnerText + " " + current_row.Cells[0].InnerText +
                        " " + current_row.Cells[1].InnerText;

    }

  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
   <title>HtmlTableRowCollection Example</title>
</head>
<body>

   <form id="form1" runat="server">

      <h3>HtmlTableRowCollection Example</h3>

       <table id="Table1" runat="server" 
       style="border-width: 1; border-color: Black">

         <tr>
            <td>
               Cell 1
            </td>
            <td>
               Cell 2
            </td>
         </tr>
         <tr>
            <td>
               Cell 3
            </td>
            <td>
               Cell 4
            </td>
         </tr>

      </table>

      <br /><br />
  
      <input type="button" 
             value="Display row contents in the table"
             onserverclick="Button_Click" 
             runat="server"/>

      <br /><br />

      <span id="Span1"
            runat="server"/>

   </form>

</body>
</html>
<!--</Snippet1>-->