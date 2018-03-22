
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Меню режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editEntryPoints
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
Friend WithEvents lblsequence  as  System.Windows.Forms.Label
Friend WithEvents txtsequence As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblName  as  System.Windows.Forms.Label
Friend WithEvents txtName As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblCaption  as  System.Windows.Forms.Label
Friend WithEvents txtCaption As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblAsToolbarItem  as  System.Windows.Forms.Label
Friend WithEvents cmbAsToolbarItem As System.Windows.Forms.ComboBox
Friend cmbAsToolbarItemDATA As DataTable
Friend cmbAsToolbarItemDATAROW As DataRow
Friend WithEvents lblActionType  as  System.Windows.Forms.Label
Friend WithEvents cmbActionType As System.Windows.Forms.ComboBox
Friend cmbActionTypeDATA As DataTable
Friend cmbActionTypeDATAROW As DataRow
Friend WithEvents lblTheFilter  as  System.Windows.Forms.Label
Friend WithEvents txtTheFilter As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdTheFilter As System.Windows.Forms.Button
Friend WithEvents cmdTheFilterClear As System.Windows.Forms.Button
Friend WithEvents lblJournal  as  System.Windows.Forms.Label
Friend WithEvents txtJournal As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdJournal As System.Windows.Forms.Button
Friend WithEvents cmdJournalClear As System.Windows.Forms.Button
Friend WithEvents lblReport  as  System.Windows.Forms.Label
Friend WithEvents txtReport As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdReport As System.Windows.Forms.Button
Friend WithEvents cmdReportClear As System.Windows.Forms.Button
Friend WithEvents lblDocument  as  System.Windows.Forms.Label
Friend WithEvents txtDocument As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdDocument As System.Windows.Forms.Button
Friend WithEvents cmdDocumentClear As System.Windows.Forms.Button
Friend WithEvents lblMethod  as  System.Windows.Forms.Label
Friend WithEvents txtMethod As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdMethod As System.Windows.Forms.Button
Friend WithEvents cmdMethodClear As System.Windows.Forms.Button
Friend WithEvents lblIconFile  as  System.Windows.Forms.Label
Friend WithEvents txtIconFile As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblTheExtention  as  System.Windows.Forms.Label
Friend WithEvents txtTheExtention As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdTheExtention As System.Windows.Forms.Button
Friend WithEvents cmdTheExtentionClear As System.Windows.Forms.Button
Friend WithEvents lblARM  as  System.Windows.Forms.Label
Friend WithEvents txtARM As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdARM As System.Windows.Forms.Button
Friend WithEvents cmdARMClear As System.Windows.Forms.Button
Friend WithEvents lblTheComment  as  System.Windows.Forms.Label
Friend WithEvents txtTheComment As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblObjectType  as  System.Windows.Forms.Label
Friend WithEvents txtObjectType As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdObjectType As System.Windows.Forms.Button
Friend WithEvents cmdObjectTypeClear As System.Windows.Forms.Button
Friend WithEvents lblJournalFixedQuery  as  System.Windows.Forms.Label
Friend WithEvents txtJournalFixedQuery As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblAllowAdd  as  System.Windows.Forms.Label
Friend WithEvents cmbAllowAdd As System.Windows.Forms.ComboBox
Friend cmbAllowAddDATA As DataTable
Friend cmbAllowAddDATAROW As DataRow
Friend WithEvents lblAllowEdit  as  System.Windows.Forms.Label
Friend WithEvents cmbAllowEdit As System.Windows.Forms.ComboBox
Friend cmbAllowEditDATA As DataTable
Friend cmbAllowEditDATAROW As DataRow
Friend WithEvents lblAllowDel  as  System.Windows.Forms.Label
Friend WithEvents cmbAllowDel As System.Windows.Forms.ComboBox
Friend cmbAllowDelDATA As DataTable
Friend cmbAllowDelDATAROW As DataRow
Friend WithEvents lblAllowFilter  as  System.Windows.Forms.Label
Friend WithEvents cmbAllowFilter As System.Windows.Forms.ComboBox
Friend cmbAllowFilterDATA As DataTable
Friend cmbAllowFilterDATAROW As DataRow
Friend WithEvents lblAllowPrint  as  System.Windows.Forms.Label
Friend WithEvents cmbAllowPrint As System.Windows.Forms.ComboBox
Friend cmbAllowPrintDATA As DataTable
Friend cmbAllowPrintDATAROW As DataRow

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
Me.lblsequence = New System.Windows.Forms.Label
Me.txtsequence = New LATIR2GuiManager.TouchTextBox
Me.lblName = New System.Windows.Forms.Label
Me.txtName = New LATIR2GuiManager.TouchTextBox
Me.lblCaption = New System.Windows.Forms.Label
Me.txtCaption = New LATIR2GuiManager.TouchTextBox
Me.lblAsToolbarItem = New System.Windows.Forms.Label
Me.cmbAsToolbarItem = New System.Windows.Forms.ComboBox
Me.lblActionType = New System.Windows.Forms.Label
Me.cmbActionType = New System.Windows.Forms.ComboBox
Me.lblTheFilter = New System.Windows.Forms.Label
Me.txtTheFilter = New LATIR2GuiManager.TouchTextBox
Me.cmdTheFilter = New System.Windows.Forms.Button
Me.cmdTheFilterClear = New System.Windows.Forms.Button
Me.lblJournal = New System.Windows.Forms.Label
Me.txtJournal = New LATIR2GuiManager.TouchTextBox
Me.cmdJournal = New System.Windows.Forms.Button
Me.cmdJournalClear = New System.Windows.Forms.Button
Me.lblReport = New System.Windows.Forms.Label
Me.txtReport = New LATIR2GuiManager.TouchTextBox
Me.cmdReport = New System.Windows.Forms.Button
Me.cmdReportClear = New System.Windows.Forms.Button
Me.lblDocument = New System.Windows.Forms.Label
Me.txtDocument = New LATIR2GuiManager.TouchTextBox
Me.cmdDocument = New System.Windows.Forms.Button
Me.cmdDocumentClear = New System.Windows.Forms.Button
Me.lblMethod = New System.Windows.Forms.Label
Me.txtMethod = New LATIR2GuiManager.TouchTextBox
Me.cmdMethod = New System.Windows.Forms.Button
Me.cmdMethodClear = New System.Windows.Forms.Button
Me.lblIconFile = New System.Windows.Forms.Label
Me.txtIconFile = New LATIR2GuiManager.TouchTextBox
Me.lblTheExtention = New System.Windows.Forms.Label
Me.txtTheExtention = New LATIR2GuiManager.TouchTextBox
Me.cmdTheExtention = New System.Windows.Forms.Button
Me.cmdTheExtentionClear = New System.Windows.Forms.Button
Me.lblARM = New System.Windows.Forms.Label
Me.txtARM = New LATIR2GuiManager.TouchTextBox
Me.cmdARM = New System.Windows.Forms.Button
Me.cmdARMClear = New System.Windows.Forms.Button
Me.lblTheComment = New System.Windows.Forms.Label
Me.txtTheComment = New LATIR2GuiManager.TouchTextBox
Me.lblObjectType = New System.Windows.Forms.Label
Me.txtObjectType = New LATIR2GuiManager.TouchTextBox
Me.cmdObjectType = New System.Windows.Forms.Button
Me.cmdObjectTypeClear = New System.Windows.Forms.Button
Me.lblJournalFixedQuery = New System.Windows.Forms.Label
Me.txtJournalFixedQuery = New LATIR2GuiManager.TouchTextBox
Me.lblAllowAdd = New System.Windows.Forms.Label
Me.cmbAllowAdd = New System.Windows.Forms.ComboBox
Me.lblAllowEdit = New System.Windows.Forms.Label
Me.cmbAllowEdit = New System.Windows.Forms.ComboBox
Me.lblAllowDel = New System.Windows.Forms.Label
Me.cmbAllowDel = New System.Windows.Forms.ComboBox
Me.lblAllowFilter = New System.Windows.Forms.Label
Me.cmbAllowFilter = New System.Windows.Forms.ComboBox
Me.lblAllowPrint = New System.Windows.Forms.Label
Me.cmbAllowPrint = New System.Windows.Forms.ComboBox

