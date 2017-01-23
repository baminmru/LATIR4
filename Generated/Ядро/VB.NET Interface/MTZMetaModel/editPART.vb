
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Раздел режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editPART
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
Friend WithEvents lblSequence  as  System.Windows.Forms.Label
Friend WithEvents txtSequence As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblPartType  as  System.Windows.Forms.Label
Friend WithEvents cmbPartType As System.Windows.Forms.ComboBox
Friend cmbPartTypeDATA As DataTable
Friend cmbPartTypeDATAROW As DataRow
Friend WithEvents lblCaption  as  System.Windows.Forms.Label
Friend WithEvents txtCaption As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblName  as  System.Windows.Forms.Label
Friend WithEvents txtName As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblthe_Comment  as  System.Windows.Forms.Label
Friend WithEvents txtthe_Comment As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblNoLog  as  System.Windows.Forms.Label
Friend WithEvents cmbNoLog As System.Windows.Forms.ComboBox
Friend cmbNoLogDATA As DataTable
Friend cmbNoLogDATAROW As DataRow
Friend WithEvents lblManualRegister  as  System.Windows.Forms.Label
Friend WithEvents cmbManualRegister As System.Windows.Forms.ComboBox
Friend cmbManualRegisterDATA As DataTable
Friend cmbManualRegisterDATAROW As DataRow
Friend WithEvents lblOnCreate  as  System.Windows.Forms.Label
Friend WithEvents txtOnCreate As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdOnCreate As System.Windows.Forms.Button
Friend WithEvents cmdOnCreateClear As System.Windows.Forms.Button
Friend WithEvents lblOnSave  as  System.Windows.Forms.Label
Friend WithEvents txtOnSave As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdOnSave As System.Windows.Forms.Button
Friend WithEvents cmdOnSaveClear As System.Windows.Forms.Button
Friend WithEvents lblOnRun  as  System.Windows.Forms.Label
Friend WithEvents txtOnRun As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdOnRun As System.Windows.Forms.Button
Friend WithEvents cmdOnRunClear As System.Windows.Forms.Button
Friend WithEvents lblOnDelete  as  System.Windows.Forms.Label
Friend WithEvents txtOnDelete As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdOnDelete As System.Windows.Forms.Button
Friend WithEvents cmdOnDeleteClear As System.Windows.Forms.Button
Friend WithEvents lblAddBehaivor  as  System.Windows.Forms.Label
Friend WithEvents cmbAddBehaivor As System.Windows.Forms.ComboBox
Friend cmbAddBehaivorDATA As DataTable
Friend cmbAddBehaivorDATAROW As DataRow
Friend WithEvents lblExtenderObject  as  System.Windows.Forms.Label
Friend WithEvents txtExtenderObject As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdExtenderObject As System.Windows.Forms.Button
Friend WithEvents cmdExtenderObjectClear As System.Windows.Forms.Button
Friend WithEvents lblshablonBrief  as  System.Windows.Forms.Label
Friend WithEvents txtshablonBrief As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblruleBrief  as  System.Windows.Forms.Label
Friend WithEvents txtruleBrief As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblIsJormalChange  as  System.Windows.Forms.Label
Friend WithEvents cmbIsJormalChange As System.Windows.Forms.ComboBox
Friend cmbIsJormalChangeDATA As DataTable
Friend cmbIsJormalChangeDATAROW As DataRow
Friend WithEvents lblUseArchiving  as  System.Windows.Forms.Label
Friend WithEvents cmbUseArchiving As System.Windows.Forms.ComboBox
Friend cmbUseArchivingDATA As DataTable
Friend cmbUseArchivingDATAROW As DataRow
Friend WithEvents lblintegerpkey  as  System.Windows.Forms.Label
Friend WithEvents cmbintegerpkey As System.Windows.Forms.ComboBox
Friend cmbintegerpkeyDATA As DataTable
Friend cmbintegerpkeyDATAROW As DataRow
Friend WithEvents lblpartIconCls  as  System.Windows.Forms.Label
Friend WithEvents txtpartIconCls As LATIR2GuiManager.TouchTextBox

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
Me.lblSequence = New System.Windows.Forms.Label
Me.txtSequence = New LATIR2GuiManager.TouchTextBox
Me.lblPartType = New System.Windows.Forms.Label
Me.cmbPartType = New System.Windows.Forms.ComboBox
Me.lblCaption = New System.Windows.Forms.Label
Me.txtCaption = New LATIR2GuiManager.TouchTextBox
Me.lblName = New System.Windows.Forms.Label
Me.txtName = New LATIR2GuiManager.TouchTextBox
Me.lblthe_Comment = New System.Windows.Forms.Label
Me.txtthe_Comment = New LATIR2GuiManager.TouchTextBox
Me.lblNoLog = New System.Windows.Forms.Label
Me.cmbNoLog = New System.Windows.Forms.ComboBox
Me.lblManualRegister = New System.Windows.Forms.Label
Me.cmbManualRegister = New System.Windows.Forms.ComboBox
Me.lblOnCreate = New System.Windows.Forms.Label
Me.txtOnCreate = New LATIR2GuiManager.TouchTextBox
Me.cmdOnCreate = New System.Windows.Forms.Button
Me.cmdOnCreateClear = New System.Windows.Forms.Button
Me.lblOnSave = New System.Windows.Forms.Label
Me.txtOnSave = New LATIR2GuiManager.TouchTextBox
Me.cmdOnSave = New System.Windows.Forms.Button
Me.cmdOnSaveClear = New System.Windows.Forms.Button
Me.lblOnRun = New System.Windows.Forms.Label
Me.txtOnRun = New LATIR2GuiManager.TouchTextBox
Me.cmdOnRun = New System.Windows.Forms.Button
Me.cmdOnRunClear = New System.Windows.Forms.Button
Me.lblOnDelete = New System.Windows.Forms.Label
Me.txtOnDelete = New LATIR2GuiManager.TouchTextBox
Me.cmdOnDelete = New System.Windows.Forms.Button
Me.cmdOnDeleteClear = New System.Windows.Forms.Button
Me.lblAddBehaivor = New System.Windows.Forms.Label
Me.cmbAddBehaivor = New System.Windows.Forms.ComboBox
Me.lblExtenderObject = New System.Windows.Forms.Label
Me.txtExtenderObject = New LATIR2GuiManager.TouchTextBox
Me.cmdExtenderObject = New System.Windows.Forms.Button
Me.cmdExtenderObjectClear = New System.Windows.Forms.Button
Me.lblshablonBrief = New System.Windows.Forms.Label
Me.txtshablonBrief = New LATIR2GuiManager.TouchTextBox
Me.lblruleBrief = New System.Windows.Forms.Label
Me.txtruleBrief = New LATIR2GuiManager.TouchTextBox
Me.lblIsJormalChange = New System.Windows.Forms.Label
Me.cmbIsJormalChange = New System.Windows.Forms.ComboBox
Me.lblUseArchiving = New System.Windows.Forms.Label
Me.cmbUseArchiving = New System.Windows.Forms.ComboBox
Me.lblintegerpkey = New System.Windows.Forms.Label
Me.cmbintegerpkey = New System.Windows.Forms.ComboBox
Me.lblpartIconCls = New System.Windows.Forms.Label
Me.txtpartIconCls = New LATIR2GuiManager.TouchTextBox

