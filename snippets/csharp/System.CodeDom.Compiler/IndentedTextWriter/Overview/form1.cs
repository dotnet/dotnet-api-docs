//<Snippet1>
using System;
using System.CodeDom.Compiler;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace IndentedTextWriterExample
{
    public class Form1 : Form
    {
        private readonly TextBox _textBox1;

        //<Snippet2>
        private string CreateMultilevelIndentString()
        {
            //<Snippet3>
            // Creates a TextWriter to use as the base output writer.
            StringWriter baseTextWriter = new();

            // Create an IndentedTextWriter and set the tab string to use
            // as the indentation string for each indentation level.
            IndentedTextWriter indentWriter = new(baseTextWriter, "    ");
            //</Snippet3>

            //<Snippet4>
            // Sets the indentation level.
            indentWriter.Indent = 0;
            //</Snippet4>

            // Output test strings at stepped indentations through a recursive loop method.
            WriteLevel(indentWriter, 0, 5);

            // Return the resulting string from the base StringWriter.
            return baseTextWriter.ToString();
        }

        //<Snippet5>
        private void WriteLevel(IndentedTextWriter indentWriter, int level, int totalLevels)
        {
            // Output a test string with a new-line character at the end.
            indentWriter.WriteLine($"This is a test phrase. Current indentation level: {level}");

            // If not yet at the highest recursion level, call this output method for the next level of indentation.
            if (level < totalLevels)
            {
                // Increase the indentation count for the next level of indented output.
                indentWriter.Indent++;

                // Call the WriteLevel method to write test output for the next level of indentation.
                WriteLevel(indentWriter, level + 1, totalLevels);

                // Restores the indentation count for this level after the recursive branch method has returned.
                indentWriter.Indent--;
            }
            else
            {
                //<Snippet6>
                // Outputs a string using the WriteLineNoTabs method.
                indentWriter.WriteLineNoTabs("This is a test phrase written with the IndentTextWriter.WriteLineNoTabs method.");
                //</Snippet6>
            }

            // Outputs a test string with a new-line character at the end.
            indentWriter.WriteLine($"This is a test phrase. Current indentation level: {level}");
        }
        //</Snippet5>
        //</Snippet2>

        private void Button1_Click(object sender, EventArgs e) =>
            _textBox1.Text = CreateMultilevelIndentString();

        public Form1()
        {
            Button button1 = new();
            _textBox1 = new();
            SuspendLayout();
            _textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _textBox1.Location = new Point(8, 40);
            _textBox1.Multiline = true;
            _textBox1.Name = "textBox1";
            _textBox1.Size = new Size(391, 242);
            _textBox1.TabIndex = 0;
            _textBox1.Text = "";
            button1.Location = new Point(11, 8);
            button1.Name = "button1";
            button1.Size = new Size(229, 23);
            button1.TabIndex = 1;
            button1.Text = "Generate string using IndentedTextWriter";
            button1.Click += Button1_Click;
            AutoScaleBaseSize = new Size(5, 13);
            ClientSize = new Size(407, 287);
            Controls.Add(button1);
            Controls.Add(_textBox1);
            Name = "Form1";
            Text = "IndentedTextWriter example";
            ResumeLayout(false);
        }

        [STAThread]
        static void Main()
        {
            Application.Run(new Form1());
        }
    }
}
//</Snippet1>
