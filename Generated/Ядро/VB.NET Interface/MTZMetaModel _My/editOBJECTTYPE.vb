
Imports System.Windows.Forms
Imports Microsoft.VisualBasic



''' <summary>
'''Контрол редактирования раздела Тип объекта режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editOBJECTTYPE
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

 dim iii as integer
    Friend WithEvents HolderPanel As LATIR2GUIControls.AutoPanel
Friend WithEvents lblPackage  as  System.Windows.Forms.Label
Friend WithEvents txtPackage As System.Windows.Forms.TextBox
Friend WithEvents cmdPackage As System.Windows.Forms.Button
Friend WithEvents lblthe_Comment  as  System.Windows.Forms.Label
Friend WithEvents txtthe_Comment As System.Windows.Forms.TextBox
Friend WithEvents lblName  as  System.Windows.Forms.Label
Friend WithEvents txtName As System.Windows.Forms.TextBox
Friend WithEvents lblIsSingleInstance  as  System.Windows.Forms.Label
Friend WithEvents cmbIsSingleInstance As System.Windows.Forms.ComboBox
Friend cmbIsSingleInstanceDATA As DataTable
Friend cmbIsSingleInstanceDATAROW As DataRow
Friend WithEvents lblChooseView  as  System.Windows.Forms.Label
Friend WithEvents txtChooseView As System.Windows.Forms.TextBox
Friend WithEvents cmdChooseView As System.Windows.Forms.Button
Friend WithEvents cmdChooseViewClear As System.Windows.Forms.Button
Friend WithEvents lblOnRun  as  System.Windows.Forms.Label
Friend WithEvents txtOnRun As System.Windows.Forms.TextBox
Friend WithEvents cmdOnRun As System.Windows.Forms.Button
Friend WithEvents cmdOnRunClear As System.Windows.Forms.Button
Friend WithEvents lblOnCreate  as  System.Windows.Forms.Label
Friend WithEvents txtOnCreate As System.Windows.Forms.TextBox
Friend WithEvents cmdOnCreate As System.Windows.Forms.Button
Friend WithEvents cmdOnCreateClear As System.Windows.Forms.Button
Friend WithEvents lblOnDelete  as  System.Windows.Forms.Label
Friend WithEvents txtOnDelete As System.Windows.Forms.TextBox
Friend WithEvents cmdOnDelete As System.Windows.Forms.Button
Friend WithEvents cmdOnDeleteClear As System.Windows.Forms.Button
Friend WithEvents lblAllowRefToObject  as  System.Windows.Forms.Label
Friend WithEvents cmbAllowRefToObject As System.Windows.Forms.ComboBox
Friend cmbAllowRefToObjectDATA As DataTable
Friend cmbAllowRefToObjectDATAROW As DataRow
Friend WithEvents lblAllowSearch  as  System.Windows.Forms.Label
Friend WithEvents cmbAllowSearch As System.Windows.Forms.ComboBox
Friend cmbAllowSearchDATA As DataTable
Friend cmbAllowSearchDATAROW As DataRow
Friend WithEvents lblReplicaType  as  System.Windows.Forms.Label
Friend WithEvents cmbReplicaType As System.Windows.Forms.ComboBox
Friend cmbReplicaTypeDATA As DataTable
Friend cmbReplicaTypeDATAROW As DataRow
Friend WithEvents lblTheComment  as  System.Windows.Forms.Label
Friend WithEvents txtTheComment As System.Windows.Forms.TextBox
Friend WithEvents lblUseOwnership  as  System.Windows.Forms.Label
Friend WithEvents cmbUseOwnership As System.Windows.Forms.ComboBox
Friend cmbUseOwnershipDATA As DataTable
Friend cmbUseOwnershipDATAROW As DataRow
Friend WithEvents lblUseArchiving  as  System.Windows.Forms.Label
Friend WithEvents cmbUseArchiving As System.Windows.Forms.ComboBox
Friend cmbUseArchivingDATA As DataTable
Friend cmbUseArchivingDATAROW As DataRow
Friend WithEvents lblCommitFullObject  as  System.Windows.Forms.Label
Friend WithEvents cmbCommitFullObject As System.Windows.Forms.ComboBox
Friend cmbCommitFullObjectDATA As DataTable
Friend cmbCommitFullObjectDATAROW As DataRow
Friend WithEvents lblobjIconCls  as  System.Windows.Forms.Label
Friend WithEvents txtobjIconCls As System.Windows.Forms.TextBox

