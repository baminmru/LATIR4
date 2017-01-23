
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Поле режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editFIELD
    Inherits System.Windows.Forms.UserControl
    Implements LATIR2GUIManager.IRowEditor

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub
    private mOnInit as boolean = false
    private mChanged as boolean = false
    public event Changed() Implements LATIR2GUIManager.IRowEditor.Changed 
    Public Event Saved() Implements LATIR2GUIManager.IRowEditor.Saved
    Public Event Refreshed() Implements LATIR2GUIManager.IRowEditor.Refreshed
    Public Sub Changing()
      if not mOnInit then
        mChanged = true
        raiseevent Changed()
      end if
    End Sub

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose (disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

 Dim iii As Integer
    Friend WithEvents HolderPanel As LATIR2GUIControls.AutoPanel
Friend WithEvents lblTabName  as  System.Windows.Forms.Label
Friend WithEvents txtTabName As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblFieldGroupBox  as  System.Windows.Forms.Label
Friend WithEvents txtFieldGroupBox As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblSequence  as  System.Windows.Forms.Label
Friend WithEvents txtSequence As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblCaption  as  System.Windows.Forms.Label
Friend WithEvents txtCaption As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblName  as  System.Windows.Forms.Label
Friend WithEvents txtName As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblFieldType  as  System.Windows.Forms.Label
Friend WithEvents txtFieldType As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdFieldType As System.Windows.Forms.Button
Friend WithEvents lblIsBrief  as  System.Windows.Forms.Label
Friend WithEvents cmbIsBrief As System.Windows.Forms.ComboBox
Friend cmbIsBriefDATA As DataTable
Friend cmbIsBriefDATAROW As DataRow
Friend WithEvents lblIsTabBrief  as  System.Windows.Forms.Label
Friend WithEvents cmbIsTabBrief As System.Windows.Forms.ComboBox
Friend cmbIsTabBriefDATA As DataTable
Friend cmbIsTabBriefDATAROW As DataRow
Friend WithEvents lblAllowNull  as  System.Windows.Forms.Label
Friend WithEvents cmbAllowNull As System.Windows.Forms.ComboBox
Friend cmbAllowNullDATA As DataTable
Friend cmbAllowNullDATAROW As DataRow
Friend WithEvents lblDataSize  as  System.Windows.Forms.Label
Friend WithEvents txtDataSize As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblReferenceType  as  System.Windows.Forms.Label
Friend WithEvents cmbReferenceType As System.Windows.Forms.ComboBox
Friend cmbReferenceTypeDATA As DataTable
Friend cmbReferenceTypeDATAROW As DataRow
Friend WithEvents lblRefToType  as  System.Windows.Forms.Label
Friend WithEvents txtRefToType As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdRefToType As System.Windows.Forms.Button
Friend WithEvents cmdRefToTypeClear As System.Windows.Forms.Button
Friend WithEvents lblRefToPart  as  System.Windows.Forms.Label
Friend WithEvents txtRefToPart As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdRefToPart As System.Windows.Forms.Button
Friend WithEvents cmdRefToPartClear As System.Windows.Forms.Button
Friend WithEvents lblTheStyle  as  System.Windows.Forms.Label
Friend WithEvents txtTheStyle As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblInternalReference  as  System.Windows.Forms.Label
Friend WithEvents cmbInternalReference As System.Windows.Forms.ComboBox
Friend cmbInternalReferenceDATA As DataTable
Friend cmbInternalReferenceDATAROW As DataRow
Friend WithEvents lblCreateRefOnly  as  System.Windows.Forms.Label
Friend WithEvents cmbCreateRefOnly As System.Windows.Forms.ComboBox
Friend cmbCreateRefOnlyDATA As DataTable
Friend cmbCreateRefOnlyDATAROW As DataRow
Friend WithEvents lblIsAutoNumber  as  System.Windows.Forms.Label
Friend WithEvents cmbIsAutoNumber As System.Windows.Forms.ComboBox
Friend cmbIsAutoNumberDATA As DataTable
Friend cmbIsAutoNumberDATAROW As DataRow
Friend WithEvents lblTheNumerator  as  System.Windows.Forms.Label
Friend WithEvents txtTheNumerator As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdTheNumerator As System.Windows.Forms.Button
Friend WithEvents cmdTheNumeratorClear As System.Windows.Forms.Button
Friend WithEvents lblZoneTemplate  as  System.Windows.Forms.Label
Friend WithEvents txtZoneTemplate As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblNumberDateField  as  System.Windows.Forms.Label
Friend WithEvents txtNumberDateField As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdNumberDateField As System.Windows.Forms.Button
Friend WithEvents cmdNumberDateFieldClear As System.Windows.Forms.Button
Friend WithEvents lblTheComment  as  System.Windows.Forms.Label
Friend WithEvents txtTheComment As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblshablonBrief  as  System.Windows.Forms.Label
Friend WithEvents txtshablonBrief As LATIR2GuiManager.TouchTextBox
Friend WithEvents lbltheNameClass  as  System.Windows.Forms.Label
Friend WithEvents txttheNameClass As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblTheMask  as  System.Windows.Forms.Label
Friend WithEvents txtTheMask As LATIR2GuiManager.TouchTextBox

<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

 Me.HolderPanel = New LATIR2GUIControls.AutoPanel
 Me.HolderPanel.SuspendLayout()
Me.SuspendLayout()
 '
'HolderPanel
'
Me.HolderPanel.AllowDrop = True
Me.HolderPanel.BackColor = System.Drawing.SystemColors.Control
Me.HolderPanel.Dock = System.Windows.Forms.DockStyle.Fill
Me.HolderPanel.Location = New System.Drawing.Point(0, 0)
Me.HolderPanel.Name = "HolderPanel"
Me.HolderPanel.Size = New System.Drawing.Size(232, 120)
Me.HolderPanel.TabIndex = 0
Me.lblTabName = New System.Windows.Forms.Label
Me.txtTabName = New LATIR2GuiManager.TouchTextBox
Me.lblFieldGroupBox = New System.Windows.Forms.Label
Me.txtFieldGroupBox = New LATIR2GuiManager.TouchTextBox
Me.lblSequence = New System.Windows.Forms.Label
Me.txtSequence = New LATIR2GuiManager.TouchTextBox
Me.lblCaption = New System.Windows.Forms.Label
Me.txtCaption = New LATIR2GuiManager.TouchTextBox
Me.lblName = New System.Windows.Forms.Label
Me.txtName = New LATIR2GuiManager.TouchTextBox
Me.lblFieldType = New System.Windows.Forms.Label
Me.txtFieldType = New LATIR2GuiManager.TouchTextBox
Me.cmdFieldType = New System.Windows.Forms.Button
Me.lblIsBrief = New System.Windows.Forms.Label
Me.cmbIsBrief = New System.Windows.Forms.ComboBox
Me.lblIsTabBrief = New System.Windows.Forms.Label
Me.cmbIsTabBrief = New System.Windows.Forms.ComboBox
Me.lblAllowNull = New System.Windows.Forms.Label
Me.cmbAllowNull = New System.Windows.Forms.ComboBox
Me.lblDataSize = New System.Windows.Forms.Label
Me.txtDataSize = New LATIR2GuiManager.TouchTextBox
Me.lblReferenceType = New System.Windows.Forms.Label
Me.cmbReferenceType = New System.Windows.Forms.ComboBox
Me.lblRefToType = New System.Windows.Forms.Label
Me.txtRefToType = New LATIR2GuiManager.TouchTextBox
Me.cmdRefToType = New System.Windows.Forms.Button
Me.cmdRefToTypeClear = New System.Windows.Forms.Button
Me.lblRefToPart = New System.Windows.Forms.Label
Me.txtRefToPart = New LATIR2GuiManager.TouchTextBox
Me.cmdRefToPart = New System.Windows.Forms.Button
Me.cmdRefToPartClear = New System.Windows.Forms.Button
Me.lblTheStyle = New System.Windows.Forms.Label
Me.txtTheStyle = New LATIR2GuiManager.TouchTextBox
Me.lblInternalReference = New System.Windows.Forms.Label
Me.cmbInternalReference = New System.Windows.Forms.ComboBox
Me.lblCreateRefOnly = New System.Windows.Forms.Label
Me.cmbCreateRefOnly = New System.Windows.Forms.ComboBox
Me.lblIsAutoNumber = New System.Windows.Forms.Label
Me.cmbIsAutoNumber = New System.Windows.Forms.ComboBox
Me.lblTheNumerator = New System.Windows.Forms.Label
Me.txtTheNumerator = New LATIR2GuiManager.TouchTextBox
Me.cmdTheNumerator = New System.Windows.Forms.Button
Me.cmdTheNumeratorClear = New System.Windows.Forms.Button
Me.lblZoneTemplate = New System.Windows.Forms.Label
Me.txtZoneTemplate = New LATIR2GuiManager.TouchTextBox
Me.lblNumberDateField = New System.Windows.Forms.Label
Me.txtNumberDateField = New LATIR2GuiManager.TouchTextBox
Me.cmdNumberDateField = New System.Windows.Forms.Button
Me.cmdNumberDateFieldClear = New System.Windows.Forms.Button
Me.lblTheComment = New System.Windows.Forms.Label
Me.txtTheComment = New LATIR2GuiManager.TouchTextBox
Me.lblshablonBrief = New System.Windows.Forms.Label
Me.txtshablonBrief = New LATIR2GuiManager.TouchTextBox
Me.lbltheNameClass = New System.Windows.Forms.Label
Me.txttheNameClass = New LATIR2GuiManager.TouchTextBox
Me.lblTheMask = New System.Windows.Forms.Label
Me.txtTheMask = New LATIR2GuiManager.TouchTextBox

Me.lblTabName.Location = New System.Drawing.Point(20,5)
Me.lblTabName.name = "lblTabName"
Me.lblTabName.Size = New System.Drawing.Size(200, 20)
Me.lblTabName.TabIndex = 1
Me.lblTabName.Text = "Имя вкладки"
Me.lblTabName.ForeColor = System.Drawing.Color.Blue
Me.txtTabName.Location = New System.Drawing.Point(20,27)
Me.txtTabName.name = "txtTabName"
Me.txtTabName.Size = New System.Drawing.Size(200, 20)
Me.txtTabName.TabIndex = 2
Me.txtTabName.Text = "" 
Me.lblFieldGroupBox.Location = New System.Drawing.Point(20,52)
Me.lblFieldGroupBox.name = "lblFieldGroupBox"
Me.lblFieldGroupBox.Size = New System.Drawing.Size(200, 20)
Me.lblFieldGroupBox.TabIndex = 3
Me.lblFieldGroupBox.Text = "Имя группы"
Me.lblFieldGroupBox.ForeColor = System.Drawing.Color.Blue
Me.txtFieldGroupBox.Location = New System.Drawing.Point(20,74)
Me.txtFieldGroupBox.name = "txtFieldGroupBox"
Me.txtFieldGroupBox.Size = New System.Drawing.Size(200, 20)
Me.txtFieldGroupBox.TabIndex = 4
Me.txtFieldGroupBox.Text = "" 
Me.lblSequence.Location = New System.Drawing.Point(20,99)
Me.lblSequence.name = "lblSequence"
Me.lblSequence.Size = New System.Drawing.Size(200, 20)
Me.lblSequence.TabIndex = 5
Me.lblSequence.Text = "№ п/п"
Me.lblSequence.ForeColor = System.Drawing.Color.Black
Me.txtSequence.Location = New System.Drawing.Point(20,121)
Me.txtSequence.name = "txtSequence"
Me.txtSequence.MultiLine = false
Me.txtSequence.Size = New System.Drawing.Size(200,  20)
Me.txtSequence.TabIndex = 6
Me.txtSequence.Text = "" 
Me.txtSequence.MaxLength = 15
Me.lblCaption.Location = New System.Drawing.Point(20,146)
Me.lblCaption.name = "lblCaption"
Me.lblCaption.Size = New System.Drawing.Size(200, 20)
Me.lblCaption.TabIndex = 7
Me.lblCaption.Text = "Надпись"
Me.lblCaption.ForeColor = System.Drawing.Color.Black
Me.txtCaption.Location = New System.Drawing.Point(20,168)
Me.txtCaption.name = "txtCaption"
Me.txtCaption.Size = New System.Drawing.Size(200, 20)
Me.txtCaption.TabIndex = 8
Me.txtCaption.Text = "" 
Me.lblName.Location = New System.Drawing.Point(20,193)
Me.lblName.name = "lblName"
Me.lblName.Size = New System.Drawing.Size(200, 20)
Me.lblName.TabIndex = 9
Me.lblName.Text = "Имя поля"
Me.lblName.ForeColor = System.Drawing.Color.Black
Me.txtName.Location = New System.Drawing.Point(20,215)
Me.txtName.name = "txtName"
Me.txtName.Size = New System.Drawing.Size(200, 20)
Me.txtName.TabIndex = 10
Me.txtName.Text = "" 
Me.lblFieldType.Location = New System.Drawing.Point(20,240)
Me.lblFieldType.name = "lblFieldType"
Me.lblFieldType.Size = New System.Drawing.Size(200, 20)
Me.lblFieldType.TabIndex = 11
Me.lblFieldType.Text = "Тип поля"
Me.lblFieldType.ForeColor = System.Drawing.Color.Black
Me.txtFieldType.Location = New System.Drawing.Point(20,262)
Me.txtFieldType.name = "txtFieldType"
Me.txtFieldType.ReadOnly = True
Me.txtFieldType.Size = New System.Drawing.Size(176, 20)
Me.txtFieldType.TabIndex = 12
Me.txtFieldType.Text = "" 
Me.cmdFieldType.Location = New System.Drawing.Point(198,262)
Me.cmdFieldType.name = "cmdFieldType"
Me.cmdFieldType.Size = New System.Drawing.Size(22, 20)
Me.cmdFieldType.TabIndex = 13
Me.cmdFieldType.Text = "..." 
Me.lblIsBrief.Location = New System.Drawing.Point(20,287)
Me.lblIsBrief.name = "lblIsBrief"
Me.lblIsBrief.Size = New System.Drawing.Size(200, 20)
Me.lblIsBrief.TabIndex = 14
Me.lblIsBrief.Text = "Краткая информация"
Me.lblIsBrief.ForeColor = System.Drawing.Color.Black
Me.cmbIsBrief.Location = New System.Drawing.Point(20,309)
Me.cmbIsBrief.name = "cmbIsBrief"
Me.cmbIsBrief.Size = New System.Drawing.Size(200,  20)
Me.cmbIsBrief.TabIndex = 15
Me.lblIsTabBrief.Location = New System.Drawing.Point(20,334)
Me.lblIsTabBrief.name = "lblIsTabBrief"
Me.lblIsTabBrief.Size = New System.Drawing.Size(200, 20)
Me.lblIsTabBrief.TabIndex = 16
Me.lblIsTabBrief.Text = "Для отображения в таблице"
Me.lblIsTabBrief.ForeColor = System.Drawing.Color.Black
Me.cmbIsTabBrief.Location = New System.Drawing.Point(20,356)
Me.cmbIsTabBrief.name = "cmbIsTabBrief"
Me.cmbIsTabBrief.Size = New System.Drawing.Size(200,  20)
Me.cmbIsTabBrief.TabIndex = 17
Me.lblAllowNull.Location = New System.Drawing.Point(20,381)
Me.lblAllowNull.name = "lblAllowNull"
Me.lblAllowNull.Size = New System.Drawing.Size(200, 20)
Me.lblAllowNull.TabIndex = 18
Me.lblAllowNull.Text = "Может быть пустым"
Me.lblAllowNull.ForeColor = System.Drawing.Color.Black
Me.cmbAllowNull.Location = New System.Drawing.Point(20,403)
Me.cmbAllowNull.name = "cmbAllowNull"
Me.cmbAllowNull.Size = New System.Drawing.Size(200,  20)
Me.cmbAllowNull.TabIndex = 19
Me.lblDataSize.Location = New System.Drawing.Point(230,5)
Me.lblDataSize.name = "lblDataSize"
Me.lblDataSize.Size = New System.Drawing.Size(200, 20)
Me.lblDataSize.TabIndex = 20
Me.lblDataSize.Text = "Размер поля"
Me.lblDataSize.ForeColor = System.Drawing.Color.Blue
Me.txtDataSize.Location = New System.Drawing.Point(230,27)
Me.txtDataSize.name = "txtDataSize"
Me.txtDataSize.MultiLine = false
Me.txtDataSize.Size = New System.Drawing.Size(200,  20)
Me.txtDataSize.TabIndex = 21
Me.txtDataSize.Text = "" 
Me.txtDataSize.MaxLength = 15
Me.lblReferenceType.Location = New System.Drawing.Point(230,52)
Me.lblReferenceType.name = "lblReferenceType"
Me.lblReferenceType.Size = New System.Drawing.Size(200, 20)
Me.lblReferenceType.TabIndex = 22
Me.lblReferenceType.Text = "Тип ссылки"
Me.lblReferenceType.ForeColor = System.Drawing.Color.Black
Me.cmbReferenceType.Location = New System.Drawing.Point(230,74)
Me.cmbReferenceType.name = "cmbReferenceType"
Me.cmbReferenceType.Size = New System.Drawing.Size(200,  20)
Me.cmbReferenceType.TabIndex = 23
Me.cmbReferenceType.DropDownStyle = ComboBoxStyle.DropDownList
Me.lblRefToType.Location = New System.Drawing.Point(230,99)
Me.lblRefToType.name = "lblRefToType"
Me.lblRefToType.Size = New System.Drawing.Size(200, 20)
Me.lblRefToType.TabIndex = 24
Me.lblRefToType.Text = "Ссылка на тип"
Me.lblRefToType.ForeColor = System.Drawing.Color.Blue
Me.txtRefToType.Location = New System.Drawing.Point(230,121)
Me.txtRefToType.name = "txtRefToType"
Me.txtRefToType.ReadOnly = True
Me.txtRefToType.Size = New System.Drawing.Size(155, 20)
Me.txtRefToType.TabIndex = 25
Me.txtRefToType.Text = "" 
Me.cmdRefToType.Location = New System.Drawing.Point(386,121)
Me.cmdRefToType.name = "cmdRefToType"
Me.cmdRefToType.Size = New System.Drawing.Size(22, 20)
Me.cmdRefToType.TabIndex = 26
Me.cmdRefToType.Text = "..." 
Me.cmdRefToTypeClear.Location = New System.Drawing.Point(408,121)
Me.cmdRefToTypeClear.name = "cmdRefToTypeClear"
Me.cmdRefToTypeClear.Size = New System.Drawing.Size(22, 20)
Me.cmdRefToTypeClear.TabIndex = 27
Me.cmdRefToTypeClear.Text = "X" 
Me.lblRefToPart.Location = New System.Drawing.Point(230,146)
Me.lblRefToPart.name = "lblRefToPart"
Me.lblRefToPart.Size = New System.Drawing.Size(200, 20)
Me.lblRefToPart.TabIndex = 28
Me.lblRefToPart.Text = "Ссылка на раздел"
Me.lblRefToPart.ForeColor = System.Drawing.Color.Blue
Me.txtRefToPart.Location = New System.Drawing.Point(230,168)
Me.txtRefToPart.name = "txtRefToPart"
Me.txtRefToPart.ReadOnly = True
Me.txtRefToPart.Size = New System.Drawing.Size(155, 20)
Me.txtRefToPart.TabIndex = 29
Me.txtRefToPart.Text = "" 
Me.cmdRefToPart.Location = New System.Drawing.Point(386,168)
Me.cmdRefToPart.name = "cmdRefToPart"
Me.cmdRefToPart.Size = New System.Drawing.Size(22, 20)
Me.cmdRefToPart.TabIndex = 30
Me.cmdRefToPart.Text = "..." 
Me.cmdRefToPartClear.Location = New System.Drawing.Point(408,168)
Me.cmdRefToPartClear.name = "cmdRefToPartClear"
Me.cmdRefToPartClear.Size = New System.Drawing.Size(22, 20)
Me.cmdRefToPartClear.TabIndex = 31
Me.cmdRefToPartClear.Text = "X" 
Me.lblTheStyle.Location = New System.Drawing.Point(230,193)
Me.lblTheStyle.name = "lblTheStyle"
Me.lblTheStyle.Size = New System.Drawing.Size(200, 20)
Me.lblTheStyle.TabIndex = 32
Me.lblTheStyle.Text = "Стиль"
Me.lblTheStyle.ForeColor = System.Drawing.Color.Blue
Me.txtTheStyle.Location = New System.Drawing.Point(230,215)
Me.txtTheStyle.name = "txtTheStyle"
Me.txtTheStyle.Size = New System.Drawing.Size(200, 20)
Me.txtTheStyle.TabIndex = 33
Me.txtTheStyle.Text = "" 
Me.lblInternalReference.Location = New System.Drawing.Point(230,240)
Me.lblInternalReference.name = "lblInternalReference"
Me.lblInternalReference.Size = New System.Drawing.Size(200, 20)
Me.lblInternalReference.TabIndex = 34
Me.lblInternalReference.Text = "Ссылка в пределах объекта"
Me.lblInternalReference.ForeColor = System.Drawing.Color.Black
Me.cmbInternalReference.Location = New System.Drawing.Point(230,262)
Me.cmbInternalReference.name = "cmbInternalReference"
Me.cmbInternalReference.Size = New System.Drawing.Size(200,  20)
Me.cmbInternalReference.TabIndex = 35
Me.lblCreateRefOnly.Location = New System.Drawing.Point(230,287)
Me.lblCreateRefOnly.name = "lblCreateRefOnly"
Me.lblCreateRefOnly.Size = New System.Drawing.Size(200, 20)
Me.lblCreateRefOnly.TabIndex = 36
Me.lblCreateRefOnly.Text = "Только создание объекта"
Me.lblCreateRefOnly.ForeColor = System.Drawing.Color.Black
Me.cmbCreateRefOnly.Location = New System.Drawing.Point(230,309)
Me.cmbCreateRefOnly.name = "cmbCreateRefOnly"
Me.cmbCreateRefOnly.Size = New System.Drawing.Size(200,  20)
Me.cmbCreateRefOnly.TabIndex = 37
Me.lblIsAutoNumber.Location = New System.Drawing.Point(230,334)
Me.lblIsAutoNumber.name = "lblIsAutoNumber"
Me.lblIsAutoNumber.Size = New System.Drawing.Size(200, 20)
Me.lblIsAutoNumber.TabIndex = 38
Me.lblIsAutoNumber.Text = "Автонумерация"
Me.lblIsAutoNumber.ForeColor = System.Drawing.Color.Black
Me.cmbIsAutoNumber.Location = New System.Drawing.Point(230,356)
Me.cmbIsAutoNumber.name = "cmbIsAutoNumber"
Me.cmbIsAutoNumber.Size = New System.Drawing.Size(200,  20)
Me.cmbIsAutoNumber.TabIndex = 39
Me.lblTheNumerator.Location = New System.Drawing.Point(230,381)
Me.lblTheNumerator.name = "lblTheNumerator"
Me.lblTheNumerator.Size = New System.Drawing.Size(200, 20)
Me.lblTheNumerator.TabIndex = 40
Me.lblTheNumerator.Text = "Нумератор"
Me.lblTheNumerator.ForeColor = System.Drawing.Color.Blue
Me.txtTheNumerator.Location = New System.Drawing.Point(230,403)
Me.txtTheNumerator.name = "txtTheNumerator"
Me.txtTheNumerator.ReadOnly = True
Me.txtTheNumerator.Size = New System.Drawing.Size(155, 20)
Me.txtTheNumerator.TabIndex = 41
Me.txtTheNumerator.Text = "" 
Me.cmdTheNumerator.Location = New System.Drawing.Point(386,403)
Me.cmdTheNumerator.name = "cmdTheNumerator"
Me.cmdTheNumerator.Size = New System.Drawing.Size(22, 20)
Me.cmdTheNumerator.TabIndex = 42
Me.cmdTheNumerator.Text = "..." 
Me.cmdTheNumeratorClear.Location = New System.Drawing.Point(408,403)
Me.cmdTheNumeratorClear.name = "cmdTheNumeratorClear"
Me.cmdTheNumeratorClear.Size = New System.Drawing.Size(22, 20)
Me.cmdTheNumeratorClear.TabIndex = 43
Me.cmdTheNumeratorClear.Text = "X" 
Me.lblZoneTemplate.Location = New System.Drawing.Point(440,5)
Me.lblZoneTemplate.name = "lblZoneTemplate"
Me.lblZoneTemplate.Size = New System.Drawing.Size(200, 20)
Me.lblZoneTemplate.TabIndex = 44
Me.lblZoneTemplate.Text = "Шаблон зоны нумерации"
Me.lblZoneTemplate.ForeColor = System.Drawing.Color.Blue
Me.txtZoneTemplate.Location = New System.Drawing.Point(440,27)
Me.txtZoneTemplate.name = "txtZoneTemplate"
Me.txtZoneTemplate.Size = New System.Drawing.Size(200, 20)
Me.txtZoneTemplate.TabIndex = 45
Me.txtZoneTemplate.Text = "" 
Me.lblNumberDateField.Location = New System.Drawing.Point(440,52)
Me.lblNumberDateField.name = "lblNumberDateField"
Me.lblNumberDateField.Size = New System.Drawing.Size(200, 20)
Me.lblNumberDateField.TabIndex = 46
Me.lblNumberDateField.Text = "Поле для расчета даты"
Me.lblNumberDateField.ForeColor = System.Drawing.Color.Blue
Me.txtNumberDateField.Location = New System.Drawing.Point(440,74)
Me.txtNumberDateField.name = "txtNumberDateField"
Me.txtNumberDateField.ReadOnly = True
Me.txtNumberDateField.Size = New System.Drawing.Size(155, 20)
Me.txtNumberDateField.TabIndex = 47
Me.txtNumberDateField.Text = "" 
Me.cmdNumberDateField.Location = New System.Drawing.Point(596,74)
Me.cmdNumberDateField.name = "cmdNumberDateField"
Me.cmdNumberDateField.Size = New System.Drawing.Size(22, 20)
Me.cmdNumberDateField.TabIndex = 48
Me.cmdNumberDateField.Text = "..." 
Me.cmdNumberDateFieldClear.Location = New System.Drawing.Point(618,74)
Me.cmdNumberDateFieldClear.name = "cmdNumberDateFieldClear"
Me.cmdNumberDateFieldClear.Size = New System.Drawing.Size(22, 20)
Me.cmdNumberDateFieldClear.TabIndex = 49
Me.cmdNumberDateFieldClear.Text = "X" 
Me.lblTheComment.Location = New System.Drawing.Point(440,99)
Me.lblTheComment.name = "lblTheComment"
Me.lblTheComment.Size = New System.Drawing.Size(200, 20)
Me.lblTheComment.TabIndex = 50
Me.lblTheComment.Text = "Описание"
Me.lblTheComment.ForeColor = System.Drawing.Color.Blue
Me.txtTheComment.Location = New System.Drawing.Point(440,121)
Me.txtTheComment.name = "txtTheComment"
Me.txtTheComment.MultiLine = True
Me.txtTheComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtTheComment.Size = New System.Drawing.Size(200, 50 + 20)
Me.txtTheComment.TabIndex = 51
Me.txtTheComment.Text = "" 
Me.lblshablonBrief.Location = New System.Drawing.Point(440,191)
Me.lblshablonBrief.name = "lblshablonBrief"
Me.lblshablonBrief.Size = New System.Drawing.Size(200, 20)
Me.lblshablonBrief.TabIndex = 52
Me.lblshablonBrief.Text = "Шаблон для краткого отображения"
Me.lblshablonBrief.ForeColor = System.Drawing.Color.Blue
Me.txtshablonBrief.Location = New System.Drawing.Point(440,213)
Me.txtshablonBrief.name = "txtshablonBrief"
Me.txtshablonBrief.Size = New System.Drawing.Size(200, 20)
Me.txtshablonBrief.TabIndex = 53
Me.txtshablonBrief.Text = "" 
Me.lbltheNameClass.Location = New System.Drawing.Point(440,238)
Me.lbltheNameClass.name = "lbltheNameClass"
Me.lbltheNameClass.Size = New System.Drawing.Size(200, 20)
Me.lbltheNameClass.TabIndex = 54
Me.lbltheNameClass.Text = "Имя класса для мастера строк"
Me.lbltheNameClass.ForeColor = System.Drawing.Color.Blue
Me.txttheNameClass.Location = New System.Drawing.Point(440,260)
Me.txttheNameClass.name = "txttheNameClass"
Me.txttheNameClass.Size = New System.Drawing.Size(200, 20)
Me.txttheNameClass.TabIndex = 55
Me.txttheNameClass.Text = "" 
Me.lblTheMask.Location = New System.Drawing.Point(440,285)
Me.lblTheMask.name = "lblTheMask"
Me.lblTheMask.Size = New System.Drawing.Size(200, 20)
Me.lblTheMask.TabIndex = 56
Me.lblTheMask.Text = "Маска"
Me.lblTheMask.ForeColor = System.Drawing.Color.Blue
Me.txtTheMask.Location = New System.Drawing.Point(440,307)
Me.txtTheMask.name = "txtTheMask"
Me.txtTheMask.Size = New System.Drawing.Size(200, 20)
Me.txtTheMask.TabIndex = 57
Me.txtTheMask.Text = "" 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTabName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTabName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblFieldGroupBox)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtFieldGroupBox)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblSequence)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtSequence)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblCaption)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtCaption)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblFieldType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtFieldType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdFieldType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblIsBrief)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbIsBrief)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblIsTabBrief)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbIsTabBrief)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblAllowNull)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbAllowNull)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblDataSize)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtDataSize)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblReferenceType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbReferenceType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblRefToType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtRefToType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdRefToType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdRefToTypeClear)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblRefToPart)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtRefToPart)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdRefToPart)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdRefToPartClear)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTheStyle)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTheStyle)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblInternalReference)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbInternalReference)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblCreateRefOnly)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbCreateRefOnly)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblIsAutoNumber)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbIsAutoNumber)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTheNumerator)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTheNumerator)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdTheNumerator)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdTheNumeratorClear)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblZoneTemplate)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtZoneTemplate)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblNumberDateField)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtNumberDateField)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdNumberDateField)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdNumberDateFieldClear)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTheComment)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTheComment)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblshablonBrief)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtshablonBrief)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lbltheNameClass)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txttheNameClass)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTheMask)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTheMask)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editFIELD"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtTabName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTabName.TextChanged
  Changing

