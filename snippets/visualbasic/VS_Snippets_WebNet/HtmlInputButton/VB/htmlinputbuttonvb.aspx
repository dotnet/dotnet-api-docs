<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

      Protected Sub AddButton_Click(sender As Object, e As EventArgs)

         Dim Answer As Integer

         Answer = Convert.ToInt32(Value1.Value) + Convert.ToInt32(Value2.Value)

         AnswerMessage.InnerHtml = Answer.ToString()

      End Sub

   </script>

<html xmlns="http://www.w3.org/1999/xhtml" > 

<head>
    <title> HtmlInputButton Example </title>
</head>
<body>
<form id="form1" runat="server">
    <div>

    <h3> HtmlInputButton Example </h3>

    <table>
        <tr>
            <td colspan="5">

               Enter integer values into the text boxes. <br />
               Click the Add button to add the two values. <br />
               Click the Reset button to reset the text boxes.

            </td>
        </tr>
        <tr>
            <td colspan="5">
                &nbsp;
            </td>
        </tr>
        <tr align="center">
            <td>

                <input id="Value1"
                    type="Text"
                    size="2"
                    maxlength="3"
                    value="1"
                    runat="server"/>

            </td>
            <td>
                + 
            </td>
            <td>
                <input id="Value2"
                    type="Text"
                    size="2"
                    maxlength="3"
                    value="1"
                    runat="server"/>

            </td>
            <td>
                =

            </td>
            <td>
               <span id="AnswerMessage"
                     runat="server"/>
            </td>
        </tr>
        <tr>
            <td colspan="2">

                <asp:RequiredFieldValidator
                     ID="Value1RequiredValidator"
                     ControlToValidate="Value1"
                     ErrorMessage="Please enter a value.<br />"
                     Display="Dynamic"
                     runat="server"/>

                <asp:CompareValidator
                     ID="Value1MinCompareValidator"
                     ControlToValidate="Value1"
                     Operator="LessThan"
                     Type="Integer"
                     ValueToCompare="100"
                     ErrorMessage="Please enter an integer less than 100.<br />"
                     Display="Dynamic"
                     runat="server"/>

                <asp:CompareValidator
                     ID="Value1MaxCompareValidator"
                     ControlToValidate="Value1"
                     Operator="GreaterThan"
                     Type="Integer"
                     ValueToCompare="0"
                     ErrorMessage="Please enter an integer greater than 0.<br />"
                     Display="Dynamic"
                     runat="server"/>

            </td>
            <td colspan="2">

                <asp:RequiredFieldValidator
                     ID="Value2RequiredValidator"
                     ControlToValidate="Value2"
                     ErrorMessage="Please enter a value.<br />"
                     Display="Dynamic"
                     runat="server"/>

                <asp:CompareValidator
                     ID="Value2MinCompareValidator"
                     ControlToValidate="Value2"
                     Operator="LessThan"
                     Type="Integer"
                     ValueToCompare="100"
                     ErrorMessage="Please enter an integer less than 100.<br />"
                     Display="Dynamic"
                     runat="server"/>

                <asp:CompareValidator
                     ID="Value2MaxCompareValidator"
                     ControlToValidate="Value2"
                     Operator="GreaterThan"
                     Type="Integer"
                     ValueToCompare="0"
                     ErrorMessage="Please enter an integer greater than 0.<br />"
                     Display="Dynamic"
                     runat="server"/>

            </td>
            <td>
               &nbsp;
            </td>
         </tr>
         <tr align="center">
            <td colspan="4">

               <input type="Submit"
                      id="SubmitButton"
                      value="Add"
                      onserverclick="AddButton_Click"
                      runat="server"/>

               &nbsp;&nbsp;&nbsp;

               <input type="Reset"
                      id="ResetButton"
                      value="Reset"
                      runat="server"/>

            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>

    </div>
</form>
</body>
</html>
<!--</Snippet1>-->