Me.lblsequence.Location = New System.Drawing.Point(20,5)
Me.lblsequence.name = "lblsequence"
Me.lblsequence.Size = New System.Drawing.Size(200, 20)
Me.lblsequence.TabIndex = 1
Me.lblsequence.Text = "Последовательность"
Me.lblsequence.ForeColor = System.Drawing.Color.Black
Me.txtsequence.Location = New System.Drawing.Point(20,27)
Me.txtsequence.name = "txtsequence"
Me.txtsequence.MultiLine = false
Me.txtsequence.Size = New System.Drawing.Size(200,  20)
Me.txtsequence.TabIndex = 2
Me.txtsequence.Text = "" 
Me.txtsequence.MaxLength = 15
Me.lblName.Location = New System.Drawing.Point(20,52)
Me.lblName.name = "lblName"
Me.lblName.Size = New System.Drawing.Size(200, 20)
Me.lblName.TabIndex = 3
Me.lblName.Text = "Название"
Me.lblName.ForeColor = System.Drawing.Color.Black
Me.txtName.Location = New System.Drawing.Point(20,74)
Me.txtName.name = "txtName"
Me.txtName.Size = New System.Drawing.Size(200, 20)
Me.txtName.TabIndex = 4
Me.txtName.Text = "" 
Me.lblCaption.Location = New System.Drawing.Point(20,99)
Me.lblCaption.name = "lblCaption"
Me.lblCaption.Size = New System.Drawing.Size(200, 20)
Me.lblCaption.TabIndex = 5
Me.lblCaption.Text = "Заголовок"
Me.lblCaption.ForeColor = System.Drawing.Color.Black
Me.txtCaption.Location = New System.Drawing.Point(20,121)
Me.txtCaption.name = "txtCaption"
Me.txtCaption.Size = New System.Drawing.Size(200, 20)
Me.txtCaption.TabIndex = 6
Me.txtCaption.Text = "" 
Me.lblAsToolbarItem.Location = New System.Drawing.Point(20,146)
Me.lblAsToolbarItem.name = "lblAsToolbarItem"
Me.lblAsToolbarItem.Size = New System.Drawing.Size(200, 20)
Me.lblAsToolbarItem.TabIndex = 7
Me.lblAsToolbarItem.Text = "Включить в тулбар"
Me.lblAsToolbarItem.ForeColor = System.Drawing.Color.Black
Me.cmbAsToolbarItem.Location = New System.Drawing.Point(20,168)
Me.cmbAsToolbarItem.name = "cmbAsToolbarItem"
Me.cmbAsToolbarItem.Size = New System.Drawing.Size(200,  20)
Me.cmbAsToolbarItem.TabIndex = 8
Me.lblActionType.Location = New System.Drawing.Point(20,193)
Me.lblActionType.name = "lblActionType"
Me.lblActionType.Size = New System.Drawing.Size(200, 20)
Me.lblActionType.TabIndex = 9
Me.lblActionType.Text = "Вариант действия"
Me.lblActionType.ForeColor = System.Drawing.Color.Black
Me.cmbActionType.Location = New System.Drawing.Point(20,215)
Me.cmbActionType.name = "cmbActionType"
Me.cmbActionType.Size = New System.Drawing.Size(200,  20)
Me.cmbActionType.TabIndex = 10
Me.cmbActionType.DropDownStyle = ComboBoxStyle.DropDownList
Me.lblTheFilter.Location = New System.Drawing.Point(20,240)
Me.lblTheFilter.name = "lblTheFilter"
Me.lblTheFilter.Size = New System.Drawing.Size(200, 20)
Me.lblTheFilter.TabIndex = 11
Me.lblTheFilter.Text = "Фильтр"
Me.lblTheFilter.ForeColor = System.Drawing.Color.Blue
Me.txtTheFilter.Location = New System.Drawing.Point(20,262)
Me.txtTheFilter.name = "txtTheFilter"
Me.txtTheFilter.ReadOnly = True
Me.txtTheFilter.Size = New System.Drawing.Size(155, 20)
Me.txtTheFilter.TabIndex = 12
Me.txtTheFilter.Text = "" 
Me.cmdTheFilter.Location = New System.Drawing.Point(176,262)
Me.cmdTheFilter.name = "cmdTheFilter"
Me.cmdTheFilter.Size = New System.Drawing.Size(22, 20)
Me.cmdTheFilter.TabIndex = 13
Me.cmdTheFilter.Text = "..." 
Me.cmdTheFilterClear.Location = New System.Drawing.Point(198,262)
Me.cmdTheFilterClear.name = "cmdTheFilterClear"
Me.cmdTheFilterClear.Size = New System.Drawing.Size(22, 20)
Me.cmdTheFilterClear.TabIndex = 14
Me.cmdTheFilterClear.Text = "X" 
Me.lblJournal.Location = New System.Drawing.Point(20,287)
Me.lblJournal.name = "lblJournal"
Me.lblJournal.Size = New System.Drawing.Size(200, 20)
Me.lblJournal.TabIndex = 15
Me.lblJournal.Text = "Журнал"
Me.lblJournal.ForeColor = System.Drawing.Color.Blue
Me.txtJournal.Location = New System.Drawing.Point(20,309)
Me.txtJournal.name = "txtJournal"
Me.txtJournal.ReadOnly = True
Me.txtJournal.Size = New System.Drawing.Size(155, 20)
Me.txtJournal.TabIndex = 16
Me.txtJournal.Text = "" 
Me.cmdJournal.Location = New System.Drawing.Point(176,309)
Me.cmdJournal.name = "cmdJournal"
Me.cmdJournal.Size = New System.Drawing.Size(22, 20)
Me.cmdJournal.TabIndex = 17
Me.cmdJournal.Text = "..." 
Me.cmdJournalClear.Location = New System.Drawing.Point(198,309)
Me.cmdJournalClear.name = "cmdJournalClear"
Me.cmdJournalClear.Size = New System.Drawing.Size(22, 20)
Me.cmdJournalClear.TabIndex = 18
Me.cmdJournalClear.Text = "X" 
Me.lblReport.Location = New System.Drawing.Point(20,334)
Me.lblReport.name = "lblReport"
Me.lblReport.Size = New System.Drawing.Size(200, 20)
Me.lblReport.TabIndex = 19
Me.lblReport.Text = "Отчет"
Me.lblReport.ForeColor = System.Drawing.Color.Blue
Me.txtReport.Location = New System.Drawing.Point(20,356)
Me.txtReport.name = "txtReport"
Me.txtReport.ReadOnly = True
Me.txtReport.Size = New System.Drawing.Size(155, 20)
Me.txtReport.TabIndex = 20
Me.txtReport.Text = "" 
Me.cmdReport.Location = New System.Drawing.Point(176,356)
Me.cmdReport.name = "cmdReport"
Me.cmdReport.Size = New System.Drawing.Size(22, 20)
Me.cmdReport.TabIndex = 21
Me.cmdReport.Text = "..." 
Me.cmdReportClear.Location = New System.Drawing.Point(198,356)
Me.cmdReportClear.name = "cmdReportClear"
Me.cmdReportClear.Size = New System.Drawing.Size(22, 20)
Me.cmdReportClear.TabIndex = 22
Me.cmdReportClear.Text = "X" 
Me.lblDocument.Location = New System.Drawing.Point(20,381)
Me.lblDocument.name = "lblDocument"
Me.lblDocument.Size = New System.Drawing.Size(200, 20)
Me.lblDocument.TabIndex = 23
Me.lblDocument.Text = "Документ"
Me.lblDocument.ForeColor = System.Drawing.Color.Blue
Me.txtDocument.Location = New System.Drawing.Point(20,403)
Me.txtDocument.name = "txtDocument"
Me.txtDocument.ReadOnly = True
Me.txtDocument.Size = New System.Drawing.Size(155, 20)
Me.txtDocument.TabIndex = 24
Me.txtDocument.Text = "" 
Me.cmdDocument.Location = New System.Drawing.Point(176,403)
Me.cmdDocument.name = "cmdDocument"
Me.cmdDocument.Size = New System.Drawing.Size(22, 20)
Me.cmdDocument.TabIndex = 25
Me.cmdDocument.Text = "..." 
Me.cmdDocumentClear.Location = New System.Drawing.Point(198,403)
Me.cmdDocumentClear.name = "cmdDocumentClear"
Me.cmdDocumentClear.Size = New System.Drawing.Size(22, 20)
Me.cmdDocumentClear.TabIndex = 26
Me.cmdDocumentClear.Text = "X" 
Me.lblMethod.Location = New System.Drawing.Point(230,5)
Me.lblMethod.name = "lblMethod"
Me.lblMethod.Size = New System.Drawing.Size(200, 20)
Me.lblMethod.TabIndex = 27
Me.lblMethod.Text = "Метод"
Me.lblMethod.ForeColor = System.Drawing.Color.Blue
Me.txtMethod.Location = New System.Drawing.Point(230,27)
Me.txtMethod.name = "txtMethod"
Me.txtMethod.ReadOnly = True
Me.txtMethod.Size = New System.Drawing.Size(155, 20)
Me.txtMethod.TabIndex = 28
Me.txtMethod.Text = "" 
Me.cmdMethod.Location = New System.Drawing.Point(386,27)
Me.cmdMethod.name = "cmdMethod"
Me.cmdMethod.Size = New System.Drawing.Size(22, 20)
Me.cmdMethod.TabIndex = 29
Me.cmdMethod.Text = "..." 
Me.cmdMethodClear.Location = New System.Drawing.Point(408,27)
Me.cmdMethodClear.name = "cmdMethodClear"
Me.cmdMethodClear.Size = New System.Drawing.Size(22, 20)
Me.cmdMethodClear.TabIndex = 30
Me.cmdMethodClear.Text = "X" 
Me.lblIconFile.Location = New System.Drawing.Point(230,52)
Me.lblIconFile.name = "lblIconFile"
Me.lblIconFile.Size = New System.Drawing.Size(200, 20)
Me.lblIconFile.TabIndex = 31
Me.lblIconFile.Text = "Файл картинки"
Me.lblIconFile.ForeColor = System.Drawing.Color.Blue
Me.txtIconFile.Location = New System.Drawing.Point(230,74)
Me.txtIconFile.name = "txtIconFile"
Me.txtIconFile.Size = New System.Drawing.Size(200, 20)
Me.txtIconFile.TabIndex = 32
Me.txtIconFile.Text = "" 
Me.lblTheExtention.Location = New System.Drawing.Point(230,99)
Me.lblTheExtention.name = "lblTheExtention"
Me.lblTheExtention.Size = New System.Drawing.Size(200, 20)
Me.lblTheExtention.TabIndex = 33
Me.lblTheExtention.Text = "Расширение"
Me.lblTheExtention.ForeColor = System.Drawing.Color.Blue
Me.txtTheExtention.Location = New System.Drawing.Point(230,121)
Me.txtTheExtention.name = "txtTheExtention"
Me.txtTheExtention.ReadOnly = True
Me.txtTheExtention.Size = New System.Drawing.Size(155, 20)
Me.txtTheExtention.TabIndex = 34
Me.txtTheExtention.Text = "" 
Me.cmdTheExtention.Location = New System.Drawing.Point(386,121)
Me.cmdTheExtention.name = "cmdTheExtention"
Me.cmdTheExtention.Size = New System.Drawing.Size(22, 20)
Me.cmdTheExtention.TabIndex = 35
Me.cmdTheExtention.Text = "..." 
Me.cmdTheExtentionClear.Location = New System.Drawing.Point(408,121)
Me.cmdTheExtentionClear.name = "cmdTheExtentionClear"
Me.cmdTheExtentionClear.Size = New System.Drawing.Size(22, 20)
Me.cmdTheExtentionClear.TabIndex = 36
Me.cmdTheExtentionClear.Text = "X" 
Me.lblARM.Location = New System.Drawing.Point(230,146)
Me.lblARM.name = "lblARM"
Me.lblARM.Size = New System.Drawing.Size(200, 20)
Me.lblARM.TabIndex = 37
Me.lblARM.Text = "АРМ"
Me.lblARM.ForeColor = System.Drawing.Color.Blue
Me.txtARM.Location = New System.Drawing.Point(230,168)
Me.txtARM.name = "txtARM"
Me.txtARM.ReadOnly = True
Me.txtARM.Size = New System.Drawing.Size(155, 20)
Me.txtARM.TabIndex = 38
Me.txtARM.Text = "" 
Me.cmdARM.Location = New System.Drawing.Point(386,168)
Me.cmdARM.name = "cmdARM"
Me.cmdARM.Size = New System.Drawing.Size(22, 20)
Me.cmdARM.TabIndex = 39
Me.cmdARM.Text = "..." 
Me.cmdARMClear.Location = New System.Drawing.Point(408,168)
Me.cmdARMClear.name = "cmdARMClear"
Me.cmdARMClear.Size = New System.Drawing.Size(22, 20)
Me.cmdARMClear.TabIndex = 40
Me.cmdARMClear.Text = "X" 
Me.lblTheComment.Location = New System.Drawing.Point(230,193)
Me.lblTheComment.name = "lblTheComment"
Me.lblTheComment.Size = New System.Drawing.Size(200, 20)
Me.lblTheComment.TabIndex = 41
Me.lblTheComment.Text = "Примечание"
Me.lblTheComment.ForeColor = System.Drawing.Color.Blue
Me.txtTheComment.Location = New System.Drawing.Point(230,215)
Me.txtTheComment.name = "txtTheComment"
Me.txtTheComment.MultiLine = True
Me.txtTheComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtTheComment.Size = New System.Drawing.Size(200, 50 + 20)
Me.txtTheComment.TabIndex = 42
Me.txtTheComment.Text = "" 
Me.lblObjectType.Location = New System.Drawing.Point(230,285)
Me.lblObjectType.name = "lblObjectType"
Me.lblObjectType.Size = New System.Drawing.Size(200, 20)
Me.lblObjectType.TabIndex = 43
Me.lblObjectType.Text = "Тип документа"
Me.lblObjectType.ForeColor = System.Drawing.Color.Blue
Me.txtObjectType.Location = New System.Drawing.Point(230,307)
Me.txtObjectType.name = "txtObjectType"
Me.txtObjectType.ReadOnly = True
Me.txtObjectType.Size = New System.Drawing.Size(155, 20)
Me.txtObjectType.TabIndex = 44
Me.txtObjectType.Text = "" 
Me.cmdObjectType.Location = New System.Drawing.Point(386,307)
Me.cmdObjectType.name = "cmdObjectType"
Me.cmdObjectType.Size = New System.Drawing.Size(22, 20)
Me.cmdObjectType.TabIndex = 45
Me.cmdObjectType.Text = "..." 
Me.cmdObjectTypeClear.Location = New System.Drawing.Point(408,307)
Me.cmdObjectTypeClear.name = "cmdObjectTypeClear"
Me.cmdObjectTypeClear.Size = New System.Drawing.Size(22, 20)
Me.cmdObjectTypeClear.TabIndex = 46
Me.cmdObjectTypeClear.Text = "X" 
Me.lblJournalFixedQuery.Location = New System.Drawing.Point(230,332)
Me.lblJournalFixedQuery.name = "lblJournalFixedQuery"
Me.lblJournalFixedQuery.Size = New System.Drawing.Size(200, 20)
Me.lblJournalFixedQuery.TabIndex = 47
Me.lblJournalFixedQuery.Text = "Ограничения к журналу"
Me.lblJournalFixedQuery.ForeColor = System.Drawing.Color.Blue
Me.txtJournalFixedQuery.Location = New System.Drawing.Point(230,354)
Me.txtJournalFixedQuery.name = "txtJournalFixedQuery"
Me.txtJournalFixedQuery.MultiLine = True
Me.txtJournalFixedQuery.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtJournalFixedQuery.Size = New System.Drawing.Size(200, 50 + 20)
Me.txtJournalFixedQuery.TabIndex = 48
Me.txtJournalFixedQuery.Text = "" 
Me.lblAllowAdd.Location = New System.Drawing.Point(440,5)
Me.lblAllowAdd.name = "lblAllowAdd"
Me.lblAllowAdd.Size = New System.Drawing.Size(200, 20)
Me.lblAllowAdd.TabIndex = 49
Me.lblAllowAdd.Text = "Разрешено добавление"
Me.lblAllowAdd.ForeColor = System.Drawing.Color.Black
Me.cmbAllowAdd.Location = New System.Drawing.Point(440,27)
Me.cmbAllowAdd.name = "cmbAllowAdd"
Me.cmbAllowAdd.Size = New System.Drawing.Size(200,  20)
Me.cmbAllowAdd.TabIndex = 50
Me.lblAllowEdit.Location = New System.Drawing.Point(440,52)
Me.lblAllowEdit.name = "lblAllowEdit"
Me.lblAllowEdit.Size = New System.Drawing.Size(200, 20)
Me.lblAllowEdit.TabIndex = 51
Me.lblAllowEdit.Text = "Разрешено редактирование"
Me.lblAllowEdit.ForeColor = System.Drawing.Color.Black
Me.cmbAllowEdit.Location = New System.Drawing.Point(440,74)
Me.cmbAllowEdit.name = "cmbAllowEdit"
Me.cmbAllowEdit.Size = New System.Drawing.Size(200,  20)
Me.cmbAllowEdit.TabIndex = 52
Me.lblAllowDel.Location = New System.Drawing.Point(440,99)
Me.lblAllowDel.name = "lblAllowDel"
Me.lblAllowDel.Size = New System.Drawing.Size(200, 20)
Me.lblAllowDel.TabIndex = 53
Me.lblAllowDel.Text = "Рарешено удаление"
Me.lblAllowDel.ForeColor = System.Drawing.Color.Black
Me.cmbAllowDel.Location = New System.Drawing.Point(440,121)
Me.cmbAllowDel.name = "cmbAllowDel"
Me.cmbAllowDel.Size = New System.Drawing.Size(200,  20)
Me.cmbAllowDel.TabIndex = 54
Me.lblAllowFilter.Location = New System.Drawing.Point(440,146)
Me.lblAllowFilter.name = "lblAllowFilter"
Me.lblAllowFilter.Size = New System.Drawing.Size(200, 20)
Me.lblAllowFilter.TabIndex = 55
Me.lblAllowFilter.Text = "Разрешен фильтр"
Me.lblAllowFilter.ForeColor = System.Drawing.Color.Black
Me.cmbAllowFilter.Location = New System.Drawing.Point(440,168)
Me.cmbAllowFilter.name = "cmbAllowFilter"
Me.cmbAllowFilter.Size = New System.Drawing.Size(200,  20)
Me.cmbAllowFilter.TabIndex = 56
Me.lblAllowPrint.Location = New System.Drawing.Point(440,193)
Me.lblAllowPrint.name = "lblAllowPrint"
Me.lblAllowPrint.Size = New System.Drawing.Size(200, 20)
Me.lblAllowPrint.TabIndex = 57
Me.lblAllowPrint.Text = "Разрешена печать"
Me.lblAllowPrint.ForeColor = System.Drawing.Color.Black
Me.cmbAllowPrint.Location = New System.Drawing.Point(440,215)
Me.cmbAllowPrint.name = "cmbAllowPrint"
Me.cmbAllowPrint.Size = New System.Drawing.Size(200,  20)
Me.cmbAllowPrint.TabIndex = 58
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblsequence)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtsequence)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblCaption)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtCaption)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblAsToolbarItem)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbAsToolbarItem)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblActionType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbActionType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTheFilter)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTheFilter)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdTheFilter)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdTheFilterClear)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblJournal)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtJournal)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdJournal)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdJournalClear)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblReport)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtReport)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdReport)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdReportClear)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblDocument)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtDocument)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdDocument)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdDocumentClear)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblMethod)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtMethod)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdMethod)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdMethodClear)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblIconFile)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtIconFile)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTheExtention)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTheExtention)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdTheExtention)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdTheExtentionClear)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblARM)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtARM)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdARM)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdARMClear)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTheComment)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTheComment)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblObjectType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtObjectType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdObjectType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdObjectTypeClear)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblJournalFixedQuery)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtJournalFixedQuery)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblAllowAdd)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbAllowAdd)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblAllowEdit)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbAllowEdit)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblAllowDel)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbAllowDel)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblAllowFilter)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbAllowFilter)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblAllowPrint)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbAllowPrint)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editEntryPoints"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

        Private Sub txtsequence_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtsequence.Validating
        If txtsequence.Text <> "" Then
            try
            If Not IsNumeric(txtsequence.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtsequence.Text) < -2000000000 Or Val(txtsequence.Text) > 2000000000 Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
            Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtsequence_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsequence.TextChanged
  Changing