<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.HolderPanel = New LATIR2GUIControls.AutoPanel()
        Me.lblPackage = New System.Windows.Forms.Label()
        Me.txtPackage = New System.Windows.Forms.TextBox()
        Me.cmdPackage = New System.Windows.Forms.Button()
        Me.lblthe_Comment = New System.Windows.Forms.Label()
        Me.txtthe_Comment = New System.Windows.Forms.TextBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.lblIsSingleInstance = New System.Windows.Forms.Label()
        Me.cmbIsSingleInstance = New System.Windows.Forms.ComboBox()
        Me.lblChooseView = New System.Windows.Forms.Label()
        Me.txtChooseView = New System.Windows.Forms.TextBox()
        Me.cmdChooseView = New System.Windows.Forms.Button()
        Me.cmdChooseViewClear = New System.Windows.Forms.Button()
        Me.lblOnRun = New System.Windows.Forms.Label()
        Me.txtOnRun = New System.Windows.Forms.TextBox()
        Me.cmdOnRun = New System.Windows.Forms.Button()
        Me.cmdOnRunClear = New System.Windows.Forms.Button()
        Me.lblOnCreate = New System.Windows.Forms.Label()
        Me.txtOnCreate = New System.Windows.Forms.TextBox()
        Me.cmdOnCreate = New System.Windows.Forms.Button()
        Me.cmdOnCreateClear = New System.Windows.Forms.Button()
        Me.lblOnDelete = New System.Windows.Forms.Label()
        Me.txtOnDelete = New System.Windows.Forms.TextBox()
        Me.cmdOnDelete = New System.Windows.Forms.Button()
        Me.cmdOnDeleteClear = New System.Windows.Forms.Button()
        Me.lblAllowRefToObject = New System.Windows.Forms.Label()
        Me.cmbAllowRefToObject = New System.Windows.Forms.ComboBox()
        Me.lblAllowSearch = New System.Windows.Forms.Label()
        Me.cmbAllowSearch = New System.Windows.Forms.ComboBox()
        Me.lblReplicaType = New System.Windows.Forms.Label()
        Me.cmbReplicaType = New System.Windows.Forms.ComboBox()
        Me.lblTheComment = New System.Windows.Forms.Label()
        Me.txtTheComment = New System.Windows.Forms.TextBox()
        Me.lblUseOwnership = New System.Windows.Forms.Label()
        Me.cmbUseOwnership = New System.Windows.Forms.ComboBox()
        Me.lblUseArchiving = New System.Windows.Forms.Label()
        Me.cmbUseArchiving = New System.Windows.Forms.ComboBox()
        Me.lblCommitFullObject = New System.Windows.Forms.Label()
        Me.cmbCommitFullObject = New System.Windows.Forms.ComboBox()
        Me.lblobjIconCls = New System.Windows.Forms.Label()
        Me.txtobjIconCls = New System.Windows.Forms.TextBox()
        Me.HolderPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'HolderPanel
        '
        Me.HolderPanel.AllowDrop = True
        Me.HolderPanel.AutoScroll = True
        Me.HolderPanel.BackColor = System.Drawing.SystemColors.Control
        Me.HolderPanel.Controls.Add(Me.lblPackage)
        Me.HolderPanel.Controls.Add(Me.txtPackage)
        Me.HolderPanel.Controls.Add(Me.cmdPackage)
        Me.HolderPanel.Controls.Add(Me.lblthe_Comment)
        Me.HolderPanel.Controls.Add(Me.txtthe_Comment)
        Me.HolderPanel.Controls.Add(Me.lblName)
        Me.HolderPanel.Controls.Add(Me.txtName)
        Me.HolderPanel.Controls.Add(Me.lblIsSingleInstance)
        Me.HolderPanel.Controls.Add(Me.cmbIsSingleInstance)
        Me.HolderPanel.Controls.Add(Me.lblChooseView)
        Me.HolderPanel.Controls.Add(Me.txtChooseView)
        Me.HolderPanel.Controls.Add(Me.cmdChooseView)
        Me.HolderPanel.Controls.Add(Me.cmdChooseViewClear)
        Me.HolderPanel.Controls.Add(Me.lblOnRun)
        Me.HolderPanel.Controls.Add(Me.txtOnRun)
        Me.HolderPanel.Controls.Add(Me.cmdOnRun)
        Me.HolderPanel.Controls.Add(Me.cmdOnRunClear)
        Me.HolderPanel.Controls.Add(Me.lblOnCreate)
        Me.HolderPanel.Controls.Add(Me.txtOnCreate)
        Me.HolderPanel.Controls.Add(Me.cmdOnCreate)
        Me.HolderPanel.Controls.Add(Me.cmdOnCreateClear)
        Me.HolderPanel.Controls.Add(Me.lblOnDelete)
        Me.HolderPanel.Controls.Add(Me.txtOnDelete)
        Me.HolderPanel.Controls.Add(Me.cmdOnDelete)
        Me.HolderPanel.Controls.Add(Me.cmdOnDeleteClear)
        Me.HolderPanel.Controls.Add(Me.lblAllowRefToObject)
        Me.HolderPanel.Controls.Add(Me.cmbAllowRefToObject)
        Me.HolderPanel.Controls.Add(Me.lblAllowSearch)
        Me.HolderPanel.Controls.Add(Me.cmbAllowSearch)
        Me.HolderPanel.Controls.Add(Me.lblReplicaType)
        Me.HolderPanel.Controls.Add(Me.cmbReplicaType)
        Me.HolderPanel.Controls.Add(Me.lblTheComment)
        Me.HolderPanel.Controls.Add(Me.txtTheComment)
        Me.HolderPanel.Controls.Add(Me.lblUseOwnership)
        Me.HolderPanel.Controls.Add(Me.cmbUseOwnership)
        Me.HolderPanel.Controls.Add(Me.lblUseArchiving)
        Me.HolderPanel.Controls.Add(Me.cmbUseArchiving)
        Me.HolderPanel.Controls.Add(Me.lblCommitFullObject)
        Me.HolderPanel.Controls.Add(Me.cmbCommitFullObject)
        Me.HolderPanel.Controls.Add(Me.lblobjIconCls)
        Me.HolderPanel.Controls.Add(Me.txtobjIconCls)
        Me.HolderPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HolderPanel.Location = New System.Drawing.Point(0, 0)
        Me.HolderPanel.Name = "HolderPanel"
        Me.HolderPanel.Size = New System.Drawing.Size(480, 287)
        Me.HolderPanel.TabIndex = 0
        '
        'lblPackage
        '
        Me.lblPackage.ForeColor = System.Drawing.Color.Black
        Me.lblPackage.Location = New System.Drawing.Point(20, 5)
        Me.lblPackage.Name = "lblPackage"
        Me.lblPackage.Size = New System.Drawing.Size(200, 20)
        Me.lblPackage.TabIndex = 1
        Me.lblPackage.Text = "Приложение"
        '
        'txtPackage
        '
        Me.txtPackage.Location = New System.Drawing.Point(20, 27)
        Me.txtPackage.Name = "txtPackage"
        Me.txtPackage.ReadOnly = True
        Me.txtPackage.Size = New System.Drawing.Size(176, 20)
        Me.txtPackage.TabIndex = 2
        '
        'cmdPackage
        '
        Me.cmdPackage.Location = New System.Drawing.Point(198, 27)
        Me.cmdPackage.Name = "cmdPackage"
        Me.cmdPackage.Size = New System.Drawing.Size(22, 20)
        Me.cmdPackage.TabIndex = 3
        Me.cmdPackage.Text = "..."
        '
        'lblthe_Comment
        '
        Me.lblthe_Comment.ForeColor = System.Drawing.Color.Black
        Me.lblthe_Comment.Location = New System.Drawing.Point(20, 52)
        Me.lblthe_Comment.Name = "lblthe_Comment"
        Me.lblthe_Comment.Size = New System.Drawing.Size(200, 20)
        Me.lblthe_Comment.TabIndex = 4
        Me.lblthe_Comment.Text = "Название"
        '
        'txtthe_Comment
        '
        Me.txtthe_Comment.Location = New System.Drawing.Point(20, 74)
        Me.txtthe_Comment.Name = "txtthe_Comment"
        Me.txtthe_Comment.Size = New System.Drawing.Size(200, 20)
        Me.txtthe_Comment.TabIndex = 5
        '
        'lblName
        '
        Me.lblName.ForeColor = System.Drawing.Color.Black
        Me.lblName.Location = New System.Drawing.Point(20, 99)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(200, 20)
        Me.lblName.TabIndex = 6
        Me.lblName.Text = "Код"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(20, 121)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(200, 20)
        Me.txtName.TabIndex = 7
        '
        'lblIsSingleInstance
        '
        Me.lblIsSingleInstance.ForeColor = System.Drawing.Color.Black
        Me.lblIsSingleInstance.Location = New System.Drawing.Point(20, 146)
        Me.lblIsSingleInstance.Name = "lblIsSingleInstance"
        Me.lblIsSingleInstance.Size = New System.Drawing.Size(200, 20)
        Me.lblIsSingleInstance.TabIndex = 8
        Me.lblIsSingleInstance.Text = "Допускается только один объект"
        '
        'cmbIsSingleInstance
        '
        Me.cmbIsSingleInstance.Location = New System.Drawing.Point(20, 168)
        Me.cmbIsSingleInstance.Name = "cmbIsSingleInstance"
        Me.cmbIsSingleInstance.Size = New System.Drawing.Size(200, 21)
        Me.cmbIsSingleInstance.TabIndex = 9
        '
        'lblChooseView
        '
        Me.lblChooseView.ForeColor = System.Drawing.Color.Blue
        Me.lblChooseView.Location = New System.Drawing.Point(20, 193)
        Me.lblChooseView.Name = "lblChooseView"
        Me.lblChooseView.Size = New System.Drawing.Size(200, 20)
        Me.lblChooseView.TabIndex = 10
        Me.lblChooseView.Text = "Представление для выбора"
        '
        'txtChooseView
        '
        Me.txtChooseView.Location = New System.Drawing.Point(20, 215)
        Me.txtChooseView.Name = "txtChooseView"
        Me.txtChooseView.ReadOnly = True
        Me.txtChooseView.Size = New System.Drawing.Size(155, 20)
        Me.txtChooseView.TabIndex = 11
        '
        'cmdChooseView
        '
        Me.cmdChooseView.Location = New System.Drawing.Point(176, 215)
        Me.cmdChooseView.Name = "cmdChooseView"
        Me.cmdChooseView.Size = New System.Drawing.Size(22, 20)
        Me.cmdChooseView.TabIndex = 12
        Me.cmdChooseView.Text = "..."
        '
        'cmdChooseViewClear
        '
        Me.cmdChooseViewClear.Location = New System.Drawing.Point(198, 215)
        Me.cmdChooseViewClear.Name = "cmdChooseViewClear"
        Me.cmdChooseViewClear.Size = New System.Drawing.Size(22, 20)
        Me.cmdChooseViewClear.TabIndex = 13
        Me.cmdChooseViewClear.Text = "X"
        '
        'lblOnRun
        '
        Me.lblOnRun.ForeColor = System.Drawing.Color.Blue
        Me.lblOnRun.Location = New System.Drawing.Point(20, 240)
        Me.lblOnRun.Name = "lblOnRun"
        Me.lblOnRun.Size = New System.Drawing.Size(200, 20)
        Me.lblOnRun.TabIndex = 14
        Me.lblOnRun.Text = "При запуске"
        '
        'txtOnRun
        '
        Me.txtOnRun.Location = New System.Drawing.Point(20, 262)
        Me.txtOnRun.Name = "txtOnRun"
        Me.txtOnRun.ReadOnly = True
        Me.txtOnRun.Size = New System.Drawing.Size(155, 20)
        Me.txtOnRun.TabIndex = 15
        '
        'cmdOnRun
        '
        Me.cmdOnRun.Location = New System.Drawing.Point(176, 262)
        Me.cmdOnRun.Name = "cmdOnRun"
        Me.cmdOnRun.Size = New System.Drawing.Size(22, 20)
        Me.cmdOnRun.TabIndex = 16
        Me.cmdOnRun.Text = "..."
        '
        'cmdOnRunClear
        '
        Me.cmdOnRunClear.Location = New System.Drawing.Point(198, 262)
        Me.cmdOnRunClear.Name = "cmdOnRunClear"
        Me.cmdOnRunClear.Size = New System.Drawing.Size(22, 20)
        Me.cmdOnRunClear.TabIndex = 17
        Me.cmdOnRunClear.Text = "X"
        '
        'lblOnCreate
        '
        Me.lblOnCreate.ForeColor = System.Drawing.Color.Blue
        Me.lblOnCreate.Location = New System.Drawing.Point(20, 287)
        Me.lblOnCreate.Name = "lblOnCreate"
        Me.lblOnCreate.Size = New System.Drawing.Size(200, 20)
        Me.lblOnCreate.TabIndex = 18
        Me.lblOnCreate.Text = "При создании"
        '
        'txtOnCreate
        '
        Me.txtOnCreate.Location = New System.Drawing.Point(20, 309)
        Me.txtOnCreate.Name = "txtOnCreate"
        Me.txtOnCreate.ReadOnly = True
        Me.txtOnCreate.Size = New System.Drawing.Size(155, 20)
        Me.txtOnCreate.TabIndex = 19
        '
        'cmdOnCreate
        '
        Me.cmdOnCreate.Location = New System.Drawing.Point(176, 309)
        Me.cmdOnCreate.Name = "cmdOnCreate"
        Me.cmdOnCreate.Size = New System.Drawing.Size(22, 20)
        Me.cmdOnCreate.TabIndex = 20
        Me.cmdOnCreate.Text = "..."
        '
        'cmdOnCreateClear
        '
        Me.cmdOnCreateClear.Location = New System.Drawing.Point(198, 309)
        Me.cmdOnCreateClear.Name = "cmdOnCreateClear"
        Me.cmdOnCreateClear.Size = New System.Drawing.Size(22, 20)
        Me.cmdOnCreateClear.TabIndex = 21
        Me.cmdOnCreateClear.Text = "X"
        '
        'lblOnDelete
        '
        Me.lblOnDelete.ForeColor = System.Drawing.Color.Blue
        Me.lblOnDelete.Location = New System.Drawing.Point(20, 334)
        Me.lblOnDelete.Name = "lblOnDelete"
        Me.lblOnDelete.Size = New System.Drawing.Size(200, 20)
        Me.lblOnDelete.TabIndex = 22
        Me.lblOnDelete.Text = "При удалении"
        '
        'txtOnDelete
        '
        Me.txtOnDelete.Location = New System.Drawing.Point(20, 356)
        Me.txtOnDelete.Name = "txtOnDelete"
        Me.txtOnDelete.ReadOnly = True
        Me.txtOnDelete.Size = New System.Drawing.Size(155, 20)
        Me.txtOnDelete.TabIndex = 23
        '
        'cmdOnDelete
        '
        Me.cmdOnDelete.Location = New System.Drawing.Point(176, 356)
        Me.cmdOnDelete.Name = "cmdOnDelete"
        Me.cmdOnDelete.Size = New System.Drawing.Size(22, 20)
        Me.cmdOnDelete.TabIndex = 24
        Me.cmdOnDelete.Text = "..."
        '
        'cmdOnDeleteClear
        '
        Me.cmdOnDeleteClear.Location = New System.Drawing.Point(198, 356)
        Me.cmdOnDeleteClear.Name = "cmdOnDeleteClear"
        Me.cmdOnDeleteClear.Size = New System.Drawing.Size(22, 20)
        Me.cmdOnDeleteClear.TabIndex = 25
        Me.cmdOnDeleteClear.Text = "X"
        '
        'lblAllowRefToObject
        '
        Me.lblAllowRefToObject.ForeColor = System.Drawing.Color.Black
        Me.lblAllowRefToObject.Location = New System.Drawing.Point(20, 381)
        Me.lblAllowRefToObject.Name = "lblAllowRefToObject"
        Me.lblAllowRefToObject.Size = New System.Drawing.Size(200, 20)
        Me.lblAllowRefToObject.TabIndex = 26
        Me.lblAllowRefToObject.Text = "Отображать при выборе ссылки"
        '
        'cmbAllowRefToObject
        '
        Me.cmbAllowRefToObject.Location = New System.Drawing.Point(20, 403)
        Me.cmbAllowRefToObject.Name = "cmbAllowRefToObject"
        Me.cmbAllowRefToObject.Size = New System.Drawing.Size(200, 21)
        Me.cmbAllowRefToObject.TabIndex = 27
        '
        'lblAllowSearch
        '
        Me.lblAllowSearch.ForeColor = System.Drawing.Color.Black
        Me.lblAllowSearch.Location = New System.Drawing.Point(230, 5)
        Me.lblAllowSearch.Name = "lblAllowSearch"
        Me.lblAllowSearch.Size = New System.Drawing.Size(200, 20)
        Me.lblAllowSearch.TabIndex = 28
        Me.lblAllowSearch.Text = "Отображать при поиске"
        '
        'cmbAllowSearch
        '
        Me.cmbAllowSearch.Location = New System.Drawing.Point(230, 27)
        Me.cmbAllowSearch.Name = "cmbAllowSearch"
        Me.cmbAllowSearch.Size = New System.Drawing.Size(200, 21)
        Me.cmbAllowSearch.TabIndex = 29
        '
        'lblReplicaType
        '
        Me.lblReplicaType.ForeColor = System.Drawing.Color.Blue
        Me.lblReplicaType.Location = New System.Drawing.Point(230, 52)
        Me.lblReplicaType.Name = "lblReplicaType"
        Me.lblReplicaType.Size = New System.Drawing.Size(200, 20)
        Me.lblReplicaType.TabIndex = 30
        Me.lblReplicaType.Text = "Тип репликации"
        '
        'cmbReplicaType
        '
        Me.cmbReplicaType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbReplicaType.Location = New System.Drawing.Point(230, 74)
        Me.cmbReplicaType.Name = "cmbReplicaType"
        Me.cmbReplicaType.Size = New System.Drawing.Size(200, 21)
        Me.cmbReplicaType.TabIndex = 31
        '
        'lblTheComment
        '
        Me.lblTheComment.ForeColor = System.Drawing.Color.Blue
        Me.lblTheComment.Location = New System.Drawing.Point(230, 99)
        Me.lblTheComment.Name = "lblTheComment"
        Me.lblTheComment.Size = New System.Drawing.Size(200, 20)
        Me.lblTheComment.TabIndex = 32
        Me.lblTheComment.Text = "Описание"
        '
        'txtTheComment
        '
        Me.txtTheComment.Location = New System.Drawing.Point(230, 121)
        Me.txtTheComment.Multiline = True
        Me.txtTheComment.Name = "txtTheComment"
        Me.txtTheComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtTheComment.Size = New System.Drawing.Size(200, 50)
        Me.txtTheComment.TabIndex = 33
        '
        'lblUseOwnership
        '
        Me.lblUseOwnership.ForeColor = System.Drawing.Color.Black
        Me.lblUseOwnership.Location = New System.Drawing.Point(230, 191)
        Me.lblUseOwnership.Name = "lblUseOwnership"
        Me.lblUseOwnership.Size = New System.Drawing.Size(200, 20)
        Me.lblUseOwnership.TabIndex = 34
        Me.lblUseOwnership.Text = "Видмость зависит от пользователя"
        '
        'cmbUseOwnership
        '
        Me.cmbUseOwnership.Location = New System.Drawing.Point(230, 213)
        Me.cmbUseOwnership.Name = "cmbUseOwnership"
        Me.cmbUseOwnership.Size = New System.Drawing.Size(200, 21)
        Me.cmbUseOwnership.TabIndex = 35
        '
        'lblUseArchiving
        '
        Me.lblUseArchiving.ForeColor = System.Drawing.Color.Black
        Me.lblUseArchiving.Location = New System.Drawing.Point(230, 238)
        Me.lblUseArchiving.Name = "lblUseArchiving"
        Me.lblUseArchiving.Size = New System.Drawing.Size(200, 20)
        Me.lblUseArchiving.TabIndex = 36
        Me.lblUseArchiving.Text = "Архивировать вместо удаления"
        '
        'cmbUseArchiving
        '
        Me.cmbUseArchiving.Location = New System.Drawing.Point(230, 260)
        Me.cmbUseArchiving.Name = "cmbUseArchiving"
        Me.cmbUseArchiving.Size = New System.Drawing.Size(200, 21)
        Me.cmbUseArchiving.TabIndex = 37
        '
        'lblCommitFullObject
        '
        Me.lblCommitFullObject.ForeColor = System.Drawing.Color.Black
        Me.lblCommitFullObject.Location = New System.Drawing.Point(230, 285)
        Me.lblCommitFullObject.Name = "lblCommitFullObject"
        Me.lblCommitFullObject.Size = New System.Drawing.Size(200, 20)
        Me.lblCommitFullObject.TabIndex = 38
        Me.lblCommitFullObject.Text = "Сохранять объект целиком"
        '
        'cmbCommitFullObject
        '
        Me.cmbCommitFullObject.Location = New System.Drawing.Point(230, 307)
        Me.cmbCommitFullObject.Name = "cmbCommitFullObject"
        Me.cmbCommitFullObject.Size = New System.Drawing.Size(200, 21)
        Me.cmbCommitFullObject.TabIndex = 39
        '
        'lblobjIconCls
        '
        Me.lblobjIconCls.ForeColor = System.Drawing.Color.Blue
        Me.lblobjIconCls.Location = New System.Drawing.Point(230, 332)
        Me.lblobjIconCls.Name = "lblobjIconCls"
        Me.lblobjIconCls.Size = New System.Drawing.Size(200, 20)
        Me.lblobjIconCls.TabIndex = 40
        Me.lblobjIconCls.Text = "Иконка объекта"
        '
        'txtobjIconCls
        '
        Me.txtobjIconCls.Location = New System.Drawing.Point(230, 354)
        Me.txtobjIconCls.Name = "txtobjIconCls"
        Me.txtobjIconCls.Size = New System.Drawing.Size(200, 20)
        Me.txtobjIconCls.TabIndex = 41
        '
        'editOBJECTTYPE
        '
        Me.AutoScroll = True
        Me.Controls.Add(Me.HolderPanel)
        Me.Name = "editOBJECTTYPE"
        Me.Size = New System.Drawing.Size(480, 287)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