end sub
private sub txtFieldGroupBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFieldGroupBox.TextChanged
  Changing

end sub
        Private Sub txtSequence_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtSequence.Validating
        If txtSequence.Text <> "" Then
            try
            If Not IsNumeric(txtSequence.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtSequence.Text) < -2000000000 Or Val(txtSequence.Text) > 2000000000 Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
            Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtSequence_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSequence.TextChanged
  Changing

end sub
private sub txtCaption_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCaption.TextChanged
  Changing

end sub
private sub txtName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
  Changing

end sub
private sub txtFieldType_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFieldType.TextChanged
  Changing

end sub
private sub cmdFieldType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFieldType.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("FIELDTYPE","",System.guid.Empty, id, brief) Then
          txtFieldType.Tag = id
          txtFieldType.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmbIsBrief_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbIsBrief.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmbIsTabBrief_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbIsTabBrief.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmbAllowNull_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAllowNull.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
        Private Sub txtDataSize_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDataSize.Validating
        If txtDataSize.Text <> "" Then
            try
            If Not IsNumeric(txtDataSize.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtDataSize.Text) < -2000000000 Or Val(txtDataSize.Text) > 2000000000 Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
            Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtDataSize_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDataSize.TextChanged
  Changing

end sub
private sub cmbReferenceType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbReferenceType.SelectedIndexChanged
  try
     Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtRefToType_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRefToType.TextChanged
  Changing

