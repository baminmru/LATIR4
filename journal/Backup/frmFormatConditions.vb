Imports Janus.Windows.GridEX


Public Class frmFormatConditions
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents icons As System.Windows.Forms.ImageList
    Friend WithEvents cldStyle As System.Windows.Forms.ColorDialog
    Friend WithEvents tabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtValue2 As System.Windows.Forms.TextBox
    Friend WithEvents lblValue1 As System.Windows.Forms.Label
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents lblCondition As System.Windows.Forms.Label
    Friend WithEvents cmbFields As System.Windows.Forms.ComboBox
    Friend WithEvents lblValue2 As System.Windows.Forms.Label
    Friend WithEvents txtValue1 As System.Windows.Forms.TextBox
    Friend WithEvents cmbCondition As System.Windows.Forms.ComboBox
    Friend WithEvents tabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents lblBkgColor2 As System.Windows.Forms.Label
    Friend WithEvents btnBkgColor2 As System.Windows.Forms.Button
    Friend WithEvents lblBkgColor1 As System.Windows.Forms.Label
    Friend WithEvents btnBkgColor1 As System.Windows.Forms.Button
    Friend WithEvents lblTextColor As System.Windows.Forms.Label
    Friend WithEvents cmbItemBkgStyle As System.Windows.Forms.ComboBox
    Friend WithEvents label8 As System.Windows.Forms.Label
    Friend WithEvents label5 As System.Windows.Forms.Label
    Friend WithEvents label4 As System.Windows.Forms.Label
    Friend WithEvents label3 As System.Windows.Forms.Label
    Friend WithEvents btnTextColor As System.Windows.Forms.Button
    Friend WithEvents chbUnderline As System.Windows.Forms.CheckBox
    Friend WithEvents chbStrikeout As System.Windows.Forms.CheckBox
    Friend WithEvents chbItalic As System.Windows.Forms.CheckBox
    Friend WithEvents chbBold As System.Windows.Forms.CheckBox
    Friend WithEvents label11 As System.Windows.Forms.Label
    Friend WithEvents label7 As System.Windows.Forms.Label
    Friend WithEvents label6 As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnMoveUp As System.Windows.Forms.Button
    Friend WithEvents btnMoveDown As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents grpConditionName As System.Windows.Forms.GroupBox
    Friend WithEvents lblConditionName As System.Windows.Forms.Label
    Friend WithEvents groupRowStyle As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.TabPage
    Friend WithEvents groupConditionCriteria As System.Windows.Forms.GroupBox
    Friend WithEvents jsgConditions As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnEmptyForeColor As System.Windows.Forms.Button
    Friend WithEvents btnEmptyBackColor As System.Windows.Forms.Button
    Friend WithEvents btnEmptyBackColor2 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmFormatConditions))
        Me.icons = New System.Windows.Forms.ImageList(Me.components)
        Me.cldStyle = New System.Windows.Forms.ColorDialog
        Me.tabControl1 = New System.Windows.Forms.TabControl
        Me.GroupBox2 = New System.Windows.Forms.TabPage
        Me.grpConditionName = New System.Windows.Forms.GroupBox
        Me.lblConditionName = New System.Windows.Forms.Label
        Me.txtName = New System.Windows.Forms.TextBox
        Me.groupConditionCriteria = New System.Windows.Forms.GroupBox
        Me.txtValue2 = New System.Windows.Forms.TextBox
        Me.lblValue1 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.lblCondition = New System.Windows.Forms.Label
        Me.cmbFields = New System.Windows.Forms.ComboBox
        Me.lblValue2 = New System.Windows.Forms.Label
        Me.txtValue1 = New System.Windows.Forms.TextBox
        Me.cmbCondition = New System.Windows.Forms.ComboBox
        Me.tabPage3 = New System.Windows.Forms.TabPage
        Me.groupRowStyle = New System.Windows.Forms.GroupBox
        Me.btnEmptyBackColor2 = New System.Windows.Forms.Button
        Me.btnEmptyBackColor = New System.Windows.Forms.Button
        Me.btnEmptyForeColor = New System.Windows.Forms.Button
        Me.lblBkgColor2 = New System.Windows.Forms.Label
        Me.btnBkgColor2 = New System.Windows.Forms.Button
        Me.lblBkgColor1 = New System.Windows.Forms.Label
        Me.btnBkgColor1 = New System.Windows.Forms.Button
        Me.lblTextColor = New System.Windows.Forms.Label
        Me.cmbItemBkgStyle = New System.Windows.Forms.ComboBox
        Me.label8 = New System.Windows.Forms.Label
        Me.label5 = New System.Windows.Forms.Label
        Me.label4 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.btnTextColor = New System.Windows.Forms.Button
        Me.chbUnderline = New System.Windows.Forms.CheckBox
        Me.chbStrikeout = New System.Windows.Forms.CheckBox
        Me.chbItalic = New System.Windows.Forms.CheckBox
        Me.chbBold = New System.Windows.Forms.CheckBox
        Me.label11 = New System.Windows.Forms.Label
        Me.label7 = New System.Windows.Forms.Label
        Me.label6 = New System.Windows.Forms.Label
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnMoveUp = New System.Windows.Forms.Button
        Me.btnMoveDown = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.jsgConditions = New Janus.Windows.GridEX.GridEX
        Me.tabControl1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.grpConditionName.SuspendLayout()
        Me.groupConditionCriteria.SuspendLayout()
        Me.tabPage3.SuspendLayout()
        Me.groupRowStyle.SuspendLayout()
        CType(Me.jsgConditions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'icons
        '
        Me.icons.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.icons.ImageSize = New System.Drawing.Size(16, 16)
        Me.icons.ImageStream = CType(resources.GetObject("icons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.icons.TransparentColor = System.Drawing.Color.Transparent
        '
        'cldStyle
        '
        Me.cldStyle.AnyColor = True
        '
        'tabControl1
        '
        Me.tabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox2, Me.tabPage3})
        Me.tabControl1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tabControl1.HotTrack = True
        Me.tabControl1.ImageList = Me.icons
        Me.tabControl1.ItemSize = New System.Drawing.Size(109, 19)
        Me.tabControl1.Location = New System.Drawing.Point(4, 213)
        Me.tabControl1.Name = "tabControl1"
        Me.tabControl1.SelectedIndex = 0
        Me.tabControl1.Size = New System.Drawing.Size(416, 224)
        Me.tabControl1.TabIndex = 31
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.Menu
        Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.grpConditionName, Me.groupConditionCriteria})
        Me.GroupBox2.Cursor = System.Windows.Forms.Cursors.Default
        Me.GroupBox2.ImageIndex = 0
        Me.GroupBox2.Location = New System.Drawing.Point(4, 23)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(408, 197)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.Text = "Condition Properties"
        '
        'grpConditionName
        '
        Me.grpConditionName.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblConditionName, Me.txtName})
        Me.grpConditionName.Enabled = False
        Me.grpConditionName.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.grpConditionName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.grpConditionName.Location = New System.Drawing.Point(8, 8)
        Me.grpConditionName.Name = "grpConditionName"
        Me.grpConditionName.Size = New System.Drawing.Size(392, 64)
        Me.grpConditionName.TabIndex = 20
        Me.grpConditionName.TabStop = False
        '
        'lblConditionName
        '
        Me.lblConditionName.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblConditionName.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.lblConditionName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblConditionName.Location = New System.Drawing.Point(8, 24)
        Me.lblConditionName.Name = "lblConditionName"
        Me.lblConditionName.Size = New System.Drawing.Size(104, 16)
        Me.lblConditionName.TabIndex = 23
        Me.lblConditionName.Text = "Condition Name:"
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.txtName.Location = New System.Drawing.Point(120, 24)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(256, 21)
        Me.txtName.TabIndex = 22
        Me.txtName.Text = ""
        '
        'groupConditionCriteria
        '
        Me.groupConditionCriteria.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtValue2, Me.lblValue1, Me.label2, Me.lblCondition, Me.cmbFields, Me.lblValue2, Me.txtValue1, Me.cmbCondition})
        Me.groupConditionCriteria.Enabled = False
        Me.groupConditionCriteria.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.groupConditionCriteria.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.groupConditionCriteria.Location = New System.Drawing.Point(8, 80)
        Me.groupConditionCriteria.Name = "groupConditionCriteria"
        Me.groupConditionCriteria.Size = New System.Drawing.Size(392, 112)
        Me.groupConditionCriteria.TabIndex = 19
        Me.groupConditionCriteria.TabStop = False
        Me.groupConditionCriteria.Text = "Condition:"
        '
        'txtValue2
        '
        Me.txtValue2.Enabled = False
        Me.txtValue2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.txtValue2.Location = New System.Drawing.Point(248, 80)
        Me.txtValue2.Name = "txtValue2"
        Me.txtValue2.Size = New System.Drawing.Size(136, 21)
        Me.txtValue2.TabIndex = 19
        Me.txtValue2.Text = ""
        '
        'lblValue1
        '
        Me.lblValue1.AutoSize = True
        Me.lblValue1.Enabled = False
        Me.lblValue1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblValue1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.lblValue1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblValue1.Location = New System.Drawing.Point(248, 24)
        Me.lblValue1.Name = "lblValue1"
        Me.lblValue1.Size = New System.Drawing.Size(45, 14)
        Me.lblValue1.TabIndex = 16
        Me.lblValue1.Text = "Value 1:"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.label2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.label2.Location = New System.Drawing.Point(16, 24)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(46, 14)
        Me.label2.TabIndex = 13
        Me.label2.Text = "Column:"
        '
        'lblCondition
        '
        Me.lblCondition.AutoSize = True
        Me.lblCondition.Enabled = False
        Me.lblCondition.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblCondition.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.lblCondition.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCondition.Location = New System.Drawing.Point(144, 24)
        Me.lblCondition.Name = "lblCondition"
        Me.lblCondition.Size = New System.Drawing.Size(63, 14)
        Me.lblCondition.TabIndex = 14
        Me.lblCondition.Text = "Comparison"
        '
        'cmbFields
        '
        Me.cmbFields.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbFields.DisplayMember = "Text"
        Me.cmbFields.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.cmbFields.ItemHeight = 13
        Me.cmbFields.Location = New System.Drawing.Point(16, 40)
        Me.cmbFields.Name = "cmbFields"
        Me.cmbFields.Size = New System.Drawing.Size(120, 21)
        Me.cmbFields.TabIndex = 18
        Me.cmbFields.ValueMember = "Value"
        '
        'lblValue2
        '
        Me.lblValue2.AutoSize = True
        Me.lblValue2.Enabled = False
        Me.lblValue2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblValue2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.lblValue2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblValue2.Location = New System.Drawing.Point(248, 64)
        Me.lblValue2.Name = "lblValue2"
        Me.lblValue2.Size = New System.Drawing.Size(45, 14)
        Me.lblValue2.TabIndex = 15
        Me.lblValue2.Text = "Value 2:"
        '
        'txtValue1
        '
        Me.txtValue1.Enabled = False
        Me.txtValue1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.txtValue1.Location = New System.Drawing.Point(248, 40)
        Me.txtValue1.Name = "txtValue1"
        Me.txtValue1.Size = New System.Drawing.Size(136, 21)
        Me.txtValue1.TabIndex = 20
        Me.txtValue1.Text = ""
        '
        'cmbCondition
        '
        Me.cmbCondition.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbCondition.Enabled = False
        Me.cmbCondition.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.cmbCondition.ItemHeight = 13
        Me.cmbCondition.Location = New System.Drawing.Point(144, 40)
        Me.cmbCondition.Name = "cmbCondition"
        Me.cmbCondition.Size = New System.Drawing.Size(96, 21)
        Me.cmbCondition.TabIndex = 17
        '
        'tabPage3
        '
        Me.tabPage3.BackColor = System.Drawing.SystemColors.Menu
        Me.tabPage3.Controls.AddRange(New System.Windows.Forms.Control() {Me.groupRowStyle})
        Me.tabPage3.Cursor = System.Windows.Forms.Cursors.Default
        Me.tabPage3.ImageIndex = 1
        Me.tabPage3.Location = New System.Drawing.Point(4, 23)
        Me.tabPage3.Name = "tabPage3"
        Me.tabPage3.Size = New System.Drawing.Size(408, 197)
        Me.tabPage3.TabIndex = 2
        Me.tabPage3.Text = "Appearance"
        Me.tabPage3.Visible = False
        '
        'groupRowStyle
        '
        Me.groupRowStyle.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnEmptyBackColor2, Me.btnEmptyBackColor, Me.btnEmptyForeColor, Me.lblBkgColor2, Me.btnBkgColor2, Me.lblBkgColor1, Me.btnBkgColor1, Me.lblTextColor, Me.cmbItemBkgStyle, Me.label8, Me.label5, Me.label4, Me.label3, Me.btnTextColor, Me.chbUnderline, Me.chbStrikeout, Me.chbItalic, Me.chbBold, Me.label11})
        Me.groupRowStyle.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.groupRowStyle.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.groupRowStyle.Location = New System.Drawing.Point(8, 8)
        Me.groupRowStyle.Name = "groupRowStyle"
        Me.groupRowStyle.Size = New System.Drawing.Size(388, 183)
        Me.groupRowStyle.TabIndex = 0
        Me.groupRowStyle.TabStop = False
        Me.groupRowStyle.Text = "Row Style:"
        '
        'btnEmptyBackColor2
        '
        Me.btnEmptyBackColor2.BackColor = System.Drawing.SystemColors.Control
        Me.btnEmptyBackColor2.Font = New System.Drawing.Font("Marlett", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btnEmptyBackColor2.Location = New System.Drawing.Point(320, 138)
        Me.btnEmptyBackColor2.Name = "btnEmptyBackColor2"
        Me.btnEmptyBackColor2.Size = New System.Drawing.Size(20, 20)
        Me.btnEmptyBackColor2.TabIndex = 50
        Me.btnEmptyBackColor2.Text = "r"
        Me.btnEmptyBackColor2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnEmptyBackColor
        '
        Me.btnEmptyBackColor.BackColor = System.Drawing.SystemColors.Control
        Me.btnEmptyBackColor.Font = New System.Drawing.Font("Marlett", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btnEmptyBackColor.Location = New System.Drawing.Point(128, 142)
        Me.btnEmptyBackColor.Name = "btnEmptyBackColor"
        Me.btnEmptyBackColor.Size = New System.Drawing.Size(20, 20)
        Me.btnEmptyBackColor.TabIndex = 49
        Me.btnEmptyBackColor.Text = "r"
        Me.btnEmptyBackColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnEmptyForeColor
        '
        Me.btnEmptyForeColor.BackColor = System.Drawing.SystemColors.Control
        Me.btnEmptyForeColor.Font = New System.Drawing.Font("Marlett", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btnEmptyForeColor.Location = New System.Drawing.Point(104, 56)
        Me.btnEmptyForeColor.Name = "btnEmptyForeColor"
        Me.btnEmptyForeColor.Size = New System.Drawing.Size(20, 20)
        Me.btnEmptyForeColor.TabIndex = 48
        Me.btnEmptyForeColor.Text = "r"
        Me.btnEmptyForeColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBkgColor2
        '
        Me.lblBkgColor2.BackColor = System.Drawing.Color.White
        Me.lblBkgColor2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBkgColor2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblBkgColor2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblBkgColor2.Font = New System.Drawing.Font("Tahoma", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBkgColor2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblBkgColor2.Location = New System.Drawing.Point(284, 142)
        Me.lblBkgColor2.Name = "lblBkgColor2"
        Me.lblBkgColor2.Size = New System.Drawing.Size(12, 12)
        Me.lblBkgColor2.TabIndex = 47
        Me.lblBkgColor2.Text = "///"
        '
        'btnBkgColor2
        '
        Me.btnBkgColor2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBkgColor2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnBkgColor2.Font = New System.Drawing.Font("Tahoma", 6.0!, System.Drawing.FontStyle.Bold)
        Me.btnBkgColor2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnBkgColor2.Location = New System.Drawing.Point(280, 138)
        Me.btnBkgColor2.Name = "btnBkgColor2"
        Me.btnBkgColor2.Size = New System.Drawing.Size(40, 20)
        Me.btnBkgColor2.TabIndex = 46
        Me.btnBkgColor2.Text = "..."
        Me.btnBkgColor2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblBkgColor1
        '
        Me.lblBkgColor1.BackColor = System.Drawing.Color.White
        Me.lblBkgColor1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBkgColor1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblBkgColor1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblBkgColor1.Font = New System.Drawing.Font("Tahoma", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBkgColor1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblBkgColor1.Location = New System.Drawing.Point(92, 146)
        Me.lblBkgColor1.Name = "lblBkgColor1"
        Me.lblBkgColor1.Size = New System.Drawing.Size(12, 12)
        Me.lblBkgColor1.TabIndex = 45
        Me.lblBkgColor1.Text = "///"
        '
        'btnBkgColor1
        '
        Me.btnBkgColor1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBkgColor1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnBkgColor1.Font = New System.Drawing.Font("Tahoma", 6.0!, System.Drawing.FontStyle.Bold)
        Me.btnBkgColor1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnBkgColor1.Location = New System.Drawing.Point(88, 142)
        Me.btnBkgColor1.Name = "btnBkgColor1"
        Me.btnBkgColor1.Size = New System.Drawing.Size(40, 20)
        Me.btnBkgColor1.TabIndex = 44
        Me.btnBkgColor1.Text = "..."
        Me.btnBkgColor1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTextColor
        '
        Me.lblTextColor.BackColor = System.Drawing.Color.White
        Me.lblTextColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTextColor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblTextColor.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblTextColor.Font = New System.Drawing.Font("Tahoma", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextColor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTextColor.Location = New System.Drawing.Point(77, 60)
        Me.lblTextColor.Name = "lblTextColor"
        Me.lblTextColor.Size = New System.Drawing.Size(12, 12)
        Me.lblTextColor.TabIndex = 43
        Me.lblTextColor.Text = "///"
        Me.lblTextColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbItemBkgStyle
        '
        Me.cmbItemBkgStyle.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbItemBkgStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbItemBkgStyle.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.cmbItemBkgStyle.ItemHeight = 13
        Me.cmbItemBkgStyle.Location = New System.Drawing.Point(57, 111)
        Me.cmbItemBkgStyle.Name = "cmbItemBkgStyle"
        Me.cmbItemBkgStyle.Size = New System.Drawing.Size(172, 21)
        Me.cmbItemBkgStyle.TabIndex = 42
        '
        'label8
        '
        Me.label8.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.label8.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.label8.Location = New System.Drawing.Point(9, 144)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(70, 16)
        Me.label8.TabIndex = 41
        Me.label8.Text = "Background:"
        '
        'label5
        '
        Me.label5.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.label5.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.label5.Location = New System.Drawing.Point(158, 143)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(110, 16)
        Me.label5.TabIndex = 39
        Me.label5.Text = "Gradient Background:"
        '
        'label4
        '
        Me.label4.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.label4.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.label4.Location = New System.Drawing.Point(9, 87)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(112, 16)
        Me.label4.TabIndex = 38
        Me.label4.Text = "Background Style:"
        '
        'label3
        '
        Me.label3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.label3.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.label3.Location = New System.Drawing.Point(9, 60)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(64, 12)
        Me.label3.TabIndex = 37
        Me.label3.Text = "Text Color:"
        '
        'btnTextColor
        '
        Me.btnTextColor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTextColor.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnTextColor.Font = New System.Drawing.Font("Tahoma", 6.0!, System.Drawing.FontStyle.Bold)
        Me.btnTextColor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnTextColor.Location = New System.Drawing.Point(73, 56)
        Me.btnTextColor.Name = "btnTextColor"
        Me.btnTextColor.Size = New System.Drawing.Size(31, 20)
        Me.btnTextColor.TabIndex = 35
        Me.btnTextColor.Text = "..."
        Me.btnTextColor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chbUnderline
        '
        Me.chbUnderline.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chbUnderline.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chbUnderline.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Underline)
        Me.chbUnderline.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chbUnderline.Location = New System.Drawing.Point(196, 28)
        Me.chbUnderline.Name = "chbUnderline"
        Me.chbUnderline.Size = New System.Drawing.Size(68, 16)
        Me.chbUnderline.TabIndex = 34
        Me.chbUnderline.Text = "Underline"
        Me.chbUnderline.ThreeState = True
        '
        'chbStrikeout
        '
        Me.chbStrikeout.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chbStrikeout.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chbStrikeout.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Strikeout)
        Me.chbStrikeout.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chbStrikeout.Location = New System.Drawing.Point(124, 28)
        Me.chbStrikeout.Name = "chbStrikeout"
        Me.chbStrikeout.Size = New System.Drawing.Size(64, 16)
        Me.chbStrikeout.TabIndex = 33
        Me.chbStrikeout.Text = "Strikeout"
        Me.chbStrikeout.ThreeState = True
        '
        'chbItalic
        '
        Me.chbItalic.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chbItalic.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chbItalic.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic)
        Me.chbItalic.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chbItalic.Location = New System.Drawing.Point(72, 28)
        Me.chbItalic.Name = "chbItalic"
        Me.chbItalic.Size = New System.Drawing.Size(48, 16)
        Me.chbItalic.TabIndex = 32
        Me.chbItalic.Text = "Italic"
        Me.chbItalic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chbItalic.ThreeState = True
        '
        'chbBold
        '
        Me.chbBold.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chbBold.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chbBold.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.chbBold.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chbBold.Location = New System.Drawing.Point(8, 28)
        Me.chbBold.Name = "chbBold"
        Me.chbBold.Size = New System.Drawing.Size(52, 16)
        Me.chbBold.TabIndex = 31
        Me.chbBold.Text = "Bold"
        Me.chbBold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chbBold.ThreeState = True
        '
        'label11
        '
        Me.label11.AutoSize = True
        Me.label11.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.label11.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.label11.Location = New System.Drawing.Point(9, 115)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(51, 14)
        Me.label11.TabIndex = 38
        Me.label11.Text = "Gradient:"
        '
        'label7
        '
        Me.label7.BackColor = System.Drawing.SystemColors.ControlDark
        Me.label7.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.label7.Location = New System.Drawing.Point(4, 5)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(416, 16)
        Me.label7.TabIndex = 30
        Me.label7.Text = "Rules for this view:"
        '
        'label6
        '
        Me.label6.BackColor = System.Drawing.SystemColors.ControlDark
        Me.label6.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.label6.Location = New System.Drawing.Point(4, 189)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(416, 16)
        Me.label6.TabIndex = 29
        Me.label6.Text = "Properties of selected rule:"
        '
        'btnAdd
        '
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnAdd.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAdd.Location = New System.Drawing.Point(324, 29)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(96, 24)
        Me.btnAdd.TabIndex = 27
        Me.btnAdd.Text = "Add"
        '
        'btnDelete
        '
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnDelete.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnDelete.Location = New System.Drawing.Point(324, 61)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(96, 24)
        Me.btnDelete.TabIndex = 23
        Me.btnDelete.Text = "Delete"
        '
        'btnMoveUp
        '
        Me.btnMoveUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnMoveUp.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnMoveUp.Location = New System.Drawing.Point(324, 93)
        Me.btnMoveUp.Name = "btnMoveUp"
        Me.btnMoveUp.Size = New System.Drawing.Size(96, 24)
        Me.btnMoveUp.TabIndex = 22
        Me.btnMoveUp.Text = "Move Up"
        Me.btnMoveUp.Visible = False
        '
        'btnMoveDown
        '
        Me.btnMoveDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnMoveDown.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnMoveDown.Location = New System.Drawing.Point(324, 125)
        Me.btnMoveDown.Name = "btnMoveDown"
        Me.btnMoveDown.Size = New System.Drawing.Size(96, 24)
        Me.btnMoveDown.TabIndex = 24
        Me.btnMoveDown.Text = "Move Down"
        Me.btnMoveDown.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancel.Location = New System.Drawing.Point(340, 445)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 24)
        Me.btnCancel.TabIndex = 26
        Me.btnCancel.Text = "Cancel"
        '
        'btnOK
        '
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnOK.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnOK.Location = New System.Drawing.Point(252, 445)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(80, 24)
        Me.btnOK.TabIndex = 25
        Me.btnOK.Text = "OK"
        '
        'jsgConditions
        '
        Me.jsgConditions.ColumnAutoResize = True
        Me.jsgConditions.Cursor = System.Windows.Forms.Cursors.Default
        Me.jsgConditions.ExternalImageList = Me.icons
        Me.jsgConditions.GroupByBoxVisible = False
        Me.jsgConditions.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight
        Me.jsgConditions.LayoutData = "<GridEXLayoutData><PersistenceMode>TableStructure, DropDowns, FormatStyles, Inter" & _
        "nalImageList</PersistenceMode><RootTable><Columns Collection=""true""><Column0 ID=" & _
        """Selector""><AllowSize>False</AllowSize><AllowSort>False</AllowSort><Key>Selector" & _
        "</Key><Position>0</Position><Width>22</Width><ActAsSelector>True</ActAsSelector>" & _
        "</Column0><Column1 ID=""Icon""><AllowDrag>False</AllowDrag><AllowGroup>False</Allo" & _
        "wGroup><AllowSize>False</AllowSize><AllowSort>False</AllowSort><ColumnType>Image" & _
        "</ColumnType><ImageIndex>0</ImageIndex><Key>Icon</Key><Position>1</Position><Sel" & _
        "ectable>False</Selectable><Width>22</Width></Column1><Column2 ID=""Text""><AllowSo" & _
        "rt>False</AllowSort><DataMember>Key</DataMember><Key>Text</Key><Position>2</Posi" & _
        "tion><Selectable>False</Selectable><Width>267</Width></Column2></Columns><GroupC" & _
        "ondition ID="""" /></RootTable></GridEXLayoutData>"
        Me.jsgConditions.Location = New System.Drawing.Point(6, 28)
        Me.jsgConditions.Name = "jsgConditions"
        Me.jsgConditions.Size = New System.Drawing.Size(313, 154)
        Me.jsgConditions.TabIndex = 32
        '
        'frmFormatConditions
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(426, 475)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.jsgConditions, Me.tabControl1, Me.label7, Me.label6, Me.btnAdd, Me.btnDelete, Me.btnMoveUp, Me.btnMoveDown, Me.btnCancel, Me.btnOK})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmFormatConditions"
        Me.Text = "Automatic Formatting"
        Me.tabControl1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.grpConditionName.ResumeLayout(False)
        Me.groupConditionCriteria.ResumeLayout(False)
        Me.tabPage3.ResumeLayout(False)
        Me.groupRowStyle.ResumeLayout(False)
        CType(Me.jsgConditions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim mTable As GridEXTable
    Dim tempConditions As ArrayList

    Private Sub PopulateEnumCombo(ByVal combo As ComboBox, ByVal enumType As Type)
        Dim values As Array
        values = System.Enum.GetValues(enumType)
        Dim value As Object
        For Each value In values
            combo.Items.Add(value)
        Next
    End Sub
    Private Sub PopulateCombos()

        Dim column As GridEXColumn
        Dim columnList As ArrayList
        columnList = New ArrayList

        For Each column In mTable.Columns
            columnList.Add(New NamedObject(column, column.Caption))
            'Me.cmbFields.Items.Add()
        Next
        Me.cmbFields.DataSource = columnList
        Me.cmbFields.ValueMember = "Value"
        Me.cmbFields.DisplayMember = "Name"
        Me.PopulateEnumCombo(cmbCondition, ConditionOperator.Equal.GetType())
        Me.PopulateEnumCombo(cmbItemBkgStyle, Janus.Windows.GridEX.BackgroundGradientMode.Empty.GetType())

    End Sub
    Public Sub ShowFormatConditionsForm(ByVal table As GridEXTable)
        mTable = table
        PopulateCombos()
        PopulateFormatConditionsList()
        OnActiveConditionChanged()
        ShowDialog()
    End Sub
    Private Sub PopulateFormatConditionsList()
        tempConditions = New ArrayList
        Dim condition As GridEXFormatCondition
        For Each condition In mTable.FormatConditions
            tempConditions.Add(condition)
        Next
        Me.jsgConditions.SetDataBinding(tempConditions, "")

    End Sub
    Private twoValues As Boolean
    Private Sub cmbCondition_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCondition.SelectedIndexChanged
        If Not cmbCondition.SelectedItem Is Nothing Then
            Select Case CType(cmbCondition.SelectedItem, ConditionOperator)
                Case ConditionOperator.Between, ConditionOperator.NotBetween
                    txtValue2.Enabled = True
                    lblValue2.Enabled = True
                    twoValues = True

                Case Else
                    txtValue2.Text = ""
                    txtValue2.Enabled = False
                    lblValue2.Enabled = False
                    twoValues = False

            End Select
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim condition As New GridEXFormatCondition
        condition.Key = "Untitled"
        Me.tempConditions.Add(condition)
        Me.jsgConditions.Refetch()
        Me.jsgConditions.Row = Me.jsgConditions.RecordCount - 1
        Me.jsgConditions.Focus()
    End Sub

    Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        GetConditionValues()
        mTable.FormatConditions.Clear()
        Dim condition As GridEXFormatCondition
        For Each condition In tempConditions
            mTable.FormatConditions.Add(condition)
        Next
        Close()
    End Sub

    Private mActiveCondition As GridEXFormatCondition
    Private Property ActiveCondition() As GridEXFormatCondition
        Get
            Return mActiveCondition
        End Get
        Set(ByVal Value As GridEXFormatCondition)
            If Not Value Is mActiveCondition Then
                If Not mActiveCondition Is Nothing Then
                    Me.GetConditionValues()
                End If
                mActiveCondition = Value
                OnActiveConditionChanged()
            End If
        End Set
    End Property
    Private Sub SetColorToLabel(ByVal label As Label, ByVal color As Color)
        If color.IsEmpty Then
            label.BackColor = System.Drawing.Color.White
            label.ForeColor = System.Drawing.Color.Gray
        Else
            label.BackColor = color
            label.ForeColor = color
        End If
    End Sub
    Private Sub OnActiveConditionChanged()
        If mActiveCondition Is Nothing Then
            Me.grpConditionName.Enabled = False
            Me.groupConditionCriteria.Enabled = False
            Me.groupRowStyle.Enabled = False
            Me.txtName.Text = ""
            Me.cmbFields.SelectedItem = Nothing
            Me.cmbCondition.SelectedValue = Nothing
            Me.cmbItemBkgStyle.SelectedValue = Nothing
            Me.txtValue1.Text = ""
            Me.txtValue2.Text = ""
            Me.SetColorToLabel(Me.lblTextColor, Color.Empty)
            Me.SetColorToLabel(Me.lblBkgColor1, Color.Empty)
            Me.SetColorToLabel(Me.lblBkgColor2, Color.Empty)
            Me.chbBold.CheckState = CheckState.Indeterminate
            Me.chbItalic.CheckState = CheckState.Indeterminate
            Me.chbUnderline.CheckState = CheckState.Indeterminate
            Me.chbStrikeout.CheckState = CheckState.Indeterminate
        Else
            Me.grpConditionName.Enabled = True
            Me.groupConditionCriteria.Enabled = True
            Me.groupRowStyle.Enabled = True
            Me.txtName.Text = mActiveCondition.Key
            If mActiveCondition.Column Is Nothing Then
                Me.cmbFields.SelectedIndex = -1
            Else
                Me.cmbFields.SelectedValue = mActiveCondition.Column
            End If
            Me.cmbCondition.SelectedValue = mActiveCondition.ConditionOperator
            Me.cmbItemBkgStyle.SelectedItem = mActiveCondition.FormatStyle.BackgroundGradientMode
            Me.txtValue1.Text = mActiveCondition.Value1 & ""
            Me.txtValue2.Text = mActiveCondition.Value2 & ""
            Me.SetColorToLabel(Me.lblTextColor, mActiveCondition.FormatStyle.ForeColor)
            Me.SetColorToLabel(Me.lblBkgColor1, mActiveCondition.FormatStyle.BackColor)
            Me.SetColorToLabel(Me.lblBkgColor2, mActiveCondition.FormatStyle.BackColorGradient)
            SetCheckBoxValue(chbBold, mActiveCondition.FormatStyle.FontBold)
            SetCheckBoxValue(chbItalic, mActiveCondition.FormatStyle.FontItalic)
            SetCheckBoxValue(chbUnderline, mActiveCondition.FormatStyle.FontUnderline)
            SetCheckBoxValue(chbStrikeout, mActiveCondition.FormatStyle.FontStrikeout)
        End If
    End Sub

    Private Sub SetCheckBoxValue(ByVal chk As CheckBox, ByVal value As Janus.Windows.GridEX.TriState)
        Select Case value
            Case Janus.Windows.GridEX.TriState.Empty
                chk.CheckState = CheckState.Indeterminate
            Case Janus.Windows.GridEX.TriState.True
                chk.CheckState = CheckState.Checked
            Case Janus.Windows.GridEX.TriState.False
                chk.CheckState = CheckState.Unchecked
        End Select
    End Sub
    'Private Sub SelectItem(ByVal item As ListViewItem, ByVal condition As GridEXFormatCondition)
    '    If Not mActiveCondition Is Nothing Then
    '        GetConditionValues()
    '    End If
    '    mActiveCondition = condition
    '    If Not condition Is Nothing Then
    '        Me.txtName.Text = condition.Key
    '        Me.cmbFields.SelectedItem = condition.Column
    '        Me.cmbCondition.SelectedItem = condition.ConditionOperator
    '        If Not condition.Value1 Is Nothing Then
    '            Me.txtValue1.Text = condition.Value1.ToString()
    '        Else
    '            Me.txtValue1.Text = ""
    '        End If
    '        If (Not condition.Value2 Is Nothing) AndAlso (condition.ConditionOperator = ConditionOperator.Between OrElse condition.ConditionOperator = ConditionOperator.NotBetween) Then
    '            txtValue2.Text = condition.Value2.ToString()
    '        Else
    '            txtValue2.Text = ""
    '        End If

    '        Me.SetCheckBoxValue(chbBold, condition.FormatStyle.FontBold)
    '        Me.SetCheckBoxValue(chbItalic, condition.FormatStyle.FontItalic)
    '        Me.SetCheckBoxValue(chbStrikeout, condition.FormatStyle.FontStrikeout)
    '        Me.SetCheckBoxValue(chbUnderline, condition.FormatStyle.FontUnderline)


    '        lblTextColor.BackColor = condition.FormatStyle.ForeColor
    '        lblBkgColor1.BackColor = condition.FormatStyle.BackColor
    '        lblBkgColor2.BackColor = condition.FormatStyle.BackColorGradient
    '        cmbItemBkgStyle.SelectedItem = condition.FormatStyle.BackgroundGradientMode


    '        If item.Index = 0 Then
    '            Me.btnMoveUp.Enabled = False
    '        Else
    '            Me.btnMoveUp.Enabled = True
    '        End If

    '        If item.Index = listView1.Items.Count - 1 Then
    '            btnMoveDown.Enabled = False
    '        Else
    '            btnMoveDown.Enabled = True
    '        End If
    '    Else
    '        Me.txtName.Text = ""
    '        Me.cmbFields.SelectedItem = Nothing
    '    End If
    'End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub cmbFields_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbFields.SelectedIndexChanged
        Dim controlsEnabled As Boolean
        If Not cmbFields.SelectedItem Is Nothing Then
            If mActiveCondition Is Nothing Then
                controlsEnabled = False
                cmbCondition.SelectedItem = Nothing
            Else
                controlsEnabled = True
                If cmbCondition.SelectedItem Is Nothing Then
                    cmbCondition.SelectedItem = mActiveCondition.ConditionOperator
                End If
            End If
        Else
            cmbCondition.SelectedItem = Nothing
        End If
        txtValue1.Enabled = controlsEnabled
        cmbCondition.Enabled = controlsEnabled
        lblCondition.Enabled = controlsEnabled
        lblValue1.Enabled = controlsEnabled
    End Sub

    Private Function GetConditionValues() As Boolean
        If Not mActiveCondition Is Nothing Then
            Dim column As GridEXColumn = CType(Me.cmbFields.SelectedValue, GridEXColumn)
            Try
                Dim value1 As Object = Convert.ChangeType(txtValue1.Text, column.Type)
                mActiveCondition.Value1 = value1
            Catch
                MessageBox.Show("Value 1 is not valid", "Журнал")
                txtValue1.Focus()
                txtValue1.SelectionStart = txtValue1.Text.Length
                txtValue1.ScrollToCaret()
                Return False
            End Try

            If (twoValues) Then

                Try
                    Dim value2 As Object = Convert.ChangeType(txtValue2.Text, column.Type)
                    mActiveCondition.Value2 = value2
                Catch
                    MessageBox.Show("Value 2 is not valid", "Журнал")
                    txtValue2.SelectionStart = 0
                    txtValue2.ScrollToCaret()
                    Return False

                End Try
            Else

                mActiveCondition.Value2 = Nothing
            End If
            mActiveCondition.Key = txtName.Text
            mActiveCondition.Column = column
            mActiveCondition.ConditionOperator = CType(Me.cmbCondition.SelectedItem, ConditionOperator)
            mActiveCondition.FormatStyle.FontBold = Me.CheckStateToTriState(Me.chbBold.CheckState)
            mActiveCondition.FormatStyle.FontItalic = Me.CheckStateToTriState(Me.chbItalic.CheckState)
            mActiveCondition.FormatStyle.FontUnderline = Me.CheckStateToTriState(Me.chbUnderline.CheckState)
            mActiveCondition.FormatStyle.FontStrikeout = Me.CheckStateToTriState(Me.chbStrikeout.CheckState)
            mActiveCondition.FormatStyle.BackgroundGradientMode = CType(Me.cmbItemBkgStyle.SelectedItem, Janus.Windows.GridEX.BackgroundGradientMode)
        End If
        Return True
    End Function

    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Me.jsgConditions.AllowDelete = InheritableBoolean.True
        Me.jsgConditions.Delete()
        Me.jsgConditions.AllowDelete = InheritableBoolean.False

    End Sub



    Private Sub cmbItemBkgStyle_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbItemBkgStyle.SelectedIndexChanged
        If Not mActiveCondition Is Nothing Then
            mActiveCondition.FormatStyle.BackgroundGradientMode = CType(cmbItemBkgStyle.SelectedItem, Janus.Windows.GridEX.BackgroundGradientMode)
        End If
    End Sub

    Private Function CheckStateToTriState(ByVal state As CheckState) As Janus.Windows.GridEX.TriState
        Select Case state
            Case CheckState.Checked
                Return Janus.Windows.GridEX.TriState.True
            Case CheckState.Indeterminate
                Return Janus.Windows.GridEX.TriState.Empty
            Case CheckState.Unchecked
                Return Janus.Windows.GridEX.TriState.False
        End Select
    End Function



    Private Sub txtName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
        If Not mActiveCondition Is Nothing Then
            Me.ActiveCondition.Key = txtName.Text
            Me.jsgConditions.Refresh()
        End If
    End Sub

    Private Sub jsgConditions_LoadingRow(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.RowLoadEventArgs) Handles jsgConditions.LoadingRow
        If e.Row.RowType = RowType.Record Then
            e.Row.IsChecked = CType(e.Row.DataRow, GridEXFormatCondition).Enabled
        End If
    End Sub

    Private Sub jsgConditions_UpdatingRecord(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles jsgConditions.UpdatingRecord
        Dim row As GridEXRow
        row = jsgConditions.GetRow()
        CType(row.DataRow, GridEXFormatCondition).Enabled = row.IsChecked

    End Sub

    Private Sub jsgConditions_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles jsgConditions.SelectionChanged
        If Me.jsgConditions.Row <> -1 Then
            ActiveCondition = CType(jsgConditions.GetRow().DataRow, GridEXFormatCondition)
        End If
    End Sub


    Private Sub jsgConditions_FormattingRow(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.RowLoadEventArgs) Handles jsgConditions.FormattingRow
        If e.Row.RowType = RowType.Record Then
            Dim formatCondition As GridEXFormatCondition = CType(e.Row.DataRow, GridEXFormatCondition)
            e.Row.RowStyle = New GridEXFormatStyle(formatCondition.FormatStyle)
        End If
    End Sub
    Private Sub TextColorClick(ByVal sender As Object, ByVal e As EventArgs) Handles lblTextColor.Click, btnTextColor.Click
        If mActiveCondition.FormatStyle.ForeColor.IsEmpty Then
            Me.cldStyle.Color = Color.White
        Else
            Me.cldStyle.Color = mActiveCondition.FormatStyle.ForeColor
        End If
        If Me.cldStyle.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Me.mActiveCondition.FormatStyle.ForeColor = cldStyle.Color
            Me.SetColorToLabel(Me.lblTextColor, mActiveCondition.FormatStyle.ForeColor)
        End If
    End Sub

    Private Sub btnEmptyForeColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmptyForeColor.Click
        Me.mActiveCondition.FormatStyle.ForeColor = Color.Empty
        Me.SetColorToLabel(Me.lblTextColor, Color.Empty)
    End Sub

    Private Sub btnEmptyBackColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmptyBackColor.Click
        Me.mActiveCondition.FormatStyle.BackColor = Color.Empty
        Me.SetColorToLabel(Me.lblBkgColor1, Color.Empty)
    End Sub

    Private Sub btnEmptyBackColor2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmptyBackColor2.Click
        Me.mActiveCondition.FormatStyle.BackColorGradient = Color.Empty
        Me.SetColorToLabel(Me.lblBkgColor2, Color.Empty)
    End Sub
    Private Sub BackColorClick(ByVal sender As Object, ByVal e As EventArgs) Handles lblBkgColor1.Click, btnBkgColor1.Click

        Me.cldStyle.Color = mActiveCondition.FormatStyle.BackColor
        If Me.cldStyle.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Me.mActiveCondition.FormatStyle.BackColor = cldStyle.Color
            Me.SetColorToLabel(Me.lblBkgColor1, Me.mActiveCondition.FormatStyle.BackColor)
        End If
    End Sub
    Private Sub BackColor2Click(ByVal sender As Object, ByVal e As EventArgs) Handles lblBkgColor2.Click, btnBkgColor2.Click
        Me.cldStyle.Color = mActiveCondition.FormatStyle.BackColor
        If Me.cldStyle.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Me.mActiveCondition.FormatStyle.BackColorGradient = cldStyle.Color
            Me.SetColorToLabel(Me.lblBkgColor2, Me.mActiveCondition.FormatStyle.BackColorGradient)
        End If
    End Sub
End Class