end sub
private sub txtName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
  Changing

end sub
private sub txtCaption_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCaption.TextChanged
  Changing

end sub
private sub cmbAsToolbarItem_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAsToolbarItem.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmbActionType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbActionType.SelectedIndexChanged
  try
     Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtTheFilter_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTheFilter.TextChanged
  Changing

end sub
private sub cmdTheFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTheFilter.Click
  try
Dim id As guid
Dim brief As String  = string.Empty
Dim OK as boolean
       OK=GuiManager.GetObjectDialog("MTZFltr","",id,brief)
If OK Then
    txtTheFilter.Text = brief
    txtTheFilter.Tag = id
End If
        catch ex as system.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
End Sub
private sub txtJournal_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtJournal.TextChanged
  Changing

end sub
private sub cmdJournal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdJournal.Click
  try
Dim id As guid
Dim brief As String  = string.Empty
Dim OK as boolean
       OK=GuiManager.GetObjectDialog("MTZJrnl","",id,brief)
If OK Then
    txtJournal.Text = brief
    txtJournal.Tag = id
End If
        catch ex as system.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
End Sub
private sub txtReport_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtReport.TextChanged
  Changing

end sub
private sub cmdReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReport.Click
  try
Dim id As guid
Dim brief As String  = string.Empty
Dim OK as boolean
       OK=GuiManager.GetObjectDialog("MTZRprt","",id,brief)
