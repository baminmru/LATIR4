<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StyleSetup
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.cmbStyles = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        CType(Me.cmbStyles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraLabel1
        '
        Me.UltraLabel1.Location = New System.Drawing.Point(9, 11)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(247, 28)
        Me.UltraLabel1.TabIndex = 0
        Me.UltraLabel1.Text = "Библиотека стилей"
        '
        'cmbStyles
        '
        Me.cmbStyles.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbStyles.Location = New System.Drawing.Point(16, 35)
        Me.cmbStyles.Name = "cmbStyles"
        Me.cmbStyles.Size = New System.Drawing.Size(329, 21)
        Me.cmbStyles.TabIndex = 1
        '
        'StyleSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(435, 109)
        Me.Controls.Add(Me.cmbStyles)
        Me.Controls.Add(Me.UltraLabel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "StyleSetup"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "StyleSetup"
        CType(Me.cmbStyles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents cmbStyles As Infragistics.Win.UltraWinEditors.UltraComboEditor

End Class