end sub
private sub cmdRefToType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefToType.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("OBJECTTYPE","",System.guid.Empty, id, brief) Then
          txtRefToType.Tag = id
          txtRefToType.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmdRefToTypeClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefToTypeClear.Click
  try
          txtRefToType.Tag = Guid.Empty
          txtRefToType.text = ""
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtRefToPart_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRefToPart.TextChanged
  Changing

end sub
private sub cmdRefToPart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefToPart.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("PART","",System.guid.Empty, id, brief) Then
          txtRefToPart.Tag = id
          txtRefToPart.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmdRefToPartClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefToPartClear.Click
  try
          txtRefToPart.Tag = Guid.Empty
          txtRefToPart.text = ""
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtTheStyle_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTheStyle.TextChanged
  Changing

end sub
private sub cmbInternalReference_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbInternalReference.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmbCreateRefOnly_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCreateRefOnly.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmbIsAutoNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbIsAutoNumber.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtTheNumerator_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTheNumerator.TextChanged
  Changing

end sub
private sub cmdTheNumerator_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTheNumerator.Click
  try
Dim id As guid
Dim brief As String  = string.Empty
Dim OK as boolean
       OK=GuiManager.GetObjectDialog("STDNumerator","",id,brief)
If OK Then
    txtTheNumerator.Text = brief
    txtTheNumerator.Tag = id
