<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmTypeList
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
	Public WithEvents cmbType As System.Windows.Forms.ListBox
	Public WithEvents CancelButton_Renamed As System.Windows.Forms.Button
	Public WithEvents OKButton As System.Windows.Forms.Button
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTypeList))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmbType = New System.Windows.Forms.ListBox
		Me.CancelButton_Renamed = New System.Windows.Forms.Button
		Me.OKButton = New System.Windows.Forms.Button
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Тип объекта"
		Me.ClientSize = New System.Drawing.Size(398, 220)
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
		Me.Name = "frmTypeList"
		Me.cmbType.Size = New System.Drawing.Size(305, 215)
		Me.cmbType.Location = New System.Drawing.Point(2, 2)
		Me.cmbType.TabIndex = 2
		Me.cmbType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.cmbType.BackColor = System.Drawing.SystemColors.Window
		Me.cmbType.CausesValidation = True
		Me.cmbType.Enabled = True
		Me.cmbType.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbType.IntegralHeight = True
		Me.cmbType.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbType.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me.cmbType.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbType.Sorted = False
		Me.cmbType.TabStop = True
		Me.cmbType.Visible = True
		Me.cmbType.MultiColumn = False
		Me.cmbType.Name = "cmbType"
		Me.CancelButton_Renamed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CancelButton = Me.CancelButton_Renamed
		Me.CancelButton_Renamed.Text = "Отмена"
		Me.CancelButton_Renamed.Size = New System.Drawing.Size(79, 21)
		Me.CancelButton_Renamed.Location = New System.Drawing.Point(312, 34)
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
		Me.AcceptButton = Me.OKButton
		Me.OKButton.Size = New System.Drawing.Size(79, 21)
		Me.OKButton.Location = New System.Drawing.Point(312, 8)
		Me.OKButton.TabIndex = 0
		Me.OKButton.BackColor = System.Drawing.SystemColors.Control
		Me.OKButton.CausesValidation = True
		Me.OKButton.Enabled = True
		Me.OKButton.ForeColor = System.Drawing.SystemColors.ControlText
		Me.OKButton.Cursor = System.Windows.Forms.Cursors.Default
		Me.OKButton.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.OKButton.TabStop = True
		Me.OKButton.Name = "OKButton"
		Me.Controls.Add(cmbType)
		Me.Controls.Add(CancelButton_Renamed)
		Me.Controls.Add(OKButton)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class