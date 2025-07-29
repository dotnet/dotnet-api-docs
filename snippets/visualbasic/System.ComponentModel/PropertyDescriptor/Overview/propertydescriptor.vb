Imports System.ComponentModel
Imports System.Windows.Forms

Public NotInheritable Class Form1
    Inherits Form

    Public Shared Sub Main()

    End Sub

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If (components IsNot Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button1 As Button

    Private Function ShouldSerializeTextBox1() As Boolean
        Return True
    End Function

    Private Function ShouldSerializeButton1() As Boolean
        Return True
    End Function

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        TextBox1 = New TextBox()
        Button1 = New Button()
        SuspendLayout()
        '
        'TextBox1
        '
        TextBox1.Multiline = True
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New System.Drawing.Size(224, 96)
        TextBox1.TabIndex = 0
        TextBox1.Text = "TextBox1"
        '
        'Button1
        '
        Button1.Location = New System.Drawing.Point(24, 136)
        Button1.Name = "Button1"
        Button1.TabIndex = 1
        Button1.Text = "Button1"
        '
        'Form1
        '
        ClientSize = New System.Drawing.Size(292, 273)
        Controls.AddRange(New Control() {Button1, TextBox1})
        Name = "Form1"
        Text = "Form1"
        ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '<snippet1>
        ' Creates a new collection and assign it the properties for button1.
        Dim properties As PropertyDescriptorCollection = TypeDescriptor.GetProperties(Button1)

        ' Sets an PropertyDescriptor to the specific property.
        Dim myProperty As PropertyDescriptor = properties.Find("Text", False)

        ' Prints the property and the property description.
        TextBox1.Text += myProperty.DisplayName & ControlChars.Cr
        TextBox1.Text += myProperty.Description & ControlChars.Cr
        TextBox1.Text += myProperty.Category & ControlChars.Cr
        '</snippet1>
    End Sub
End Class
