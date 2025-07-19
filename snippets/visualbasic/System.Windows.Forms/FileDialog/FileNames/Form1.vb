Imports System.Drawing
Imports System.Security
Imports System.Windows.Forms

Public Class Form1
    Public Shared Sub Main()
    End Sub

    '<SNIPPET1>
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitializeOpenFileDialog()
    End Sub

    Private Sub SelectFileButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectFileButton.Click
        Dim dr As DialogResult = OpenFileDialog1.ShowDialog()
        If (dr = System.Windows.Forms.DialogResult.OK) Then
            ' Read the files
            Dim file As String
            For Each file In OpenFileDialog1.FileNames
                ' Create a PictureBox for each file, and add that file to the FlowLayoutPanel.
                Try
                    Dim pb As New PictureBox()
                    Dim loadedImage As Image = Image.FromFile(file)
                    pb.Height = loadedImage.Height
                    pb.Width = loadedImage.Width
                    pb.Image = loadedImage
                    FlowLayoutPanel1.Controls.Add(pb)
                Catch SecEx As SecurityException
                    ' The user lacks appropriate permissions to read files, discover paths, etc.
                    MessageBox.Show("Security error. Please contact your administrator for details.\n\n" &
                        "Error message: " & SecEx.Message & "\n\n" &
                        "Details (send to Support):\n\n" & SecEx.StackTrace)
                Catch ex As Exception
                    ' Could not load the image - probably permissions-related.
                    MessageBox.Show(("Cannot display the image: " & file.Substring(file.LastIndexOf("\"c)) &
                    ". You may not have permission to read the file, or " + "it may be corrupt." _
                    & ControlChars.Lf & ControlChars.Lf & "Reported error: " & ex.Message))
                End Try
            Next file
        End If
    End Sub

    Public Sub InitializeOpenFileDialog()
        ' Set the file dialog to filter for graphics files.
        OpenFileDialog1.Filter =
                "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|" +
                "All files (*.*)|*.*"

        ' Allow the user to select multiple images.
        OpenFileDialog1.Multiselect = True
        OpenFileDialog1.Title = "My Image Browser"
    End Sub
    '</SNIPPET1>
End Class
