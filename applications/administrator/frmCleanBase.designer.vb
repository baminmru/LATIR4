<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmCleanBaseTool
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
	Public WithEvents chkNoExec As System.Windows.Forms.CheckBox
	Public WithEvents txtLog As LATIR2GuiManager.TouchTextBox
	Public WithEvents cmdCleanBase As System.Windows.Forms.Button
	Public WithEvents lstTypes As System.Windows.Forms.CheckedListBox
	Public WithEvents cmdSelAll As System.Windows.Forms.Button
	Public WithEvents cmdClearAll As System.Windows.Forms.Button
	Public WithEvents Label4 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.chkNoExec = New System.Windows.Forms.CheckBox()
        Me.txtLog = New LATIR2GuiManager.TouchTextBox()
        Me.cmdCleanBase = New System.Windows.Forms.Button()
        Me.lstTypes = New System.Windows.Forms.CheckedListBox()
        Me.cmdSelAll = New System.Windows.Forms.Button()
        Me.cmdClearAll = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'chkNoExec
        '
        Me.chkNoExec.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkNoExec.BackColor = System.Drawing.SystemColors.Control
        Me.chkNoExec.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkNoExec.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkNoExec.Location = New System.Drawing.Point(8, 368)
        Me.chkNoExec.Name = "chkNoExec"
        Me.chkNoExec.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkNoExec.Size = New System.Drawing.Size(137, 25)
        Me.chkNoExec.TabIndex = 6
        Me.chkNoExec.Text = "Не исполнять скрипт"
        Me.chkNoExec.UseVisualStyleBackColor = False
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
        Me.txtLog.Location = New System.Drawing.Point(8, 232)
        Me.txtLog.MaxLength = 0
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtLog.Size = New System.Drawing.Size(385, 129)
        Me.txtLog.TabIndex = 5
        '
        'cmdCleanBase
        '
        Me.cmdCleanBase.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCleanBase.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCleanBase.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCleanBase.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCleanBase.Location = New System.Drawing.Point(224, 368)
        Me.cmdCleanBase.Name = "cmdCleanBase"
        Me.cmdCleanBase.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCleanBase.Size = New System.Drawing.Size(169, 25)
        Me.cmdCleanBase.TabIndex = 4
        Me.cmdCleanBase.Text = "Очистить базу"
        Me.cmdCleanBase.UseVisualStyleBackColor = False
        '
        'lstTypes
        '
        Me.lstTypes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstTypes.BackColor = System.Drawing.SystemColors.Window
        Me.lstTypes.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstTypes.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstTypes.IntegralHeight = False
        Me.lstTypes.Location = New System.Drawing.Point(0, 24)
        Me.lstTypes.Name = "lstTypes"
        Me.lstTypes.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstTypes.Size = New System.Drawing.Size(391, 179)
        Me.lstTypes.Sorted = True
        Me.lstTypes.TabIndex = 2
        '
        'cmdSelAll
        '
        Me.cmdSelAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSelAll.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSelAll.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSelAll.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSelAll.Location = New System.Drawing.Point(224, 208)
        Me.cmdSelAll.Name = "cmdSelAll"
        Me.cmdSelAll.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSelAll.Size = New System.Drawing.Size(81, 21)
        Me.cmdSelAll.TabIndex = 1
        Me.cmdSelAll.Text = "Выбрать все"
        Me.cmdSelAll.UseVisualStyleBackColor = False
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearAll.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClearAll.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdClearAll.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdClearAll.Location = New System.Drawing.Point(312, 208)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdClearAll.Size = New System.Drawing.Size(81, 21)
        Me.cmdClearAll.TabIndex = 0
        Me.cmdClearAll.Text = "Отменить"
        Me.cmdClearAll.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(0, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(101, 17)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Типы документов для очистки"
        '
        'frmCleanBaseTool
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(397, 403)
        Me.Controls.Add(Me.chkNoExec)
        Me.Controls.Add(Me.txtLog)
        Me.Controls.Add(Me.cmdCleanBase)
        Me.Controls.Add(Me.lstTypes)
        Me.Controls.Add(Me.cmdSelAll)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.Label4)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(4, 23)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCleanBaseTool"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Очистка базы данных"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region
End Class