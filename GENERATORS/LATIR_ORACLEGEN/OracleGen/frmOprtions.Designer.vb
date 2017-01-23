<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmOptions
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
	Public WithEvents chkMethods As System.Windows.Forms.CheckBox
	Public WithEvents chkProcs As System.Windows.Forms.CheckBox
	Public WithEvents chkInit As System.Windows.Forms.CheckBox
	Public WithEvents chkView As System.Windows.Forms.CheckBox
	Public WithEvents chkKernel As System.Windows.Forms.CheckBox
	Public WithEvents chkTables As System.Windows.Forms.CheckBox
	Public WithEvents CancelButton_Renamed As System.Windows.Forms.Button
	Public WithEvents OKButton As System.Windows.Forms.Button
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.chkMethods = New System.Windows.Forms.CheckBox()
        Me.chkProcs = New System.Windows.Forms.CheckBox()
        Me.chkInit = New System.Windows.Forms.CheckBox()
        Me.chkView = New System.Windows.Forms.CheckBox()
        Me.chkKernel = New System.Windows.Forms.CheckBox()
        Me.chkTables = New System.Windows.Forms.CheckBox()
        Me.CancelButton_Renamed = New System.Windows.Forms.Button()
        Me.OKButton = New System.Windows.Forms.Button()
        Me.txtSchema = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'chkMethods
        '
        Me.chkMethods.BackColor = System.Drawing.SystemColors.Control
        Me.chkMethods.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkMethods.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkMethods.Location = New System.Drawing.Point(18, 157)
        Me.chkMethods.Name = "chkMethods"
        Me.chkMethods.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkMethods.Size = New System.Drawing.Size(244, 20)
        Me.chkMethods.TabIndex = 7
        Me.chkMethods.Text = "Методы"
        Me.chkMethods.UseVisualStyleBackColor = False
        '
        'chkProcs
        '
        Me.chkProcs.BackColor = System.Drawing.SystemColors.Control
        Me.chkProcs.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkProcs.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkProcs.Location = New System.Drawing.Point(18, 128)
        Me.chkProcs.Name = "chkProcs"
        Me.chkProcs.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkProcs.Size = New System.Drawing.Size(244, 20)
        Me.chkProcs.TabIndex = 6
        Me.chkProcs.Text = "Процедуры"
        Me.chkProcs.UseVisualStyleBackColor = False
        '
        'chkInit
        '
        Me.chkInit.BackColor = System.Drawing.SystemColors.Control
        Me.chkInit.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkInit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkInit.Location = New System.Drawing.Point(18, 98)
        Me.chkInit.Name = "chkInit"
        Me.chkInit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkInit.Size = New System.Drawing.Size(244, 20)
        Me.chkInit.TabIndex = 5
        Me.chkInit.Text = "Инициализация базы"
        Me.chkInit.UseVisualStyleBackColor = False
        '
        'chkView
        '
        Me.chkView.BackColor = System.Drawing.SystemColors.Control
        Me.chkView.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkView.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkView.Location = New System.Drawing.Point(18, 39)
        Me.chkView.Name = "chkView"
        Me.chkView.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkView.Size = New System.Drawing.Size(244, 20)
        Me.chkView.TabIndex = 4
        Me.chkView.Text = "Запросы (View)"
        Me.chkView.UseVisualStyleBackColor = False
        '
        'chkKernel
        '
        Me.chkKernel.BackColor = System.Drawing.SystemColors.Control
        Me.chkKernel.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkKernel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkKernel.Location = New System.Drawing.Point(18, 69)
        Me.chkKernel.Name = "chkKernel"
        Me.chkKernel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkKernel.Size = New System.Drawing.Size(244, 20)
        Me.chkKernel.TabIndex = 3
        Me.chkKernel.Text = "Ядро"
        Me.chkKernel.UseVisualStyleBackColor = False
        '
        'chkTables
        '
        Me.chkTables.BackColor = System.Drawing.SystemColors.Control
        Me.chkTables.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkTables.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkTables.Location = New System.Drawing.Point(18, 9)
        Me.chkTables.Name = "chkTables"
        Me.chkTables.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkTables.Size = New System.Drawing.Size(244, 20)
        Me.chkTables.TabIndex = 2
        Me.chkTables.Text = "Структура таблиц"
        Me.chkTables.UseVisualStyleBackColor = False
        '
        'CancelButton_Renamed
        '
        Me.CancelButton_Renamed.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton_Renamed.Cursor = System.Windows.Forms.Cursors.Default
        Me.CancelButton_Renamed.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CancelButton_Renamed.Location = New System.Drawing.Point(271, 40)
        Me.CancelButton_Renamed.Name = "CancelButton_Renamed"
        Me.CancelButton_Renamed.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CancelButton_Renamed.Size = New System.Drawing.Size(81, 25)
        Me.CancelButton_Renamed.TabIndex = 1
        Me.CancelButton_Renamed.Text = "Cancel"
        Me.CancelButton_Renamed.UseVisualStyleBackColor = False
        '
        'OKButton
        '
        Me.OKButton.BackColor = System.Drawing.SystemColors.Control
        Me.OKButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.OKButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.OKButton.Location = New System.Drawing.Point(271, 9)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.OKButton.Size = New System.Drawing.Size(81, 25)
        Me.OKButton.TabIndex = 0
        Me.OKButton.Text = "OK"
        Me.OKButton.UseVisualStyleBackColor = False
        '
        'txtSchema
        '
        Me.txtSchema.Location = New System.Drawing.Point(126, 194)
        Me.txtSchema.Name = "txtSchema"
        Me.txtSchema.Size = New System.Drawing.Size(183, 20)
        Me.txtSchema.TabIndex = 8
        Me.txtSchema.Text = "LATIR4"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 197)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Название схемы"
        '
        'frmOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(361, 227)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtSchema)
        Me.Controls.Add(Me.chkMethods)
        Me.Controls.Add(Me.chkProcs)
        Me.Controls.Add(Me.chkInit)
        Me.Controls.Add(Me.chkView)
        Me.Controls.Add(Me.chkKernel)
        Me.Controls.Add(Me.chkTables)
        Me.Controls.Add(Me.CancelButton_Renamed)
        Me.Controls.Add(Me.OKButton)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(184, 250)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOptions"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Параметры генерации"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtSchema As Windows.Forms.TextBox
    Friend WithEvents Label1 As Windows.Forms.Label
#End Region
End Class