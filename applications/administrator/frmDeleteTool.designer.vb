<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmDeleteTool
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
	Public WithEvents cmdUnselAll As System.Windows.Forms.Button
	Public WithEvents cmdSelAll As System.Windows.Forms.Button
	Public WithEvents cmdKill As System.Windows.Forms.Button
    Public WithEvents lstObj As System.Windows.Forms.CheckedListBox
	Public WithEvents cmbType As System.Windows.Forms.ComboBox
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDeleteTool))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdUnselAll = New System.Windows.Forms.Button()
        Me.cmdSelAll = New System.Windows.Forms.Button()
        Me.cmdKill = New System.Windows.Forms.Button()
        Me.lstObj = New System.Windows.Forms.CheckedListBox()
        Me.cmbType = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmdUnselAll
        '
        Me.cmdUnselAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdUnselAll.BackColor = System.Drawing.SystemColors.Control
        Me.cmdUnselAll.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdUnselAll.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdUnselAll.Location = New System.Drawing.Point(116, 384)
        Me.cmdUnselAll.Name = "cmdUnselAll"
        Me.cmdUnselAll.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdUnselAll.Size = New System.Drawing.Size(104, 21)
        Me.cmdUnselAll.TabIndex = 6
        Me.cmdUnselAll.Text = "Отменить все"
        Me.cmdUnselAll.UseVisualStyleBackColor = False
        '
        'cmdSelAll
        '
        Me.cmdSelAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdSelAll.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSelAll.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSelAll.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSelAll.Location = New System.Drawing.Point(8, 384)
        Me.cmdSelAll.Name = "cmdSelAll"
        Me.cmdSelAll.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSelAll.Size = New System.Drawing.Size(104, 21)
        Me.cmdSelAll.TabIndex = 5
        Me.cmdSelAll.Text = "Выделить все"
        Me.cmdSelAll.UseVisualStyleBackColor = False
        '
        'cmdKill
        '
        Me.cmdKill.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdKill.BackColor = System.Drawing.SystemColors.Control
        Me.cmdKill.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdKill.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdKill.Location = New System.Drawing.Point(372, 384)
        Me.cmdKill.Name = "cmdKill"
        Me.cmdKill.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdKill.Size = New System.Drawing.Size(79, 21)
        Me.cmdKill.TabIndex = 3
        Me.cmdKill.Text = "Удалить"
        Me.cmdKill.UseVisualStyleBackColor = False
        '
        'lstObj
        '
        Me.lstObj.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstObj.BackColor = System.Drawing.SystemColors.Window
        Me.lstObj.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstObj.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstObj.Location = New System.Drawing.Point(8, 56)
        Me.lstObj.Name = "lstObj"
        Me.lstObj.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstObj.Size = New System.Drawing.Size(449, 319)
        Me.lstObj.Sorted = True
        Me.lstObj.TabIndex = 1
        '
        'cmbType
        '
        Me.cmbType.BackColor = System.Drawing.SystemColors.Window
        Me.cmbType.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbType.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbType.Location = New System.Drawing.Point(8, 24)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbType.Size = New System.Drawing.Size(449, 21)
        Me.cmbType.Sorted = True
        Me.cmbType.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(8, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(225, 25)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Тип документа"
        '
        'frmDeleteTool
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(461, 414)
        Me.Controls.Add(Me.cmdUnselAll)
        Me.Controls.Add(Me.cmdSelAll)
        Me.Controls.Add(Me.cmdKill)
        Me.Controls.Add(Me.lstObj)
        Me.Controls.Add(Me.cmbType)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDeleteTool"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Удаление документов"
        Me.ResumeLayout(False)

    End Sub
#End Region
End Class