<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class touchInput
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
        Me.pnlYN = New System.Windows.Forms.Panel()
        Me.optNo = New System.Windows.Forms.RadioButton()
        Me.optYes = New System.Windows.Forms.RadioButton()
        Me.pnlNumeric = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtNum = New System.Windows.Forms.TextBox()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.pnlText = New System.Windows.Forms.Panel()
        Me.txtInput = New System.Windows.Forms.TextBox()
        Me.pnlYN.SuspendLayout()
        Me.pnlNumeric.SuspendLayout()
        Me.pnlText.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlYN
        '
        Me.pnlYN.BackColor = System.Drawing.Color.LightGray
        Me.pnlYN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlYN.Controls.Add(Me.optNo)
        Me.pnlYN.Controls.Add(Me.optYes)
        Me.pnlYN.Location = New System.Drawing.Point(252, 29)
        Me.pnlYN.Name = "pnlYN"
        Me.pnlYN.Size = New System.Drawing.Size(197, 73)
        Me.pnlYN.TabIndex = 0
        Me.pnlYN.Visible = False
        '
        'optNo
        '
        Me.optNo.CheckAlign = System.Drawing.ContentAlignment.TopCenter
        Me.optNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.optNo.ForeColor = System.Drawing.Color.OrangeRed
        Me.optNo.Location = New System.Drawing.Point(100, 8)
        Me.optNo.Name = "optNo"
        Me.optNo.Size = New System.Drawing.Size(84, 53)
        Me.optNo.TabIndex = 5
        Me.optNo.TabStop = True
        Me.optNo.Text = "Нет"
        Me.optNo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.optNo.UseVisualStyleBackColor = True
        '
        'optYes
        '
        Me.optYes.CheckAlign = System.Drawing.ContentAlignment.TopCenter
        Me.optYes.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.optYes.ForeColor = System.Drawing.Color.ForestGreen
        Me.optYes.Location = New System.Drawing.Point(3, 8)
        Me.optYes.Name = "optYes"
        Me.optYes.Size = New System.Drawing.Size(104, 53)
        Me.optYes.TabIndex = 4
        Me.optYes.TabStop = True
        Me.optYes.Text = "Да"
        Me.optYes.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.optYes.UseVisualStyleBackColor = True
        '
        'pnlNumeric
        '
        Me.pnlNumeric.BackColor = System.Drawing.Color.LightGray
        Me.pnlNumeric.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlNumeric.Controls.Add(Me.Button1)
        Me.pnlNumeric.Controls.Add(Me.txtNum)
        Me.pnlNumeric.Controls.Add(Me.Button14)
        Me.pnlNumeric.Controls.Add(Me.Button10)
        Me.pnlNumeric.Controls.Add(Me.Button11)
        Me.pnlNumeric.Controls.Add(Me.Button12)
        Me.pnlNumeric.Controls.Add(Me.Button7)
        Me.pnlNumeric.Controls.Add(Me.Button8)
        Me.pnlNumeric.Controls.Add(Me.Button9)
        Me.pnlNumeric.Controls.Add(Me.Button4)
        Me.pnlNumeric.Controls.Add(Me.Button5)
        Me.pnlNumeric.Controls.Add(Me.Button3)
        Me.pnlNumeric.Controls.Add(Me.Button6)
        Me.pnlNumeric.Controls.Add(Me.Button13)
        Me.pnlNumeric.Location = New System.Drawing.Point(7, 98)
        Me.pnlNumeric.Name = "pnlNumeric"
        Me.pnlNumeric.Size = New System.Drawing.Size(239, 294)
        Me.pnlNumeric.TabIndex = 1
        Me.pnlNumeric.Visible = False
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button1.Location = New System.Drawing.Point(10, 9)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(27, 31)
        Me.Button1.TabIndex = 26
        Me.Button1.Text = "-"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtNum
        '
        Me.txtNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtNum.Location = New System.Drawing.Point(43, 9)
        Me.txtNum.Name = "txtNum"
        Me.txtNum.Size = New System.Drawing.Size(186, 31)
        Me.txtNum.TabIndex = 25
        '
        'Button14
        '
        Me.Button14.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button14.Location = New System.Drawing.Point(10, 110)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(69, 56)
        Me.Button14.TabIndex = 24
        Me.Button14.Text = "4"
        Me.Button14.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button10.Location = New System.Drawing.Point(160, 234)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(69, 56)
        Me.Button10.TabIndex = 23
        Me.Button10.Text = "."
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Button11
        '
        Me.Button11.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button11.Location = New System.Drawing.Point(85, 234)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(69, 56)
        Me.Button11.TabIndex = 22
        Me.Button11.Text = "0"
        Me.Button11.UseVisualStyleBackColor = True
        '
        'Button12
        '
        Me.Button12.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button12.Location = New System.Drawing.Point(10, 234)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(69, 56)
        Me.Button12.TabIndex = 21
        Me.Button12.Text = "C"
        Me.Button12.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button7.Location = New System.Drawing.Point(160, 172)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(69, 56)
        Me.Button7.TabIndex = 20
        Me.Button7.Text = "3"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button8.Location = New System.Drawing.Point(85, 172)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(69, 56)
        Me.Button8.TabIndex = 19
        Me.Button8.Text = "2"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button9.Location = New System.Drawing.Point(10, 172)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(69, 56)
        Me.Button9.TabIndex = 18
        Me.Button9.Text = "1"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button4.Location = New System.Drawing.Point(160, 110)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(69, 56)
        Me.Button4.TabIndex = 17
        Me.Button4.Text = "6"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button5.Location = New System.Drawing.Point(85, 110)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(69, 56)
        Me.Button5.TabIndex = 16
        Me.Button5.Text = "5"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button3.Location = New System.Drawing.Point(160, 48)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(69, 56)
        Me.Button3.TabIndex = 15
        Me.Button3.Text = "9"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button6.Location = New System.Drawing.Point(85, 48)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(69, 56)
        Me.Button6.TabIndex = 14
        Me.Button6.Text = "8"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button13
        '
        Me.Button13.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button13.Location = New System.Drawing.Point(10, 48)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(69, 56)
        Me.Button13.TabIndex = 13
        Me.Button13.Text = "7"
        Me.Button13.UseVisualStyleBackColor = True
        '
        'pnlText
        '
        Me.pnlText.BackColor = System.Drawing.Color.LightGray
        Me.pnlText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlText.Controls.Add(Me.txtInput)
        Me.pnlText.Location = New System.Drawing.Point(7, 3)
        Me.pnlText.Name = "pnlText"
        Me.pnlText.Size = New System.Drawing.Size(229, 44)
        Me.pnlText.TabIndex = 2
        '
        'txtInput
        '
        Me.txtInput.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtInput.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtInput.Location = New System.Drawing.Point(0, 3)
        Me.txtInput.Name = "txtInput"
        Me.txtInput.Size = New System.Drawing.Size(224, 29)
        Me.txtInput.TabIndex = 0
        '
        'touchInput
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.pnlNumeric)
        Me.Controls.Add(Me.pnlYN)
        Me.Controls.Add(Me.pnlText)
        Me.Name = "touchInput"
        Me.Size = New System.Drawing.Size(454, 369)
        Me.pnlYN.ResumeLayout(False)
        Me.pnlNumeric.ResumeLayout(False)
        Me.pnlNumeric.PerformLayout()
        Me.pnlText.ResumeLayout(False)
        Me.pnlText.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlYN As Panel
    Friend WithEvents pnlNumeric As Panel
    Friend WithEvents Button10 As Button
    Friend WithEvents Button11 As Button
    Friend WithEvents Button12 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents Button9 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button13 As Button
    Friend WithEvents Button14 As Button
    Friend WithEvents pnlText As Panel
    Friend WithEvents txtInput As TextBox
    Friend WithEvents optNo As RadioButton
    Friend WithEvents optYes As RadioButton
    Friend WithEvents txtNum As TextBox
    Friend WithEvents Button1 As Button
End Class