Me.lblSequence.Location = New System.Drawing.Point(20,5)
Me.lblSequence.name = "lblSequence"
Me.lblSequence.Size = New System.Drawing.Size(200, 20)
Me.lblSequence.TabIndex = 1
Me.lblSequence.Text = "№ п/п"
Me.lblSequence.ForeColor = System.Drawing.Color.Black
Me.txtSequence.Location = New System.Drawing.Point(20,27)
Me.txtSequence.name = "txtSequence"
Me.txtSequence.MultiLine = false
Me.txtSequence.Size = New System.Drawing.Size(200,  20)
Me.txtSequence.TabIndex = 2
Me.txtSequence.Text = "" 
Me.txtSequence.MaxLength = 15
Me.lblPartType.Location = New System.Drawing.Point(20,52)
Me.lblPartType.name = "lblPartType"
Me.lblPartType.Size = New System.Drawing.Size(200, 20)
Me.lblPartType.TabIndex = 3
Me.lblPartType.Text = "Тип структры"
Me.lblPartType.ForeColor = System.Drawing.Color.Black
Me.cmbPartType.Location = New System.Drawing.Point(20,74)
Me.cmbPartType.name = "cmbPartType"
Me.cmbPartType.Size = New System.Drawing.Size(200,  20)
Me.cmbPartType.TabIndex = 4
Me.cmbPartType.DropDownStyle = ComboBoxStyle.DropDownList
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
Me.lblName.Location = New System.Drawing.Point(20,146)
Me.lblName.name = "lblName"
Me.lblName.Size = New System.Drawing.Size(200, 20)
Me.lblName.TabIndex = 7
Me.lblName.Text = "Название"
Me.lblName.ForeColor = System.Drawing.Color.Black
Me.txtName.Location = New System.Drawing.Point(20,168)
Me.txtName.name = "txtName"
Me.txtName.Size = New System.Drawing.Size(200, 20)
Me.txtName.TabIndex = 8
Me.txtName.Text = "" 
Me.lblthe_Comment.Location = New System.Drawing.Point(20,193)
Me.lblthe_Comment.name = "lblthe_Comment"
Me.lblthe_Comment.Size = New System.Drawing.Size(200, 20)
Me.lblthe_Comment.TabIndex = 9
Me.lblthe_Comment.Text = "Описание"
Me.lblthe_Comment.ForeColor = System.Drawing.Color.Blue
Me.txtthe_Comment.Location = New System.Drawing.Point(20,215)
Me.txtthe_Comment.name = "txtthe_Comment"
Me.txtthe_Comment.MultiLine = True
Me.txtthe_Comment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtthe_Comment.Size = New System.Drawing.Size(200, 50 + 20)
Me.txtthe_Comment.TabIndex = 10
Me.txtthe_Comment.Text = "" 
Me.lblNoLog.Location = New System.Drawing.Point(20,285)
Me.lblNoLog.name = "lblNoLog"
Me.lblNoLog.Size = New System.Drawing.Size(200, 20)
Me.lblNoLog.TabIndex = 11
Me.lblNoLog.Text = "Не записывать в журнал"
Me.lblNoLog.ForeColor = System.Drawing.Color.Black
Me.cmbNoLog.Location = New System.Drawing.Point(20,307)
Me.cmbNoLog.name = "cmbNoLog"
Me.cmbNoLog.Size = New System.Drawing.Size(200,  20)
Me.cmbNoLog.TabIndex = 12
Me.lblManualRegister.Location = New System.Drawing.Point(20,332)
Me.lblManualRegister.name = "lblManualRegister"
Me.lblManualRegister.Size = New System.Drawing.Size(200, 20)
Me.lblManualRegister.TabIndex = 13
Me.lblManualRegister.Text = "Исключить из индексирования"
Me.lblManualRegister.ForeColor = System.Drawing.Color.Black
Me.cmbManualRegister.Location = New System.Drawing.Point(20,354)
Me.cmbManualRegister.name = "cmbManualRegister"
Me.cmbManualRegister.Size = New System.Drawing.Size(200,  20)
Me.cmbManualRegister.TabIndex = 14
Me.lblOnCreate.Location = New System.Drawing.Point(20,379)
Me.lblOnCreate.name = "lblOnCreate"
Me.lblOnCreate.Size = New System.Drawing.Size(200, 20)
Me.lblOnCreate.TabIndex = 15
Me.lblOnCreate.Text = "При создании"
Me.lblOnCreate.ForeColor = System.Drawing.Color.Blue
Me.txtOnCreate.Location = New System.Drawing.Point(20,401)
Me.txtOnCreate.name = "txtOnCreate"
Me.txtOnCreate.ReadOnly = True
Me.txtOnCreate.Size = New System.Drawing.Size(155, 20)
Me.txtOnCreate.TabIndex = 16
Me.txtOnCreate.Text = "" 
Me.cmdOnCreate.Location = New System.Drawing.Point(176,401)
Me.cmdOnCreate.name = "cmdOnCreate"
Me.cmdOnCreate.Size = New System.Drawing.Size(22, 20)
Me.cmdOnCreate.TabIndex = 17
Me.cmdOnCreate.Text = "..." 
Me.cmdOnCreateClear.Location = New System.Drawing.Point(198,401)
Me.cmdOnCreateClear.name = "cmdOnCreateClear"
Me.cmdOnCreateClear.Size = New System.Drawing.Size(22, 20)
Me.cmdOnCreateClear.TabIndex = 18
Me.cmdOnCreateClear.Text = "X" 
Me.lblOnSave.Location = New System.Drawing.Point(230,5)
Me.lblOnSave.name = "lblOnSave"
Me.lblOnSave.Size = New System.Drawing.Size(200, 20)
Me.lblOnSave.TabIndex = 19
Me.lblOnSave.Text = "При сохранении"
Me.lblOnSave.ForeColor = System.Drawing.Color.Blue
Me.txtOnSave.Location = New System.Drawing.Point(230,27)
Me.txtOnSave.name = "txtOnSave"
Me.txtOnSave.ReadOnly = True
Me.txtOnSave.Size = New System.Drawing.Size(155, 20)
Me.txtOnSave.TabIndex = 20
Me.txtOnSave.Text = "" 
Me.cmdOnSave.Location = New System.Drawing.Point(386,27)
Me.cmdOnSave.name = "cmdOnSave"
Me.cmdOnSave.Size = New System.Drawing.Size(22, 20)
Me.cmdOnSave.TabIndex = 21
Me.cmdOnSave.Text = "..." 
Me.cmdOnSaveClear.Location = New System.Drawing.Point(408,27)
Me.cmdOnSaveClear.name = "cmdOnSaveClear"
Me.cmdOnSaveClear.Size = New System.Drawing.Size(22, 20)
Me.cmdOnSaveClear.TabIndex = 22
Me.cmdOnSaveClear.Text = "X" 
Me.lblOnRun.Location = New System.Drawing.Point(230,52)
Me.lblOnRun.name = "lblOnRun"
Me.lblOnRun.Size = New System.Drawing.Size(200, 20)
Me.lblOnRun.TabIndex = 23
Me.lblOnRun.Text = "При открытии"
Me.lblOnRun.ForeColor = System.Drawing.Color.Blue
Me.txtOnRun.Location = New System.Drawing.Point(230,74)
Me.txtOnRun.name = "txtOnRun"
Me.txtOnRun.ReadOnly = True
Me.txtOnRun.Size = New System.Drawing.Size(155, 20)
Me.txtOnRun.TabIndex = 24
Me.txtOnRun.Text = "" 
Me.cmdOnRun.Location = New System.Drawing.Point(386,74)
Me.cmdOnRun.name = "cmdOnRun"
Me.cmdOnRun.Size = New System.Drawing.Size(22, 20)
Me.cmdOnRun.TabIndex = 25
Me.cmdOnRun.Text = "..." 
Me.cmdOnRunClear.Location = New System.Drawing.Point(408,74)
Me.cmdOnRunClear.name = "cmdOnRunClear"
Me.cmdOnRunClear.Size = New System.Drawing.Size(22, 20)
Me.cmdOnRunClear.TabIndex = 26
Me.cmdOnRunClear.Text = "X" 
Me.lblOnDelete.Location = New System.Drawing.Point(230,99)
Me.lblOnDelete.name = "lblOnDelete"
Me.lblOnDelete.Size = New System.Drawing.Size(200, 20)
Me.lblOnDelete.TabIndex = 27
Me.lblOnDelete.Text = "При удалении"
Me.lblOnDelete.ForeColor = System.Drawing.Color.Blue
Me.txtOnDelete.Location = New System.Drawing.Point(230,121)
Me.txtOnDelete.name = "txtOnDelete"
Me.txtOnDelete.ReadOnly = True
Me.txtOnDelete.Size = New System.Drawing.Size(155, 20)
Me.txtOnDelete.TabIndex = 28
Me.txtOnDelete.Text = "" 
Me.cmdOnDelete.Location = New System.Drawing.Point(386,121)
Me.cmdOnDelete.name = "cmdOnDelete"
Me.cmdOnDelete.Size = New System.Drawing.Size(22, 20)
Me.cmdOnDelete.TabIndex = 29
Me.cmdOnDelete.Text = "..." 
Me.cmdOnDeleteClear.Location = New System.Drawing.Point(408,121)
Me.cmdOnDeleteClear.name = "cmdOnDeleteClear"
Me.cmdOnDeleteClear.Size = New System.Drawing.Size(22, 20)
Me.cmdOnDeleteClear.TabIndex = 30
Me.cmdOnDeleteClear.Text = "X" 
Me.lblAddBehaivor.Location = New System.Drawing.Point(230,146)
Me.lblAddBehaivor.name = "lblAddBehaivor"
Me.lblAddBehaivor.Size = New System.Drawing.Size(200, 20)
Me.lblAddBehaivor.TabIndex = 31
Me.lblAddBehaivor.Text = "Поведение при добавлении"
Me.lblAddBehaivor.ForeColor = System.Drawing.Color.Blue
Me.cmbAddBehaivor.Location = New System.Drawing.Point(230,168)
Me.cmbAddBehaivor.name = "cmbAddBehaivor"
Me.cmbAddBehaivor.Size = New System.Drawing.Size(200,  20)
Me.cmbAddBehaivor.TabIndex = 32
Me.cmbAddBehaivor.DropDownStyle = ComboBoxStyle.DropDownList
Me.lblExtenderObject.Location = New System.Drawing.Point(230,193)
Me.lblExtenderObject.name = "lblExtenderObject"
Me.lblExtenderObject.Size = New System.Drawing.Size(200, 20)
Me.lblExtenderObject.TabIndex = 33
Me.lblExtenderObject.Text = "Объект расширения"
Me.lblExtenderObject.ForeColor = System.Drawing.Color.Blue
Me.txtExtenderObject.Location = New System.Drawing.Point(230,215)
Me.txtExtenderObject.name = "txtExtenderObject"
Me.txtExtenderObject.ReadOnly = True
Me.txtExtenderObject.Size = New System.Drawing.Size(155, 20)
Me.txtExtenderObject.TabIndex = 34
Me.txtExtenderObject.Text = "" 
Me.cmdExtenderObject.Location = New System.Drawing.Point(386,215)
Me.cmdExtenderObject.name = "cmdExtenderObject"
Me.cmdExtenderObject.Size = New System.Drawing.Size(22, 20)
Me.cmdExtenderObject.TabIndex = 35
Me.cmdExtenderObject.Text = "..." 
Me.cmdExtenderObjectClear.Location = New System.Drawing.Point(408,215)
Me.cmdExtenderObjectClear.name = "cmdExtenderObjectClear"
Me.cmdExtenderObjectClear.Size = New System.Drawing.Size(22, 20)
Me.cmdExtenderObjectClear.TabIndex = 36
Me.cmdExtenderObjectClear.Text = "X" 
Me.lblshablonBrief.Location = New System.Drawing.Point(230,240)
Me.lblshablonBrief.name = "lblshablonBrief"
Me.lblshablonBrief.Size = New System.Drawing.Size(200, 20)
Me.lblshablonBrief.TabIndex = 37
Me.lblshablonBrief.Text = "Шаблон для краткого отображения"
Me.lblshablonBrief.ForeColor = System.Drawing.Color.Blue
Me.txtshablonBrief.Location = New System.Drawing.Point(230,262)
Me.txtshablonBrief.name = "txtshablonBrief"
Me.txtshablonBrief.Size = New System.Drawing.Size(200, 20)
Me.txtshablonBrief.TabIndex = 38
Me.txtshablonBrief.Text = "" 
Me.lblruleBrief.Location = New System.Drawing.Point(230,287)
Me.lblruleBrief.name = "lblruleBrief"
Me.lblruleBrief.Size = New System.Drawing.Size(200, 20)
Me.lblruleBrief.TabIndex = 39
Me.lblruleBrief.Text = "Правило составления BRIEF поля"
Me.lblruleBrief.ForeColor = System.Drawing.Color.Blue
Me.txtruleBrief.Location = New System.Drawing.Point(230,309)
Me.txtruleBrief.name = "txtruleBrief"
Me.txtruleBrief.Size = New System.Drawing.Size(200, 20)
Me.txtruleBrief.TabIndex = 40
Me.txtruleBrief.Text = "" 
Me.lblIsJormalChange.Location = New System.Drawing.Point(230,334)
Me.lblIsJormalChange.name = "lblIsJormalChange"
Me.lblIsJormalChange.Size = New System.Drawing.Size(200, 20)
Me.lblIsJormalChange.TabIndex = 41
Me.lblIsJormalChange.Text = "Вести журнал изменений"
Me.lblIsJormalChange.ForeColor = System.Drawing.Color.Black
Me.cmbIsJormalChange.Location = New System.Drawing.Point(230,356)
Me.cmbIsJormalChange.name = "cmbIsJormalChange"
Me.cmbIsJormalChange.Size = New System.Drawing.Size(200,  20)
Me.cmbIsJormalChange.TabIndex = 42
Me.lblUseArchiving.Location = New System.Drawing.Point(230,381)
Me.lblUseArchiving.name = "lblUseArchiving"
Me.lblUseArchiving.Size = New System.Drawing.Size(200, 20)
Me.lblUseArchiving.TabIndex = 43
Me.lblUseArchiving.Text = "Архивировать вместо удаления"
Me.lblUseArchiving.ForeColor = System.Drawing.Color.Black
Me.cmbUseArchiving.Location = New System.Drawing.Point(230,403)
Me.cmbUseArchiving.name = "cmbUseArchiving"
Me.cmbUseArchiving.Size = New System.Drawing.Size(200,  20)
Me.cmbUseArchiving.TabIndex = 44
Me.lblintegerpkey.Location = New System.Drawing.Point(440,5)
Me.lblintegerpkey.name = "lblintegerpkey"
Me.lblintegerpkey.Size = New System.Drawing.Size(200, 20)
Me.lblintegerpkey.TabIndex = 45
Me.lblintegerpkey.Text = "Целочисленный ключ"
Me.lblintegerpkey.ForeColor = System.Drawing.Color.Black
Me.cmbintegerpkey.Location = New System.Drawing.Point(440,27)
Me.cmbintegerpkey.name = "cmbintegerpkey"
Me.cmbintegerpkey.Size = New System.Drawing.Size(200,  20)
Me.cmbintegerpkey.TabIndex = 46
Me.lblpartIconCls.Location = New System.Drawing.Point(440,52)
Me.lblpartIconCls.name = "lblpartIconCls"
Me.lblpartIconCls.Size = New System.Drawing.Size(200, 20)
Me.lblpartIconCls.TabIndex = 47
Me.lblpartIconCls.Text = "Иконка раздела"
Me.lblpartIconCls.ForeColor = System.Drawing.Color.Blue
Me.txtpartIconCls.Location = New System.Drawing.Point(440,74)
Me.txtpartIconCls.name = "txtpartIconCls"
Me.txtpartIconCls.Size = New System.Drawing.Size(200, 20)
Me.txtpartIconCls.TabIndex = 48
Me.txtpartIconCls.Text = "" 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblSequence)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtSequence)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblPartType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbPartType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblCaption)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtCaption)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblthe_Comment)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtthe_Comment)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblNoLog)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbNoLog)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblManualRegister)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbManualRegister)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblOnCreate)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtOnCreate)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdOnCreate)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdOnCreateClear)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblOnSave)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtOnSave)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdOnSave)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdOnSaveClear)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblOnRun)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtOnRun)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdOnRun)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdOnRunClear)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblOnDelete)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtOnDelete)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdOnDelete)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdOnDeleteClear)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblAddBehaivor)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbAddBehaivor)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblExtenderObject)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtExtenderObject)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdExtenderObject)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdExtenderObjectClear)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblshablonBrief)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtshablonBrief)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblruleBrief)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtruleBrief)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblIsJormalChange)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbIsJormalChange)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblUseArchiving)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbUseArchiving)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblintegerpkey)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbintegerpkey)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblpartIconCls)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtpartIconCls)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editPART"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

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
private sub cmbPartType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPartType.SelectedIndexChanged
  try
     Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtCaption_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCaption.TextChanged
  Changing

