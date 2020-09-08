<%@ Page Language="VB" Debug="true" EnableSessionState="true" %>
<%@ Import Namespace="System.Collections.Specialized" %>
<%@ Register TagPrefix="MyUserControl" TagName="Logon" Src="Logonform.vb.ascx" %>
<%@ Reference Control="Logonform.vb.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
     <script language="VB" runat="server">
' System.Web.UI.UserControl.DesignerInitialize;System.Web.UI.UserControl.InitializeAsUserControl;
' System.Web.UI.UserControl.MapPath;System.Web.UI.UserControl.Trace;System.Web.UI.UserControl.Server;
' System.Web.UI.UserControl.Request;System.Web.UI.UserControl.Response;System.Web.UI.UserControl.IsPostBack
' System.Web.UI.UserControl.Session

' The following example demonstrates the methods 'DesignerInitialize','InitializeAsUserControl',and 'MapPath'
'   and properties 'IsPostBack','Request','Response','Server','Session' and 'Trace' of 'UserControl' class.
   
'   LogonControl is a 'UserControl' with textboxes for username and password, and is defined in the codebehind 
'   file LogOnControl.cs. The corresponding .ascx file for the codebehind file is Logonform.ascx which 
'   specifies using the '@control' directive, the name of the class the user control inherits and the path to
'   the source file.
   
'   This UserControl is included in the current WebForms page by using the '@Register' directive. When the 
'   submit button is clicked on the page all logon information is stored in the 'Session' instance of the 
'   user control. After the  postback the saved information is retrieved and displayed by clicking the 
'   Display Session Variables button.

        
    Sub Page_Init(Sender As Object, e As EventArgs)
' <Snippet1>        

           ' Initialize the UserControl object that has been created declaratively.
           myControl.InitializeAsUserControl(Me)

' </Snippet1>
' <Snippet2>
           ' Performs any initialization steps on the user control that are required by RAD designers.
           myControl.DesignerInitialize()
' </Snippet2>

' <Snippet3>

           myControl.Response.Write("<br /><b>The server code is running on machine</b> : " + myControl.Server.MachineName)
           Dim actualServerPath As String = myControl.MapPath(myControl.Request.Path)

' </Snippet3>
          Response.Write("<br /><b>The server code is stored at the following physical location</b> : " + actualServerPath)

    End Sub



' <Snippet7>
    Sub Page_Load(Sender As Object, e As EventArgs)    
        If (Not myControl.IsPostBack) Then
          Display.Enabled = False
       End If  
    End Sub    
' </Snippet7>

' <Snippet6>
        ' Saves state information which is used by display handler after the postback has occurred.

        Sub SubmitBtn_Click(Sender As Object, e As EventArgs) 

            ' Clear all values from session state of 'Page'.
            Session.Clear()

            ' Populate Session State of UserControl with the values entered by user.
            myControl.Session.Add("username",myControl.user.Text)
            myControl.Session.Add("password",myControl.password.Text)

            ' Add UserControl state to the SessionState object of Page.
            Session(myControl.user.Text)= myControl
            Display.Enabled = true
        End Sub

        Sub Display_Click(Sender As Object,e As EventArgs)

            Dim position As Integer = Session.Count - 1

            ' Extract stored UserControl from the session state of page.
            Dim tempControl As LogOnControl = CType(Session(Session.Keys(position)),LogOnControl)

            ' Use SessionState of UserControl to display previously typed information.
            txtSession.Text = "<br /><br />User:" + tempControl.Session("username") + "<br />Password : " + tempControl.Session("password")
            Display.Enabled = false
        End Sub
' </Snippet6>

        </script>
     <form id="form1" method="POST" action="UserControl1.aspx" runat="server">
        <table>
          <tr>
             <MyUserControl:Logon id="myControl" runat="server" />
          </tr>
          <tr>
             <td>
                <ASP:Button Text="Submit" id="submit" OnClick="SubmitBtn_Click" runat="server" />
             </td>
             <td>
                <asp:button Text="Display Session Variables" id="display" OnClick="Display_Click" runat="server" />
             </td>
          </tr>
          <tr>
            <td>
              <br />
              <br />
              <br />
              <b>Session Contents</b>
            </td>
          </tr>
          <tr>
             <asp:Label id="txtSession" Text="" Font-Bold="true" runat="server" />
          </tr>
        </table>
     </form>
  </body>
</html>
