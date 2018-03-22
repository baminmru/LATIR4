<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExtJSMaker
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
        Me.chkObjType = New System.Windows.Forms.CheckedListBox()
        Me.button3 = New System.Windows.Forms.Button()
        Me.textBoxOutPutFolder = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.folderBrowserDialogProjectOutput = New System.Windows.Forms.FolderBrowserDialog()
        Me.pb = New System.Windows.Forms.ProgressBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdSelectAll = New System.Windows.Forms.Button()
        Me.cmdClearAll = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkJournals = New System.Windows.Forms.CheckedListBox()
        Me.cmdJSelectAll = New System.Windows.Forms.Button()
        Me.cmdJClearAll = New System.Windows.Forms.Button()
        Me.chkMenu = New System.Windows.Forms.CheckBox()
        Me.chkAlterBase = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'cmdGen
        '
        Me.cmdGen.Location = New System.Drawing.Point(429, 421)
        Me.cmdGen.Name = "cmdGen"
        Me.cmdGen.Size = New System.Drawing.Size(66, 26)
        Me.cmdGen.TabIndex = 2
        Me.cmdGen.Text = "Generate"
        Me.cmdGen.UseVisualStyleBackColor = True
        '
        'chkObjType
        '
        Me.chkObjType.FormattingEnabled = True
        Me.chkObjType.Location = New System.Drawing.Point(12, 82)
        Me.chkObjType.Name = "chkObjType"
        Me.chkObjType.Size = New System.Drawing.Size(483, 94)
        Me.chkObjType.Sorted = True
        Me.chkObjType.TabIndex = 3
        '
        'button3
        '
        Me.button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.button3.Location = New System.Drawing.Point(429, 8)
        Me.button3.Name = "button3"
        Me.button3.Size = New System.Drawing.Size(66, 22)
        Me.button3.TabIndex = 56
        Me.button3.Text = "..."
        '
        'textBoxOutPutFolder
        '
        Me.textBoxOutPutFolder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textBoxOutPutFolder.Location = New System.Drawing.Point(145, 10)
        Me.textBoxOutPutFolder.Name = "textBoxOutPutFolder"
        Me.textBoxOutPutFolder.Size = New System.Drawing.Size(278, 20)
        Me.textBoxOutPutFolder.TabIndex = 55
        Me.textBoxOutPutFolder.Text = "d:\BP3\OUT\Console\"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(115, 13)
        Me.Label3.TabIndex = 54
        Me.Label3.Text = "Projects Output Folder:"
        '
        'folderBrowserDialogProjectOutput
        '
        Me.folderBrowserDialogProjectOutput.SelectedPath = "C:\LATIR2\Generated\"
        '
        'pb
        '
        Me.pb.Location = New System.Drawing.Point(12, 450)
        Me.pb.Name = "pb"
        Me.pb.Size = New System.Drawing.Size(483, 20)
        Me.pb.TabIndex = 57
        Me.pb.Visible = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(12, 430)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(113, 17)
        Me.Label1.TabIndex = 58
        Me.Label1.Text = "Процесс генерации"
        Me.Label1.Visible = False
        '
        'cmdSelectAll
        '
        Me.cmdSelectAll.Location = New System.Drawing.Point(367, 47)
        Me.cmdSelectAll.Name = "cmdSelectAll"
        Me.cmdSelectAll.Size = New System.Drawing.Size(60, 25)
        Me.cmdSelectAll.TabIndex = 59
        Me.cmdSelectAll.Text = "Select all"
        Me.cmdSelectAll.UseVisualStyleBackColor = True
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Location = New System.Drawing.Point(429, 47)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(60, 25)
        Me.cmdClearAll.TabIndex = 60
        Me.cmdClearAll.Text = "Clear all"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 13)
        Me.Label2.TabIndex = 61
        Me.Label2.Text = "Типы документов"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 194)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 62
        Me.Label4.Text = "Журналы"
        '
        'chkJournals
        '
        Me.chkJournals.FormattingEnabled = True
        Me.chkJournals.Location = New System.Drawing.Point(17, 219)
        Me.chkJournals.Name = "chkJournals"
        Me.chkJournals.Size = New System.Drawing.Size(477, 79)
        Me.chkJournals.Sorted = True
        Me.chkJournals.TabIndex = 63
        '
        'cmdJSelectAll
        '
        Me.cmdJSelectAll.Location = New System.Drawing.Point(367, 188)
        Me.cmdJSelectAll.Name = "cmdJSelectAll"
        Me.cmdJSelectAll.Size = New System.Drawing.Size(60, 25)
        Me.cmdJSelectAll.TabIndex = 64
        Me.cmdJSelectAll.Text = "Select All"
        Me.cmdJSelectAll.UseVisualStyleBackColor = True
        '
        'cmdJClearAll
        '
        Me.cmdJClearAll.Location = New System.Drawing.Point(433, 188)
        Me.cmdJClearAll.Name = "cmdJClearAll"
        Me.cmdJClearAll.Size = New System.Drawing.Size(60, 25)
        Me.cmdJClearAll.TabIndex = 65
        Me.cmdJClearAll.Text = "Clear All"
        Me.cmdJClearAll.UseVisualStyleBackColor = True
        '
        'chkMenu
        '
        Me.chkMenu.AutoSize = True
        Me.chkMenu.Location = New System.Drawing.Point(24, 318)
        Me.chkMenu.Name = "chkMenu"
        Me.chkMenu.Size = New System.Drawing.Size(55, 17)
        Me.chkMenu.TabIndex = 66
        Me.chkMenu.Text = "Меню"
        Me.chkMenu.UseVisualStyleBackColor = True
        '
        'chkAlterBase
        '
        Me.chkAlterBase.AutoSize = True
        Me.chkAlterBase.Location = New System.Drawing.Point(23, 352)
        Me.chkAlterBase.Name = "chkAlterBase"
        Me.chkAlterBase.Size = New System.Drawing.Size(74, 17)
        Me.chkAlterBase.TabIndex = 67
        Me.chkAlterBase.Text = "Alter Base"
        Me.chkAlterBase.UseVisualStyleBackColor = True
        '
        'ExtJSMaker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(516, 485)
        Me.Controls.Add(Me.chkAlterBase)
        Me.Controls.Add(Me.chkMenu)
        Me.Controls.Add(Me.cmdJClearAll)
        Me.Controls.Add(Me.cmdJSelectAll)
        Me.Controls.Add(Me.chkJournals)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.cmdSelectAll)
        Me.Controls.Add(Me.pb)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.button3)
        Me.Controls.Add(Me.textBoxOutPutFolder)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.chkObjType)
        Me.Controls.Add(Me.cmdGen)
        Me.Name = "ExtJSMaker"
        Me.Text = "ExtJSMaker"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdGen As System.Windows.Forms.Button
    Friend WithEvents chkObjType As System.Windows.Forms.CheckedListBox
    Friend WithEvents button3 As System.Windows.Forms.Button
    Friend WithEvents textBoxOutPutFolder As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents folderBrowserDialogProjectOutput As System.Windows.Forms.FolderBrowserDialog
    Public WithEvents pb As System.Windows.Forms.ProgressBar
    Public WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdSelectAll As System.Windows.Forms.Button
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkJournals As System.Windows.Forms.CheckedListBox
    Friend WithEvents cmdJSelectAll As System.Windows.Forms.Button
    Friend WithEvents cmdJClearAll As System.Windows.Forms.Button
    Friend WithEvents chkMenu As System.Windows.Forms.CheckBox
    Friend WithEvents chkAlterBase As System.Windows.Forms.CheckBox
End Class