#End Region

    Private sub txtPackage_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPackage.TextChanged
  Changing

end sub
private sub cmdPackage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPackage.Click
  on error resume next
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("MTZAPP","",System.guid.Empty, id, brief) Then
          txtPackage.Tag = id
          txtPackage.text = brief
        End If
end sub
private sub txtthe_Comment_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtthe_Comment.TextChanged
  Changing

end sub
private sub txtName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
  Changing

end sub
private sub cmbIsSingleInstance_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbIsSingleInstance.SelectedValueChanged
  on error resume next
  Changing

end sub
private sub txtChooseView_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtChooseView.TextChanged
  Changing

end sub
private sub cmdChooseView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChooseView.Click
  on error resume next
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("PARTVIEW","",System.guid.Empty, id, brief) Then
          txtChooseView.Tag = id
          txtChooseView.text = brief
        End If
end sub
private sub cmdChooseViewClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChooseViewClear.Click
  on error resume next
          txtChooseView.Tag = Guid.Empty
          txtChooseView.text = ""
end sub
private sub txtOnRun_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOnRun.TextChanged
  Changing

end sub
private sub cmdOnRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOnRun.Click
  on error resume next
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("TYPEMENU","",item.application.ID, id, brief) Then
          txtOnRun.Tag = id
          txtOnRun.text = brief
        End If
