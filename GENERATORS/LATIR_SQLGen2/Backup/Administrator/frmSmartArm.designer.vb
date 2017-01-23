<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmSmartArm
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
	Public WithEvents chkbDoNotDeleteAUTO As System.Windows.Forms.CheckBox
	Public WithEvents chkCreateARM As System.Windows.Forms.CheckBox
	Public WithEvents cmdSelAll As System.Windows.Forms.Button
	Public WithEvents cmdClearAll As System.Windows.Forms.Button
	Public WithEvents lstTypes As System.Windows.Forms.CheckedListBox
	Public WithEvents cmdStart As System.Windows.Forms.Button
	Public WithEvents pb As System.Windows.Forms.ProgressBar
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSmartArm))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.chkbDoNotDeleteAUTO = New System.Windows.Forms.CheckBox
		Me.chkCreateARM = New System.Windows.Forms.CheckBox
		Me.cmdSelAll = New System.Windows.Forms.Button
		Me.cmdClearAll = New System.Windows.Forms.Button
		Me.lstTypes = New System.Windows.Forms.CheckedListBox
		Me.cmdStart = New System.Windows.Forms.Button
		Me.pb = New System.Windows.Forms.ProgressBar
		Me.Label1 = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Скоростная подготовка"
		Me.ClientSize = New System.Drawing.Size(395, 418)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmSmartArm"
		Me.chkbDoNotDeleteAUTO.Text = "Оставлять АВТО вьхи"
		Me.chkbDoNotDeleteAUTO.Size = New System.Drawing.Size(225, 17)
		Me.chkbDoNotDeleteAUTO.Location = New System.Drawing.Point(8, 292)
		Me.chkbDoNotDeleteAUTO.TabIndex = 7
		Me.chkbDoNotDeleteAUTO.CheckState = System.Windows.Forms.CheckState.Checked
		Me.chkbDoNotDeleteAUTO.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkbDoNotDeleteAUTO.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkbDoNotDeleteAUTO.BackColor = System.Drawing.SystemColors.Control
		Me.chkbDoNotDeleteAUTO.CausesValidation = True
		Me.chkbDoNotDeleteAUTO.Enabled = True
		Me.chkbDoNotDeleteAUTO.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkbDoNotDeleteAUTO.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkbDoNotDeleteAUTO.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkbDoNotDeleteAUTO.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkbDoNotDeleteAUTO.TabStop = True
		Me.chkbDoNotDeleteAUTO.Visible = True
		Me.chkbDoNotDeleteAUTO.Name = "chkbDoNotDeleteAUTO"
		Me.chkCreateARM.Text = "Создавать АРМ"
		Me.chkCreateARM.Size = New System.Drawing.Size(225, 17)
		Me.chkCreateARM.Location = New System.Drawing.Point(8, 272)
		Me.chkCreateARM.TabIndex = 6
		Me.chkCreateARM.CheckState = System.Windows.Forms.CheckState.Checked
		Me.chkCreateARM.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkCreateARM.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkCreateARM.BackColor = System.Drawing.SystemColors.Control
		Me.chkCreateARM.CausesValidation = True
		Me.chkCreateARM.Enabled = True
		Me.chkCreateARM.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkCreateARM.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkCreateARM.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkCreateARM.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkCreateARM.TabStop = True
		Me.chkCreateARM.Visible = True
		Me.chkCreateARM.Name = "chkCreateARM"
		Me.cmdSelAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdSelAll.Text = "Выбрать все"
		Me.cmdSelAll.Size = New System.Drawing.Size(81, 21)
		Me.cmdSelAll.Location = New System.Drawing.Point(222, 320)
		Me.cmdSelAll.TabIndex = 2
		Me.cmdSelAll.BackColor = System.Drawing.SystemColors.Control
		Me.cmdSelAll.CausesValidation = True
		Me.cmdSelAll.Enabled = True
		Me.cmdSelAll.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdSelAll.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdSelAll.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdSelAll.TabStop = True
		Me.cmdSelAll.Name = "cmdSelAll"
		Me.cmdClearAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdClearAll.Text = "Отменить"
		Me.cmdClearAll.Size = New System.Drawing.Size(81, 21)
		Me.cmdClearAll.Location = New System.Drawing.Point(310, 320)
		Me.cmdClearAll.TabIndex = 3
		Me.cmdClearAll.BackColor = System.Drawing.SystemColors.Control
		Me.cmdClearAll.CausesValidation = True
		Me.cmdClearAll.Enabled = True
		Me.cmdClearAll.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdClearAll.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdClearAll.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdClearAll.TabStop = True
		Me.cmdClearAll.Name = "cmdClearAll"
		Me.lstTypes.Size = New System.Drawing.Size(391, 260)
		Me.lstTypes.IntegralHeight = False
		Me.lstTypes.Location = New System.Drawing.Point(2, 0)
		Me.lstTypes.Sorted = True
		Me.lstTypes.TabIndex = 0
		Me.lstTypes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lstTypes.BackColor = System.Drawing.SystemColors.Window
		Me.lstTypes.CausesValidation = True
		Me.lstTypes.Enabled = True
		Me.lstTypes.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lstTypes.Cursor = System.Windows.Forms.Cursors.Default
		Me.lstTypes.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me.lstTypes.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lstTypes.TabStop = True
		Me.lstTypes.Visible = True
		Me.lstTypes.MultiColumn = False
		Me.lstTypes.Name = "lstTypes"
		Me.cmdStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdStart.Text = "Запуск"
		Me.cmdStart.Size = New System.Drawing.Size(79, 21)
		Me.cmdStart.Location = New System.Drawing.Point(4, 321)
		Me.cmdStart.TabIndex = 1
		Me.cmdStart.BackColor = System.Drawing.SystemColors.Control
		Me.cmdStart.CausesValidation = True
		Me.cmdStart.Enabled = True
		Me.cmdStart.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdStart.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdStart.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdStart.TabStop = True
		Me.cmdStart.Name = "cmdStart"
		Me.pb.Size = New System.Drawing.Size(388, 20)
		Me.pb.Location = New System.Drawing.Point(2, 350)
		Me.pb.TabIndex = 4
		Me.pb.Visible = False
		Me.pb.Name = "pb"
		Me.Label1.Size = New System.Drawing.Size(390, 32)
		Me.Label1.Location = New System.Drawing.Point(2, 377)
		Me.Label1.TabIndex = 5
		Me.Label1.Visible = False
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label1.BackColor = System.Drawing.SystemColors.Control
		Me.Label1.Enabled = True
		Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Label1.Name = "Label1"
		Me.Controls.Add(chkbDoNotDeleteAUTO)
		Me.Controls.Add(chkCreateARM)
		Me.Controls.Add(cmdSelAll)
		Me.Controls.Add(cmdClearAll)
		Me.Controls.Add(lstTypes)
		Me.Controls.Add(cmdStart)
		Me.Controls.Add(pb)
		Me.Controls.Add(Label1)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class