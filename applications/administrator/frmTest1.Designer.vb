<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTest1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtPart = New LATIR2GuiManager.TouchTextBox
        Me.cmdPart = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'txtPart
        '
        Me.txtPart.AcceptsReturn = True
        Me.txtPart.BackColor = System.Drawing.SystemColors.Window
        Me.txtPart.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPart.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPart.Location = New System.Drawing.Point(3, 12)
        Me.txtPart.MaxLength = 0
        Me.txtPart.Name = "txtPart"
        Me.txtPart.ReadOnly = True
        Me.txtPart.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPart.Size = New System.Drawing.Size(339, 20)
        Me.txtPart.TabIndex = 3
        '
        'cmdPart
        '
        Me.cmdPart.BackColor = System.Drawing.SystemColors.Control
        Me.cmdPart.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdPart.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdPart.Location = New System.Drawing.Point(348, 7)
        Me.cmdPart.Name = "cmdPart"
        Me.cmdPart.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdPart.Size = New System.Drawing.Size(29, 29)
        Me.cmdPart.TabIndex = 2
        Me.cmdPart.Text = "..."
        Me.cmdPart.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(26, 235)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(219, 39)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "summ percent  fakt"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(26, 280)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(218, 41)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "summ percent fakt shift"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(24, 53)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(218, 43)
        Me.Button3.TabIndex = 6
        Me.Button3.Text = "value"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(28, 172)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(217, 46)
        Me.Button4.TabIndex = 7
        Me.Button4.Text = "summ + percent"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(24, 110)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(217, 42)
        Me.Button5.TabIndex = 8
        Me.Button5.Text = "boolean"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'frmTest1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(504, 415)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtPart)
        Me.Controls.Add(Me.cmdPart)
        Me.Name = "frmTest1"
        Me.Text = "frmTest1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents txtPart As LATIR2GuiManager.TouchTextBox
    Public WithEvents cmdPart As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
End Class
