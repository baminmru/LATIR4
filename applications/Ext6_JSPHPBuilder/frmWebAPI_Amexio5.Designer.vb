﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmWebAPI_Amexio5
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.cmdGen = New System.Windows.Forms.Button()
        Me.chkObjType = New System.Windows.Forms.CheckedListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdClearAll = New System.Windows.Forms.Button()
        Me.cmdSelectAll = New System.Windows.Forms.Button()
        Me.button3 = New System.Windows.Forms.Button()
        Me.textBoxOutPutFolder = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.folderBrowserDialogProjectOutput = New System.Windows.Forms.FolderBrowserDialog()
        Me.txtNS = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkUseDecap = New System.Windows.Forms.CheckBox()
        Me.txtContext = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkAutorize = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.optMS = New System.Windows.Forms.RadioButton()
        Me.optPG = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdGen
        '
        Me.cmdGen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdGen.Location = New System.Drawing.Point(455, 381)
        Me.cmdGen.Name = "cmdGen"
        Me.cmdGen.Size = New System.Drawing.Size(66, 26)
        Me.cmdGen.TabIndex = 77
        Me.cmdGen.Text = "Generate"
        Me.cmdGen.UseVisualStyleBackColor = True
        '
        'chkObjType
        '
        Me.chkObjType.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkObjType.FormattingEnabled = True
        Me.chkObjType.Location = New System.Drawing.Point(25, 214)
        Me.chkObjType.Name = "chkObjType"
        Me.chkObjType.Size = New System.Drawing.Size(490, 139)
        Me.chkObjType.Sorted = True
        Me.chkObjType.TabIndex = 76
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 189)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 13)
        Me.Label2.TabIndex = 75
        Me.Label2.Text = "Типы документов"
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearAll.Location = New System.Drawing.Point(460, 183)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(60, 25)
        Me.cmdClearAll.TabIndex = 73
        Me.cmdClearAll.Text = "Clear all"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'cmdSelectAll
        '
        Me.cmdSelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSelectAll.Location = New System.Drawing.Point(394, 183)
        Me.cmdSelectAll.Name = "cmdSelectAll"
        Me.cmdSelectAll.Size = New System.Drawing.Size(60, 25)
        Me.cmdSelectAll.TabIndex = 72
        Me.cmdSelectAll.Text = "Select all"
        Me.cmdSelectAll.UseVisualStyleBackColor = True
        '
        'button3
        '
        Me.button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.button3.Location = New System.Drawing.Point(455, 21)
        Me.button3.Name = "button3"
        Me.button3.Size = New System.Drawing.Size(66, 22)
        Me.button3.TabIndex = 71
        Me.button3.Text = "..."
        '
        'textBoxOutPutFolder
        '
        Me.textBoxOutPutFolder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textBoxOutPutFolder.Location = New System.Drawing.Point(155, 21)
        Me.textBoxOutPutFolder.Name = "textBoxOutPutFolder"
        Me.textBoxOutPutFolder.Size = New System.Drawing.Size(288, 20)
        Me.textBoxOutPutFolder.TabIndex = 70
        Me.textBoxOutPutFolder.Text = "d:\BP3\OUT\Console\"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(115, 13)
        Me.Label3.TabIndex = 74
        Me.Label3.Text = "Projects Output Folder:"
        '
        'folderBrowserDialogProjectOutput
        '
        Me.folderBrowserDialogProjectOutput.SelectedPath = "C:\LATIR2\Generated\"
        '
        'txtNS
        '
        Me.txtNS.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNS.Location = New System.Drawing.Point(155, 60)
        Me.txtNS.Name = "txtNS"
        Me.txtNS.Size = New System.Drawing.Size(288, 20)
        Me.txtNS.TabIndex = 78
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 13)
        Me.Label1.TabIndex = 79
        Me.Label1.Text = "Default namespace:"
        '
        'chkUseDecap
        '
        Me.chkUseDecap.AutoSize = True
        Me.chkUseDecap.Location = New System.Drawing.Point(25, 387)
        Me.chkUseDecap.Name = "chkUseDecap"
        Me.chkUseDecap.Size = New System.Drawing.Size(122, 17)
        Me.chkUseDecap.TabIndex = 80
        Me.chkUseDecap.Text = "lower case first letter"
        Me.chkUseDecap.UseVisualStyleBackColor = True
        '
        'txtContext
        '
        Me.txtContext.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtContext.Location = New System.Drawing.Point(155, 96)
        Me.txtContext.Name = "txtContext"
        Me.txtContext.Size = New System.Drawing.Size(288, 20)
        Me.txtContext.TabIndex = 81
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 99)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(102, 13)
        Me.Label4.TabIndex = 82
        Me.Label4.Text = "Context class name:"
        '
        'chkAutorize
        '
        Me.chkAutorize.AutoSize = True
        Me.chkAutorize.Location = New System.Drawing.Point(155, 132)
        Me.chkAutorize.Name = "chkAutorize"
        Me.chkAutorize.Size = New System.Drawing.Size(64, 17)
        Me.chkAutorize.TabIndex = 83
        Me.chkAutorize.Text = "Autorize"
        Me.chkAutorize.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.optPG)
        Me.GroupBox1.Controls.Add(Me.optMS)
        Me.GroupBox1.Location = New System.Drawing.Point(241, 123)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(273, 54)
        Me.GroupBox1.TabIndex = 84
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "DB"
        '
        'optMS
        '
        Me.optMS.AutoSize = True
        Me.optMS.Checked = True
        Me.optMS.Location = New System.Drawing.Point(27, 20)
        Me.optMS.Name = "optMS"
        Me.optMS.Size = New System.Drawing.Size(63, 17)
        Me.optMS.TabIndex = 0
        Me.optMS.TabStop = True
        Me.optMS.Text = "Ms SQL"
        Me.optMS.UseVisualStyleBackColor = True
        '
        'optPG
        '
        Me.optPG.AutoSize = True
        Me.optPG.Location = New System.Drawing.Point(142, 20)
        Me.optPG.Name = "optPG"
        Me.optPG.Size = New System.Drawing.Size(85, 17)
        Me.optPG.TabIndex = 1
        Me.optPG.Text = "Postgre SQL"
        Me.optPG.UseVisualStyleBackColor = True
        '
        'frmWebAPI_Amexio5
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(542, 416)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.chkAutorize)
        Me.Controls.Add(Me.txtContext)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.chkUseDecap)
        Me.Controls.Add(Me.txtNS)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdGen)
        Me.Controls.Add(Me.chkObjType)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.cmdSelectAll)
        Me.Controls.Add(Me.button3)
        Me.Controls.Add(Me.textBoxOutPutFolder)
        Me.Controls.Add(Me.Label3)
        Me.Name = "frmWebAPI_Amexio5"
        Me.Text = "Web API + ANGULAR 6 + (AMEXIO 5)  generator"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdGen As Button
    Friend WithEvents chkObjType As CheckedListBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cmdClearAll As Button
    Friend WithEvents cmdSelectAll As Button
    Friend WithEvents button3 As Button
    Friend WithEvents textBoxOutPutFolder As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents folderBrowserDialogProjectOutput As FolderBrowserDialog
    Friend WithEvents txtNS As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents chkUseDecap As CheckBox
    Friend WithEvents txtContext As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents chkAutorize As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents optPG As RadioButton
    Friend WithEvents optMS As RadioButton
End Class
