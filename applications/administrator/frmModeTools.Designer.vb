<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmModeTools
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
	Public WithEvents cmdSave As System.Windows.Forms.Button
	Public WithEvents cmdAddMode As System.Windows.Forms.Button
	Public WithEvents cmbMode As System.Windows.Forms.ComboBox
	Public WithEvents cmbType As System.Windows.Forms.ComboBox
	Public WithEvents grPart As AxGridEX20.AxGridEX
	Public WithEvents grField As AxGridEX20.AxGridEX
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmModeTools))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdSave = New System.Windows.Forms.Button
		Me.cmdAddMode = New System.Windows.Forms.Button
		Me.cmbMode = New System.Windows.Forms.ComboBox
		Me.cmbType = New System.Windows.Forms.ComboBox
		Me.grPart = New AxGridEX20.AxGridEX
		Me.grField = New AxGridEX20.AxGridEX
		Me.Label4 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.grPart, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.grField, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Настройка режимов "
		Me.ClientSize = New System.Drawing.Size(542, 447)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.Icon = CType(resources.GetObject("frmModeTools.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmModeTools"
		Me.cmdSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdSave.Text = "Сохранить"
		Me.cmdSave.Size = New System.Drawing.Size(79, 21)
		Me.cmdSave.Location = New System.Drawing.Point(456, 418)
		Me.cmdSave.TabIndex = 9
		Me.cmdSave.BackColor = System.Drawing.SystemColors.Control
		Me.cmdSave.CausesValidation = True
		Me.cmdSave.Enabled = True
		Me.cmdSave.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdSave.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdSave.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdSave.TabStop = True
		Me.cmdSave.Name = "cmdSave"
		Me.cmdAddMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAddMode.Text = "+"
		Me.cmdAddMode.Size = New System.Drawing.Size(21, 21)
		Me.cmdAddMode.Location = New System.Drawing.Point(516, 32)
		Me.cmdAddMode.TabIndex = 4
		Me.cmdAddMode.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAddMode.CausesValidation = True
		Me.cmdAddMode.Enabled = True
		Me.cmdAddMode.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAddMode.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAddMode.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAddMode.TabStop = True
		Me.cmdAddMode.Name = "cmdAddMode"
		Me.cmbMode.Size = New System.Drawing.Size(401, 21)
		Me.cmbMode.Location = New System.Drawing.Point(112, 32)
		Me.cmbMode.TabIndex = 3
		Me.cmbMode.Text = "Combo2"
		Me.cmbMode.BackColor = System.Drawing.SystemColors.Window
		Me.cmbMode.CausesValidation = True
		Me.cmbMode.Enabled = True
		Me.cmbMode.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbMode.IntegralHeight = True
		Me.cmbMode.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbMode.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbMode.Sorted = False
		Me.cmbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.cmbMode.TabStop = True
		Me.cmbMode.Visible = True
		Me.cmbMode.Name = "cmbMode"
		Me.cmbType.Size = New System.Drawing.Size(425, 21)
		Me.cmbType.Location = New System.Drawing.Point(112, 6)
		Me.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbType.TabIndex = 1
		Me.cmbType.BackColor = System.Drawing.SystemColors.Window
		Me.cmbType.CausesValidation = True
		Me.cmbType.Enabled = True
		Me.cmbType.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbType.IntegralHeight = True
		Me.cmbType.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbType.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbType.Sorted = False
		Me.cmbType.TabStop = True
		Me.cmbType.Visible = True
		Me.cmbType.Name = "cmbType"
		grPart.OcxState = CType(resources.GetObject("grPart.OcxState"), System.Windows.Forms.AxHost.State)
		Me.grPart.Size = New System.Drawing.Size(529, 150)
		Me.grPart.Location = New System.Drawing.Point(8, 84)
		Me.grPart.TabIndex = 6
		Me.grPart.Name = "grPart"
		grField.OcxState = CType(resources.GetObject("grField.OcxState"), System.Windows.Forms.AxHost.State)
		Me.grField.Size = New System.Drawing.Size(529, 150)
		Me.grField.Location = New System.Drawing.Point(8, 262)
		Me.grField.TabIndex = 8
		Me.grField.Name = "grField"
		Me.Label4.Text = "Ограничение полей"
		Me.Label4.Size = New System.Drawing.Size(257, 17)
		Me.Label4.Location = New System.Drawing.Point(8, 242)
		Me.Label4.TabIndex = 7
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label4.BackColor = System.Drawing.SystemColors.Control
		Me.Label4.Enabled = True
		Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label4.UseMnemonic = True
		Me.Label4.Visible = True
		Me.Label4.AutoSize = False
		Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label4.Name = "Label4"
		Me.Label3.Text = "Ограничения разделов"
		Me.Label3.Size = New System.Drawing.Size(345, 17)
		Me.Label3.Location = New System.Drawing.Point(8, 64)
		Me.Label3.TabIndex = 5
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
		Me.Label2.Text = "Режим"
		Me.Label2.Size = New System.Drawing.Size(97, 17)
		Me.Label2.Location = New System.Drawing.Point(8, 32)
		Me.Label2.TabIndex = 2
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
		Me.Label1.Text = "Тип документа:"
		Me.Label1.Size = New System.Drawing.Size(97, 17)
		Me.Label1.Location = New System.Drawing.Point(8, 6)
		Me.Label1.TabIndex = 0
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
		Me.Controls.Add(cmdSave)
		Me.Controls.Add(cmdAddMode)
		Me.Controls.Add(cmbMode)
		Me.Controls.Add(cmbType)
		Me.Controls.Add(grPart)
		Me.Controls.Add(grField)
		Me.Controls.Add(Label4)
		Me.Controls.Add(Label3)
		Me.Controls.Add(Label2)
		Me.Controls.Add(Label1)
		CType(Me.grField, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.grPart, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class