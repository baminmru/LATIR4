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
    Public WithEvents lblServer As System.Windows.Forms.Label
    Public WithEvents lblLogin As System.Windows.Forms.Label
    Public WithEvents lblPassword As System.Windows.Forms.Label
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.lstBlocks = New System.Windows.Forms.CheckedListBox()
        Me.pb = New System.Windows.Forms.ProgressBar()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtLog = New System.Windows.Forms.TextBox()
        Me.cmdGo = New System.Windows.Forms.Button()
        Me.frameRight = New System.Windows.Forms.GroupBox()
        Me.txtServer = New System.Windows.Forms.TextBox()
        Me.txtLogin = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.lblServer = New System.Windows.Forms.Label()
        Me.lblLogin = New System.Windows.Forms.Label()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.cmdDataPath = New System.Windows.Forms.Button()
        Me.txtData = New System.Windows.Forms.TextBox()
        Me.DlgOpen = New System.Windows.Forms.OpenFileDialog()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Frame1.SuspendLayout()
        Me.frameRight.SuspendLayout()
        Me.SuspendLayout()
        '
        'Frame1
        '
        Me.Frame1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.lstBlocks)
        Me.Frame1.Controls.Add(Me.pb)
        Me.Frame1.Controls.Add(Me.Label3)
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(373, 0)
        Me.Frame1.Margin = New System.Windows.Forms.Padding(4)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.Padding = New System.Windows.Forms.Padding(4)
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(364, 267)
        Me.Frame1.TabIndex = 16
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Процесс инсталляции"
        '
        'lstBlocks
        '
        Me.lstBlocks.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstBlocks.BackColor = System.Drawing.SystemColors.Window
        Me.lstBlocks.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstBlocks.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstBlocks.Location = New System.Drawing.Point(4, 39)
        Me.lstBlocks.Margin = New System.Windows.Forms.Padding(4)
        Me.lstBlocks.Name = "lstBlocks"
        Me.lstBlocks.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstBlocks.Size = New System.Drawing.Size(341, 174)
        Me.lstBlocks.TabIndex = 18
        '
        'pb
        '
        Me.pb.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pb.Location = New System.Drawing.Point(11, 236)
        Me.pb.Margin = New System.Windows.Forms.Padding(4)
        Me.pb.Name = "pb"
        Me.pb.Size = New System.Drawing.Size(343, 21)
        Me.pb.TabIndex = 17
        Me.pb.Visible = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(11, 20)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(247, 21)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Модули"
        '
        'txtLog
        '
        Me.txtLog.AcceptsReturn = True
        Me.txtLog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLog.BackColor = System.Drawing.SystemColors.Window
        Me.txtLog.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLog.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLog.Location = New System.Drawing.Point(384, 295)
        Me.txtLog.Margin = New System.Windows.Forms.Padding(4)
        Me.txtLog.MaxLength = 0
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.ReadOnly = True
        Me.txtLog.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtLog.Size = New System.Drawing.Size(341, 79)
        Me.txtLog.TabIndex = 14
        Me.txtLog.WordWrap = False
        '
        'cmdGo
        '
        Me.cmdGo.BackColor = System.Drawing.SystemColors.Control
        Me.cmdGo.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdGo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdGo.Location = New System.Drawing.Point(21, 345)
        Me.cmdGo.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdGo.Name = "cmdGo"
        Me.cmdGo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdGo.Size = New System.Drawing.Size(300, 31)
        Me.cmdGo.TabIndex = 12
        Me.cmdGo.Text = "Начать инсталляцию"
        Me.cmdGo.UseVisualStyleBackColor = False
        '
        'frameRight
        '
        Me.frameRight.BackColor = System.Drawing.SystemColors.Control
        Me.frameRight.Controls.Add(Me.txtServer)
        Me.frameRight.Controls.Add(Me.txtLogin)
        Me.frameRight.Controls.Add(Me.txtPassword)
        Me.frameRight.Controls.Add(Me.lblServer)
        Me.frameRight.Controls.Add(Me.lblLogin)
        Me.frameRight.Controls.Add(Me.lblPassword)
        Me.frameRight.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frameRight.Location = New System.Drawing.Point(0, 0)
        Me.frameRight.Margin = New System.Windows.Forms.Padding(4)
        Me.frameRight.Name = "frameRight"
        Me.frameRight.Padding = New System.Windows.Forms.Padding(4)
        Me.frameRight.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frameRight.Size = New System.Drawing.Size(369, 265)
        Me.frameRight.TabIndex = 15
        Me.frameRight.TabStop = False
        Me.frameRight.Text = "Параметры подключения"
        '
        'txtServer
        '
        Me.txtServer.AcceptsReturn = True
        Me.txtServer.BackColor = System.Drawing.SystemColors.Window
        Me.txtServer.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtServer.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtServer.Location = New System.Drawing.Point(16, 39)
        Me.txtServer.Margin = New System.Windows.Forms.Padding(4)
        Me.txtServer.MaxLength = 0
        Me.txtServer.Name = "txtServer"
        Me.txtServer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtServer.Size = New System.Drawing.Size(341, 22)
        Me.txtServer.TabIndex = 1
        Me.txtServer.Text = "//localhost/ORA"
        '
        'txtLogin
        '
        Me.txtLogin.AcceptsReturn = True
        Me.txtLogin.BackColor = System.Drawing.SystemColors.Window
        Me.txtLogin.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLogin.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLogin.Location = New System.Drawing.Point(16, 172)
        Me.txtLogin.Margin = New System.Windows.Forms.Padding(4)
        Me.txtLogin.MaxLength = 0
        Me.txtLogin.Name = "txtLogin"
        Me.txtLogin.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLogin.Size = New System.Drawing.Size(341, 22)
        Me.txtLogin.TabIndex = 6
        '
        'txtPassword
        '
        Me.txtPassword.AcceptsReturn = True
        Me.txtPassword.BackColor = System.Drawing.SystemColors.Window
        Me.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPassword.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPassword.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtPassword.Location = New System.Drawing.Point(16, 225)
        Me.txtPassword.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPassword.MaxLength = 0
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPassword.Size = New System.Drawing.Size(341, 22)
        Me.txtPassword.TabIndex = 8
        '
        'lblServer
        '
        Me.lblServer.BackColor = System.Drawing.SystemColors.Control
        Me.lblServer.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblServer.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblServer.Location = New System.Drawing.Point(16, 20)
        Me.lblServer.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblServer.Name = "lblServer"
        Me.lblServer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblServer.Size = New System.Drawing.Size(343, 21)
        Me.lblServer.TabIndex = 0
        Me.lblServer.Text = "Oracle сервер instance:"
        '
        'lblLogin
        '
        Me.lblLogin.BackColor = System.Drawing.SystemColors.Control
        Me.lblLogin.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLogin.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLogin.Location = New System.Drawing.Point(16, 155)
        Me.lblLogin.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLogin.Name = "lblLogin"
        Me.lblLogin.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLogin.Size = New System.Drawing.Size(343, 21)
        Me.lblLogin.TabIndex = 5
        Me.lblLogin.Text = "SQL имя пользователя:"
        '
        'lblPassword
        '
        Me.lblPassword.BackColor = System.Drawing.SystemColors.Control
        Me.lblPassword.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPassword.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPassword.Location = New System.Drawing.Point(16, 207)
        Me.lblPassword.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPassword.Size = New System.Drawing.Size(343, 21)
        Me.lblPassword.TabIndex = 7
        Me.lblPassword.Text = "SQL пароль:"
        '
        'cmdDataPath
        '
        Me.cmdDataPath.BackColor = System.Drawing.SystemColors.Control
        Me.cmdDataPath.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdDataPath.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdDataPath.Location = New System.Drawing.Point(331, 295)
        Me.cmdDataPath.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdDataPath.Name = "cmdDataPath"
        Me.cmdDataPath.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdDataPath.Size = New System.Drawing.Size(28, 26)
        Me.cmdDataPath.TabIndex = 11
        Me.cmdDataPath.Text = "..."
        Me.cmdDataPath.UseVisualStyleBackColor = False
        '
        'txtData
        '
        Me.txtData.AcceptsReturn = True
        Me.txtData.BackColor = System.Drawing.SystemColors.Window
        Me.txtData.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtData.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtData.Location = New System.Drawing.Point(21, 295)
        Me.txtData.Margin = New System.Windows.Forms.Padding(4)
        Me.txtData.MaxLength = 0
        Me.txtData.Name = "txtData"
        Me.txtData.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtData.Size = New System.Drawing.Size(299, 22)
        Me.txtData.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(384, 276)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(161, 21)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Ошибки"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(21, 276)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(196, 21)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Файл с данными  (xml):"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(749, 388)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.txtLog)
        Me.Controls.Add(Me.cmdGo)
        Me.Controls.Add(Me.frameRight)
        Me.Controls.Add(Me.cmdDataPath)
        Me.Controls.Add(Me.txtData)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(356, 40)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Form1"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Инсталлятор базы данных"
        Me.Frame1.ResumeLayout(False)
        Me.frameRight.ResumeLayout(False)
        Me.frameRight.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region
End Class