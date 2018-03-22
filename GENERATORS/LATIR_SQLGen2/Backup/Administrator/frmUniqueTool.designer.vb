<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmUniqueTool
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
	Public WithEvents txtDesc As System.Windows.Forms.TextBox
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdOK As System.Windows.Forms.Button
	Public WithEvents chkIsGlobal As System.Windows.Forms.CheckBox
	Public WithEvents lstFields As System.Windows.Forms.CheckedListBox
	Public WithEvents txtName As System.Windows.Forms.TextBox
	Public WithEvents txtPart As System.Windows.Forms.TextBox
	Public WithEvents cmdPart As System.Windows.Forms.Button
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtDesc = New System.Windows.Forms.TextBox
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOK = New System.Windows.Forms.Button
        Me.chkIsGlobal = New System.Windows.Forms.CheckBox
        Me.lstFields = New System.Windows.Forms.CheckedListBox
        Me.txtName = New System.Windows.Forms.TextBox
        Me.txtPart = New System.Windows.Forms.TextBox
        Me.cmdPart = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'txtDesc
        '
        Me.txtDesc.AcceptsReturn = True
        Me.txtDesc.BackColor = System.Drawing.SystemColors.Window
        Me.txtDesc.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDesc.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDesc.Location = New System.Drawing.Point(8, 296)
        Me.txtDesc.MaxLength = 0
        Me.txtDesc.Multiline = True
        Me.txtDesc.Name = "txtDesc"
        Me.txtDesc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDesc.Size = New System.Drawing.Size(369, 65)
        Me.txtDesc.TabIndex = 9
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(288, 376)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(89, 25)
        Me.cmdCancel.TabIndex = 8
        Me.cmdCancel.Text = "Закрыть"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOK.Location = New System.Drawing.Point(184, 376)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOK.Size = New System.Drawing.Size(97, 25)
        Me.cmdOK.TabIndex = 7
        Me.cmdOK.Text = "Создать"
        Me.cmdOK.UseVisualStyleBackColor = False
        '
        'chkIsGlobal
        '
        Me.chkIsGlobal.BackColor = System.Drawing.SystemColors.Control
        Me.chkIsGlobal.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkIsGlobal.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkIsGlobal.Location = New System.Drawing.Point(8, 248)
        Me.chkIsGlobal.Name = "chkIsGlobal"
        Me.chkIsGlobal.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkIsGlobal.Size = New System.Drawing.Size(289, 17)
        Me.chkIsGlobal.TabIndex = 6
        Me.chkIsGlobal.Text = "Глобальное ограничение"
        Me.chkIsGlobal.UseVisualStyleBackColor = False
        '
        'lstFields
        '
        Me.lstFields.BackColor = System.Drawing.SystemColors.Window
        Me.lstFields.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstFields.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstFields.Location = New System.Drawing.Point(8, 80)
        Me.lstFields.Name = "lstFields"
        Me.lstFields.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstFields.Size = New System.Drawing.Size(369, 94)
        Me.lstFields.TabIndex = 5
        '
        'txtName
        '
        Me.txtName.AcceptsReturn = True
        Me.txtName.BackColor = System.Drawing.SystemColors.Window
        Me.txtName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtName.Location = New System.Drawing.Point(8, 216)
        Me.txtName.MaxLength = 0
        Me.txtName.Name = "txtName"
        Me.txtName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtName.Size = New System.Drawing.Size(369, 20)
        Me.txtName.TabIndex = 4
        '
        'txtPart
        '
        Me.txtPart.AcceptsReturn = True
        Me.txtPart.BackColor = System.Drawing.SystemColors.Window
        Me.txtPart.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPart.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPart.Location = New System.Drawing.Point(8, 24)
        Me.txtPart.MaxLength = 0
        Me.txtPart.Name = "txtPart"
        Me.txtPart.ReadOnly = True
        Me.txtPart.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPart.Size = New System.Drawing.Size(339, 20)
        Me.txtPart.TabIndex = 1
        '
        'cmdPart
        '
        Me.cmdPart.BackColor = System.Drawing.SystemColors.Control
        Me.cmdPart.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdPart.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdPart.Location = New System.Drawing.Point(344, 24)
        Me.cmdPart.Name = "cmdPart"
        Me.cmdPart.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdPart.Size = New System.Drawing.Size(29, 29)
        Me.cmdPart.TabIndex = 0
        Me.cmdPart.Text = "..."
        Me.cmdPart.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(8, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(169, 25)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Поля раздела"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(8, 272)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(193, 25)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Описание"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(8, 184)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(281, 25)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Название"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(8, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(308, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Раздел для создания уникального сочетания"
        '
        'frmUniqueTool
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(384, 401)
        Me.Controls.Add(Me.txtDesc)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.chkIsGlobal)
        Me.Controls.Add(Me.lstFields)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.txtPart)
        Me.Controls.Add(Me.cmdPart)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUniqueTool"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Создание уникальных сочетаний"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region 
End Class