<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class jsCompressor
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
        Me.cmdFolder = New System.Windows.Forms.Button()
        Me.dlgFolder = New System.Windows.Forms.FolderBrowserDialog()
        Me.txtFolder = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdCompress = New System.Windows.Forms.Button()
        Me.lblOUt = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmdFolder
        '
        Me.cmdFolder.Location = New System.Drawing.Point(518, 47)
        Me.cmdFolder.Name = "cmdFolder"
        Me.cmdFolder.Size = New System.Drawing.Size(45, 21)
        Me.cmdFolder.TabIndex = 0
        Me.cmdFolder.Text = "..."
        Me.cmdFolder.UseVisualStyleBackColor = True
        '
        'txtFolder
        '
        Me.txtFolder.Location = New System.Drawing.Point(12, 48)
        Me.txtFolder.Name = "txtFolder"
        Me.txtFolder.ReadOnly = True
        Me.txtFolder.Size = New System.Drawing.Size(489, 20)
        Me.txtFolder.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Папка"
        '
        'cmdCompress
        '
        Me.cmdCompress.Location = New System.Drawing.Point(14, 101)
        Me.cmdCompress.Name = "cmdCompress"
        Me.cmdCompress.Size = New System.Drawing.Size(131, 45)
        Me.cmdCompress.TabIndex = 3
        Me.cmdCompress.Text = "Сжать"
        Me.cmdCompress.UseVisualStyleBackColor = True
        '
        'lblOUt
        '
        Me.lblOUt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOUt.Location = New System.Drawing.Point(14, 167)
        Me.lblOUt.Name = "lblOUt"
        Me.lblOUt.Size = New System.Drawing.Size(549, 29)
        Me.lblOUt.TabIndex = 4
        '
        'jsCompressor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(594, 206)
        Me.Controls.Add(Me.lblOUt)
        Me.Controls.Add(Me.cmdCompress)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtFolder)
        Me.Controls.Add(Me.cmdFolder)
        Me.Name = "jsCompressor"
        Me.Text = "jsCompressor"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdFolder As System.Windows.Forms.Button
    Friend WithEvents dlgFolder As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents txtFolder As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdCompress As System.Windows.Forms.Button
    Friend WithEvents lblOUt As System.Windows.Forms.Label
End Class
