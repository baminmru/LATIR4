<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExportToMySQL
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
        Me.cmdGen = New System.Windows.Forms.Button()
        Me.button3 = New System.Windows.Forms.Button()
        Me.txtExport = New LATIR2GuiManager.TouchTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.progressBar = New System.Windows.Forms.ProgressBar()
        Me.chkTypes = New System.Windows.Forms.CheckedListBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BFolder = New System.Windows.Forms.FolderBrowserDialog()
        Me.cmdUnSelectAll = New System.Windows.Forms.Button()
        Me.cmdSelectAll = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmdGen
        '
        Me.cmdGen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdGen.BackColor = System.Drawing.SystemColors.Control
        Me.cmdGen.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdGen.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdGen.Location = New System.Drawing.Point(12, 296)
        Me.cmdGen.Name = "cmdGen"
        Me.cmdGen.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdGen.Size = New System.Drawing.Size(73, 21)
        Me.cmdGen.TabIndex = 72
        Me.cmdGen.Text = "Генерация"
        Me.cmdGen.UseVisualStyleBackColor = False
        '
        'button3
        '
        Me.button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.button3.Location = New System.Drawing.Point(546, 268)
        Me.button3.Name = "button3"
        Me.button3.Size = New System.Drawing.Size(26, 22)
        Me.button3.TabIndex = 71
        Me.button3.Text = "..."
        '
        'txtExport
        '
        Me.txtExport.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtExport.Location = New System.Drawing.Point(127, 270)
        Me.txtExport.Name = "txtExport"
        Me.txtExport.Size = New System.Drawing.Size(413, 20)
        Me.txtExport.TabIndex = 70
        Me.txtExport.Text = "C:\LATIR2\Export\"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 270)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 13)
        Me.Label3.TabIndex = 69
        Me.Label3.Text = "Выходная папка"
        '
        'progressBar
        '
        Me.progressBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.progressBar.Location = New System.Drawing.Point(12, 323)
        Me.progressBar.Name = "progressBar"
        Me.progressBar.Size = New System.Drawing.Size(566, 17)
        Me.progressBar.TabIndex = 67
        Me.progressBar.Visible = False
        '
        'chkTypes
        '
        Me.chkTypes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkTypes.CheckOnClick = True
        Me.chkTypes.FormattingEnabled = True
        Me.chkTypes.Location = New System.Drawing.Point(12, 22)
        Me.chkTypes.Name = "chkTypes"
        Me.chkTypes.Size = New System.Drawing.Size(560, 199)
        Me.chkTypes.Sorted = True
        Me.chkTypes.TabIndex = 65
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(9, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(101, 17)
        Me.Label4.TabIndex = 66
        Me.Label4.Text = "Типы документов"
        '
        'cmdUnSelectAll
        '
        Me.cmdUnSelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdUnSelectAll.BackColor = System.Drawing.SystemColors.Control
        Me.cmdUnSelectAll.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdUnSelectAll.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdUnSelectAll.Location = New System.Drawing.Point(118, 238)
        Me.cmdUnSelectAll.Name = "cmdUnSelectAll"
        Me.cmdUnSelectAll.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdUnSelectAll.Size = New System.Drawing.Size(100, 21)
        Me.cmdUnSelectAll.TabIndex = 74
        Me.cmdUnSelectAll.Text = "Отменить все"
        Me.cmdUnSelectAll.UseVisualStyleBackColor = False
        '
        'cmdSelectAll
        '
        Me.cmdSelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdSelectAll.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSelectAll.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSelectAll.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSelectAll.Location = New System.Drawing.Point(12, 238)
        Me.cmdSelectAll.Name = "cmdSelectAll"
        Me.cmdSelectAll.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSelectAll.Size = New System.Drawing.Size(100, 21)
        Me.cmdSelectAll.TabIndex = 73
        Me.cmdSelectAll.Text = "Выбрать все"
        Me.cmdSelectAll.UseVisualStyleBackColor = False
        '
        'frmExportToMySQL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(595, 352)
        Me.Controls.Add(Me.cmdUnSelectAll)
        Me.Controls.Add(Me.cmdSelectAll)
        Me.Controls.Add(Me.cmdGen)
        Me.Controls.Add(Me.button3)
        Me.Controls.Add(Me.txtExport)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.progressBar)
        Me.Controls.Add(Me.chkTypes)
        Me.Controls.Add(Me.Label4)
        Me.Name = "frmExportToMySQL"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Экспорт данных в ⁮MySQL"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents cmdGen As System.Windows.Forms.Button
    Friend WithEvents button3 As System.Windows.Forms.Button
    Friend WithEvents txtExport As LATIR2GuiManager.TouchTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents progressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents chkTypes As System.Windows.Forms.CheckedListBox
    Public WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BFolder As System.Windows.Forms.FolderBrowserDialog
    Public WithEvents cmdUnSelectAll As System.Windows.Forms.Button
    Public WithEvents cmdSelectAll As System.Windows.Forms.Button
End Class