end sub
private sub txtName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
  Changing

end sub
private sub txtthe_Comment_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtthe_Comment.TextChanged
  Changing

end sub
private sub cmbNoLog_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNoLog.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmbManualRegister_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbManualRegister.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtOnCreate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOnCreate.TextChanged
  Changing

end sub
private sub cmdOnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOnCreate.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("PARTMENU","",System.guid.Empty, id, brief) Then
          txtOnCreate.Tag = id
          txtOnCreate.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmdOnCreateClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOnCreateClear.Click
  try
          txtOnCreate.Tag = Guid.Empty
          txtOnCreate.text = ""
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtOnSave_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOnSave.TextChanged
  Changing

end sub
private sub cmdOnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOnSave.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("PARTMENU","",System.guid.Empty, id, brief) Then
          txtOnSave.Tag = id
          txtOnSave.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmdOnSaveClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOnSaveClear.Click
  try
          txtOnSave.Tag = Guid.Empty
          txtOnSave.text = ""
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtOnRun_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOnRun.TextChanged
  Changing

end sub
private sub cmdOnRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOnRun.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("PARTMENU","",System.guid.Empty, id, brief) Then
          txtOnRun.Tag = id
          txtOnRun.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmdOnRunClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOnRunClear.Click
  try
          txtOnRun.Tag = Guid.Empty
          txtOnRun.text = ""
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtOnDelete_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOnDelete.TextChanged
  Changing

