<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmSaveTool
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
	Public WithEvents txtPath As System.Windows.Forms.TextBox
	Public WithEvents cmdPath As System.Windows.Forms.Button
	Public WithEvents cmdUnselAll As System.Windows.Forms.Button
	Public WithEvents cmdSelAll As System.Windows.Forms.Button
	Public WithEvents cmdSave As System.Windows.Forms.Button
	Public WithEvents lstObj As System.Windows.Forms.CheckedListBox
	Public WithEvents cmbType As System.Windows.Forms.ComboBox
	Public WithEvents Label8 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSaveTool))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtPath = New System.Windows.Forms.TextBox
        Me.cmdPath = New System.Windows.Forms.Button
        Me.cmdUnselAll = New System.Windows.Forms.Button
        Me.cmdSelAll = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.lstObj = New System.Windows.Forms.CheckedListBox
        Me.cmbType = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cdlgfolder = New System.Windows.Forms.FolderBrowserDialog
        Me.SuspendLayout()
        '
        'txtPath
        '
        Me.txtPath.AcceptsReturn = True
        Me.txtPath.BackColor = System.Drawing.SystemColors.Window
        Me.txtPath.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPath.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPath.Location = New System.Drawing.Point(126, 328)
        Me.txtPath.MaxLength = 0
        Me.txtPath.Name = "txtPath"
        Me.txtPath.ReadOnly = True
        Me.txtPath.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPath.Size = New System.Drawing.Size(310, 20)
        Me.txtPath.TabIndex = 4
        '
        'cmdPath
        '
        Me.cmdPath.BackColor = System.Drawing.SystemColors.Control
        Me.cmdPath.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdPath.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdPath.Location = New System.Drawing.Point(436, 328)
        Me.cmdPath.Name = "cmdPath"
        Me.cmdPath.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdPath.Size = New System.Drawing.Size(21, 21)
        Me.cmdPath.TabIndex = 5
        Me.cmdPath.Text = "..."
        Me.cmdPath.UseVisualStyleBackColor = False
        '
        'cmdUnselAll
        '
        Me.cmdUnselAll.BackColor = System.Drawing.SystemColors.Control
        Me.cmdUnselAll.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdUnselAll.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdUnselAll.Location = New System.Drawing.Point(103, 369)
        Me.cmdUnselAll.Name = "cmdUnselAll"
        Me.cmdUnselAll.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdUnselAll.Size = New System.Drawing.Size(90, 21)
        Me.cmdUnselAll.TabIndex = 7
        Me.cmdUnselAll.Text = "Отменить все"
        Me.cmdUnselAll.UseVisualStyleBackColor = False
        '
        'cmdSelAll
        '
        Me.cmdSelAll.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSelAll.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSelAll.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSelAll.Location = New System.Drawing.Point(8, 368)
        Me.cmdSelAll.Name = "cmdSelAll"
        Me.cmdSelAll.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSelAll.Size = New System.Drawing.Size(90, 21)
        Me.cmdSelAll.TabIndex = 6
        Me.cmdSelAll.Text = "Выделить все"
        Me.cmdSelAll.UseVisualStyleBackColor = False
        '
        'cmdSave
        '
        Me.cmdSave.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSave.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSave.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSave.Location = New System.Drawing.Point(375, 367)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSave.Size = New System.Drawing.Size(79, 21)
        Me.cmdSave.TabIndex = 8
        Me.cmdSave.Text = "Сохранить"
        Me.cmdSave.UseVisualStyleBackColor = False
        '
        'lstObj
        '
        Me.lstObj.BackColor = System.Drawing.SystemColors.Window
        Me.lstObj.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstObj.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstObj.Location = New System.Drawing.Point(8, 44)
        Me.lstObj.Name = "lstObj"
        Me.lstObj.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstObj.Size = New System.Drawing.Size(449, 274)
        Me.lstObj.TabIndex = 2
        '
        'cmbType
        '
        Me.cmbType.BackColor = System.Drawing.SystemColors.Window
        Me.cmbType.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbType.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbType.Location = New System.Drawing.Point(8, 22)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbType.Size = New System.Drawing.Size(449, 21)
        Me.cmbType.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(9, 328)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(119, 17)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Куда сохранить:"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(8, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(225, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Тип документа"
        '
        'frmSaveTool
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(460, 394)
        Me.Controls.Add(Me.txtPath)
        Me.Controls.Add(Me.cmdPath)
        Me.Controls.Add(Me.cmdUnselAll)
        Me.Controls.Add(Me.cmdSelAll)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.lstObj)
        Me.Controls.Add(Me.cmbType)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSaveTool"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Сохранение документов"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cdlgfolder As System.Windows.Forms.FolderBrowserDialog
#End Region 
End Class