End If
        catch ex as system.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
End Sub
private sub txtZoneTemplate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtZoneTemplate.TextChanged
  Changing

end sub
private sub txtNumberDateField_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumberDateField.TextChanged
  Changing

end sub
private sub cmdNumberDateField_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNumberDateField.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("FIELD","",System.guid.Empty, id, brief) Then
          txtNumberDateField.Tag = id
          txtNumberDateField.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmdNumberDateFieldClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNumberDateFieldClear.Click
  try
          txtNumberDateField.Tag = Guid.Empty
          txtNumberDateField.text = ""
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtTheComment_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTheComment.TextChanged
  Changing

end sub
private sub txtshablonBrief_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtshablonBrief.TextChanged
  Changing

end sub
private sub txttheNameClass_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttheNameClass.TextChanged
  Changing

end sub
private sub txtTheMask_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTheMask.TextChanged
  Changing

end sub

Public Item As MTZMetaModel.MTZMetaModel.FIELD
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,MTZMetaModel.MTZMetaModel.FIELD)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

txtTabName.text = item.TabName
txtFieldGroupBox.text = item.FieldGroupBox
txtSequence.text = item.Sequence.toString()
txtCaption.text = item.Caption
txtName.text = item.Name
If Not item.FieldType Is Nothing Then
  txtFieldType.Tag = item.FieldType.id
  txtFieldType.text = item.FieldType.brief
