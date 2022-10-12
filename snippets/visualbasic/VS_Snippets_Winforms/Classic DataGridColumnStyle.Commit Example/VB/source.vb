﻿Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms


Namespace MyNameSpace
    
    Class MyDataGridColumnStyle
        Inherits DataGridColumnStyle
        
        private currentValue As Integer = 0
        private isEditing As Boolean = False

        ' <Snippet1>
        Protected Overrides Function Commit(dataSource As System.Windows.Forms.CurrencyManager, rowNum As Integer) As Boolean
            SetColumnValueAtRow(dataSource, rowNum, currentValue)
            isEditing = False
            Invalidate
            Commit = True
        End Function
        ' </Snippet1>

        Overloads Protected Overrides Sub Edit(source As System.Windows.Forms.CurrencyManager, rowNum As Integer, bounds As System.Drawing.Rectangle, readOnly1 As Boolean, displayText As String, cellIsVisiblen As Boolean)
        End Sub
         
        Protected Overrides Function GetPreferredSize(g As System.Drawing.Graphics, value As Object) As System.Drawing.Size
            Return New Size(New Point(1, 2))
        End Function 'GetPreferredSize
        
        
        Protected Overrides Function GetPreferredHeight(g As System.Drawing.Graphics, value As Object) As Integer
            Return 1
        End Function 'GetPreferredHeight
        
        
        Protected Overrides Function GetMinimumHeight() As Integer
            Return 1
        End Function 'GetMinimumHeight
        
        
        Protected Overrides Sub Abort(rowNum As Integer)
        End Sub
         
        
        Overloads Protected Overrides Sub Paint(g As System.Drawing.Graphics, bounds As System.Drawing.Rectangle, source As System.Windows.Forms.CurrencyManager, rowNum As Integer, b As Boolean)
        End Sub
        
        
        Overloads Protected Overrides Sub Paint(g As System.Drawing.Graphics, bounds As System.Drawing.Rectangle, source As System.Windows.Forms.CurrencyManager, rowNum As Integer)
        End Sub
    End Class
End Namespace 'MyNameSpace
