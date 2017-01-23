<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFieldCopy
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.tvParts = New System.Windows.Forms.TreeView()
        Me.tvCopyTo = New System.Windows.Forms.TreeView()
        Me.cmdCopy = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lstFrom = New System.Windows.Forms.ListBox()
        Me.lstTo = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'tvParts
        '
        Me.tvParts.Location = New System.Drawing.Point(16, 41)
        Me.tvParts.Name = "tvParts"
        Me.tvParts.Size = New System.Drawing.Size(316, 177)
        Me.tvParts.TabIndex = 0
        '
        'tvCopyTo
        '
        Me.tvCopyTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tvCopyTo.Location = New System.Drawing.Point(446, 41)
        Me.tvCopyTo.Name = "tvCopyTo"
        Me.tvCopyTo.Size = New System.Drawing.Size(321, 177)
        Me.tvCopyTo.TabIndex = 1
        '
        'cmdCopy
        '
        Me.cmdCopy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCopy.Location = New System.Drawing.Point(339, 288)
        Me.cmdCopy.Name = "cmdCopy"
        Me.cmdCopy.Size = New System.Drawing.Size(101, 33)
        Me.cmdCopy.TabIndex = 2
        Me.cmdCopy.Text = "Копировать >>"
        Me.cmdCopy.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Копировать из"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(495, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Копировать в"
        '
        'lstFrom
        '
        Me.lstFrom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstFrom.FormattingEnabled = True
        Me.lstFrom.Location = New System.Drawing.Point(19, 226)
        Me.lstFrom.Name = "lstFrom"
        Me.lstFrom.Size = New System.Drawing.Size(312, 173)
        Me.lstFrom.TabIndex = 8
        '
        'lstTo
        '
        Me.lstTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstTo.FormattingEnabled = True
        Me.lstTo.Location = New System.Drawing.Point(446, 228)
        Me.lstTo.Name = "lstTo"
        Me.lstTo.Size = New System.Drawing.Size(318, 173)
        Me.lstTo.TabIndex = 9
        '
        'frmFieldCopy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 418)
        Me.Controls.Add(Me.lstTo)
        Me.Controls.Add(Me.lstFrom)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdCopy)
        Me.Controls.Add(Me.tvCopyTo)
        Me.Controls.Add(Me.tvParts)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFieldCopy"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Копирование полей"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tvParts As System.Windows.Forms.TreeView
    Friend WithEvents tvCopyTo As System.Windows.Forms.TreeView
    Friend WithEvents cmdCopy As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lstFrom As System.Windows.Forms.ListBox
    Friend WithEvents lstTo As System.Windows.Forms.ListBox
End Class
