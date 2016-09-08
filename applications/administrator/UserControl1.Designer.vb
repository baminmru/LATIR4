<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControl1
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.AutoPanel1 = New LATIRGUIControls.AutoPanel
        Me.UltraButton1 = New Infragistics.Win.Misc.UltraButton
        Me.UltraFormattedLinkLabel1 = New Infragistics.Win.FormattedLinkLabel.UltraFormattedLinkLabel
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.AutoPanel1.SuspendLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AutoPanel1
        '
        Me.AutoPanel1.AllowDrop = True
        Me.AutoPanel1.BackColor = System.Drawing.SystemColors.Control
        Me.AutoPanel1.Controls.Add(Me.UltraGroupBox1)
        Me.AutoPanel1.Controls.Add(Me.UltraFormattedLinkLabel1)
        Me.AutoPanel1.Controls.Add(Me.UltraButton1)
        Me.AutoPanel1.Location = New System.Drawing.Point(23, 17)
        Me.AutoPanel1.Name = "AutoPanel1"
        Me.AutoPanel1.Size = New System.Drawing.Size(452, 348)
        Me.AutoPanel1.TabIndex = 0
        '
        'UltraButton1
        '
        Me.UltraButton1.Location = New System.Drawing.Point(29, 25)
        Me.UltraButton1.Name = "UltraButton1"
        Me.UltraButton1.Size = New System.Drawing.Size(210, 84)
        Me.UltraButton1.TabIndex = 0
        Me.UltraButton1.Text = "UltraButton1"
        '
        'UltraFormattedLinkLabel1
        '
        Me.UltraFormattedLinkLabel1.Location = New System.Drawing.Point(36, 142)
        Me.UltraFormattedLinkLabel1.Name = "UltraFormattedLinkLabel1"
        Me.UltraFormattedLinkLabel1.Size = New System.Drawing.Size(173, 54)
        Me.UltraFormattedLinkLabel1.TabIndex = 1
        Me.UltraFormattedLinkLabel1.TabStop = True
        Me.UltraFormattedLinkLabel1.Value = "UltraFormattedLinkLabel1"
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Location = New System.Drawing.Point(130, 250)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(217, 31)
        Me.UltraGroupBox1.TabIndex = 2
        Me.UltraGroupBox1.Text = "UltraGroupBox1"
        '
        'UserControl1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.AutoPanel1)
        Me.Name = "UserControl1"
        Me.Size = New System.Drawing.Size(502, 383)
        Me.AutoPanel1.ResumeLayout(False)
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents AutoPanel1 As LATIRGUIControls.AutoPanel
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraFormattedLinkLabel1 As Infragistics.Win.FormattedLinkLabel.UltraFormattedLinkLabel
    Friend WithEvents UltraButton1 As Infragistics.Win.Misc.UltraButton

End Class