If OK Then
    txtReport.Text = brief
    txtReport.Tag = id
End If
        catch ex as system.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
End Sub
private sub txtDocument_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDocument.TextChanged
  Changing

end sub
private sub cmdDocument_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDocument.Click
  try
Dim id As guid
Dim brief As String  = string.Empty
Dim OK as boolean
        OK=GuiManager.GetObjectDialog("","",id,brief)
If OK Then
    txtDocument.Text = brief
    txtDocument.Tag = id
End If
        catch ex as system.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
End Sub
private sub txtMethod_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMethod.TextChanged
  Changing

end sub
private sub cmdMethod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMethod.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("SHAREDMETHOD","",System.guid.Empty, id, brief) Then
          txtMethod.Tag = id
          txtMethod.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmdMethodClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMethodClear.Click
  try
          txtMethod.Tag = Guid.Empty
          txtMethod.text = ""
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtIconFile_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIconFile.TextChanged
  Changing

end sub
private sub txtTheExtention_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTheExtention.TextChanged
  Changing

end sub
private sub cmdTheExtention_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTheExtention.Click
  try
Dim id As guid
Dim brief As String  = string.Empty
Dim OK as boolean
       OK=GuiManager.GetObjectDialog("MTZExt","",id,brief)
If OK Then
    txtTheExtention.Text = brief
    txtTheExtention.Tag = id
