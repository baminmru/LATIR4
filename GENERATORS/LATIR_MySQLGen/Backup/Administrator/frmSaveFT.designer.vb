<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmSaveFT
#Region "Windows Form Designer generated code "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'This call is required by the Windows Form Designer.
		InitializeComponent()
	End Sub
	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
	Public WithEvents cmdPath As System.Windows.Forms.Button
	Public WithEvents txtPath As System.Windows.Forms.TextBox
	Public WithEvents OKButton As System.Windows.Forms.Button
	Public WithEvents Label8 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdPath = New System.Windows.Forms.Button
        Me.txtPath = New System.Windows.Forms.TextBox
        Me.OKButton = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.cdlgFolder = New System.Windows.Forms.FolderBrowserDialog
        Me.SuspendLayout()
        '
        'cmdPath
        '
        Me.cmdPath.BackColor = System.Drawing.SystemColors.Control
        Me.cmdPath.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdPath.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdPath.Location = New System.Drawing.Point(427, 8)
        Me.cmdPath.Name = "cmdPath"
        Me.cmdPath.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdPath.Size = New System.Drawing.Size(21, 21)
        Me.cmdPath.TabIndex = 2
        Me.cmdPath.Text = "..."
        Me.cmdPath.UseVisualStyleBackColor = False
        '
        'txtPath
        '
        Me.txtPath.AcceptsReturn = True
        Me.txtPath.BackColor = System.Drawing.SystemColors.Window
        Me.txtPath.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPath.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPath.Location = New System.Drawing.Point(128, 8)
        Me.txtPath.MaxLength = 0
        Me.txtPath.Name = "txtPath"
        Me.txtPath.ReadOnly = True
        Me.txtPath.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPath.Size = New System.Drawing.Size(298, 20)
        Me.txtPath.TabIndex = 1
        '
        'OKButton
        '
        Me.OKButton.BackColor = System.Drawing.SystemColors.Control
        Me.OKButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.OKButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.OKButton.Location = New System.Drawing.Point(368, 34)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.OKButton.Size = New System.Drawing.Size(79, 21)
        Me.OKButton.TabIndex = 3
        Me.OKButton.Text = "Сохранить"
        Me.OKButton.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(8, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(119, 17)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Куда сохранить:"
        '
        'frmSaveFT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(452, 59)
        Me.Controls.Add(Me.cmdPath)
        Me.Controls.Add(Me.txtPath)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.Label8)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(3, 19)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSaveFT"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Сохранить типы полей"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cdlgFolder As System.Windows.Forms.FolderBrowserDialog
#End Region 
End Class