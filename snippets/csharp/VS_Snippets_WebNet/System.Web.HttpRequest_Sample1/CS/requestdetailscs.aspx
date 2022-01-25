<!-- <Snippet1> -->
<%@ Page Language="C#" %>
<%@ import Namespace="System.Threading" %>
<%@ import Namespace="System.IO" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    /* NOTE: To use this sample, create a c:\temp\CS folder,
    *  add the ASP.NET account (in IIS 5.x <machinename>\ASPNET,
    *  in IIS 6.x NETWORK SERVICE), and give it write permissions
    *  to the folder.*/

    private const string INFO_DIR = @"c:\temp\CS\RequestDetails";
    public static int requestCount;

    private void Page_Load(object sender, System.EventArgs e)
    {

        // Create a variable to use when iterating
        // through the UserLanguages property.
        int langCount;

        int requestNumber = Interlocked.Increment(ref requestCount);

        // Create the file to contain information about the request.
        string strFilePath = INFO_DIR + requestNumber.ToString() + @".txt";


        StreamWriter sw = File.CreateText(strFilePath);

        try
        {
// <snippet2>
            // Write request information to the file with HTML encoding.
            sw.WriteLine(Server.HtmlEncode(DateTime.Now.ToString()));
            sw.WriteLine(Server.HtmlEncode(Request.CurrentExecutionFilePath));
            sw.WriteLine(Server.HtmlEncode(Request.ApplicationPath));
            sw.WriteLine(Server.HtmlEncode(Request.FilePath));
            sw.WriteLine(Server.HtmlEncode(Request.Path));
// </snippet2>

// <snippet3>
            // Iterate through the Form collection and write
            // the values to the file with HTML encoding.
            // String[] formArray = Request.Form.AllKeys;
            foreach (string s in Request.Form)
            {
                sw.WriteLine("Form: " + Server.HtmlEncode(s));
            }
// </snippet3>

// <snippet4>
            // Write the PathInfo property value
            // or a string if it is empty.
            if (Request.PathInfo == String.Empty)
            {
                sw.WriteLine("The PathInfo property contains no information.");
            }
            else
            {
                sw.WriteLine(Server.HtmlEncode(Request.PathInfo));
            }
// </snippet4>

// <snippet5>
            // Write request information to the file with HTML encoding.
            sw.WriteLine(Server.HtmlEncode(Request.PhysicalApplicationPath));
            sw.WriteLine(Server.HtmlEncode(Request.PhysicalPath));
            sw.WriteLine(Server.HtmlEncode(Request.RawUrl));
// </snippet5>

// <snippet6>
            // Write a message to the file dependent upon
            // the value of the TotalBytes property.
            if (Request.TotalBytes > 1000)
            {
                sw.WriteLine("The request is 1KB or greater");
            }
            else
            {
                sw.WriteLine("The request is less than 1KB");
            }
// </snippet6>

// <snippet7>
            // Write request information to the file with HTML encoding.
            sw.WriteLine(Server.HtmlEncode(Request.RequestType));
            sw.WriteLine(Server.HtmlEncode(Request.UserHostAddress));
            sw.WriteLine(Server.HtmlEncode(Request.UserHostName));
            sw.WriteLine(Server.HtmlEncode(Request.HttpMethod));
// </snippet7>

// <snippet8>
            // Iterate through the UserLanguages collection and
            // write its HTML encoded values to the file.
            for (langCount=0; langCount < Request.UserLanguages.Length; langCount++)
            {
                sw.WriteLine(@"User Language " + langCount +": " + Server.HtmlEncode(Request.UserLanguages[langCount]));
            }
// </snippet8>
       }

       finally
       {
            // Close the stream to the file.
            sw.Close();
       }

        lblInfoSent.Text = "Information about this request has been sent to a file.";
    }


    private void btnSendInfo_Click(object sender, System.EventArgs e)
    {
        lblInfoSent.Text = "Hello, " + Server.HtmlEncode(txtBoxName.Text) +
          ". You have created a new  request info file.";
    }

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
        </p>
        <p>
            Enter your name here:
            <asp:TextBox id="txtBoxName" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button id="btnSendInfo" onclick="btnSendInfo_Click" runat="server" Text="Click Here"></asp:Button>
        </p>
        <p>
            <asp:Label id="lblInfoSent" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>
<!-- </Snippet1> -->