end sub
private sub cmdOnRunClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOnRunClear.Click
  on error resume next
          txtOnRun.Tag = Guid.Empty
          txtOnRun.text = ""
end sub
private sub txtOnCreate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOnCreate.TextChanged
  Changing

end sub
private sub cmdOnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOnCreate.Click
  on error resume next
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("TYPEMENU","",System.guid.Empty, id, brief) Then
          txtOnCreate.Tag = id
          txtOnCreate.text = brief
        End If
end sub
private sub cmdOnCreateClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOnCreateClear.Click
  on error resume next
          txtOnCreate.Tag = Guid.Empty
          txtOnCreate.text = ""
end sub
private sub txtOnDelete_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOnDelete.TextChanged
  Changing

end sub
private sub cmdOnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOnDelete.Click
  on error resume next
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("TYPEMENU","",System.guid.Empty, id, brief) Then
          txtOnDelete.Tag = id
          txtOnDelete.text = brief
        End If
end sub
private sub cmdOnDeleteClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOnDeleteClear.Click
  on error resume next
          txtOnDelete.Tag = Guid.Empty
          txtOnDelete.text = ""
end sub
private sub cmbAllowRefToObject_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAllowRefToObject.SelectedValueChanged
  on error resume next
  Changing

end sub
private sub cmbAllowSearch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAllowSearch.SelectedValueChanged
  on error resume next
  Changing

