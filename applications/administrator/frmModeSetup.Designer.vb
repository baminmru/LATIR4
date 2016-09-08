<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModeSetup
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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tvParts = New System.Windows.Forms.TreeView()
        Me.lstMode = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmdAdd = New System.Windows.Forms.Button()
        Me.cmdAddMode = New System.Windows.Forms.Button()
        Me.txtNewMode = New LATIR2GuiManager.TouchTextBox()
        Me.gvRestriction = New System.Windows.Forms.DataGridView()
        Me.chkPartAdd = New System.Windows.Forms.CheckBox()
        Me.chkEdit = New System.Windows.Forms.CheckBox()
        Me.chkRead = New System.Windows.Forms.CheckBox()
        Me.chkPartDelete = New System.Windows.Forms.CheckBox()
        Me.chkM = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.gvPartRestriction = New System.Windows.Forms.DataGridView()
        Me.chkPartRead = New System.Windows.Forms.CheckBox()
        Me.chkPartEdit = New System.Windows.Forms.CheckBox()
        Me.cmdAddPart = New System.Windows.Forms.Button()
        Me.lstFrom = New System.Windows.Forms.CheckedListBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.cmdClearFields = New System.Windows.Forms.Button()
        Me.cmdClearParts = New System.Windows.Forms.Button()
        CType(Me.gvRestriction, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvPartRestriction, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(12, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(229, 17)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Типы документов \ разделы"
        '
        'tvParts
        '
        Me.tvParts.HideSelection = False
        Me.tvParts.Location = New System.Drawing.Point(12, 29)
        Me.tvParts.Name = "tvParts"
        Me.tvParts.Size = New System.Drawing.Size(370, 222)
        Me.tvParts.TabIndex = 9
        '
        'lstMode
        '
        Me.lstMode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstMode.FormattingEnabled = True
        Me.lstMode.Location = New System.Drawing.Point(446, 29)
        Me.lstMode.Name = "lstMode"
        Me.lstMode.Size = New System.Drawing.Size(469, 56)
        Me.lstMode.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(443, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Режимы"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(694, 275)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Разрешения для полей"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 275)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Поля"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(443, 88)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(105, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Настройка режима"
        '
        'cmdAdd
        '
        Me.cmdAdd.Location = New System.Drawing.Point(388, 322)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(52, 40)
        Me.cmdAdd.TabIndex = 17
        Me.cmdAdd.Text = ">"
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'cmdAddMode
        '
        Me.cmdAddMode.Location = New System.Drawing.Point(566, 1)
        Me.cmdAddMode.Name = "cmdAddMode"
        Me.cmdAddMode.Size = New System.Drawing.Size(26, 22)
        Me.cmdAddMode.TabIndex = 19
        Me.cmdAddMode.Text = "+"
        Me.cmdAddMode.UseVisualStyleBackColor = True
        '
        'txtNewMode
        '
        Me.txtNewMode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNewMode.Location = New System.Drawing.Point(627, 3)
        Me.txtNewMode.MaxLength = 4
        Me.txtNewMode.Name = "txtNewMode"
        Me.txtNewMode.Size = New System.Drawing.Size(288, 20)
        Me.txtNewMode.TabIndex = 20
        '
        'gvRestriction
        '
        Me.gvRestriction.AllowUserToAddRows = False
        Me.gvRestriction.AllowUserToDeleteRows = False
        Me.gvRestriction.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gvRestriction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvRestriction.Location = New System.Drawing.Point(446, 298)
        Me.gvRestriction.Name = "gvRestriction"
        Me.gvRestriction.Size = New System.Drawing.Size(479, 173)
        Me.gvRestriction.TabIndex = 21
        '
        'chkPartAdd
        '
        Me.chkPartAdd.AutoSize = True
        Me.chkPartAdd.Location = New System.Drawing.Point(445, 105)
        Me.chkPartAdd.Name = "chkPartAdd"
        Me.chkPartAdd.Size = New System.Drawing.Size(45, 17)
        Me.chkPartAdd.TabIndex = 22
        Me.chkPartAdd.Text = "Add"
        Me.chkPartAdd.UseVisualStyleBackColor = True
        '
        'chkEdit
        '
        Me.chkEdit.AutoSize = True
        Me.chkEdit.Location = New System.Drawing.Point(516, 275)
        Me.chkEdit.Name = "chkEdit"
        Me.chkEdit.Size = New System.Drawing.Size(44, 17)
        Me.chkEdit.TabIndex = 23
        Me.chkEdit.Text = "Edit"
        Me.chkEdit.UseVisualStyleBackColor = True
        '
        'chkRead
        '
        Me.chkRead.AutoSize = True
        Me.chkRead.Location = New System.Drawing.Point(458, 275)
        Me.chkRead.Name = "chkRead"
        Me.chkRead.Size = New System.Drawing.Size(52, 17)
        Me.chkRead.TabIndex = 24
        Me.chkRead.Text = "Read"
        Me.chkRead.UseVisualStyleBackColor = True
        '
        'chkPartDelete
        '
        Me.chkPartDelete.AutoSize = True
        Me.chkPartDelete.Location = New System.Drawing.Point(500, 105)
        Me.chkPartDelete.Name = "chkPartDelete"
        Me.chkPartDelete.Size = New System.Drawing.Size(57, 17)
        Me.chkPartDelete.TabIndex = 25
        Me.chkPartDelete.Text = "Delete"
        Me.chkPartDelete.UseVisualStyleBackColor = True
        '
        'chkM
        '
        Me.chkM.AutoSize = True
        Me.chkM.Location = New System.Drawing.Point(566, 275)
        Me.chkM.Name = "chkM"
        Me.chkM.Size = New System.Drawing.Size(76, 17)
        Me.chkM.TabIndex = 26
        Me.chkM.Text = "Mandatory"
        Me.chkM.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(694, 105)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(142, 13)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "Разрешения для разделов"
        '
        'gvPartRestriction
        '
        Me.gvPartRestriction.AllowUserToAddRows = False
        Me.gvPartRestriction.AllowUserToDeleteRows = False
        Me.gvPartRestriction.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gvPartRestriction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvPartRestriction.Location = New System.Drawing.Point(446, 128)
        Me.gvPartRestriction.Name = "gvPartRestriction"
        Me.gvPartRestriction.Size = New System.Drawing.Size(479, 123)
        Me.gvPartRestriction.TabIndex = 28
        '
        'chkPartRead
        '
        Me.chkPartRead.AutoSize = True
        Me.chkPartRead.Location = New System.Drawing.Point(566, 105)
        Me.chkPartRead.Name = "chkPartRead"
        Me.chkPartRead.Size = New System.Drawing.Size(52, 17)
        Me.chkPartRead.TabIndex = 30
        Me.chkPartRead.Text = "Read"
        Me.chkPartRead.UseVisualStyleBackColor = True
        '
        'chkPartEdit
        '
        Me.chkPartEdit.AutoSize = True
        Me.chkPartEdit.Location = New System.Drawing.Point(624, 105)
        Me.chkPartEdit.Name = "chkPartEdit"
        Me.chkPartEdit.Size = New System.Drawing.Size(44, 17)
        Me.chkPartEdit.TabIndex = 29
        Me.chkPartEdit.Text = "Edit"
        Me.chkPartEdit.UseVisualStyleBackColor = True
        '
        'cmdAddPart
        '
        Me.cmdAddPart.Location = New System.Drawing.Point(388, 145)
        Me.cmdAddPart.Name = "cmdAddPart"
        Me.cmdAddPart.Size = New System.Drawing.Size(52, 43)
        Me.cmdAddPart.TabIndex = 31
        Me.cmdAddPart.Text = ">"
        Me.cmdAddPart.UseVisualStyleBackColor = True
        '
        'lstFrom
        '
        Me.lstFrom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstFrom.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lstFrom.FormattingEnabled = True
        Me.lstFrom.Location = New System.Drawing.Point(14, 304)
        Me.lstFrom.Name = "lstFrom"
        Me.lstFrom.Size = New System.Drawing.Size(364, 154)
        Me.lstFrom.TabIndex = 32
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(149, 269)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(98, 25)
        Me.Button1.TabIndex = 33
        Me.Button1.Text = "выбрать все"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(265, 269)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(113, 25)
        Me.Button2.TabIndex = 34
        Me.Button2.Text = "отменить все"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'cmdClearFields
        '
        Me.cmdClearFields.Location = New System.Drawing.Point(388, 379)
        Me.cmdClearFields.Name = "cmdClearFields"
        Me.cmdClearFields.Size = New System.Drawing.Size(52, 42)
        Me.cmdClearFields.TabIndex = 35
        Me.cmdClearFields.Text = "<<"
        Me.cmdClearFields.UseVisualStyleBackColor = True
        '
        'cmdClearParts
        '
        Me.cmdClearParts.Location = New System.Drawing.Point(388, 199)
        Me.cmdClearParts.Name = "cmdClearParts"
        Me.cmdClearParts.Size = New System.Drawing.Size(51, 51)
        Me.cmdClearParts.TabIndex = 36
        Me.cmdClearParts.Text = "<<"
        Me.cmdClearParts.UseVisualStyleBackColor = True
        '
        'frmModeSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(945, 483)
        Me.Controls.Add(Me.cmdClearParts)
        Me.Controls.Add(Me.cmdClearFields)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lstFrom)
        Me.Controls.Add(Me.cmdAddPart)
        Me.Controls.Add(Me.chkPartRead)
        Me.Controls.Add(Me.chkPartEdit)
        Me.Controls.Add(Me.gvPartRestriction)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.chkM)
        Me.Controls.Add(Me.chkPartDelete)
        Me.Controls.Add(Me.chkRead)
        Me.Controls.Add(Me.chkEdit)
        Me.Controls.Add(Me.chkPartAdd)
        Me.Controls.Add(Me.gvRestriction)
        Me.Controls.Add(Me.txtNewMode)
        Me.Controls.Add(Me.cmdAddMode)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lstMode)
        Me.Controls.Add(Me.tvParts)
        Me.Controls.Add(Me.Label4)
        Me.Name = "frmModeSetup"
        Me.Text = "Настройка режимов"
        CType(Me.gvRestriction, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvPartRestriction, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tvParts As System.Windows.Forms.TreeView
    Friend WithEvents lstMode As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents cmdAddMode As System.Windows.Forms.Button
    Friend WithEvents txtNewMode As LATIR2GuiManager.TouchTextBox
    Friend WithEvents gvRestriction As System.Windows.Forms.DataGridView
    Friend WithEvents chkPartAdd As System.Windows.Forms.CheckBox
    Friend WithEvents chkEdit As System.Windows.Forms.CheckBox
    Friend WithEvents chkRead As System.Windows.Forms.CheckBox
    Friend WithEvents chkPartDelete As System.Windows.Forms.CheckBox
    Friend WithEvents chkM As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents gvPartRestriction As System.Windows.Forms.DataGridView
    Friend WithEvents chkPartRead As System.Windows.Forms.CheckBox
    Friend WithEvents chkPartEdit As System.Windows.Forms.CheckBox
    Friend WithEvents cmdAddPart As System.Windows.Forms.Button
    Friend WithEvents lstFrom As System.Windows.Forms.CheckedListBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents cmdClearFields As System.Windows.Forms.Button
    Friend WithEvents cmdClearParts As System.Windows.Forms.Button
End Class
