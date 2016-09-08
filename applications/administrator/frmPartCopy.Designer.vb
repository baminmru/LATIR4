<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPartCopy
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdCopy = New System.Windows.Forms.Button()
        Me.tvCopyTo = New System.Windows.Forms.TreeView()
        Me.tvParts = New System.Windows.Forms.TreeView()
        Me.chkWithFields = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(491, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Копировать в"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Копировать из"
        '
        'cmdCopy
        '
        Me.cmdCopy.Location = New System.Drawing.Point(335, 111)
        Me.cmdCopy.Name = "cmdCopy"
        Me.cmdCopy.Size = New System.Drawing.Size(101, 33)
        Me.cmdCopy.TabIndex = 9
        Me.cmdCopy.Text = "Копировать >>"
        Me.cmdCopy.UseVisualStyleBackColor = True
        '
        'tvCopyTo
        '
        Me.tvCopyTo.Location = New System.Drawing.Point(442, 43)
        Me.tvCopyTo.Name = "tvCopyTo"
        Me.tvCopyTo.Size = New System.Drawing.Size(321, 305)
        Me.tvCopyTo.TabIndex = 8
        '
        'tvParts
        '
        Me.tvParts.Location = New System.Drawing.Point(12, 43)
        Me.tvParts.Name = "tvParts"
        Me.tvParts.Size = New System.Drawing.Size(316, 305)
        Me.tvParts.TabIndex = 7
        '
        'chkWithFields
        '
        Me.chkWithFields.AutoSize = True
        Me.chkWithFields.Location = New System.Drawing.Point(346, 164)
        Me.chkWithFields.Name = "chkWithFields"
        Me.chkWithFields.Size = New System.Drawing.Size(74, 17)
        Me.chkWithFields.TabIndex = 12
        Me.chkWithFields.Text = "С полями"
        Me.chkWithFields.UseVisualStyleBackColor = True
        '
        'frmPartCopy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(787, 394)
        Me.Controls.Add(Me.chkWithFields)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdCopy)
        Me.Controls.Add(Me.tvCopyTo)
        Me.Controls.Add(Me.tvParts)
        Me.Name = "frmPartCopy"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdCopy As System.Windows.Forms.Button
    Friend WithEvents tvCopyTo As System.Windows.Forms.TreeView
    Friend WithEvents tvParts As System.Windows.Forms.TreeView
    Friend WithEvents chkWithFields As System.Windows.Forms.CheckBox
End Class
