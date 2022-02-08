<!-- <Snippet1> -->

<%@ Page language="VB" %>
<%@ import namespace="System.Data"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  ' To dynamically create a template for a FormView control,
  ' you must create a custom template class to represent 
  ' the template. This template class represents the item
  ' template for a FormView control.
  Private NotInheritable Class EmployeeItemTemplate
    Implements ITemplate

    ' When implementing the ITemplate interface, you must
    ' implement the InstantiateIn method. The FormView
    ' control calls this method to create the template's 
    ' content. 
    Sub InstantiateIn(ByVal container As Control) Implements ITemplate.InstantiateIn
      
      ' Create the child controls contained in the template.
      ' For this example, the item template displays the
      ' FirstName and LastName fields from the data source.
      ' To support data binding, create event handlers 
      ' for the DataBinding event of each child control.
      ' The event handlers must bind the appropriate value 
      ' to each control.
      Dim firstNameLabel As New Label()
      firstNameLabel.ID = "FirstNameLabel"
      AddHandler firstNameLabel.DataBinding, AddressOf FirstNameLabel_DataBinding

      Dim nameLineBreak As New LiteralControl("<br/>")
      Dim buttonLineBreak As New LiteralControl("<br/>")

      Dim lastNameLabel As New Label()
      lastNameLabel.ID = "LastNameLabel"
      AddHandler lastNameLabel.DataBinding, AddressOf LastNameLabel_DataBinding

      Dim editButton As New Button()
      editButton.ID = "EditButton"
      editButton.CommandName = "Edit"
      editButton.Text = "Edit"

      ' Add the controls to the Controls collection of the 
      ' container control.
      container.Controls.Add(firstNameLabel)
      container.Controls.Add(nameLineBreak)
      container.Controls.Add(lastNameLabel)
      container.Controls.Add(buttonLineBreak)
      container.Controls.Add(editButton)

    End Sub

    ' This event handler binds the value of the FirstName field
    ' to the FirstNameLabel Label control displayed in the template.
    Private Sub FirstNameLabel_DataBinding(ByVal sender As Object, ByVal e As EventArgs)
      
      ' Use the sender parameter to retrieve the Label control
      ' being bound to data.
      Dim firstNameLabelControl As Label = CType(sender, Label)

      ' Retrieve the value to bind to the Label control. First,
      ' use the NamingContainer property to retrieve the parent 
      ' control of the Label control. In this example, the parent 
      ' control is the FormView control.
      Dim formViewContainer As FormView = CType(firstNameLabelControl.NamingContainer, FormView)

      ' Get the data item bound to the FormView control.
      Dim rowView As DataRowView = CType(formViewContainer.DataItem, DataRowView)

      ' Use the data item to retrieve the value of the FirstName field.
      ' Set the Text property of the Label control to this value.        
      firstNameLabelControl.Text = rowView("FirstName").ToString()
      
    End Sub

    ' This event handler binds the value of the LastName field
    ' to the LastNameLabel Label control displayed in the template.
    Private Sub LastNameLabel_DataBinding(ByVal sender As Object, ByVal e As EventArgs)

      ' Use the sender parameter to retrieve the Label control
      ' being bound to data.
      Dim lastNameLabelControl As Label = CType(sender, Label)

      ' Retrieve the value to bind to the Label control. First,
      ' use the NamingContainer property to retrieve the parent 
      ' control of the Label control. In this example, the parent 
      ' control is the FormView control.
      Dim formViewContainer As FormView = CType(lastNameLabelControl.NamingContainer, FormView)

      ' Get the data item bound to the FormView control.
      Dim rowView As DataRowView = CType(formViewContainer.DataItem, DataRowView)

      ' Use the data item to retrieve the value of the LastName field.
      ' Set the Text property of the Label control to this value.         
      lastNameLabelControl.Text = rowView("LastName").ToString()
    
    End Sub


  End Class
  
  ' This template class represents the edit item
  ' template for a FormView control.
  Private NotInheritable Class EmployeeEditItemTemplate
    Implements ITemplate

    Sub InstantiateIn(ByVal container As Control) Implements ITemplate.InstantiateIn
      ' Create the child controls contained in the template.
      ' The edit item template should contain the input 
      ' controls for the user to edit a record.
      Dim firstNameTextBox As New TextBox()
      firstNameTextBox.ID = "FirstNameTextBox"

      Dim nameLineBreak As New LiteralControl("<br/>")
      Dim buttonLineBreak As New LiteralControl("<br/>")

      Dim lastNameTextBox As New TextBox()
      lastNameTextBox.ID = "LastNameTextBox"

      Dim updateButton As New Button()
      updateButton.ID = "UpdateButton"
      updateButton.CommandName = "Update"
      updateButton.Text = "Update"

      Dim cancelButton As New Button()
      cancelButton.ID = "CancelButton"
      cancelButton.CommandName = "Cancel"
      cancelButton.Text = "Cancel"

      ' Add the controls to the Controls collection of the 
      ' container control.
      container.Controls.Add(firstNameTextBox)
      container.Controls.Add(nameLineBreak)
      container.Controls.Add(lastNameTextBox)
      container.Controls.Add(buttonLineBreak)
      container.Controls.Add(updateButton)
      container.Controls.Add(cancelButton)

    End Sub
    
  End Class

  Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

    ' Create a new FormView object.
    Dim employeesFormView As New FormView()

    ' Set the FormView object's properties.
    employeesFormView.ID = "EmployeesFormView"
    employeesFormView.DataSourceID = "EmployeeSource"
    employeesFormView.AllowPaging = True
    employeesFormView.HeaderText = "Employee Name"
    
    Dim keyArray() As String = {"EmployeeID"}
    employeesFormView.DataKeyNames = keyArray

    ' Programmatically register the event handlers for 
    ' the FormView control.
    AddHandler employeesFormView.PageIndexChanging, AddressOf EmployeeFormView_PageIndexChanging
    AddHandler employeesFormView.ModeChanged, AddressOf EmployeeFormView_ModeChanged
    AddHandler employeesFormView.ItemUpdating, AddressOf EmployeeFormView_ItemUpdating

    ' Create the dynamic templates using the custom template classes.
    employeesFormView.ItemTemplate = New EmployeeItemTemplate()
    employeesFormView.EditItemTemplate = New EmployeeEditItemTemplate()
    ' Add the FormView object to the Controls collection
    ' of the PlaceHolder control.
    FormViewPlaceHolder.Controls.Add(employeesFormView)

  End Sub

  Sub EmployeeFormView_ItemUpdating(ByVal sender As Object, ByVal e As FormViewUpdateEventArgs)
    
    ' Because the FormView control is dynamically generated, 
    ' the NewValues collection must be programmatically populated
    ' with the values for the record to update.

    ' Use the sender argument to retrieve the FormView
    ' control that raised the event.
    Dim employeeFormView As FormView = CType(sender, FormView)
    
    ' Retrieve the data row from the FormView control.
    Dim row As FormViewRow = employeeFormView.Row

    ' Retrieve the TextBox controls that contain the updated values 
    ' entered by the user. 
    Dim firstNameTextBox As TextBox = CType(row.FindControl("FirstNameTextBox"), TextBox)
    Dim lastNameTextBox As TextBox = CType(row.FindControl("LastNameTextBox"), TextBox)

    If firstNameTextBox IsNot Nothing And lastNameTextBox IsNot Nothing Then
    
      ' Add the new values to the NewValues collections.
      e.NewValues.Add("FirstName", firstNameTextBox.Text)
      e.NewValues.Add("LastName", lastNameTextBox.Text)
      
    End If

  End Sub

  Sub EmployeeFormView_PageIndexChanging(ByVal sender As Object, ByVal e As FormViewPageEventArgs)
  
    ' Use the sender argument to retrieve the FormView
    ' control that raised the event.
    Dim employeeFormView As FormView = CType(sender, FormView)
    
    ' Cancel the paging operation if the FormView control 
    ' is in edit mode.
    If employeeFormView.CurrentMode = FormViewMode.Edit Then
    
      e.Cancel = True
      
      ' Display an error message.
      Dim newPage As Integer = e.NewPageIndex + 1
      MessageLabel.Text = "Please update the current record before moving to page " & _
        newPage.ToString() & "."
    
    End If
    
  End Sub

  Sub EmployeeFormView_ModeChanged(ByVal sender As Object, ByVal e As EventArgs)
  
    ' Clear the message label.
    MessageLabel.Text = ""
  
  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>FormView Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>FormView Example</h3>
      
      <!-- Use a PlaceHolder control as the container for the -->
      <!-- dynamically generated FormView control.            -->       
      <asp:placeholder id="FormViewPlaceHolder"
        runat="server"/>
      
      <br/><br/>
      
      <asp:label id="MessageLabel"
        forecolor="Red"
        runat="server"/>

      <!-- This example uses Microsoft SQL Server and connects  -->
      <!-- to the Northwind sample database. Use an ASP.NET     -->
      <!-- expression to retrieve the connection string value   -->
      <!-- from the Web.config file.                            -->
      <asp:sqldatasource id="EmployeeSource"
        selectcommand="Select [EmployeeID], [LastName], [FirstName] From [Employees]"
        updatecommand="Update [Employees] Set [LastName]=@LastName, [FirstName]=@FirstName Where [EmployeeID]=@EmployeeID"
        connectionstring="<%$ ConnectionStrings:NorthWindConnectionString%>" 
        runat="server"/>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->