end sub
private sub cmbReplicaType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbReplicaType.SelectedValueChanged
  on error resume next
  Changing

end sub
private sub txtTheComment_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTheComment.TextChanged
  Changing

end sub
private sub cmbUseOwnership_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbUseOwnership.SelectedValueChanged
  on error resume next
  Changing

end sub
private sub cmbUseArchiving_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbUseArchiving.SelectedValueChanged
  on error resume next
  Changing

end sub
private sub cmbCommitFullObject_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCommitFullObject.SelectedValueChanged
  on error resume next
  Changing

end sub
private sub txtobjIconCls_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtobjIconCls.TextChanged
  Changing

end sub

Public Item As MTZMetaModel.MTZMetaModel.OBJECTTYPE
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,MTZMetaModel.MTZMetaModel.OBJECTTYPE)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

If Not item.Package Is Nothing Then
  txtPackage.Tag = item.Package.id
  txtPackage.text = item.Package.brief
else
  txtPackage.Tag = System.Guid.Empty 
  txtPackage.text = "" 
End If
txtthe_Comment.text = item.the_Comment
txtName.text = item.Name
cmbIsSingleInstanceData = New DataTable
cmbIsSingleInstanceData.Columns.Add("name", GetType(System.String))
cmbIsSingleInstanceData.Columns.Add("Value", GetType(System.Int32))
On Error Resume Next
cmbIsSingleInstanceDataRow = cmbIsSingleInstanceData.NewRow
cmbIsSingleInstanceDataRow("name") = "Да"
cmbIsSingleInstanceDataRow("Value") = -1
cmbIsSingleInstanceData.Rows.Add (cmbIsSingleInstanceDataRow)
cmbIsSingleInstanceDataRow = cmbIsSingleInstanceData.NewRow
cmbIsSingleInstanceDataRow("name") = "Нет"
cmbIsSingleInstanceDataRow("Value") = 0
cmbIsSingleInstanceData.Rows.Add (cmbIsSingleInstanceDataRow)
cmbIsSingleInstance.DisplayMember = "name"
cmbIsSingleInstance.ValueMember = "Value"
cmbIsSingleInstance.DataSource = cmbIsSingleInstanceData
 cmbIsSingleInstance.SelectedValue=CInt(Item.IsSingleInstance)