end sub
private sub cmdOnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOnDelete.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("PARTMENU","",System.guid.Empty, id, brief) Then
          txtOnDelete.Tag = id
          txtOnDelete.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmdOnDeleteClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOnDeleteClear.Click
  try
          txtOnDelete.Tag = Guid.Empty
          txtOnDelete.text = ""
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmbAddBehaivor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAddBehaivor.SelectedIndexChanged
  try
     Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtExtenderObject_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtExtenderObject.TextChanged
  Changing

end sub
private sub cmdExtenderObject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExtenderObject.Click
  try
Dim id As guid
Dim brief As String  = string.Empty
Dim OK as boolean
        OK=GuiManager.GetObjectDialog("","",id,brief)
If OK Then
    txtExtenderObject.Text = brief
    txtExtenderObject.Tag = id
End If
        catch ex as system.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
End Sub
private sub txtshablonBrief_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtshablonBrief.TextChanged
  Changing

end sub
private sub txtruleBrief_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtruleBrief.TextChanged
  Changing

end sub
private sub cmbIsJormalChange_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbIsJormalChange.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmbUseArchiving_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbUseArchiving.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmbintegerpkey_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbintegerpkey.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtpartIconCls_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpartIconCls.TextChanged
  Changing

end sub

Public Item As MTZMetaModel.MTZMetaModel.PART
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,MTZMetaModel.MTZMetaModel.PART)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

