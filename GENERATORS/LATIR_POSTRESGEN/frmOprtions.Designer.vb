<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmOptions
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
	Public WithEvents chkMethods As System.Windows.Forms.CheckBox
	Public WithEvents chkProcs As System.Windows.Forms.CheckBox
	Public WithEvents chkInit As System.Windows.Forms.CheckBox
	Public WithEvents chkView As System.Windows.Forms.CheckBox
	Public WithEvents chkKernel As System.Windows.Forms.CheckBox
	Public WithEvents chkTables As System.Windows.Forms.CheckBox
	Public WithEvents CancelButton_Renamed As System.Windows.Forms.Button
	Public WithEvents OKButton As System.Windows.Forms.Button
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmOptions))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.chkMethods = New System.Windows.Forms.CheckBox
		Me.chkProcs = New System.Windows.Forms.CheckBox
		Me.chkInit = New System.Windows.Forms.CheckBox
		Me.chkView = New System.Windows.Forms.CheckBox
		Me.chkKernel = New System.Windows.Forms.CheckBox
		Me.chkTables = New System.Windows.Forms.CheckBox
		Me.CancelButton_Renamed = New System.Windows.Forms.Button
		Me.OKButton = New System.Windows.Forms.Button
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Параметры генерации"
		Me.ClientSize = New System.Drawing.Size(361, 186)
		Me.Location = New System.Drawing.Point(184, 250)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.ShowInTaskbar = False
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmOptions"
		Me.chkMethods.Text = "Методы"
		Me.chkMethods.Size = New System.Drawing.Size(244, 20)
		Me.chkMethods.Location = New System.Drawing.Point(18, 157)
		Me.chkMethods.TabIndex = 7
		Me.chkMethods.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkMethods.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkMethods.BackColor = System.Drawing.SystemColors.Control
		Me.chkMethods.CausesValidation = True
		Me.chkMethods.Enabled = True
		Me.chkMethods.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkMethods.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkMethods.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkMethods.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkMethods.TabStop = True
		Me.chkMethods.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkMethods.Visible = True
		Me.chkMethods.Name = "chkMethods"
		Me.chkProcs.Text = "Процедуры"
		Me.chkProcs.Size = New System.Drawing.Size(244, 20)
		Me.chkProcs.Location = New System.Drawing.Point(18, 128)
		Me.chkProcs.TabIndex = 6
		Me.chkProcs.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkProcs.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkProcs.BackColor = System.Drawing.SystemColors.Control
		Me.chkProcs.CausesValidation = True
		Me.chkProcs.Enabled = True
		Me.chkProcs.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkProcs.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkProcs.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkProcs.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkProcs.TabStop = True
		Me.chkProcs.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkProcs.Visible = True
		Me.chkProcs.Name = "chkProcs"
		Me.chkInit.Text = "Инициализация базы"
		Me.chkInit.Size = New System.Drawing.Size(244, 20)
		Me.chkInit.Location = New System.Drawing.Point(18, 98)
		Me.chkInit.TabIndex = 5
		Me.chkInit.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkInit.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkInit.BackColor = System.Drawing.SystemColors.Control
		Me.chkInit.CausesValidation = True
		Me.chkInit.Enabled = True
		Me.chkInit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkInit.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkInit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkInit.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkInit.TabStop = True
		Me.chkInit.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkInit.Visible = True
		Me.chkInit.Name = "chkInit"
		Me.chkView.Text = "Запросы (View)"
		Me.chkView.Size = New System.Drawing.Size(244, 20)
		Me.chkView.Location = New System.Drawing.Point(18, 39)
		Me.chkView.TabIndex = 4
		Me.chkView.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkView.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkView.BackColor = System.Drawing.SystemColors.Control
		Me.chkView.CausesValidation = True
		Me.chkView.Enabled = True
		Me.chkView.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkView.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkView.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkView.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkView.TabStop = True
		Me.chkView.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkView.Visible = True
		Me.chkView.Name = "chkView"
		Me.chkKernel.Text = "Ядро"
		Me.chkKernel.Size = New System.Drawing.Size(244, 20)
		Me.chkKernel.Location = New System.Drawing.Point(18, 69)
		Me.chkKernel.TabIndex = 3
		Me.chkKernel.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkKernel.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkKernel.BackColor = System.Drawing.SystemColors.Control
		Me.chkKernel.CausesValidation = True
		Me.chkKernel.Enabled = True
		Me.chkKernel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkKernel.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkKernel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkKernel.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkKernel.TabStop = True
		Me.chkKernel.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkKernel.Visible = True
		Me.chkKernel.Name = "chkKernel"
		Me.chkTables.Text = "Структура таблиц"
		Me.chkTables.Size = New System.Drawing.Size(244, 20)
		Me.chkTables.Location = New System.Drawing.Point(16, 9)
		Me.chkTables.TabIndex = 2
		Me.chkTables.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkTables.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkTables.BackColor = System.Drawing.SystemColors.Control
		Me.chkTables.CausesValidation = True
		Me.chkTables.Enabled = True
		Me.chkTables.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkTables.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkTables.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkTables.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkTables.TabStop = True
		Me.chkTables.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkTables.Visible = True
		Me.chkTables.Name = "chkTables"
		Me.CancelButton_Renamed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CancelButton_Renamed.Text = "Cancel"
		Me.CancelButton_Renamed.Size = New System.Drawing.Size(81, 25)
		Me.CancelButton_Renamed.Location = New System.Drawing.Point(271, 40)
		Me.CancelButton_Renamed.TabIndex = 1
		Me.CancelButton_Renamed.BackColor = System.Drawing.SystemColors.Control
		Me.CancelButton_Renamed.CausesValidation = True
		Me.CancelButton_Renamed.Enabled = True
		Me.CancelButton_Renamed.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CancelButton_Renamed.Cursor = System.Windows.Forms.Cursors.Default
		Me.CancelButton_Renamed.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CancelButton_Renamed.TabStop = True
		Me.CancelButton_Renamed.Name = "CancelButton_Renamed"
		Me.OKButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.OKButton.Text = "OK"
		Me.OKButton.Size = New System.Drawing.Size(81, 25)
		Me.OKButton.Location = New System.Drawing.Point(271, 9)
		Me.OKButton.TabIndex = 0
		Me.OKButton.BackColor = System.Drawing.SystemColors.Control
		Me.OKButton.CausesValidation = True
		Me.OKButton.Enabled = True
		Me.OKButton.ForeColor = System.Drawing.SystemColors.ControlText
		Me.OKButton.Cursor = System.Windows.Forms.Cursors.Default
		Me.OKButton.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.OKButton.TabStop = True
		Me.OKButton.Name = "OKButton"
		Me.Controls.Add(chkMethods)
		Me.Controls.Add(chkProcs)
		Me.Controls.Add(chkInit)
		Me.Controls.Add(chkView)
		Me.Controls.Add(chkKernel)
		Me.Controls.Add(chkTables)
		Me.Controls.Add(CancelButton_Renamed)
		Me.Controls.Add(OKButton)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class