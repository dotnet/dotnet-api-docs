<!-- <Snippet1> -->
<%@ Page Language="C#" 
    Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" 
    Namespace="System.Web.UI.MobileControls" 
    Assembly="System.Web.Mobile" %>

<script runat="server">
    // Add two PhoneCall controls to the panel
    public void Page_Load(Object source, EventArgs e)
    {
        if (!IsPostBack)
        {
            PhoneCall pc = new PhoneCall();
            pc.PhoneNumber = "206-555-0187";
            pc.Text = "Office";
            pc.AlternateUrl = "http://www.microsoft.com/";
            pc.AlternateFormat = "{0}: {1}";
            Panel1.Controls.Add(pc);

            pc = new PhoneCall();
            pc.PhoneNumber = "911";
            pc.Text = "Emergency";
            pc.AlternateFormat = "Call {0} At {1}";
            Panel1.Controls.Add(pc);
        }
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <mobile:form id="form1" runat="server">
        <mobile:Panel ID="Panel1" Runat="server">
            <mobile:PhoneCall PhoneNumber="+91335303197" 
                Runat="server">Helmuth (Germany):</mobile:PhoneCall>
        </mobile:Panel>
    </mobile:form>
</body>
</html>
<!-- </Snippet1> -->
