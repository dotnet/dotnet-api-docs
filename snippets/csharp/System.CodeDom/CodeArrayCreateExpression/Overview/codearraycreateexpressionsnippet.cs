// <Snippet3>
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using System.Windows.Forms;

namespace CodeDOMSamples
{
    /// <summary>
    /// Provides a wrapper for CodeDOM samples.
    /// </summary>
    public class Form1 : Form
    {
        private CodeCompileUnit cu;
        private TextBox textBox1;
        private Button button1;
        private Button button2;
        private GroupBox groupBox1;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private int language = 1;    // 1 = C# 2 = VB
        private System.ComponentModel.Container components = null;

        public Form1()
        {
            InitializeComponent();

            cu = CreateGraph();
        }

        // <Snippet2>
        public CodeCompileUnit CreateGraph()
        {
            // Create a compile unit to contain a CodeDOM graph
            CodeCompileUnit cu = new();

            // Create a namespace named "Samples"
            CodeNamespace cn = new("Samples");

            // Import the System namespace
            cn.Imports.Add(new CodeNamespaceImport("System"));

            // Create a new type named "TestClass"
            CodeTypeDeclaration cd = new("TestClass");

            // Create a new entry point method
            CodeEntryPointMethod cm = new();

            // Write "Hello World!" to the console
            CodeMethodInvokeExpression writeLine = new(
                new CodeTypeReferenceExpression("System.Console"),
                "WriteLine",
                new CodePrimitiveExpression("Hello World!"));
            cm.Statements.Add(writeLine);

            // <Snippet1>
            // Create an initialization expression for a new array of type Int32 with 10 indices
            CodeArrayCreateExpression ca1 = new("System.Int32", 10);

            // Declare an array of type Int32, using the CodeArrayCreateExpression ca1 as the initialization expression
            CodeVariableDeclarationStatement cv1 = new("System.Int32[]", "x", ca1);

            // A C# code generator produces the following source code for the preceeding example code:

            // int[] x = new int[10];
            // </Snippet1>

            // Add the variable declaration and initialization statement to the entry point method
            cm.Statements.Add(cv1);

            // <Snippet5>
            // Declare a variable of type Int32 named "i"
            CodeVariableDeclarationStatement cv2 = new("System.Int32", "i");
            cm.Statements.Add(cv2);

            // Assign the value 10 to the integer variable "i"
            CodeAssignStatement assignment = new(new CodeVariableReferenceExpression("i"), new CodePrimitiveExpression(10));

            // A C# code generator produces the following source code for the preceding example code:

            // i = 10;
            // </Snippet5>

            cm.Statements.Add(assignment);

            // <Snippet4>
            // Create an array indexer expression that references index 5 of array "x"
            CodeArrayIndexerExpression ci1 = new(new CodeVariableReferenceExpression("x"), new CodePrimitiveExpression(5));

            // A C# code generator produces the following source code for the preceding example code:

            // x[5]
            // </Snippet4>

            // Declare a variable of type Int32 and assign the value of the array indexer to it
            CodeVariableDeclarationStatement cv3 = new("System.Int32", "y", ci1);
            cm.Statements.Add(cv3);

            // Add the entry point method to the "TestClass" type
            cd.Members.Add(cm);

            // Add the "TestClass" type to the namespace
            cn.Types.Add(cd);

            // Add the "Samples" namespace to the compile unit
            cu.Namespaces.Add(cn);

            return cu;
        }
        // </Snippet2>

        // <Snippet6>
        private void OutputGraph()
        {
            // Create string writer to output to textbox
            StringWriter sw = new();

            // Create appropriate CodeProvider
            CodeDomProvider cp = language switch
            {
                // VB
                2 => CodeDomProvider.CreateProvider("VisualBasic"),
                // CSharp
                _ => CodeDomProvider.CreateProvider("CSharp"),
            };

            // Generate code from the compile unit and outputs it to the string writer
            cp.GenerateCodeFromCompileUnit(cu, sw, new CodeGeneratorOptions());

            // Output the contents of the string writer to the textbox
            textBox1.Text = sw.ToString();
        }
        // </Snippet6>

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                components?.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            groupBox1 = new GroupBox();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            groupBox1.SuspendLayout();
            SuspendLayout();
            //
            // textBox1
            //
            textBox1.Location = new System.Drawing.Point(16, 112);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Both;
            textBox1.Size = new System.Drawing.Size(664, 248);
            textBox1.TabIndex = 0;
            textBox1.Text = "";
            textBox1.WordWrap = false;
            //
            // button1
            //
            button1.BackColor = System.Drawing.Color.Aquamarine;
            button1.Location = new System.Drawing.Point(16, 16);
            button1.Name = "button1";
            button1.TabIndex = 1;
            button1.Text = "Generate";
            button1.Click += new System.EventHandler(button1_Click);
            //
            // button2
            //
            button2.BackColor = System.Drawing.Color.MediumTurquoise;
            button2.Location = new System.Drawing.Point(112, 16);
            button2.Name = "button2";
            button2.TabIndex = 2;
            button2.Text = "Clear Code";
            button2.Click += new System.EventHandler(button2_Click);
            //
            // groupBox1
            //
            groupBox1.Controls.AddRange([radioButton2, radioButton1]);
            groupBox1.Location = new System.Drawing.Point(16, 48);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(384, 56);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Language selection";
            //
            // radioButton1
            //
            radioButton1.Checked = true;
            radioButton1.Location = new System.Drawing.Point(16, 24);
            radioButton1.Name = "radioButton1";
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "CSharp";
            radioButton1.Click += new System.EventHandler(radioButton1_CheckedChanged);
            //
            // radioButton2
            //
            radioButton2.Location = new System.Drawing.Point(144, 24);
            radioButton2.Name = "radioButton2";
            radioButton2.TabIndex = 1;
            radioButton2.Text = "Visual Basic";
            radioButton2.Click += new System.EventHandler(radioButton2_CheckedChanged);
            //
            // Form1
            //
            AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            ClientSize = new System.Drawing.Size(714, 367);
            Controls.AddRange([groupBox1, button2, button1, textBox1]);
            Name = "Form1";
            Text = "CodeDOM Samples Framework";
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }
        #endregion

        [STAThread]
        static void Main()
        {
            Application.Run(new Form1());
        }

        private void ClearCode()
        {
            textBox1.Text = "";
        }

        // Show code button
        private void button2_Click(object sender, EventArgs e)
        {
            ClearCode();
        }

        // Generate and show code button
        private void button1_Click(object sender, EventArgs e)
        {
            OutputGraph();
        }

        // Csharp language selection button
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            radioButton2.Checked = false;

            language = 1;
        }

        // Visual Basic language selection button
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = true;

            language = 2;
        }
    }
}
// </Snippet3>