If Not item.ChooseView Is Nothing Then
  txtChooseView.Tag = item.ChooseView.id
  txtChooseView.text = item.ChooseView.brief
else
  txtChooseView.Tag = System.Guid.Empty 
  txtChooseView.text = "" 
End If
If Not item.OnRun Is Nothing Then
  txtOnRun.Tag = item.OnRun.id
  txtOnRun.text = item.OnRun.brief
else
  txtOnRun.Tag = System.Guid.Empty 
  txtOnRun.text = "" 
End If
If Not item.OnCreate Is Nothing Then
  txtOnCreate.Tag = item.OnCreate.id
  txtOnCreate.text = item.OnCreate.brief
else
  txtOnCreate.Tag = System.Guid.Empty 
  txtOnCreate.text = "" 
End If
If Not item.OnDelete Is Nothing Then
  txtOnDelete.Tag = item.OnDelete.id
  txtOnDelete.text = item.OnDelete.brief
else
  txtOnDelete.Tag = System.Guid.Empty 
  txtOnDelete.text = "" 
End If
cmbAllowRefToObjectData = New DataTable
cmbAllowRefToObjectData.Columns.Add("name", GetType(System.String))
cmbAllowRefToObjectData.Columns.Add("Value", GetType(System.Int32))
On Error Resume Next
cmbAllowRefToObjectDataRow = cmbAllowRefToObjectData.NewRow
cmbAllowRefToObjectDataRow("name") = "Да"
cmbAllowRefToObjectDataRow("Value") = -1
cmbAllowRefToObjectData.Rows.Add (cmbAllowRefToObjectDataRow)
cmbAllowRefToObjectDataRow = cmbAllowRefToObjectData.NewRow
cmbAllowRefToObjectDataRow("name") = "Нет"
cmbAllowRefToObjectDataRow("Value") = 0
cmbAllowRefToObjectData.Rows.Add (cmbAllowRefToObjectDataRow)
cmbAllowRefToObject.DisplayMember = "name"
cmbAllowRefToObject.ValueMember = "Value"
cmbAllowRefToObject.DataSource = cmbAllowRefToObjectData
 cmbAllowRefToObject.SelectedValue=CInt(Item.AllowRefToObject)
