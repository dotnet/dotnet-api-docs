'<Snippet1>
Imports System.Drawing
Imports System.Windows.Forms

Namespace TrackBar

    ' <summary>
    ' Summary description for Form1.
    ' </summary>
    Public Class Form1
        Inherits Form

        Private _panel1 As Panel
        Private WithEvents trackBar1 As System.Windows.Forms.TrackBar
        Private WithEvents trackBar2 As System.Windows.Forms.TrackBar
        Private WithEvents trackBar3 As System.Windows.Forms.TrackBar
        Private _label1 As Label
        Private _label2 As Label
        Private _label3 As Label
        ' <summary>
        ' Required designer variable.
        ' </summary>
        Private Components As System.ComponentModel.Container
        Public Sub New()
            MyBase.New()

            '
            ' Required for Windows Form Designer support
            '
            InitializeComponent()

            '
            ' TODO: Add any constructor code after InitializeComponent call
            '
            '<Snippet2>
            trackBar2.Orientation = Orientation.Vertical
            trackBar3.Orientation = Orientation.Vertical
            trackBar1.Maximum = 255
            trackBar2.Maximum = 255
            trackBar3.Maximum = 255
            trackBar1.Width = 400
            trackBar2.Height = 400
            trackBar3.Height = 400
            trackBar1.LargeChange = 16
            trackBar2.LargeChange = 16
            trackBar3.LargeChange = 16
            '</Snippet2>
        End Sub

        ' <summary>
        ' Clean up any resources being used.
        ' </summary>

        '#region Windows Form Designer generated code
        ' <summary>
        ' Required method for Designer support - do not modify
        ' the contents of Me method with the code editor.
        ' </summary>
        Private Sub InitializeComponent()
            _label1 = New Label()
            _label2 = New Label()
            _label3 = New Label()
            trackBar1 = New System.Windows.Forms.TrackBar()
            trackBar2 = New System.Windows.Forms.TrackBar()
            trackBar3 = New System.Windows.Forms.TrackBar()
            _panel1 = New Panel()
            '<Snippet4>
            CType(trackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(trackBar2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(trackBar3, System.ComponentModel.ISupportInitialize).BeginInit()
            SuspendLayout()
            '
            'trackBar1
            '
            trackBar1.Location = New Point(160, 400)
            trackBar1.Name = "trackBar1"
            trackBar1.TabIndex = 1
            '
            'trackBar2
            '
            trackBar2.Location = New Point(608, 40)
            trackBar2.Name = "trackBar2"
            trackBar2.TabIndex = 2
            '
            'trackBar3
            '
            trackBar3.Location = New Point(56, 40)
            trackBar3.Name = "trackBar3"
            trackBar3.TabIndex = 3
            CType(trackBar1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(trackBar2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(trackBar3, System.ComponentModel.ISupportInitialize).EndInit()
            '</Snippet4>
            '
            'label1
            '
            _label1.Location = New Point(288, 448)
            _label1.Name = "label1"
            _label1.TabIndex = 4
            '
            'label2
            '
            _label2.Location = New Point(600, 16)
            _label2.Name = "label2"
            _label2.Size = New Size(120, 16)
            _label2.TabIndex = 5
            '
            'label3
            '
            _label3.Location = New Point(8, 16)
            _label3.Name = "label3"
            _label3.Size = New Size(120, 16)
            _label3.TabIndex = 6
            '
            'panel1
            '
            _panel1.BorderStyle = BorderStyle.Fixed3D
            _panel1.Location = New Point(128, 32)
            _panel1.Name = "panel1"
            _panel1.Size = New Size(464, 352)
            _panel1.TabIndex = 0
            '
            'Form1
            '
            ClientSize = New Size(728, 477)
            Controls.AddRange(New Control() {_label3, _label2, _label1, trackBar2, trackBar3, trackBar1, _panel1})
            AddHandler Load, AddressOf Form1_Load
            Name = "Form1"
            Text = "Color builder"
            ResumeLayout(False)

        End Sub

        ' <summary>
        ' The main entry point for the application.
        ' </summary>
        ' [STAThread]
        ' static void Main()
        '
        '	Application.Run(new Form1())
        ' }

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
            showColorValueLabels()
        End Sub

        '<Snippet3>
        Private Sub showColorValueLabels()
            _label1.Text = "Red value is : " & trackBar1.Value.ToString()
            _label2.Text = "Green Value is : " & trackBar2.Value.ToString()
            _label3.Text = "Blue Value is : " & trackBar3.Value.ToString()
        End Sub

        Private Sub trackBar_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles trackBar1.Scroll, trackBar2.Scroll, trackBar3.Scroll
            Dim myTB As System.Windows.Forms.TrackBar
            myTB = sender
            _panel1.BackColor = Color.FromArgb(trackBar1.Value, trackBar2.Value, trackBar3.Value)
            myTB.Text = "Value is " & myTB.Value.ToString()
            showColorValueLabels()
        End Sub
        '</Snippet3>

        Public Shared Sub Main()
            Application.Run(New Form1())
        End Sub

    End Class
End Namespace
'</Snippet1>