else
  txtFieldType.Tag = System.Guid.Empty 
  txtFieldType.text = "" 
End If
cmbIsBriefData = New DataTable
cmbIsBriefData.Columns.Add("name", GetType(System.String))
cmbIsBriefData.Columns.Add("Value", GetType(System.Int32))
try
cmbIsBriefDataRow = cmbIsBriefData.NewRow
cmbIsBriefDataRow("name") = "Да"
cmbIsBriefDataRow("Value") = -1
cmbIsBriefData.Rows.Add (cmbIsBriefDataRow)
cmbIsBriefDataRow = cmbIsBriefData.NewRow
cmbIsBriefDataRow("name") = "Нет"
cmbIsBriefDataRow("Value") = 0
cmbIsBriefData.Rows.Add (cmbIsBriefDataRow)
cmbIsBrief.DisplayMember = "name"
cmbIsBrief.ValueMember = "Value"
cmbIsBrief.DataSource = cmbIsBriefData
 cmbIsBrief.SelectedValue=CInt(Item.IsBrief)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
cmbIsTabBriefData = New DataTable
cmbIsTabBriefData.Columns.Add("name", GetType(System.String))
cmbIsTabBriefData.Columns.Add("Value", GetType(System.Int32))
try
cmbIsTabBriefDataRow = cmbIsTabBriefData.NewRow
cmbIsTabBriefDataRow("name") = "Да"
cmbIsTabBriefDataRow("Value") = -1
cmbIsTabBriefData.Rows.Add (cmbIsTabBriefDataRow)
cmbIsTabBriefDataRow = cmbIsTabBriefData.NewRow
cmbIsTabBriefDataRow("name") = "Нет"
cmbIsTabBriefDataRow("Value") = 0
cmbIsTabBriefData.Rows.Add (cmbIsTabBriefDataRow)
cmbIsTabBrief.DisplayMember = "name"
cmbIsTabBrief.ValueMember = "Value"
cmbIsTabBrief.DataSource = cmbIsTabBriefData
 cmbIsTabBrief.SelectedValue=CInt(Item.IsTabBrief)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