cmbAllowSearchData = New DataTable
cmbAllowSearchData.Columns.Add("name", GetType(System.String))
cmbAllowSearchData.Columns.Add("Value", GetType(System.Int32))
On Error Resume Next
cmbAllowSearchDataRow = cmbAllowSearchData.NewRow
cmbAllowSearchDataRow("name") = "Да"
cmbAllowSearchDataRow("Value") = -1
cmbAllowSearchData.Rows.Add (cmbAllowSearchDataRow)
cmbAllowSearchDataRow = cmbAllowSearchData.NewRow
cmbAllowSearchDataRow("name") = "Нет"
cmbAllowSearchDataRow("Value") = 0
cmbAllowSearchData.Rows.Add (cmbAllowSearchDataRow)
cmbAllowSearch.DisplayMember = "name"
cmbAllowSearch.ValueMember = "Value"
cmbAllowSearch.DataSource = cmbAllowSearchData
 cmbAllowSearch.SelectedValue=CInt(Item.AllowSearch)
cmbReplicaTypeData = New DataTable
cmbReplicaTypeData.Columns.Add("name", GetType(System.String))
cmbReplicaTypeData.Columns.Add("Value", GetType(System.Int32))
On Error Resume Next
cmbReplicaTypeDataRow = cmbReplicaTypeData.NewRow
cmbReplicaTypeDataRow("name") = "Весь документ"
cmbReplicaTypeDataRow("Value") = 0
cmbReplicaTypeData.Rows.Add (cmbReplicaTypeDataRow)
cmbReplicaTypeDataRow = cmbReplicaTypeData.NewRow
cmbReplicaTypeDataRow("name") = "Построчно"
cmbReplicaTypeDataRow("Value") = 1
cmbReplicaTypeData.Rows.Add (cmbReplicaTypeDataRow)
cmbReplicaTypeDataRow = cmbReplicaTypeData.NewRow
cmbReplicaTypeDataRow("name") = "Локальный"
cmbReplicaTypeDataRow("Value") = 2
cmbReplicaTypeData.Rows.Add (cmbReplicaTypeDataRow)
cmbReplicaType.DisplayMember = "name"
cmbReplicaType.ValueMember = "Value"
cmbReplicaType.DataSource = cmbReplicaTypeData
 cmbReplicaType.SelectedValue=CInt(Item.ReplicaType)
