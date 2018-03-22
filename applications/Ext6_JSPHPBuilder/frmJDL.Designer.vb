<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJDL
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
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

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdClearAll = New System.Windows.Forms.Button()
        Me.cmdSelectAll = New System.Windows.Forms.Button()
        Me.button3 = New System.Windows.Forms.Button()
        Me.textBoxOutPutFolder = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkObjType = New System.Windows.Forms.CheckedListBox()
        Me.folderBrowserDialogProjectOutput = New System.Windows.Forms.FolderBrowserDialog()
        Me.cmdGen = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 13)
        Me.Label2.TabIndex = 67
        Me.Label2.Text = "Типы документов"
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearAll.Location = New System.Drawing.Point(458, 60)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(60, 25)
        Me.cmdClearAll.TabIndex = 65
        Me.cmdClearAll.Text = "Clear all"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'cmdSelectAll
        '
        Me.cmdSelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSelectAll.Location = New System.Drawing.Point(390, 60)
        Me.cmdSelectAll.Name = "cmdSelectAll"
        Me.cmdSelectAll.Size = New System.Drawing.Size(60, 25)
        Me.cmdSelectAll.TabIndex = 64
        Me.cmdSelectAll.Text = "Select all"
        Me.cmdSelectAll.UseVisualStyleBackColor = True
        '
        'button3
        '
        Me.button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.button3.Location = New System.Drawing.Point(458, 27)
        Me.button3.Name = "button3"
        Me.button3.Size = New System.Drawing.Size(66, 22)
        Me.button3.TabIndex = 63
        Me.button3.Text = "..."
        '
        'textBoxOutPutFolder
        '
        Me.textBoxOutPutFolder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textBoxOutPutFolder.Location = New System.Drawing.Point(158, 27)
        Me.textBoxOutPutFolder.Name = "textBoxOutPutFolder"
        Me.textBoxOutPutFolder.Size = New System.Drawing.Size(288, 20)
        Me.textBoxOutPutFolder.TabIndex = 62
        Me.textBoxOutPutFolder.Text = "d:\BP3\OUT\Console\"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(25, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(115, 13)
        Me.Label3.TabIndex = 66
        Me.Label3.Text = "Projects Output Folder:"
        '
        'chkObjType
        '
        Me.chkObjType.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkObjType.FormattingEnabled = True
        Me.chkObjType.Location = New System.Drawing.Point(28, 112)
        Me.chkObjType.Name = "chkObjType"
        Me.chkObjType.Size = New System.Drawing.Size(490, 244)
        Me.chkObjType.TabIndex = 68
        '
        'folderBrowserDialogProjectOutput
        '
        Me.folderBrowserDialogProjectOutput.SelectedPath = "C:\LATIR2\Generated\"
        '
        'cmdGen
        '
        Me.cmdGen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdGen.Location = New System.Drawing.Point(452, 376)
        Me.cmdGen.Name = "cmdGen"
        Me.cmdGen.Size = New System.Drawing.Size(66, 26)
        Me.cmdGen.TabIndex = 69
        Me.cmdGen.Text = "Generate"
        Me.cmdGen.UseVisualStyleBackColor = True
        '
        'frmJDL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(541, 414)
        Me.Controls.Add(Me.cmdGen)
        Me.Controls.Add(Me.chkObjType)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.cmdSelectAll)
        Me.Controls.Add(Me.button3)
        Me.Controls.Add(Me.textBoxOutPutFolder)
        Me.Controls.Add(Me.Label3)
        Me.MinimumSize = New System.Drawing.Size(400, 400)
        Me.Name = "frmJDL"
        Me.Text = "Jhipster JDL generator"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents cmdClearAll As Button
    Friend WithEvents cmdSelectAll As Button
    Friend WithEvents button3 As Button
    Friend WithEvents textBoxOutPutFolder As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents chkObjType As CheckedListBox
    Friend WithEvents folderBrowserDialogProjectOutput As FolderBrowserDialog
    Friend WithEvents cmdGen As Button
End Class