cmbAllowNullData = New DataTable
cmbAllowNullData.Columns.Add("name", GetType(System.String))
cmbAllowNullData.Columns.Add("Value", GetType(System.Int32))
try
cmbAllowNullDataRow = cmbAllowNullData.NewRow
cmbAllowNullDataRow("name") = "Да"
cmbAllowNullDataRow("Value") = -1
cmbAllowNullData.Rows.Add (cmbAllowNullDataRow)
cmbAllowNullDataRow = cmbAllowNullData.NewRow
cmbAllowNullDataRow("name") = "Нет"
cmbAllowNullDataRow("Value") = 0
cmbAllowNullData.Rows.Add (cmbAllowNullDataRow)
cmbAllowNull.DisplayMember = "name"
cmbAllowNull.ValueMember = "Value"
cmbAllowNull.DataSource = cmbAllowNullData
 cmbAllowNull.SelectedValue=CInt(Item.AllowNull)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
txtDataSize.text = item.DataSize.toString()
cmbReferenceTypeData = New DataTable
cmbReferenceTypeData.Columns.Add("name", GetType(System.String))
cmbReferenceTypeData.Columns.Add("Value", GetType(System.Int32))
try
cmbReferenceTypeDataRow = cmbReferenceTypeData.NewRow
cmbReferenceTypeDataRow("name") = "Скалярное поле ( не ссылка)"
cmbReferenceTypeDataRow("Value") = 0
cmbReferenceTypeData.Rows.Add (cmbReferenceTypeDataRow)
cmbReferenceTypeDataRow = cmbReferenceTypeData.NewRow
cmbReferenceTypeDataRow("name") = "На объект "
cmbReferenceTypeDataRow("Value") = 1
cmbReferenceTypeData.Rows.Add (cmbReferenceTypeDataRow)
cmbReferenceTypeDataRow = cmbReferenceTypeData.NewRow
cmbReferenceTypeDataRow("name") = "На строку раздела"
cmbReferenceTypeDataRow("Value") = 2
cmbReferenceTypeData.Rows.Add (cmbReferenceTypeDataRow)
cmbReferenceTypeDataRow = cmbReferenceTypeData.NewRow
cmbReferenceTypeDataRow("name") = "На источник данных"
cmbReferenceTypeDataRow("Value") = 3
cmbReferenceTypeData.Rows.Add (cmbReferenceTypeDataRow)
cmbReferenceType.DisplayMember = "name"
cmbReferenceType.ValueMember = "Value"
cmbReferenceType.DataSource = cmbReferenceTypeData
 cmbReferenceType.SelectedValue=CInt(Item.ReferenceType)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
