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
	Public WithEvents chkMaintein As System.Windows.Forms.CheckBox
	Public WithEvents chkManual As System.Windows.Forms.CheckBox
	Public WithEvents chkMethods As System.Windows.Forms.CheckBox
	Public WithEvents chkProcs As System.Windows.Forms.CheckBox
	Public WithEvents chkInit As System.Windows.Forms.CheckBox
	Public WithEvents chkView As System.Windows.Forms.CheckBox
	Public WithEvents chkFullText As System.Windows.Forms.CheckBox
	Public WithEvents chkKernel As System.Windows.Forms.CheckBox
	Public WithEvents chkTables As System.Windows.Forms.CheckBox
	Public WithEvents CancelButton_Renamed As System.Windows.Forms.Button
	Public WithEvents OKButton As System.Windows.Forms.Button
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOptions))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.chkMaintein = New System.Windows.Forms.CheckBox
        Me.chkManual = New System.Windows.Forms.CheckBox
        Me.chkMethods = New System.Windows.Forms.CheckBox
        Me.chkProcs = New System.Windows.Forms.CheckBox
        Me.chkInit = New System.Windows.Forms.CheckBox
        Me.chkView = New System.Windows.Forms.CheckBox
        Me.chkFullText = New System.Windows.Forms.CheckBox
        Me.chkKernel = New System.Windows.Forms.CheckBox
        Me.chkTables = New System.Windows.Forms.CheckBox
        Me.CancelButton_Renamed = New System.Windows.Forms.Button
        Me.OKButton = New System.Windows.Forms.Button
        Me.chkLite = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'chkMaintein
        '
        Me.chkMaintein.AutoSize = True
        Me.chkMaintein.BackColor = System.Drawing.SystemColors.Control
        Me.chkMaintein.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkMaintein.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkMaintein.Location = New System.Drawing.Point(125, 97)
        Me.chkMaintein.Name = "chkMaintein"
        Me.chkMaintein.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkMaintein.Size = New System.Drawing.Size(105, 17)
        Me.chkMaintein.TabIndex = 8
        Me.chkMaintein.Text = "Scheduled tasks"
        Me.chkMaintein.UseVisualStyleBackColor = False
        '
        'chkManual
        '
        Me.chkManual.AutoSize = True
        Me.chkManual.BackColor = System.Drawing.SystemColors.Control
        Me.chkManual.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkManual.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkManual.Location = New System.Drawing.Point(125, 67)
        Me.chkManual.Name = "chkManual"
        Me.chkManual.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkManual.Size = New System.Drawing.Size(88, 17)
        Me.chkManual.TabIndex = 7
        Me.chkManual.Text = "Manual code"
        Me.chkManual.UseVisualStyleBackColor = False
        '
        'chkMethods
        '
        Me.chkMethods.AutoSize = True
        Me.chkMethods.BackColor = System.Drawing.SystemColors.Control
        Me.chkMethods.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkMethods.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkMethods.Location = New System.Drawing.Point(125, 38)
        Me.chkMethods.Name = "chkMethods"
        Me.chkMethods.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkMethods.Size = New System.Drawing.Size(67, 17)
        Me.chkMethods.TabIndex = 6
        Me.chkMethods.Text = "Methods"
        Me.chkMethods.UseVisualStyleBackColor = False
        '
        'chkProcs
        '
        Me.chkProcs.AutoSize = True
        Me.chkProcs.BackColor = System.Drawing.SystemColors.Control
        Me.chkProcs.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkProcs.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkProcs.Location = New System.Drawing.Point(125, 9)
        Me.chkProcs.Name = "chkProcs"
        Me.chkProcs.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkProcs.Size = New System.Drawing.Size(80, 17)
        Me.chkProcs.TabIndex = 5
        Me.chkProcs.Text = "Procedures"
        Me.chkProcs.UseVisualStyleBackColor = False
        '
        'chkInit
        '
        Me.chkInit.AutoSize = True
        Me.chkInit.BackColor = System.Drawing.SystemColors.Control
        Me.chkInit.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkInit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkInit.Location = New System.Drawing.Point(12, 125)
        Me.chkInit.Name = "chkInit"
        Me.chkInit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkInit.Size = New System.Drawing.Size(88, 17)
        Me.chkInit.TabIndex = 4
        Me.chkInit.Text = "Database init"
        Me.chkInit.UseVisualStyleBackColor = False
        '
        'chkView
        '
        Me.chkView.AutoSize = True
        Me.chkView.BackColor = System.Drawing.SystemColors.Control
        Me.chkView.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkView.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkView.Location = New System.Drawing.Point(12, 96)
        Me.chkView.Name = "chkView"
        Me.chkView.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkView.Size = New System.Drawing.Size(94, 17)
        Me.chkView.TabIndex = 3
        Me.chkView.Text = "Queries (View)"
        Me.chkView.UseVisualStyleBackColor = False
        '
        'chkFullText
        '
        Me.chkFullText.AutoSize = True
        Me.chkFullText.BackColor = System.Drawing.SystemColors.Control
        Me.chkFullText.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkFullText.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkFullText.Location = New System.Drawing.Point(12, 67)
        Me.chkFullText.Name = "chkFullText"
        Me.chkFullText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkFullText.Size = New System.Drawing.Size(94, 17)
        Me.chkFullText.TabIndex = 2
        Me.chkFullText.Text = "Fulltext search"
        Me.chkFullText.UseVisualStyleBackColor = False
        '
        'chkKernel
        '
        Me.chkKernel.AutoSize = True
        Me.chkKernel.BackColor = System.Drawing.SystemColors.Control
        Me.chkKernel.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkKernel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkKernel.Location = New System.Drawing.Point(12, 38)
        Me.chkKernel.Name = "chkKernel"
        Me.chkKernel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkKernel.Size = New System.Drawing.Size(51, 17)
        Me.chkKernel.TabIndex = 1
        Me.chkKernel.Text = "Core "
        Me.chkKernel.UseVisualStyleBackColor = False
        '
        'chkTables
        '
        Me.chkTables.AutoSize = True
        Me.chkTables.BackColor = System.Drawing.SystemColors.Control
        Me.chkTables.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkTables.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkTables.Location = New System.Drawing.Point(12, 9)
        Me.chkTables.Name = "chkTables"
        Me.chkTables.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkTables.Size = New System.Drawing.Size(102, 17)
        Me.chkTables.TabIndex = 0
        Me.chkTables.Text = "Tables structure"
        Me.chkTables.UseVisualStyleBackColor = False
        '
        'CancelButton_Renamed
        '
        Me.CancelButton_Renamed.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton_Renamed.Cursor = System.Windows.Forms.Cursors.Default
        Me.CancelButton_Renamed.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CancelButton_Renamed.Location = New System.Drawing.Point(159, 163)
        Me.CancelButton_Renamed.Name = "CancelButton_Renamed"
        Me.CancelButton_Renamed.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CancelButton_Renamed.Size = New System.Drawing.Size(70, 24)
        Me.CancelButton_Renamed.TabIndex = 10
        Me.CancelButton_Renamed.Text = "&Cancel"
        Me.CancelButton_Renamed.UseVisualStyleBackColor = False
        '
        'OKButton
        '
        Me.OKButton.BackColor = System.Drawing.SystemColors.Control
        Me.OKButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.OKButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.OKButton.Location = New System.Drawing.Point(83, 163)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.OKButton.Size = New System.Drawing.Size(70, 24)
        Me.OKButton.TabIndex = 9
        Me.OKButton.Text = "&OK"
        Me.OKButton.UseVisualStyleBackColor = False
        '
        'chkLite
        '
        Me.chkLite.AutoSize = True
        Me.chkLite.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.chkLite.Location = New System.Drawing.Point(125, 130)
        Me.chkLite.Name = "chkLite"
        Me.chkLite.Size = New System.Drawing.Size(116, 19)
        Me.chkLite.TabIndex = 11
        Me.chkLite.Text = "LITE MODE !!!"
        Me.chkLite.UseVisualStyleBackColor = True
        '
        'frmOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(242, 190)
        Me.Controls.Add(Me.chkLite)
        Me.Controls.Add(Me.chkMaintein)
        Me.Controls.Add(Me.chkManual)
        Me.Controls.Add(Me.chkMethods)
        Me.Controls.Add(Me.chkProcs)
        Me.Controls.Add(Me.chkInit)
        Me.Controls.Add(Me.chkView)
        Me.Controls.Add(Me.chkFullText)
        Me.Controls.Add(Me.chkKernel)
        Me.Controls.Add(Me.chkTables)
        Me.Controls.Add(Me.CancelButton_Renamed)
        Me.Controls.Add(Me.OKButton)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(184, 250)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOptions"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Generator settings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkLite As System.Windows.Forms.CheckBox
#End Region 
End Class