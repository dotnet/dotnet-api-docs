<!-- <Snippet1> -->
<!-- This example demonstrates how to set property values for the
BorderColor, BorderStyle, and BorderWidth properties, and how to 
change the property values at run time. -->

<!-- </Snippet1> -->
<!-- <Snippet2> -->
<!-- To view this code snippet in a fully-working example, see the 
Control Class topic. -->

<!-- </Snippet2> -->
<!-- <Snippet3> -->
<%@ Page language="c#" AutoEventWireup="true" %>
<%@ Import Namespace="System.Drawing" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
    private void Page_Load(object sender, System.EventArgs e)
    {
        // Determine whether this is the first time the page is loaded;
        // if so, load the drop-down lists with data.
        if (!Page.IsPostBack)
        {
// <Snippet4>
            // Create a ListItemCollection and add names of colors.
            ListItemCollection colors = new ListItemCollection();
            colors.Add(Color.Black.Name);
            colors.Add(Color.Blue.Name);
            colors.Add(Color.Green.Name);
            colors.Add(Color.Orange.Name);
            colors.Add(Color.Purple.Name);
            colors.Add(Color.Red.Name);
            colors.Add(Color.White.Name);
            colors.Add(Color.Yellow.Name);
// </Snippet4>
            // Bind the colors collection to the borderColorList.
            borderColorList.DataSource = colors;
            borderColorList.DataBind();

            // Create a ListItemCollection and the add names of 
            // the BorderStyle enumeration values.
            ListItemCollection styles = new ListItemCollection();

            foreach (string s in Enum.GetNames(typeof(BorderStyle)))
            {
                styles.Add(s);
            }

            // Bind the styles collection to the borderStyleList.
            borderStyleList.DataSource = styles;
            borderStyleList.DataBind();

            // Create a ListItemCollection and add width values
            // expressed in pixels (px).
            ListItemCollection widths = new ListItemCollection();

            for (int i = 0; i < 11; i++)
            {
                widths.Add(i.ToString() + "px");
            }

            // Bind the widths collection to the borderWidthList.
            borderWidthList.DataSource = widths;
            borderWidthList.DataBind();
        }

    }

    // This method handles the SelectedIndexChanged event for borderColorList.
    public void ChangeBorderColor(object sender, System.EventArgs e)
    {
// <Snippet5>
        // Convert the color name string to an object of type Color, 
        // and set the Color as the new border color for Label1.
        Label1.BorderColor = Color.FromName(borderColorList.SelectedItem.Text);
// </Snippet5>
    }

    // This method handles the selectedIndexChanged event for boderStyleList.
    public void ChangeBorderStyle(object sender, System.EventArgs e)
    {
// <Snippet6>
        // Convert the style name string to a BorderStyle enumeration value,
        // and set the BorderStyle as the new border style for Label1.
        Label1.BorderStyle = (BorderStyle)Enum.Parse(typeof(BorderStyle),
                              borderStyleList.SelectedItem.Text);
// </Snippet6>
    }

    // This method handles the SelectedIndexChanged event for borderWidthList.
    public void ChangeBorderWidth(object sender, System.EventArgs e)
    {
// <Snippet7>
        // Convert the border width string to a object of type Unit,
        // and set the Unit as the new border width for Label1.
        Label1.BorderWidth = Unit.Parse(borderWidthList.SelectedItem.Text);
// </Snippet7>
    }
    </script>
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head>
    <title> Border Properties Example </title>
</head>

    <body>
        <form id="form1" runat="server">

            <h3> Border Properties Example </h3>

            <table border="0" cellpadding="6">
                <tr>
                    <td>
                        <asp:Label Runat="server" BorderColor="Black" 
                            BorderStyle="Solid" BorderWidth="4px" ID="Label1" 
                            Text="Border Properties Example" Height="75" 
                            Width="200"><center><br />Border Properties Example
                            </center></asp:Label>
                    </td>

                    <td>
<!-- <Snippet8> -->
                        <asp:DropDownList Runat="server" ID="borderColorList" 
                            OnSelectedIndexChanged="ChangeBorderColor" AutoPostBack="True" 
                            EnableViewState="True"></asp:DropDownList>
<!-- </Snippet8> -->
                        <br />
                        <br />
<!-- <Snippet9> -->
                        <asp:DropDownList Runat="server" ID="borderStyleList" 
                            OnSelectedIndexChanged="ChangeBorderStyle" AutoPostBack="True" 
                            EnableViewState="True"></asp:DropDownList>
<!-- </Snippet9> -->
                        <br />            
                        <br />
<!-- <Snippet10> -->
                        <asp:DropDownList Runat="server" ID="borderWidthList" 
                            OnSelectedIndexChanged="ChangeBorderWidth" AutoPostBack="True"
                            EnableViewState="True"></asp:DropDownList>
<!-- </Snippet10> -->
                    </td>
                </tr>
            </table>
        </form>
    </body>
</html>
<!-- </Snippet3> -->
