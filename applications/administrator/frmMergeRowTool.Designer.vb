<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmMergeRowTool
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
	Public WithEvents Command1 As System.Windows.Forms.Button
	Public WithEvents cmdPart As System.Windows.Forms.Button
	Public WithEvents txtPart As LATIR2GuiManager.TouchTextBox
	Public WithEvents txtOut As System.Windows.Forms.RichTextBox
	Public WithEvents cmdGo As System.Windows.Forms.Button
	Public WithEvents pb As System.Windows.Forms.ProgressBar
	Public WithEvents cmdNewDoc As System.Windows.Forms.Button
	Public WithEvents txtNewDoc As LATIR2GuiManager.TouchTextBox
	Public WithEvents chkDel As System.Windows.Forms.CheckBox
	Public WithEvents cmdDocToDel As System.Windows.Forms.Button
	Public WithEvents txtDocToDel As LATIR2GuiManager.TouchTextBox
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMergeRowTool))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.Command1 = New System.Windows.Forms.Button
		Me.cmdPart = New System.Windows.Forms.Button
		Me.txtPart = New LATIR2GuiManager.TouchTextBox
		Me.txtOut = New System.Windows.Forms.RichTextBox
		Me.cmdGo = New System.Windows.Forms.Button
		Me.pb = New System.Windows.Forms.ProgressBar
		Me.cmdNewDoc = New System.Windows.Forms.Button
		Me.txtNewDoc = New LATIR2GuiManager.TouchTextBox
		Me.chkDel = New System.Windows.Forms.CheckBox
		Me.cmdDocToDel = New System.Windows.Forms.Button
		Me.txtDocToDel = New LATIR2GuiManager.TouchTextBox
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "����������� � �������� ����� ������"
		Me.ClientSize = New System.Drawing.Size(298, 295)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmMergeRowTool"
		Me.Command1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CancelButton = Me.Command1
		Me.Command1.Text = "������"
		Me.Command1.Size = New System.Drawing.Size(79, 21)
		Me.Command1.Location = New System.Drawing.Point(214, 268)
		Me.Command1.TabIndex = 13
		Me.Command1.BackColor = System.Drawing.SystemColors.Control
		Me.Command1.CausesValidation = True
		Me.Command1.Enabled = True
		Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command1.TabStop = True
		Me.Command1.Name = "Command1"
		Me.cmdPart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPart.Text = "..."
		Me.cmdPart.Size = New System.Drawing.Size(21, 21)
		Me.cmdPart.Location = New System.Drawing.Point(272, 28)
		Me.cmdPart.TabIndex = 2
		Me.cmdPart.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPart.CausesValidation = True
		Me.cmdPart.Enabled = True
		Me.cmdPart.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPart.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPart.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPart.TabStop = True
		Me.cmdPart.Name = "cmdPart"
		Me.txtPart.AutoSize = False
		Me.txtPart.Size = New System.Drawing.Size(267, 20)
		Me.txtPart.Location = New System.Drawing.Point(2, 27)
		Me.txtPart.ReadOnly = True
		Me.txtPart.TabIndex = 1
		Me.txtPart.AcceptsReturn = True
		Me.txtPart.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtPart.BackColor = System.Drawing.SystemColors.Window
		Me.txtPart.CausesValidation = True
		Me.txtPart.Enabled = True
		Me.txtPart.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtPart.HideSelection = True
		Me.txtPart.Maxlength = 0
		Me.txtPart.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtPart.MultiLine = False
		Me.txtPart.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtPart.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtPart.TabStop = True
		Me.txtPart.Visible = True
		Me.txtPart.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtPart.Name = "txtPart"
		Me.txtOut.Size = New System.Drawing.Size(290, 105)
		Me.txtOut.Location = New System.Drawing.Point(2, 158)
		Me.txtOut.TabIndex = 10
		Me.txtOut.Visible = False
		Me.txtOut.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
		Me.txtOut.RTF = resources.GetString("txtOut.TextRTF")
		Me.txtOut.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtOut.Name = "txtOut"
		Me.cmdGo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdGo.Text = "����"
		Me.cmdGo.Size = New System.Drawing.Size(79, 21)
		Me.cmdGo.Location = New System.Drawing.Point(4, 268)
		Me.cmdGo.TabIndex = 11
		Me.cmdGo.BackColor = System.Drawing.SystemColors.Control
		Me.cmdGo.CausesValidation = True
		Me.cmdGo.Enabled = True
		Me.cmdGo.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdGo.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdGo.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdGo.TabStop = True
		Me.cmdGo.Name = "cmdGo"
		Me.pb.Size = New System.Drawing.Size(209, 20)
		Me.pb.Location = New System.Drawing.Point(84, 268)
		Me.pb.TabIndex = 12
		Me.pb.Visible = False
		Me.pb.Name = "pb"
		Me.cmdNewDoc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdNewDoc.Text = "..."
		Me.cmdNewDoc.Size = New System.Drawing.Size(21, 21)
		Me.cmdNewDoc.Location = New System.Drawing.Point(272, 114)
		Me.cmdNewDoc.TabIndex = 8
		Me.cmdNewDoc.BackColor = System.Drawing.SystemColors.Control
		Me.cmdNewDoc.CausesValidation = True
		Me.cmdNewDoc.Enabled = True
		Me.cmdNewDoc.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdNewDoc.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdNewDoc.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdNewDoc.TabStop = True
		Me.cmdNewDoc.Name = "cmdNewDoc"
		Me.txtNewDoc.AutoSize = False
		Me.txtNewDoc.Size = New System.Drawing.Size(267, 20)
		Me.txtNewDoc.Location = New System.Drawing.Point(2, 113)
		Me.txtNewDoc.ReadOnly = True
		Me.txtNewDoc.TabIndex = 7
		Me.txtNewDoc.AcceptsReturn = True
		Me.txtNewDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtNewDoc.BackColor = System.Drawing.SystemColors.Window
		Me.txtNewDoc.CausesValidation = True
		Me.txtNewDoc.Enabled = True
		Me.txtNewDoc.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtNewDoc.HideSelection = True
		Me.txtNewDoc.Maxlength = 0
		Me.txtNewDoc.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtNewDoc.MultiLine = False
		Me.txtNewDoc.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtNewDoc.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtNewDoc.TabStop = True
		Me.txtNewDoc.Visible = True
		Me.txtNewDoc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtNewDoc.Name = "txtNewDoc"
		Me.chkDel.Text = "������� ����� ������"
		Me.chkDel.Size = New System.Drawing.Size(179, 19)
		Me.chkDel.Location = New System.Drawing.Point(4, 136)
		Me.chkDel.TabIndex = 9
		Me.chkDel.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkDel.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkDel.BackColor = System.Drawing.SystemColors.Control
		Me.chkDel.CausesValidation = True
		Me.chkDel.Enabled = True
		Me.chkDel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkDel.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkDel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkDel.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkDel.TabStop = True
		Me.chkDel.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkDel.Visible = True
		Me.chkDel.Name = "chkDel"
		Me.cmdDocToDel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdDocToDel.Text = "..."
		Me.cmdDocToDel.Size = New System.Drawing.Size(21, 21)
		Me.cmdDocToDel.Location = New System.Drawing.Point(270, 70)
		Me.cmdDocToDel.TabIndex = 5
		Me.cmdDocToDel.BackColor = System.Drawing.SystemColors.Control
		Me.cmdDocToDel.CausesValidation = True
		Me.cmdDocToDel.Enabled = True
		Me.cmdDocToDel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdDocToDel.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdDocToDel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdDocToDel.TabStop = True
		Me.cmdDocToDel.Name = "cmdDocToDel"
		Me.txtDocToDel.AutoSize = False
		Me.txtDocToDel.Size = New System.Drawing.Size(267, 20)
		Me.txtDocToDel.Location = New System.Drawing.Point(2, 70)
		Me.txtDocToDel.ReadOnly = True
		Me.txtDocToDel.TabIndex = 4
		Me.txtDocToDel.AcceptsReturn = True
		Me.txtDocToDel.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtDocToDel.BackColor = System.Drawing.SystemColors.Window
		Me.txtDocToDel.CausesValidation = True
		Me.txtDocToDel.Enabled = True
		Me.txtDocToDel.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtDocToDel.HideSelection = True
		Me.txtDocToDel.Maxlength = 0
		Me.txtDocToDel.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtDocToDel.MultiLine = False
		Me.txtDocToDel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtDocToDel.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtDocToDel.TabStop = True
		Me.txtDocToDel.Visible = True
		Me.txtDocToDel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtDocToDel.Name = "txtDocToDel"
		Me.Label3.Text = "������ ��� ������ ������"
		Me.Label3.Size = New System.Drawing.Size(212, 20)
		Me.Label3.Location = New System.Drawing.Point(2, 3)
		Me.Label3.TabIndex = 0
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
		Me.Label2.Text = "���������� ������"
		Me.Label2.Size = New System.Drawing.Size(267, 20)
		Me.Label2.Location = New System.Drawing.Point(2, 92)
		Me.Label2.TabIndex = 6
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
		Me.Label1.Text = "������, ������� ���� �������� (� �������)"
		Me.Label1.Size = New System.Drawing.Size(246, 20)
		Me.Label1.Location = New System.Drawing.Point(2, 49)
		Me.Label1.TabIndex = 3
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
		Me.Controls.Add(Command1)
		Me.Controls.Add(cmdPart)
		Me.Controls.Add(txtPart)
		Me.Controls.Add(txtOut)
		Me.Controls.Add(cmdGo)
		Me.Controls.Add(pb)
		Me.Controls.Add(cmdNewDoc)
		Me.Controls.Add(txtNewDoc)
		Me.Controls.Add(chkDel)
		Me.Controls.Add(cmdDocToDel)
		Me.Controls.Add(txtDocToDel)
		Me.Controls.Add(Label3)
		Me.Controls.Add(Label2)
		Me.Controls.Add(Label1)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class