txtTheComment.text = item.TheComment
cmbUseOwnershipData = New DataTable
cmbUseOwnershipData.Columns.Add("name", GetType(System.String))
cmbUseOwnershipData.Columns.Add("Value", GetType(System.Int32))
On Error Resume Next
cmbUseOwnershipDataRow = cmbUseOwnershipData.NewRow
cmbUseOwnershipDataRow("name") = "Да"
cmbUseOwnershipDataRow("Value") = -1
cmbUseOwnershipData.Rows.Add (cmbUseOwnershipDataRow)
cmbUseOwnershipDataRow = cmbUseOwnershipData.NewRow
cmbUseOwnershipDataRow("name") = "Нет"
cmbUseOwnershipDataRow("Value") = 0
cmbUseOwnershipData.Rows.Add (cmbUseOwnershipDataRow)
cmbUseOwnership.DisplayMember = "name"
cmbUseOwnership.ValueMember = "Value"
cmbUseOwnership.DataSource = cmbUseOwnershipData
 cmbUseOwnership.SelectedValue=CInt(Item.UseOwnership)
cmbUseArchivingData = New DataTable
cmbUseArchivingData.Columns.Add("name", GetType(System.String))
cmbUseArchivingData.Columns.Add("Value", GetType(System.Int32))
On Error Resume Next
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
cmbCommitFullObjectData = New DataTable
cmbCommitFullObjectData.Columns.Add("name", GetType(System.String))
cmbCommitFullObjectData.Columns.Add("Value", GetType(System.Int32))
On Error Resume Next
cmbCommitFullObjectDataRow = cmbCommitFullObjectData.NewRow
cmbCommitFullObjectDataRow("name") = "Да"
cmbCommitFullObjectDataRow("Value") = -1
cmbCommitFullObjectData.Rows.Add (cmbCommitFullObjectDataRow)
cmbCommitFullObjectDataRow = cmbCommitFullObjectData.NewRow
cmbCommitFullObjectDataRow("name") = "Нет"
cmbCommitFullObjectDataRow("Value") = 0
cmbCommitFullObjectData.Rows.Add (cmbCommitFullObjectDataRow)
cmbCommitFullObject.DisplayMember = "name"
cmbCommitFullObject.ValueMember = "Value"
cmbCommitFullObject.DataSource = cmbCommitFullObjectData
 cmbCommitFullObject.SelectedValue=CInt(Item.CommitFullObject)
txtobjIconCls.text = item.objIconCls
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

If not txtPackage.Tag.Equals(System.Guid.Empty) Then
  item.Package = Item.Application.FindRowObject("MTZAPP",txtPackage.Tag)
Else
   item.Package = Nothing
End If
item.the_Comment = txtthe_Comment.text
item.Name = txtName.Text
            Item.IsSingleInstance = cmbIsSingleInstance.SelectedValue
            If not txtChooseView.Tag.Equals(System.Guid.Empty) Then
  item.ChooseView = Item.Application.FindRowObject("PARTVIEW",txtChooseView.Tag)
Else
   item.ChooseView = Nothing
End If
If not txtOnRun.Tag.Equals(System.Guid.Empty) Then
  item.OnRun = Item.Application.FindRowObject("TYPEMENU",txtOnRun.Tag)
Else
   item.OnRun = Nothing
End If
If not txtOnCreate.Tag.Equals(System.Guid.Empty) Then
  item.OnCreate = Item.Application.FindRowObject("TYPEMENU",txtOnCreate.Tag)
Else
   item.OnCreate = Nothing
End If
If not txtOnDelete.Tag.Equals(System.Guid.Empty) Then
  item.OnDelete = Item.Application.FindRowObject("TYPEMENU",txtOnDelete.Tag)
Else
   item.OnDelete = Nothing
End If
            Item.AllowRefToObject = cmbAllowRefToObject.SelectedValue
            Item.AllowSearch = cmbAllowSearch.SelectedValue
            Item.ReplicaType = cmbReplicaType.SelectedValue
            Item.TheComment = txtTheComment.Text
            Item.UseOwnership = cmbUseOwnership.SelectedValue
            Item.UseArchiving = cmbUseArchiving.SelectedValue
            Item.CommitFullObject = cmbCommitFullObject.SelectedValue
            Item.objIconCls = txtobjIconCls.text
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK = not txtPackage.Tag.Equals(System.Guid.Empty)
if mIsOK then mIsOK =( txtthe_Comment.text <> "" ) 
if mIsOK then mIsOK =( txtName.text <> "" )
        If mIsOK Then mIsOK = (cmbIsSingleInstance.SelectedIndex >= 0)
        If mIsOK Then mIsOK = (cmbAllowRefToObject.SelectedIndex >= 0)
        If mIsOK Then mIsOK = (cmbAllowSearch.SelectedIndex >= 0)
        If mIsOK Then mIsOK = (cmbUseOwnership.SelectedIndex >= 0)
        If mIsOK Then mIsOK = (cmbUseArchiving.SelectedIndex >= 0)
        If mIsOK Then mIsOK = (cmbCommitFullObject.SelectedIndex >= 0)
        Return mIsOK
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