txtSequence.text = item.Sequence.toString()
cmbPartTypeData = New DataTable
cmbPartTypeData.Columns.Add("name", GetType(System.String))
cmbPartTypeData.Columns.Add("Value", GetType(System.Int32))
try
cmbPartTypeDataRow = cmbPartTypeData.NewRow
cmbPartTypeDataRow("name") = "Строка"
cmbPartTypeDataRow("Value") = 0
cmbPartTypeData.Rows.Add (cmbPartTypeDataRow)
cmbPartTypeDataRow = cmbPartTypeData.NewRow
cmbPartTypeDataRow("name") = "Коллекция"
cmbPartTypeDataRow("Value") = 1
cmbPartTypeData.Rows.Add (cmbPartTypeDataRow)
cmbPartTypeDataRow = cmbPartTypeData.NewRow
cmbPartTypeDataRow("name") = "Дерево"
cmbPartTypeDataRow("Value") = 2
cmbPartTypeData.Rows.Add (cmbPartTypeDataRow)
cmbPartTypeDataRow = cmbPartTypeData.NewRow
cmbPartTypeDataRow("name") = "Расширение"
cmbPartTypeDataRow("Value") = 3
cmbPartTypeData.Rows.Add (cmbPartTypeDataRow)
cmbPartTypeDataRow = cmbPartTypeData.NewRow
cmbPartTypeDataRow("name") = "Расширение с данными"
cmbPartTypeDataRow("Value") = 4
cmbPartTypeData.Rows.Add (cmbPartTypeDataRow)
cmbPartType.DisplayMember = "name"
cmbPartType.ValueMember = "Value"
cmbPartType.DataSource = cmbPartTypeData
 cmbPartType.SelectedValue=CInt(Item.PartType)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
