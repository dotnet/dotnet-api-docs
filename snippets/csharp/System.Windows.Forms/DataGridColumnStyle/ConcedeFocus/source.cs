﻿using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace MyNameSpace {
    class MyDataGridColumnStyle: DataGridTextBoxColumn {
        // <Snippet1>
        protected override void ConcedeFocus() {
            // Hide the TextBox when conceding focus.
            base.TextBox.Visible = false;
        }
        // </Snippet1>
        protected override void Edit(System.Windows.Forms.CurrencyManager source, int rowNum, System.Drawing.Rectangle bounds, bool readOnly1, string displayText, bool cellIsVisiblen) {
        }

        protected override bool Commit(System.Windows.Forms.CurrencyManager dataSource, int rowNum) {
            return true;
        }

        protected override System.Drawing.Size GetPreferredSize(System.Drawing.Graphics g, object value) {
            return new Size(new Point(1, 2));
        }

        protected override int GetPreferredHeight(System.Drawing.Graphics g, object value) {
            return 1;
        }

        protected override int GetMinimumHeight() {
            return 1;
        }

        protected override void Abort(int rowNum) {
        }

        protected override void Paint(System.Drawing.Graphics g, System.Drawing.Rectangle bounds, System.Windows.Forms.CurrencyManager source, int rowNum, bool b) {
        }
        
        protected override void Paint(System.Drawing.Graphics g, System.Drawing.Rectangle bounds, System.Windows.Forms.CurrencyManager source, int rowNum) {
        }
    }
}