If Not item.RefToType Is Nothing Then
  txtRefToType.Tag = item.RefToType.id
  txtRefToType.text = item.RefToType.brief
else
  txtRefToType.Tag = System.Guid.Empty 
  txtRefToType.text = "" 
End If
If Not item.RefToPart Is Nothing Then
  txtRefToPart.Tag = item.RefToPart.id
  txtRefToPart.text = item.RefToPart.brief
else
  txtRefToPart.Tag = System.Guid.Empty 
  txtRefToPart.text = "" 
End If
txtTheStyle.text = item.TheStyle
cmbInternalReferenceData = New DataTable
cmbInternalReferenceData.Columns.Add("name", GetType(System.String))
cmbInternalReferenceData.Columns.Add("Value", GetType(System.Int32))
try
cmbInternalReferenceDataRow = cmbInternalReferenceData.NewRow
cmbInternalReferenceDataRow("name") = "Да"
cmbInternalReferenceDataRow("Value") = -1
cmbInternalReferenceData.Rows.Add (cmbInternalReferenceDataRow)
cmbInternalReferenceDataRow = cmbInternalReferenceData.NewRow
cmbInternalReferenceDataRow("name") = "Нет"
cmbInternalReferenceDataRow("Value") = 0
cmbInternalReferenceData.Rows.Add (cmbInternalReferenceDataRow)
cmbInternalReference.DisplayMember = "name"
cmbInternalReference.ValueMember = "Value"
cmbInternalReference.DataSource = cmbInternalReferenceData
 cmbInternalReference.SelectedValue=CInt(Item.InternalReference)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
cmbCreateRefOnlyData = New DataTable
cmbCreateRefOnlyData.Columns.Add("name", GetType(System.String))
cmbCreateRefOnlyData.Columns.Add("Value", GetType(System.Int32))
try
cmbCreateRefOnlyDataRow = cmbCreateRefOnlyData.NewRow
cmbCreateRefOnlyDataRow("name") = "Да"
cmbCreateRefOnlyDataRow("Value") = -1
cmbCreateRefOnlyData.Rows.Add (cmbCreateRefOnlyDataRow)
cmbCreateRefOnlyDataRow = cmbCreateRefOnlyData.NewRow
cmbCreateRefOnlyDataRow("name") = "Нет"
cmbCreateRefOnlyDataRow("Value") = 0
cmbCreateRefOnlyData.Rows.Add (cmbCreateRefOnlyDataRow)
cmbCreateRefOnly.DisplayMember = "name"
cmbCreateRefOnly.ValueMember = "Value"
cmbCreateRefOnly.DataSource = cmbCreateRefOnlyData
 cmbCreateRefOnly.SelectedValue=CInt(Item.CreateRefOnly)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