txtCaption.text = item.Caption
txtName.text = item.Name
txtthe_Comment.text = item.the_Comment
cmbNoLogData = New DataTable
cmbNoLogData.Columns.Add("name", GetType(System.String))
cmbNoLogData.Columns.Add("Value", GetType(System.Int32))
try
cmbNoLogDataRow = cmbNoLogData.NewRow
cmbNoLogDataRow("name") = "Да"
cmbNoLogDataRow("Value") = -1
cmbNoLogData.Rows.Add (cmbNoLogDataRow)
cmbNoLogDataRow = cmbNoLogData.NewRow
cmbNoLogDataRow("name") = "Нет"
cmbNoLogDataRow("Value") = 0
cmbNoLogData.Rows.Add (cmbNoLogDataRow)
cmbNoLog.DisplayMember = "name"
cmbNoLog.ValueMember = "Value"
cmbNoLog.DataSource = cmbNoLogData
 cmbNoLog.SelectedValue=CInt(Item.NoLog)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
cmbManualRegisterData = New DataTable
cmbManualRegisterData.Columns.Add("name", GetType(System.String))
cmbManualRegisterData.Columns.Add("Value", GetType(System.Int32))
try
cmbManualRegisterDataRow = cmbManualRegisterData.NewRow
cmbManualRegisterDataRow("name") = "Да"
cmbManualRegisterDataRow("Value") = -1
cmbManualRegisterData.Rows.Add (cmbManualRegisterDataRow)
cmbManualRegisterDataRow = cmbManualRegisterData.NewRow
cmbManualRegisterDataRow("name") = "Нет"
cmbManualRegisterDataRow("Value") = 0
cmbManualRegisterData.Rows.Add (cmbManualRegisterDataRow)
cmbManualRegister.DisplayMember = "name"
cmbManualRegister.ValueMember = "Value"
cmbManualRegister.DataSource = cmbManualRegisterData
 cmbManualRegister.SelectedValue=CInt(Item.ManualRegister)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
