<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmSaveDesc
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
	Public WithEvents pb As System.Windows.Forms.ProgressBar
	Public WithEvents cmdSelAll As System.Windows.Forms.Button
	Public WithEvents cmdUnselAll As System.Windows.Forms.Button
	Public WithEvents cmdPath As System.Windows.Forms.Button
	Public WithEvents txtPath As LATIR2GuiManager.TouchTextBox
	Public WithEvents OKButton As System.Windows.Forms.Button
	Public WithEvents cmbType As System.Windows.Forms.CheckedListBox
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Label8 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.pb = New System.Windows.Forms.ProgressBar
        Me.cmdSelAll = New System.Windows.Forms.Button
        Me.cmdUnselAll = New System.Windows.Forms.Button
        Me.cmdPath = New System.Windows.Forms.Button
        Me.txtPath = New LATIR2GuiManager.TouchTextBox
        Me.OKButton = New System.Windows.Forms.Button
        Me.cmbType = New System.Windows.Forms.CheckedListBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.cdlgFolder = New System.Windows.Forms.FolderBrowserDialog
        Me.SuspendLayout()
        '
        'pb
        '
        Me.pb.Location = New System.Drawing.Point(8, 232)
        Me.pb.Name = "pb"
        Me.pb.Size = New System.Drawing.Size(449, 17)
        Me.pb.TabIndex = 8
        Me.pb.Visible = False
        '
        'cmdSelAll
        '
        Me.cmdSelAll.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSelAll.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSelAll.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSelAll.Location = New System.Drawing.Point(360, 56)
        Me.cmdSelAll.Name = "cmdSelAll"
        Me.cmdSelAll.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSelAll.Size = New System.Drawing.Size(88, 21)
        Me.cmdSelAll.TabIndex = 5
        Me.cmdSelAll.Text = "Выделить все"
        Me.cmdSelAll.UseVisualStyleBackColor = False
        '
        'cmdUnselAll
        '
        Me.cmdUnselAll.BackColor = System.Drawing.SystemColors.Control
        Me.cmdUnselAll.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdUnselAll.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdUnselAll.Location = New System.Drawing.Point(360, 80)
        Me.cmdUnselAll.Name = "cmdUnselAll"
        Me.cmdUnselAll.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdUnselAll.Size = New System.Drawing.Size(88, 21)
        Me.cmdUnselAll.TabIndex = 6
        Me.cmdUnselAll.Text = "Отменить все"
        Me.cmdUnselAll.UseVisualStyleBackColor = False
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
        Me.txtPath.Location = New System.Drawing.Point(98, 8)
        Me.txtPath.MaxLength = 0
        Me.txtPath.Name = "txtPath"
        Me.txtPath.ReadOnly = True
        Me.txtPath.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPath.Size = New System.Drawing.Size(328, 20)
        Me.txtPath.TabIndex = 1
        '
        'OKButton
        '
        Me.OKButton.BackColor = System.Drawing.SystemColors.Control
        Me.OKButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.OKButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.OKButton.Location = New System.Drawing.Point(360, 200)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.OKButton.Size = New System.Drawing.Size(88, 21)
        Me.OKButton.TabIndex = 7
        Me.OKButton.Text = "Сохранить"
        Me.OKButton.UseVisualStyleBackColor = False
        '
        'cmbType
        '
        Me.cmbType.BackColor = System.Drawing.SystemColors.Window
        Me.cmbType.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbType.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbType.Location = New System.Drawing.Point(8, 56)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbType.Size = New System.Drawing.Size(345, 169)
        Me.cmbType.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(8, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(441, 17)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Описание типа"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(8, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(87, 17)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Куда сохранить:"
        '
        'frmSaveDesc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(456, 254)
        Me.Controls.Add(Me.pb)
        Me.Controls.Add(Me.cmdSelAll)
        Me.Controls.Add(Me.cmdUnselAll)
        Me.Controls.Add(Me.cmdPath)
        Me.Controls.Add(Me.txtPath)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.cmbType)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label8)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(4, 20)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSaveDesc"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Сохранить описание типа"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cdlgFolder As System.Windows.Forms.FolderBrowserDialog
#End Region 
End Class