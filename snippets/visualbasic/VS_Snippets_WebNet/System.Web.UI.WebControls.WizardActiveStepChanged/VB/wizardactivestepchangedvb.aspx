<!-- <snippet1> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
  
  Sub OnActiveStepChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    
    ' Every time that the ActiveStep property changes, change the HeaderText to match it.
    Wizard1.HeaderText = "You are currently on " + Wizard1.ActiveStep.Title
    
  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
      <form id="form1" runat="server">
        <asp:Wizard ID="Wizard1" 
          Runat="server" 
          OnActiveStepChanged="OnActiveStepChanged" 
          HeaderText="ActiveStepChanged Example">
          <WizardSteps>
            <asp:WizardStep ID="WizardStep1" Title="Step 1" 
              Runat="server">
            </asp:WizardStep>
            <asp:WizardStep ID="WizardStep2" Title="Step 2" 
              Runat="server">
            </asp:WizardStep>
          </WizardSteps>
        </asp:Wizard>
      </form>
  </body>
</html>
<!-- </snippet1> -->