cmbIsAutoNumberData = New DataTable
cmbIsAutoNumberData.Columns.Add("name", GetType(System.String))
cmbIsAutoNumberData.Columns.Add("Value", GetType(System.Int32))
try
cmbIsAutoNumberDataRow = cmbIsAutoNumberData.NewRow
cmbIsAutoNumberDataRow("name") = "Да"
cmbIsAutoNumberDataRow("Value") = -1
cmbIsAutoNumberData.Rows.Add (cmbIsAutoNumberDataRow)
cmbIsAutoNumberDataRow = cmbIsAutoNumberData.NewRow
cmbIsAutoNumberDataRow("name") = "Нет"
cmbIsAutoNumberDataRow("Value") = 0
cmbIsAutoNumberData.Rows.Add (cmbIsAutoNumberDataRow)
cmbIsAutoNumber.DisplayMember = "name"
cmbIsAutoNumber.ValueMember = "Value"
cmbIsAutoNumber.DataSource = cmbIsAutoNumberData
 cmbIsAutoNumber.SelectedValue=CInt(Item.IsAutoNumber)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
If Not item.TheNumerator Is Nothing Then
  txtTheNumerator.Tag = item.TheNumerator.id
  txtTheNumerator.text = item.TheNumerator.brief
else
  txtTheNumerator.Tag = System.Guid.Empty 
  txtTheNumerator.text = "" 
End If
txtZoneTemplate.text = item.ZoneTemplate
If Not item.NumberDateField Is Nothing Then
  txtNumberDateField.Tag = item.NumberDateField.id
  txtNumberDateField.text = item.NumberDateField.brief
else
  txtNumberDateField.Tag = System.Guid.Empty 
  txtNumberDateField.text = "" 
End If
txtTheComment.text = item.TheComment
txtshablonBrief.text = item.shablonBrief
txttheNameClass.text = item.theNameClass
txtTheMask.text = item.TheMask
        mOnInit = false
  raiseevent Refreshed()
end sub


''' <summary>
'''Сохранения данных в полях объекта
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Save() Implements LATIR2GUIManager.IRowEditor.Save
  if mRowReadOnly =false then

item.TabName = txtTabName.text
item.FieldGroupBox = txtFieldGroupBox.text
item.Sequence = val(txtSequence.text)
item.Caption = txtCaption.text
item.Name = txtName.text
If not txtFieldType.Tag.Equals(System.Guid.Empty) Then
  item.FieldType = Item.Application.FindRowObject("FIELDTYPE",txtFieldType.Tag)
Else
   item.FieldType = Nothing
End If
   item.IsBrief = cmbIsBrief.SelectedValue
   item.IsTabBrief = cmbIsTabBrief.SelectedValue
   item.AllowNull = cmbAllowNull.SelectedValue
item.DataSize = val(txtDataSize.text)
   item.ReferenceType = cmbReferenceType.SelectedValue
If not txtRefToType.Tag.Equals(System.Guid.Empty) Then
  item.RefToType = Item.Application.FindRowObject("OBJECTTYPE",txtRefToType.Tag)
Else
   item.RefToType = Nothing
End If
If not txtRefToPart.Tag.Equals(System.Guid.Empty) Then
  item.RefToPart = Item.Application.FindRowObject("PART",txtRefToPart.Tag)
Else
   item.RefToPart = Nothing
End If
item.TheStyle = txtTheStyle.text
   item.InternalReference = cmbInternalReference.SelectedValue
   item.CreateRefOnly = cmbCreateRefOnly.SelectedValue
   item.IsAutoNumber = cmbIsAutoNumber.SelectedValue
If not txtTheNumerator.Tag.Equals(System.Guid.Empty) Then
   item.TheNumerator = GuiManager.Manager.GetInstanceObject(txtTheNumerator.Tag)
Else
   item.TheNumerator = Nothing
End If
item.ZoneTemplate = txtZoneTemplate.text
If not txtNumberDateField.Tag.Equals(System.Guid.Empty) Then
  item.NumberDateField = Item.Application.FindRowObject("FIELD",txtNumberDateField.Tag)
Else
   item.NumberDateField = Nothing
End If
item.TheComment = txtTheComment.text
item.shablonBrief = txtshablonBrief.text
item.theNameClass = txttheNameClass.text
item.TheMask = txtTheMask.text
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK =( txtSequence.text <> "" ) 
if mIsOK then mIsOK =( txtCaption.text <> "" ) 
if mIsOK then mIsOK =( txtName.text <> "" ) 
if mIsOK then mIsOK = not txtFieldType.Tag.Equals(System.Guid.Empty)
if mIsOK then mIsOK =(cmbIsBrief.SelectedIndex >=0)
if mIsOK then mIsOK =(cmbIsTabBrief.SelectedIndex >=0)
if mIsOK then mIsOK =(cmbAllowNull.SelectedIndex >=0)
if mIsOK then mIsOK =(cmbReferenceType.SelectedIndex >=0)
if mIsOK then mIsOK =(cmbInternalReference.SelectedIndex >=0)
if mIsOK then mIsOK =(cmbCreateRefOnly.SelectedIndex >=0)
if mIsOK then mIsOK =(cmbIsAutoNumber.SelectedIndex >=0)
 return mIsOK
end function
Public function IsChanged() as boolean Implements LATIR2GUIManager.IRowEditor.IsChanged
 return mChanged
end function
Public Sub SetupPanel()
    HolderPanel.SetupPanel()
End Sub
Public Overridable Function GetMaxX() As Double
    Return HolderPanel.GetMaxX()
End Function
Public Overridable Function GetMaxY() As Double
    Return HolderPanel.GetMaxY()
End Function
end class
