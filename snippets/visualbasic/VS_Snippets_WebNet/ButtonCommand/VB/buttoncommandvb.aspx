<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Button CommandName Example</title>
<script runat="server">

      Sub CommandBtn_Click(sender As Object, e As CommandEventArgs) 

         Select e.CommandName

            Case "Sort"

               ' Call the method to sort the list.
               Sort_List(CType(e.CommandArgument, String))

            Case "Submit"

               ' Display a message for the Submit button being clicked.
               Message.Text = "You clicked the <b>Submit</b> button"

               ' Test whether the Command Argument is an empty string ("").
               If CType(e.CommandArgument , String) = "" Then
              
                  ' End the message.
                  Message.Text &= "."
               
               Else
               
                  ' Display an error message for the command argument. 
                  Message.Text &= ", but the command argument is not recogized."
               
               End If                

            Case Else

               ' The command name is not recognized. Display an error message.
               Message.Text = "Command name not recogized."

         End Select

      End Sub

      Sub Sort_List(commandArgument As String)

         Select commandArgument

            Case "Ascending"
 
               ' Insert code to sort the list in ascending order here.
               Message.Text = "You clicked the <b>Sort Ascending</b> button."

            Case "Descending"
              
               ' Insert code to sort the list in descending order here.
               Message.Text = "You clicked the <b>Sort Descending</b> button."

            Case Else
        
               ' The command argument is not recognized. Display an error message.
               Message.Text = "Command argument not recogized."

         End Select

      End Sub

      Sub Page_Load(sender As Object, e As EventArgs)

         ' Manually register the event-handling method for the Command  
         ' event of the Button controls.
         AddHandler Button1.Command, AddressOf CommandBtn_Click
         AddHandler Button2.Command, AddressOf CommandBtn_Click
         AddHandler Button3.Command, AddressOf CommandBtn_Click
         AddHandler Button4.Command, AddressOf CommandBtn_Click
         AddHandler Button5.Command, AddressOf CommandBtn_Click

      End Sub

   </script>

</head>
 
<body>

   <form id="form1" runat="server">

      <h3>Button CommandName Example</h3>

      Click one of the command buttons.

      <br /><br />
 
      <asp:Button id="Button1"
           Text="Sort Ascending"
           CommandName="Sort"
           CommandArgument="Ascending"
           runat="server"/>

      &nbsp;

      <asp:Button id="Button2"
           Text="Sort Descending"
           CommandName="Sort"
           CommandArgument="Descending"
           runat="server"/>

      <br /><br />

      <asp:Button id="Button3"
           Text="Submit"
           CommandName="Submit"
           runat="server"/>

      &nbsp;

      <asp:Button id="Button4"
           Text="Unknown Command Name"
           CommandName="UnknownName"
           CommandArgument="UnknownArgument"
           runat="server"/>

      &nbsp;

      <asp:Button id="Button5"
           Text="Submit Unknown Command Argument"
           CommandName="Submit"
           CommandArgument="UnknownArgument"
           runat="server"/>
       
      <br /><br />

      <asp:Label id="Message" runat="server"/>
 
   </form>
 
</body>
</html>

<!--</Snippet1>-->