End If
        catch ex as system.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
End Sub
private sub txtARM_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtARM.TextChanged
  Changing

end sub
private sub cmdARM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdARM.Click
  try
Dim id As guid
Dim brief As String  = string.Empty
Dim OK as boolean
       OK=GuiManager.GetObjectDialog("MTZwp","",id,brief)
If OK Then
    txtARM.Text = brief
    txtARM.Tag = id
End If
        catch ex as system.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
End Sub
private sub txtTheComment_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTheComment.TextChanged
  Changing

end sub
private sub txtObjectType_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtObjectType.TextChanged
  Changing

end sub
private sub cmdObjectType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdObjectType.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("OBJECTTYPE","",System.guid.Empty, id, brief) Then
          txtObjectType.Tag = id
          txtObjectType.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmdObjectTypeClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdObjectTypeClear.Click
  try
          txtObjectType.Tag = Guid.Empty
          txtObjectType.text = ""
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtJournalFixedQuery_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtJournalFixedQuery.TextChanged
  Changing

end sub
private sub cmbAllowAdd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAllowAdd.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmbAllowEdit_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAllowEdit.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmbAllowDel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAllowDel.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmbAllowFilter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAllowFilter.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmbAllowPrint_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAllowPrint.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub

Public Item As MTZwp.MTZwp.EntryPoints
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,MTZwp.MTZwp.EntryPoints)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

