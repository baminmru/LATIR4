<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StatusControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    ' <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.cmdChangeSatus = New Infragistics.Win.Misc.UltraButton
        Me.cmbStatus = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.lblStatus = New Infragistics.Win.Misc.UltraLabel
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cmdChangeSatus)
        Me.Panel1.Controls.Add(Me.cmbStatus)
        Me.Panel1.Controls.Add(Me.lblStatus)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(524, 53)
        Me.Panel1.TabIndex = 0
        '
        'cmdChangeSatus
        '
        Me.cmdChangeSatus.Location = New System.Drawing.Point(432, 10)
        Me.cmdChangeSatus.Name = "cmdChangeSatus"
        Me.cmdChangeSatus.Size = New System.Drawing.Size(80, 22)
        Me.cmdChangeSatus.TabIndex = 3
        Me.cmdChangeSatus.Text = "Установить"
        'Me.cmdChangeSatus.UseVisualStyleBackColor = True
        '
        'cmbStatus
        '
        Me.cmbStatus.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        'Me.cmbStatus.FlatStyle = System.Windows.Forms.FlatStyle.System
        'Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Location = New System.Drawing.Point(218, 10)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(204, 22)
        Me.cmbStatus.TabIndex = 2
        '
        'lblStatus
        '
        Me.lblStatus.Location = New System.Drawing.Point(3, 10)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(206, 28)
        Me.lblStatus.TabIndex = 1
        '
        'StatusControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel1)
        Me.Name = "StatusControl"
        Me.Size = New System.Drawing.Size(524, 53)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmdChangeSatus As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmbStatus As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents lblStatus As Infragistics.Win.Misc.UltraLabel

End Class
