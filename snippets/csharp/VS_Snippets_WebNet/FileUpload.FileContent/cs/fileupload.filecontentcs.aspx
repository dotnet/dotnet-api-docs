<!--<Snippet1>-->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    protected void UploadButton_Click(object sender, EventArgs e)
    {
        // Specify the path on the server to
        // save the uploaded file to.
        String savePath = @"c:\temp\uploads\";

        // Before attempting to perform operations
        // on the file, verify that the FileUpload 
        // control contains a file.
        if (FileUpload1.HasFile)
        {
            // Append the name of the file to upload to the path.
            savePath += FileUpload1.FileName;
            
            // Call the SaveAs method to save the 
            // uploaded file to the specified path.
            // This example does not perform all
            // the necessary error checking.               
            // If a file with the same name
            // already exists in the specified path,  
            // the uploaded file overwrites it.
            FileUpload1.SaveAs(savePath);
                
            // Notify the user that the file was uploaded successfully.
            UploadStatusLabel.Text = "Your file was uploaded successfully.";
                
            // Call a helper routine to display the contents
            // of the file to upload.
            DisplayFileContents(FileUpload1.PostedFile);
        }
        else
        {
            // Notify the user that a file was not uploaded.
            UploadStatusLabel.Text = "You did not specify a file to upload.";
        }
    }
    void DisplayFileContents(HttpPostedFile file)
    {
        System.IO.Stream myStream;
        Int32 fileLen;
        StringBuilder displayString = new StringBuilder();
     
        // Get the length of the file.
        fileLen = FileUpload1.PostedFile.ContentLength;
            
        // Display the length of the file in a label.
        LengthLabel.Text = "The length of the file is " + 
                           fileLen.ToString() + " bytes.";
   
        // Create a byte array to hold the contents of the file.
        Byte[] Input = new Byte[fileLen];
            
        // Initialize the stream to read the uploaded file.
        myStream = FileUpload1.FileContent;
            
        // Read the file into the byte array.
        myStream.Read(Input, 0, fileLen);
        
        // Copy the byte array to a string.
        for (int loop1 = 0; loop1 < fileLen; loop1++)
        {
            displayString.Append(Input[loop1].ToString());
        }

        // Display the contents of the file in a 
        // textbox on the page.
        ContentsLabel.Text = "The contents of the file as bytes:";

        TextBox ContentsTextBox = new TextBox();
        ContentsTextBox.TextMode = TextBoxMode.MultiLine;
        ContentsTextBox.Height = Unit.Pixel(300);
        ContentsTextBox.Width = Unit.Pixel(400);
        ContentsTextBox.Text = displayString.ToString();

        // Add the textbox to the Controls collection
        // of the Placeholder control.
        PlaceHolder1.Controls.Add(ContentsTextBox);

    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>FileUpload.FileContent Property Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h4>Select a file to upload:</h4>
       
        <asp:FileUpload id="FileUpload1"
           runat="server">
        </asp:FileUpload>
       
        <br /><br />
       
        <asp:Button id="UploadButton" 
            Text="Upload file"
            OnClick="UploadButton_Click"
            runat="server">
        </asp:Button>
        
        <br /><br />
        
        <asp:Label id="UploadStatusLabel"
           runat="server">
        </asp:Label>  
            
        <hr />
        
        <asp:Label id="LengthLabel"
           runat="server">
        </asp:Label>  
        
        <br /><br />
       
        <asp:Label id="ContentsLabel"
           runat="server">
        </asp:Label>  
        
        <br /><br />
       
        <asp:PlaceHolder id="PlaceHolder1"
            runat="server">
        </asp:PlaceHolder>        
    </div>
    </form>
</body>
</html>
<!--</Snippet1>-->