txtsequence.text = item.sequence.toString()
txtName.text = item.Name
txtCaption.text = item.Caption
cmbAsToolbarItemData = New DataTable
cmbAsToolbarItemData.Columns.Add("name", GetType(System.String))
cmbAsToolbarItemData.Columns.Add("Value", GetType(System.Int32))
try
cmbAsToolbarItemDataRow = cmbAsToolbarItemData.NewRow
cmbAsToolbarItemDataRow("name") = "Да"
cmbAsToolbarItemDataRow("Value") = -1
cmbAsToolbarItemData.Rows.Add (cmbAsToolbarItemDataRow)
cmbAsToolbarItemDataRow = cmbAsToolbarItemData.NewRow
cmbAsToolbarItemDataRow("name") = "Нет"
cmbAsToolbarItemDataRow("Value") = 0
cmbAsToolbarItemData.Rows.Add (cmbAsToolbarItemDataRow)
cmbAsToolbarItem.DisplayMember = "name"
cmbAsToolbarItem.ValueMember = "Value"
cmbAsToolbarItem.DataSource = cmbAsToolbarItemData
 cmbAsToolbarItem.SelectedValue=CInt(Item.AsToolbarItem)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
cmbActionTypeData = New DataTable
cmbActionTypeData.Columns.Add("name", GetType(System.String))
cmbActionTypeData.Columns.Add("Value", GetType(System.Int32))
try
cmbActionTypeDataRow = cmbActionTypeData.NewRow
cmbActionTypeDataRow("name") = "Ничего не делать"
cmbActionTypeDataRow("Value") = 0
cmbActionTypeData.Rows.Add (cmbActionTypeDataRow)
cmbActionTypeDataRow = cmbActionTypeData.NewRow
cmbActionTypeDataRow("name") = "Открыть документ"
cmbActionTypeDataRow("Value") = 1
cmbActionTypeData.Rows.Add (cmbActionTypeDataRow)
cmbActionTypeDataRow = cmbActionTypeData.NewRow
cmbActionTypeDataRow("name") = "Выполнить метод"
cmbActionTypeDataRow("Value") = 2
cmbActionTypeData.Rows.Add (cmbActionTypeDataRow)
cmbActionTypeDataRow = cmbActionTypeData.NewRow
cmbActionTypeDataRow("name") = "Открыть журнал"
cmbActionTypeDataRow("Value") = 3
cmbActionTypeData.Rows.Add (cmbActionTypeDataRow)
cmbActionTypeDataRow = cmbActionTypeData.NewRow
cmbActionTypeDataRow("name") = "Запустить АРМ"
cmbActionTypeDataRow("Value") = 4
cmbActionTypeData.Rows.Add (cmbActionTypeDataRow)
cmbActionTypeDataRow = cmbActionTypeData.NewRow
cmbActionTypeDataRow("name") = "Открыть отчет"
cmbActionTypeDataRow("Value") = 5
cmbActionTypeData.Rows.Add (cmbActionTypeDataRow)
cmbActionType.DisplayMember = "name"
cmbActionType.ValueMember = "Value"
cmbActionType.DataSource = cmbActionTypeData
 cmbActionType.SelectedValue=CInt(Item.ActionType)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
