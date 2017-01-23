<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class Form1
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
	Public WithEvents lstBlocks As System.Windows.Forms.CheckedListBox
	Public WithEvents pb As System.Windows.Forms.ProgressBar
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents txtLog As System.Windows.Forms.TextBox
	Public WithEvents cmdGo As System.Windows.Forms.Button
	Public WithEvents txtServer As System.Windows.Forms.TextBox
	Public WithEvents txtLogin As System.Windows.Forms.TextBox
	Public WithEvents txtPassword As System.Windows.Forms.TextBox
	Public WithEvents txtDatabase As System.Windows.Forms.TextBox
	Public WithEvents chkIntegrated As System.Windows.Forms.CheckBox
	Public WithEvents lblServer As System.Windows.Forms.Label
	Public WithEvents lblLogin As System.Windows.Forms.Label
	Public WithEvents lblPassword As System.Windows.Forms.Label
	Public WithEvents lblDatabase As System.Windows.Forms.Label
	Public WithEvents frameRight As System.Windows.Forms.GroupBox
	Public WithEvents cmdDataPath As System.Windows.Forms.Button
	Public WithEvents txtData As System.Windows.Forms.TextBox
	Public DlgOpen As System.Windows.Forms.OpenFileDialog
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.Frame1 = New System.Windows.Forms.GroupBox
		Me.lstBlocks = New System.Windows.Forms.CheckedListBox
		Me.pb = New System.Windows.Forms.ProgressBar
		Me.Label3 = New System.Windows.Forms.Label
		Me.txtLog = New System.Windows.Forms.TextBox
		Me.cmdGo = New System.Windows.Forms.Button
		Me.frameRight = New System.Windows.Forms.GroupBox
		Me.txtServer = New System.Windows.Forms.TextBox
		Me.txtLogin = New System.Windows.Forms.TextBox
		Me.txtPassword = New System.Windows.Forms.TextBox
		Me.txtDatabase = New System.Windows.Forms.TextBox
		Me.chkIntegrated = New System.Windows.Forms.CheckBox
		Me.lblServer = New System.Windows.Forms.Label
		Me.lblLogin = New System.Windows.Forms.Label
		Me.lblPassword = New System.Windows.Forms.Label
		Me.lblDatabase = New System.Windows.Forms.Label
		Me.cmdDataPath = New System.Windows.Forms.Button
		Me.txtData = New System.Windows.Forms.TextBox
		Me.DlgOpen = New System.Windows.Forms.OpenFileDialog
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.Frame1.SuspendLayout()
		Me.frameRight.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Инсталлятор базы данных"
		Me.ClientSize = New System.Drawing.Size(562, 312)
		Me.Location = New System.Drawing.Point(356, 40)
		Me.Icon = CType(resources.GetObject("Form1.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "Form1"
		Me.Frame1.Text = "Процесс инсталляции"
		Me.Frame1.Enabled = False
		Me.Frame1.Size = New System.Drawing.Size(273, 217)
		Me.Frame1.Location = New System.Drawing.Point(280, 0)
		Me.Frame1.TabIndex = 16
		Me.Frame1.BackColor = System.Drawing.SystemColors.Control
		Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame1.Visible = True
		Me.Frame1.Name = "Frame1"
		Me.lstBlocks.Size = New System.Drawing.Size(257, 154)
		Me.lstBlocks.Location = New System.Drawing.Point(8, 32)
		Me.lstBlocks.TabIndex = 18
		Me.lstBlocks.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lstBlocks.BackColor = System.Drawing.SystemColors.Window
		Me.lstBlocks.CausesValidation = True
		Me.lstBlocks.Enabled = True
		Me.lstBlocks.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lstBlocks.IntegralHeight = True
		Me.lstBlocks.Cursor = System.Windows.Forms.Cursors.Default
		Me.lstBlocks.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me.lstBlocks.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lstBlocks.Sorted = False
		Me.lstBlocks.TabStop = True
		Me.lstBlocks.Visible = True
		Me.lstBlocks.MultiColumn = False
		Me.lstBlocks.Name = "lstBlocks"
		Me.pb.Size = New System.Drawing.Size(257, 17)
		Me.pb.Location = New System.Drawing.Point(8, 192)
		Me.pb.TabIndex = 17
		Me.pb.Visible = False
		Me.pb.Name = "pb"
		Me.Label3.Text = "Модули"
		Me.Label3.Size = New System.Drawing.Size(185, 17)
		Me.Label3.Location = New System.Drawing.Point(8, 16)
		Me.Label3.TabIndex = 19
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label3.BackColor = System.Drawing.SystemColors.Control
		Me.Label3.Enabled = True
		Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label3.UseMnemonic = True
		Me.Label3.Visible = True
		Me.Label3.AutoSize = False
		Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label3.Name = "Label3"
		Me.txtLog.AutoSize = False
		Me.txtLog.Size = New System.Drawing.Size(257, 65)
		Me.txtLog.Location = New System.Drawing.Point(288, 240)
		Me.txtLog.ReadOnly = True
		Me.txtLog.MultiLine = True
		Me.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both
		Me.txtLog.WordWrap = False
		Me.txtLog.TabIndex = 14
		Me.txtLog.AcceptsReturn = True
		Me.txtLog.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtLog.BackColor = System.Drawing.SystemColors.Window
		Me.txtLog.CausesValidation = True
		Me.txtLog.Enabled = True
		Me.txtLog.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtLog.HideSelection = True
		Me.txtLog.Maxlength = 0
		Me.txtLog.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtLog.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtLog.TabStop = True
		Me.txtLog.Visible = True
		Me.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtLog.Name = "txtLog"
		Me.cmdGo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdGo.Text = "Начать инсталляцию"
		Me.cmdGo.Size = New System.Drawing.Size(225, 25)
		Me.cmdGo.Location = New System.Drawing.Point(16, 280)
		Me.cmdGo.TabIndex = 12
		Me.cmdGo.BackColor = System.Drawing.SystemColors.Control
		Me.cmdGo.CausesValidation = True
		Me.cmdGo.Enabled = True
		Me.cmdGo.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdGo.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdGo.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdGo.TabStop = True
		Me.cmdGo.Name = "cmdGo"
		Me.frameRight.Text = "Параметры подключения"
		Me.frameRight.Size = New System.Drawing.Size(277, 215)
		Me.frameRight.Location = New System.Drawing.Point(0, 0)
		Me.frameRight.TabIndex = 15
		Me.frameRight.BackColor = System.Drawing.SystemColors.Control
		Me.frameRight.Enabled = True
		Me.frameRight.ForeColor = System.Drawing.SystemColors.ControlText
		Me.frameRight.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.frameRight.Visible = True
		Me.frameRight.Name = "frameRight"
		Me.txtServer.AutoSize = False
		Me.txtServer.Size = New System.Drawing.Size(257, 19)
		Me.txtServer.Location = New System.Drawing.Point(12, 32)
		Me.txtServer.TabIndex = 1
		Me.txtServer.AcceptsReturn = True
		Me.txtServer.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtServer.BackColor = System.Drawing.SystemColors.Window
		Me.txtServer.CausesValidation = True
		Me.txtServer.Enabled = True
		Me.txtServer.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtServer.HideSelection = True
		Me.txtServer.ReadOnly = False
		Me.txtServer.Maxlength = 0
		Me.txtServer.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtServer.MultiLine = False
		Me.txtServer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtServer.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtServer.TabStop = True
		Me.txtServer.Visible = True
		Me.txtServer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtServer.Name = "txtServer"
		Me.txtLogin.AutoSize = False
		Me.txtLogin.Size = New System.Drawing.Size(257, 19)
		Me.txtLogin.Location = New System.Drawing.Point(12, 140)
		Me.txtLogin.TabIndex = 6
		Me.txtLogin.AcceptsReturn = True
		Me.txtLogin.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtLogin.BackColor = System.Drawing.SystemColors.Window
		Me.txtLogin.CausesValidation = True
		Me.txtLogin.Enabled = True
		Me.txtLogin.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtLogin.HideSelection = True
		Me.txtLogin.ReadOnly = False
		Me.txtLogin.Maxlength = 0
		Me.txtLogin.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtLogin.MultiLine = False
		Me.txtLogin.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtLogin.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtLogin.TabStop = True
		Me.txtLogin.Visible = True
		Me.txtLogin.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtLogin.Name = "txtLogin"
		Me.txtPassword.AutoSize = False
		Me.txtPassword.Size = New System.Drawing.Size(257, 19)
		Me.txtPassword.IMEMode = System.Windows.Forms.ImeMode.Disable
		Me.txtPassword.Location = New System.Drawing.Point(12, 183)
		Me.txtPassword.PasswordChar = ChrW(42)
		Me.txtPassword.TabIndex = 8
		Me.txtPassword.AcceptsReturn = True
		Me.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtPassword.BackColor = System.Drawing.SystemColors.Window
		Me.txtPassword.CausesValidation = True
		Me.txtPassword.Enabled = True
		Me.txtPassword.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtPassword.HideSelection = True
		Me.txtPassword.ReadOnly = False
		Me.txtPassword.Maxlength = 0
		Me.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtPassword.MultiLine = False
		Me.txtPassword.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtPassword.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtPassword.TabStop = True
		Me.txtPassword.Visible = True
		Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtPassword.Name = "txtPassword"
		Me.txtDatabase.AutoSize = False
		Me.txtDatabase.Size = New System.Drawing.Size(257, 19)
		Me.txtDatabase.Location = New System.Drawing.Point(12, 75)
		Me.txtDatabase.TabIndex = 3
		Me.txtDatabase.AcceptsReturn = True
		Me.txtDatabase.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtDatabase.BackColor = System.Drawing.SystemColors.Window
		Me.txtDatabase.CausesValidation = True
		Me.txtDatabase.Enabled = True
		Me.txtDatabase.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtDatabase.HideSelection = True
		Me.txtDatabase.ReadOnly = False
		Me.txtDatabase.Maxlength = 0
		Me.txtDatabase.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtDatabase.MultiLine = False
		Me.txtDatabase.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtDatabase.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtDatabase.TabStop = True
		Me.txtDatabase.Visible = True
		Me.txtDatabase.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtDatabase.Name = "txtDatabase"
		Me.chkIntegrated.Text = "Интегрированная NT безопасность"
		Me.chkIntegrated.Size = New System.Drawing.Size(257, 17)
		Me.chkIntegrated.Location = New System.Drawing.Point(12, 104)
		Me.chkIntegrated.TabIndex = 4
		Me.chkIntegrated.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkIntegrated.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkIntegrated.BackColor = System.Drawing.SystemColors.Control
		Me.chkIntegrated.CausesValidation = True
		Me.chkIntegrated.Enabled = True
		Me.chkIntegrated.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkIntegrated.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkIntegrated.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkIntegrated.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkIntegrated.TabStop = True
		Me.chkIntegrated.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkIntegrated.Visible = True
		Me.chkIntegrated.Name = "chkIntegrated"
		Me.lblServer.Text = "SQL сервер:"
		Me.lblServer.Size = New System.Drawing.Size(257, 17)
		Me.lblServer.Location = New System.Drawing.Point(12, 16)
		Me.lblServer.TabIndex = 0
		Me.lblServer.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblServer.BackColor = System.Drawing.SystemColors.Control
		Me.lblServer.Enabled = True
		Me.lblServer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblServer.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblServer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblServer.UseMnemonic = True
		Me.lblServer.Visible = True
		Me.lblServer.AutoSize = False
		Me.lblServer.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblServer.Name = "lblServer"
		Me.lblLogin.Text = "SQL имя пользователя:"
		Me.lblLogin.Size = New System.Drawing.Size(257, 17)
		Me.lblLogin.Location = New System.Drawing.Point(12, 126)
		Me.lblLogin.TabIndex = 5
		Me.lblLogin.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblLogin.BackColor = System.Drawing.SystemColors.Control
		Me.lblLogin.Enabled = True
		Me.lblLogin.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblLogin.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblLogin.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblLogin.UseMnemonic = True
		Me.lblLogin.Visible = True
		Me.lblLogin.AutoSize = False
		Me.lblLogin.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblLogin.Name = "lblLogin"
		Me.lblPassword.Text = "SQL пароль:"
		Me.lblPassword.Size = New System.Drawing.Size(257, 17)
		Me.lblPassword.Location = New System.Drawing.Point(12, 168)
		Me.lblPassword.TabIndex = 7
		Me.lblPassword.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblPassword.BackColor = System.Drawing.SystemColors.Control
		Me.lblPassword.Enabled = True
		Me.lblPassword.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblPassword.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblPassword.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblPassword.UseMnemonic = True
		Me.lblPassword.Visible = True
		Me.lblPassword.AutoSize = False
		Me.lblPassword.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblPassword.Name = "lblPassword"
		Me.lblDatabase.Text = "База данных сайта:"
		Me.lblDatabase.Size = New System.Drawing.Size(257, 17)
		Me.lblDatabase.Location = New System.Drawing.Point(12, 59)
		Me.lblDatabase.TabIndex = 2
		Me.lblDatabase.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblDatabase.BackColor = System.Drawing.SystemColors.Control
		Me.lblDatabase.Enabled = True
		Me.lblDatabase.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblDatabase.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDatabase.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDatabase.UseMnemonic = True
		Me.lblDatabase.Visible = True
		Me.lblDatabase.AutoSize = False
		Me.lblDatabase.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblDatabase.Name = "lblDatabase"
		Me.cmdDataPath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdDataPath.Text = "..."
		Me.cmdDataPath.Size = New System.Drawing.Size(21, 21)
		Me.cmdDataPath.Location = New System.Drawing.Point(248, 240)
		Me.cmdDataPath.TabIndex = 11
		Me.cmdDataPath.BackColor = System.Drawing.SystemColors.Control
		Me.cmdDataPath.CausesValidation = True
		Me.cmdDataPath.Enabled = True
		Me.cmdDataPath.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdDataPath.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdDataPath.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdDataPath.TabStop = True
		Me.cmdDataPath.Name = "cmdDataPath"
		Me.txtData.AutoSize = False
		Me.txtData.Size = New System.Drawing.Size(225, 19)
		Me.txtData.Location = New System.Drawing.Point(16, 240)
		Me.txtData.TabIndex = 10
		Me.txtData.AcceptsReturn = True
		Me.txtData.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtData.BackColor = System.Drawing.SystemColors.Window
		Me.txtData.CausesValidation = True
		Me.txtData.Enabled = True
		Me.txtData.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtData.HideSelection = True
		Me.txtData.ReadOnly = False
		Me.txtData.Maxlength = 0
		Me.txtData.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtData.MultiLine = False
		Me.txtData.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtData.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtData.TabStop = True
		Me.txtData.Visible = True
		Me.txtData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtData.Name = "txtData"
		Me.Label2.Text = "Ошибки"
		Me.Label2.Size = New System.Drawing.Size(121, 17)
		Me.Label2.Location = New System.Drawing.Point(288, 224)
		Me.Label2.TabIndex = 13
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label2.BackColor = System.Drawing.SystemColors.Control
		Me.Label2.Enabled = True
		Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2.UseMnemonic = True
		Me.Label2.Visible = True
		Me.Label2.AutoSize = False
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label2.Name = "Label2"
		Me.Label1.Text = "Файл с данными  (xml):"
		Me.Label1.Size = New System.Drawing.Size(147, 17)
		Me.Label1.Location = New System.Drawing.Point(16, 224)
		Me.Label1.TabIndex = 9
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label1.BackColor = System.Drawing.SystemColors.Control
		Me.Label1.Enabled = True
		Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.Controls.Add(Frame1)
		Me.Controls.Add(txtLog)
		Me.Controls.Add(cmdGo)
		Me.Controls.Add(frameRight)
		Me.Controls.Add(cmdDataPath)
		Me.Controls.Add(txtData)
		Me.Controls.Add(Label2)
		Me.Controls.Add(Label1)
		Me.Frame1.Controls.Add(lstBlocks)
		Me.Frame1.Controls.Add(pb)
		Me.Frame1.Controls.Add(Label3)
		Me.frameRight.Controls.Add(txtServer)
		Me.frameRight.Controls.Add(txtLogin)
		Me.frameRight.Controls.Add(txtPassword)
		Me.frameRight.Controls.Add(txtDatabase)
		Me.frameRight.Controls.Add(chkIntegrated)
		Me.frameRight.Controls.Add(lblServer)
		Me.frameRight.Controls.Add(lblLogin)
		Me.frameRight.Controls.Add(lblPassword)
		Me.frameRight.Controls.Add(lblDatabase)
		Me.Frame1.ResumeLayout(False)
		Me.frameRight.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class