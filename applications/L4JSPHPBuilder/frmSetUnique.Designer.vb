<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSetUnique
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
        Me.chkTypes = New System.Windows.Forms.CheckedListBox()
        Me.cmdMakeUniq = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPart = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFld = New System.Windows.Forms.TextBox()
        Me.txtOut = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'chkTypes
        '
        Me.chkTypes.FormattingEnabled = True
        Me.chkTypes.Location = New System.Drawing.Point(16, 12)
        Me.chkTypes.Name = "chkTypes"
        Me.chkTypes.Size = New System.Drawing.Size(440, 169)
        Me.chkTypes.TabIndex = 0
        '
        'cmdMakeUniq
        '
        Me.cmdMakeUniq.Location = New System.Drawing.Point(286, 267)
        Me.cmdMakeUniq.Name = "cmdMakeUniq"
        Me.cmdMakeUniq.Size = New System.Drawing.Size(170, 40)
        Me.cmdMakeUniq.TabIndex = 1
        Me.cmdMakeUniq.Text = "Задать уникальность"
        Me.cmdMakeUniq.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 191)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Раздел"
        '
        'txtPart
        '
        Me.txtPart.Location = New System.Drawing.Point(73, 191)
        Me.txtPart.Name = "txtPart"
        Me.txtPart.Size = New System.Drawing.Size(382, 20)
        Me.txtPart.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 226)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Поле"
        '
        'txtFld
        '
        Me.txtFld.Location = New System.Drawing.Point(75, 223)
        Me.txtFld.Name = "txtFld"
        Me.txtFld.Size = New System.Drawing.Size(379, 20)
        Me.txtFld.TabIndex = 5
        '
        'txtOut
        '
        Me.txtOut.Location = New System.Drawing.Point(11, 256)
        Me.txtOut.Multiline = True
        Me.txtOut.Name = "txtOut"
        Me.txtOut.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtOut.Size = New System.Drawing.Size(256, 61)
        Me.txtOut.TabIndex = 6
        '
        'frmSetUnique
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(473, 326)
        Me.Controls.Add(Me.txtOut)
        Me.Controls.Add(Me.txtFld)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtPart)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdMakeUniq)
        Me.Controls.Add(Me.chkTypes)
        Me.Name = "frmSetUnique"
        Me.Text = "Быстрое создание уникальных сочетаний"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkTypes As System.Windows.Forms.CheckedListBox
    Friend WithEvents cmdMakeUniq As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPart As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFld As System.Windows.Forms.TextBox
    Friend WithEvents txtOut As System.Windows.Forms.TextBox
End Class