If Not item.TheFilter Is Nothing Then
  txtTheFilter.Tag = item.TheFilter.id
  txtTheFilter.text = item.TheFilter.brief
else
  txtTheFilter.Tag = System.Guid.Empty 
  txtTheFilter.text = "" 
End If
If Not item.Journal Is Nothing Then
  txtJournal.Tag = item.Journal.id
  txtJournal.text = item.Journal.brief
else
  txtJournal.Tag = System.Guid.Empty 
  txtJournal.text = "" 
End If
If Not item.Report Is Nothing Then
  txtReport.Tag = item.Report.id
  txtReport.text = item.Report.brief
else
  txtReport.Tag = System.Guid.Empty 
  txtReport.text = "" 
End If
If Not item.Document Is Nothing Then
  txtDocument.Tag = item.Document.id
  txtDocument.text = item.Document.brief
else
  txtDocument.Tag = System.Guid.Empty 
  txtDocument.text = "" 
End If
If Not item.Method Is Nothing Then
  txtMethod.Tag = item.Method.id
  txtMethod.text = item.Method.brief
else
  txtMethod.Tag = System.Guid.Empty 
  txtMethod.text = "" 
End If
txtIconFile.text = item.IconFile
If Not item.TheExtention Is Nothing Then
  txtTheExtention.Tag = item.TheExtention.id
  txtTheExtention.text = item.TheExtention.brief
else
  txtTheExtention.Tag = System.Guid.Empty 
  txtTheExtention.text = "" 
End If
If Not item.ARM Is Nothing Then
  txtARM.Tag = item.ARM.id
  txtARM.text = item.ARM.brief
else
  txtARM.Tag = System.Guid.Empty 
  txtARM.text = "" 
End If
txtTheComment.text = item.TheComment
If Not item.ObjectType Is Nothing Then
  txtObjectType.Tag = item.ObjectType.id
  txtObjectType.text = item.ObjectType.brief
else
  txtObjectType.Tag = System.Guid.Empty 
  txtObjectType.text = "" 
End If
txtJournalFixedQuery.text = item.JournalFixedQuery
cmbAllowAddData = New DataTable
cmbAllowAddData.Columns.Add("name", GetType(System.String))
cmbAllowAddData.Columns.Add("Value", GetType(System.Int32))
try
cmbAllowAddDataRow = cmbAllowAddData.NewRow
cmbAllowAddDataRow("name") = "Да"
cmbAllowAddDataRow("Value") = -1
cmbAllowAddData.Rows.Add (cmbAllowAddDataRow)
cmbAllowAddDataRow = cmbAllowAddData.NewRow
cmbAllowAddDataRow("name") = "Нет"
cmbAllowAddDataRow("Value") = 0
cmbAllowAddData.Rows.Add (cmbAllowAddDataRow)
cmbAllowAdd.DisplayMember = "name"
cmbAllowAdd.ValueMember = "Value"
cmbAllowAdd.DataSource = cmbAllowAddData
 cmbAllowAdd.SelectedValue=CInt(Item.AllowAdd)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
cmbAllowEditData = New DataTable
cmbAllowEditData.Columns.Add("name", GetType(System.String))
cmbAllowEditData.Columns.Add("Value", GetType(System.Int32))
try
cmbAllowEditDataRow = cmbAllowEditData.NewRow
cmbAllowEditDataRow("name") = "Да"
cmbAllowEditDataRow("Value") = -1
cmbAllowEditData.Rows.Add (cmbAllowEditDataRow)
cmbAllowEditDataRow = cmbAllowEditData.NewRow
cmbAllowEditDataRow("name") = "Нет"
cmbAllowEditDataRow("Value") = 0
cmbAllowEditData.Rows.Add (cmbAllowEditDataRow)
cmbAllowEdit.DisplayMember = "name"
cmbAllowEdit.ValueMember = "Value"
cmbAllowEdit.DataSource = cmbAllowEditData
 cmbAllowEdit.SelectedValue=CInt(Item.AllowEdit)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
