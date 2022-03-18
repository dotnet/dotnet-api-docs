<!--<snippet1>-->
<%@ Page Language="VB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>FileUpload.FileContent Property Example</title>
<script runat="server">
        
        Sub UploadButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            ' Specify the path on the server to
            ' save the uploaded file to.
            Dim savePath As String = "c:\temp\uploads\"
            
            ' Before attempting to perform operations
            ' on the file, verify that the FileUpload 
            ' control contains a file.
            If (FileUpload1.HasFile) Then
            
                ' Append the name of the file to upload to the path.
                savePath += FileUpload1.FileName
            
                ' Call the SaveAs method to save the 
                ' uploaded file to the specified path.
                ' This example does not perform all
                ' the necessary error checking.               
                ' If a file with the same name
                ' already exists in the specified path,  
                ' the uploaded file overwrites it.
                FileUpload1.SaveAs(savePath)
                
                ' Notify the user that the file was uploaded successfully.
                UploadStatusLabel.Text = "Your file was uploaded successfully."
                
                ' Call a helper routine to display the contents
                ' of the file to upload.
                DisplayFileContents(FileUpload1.PostedFile)
            Else
                ' Notify the user that a file was not uploaded.
                UploadStatusLabel.Text = "You did not specify a file to upload."
            End If

        End Sub

        Sub DisplayFileContents(ByVal file As HttpPostedFile)
            
            Dim fileLen As Integer
            Dim displayString As String = ""
            
            ' Get the length of the file.
            fileLen = FileUpload1.PostedFile.ContentLength
            
            ' Display the length of the file in a label.
            LengthLabel.Text = "The length of the file is " _
                               & fileLen.ToString() & " bytes."
            
            ' Create a byte array to hold the contents of the file.
            Dim Input(fileLen - 1) As Byte
            Input = FileUpload1.FileBytes
            
            ' Copy the byte array to a string.
            For loop1 As Integer = 0 To fileLen - 1
                displayString = displayString & Input(loop1).ToString()
            Next loop1
            
            ' Display the contents of the file in a 
            ' textbox on the page.
            ContentsLabel.Text = "The contents of the file as bytes:"
            
            Dim ContentsTextBox As New TextBox
            ContentsTextBox.TextMode = TextBoxMode.MultiLine
            ContentsTextBox.Height = Unit.Pixel(300)
            ContentsTextBox.Width = Unit.Pixel(400)
            ContentsTextBox.Text = displayString
            
            ' Add the textbox to the Controls collection
            ' of the Placeholder control.
            PlaceHolder1.Controls.Add(ContentsTextBox)

        End Sub

    </script>

</head>
<body>

    <h3>FileUpload.FileContent Property Example</h3>

    <form id="Form1" runat="server">
   
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
         
    </form>

</body>
</html>
<!--</snippet1>-->
