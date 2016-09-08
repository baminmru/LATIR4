<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSequenceTool
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
        Me.Button2 = New System.Windows.Forms.Button()
        Me.tvParts = New System.Windows.Forms.TreeView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtOut = New LATIR2GuiManager.TouchTextBox()
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(404, 34)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(193, 31)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Организовать по группам"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'tvParts
        '
        Me.tvParts.Location = New System.Drawing.Point(3, 34)
        Me.tvParts.Name = "tvParts"
        Me.tvParts.Size = New System.Drawing.Size(370, 319)
        Me.tvParts.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(3, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(229, 17)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Типы документов \ разделы"
        '
        'txtOut
        '
        Me.txtOut.Location = New System.Drawing.Point(408, 84)
        Me.txtOut.Multiline = True
        Me.txtOut.Name = "txtOut"
        Me.txtOut.ReadOnly = True
        Me.txtOut.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtOut.Size = New System.Drawing.Size(433, 269)
        Me.txtOut.TabIndex = 12
        '
        'frmSequenceTool
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(892, 365)
        Me.Controls.Add(Me.txtOut)
        Me.Controls.Add(Me.tvParts)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button2)
        Me.Name = "frmSequenceTool"
        Me.Text = "frmSequenceTool"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents tvParts As System.Windows.Forms.TreeView
    Public WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtOut As LATIR2GuiManager.TouchTextBox
End Class
