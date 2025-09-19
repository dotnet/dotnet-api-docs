<!-- <Snippet2> -->
<%@ Page Language="C#" %>
<%@ Implements Interface="System.Web.UI.ICallbackEventHandler" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server" >
        
    string _cbMessage = "";
    // Define method that processes the callbacks on server.
    public void RaiseCallbackEvent(String eventArgument)
    {
        try
        {
            Page.ClientScript.ValidateEvent(button1.UniqueID);
            _cbMessage = "Correct event raised callback.";
        }
        catch (Exception ex)
        {
            _cbMessage = "Incorrect event raised callback.";
        }
    }

    // Define method that returns callback result.
    public string GetCallbackResult()
    {
        return _cbMessage;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ClientScriptManager cs = Page.ClientScript;
            String cbReference = cs.GetCallbackEventReference("'" +
                Page.UniqueID + "'", "arg", "ReceiveServerData", "",
                "ProcessCallBackError", false);
            String callbackScript = "function CallTheServer(arg, context) {" +
                cbReference + "; }";
            cs.RegisterClientScriptBlock(this.GetType(), "CallTheServer",
                callbackScript, true);
        }
    }
    protected override void Render(HtmlTextWriter writer)
    {
        Page.ClientScript.RegisterForEventValidation(button1.UniqueID);
        base.Render(writer);
    }
    
</script>

<script type="text/javascript">
    var value1 = new Date();
    function ReceiveServerData(arg, context) {
        Message.innerText = arg;
        Label1.innerText = "Callback completed at " + value1;
        value1 = new Date();
    }
    function ProcessCallBackError(arg, context) {
        Message.innerText = 'An error has occurred.';
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>CallBack Event Validation Example</title>
</head>
<body>
    <form id="Form1" runat="server">
    <div>
      Callback result: <span id="Message"></span>
      <br /> <br />
      <input type="button"
             id="button1" 
             runat="server"
             value="ClientCallBack" 
             onclick="CallTheServer(value1, null )"/>
      <br /> <br />
      <asp:Label id="Label1" runat="server"/>
    </div>
    </form>
</body>
</html>
<!-- </Snippet2> -->