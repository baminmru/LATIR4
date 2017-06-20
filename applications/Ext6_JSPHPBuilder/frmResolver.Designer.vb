<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmResolver
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
        Me.cmdB2S = New System.Windows.Forms.Button()
        Me.cmdB2Z = New System.Windows.Forms.Button()
        Me.txtOut = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmdB2S
        '
        Me.cmdB2S.Location = New System.Drawing.Point(23, 12)
        Me.cmdB2S.Name = "cmdB2S"
        Me.cmdB2S.Size = New System.Drawing.Size(118, 25)
        Me.cmdB2S.TabIndex = 0
        Me.cmdB2S.Text = "Вторичный рынок"
        Me.cmdB2S.UseVisualStyleBackColor = True
        '
        'cmdB2Z
        '
        Me.cmdB2Z.Location = New System.Drawing.Point(147, 14)
        Me.cmdB2Z.Name = "cmdB2Z"
        Me.cmdB2Z.Size = New System.Drawing.Size(118, 23)
        Me.cmdB2Z.TabIndex = 2
        Me.cmdB2Z.Text = "Загородная недвижимость"
        Me.cmdB2Z.UseVisualStyleBackColor = True
        '
        'txtOut
        '
        Me.txtOut.Location = New System.Drawing.Point(12, 140)
        Me.txtOut.Multiline = True
        Me.txtOut.Name = "txtOut"
        Me.txtOut.Size = New System.Drawing.Size(437, 160)
        Me.txtOut.TabIndex = 3
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(23, 43)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(118, 21)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Первичный рынок"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(152, 43)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(112, 20)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "Коммерция"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(22, 73)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(118, 30)
        Me.Button3.TabIndex = 6
        Me.Button3.Text = "Все"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'frmResolver
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(491, 312)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtOut)
        Me.Controls.Add(Me.cmdB2Z)
        Me.Controls.Add(Me.cmdB2S)
        Me.Name = "frmResolver"
        Me.Text = "frmResolver"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdB2S As System.Windows.Forms.Button
    Friend WithEvents cmdB2Z As System.Windows.Forms.Button
    Friend WithEvents txtOut As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
End Class
