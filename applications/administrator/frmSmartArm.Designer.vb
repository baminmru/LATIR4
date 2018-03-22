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
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.chkbDoNotDeleteAUTO = New System.Windows.Forms.CheckBox()
        Me.chkCreateARM = New System.Windows.Forms.CheckBox()
        Me.cmdSelAll = New System.Windows.Forms.Button()
        Me.cmdClearAll = New System.Windows.Forms.Button()
        Me.lstTypes = New System.Windows.Forms.CheckedListBox()
        Me.cmdStart = New System.Windows.Forms.Button()
        Me.pb = New System.Windows.Forms.ProgressBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkDelOtherView = New System.Windows.Forms.CheckBox()
        Me.chkNoMultiref = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'chkbDoNotDeleteAUTO
        '
        Me.chkbDoNotDeleteAUTO.BackColor = System.Drawing.SystemColors.Control
        Me.chkbDoNotDeleteAUTO.Checked = True
        Me.chkbDoNotDeleteAUTO.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkbDoNotDeleteAUTO.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkbDoNotDeleteAUTO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkbDoNotDeleteAUTO.Location = New System.Drawing.Point(8, 292)
        Me.chkbDoNotDeleteAUTO.Name = "chkbDoNotDeleteAUTO"
        Me.chkbDoNotDeleteAUTO.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkbDoNotDeleteAUTO.Size = New System.Drawing.Size(225, 17)
        Me.chkbDoNotDeleteAUTO.TabIndex = 7
        Me.chkbDoNotDeleteAUTO.Text = "Оставлять АВТО вьхи"
        Me.chkbDoNotDeleteAUTO.UseVisualStyleBackColor = False
        '
        'chkCreateARM
        '
        Me.chkCreateARM.BackColor = System.Drawing.SystemColors.Control
        Me.chkCreateARM.Checked = True
        Me.chkCreateARM.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCreateARM.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkCreateARM.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkCreateARM.Location = New System.Drawing.Point(8, 272)
        Me.chkCreateARM.Name = "chkCreateARM"
        Me.chkCreateARM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkCreateARM.Size = New System.Drawing.Size(225, 17)
        Me.chkCreateARM.TabIndex = 6
        Me.chkCreateARM.Text = "Создавать АРМ"
        Me.chkCreateARM.UseVisualStyleBackColor = False
        '
        'cmdSelAll
        '
        Me.cmdSelAll.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSelAll.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSelAll.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSelAll.Location = New System.Drawing.Point(222, 320)
        Me.cmdSelAll.Name = "cmdSelAll"
        Me.cmdSelAll.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSelAll.Size = New System.Drawing.Size(81, 21)
        Me.cmdSelAll.TabIndex = 2
        Me.cmdSelAll.Text = "Выбрать все"
        Me.cmdSelAll.UseVisualStyleBackColor = False
        '
        'cmdClearAll
        '
        Me.cmdClearAll.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClearAll.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdClearAll.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdClearAll.Location = New System.Drawing.Point(310, 320)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdClearAll.Size = New System.Drawing.Size(81, 21)
        Me.cmdClearAll.TabIndex = 3
        Me.cmdClearAll.Text = "Отменить"
        Me.cmdClearAll.UseVisualStyleBackColor = False
        '
        'lstTypes
        '
        Me.lstTypes.BackColor = System.Drawing.SystemColors.Window
        Me.lstTypes.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstTypes.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstTypes.IntegralHeight = False
        Me.lstTypes.Location = New System.Drawing.Point(2, 0)
        Me.lstTypes.Name = "lstTypes"
        Me.lstTypes.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstTypes.Size = New System.Drawing.Size(391, 260)
        Me.lstTypes.Sorted = True
        Me.lstTypes.TabIndex = 0
        '
        'cmdStart
        '
        Me.cmdStart.BackColor = System.Drawing.SystemColors.Control
        Me.cmdStart.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdStart.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdStart.Location = New System.Drawing.Point(4, 321)
        Me.cmdStart.Name = "cmdStart"
        Me.cmdStart.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdStart.Size = New System.Drawing.Size(79, 21)
        Me.cmdStart.TabIndex = 1
        Me.cmdStart.Text = "Запуск"
        Me.cmdStart.UseVisualStyleBackColor = False
        '
        'pb
        '
        Me.pb.Location = New System.Drawing.Point(2, 350)
        Me.pb.Name = "pb"
        Me.pb.Size = New System.Drawing.Size(388, 20)
        Me.pb.TabIndex = 4
        Me.pb.Visible = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(2, 377)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(390, 32)
        Me.Label1.TabIndex = 5
        Me.Label1.Visible = False
        '
        'chkDelOtherView
        '
        Me.chkDelOtherView.AutoSize = True
        Me.chkDelOtherView.Location = New System.Drawing.Point(222, 292)
        Me.chkDelOtherView.Name = "chkDelOtherView"
        Me.chkDelOtherView.Size = New System.Drawing.Size(132, 17)
        Me.chkDelOtherView.TabIndex = 8
        Me.chkDelOtherView.Text = "Удалять другие View"
        Me.chkDelOtherView.UseVisualStyleBackColor = True
        '
        'chkNoMultiref
        '
        Me.chkNoMultiref.AutoSize = True
        Me.chkNoMultiref.Location = New System.Drawing.Point(223, 268)
        Me.chkNoMultiref.Name = "chkNoMultiref"
        Me.chkNoMultiref.Size = New System.Drawing.Size(115, 17)
        Me.chkNoMultiref.TabIndex = 9
        Me.chkNoMultiref.Text = "Без Multiref полей"
        Me.chkNoMultiref.UseVisualStyleBackColor = True
        '
        'frmSmartArm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(395, 418)
        Me.Controls.Add(Me.chkNoMultiref)
        Me.Controls.Add(Me.chkDelOtherView)
        Me.Controls.Add(Me.chkbDoNotDeleteAUTO)
        Me.Controls.Add(Me.chkCreateARM)
        Me.Controls.Add(Me.cmdSelAll)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.lstTypes)
        Me.Controls.Add(Me.cmdStart)
        Me.Controls.Add(Me.pb)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSmartArm"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.Text = "Скоростная подготовка"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkDelOtherView As System.Windows.Forms.CheckBox
    Friend WithEvents chkNoMultiref As System.Windows.Forms.CheckBox
#End Region 
End Class