If Not item.OnCreate Is Nothing Then
  txtOnCreate.Tag = item.OnCreate.id
  txtOnCreate.text = item.OnCreate.brief
else
  txtOnCreate.Tag = System.Guid.Empty 
  txtOnCreate.text = "" 
End If
If Not item.OnSave Is Nothing Then
  txtOnSave.Tag = item.OnSave.id
  txtOnSave.text = item.OnSave.brief
else
  txtOnSave.Tag = System.Guid.Empty 
  txtOnSave.text = "" 
End If
If Not item.OnRun Is Nothing Then
  txtOnRun.Tag = item.OnRun.id
  txtOnRun.text = item.OnRun.brief
else
  txtOnRun.Tag = System.Guid.Empty 
  txtOnRun.text = "" 
End If
If Not item.OnDelete Is Nothing Then
  txtOnDelete.Tag = item.OnDelete.id
  txtOnDelete.text = item.OnDelete.brief
else
  txtOnDelete.Tag = System.Guid.Empty 
  txtOnDelete.text = "" 
End If
cmbAddBehaivorData = New DataTable
cmbAddBehaivorData.Columns.Add("name", GetType(System.String))
cmbAddBehaivorData.Columns.Add("Value", GetType(System.Int32))
try
cmbAddBehaivorDataRow = cmbAddBehaivorData.NewRow
cmbAddBehaivorDataRow("name") = "AddForm"
cmbAddBehaivorDataRow("Value") = 0
cmbAddBehaivorData.Rows.Add (cmbAddBehaivorDataRow)
cmbAddBehaivorDataRow = cmbAddBehaivorData.NewRow
cmbAddBehaivorDataRow("name") = "RefreshOnly"
cmbAddBehaivorDataRow("Value") = 1
cmbAddBehaivorData.Rows.Add (cmbAddBehaivorDataRow)
cmbAddBehaivorDataRow = cmbAddBehaivorData.NewRow
cmbAddBehaivorDataRow("name") = "RunAction"
cmbAddBehaivorDataRow("Value") = 2
cmbAddBehaivorData.Rows.Add (cmbAddBehaivorDataRow)
cmbAddBehaivor.DisplayMember = "name"
cmbAddBehaivor.ValueMember = "Value"
cmbAddBehaivor.DataSource = cmbAddBehaivorData
 cmbAddBehaivor.SelectedValue=CInt(Item.AddBehaivor)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
If Not item.ExtenderObject Is Nothing Then
  txtExtenderObject.Tag = item.ExtenderObject.id
  txtExtenderObject.text = item.ExtenderObject.brief
else
  txtExtenderObject.Tag = System.Guid.Empty 
  txtExtenderObject.text = "" 
End If
txtshablonBrief.text = item.shablonBrief
txtruleBrief.text = item.ruleBrief
cmbIsJormalChangeData = New DataTable
cmbIsJormalChangeData.Columns.Add("name", GetType(System.String))
cmbIsJormalChangeData.Columns.Add("Value", GetType(System.Int32))
try
cmbIsJormalChangeDataRow = cmbIsJormalChangeData.NewRow
cmbIsJormalChangeDataRow("name") = "Да"
cmbIsJormalChangeDataRow("Value") = -1
cmbIsJormalChangeData.Rows.Add (cmbIsJormalChangeDataRow)
cmbIsJormalChangeDataRow = cmbIsJormalChangeData.NewRow
cmbIsJormalChangeDataRow("name") = "Нет"
cmbIsJormalChangeDataRow("Value") = 0
cmbIsJormalChangeData.Rows.Add (cmbIsJormalChangeDataRow)
cmbIsJormalChange.DisplayMember = "name"
cmbIsJormalChange.ValueMember = "Value"
cmbIsJormalChange.DataSource = cmbIsJormalChangeData
 cmbIsJormalChange.SelectedValue=CInt(Item.IsJormalChange)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