cmbAllowDelData = New DataTable
cmbAllowDelData.Columns.Add("name", GetType(System.String))
cmbAllowDelData.Columns.Add("Value", GetType(System.Int32))
try
cmbAllowDelDataRow = cmbAllowDelData.NewRow
cmbAllowDelDataRow("name") = "Да"
cmbAllowDelDataRow("Value") = -1
cmbAllowDelData.Rows.Add (cmbAllowDelDataRow)
cmbAllowDelDataRow = cmbAllowDelData.NewRow
cmbAllowDelDataRow("name") = "Нет"
cmbAllowDelDataRow("Value") = 0
cmbAllowDelData.Rows.Add (cmbAllowDelDataRow)
cmbAllowDel.DisplayMember = "name"
cmbAllowDel.ValueMember = "Value"
cmbAllowDel.DataSource = cmbAllowDelData
 cmbAllowDel.SelectedValue=CInt(Item.AllowDel)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
cmbAllowFilterData = New DataTable
cmbAllowFilterData.Columns.Add("name", GetType(System.String))
cmbAllowFilterData.Columns.Add("Value", GetType(System.Int32))
try
cmbAllowFilterDataRow = cmbAllowFilterData.NewRow
cmbAllowFilterDataRow("name") = "Да"
cmbAllowFilterDataRow("Value") = -1
cmbAllowFilterData.Rows.Add (cmbAllowFilterDataRow)
cmbAllowFilterDataRow = cmbAllowFilterData.NewRow
cmbAllowFilterDataRow("name") = "Нет"
cmbAllowFilterDataRow("Value") = 0
cmbAllowFilterData.Rows.Add (cmbAllowFilterDataRow)
cmbAllowFilter.DisplayMember = "name"
cmbAllowFilter.ValueMember = "Value"
cmbAllowFilter.DataSource = cmbAllowFilterData
 cmbAllowFilter.SelectedValue=CInt(Item.AllowFilter)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
cmbAllowPrintData = New DataTable
cmbAllowPrintData.Columns.Add("name", GetType(System.String))
cmbAllowPrintData.Columns.Add("Value", GetType(System.Int32))
try
cmbAllowPrintDataRow = cmbAllowPrintData.NewRow
cmbAllowPrintDataRow("name") = "Да"
cmbAllowPrintDataRow("Value") = -1
cmbAllowPrintData.Rows.Add (cmbAllowPrintDataRow)
cmbAllowPrintDataRow = cmbAllowPrintData.NewRow
cmbAllowPrintDataRow("name") = "Нет"
cmbAllowPrintDataRow("Value") = 0
cmbAllowPrintData.Rows.Add (cmbAllowPrintDataRow)
cmbAllowPrint.DisplayMember = "name"
cmbAllowPrint.ValueMember = "Value"
cmbAllowPrint.DataSource = cmbAllowPrintData
 cmbAllowPrint.SelectedValue=CInt(Item.AllowPrint)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
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

item.sequence = val(txtsequence.text)
item.Name = txtName.text
item.Caption = txtCaption.text
   item.AsToolbarItem = cmbAsToolbarItem.SelectedValue
   item.ActionType = cmbActionType.SelectedValue
If not txtTheFilter.Tag.Equals(System.Guid.Empty) Then
   item.TheFilter = GuiManager.Manager.GetInstanceObject(txtTheFilter.Tag)
Else
   item.TheFilter = Nothing
End If
If not txtJournal.Tag.Equals(System.Guid.Empty) Then
   item.Journal = GuiManager.Manager.GetInstanceObject(txtJournal.Tag)
Else
   item.Journal = Nothing
End If
If not txtReport.Tag.Equals(System.Guid.Empty) Then
   item.Report = GuiManager.Manager.GetInstanceObject(txtReport.Tag)
Else
   item.Report = Nothing
End If
If not txtDocument.Tag.Equals(System.Guid.Empty) Then
   item.Document = GuiManager.Manager.GetInstanceObject(txtDocument.Tag)
Else
   item.Document = Nothing
End If
If not txtMethod.Tag.Equals(System.Guid.Empty) Then
  item.Method = Item.Application.FindRowObject("SHAREDMETHOD",txtMethod.Tag)
Else
   item.Method = Nothing
End If
item.IconFile = txtIconFile.text
If not txtTheExtention.Tag.Equals(System.Guid.Empty) Then
   item.TheExtention = GuiManager.Manager.GetInstanceObject(txtTheExtention.Tag)
Else
   item.TheExtention = Nothing
End If
If not txtARM.Tag.Equals(System.Guid.Empty) Then
   item.ARM = GuiManager.Manager.GetInstanceObject(txtARM.Tag)
Else
   item.ARM = Nothing
End If
item.TheComment = txtTheComment.text
If not txtObjectType.Tag.Equals(System.Guid.Empty) Then
  item.ObjectType = Item.Application.FindRowObject("OBJECTTYPE",txtObjectType.Tag)
Else
   item.ObjectType = Nothing
End If
item.JournalFixedQuery = txtJournalFixedQuery.text
   item.AllowAdd = cmbAllowAdd.SelectedValue
   item.AllowEdit = cmbAllowEdit.SelectedValue
   item.AllowDel = cmbAllowDel.SelectedValue
   item.AllowFilter = cmbAllowFilter.SelectedValue
   item.AllowPrint = cmbAllowPrint.SelectedValue
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK =( txtsequence.text <> "" ) 
if mIsOK then mIsOK =( txtName.text <> "" ) 
if mIsOK then mIsOK =( txtCaption.text <> "" ) 
if mIsOK then mIsOK =(cmbAsToolbarItem.SelectedIndex >=0)
if mIsOK then mIsOK =(cmbActionType.SelectedIndex >=0)
if mIsOK then mIsOK =(cmbAllowAdd.SelectedIndex >=0)
if mIsOK then mIsOK =(cmbAllowEdit.SelectedIndex >=0)
if mIsOK then mIsOK =(cmbAllowDel.SelectedIndex >=0)
if mIsOK then mIsOK =(cmbAllowFilter.SelectedIndex >=0)
if mIsOK then mIsOK =(cmbAllowPrint.SelectedIndex >=0)
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
