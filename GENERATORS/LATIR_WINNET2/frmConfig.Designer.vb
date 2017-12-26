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
    Public WithEvents txtLevel2 As LATIR2GuiManager.TouchTextBox
    Public WithEvents cmdPath3 As System.Windows.Forms.Button
    Public WithEvents txtControls As LATIR2GuiManager.TouchTextBox
    Public WithEvents cmdPath2 As System.Windows.Forms.Button
    Public WithEvents txtGUIManager As LATIR2GuiManager.TouchTextBox
    Public WithEvents Command3 As System.Windows.Forms.Button
    Public cdlgOpen As System.Windows.Forms.OpenFileDialog
    Public WithEvents Command2 As System.Windows.Forms.Button
    Public WithEvents Command1 As System.Windows.Forms.Button
    Public WithEvents txtPath As LATIR2GuiManager.TouchTextBox
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtLevel2 = New LATIR2GuiManager.TouchTextBox()
        Me.cmdPath3 = New System.Windows.Forms.Button()
        Me.txtControls = New LATIR2GuiManager.TouchTextBox()
        Me.cmdPath2 = New System.Windows.Forms.Button()
        Me.txtGUIManager = New LATIR2GuiManager.TouchTextBox()
        Me.Command3 = New System.Windows.Forms.Button()
        Me.cdlgOpen = New System.Windows.Forms.OpenFileDialog()
        Me.Command2 = New System.Windows.Forms.Button()
        Me.Command1 = New System.Windows.Forms.Button()
        Me.txtPath = New LATIR2GuiManager.TouchTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.MaskedTextBox1 = New System.Windows.Forms.MaskedTextBox()
        Me.SuspendLayout()
        '
        'txtLevel2
        '
        Me.txtLevel2.AcceptsReturn = True
        Me.txtLevel2.BackColor = System.Drawing.SystemColors.Window
        Me.txtLevel2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLevel2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLevel2.Location = New System.Drawing.Point(11, 183)
        Me.txtLevel2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtLevel2.MaxLength = 0
        Me.txtLevel2.Name = "txtLevel2"
        Me.txtLevel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLevel2.Size = New System.Drawing.Size(376, 22)
        Me.txtLevel2.TabIndex = 10
        Me.txtLevel2.Text = "C:\LATIR4\Build\"
        '
        'cmdPath3
        '
        Me.cmdPath3.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdPath3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdPath3.Location = New System.Drawing.Point(395, 133)
        Me.cmdPath3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdPath3.Name = "cmdPath3"
        Me.cmdPath3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdPath3.Size = New System.Drawing.Size(32, 30)
        Me.cmdPath3.TabIndex = 8
        Me.cmdPath3.Text = "..."
        '
        'txtControls
        '
        Me.txtControls.AcceptsReturn = True
        Me.txtControls.BackColor = System.Drawing.SystemColors.Window
        Me.txtControls.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtControls.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtControls.Location = New System.Drawing.Point(11, 133)
        Me.txtControls.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtControls.MaxLength = 0
        Me.txtControls.Name = "txtControls"
        Me.txtControls.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtControls.Size = New System.Drawing.Size(376, 22)
        Me.txtControls.TabIndex = 7
        Me.txtControls.Text = "C:\LATIR4\Build\LATIR2GUIManager.dll"
        '
        'cmdPath2
        '
        Me.cmdPath2.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdPath2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdPath2.Location = New System.Drawing.Point(395, 82)
        Me.cmdPath2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdPath2.Name = "cmdPath2"
        Me.cmdPath2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdPath2.Size = New System.Drawing.Size(32, 30)
        Me.cmdPath2.TabIndex = 5
        Me.cmdPath2.Text = "..."
        '
        'txtGUIManager
        '
        Me.txtGUIManager.AcceptsReturn = True
        Me.txtGUIManager.BackColor = System.Drawing.SystemColors.Window
        Me.txtGUIManager.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtGUIManager.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtGUIManager.Location = New System.Drawing.Point(11, 82)
        Me.txtGUIManager.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtGUIManager.MaxLength = 0
        Me.txtGUIManager.Name = "txtGUIManager"
        Me.txtGUIManager.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtGUIManager.Size = New System.Drawing.Size(376, 22)
        Me.txtGUIManager.TabIndex = 4
        Me.txtGUIManager.Text = "C:\LATIR4\Build\LATIR2GuiManager.dll"
        '
        'Command3
        '
        Me.Command3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command3.Location = New System.Drawing.Point(395, 32)
        Me.Command3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Command3.Name = "Command3"
        Me.Command3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command3.Size = New System.Drawing.Size(32, 30)
        Me.Command3.TabIndex = 2
        Me.Command3.Text = "..."
        '
        'cdlgOpen
        '
        Me.cdlgOpen.DefaultExt = "dll"
        Me.cdlgOpen.Filter = "dll|*.dll"
        Me.cdlgOpen.InitialDirectory = "c:\"
        '
        'Command2
        '
        Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command2.Location = New System.Drawing.Point(333, 215)
        Me.Command2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Command2.Name = "Command2"
        Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command2.Size = New System.Drawing.Size(93, 30)
        Me.Command2.TabIndex = 13
        Me.Command2.Text = "&Cancel"
        '
        'Command1
        '
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(232, 215)
        Me.Command1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(93, 30)
        Me.Command1.TabIndex = 12
        Me.Command1.Text = "&OK"
        '
        'txtPath
        '
        Me.txtPath.AcceptsReturn = True
        Me.txtPath.BackColor = System.Drawing.SystemColors.Window
        Me.txtPath.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPath.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPath.Location = New System.Drawing.Point(11, 32)
        Me.txtPath.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtPath.MaxLength = 0
        Me.txtPath.Name = "txtPath"
        Me.txtPath.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPath.Size = New System.Drawing.Size(376, 22)
        Me.txtPath.TabIndex = 1
        Me.txtPath.Text = "C:\LATIR4\Build\L2Manager.dll"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(11, 162)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(225, 17)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Object Libraries (VB NET Models):"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(11, 112)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(223, 17)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Controls (LATIR2GUIManager.dll):"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(11, 62)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(273, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "GUI Manager Dll (LATIR2GuiManager.dll):"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(11, 11)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(247, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Object manager DLL (L2Manager.dll):"
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Button1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button1.Location = New System.Drawing.Point(395, 183)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button1.Size = New System.Drawing.Size(32, 30)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "..."
        '
        'MaskedTextBox1
        '
        Me.MaskedTextBox1.Location = New System.Drawing.Point(11, 252)
        Me.MaskedTextBox1.Mask = "9999"
        Me.MaskedTextBox1.Name = "MaskedTextBox1"
        Me.MaskedTextBox1.Size = New System.Drawing.Size(376, 22)
        Me.MaskedTextBox1.TabIndex = 14
        Me.MaskedTextBox1.Text = "0012"
        '
        'Form1
        '
        Me.AcceptButton = Me.Command1
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.Command2
        Me.ClientSize = New System.Drawing.Size(433, 323)
        Me.Controls.Add(Me.MaskedTextBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtLevel2)
        Me.Controls.Add(Me.cmdPath3)
        Me.Controls.Add(Me.txtControls)
        Me.Controls.Add(Me.cmdPath2)
        Me.Controls.Add(Me.txtGUIManager)
        Me.Controls.Add(Me.Command3)
        Me.Controls.Add(Me.Command2)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me.txtPath)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(3, 22)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Generator settings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents MaskedTextBox1 As MaskedTextBox
#End Region
End Class