cmbUseArchivingData = New DataTable
cmbUseArchivingData.Columns.Add("name", GetType(System.String))
cmbUseArchivingData.Columns.Add("Value", GetType(System.Int32))
try
cmbUseArchivingDataRow = cmbUseArchivingData.NewRow
cmbUseArchivingDataRow("name") = "Да"
cmbUseArchivingDataRow("Value") = -1
cmbUseArchivingData.Rows.Add (cmbUseArchivingDataRow)
cmbUseArchivingDataRow = cmbUseArchivingData.NewRow
cmbUseArchivingDataRow("name") = "Нет"
cmbUseArchivingDataRow("Value") = 0
cmbUseArchivingData.Rows.Add (cmbUseArchivingDataRow)
cmbUseArchiving.DisplayMember = "name"
cmbUseArchiving.ValueMember = "Value"
cmbUseArchiving.DataSource = cmbUseArchivingData
 cmbUseArchiving.SelectedValue=CInt(Item.UseArchiving)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
cmbintegerpkeyData = New DataTable
cmbintegerpkeyData.Columns.Add("name", GetType(System.String))
cmbintegerpkeyData.Columns.Add("Value", GetType(System.Int32))
try
cmbintegerpkeyDataRow = cmbintegerpkeyData.NewRow
cmbintegerpkeyDataRow("name") = "Да"
cmbintegerpkeyDataRow("Value") = -1
cmbintegerpkeyData.Rows.Add (cmbintegerpkeyDataRow)
cmbintegerpkeyDataRow = cmbintegerpkeyData.NewRow
cmbintegerpkeyDataRow("name") = "Нет"
cmbintegerpkeyDataRow("Value") = 0
cmbintegerpkeyData.Rows.Add (cmbintegerpkeyDataRow)
cmbintegerpkey.DisplayMember = "name"
cmbintegerpkey.ValueMember = "Value"
cmbintegerpkey.DataSource = cmbintegerpkeyData
 cmbintegerpkey.SelectedValue=CInt(Item.integerpkey)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
txtpartIconCls.text = item.partIconCls
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

item.Sequence = val(txtSequence.text)
   item.PartType = cmbPartType.SelectedValue
item.Caption = txtCaption.text
item.Name = txtName.text
item.the_Comment = txtthe_Comment.text
   item.NoLog = cmbNoLog.SelectedValue
   item.ManualRegister = cmbManualRegister.SelectedValue
If not txtOnCreate.Tag.Equals(System.Guid.Empty) Then
  item.OnCreate = Item.Application.FindRowObject("PARTMENU",txtOnCreate.Tag)
Else
   item.OnCreate = Nothing
End If
If not txtOnSave.Tag.Equals(System.Guid.Empty) Then
  item.OnSave = Item.Application.FindRowObject("PARTMENU",txtOnSave.Tag)
Else
   item.OnSave = Nothing
End If
If not txtOnRun.Tag.Equals(System.Guid.Empty) Then
  item.OnRun = Item.Application.FindRowObject("PARTMENU",txtOnRun.Tag)
Else
   item.OnRun = Nothing
End If
If not txtOnDelete.Tag.Equals(System.Guid.Empty) Then
  item.OnDelete = Item.Application.FindRowObject("PARTMENU",txtOnDelete.Tag)
Else
   item.OnDelete = Nothing
End If
   item.AddBehaivor = cmbAddBehaivor.SelectedValue
If not txtExtenderObject.Tag.Equals(System.Guid.Empty) Then
   item.ExtenderObject = GuiManager.Manager.GetInstanceObject(txtExtenderObject.Tag)
Else
   item.ExtenderObject = Nothing
End If
item.shablonBrief = txtshablonBrief.text
item.ruleBrief = txtruleBrief.text
   item.IsJormalChange = cmbIsJormalChange.SelectedValue
   item.UseArchiving = cmbUseArchiving.SelectedValue
   item.integerpkey = cmbintegerpkey.SelectedValue
item.partIconCls = txtpartIconCls.text
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK =( txtSequence.text <> "" ) 
if mIsOK then mIsOK =(cmbPartType.SelectedIndex >=0)
if mIsOK then mIsOK =( txtCaption.text <> "" ) 
if mIsOK then mIsOK =( txtName.text <> "" ) 
if mIsOK then mIsOK =(cmbNoLog.SelectedIndex >=0)
if mIsOK then mIsOK =(cmbManualRegister.SelectedIndex >=0)
if mIsOK then mIsOK =(cmbIsJormalChange.SelectedIndex >=0)
if mIsOK then mIsOK =(cmbUseArchiving.SelectedIndex >=0)
if mIsOK then mIsOK =(cmbintegerpkey.SelectedIndex >=0)
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
