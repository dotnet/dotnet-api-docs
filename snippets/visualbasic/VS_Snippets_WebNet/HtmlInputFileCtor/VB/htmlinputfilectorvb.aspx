<!-- <Snippet1> -->
<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
 
  Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)

    ' Get HtmlInputFile control from the Controls collection
    ' of the PlaceHolder control.
    Dim file As HtmlInputFile = _
       CType(Place.FindControl("File1"), HtmlInputFile)
 
    ' Make sure a file was submitted.
    If Text1.Value = "" Then
         
      Span1.InnerHtml = "Error: You must enter a file name."
      Return
          
    End If
 
    ' Save the file.
    If file.PostedFile.ContentLength > 0 Then

      Try
        
        file.PostedFile.SaveAs(("c:\temp\" & Text1.Value))
        Span1.InnerHtml = "File uploaded successfully to " & _
           "<b>c:\temp\" & Text1.Value & "</b> on the Web server."
        
      Catch exc As Exception
        
        Span1.InnerHtml = "Error saving file <b>c:\temp\" & _
           Text1.Value & "</b><br />" & exc.ToString() & "."
        
      End Try

    End If

  End Sub


  Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

    ' Create a new HtmlInputFile control.
    Dim file As HtmlInputFile = New HtmlInputFile()
    file.ID = "File1"

    ' Add the control to the Controls collection of the
    ' PlaceHolder control.
    Place.Controls.Clear()
    Place.Controls.Add(file)

  End Sub
 
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>HtmlInputFile Constructor Example</title>
  </head>

<body>
 
   <h3>HtmlInputFile Constructor Example</h3>
 
   <form id="form1" enctype="multipart/form-data" 
         runat="server">
 
      Specify the file to upload:
      <asp:PlaceHolder id="Place"
                       runat="server"/> 
 
      <p>
      Save as file name (no path): 
      <input id="Text1" 
             type="text" 
             runat="server" />
 
      </p>
      <p>
      <span id="Span1" 
            style="font: 8pt verdana;" 
            runat="server" />

      </p>
      <p>
      <input type="button" 
             id="Button1" 
             value="Upload" 
             onserverclick="Button1_Click" 
             runat="server" />
 
      </p>
   </form>
 
</body>
</html>
<!-- </Snippet1> -->