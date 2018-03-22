Imports System.IO
Imports System.Drawing
Imports LATIR2GUIControls

Public Class TreeView
    Inherits TreeControlParent


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        MyBase.LabelCaption = lblCaption
    End Sub

    'UserControl overrides dispose to clean up the component list.
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
    Friend WithEvents mnuService As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuAdd As System.Windows.Forms.MenuItem
    Friend WithEvents mnuEdit As System.Windows.Forms.MenuItem
    Friend WithEvents mnuDel As System.Windows.Forms.MenuItem
    Friend WithEvents tv As System.Windows.Forms.TreeView
    Friend WithEvents lblCaption As System.Windows.Forms.Label
    Friend WithEvents mnuAddRoot As System.Windows.Forms.MenuItem
    Friend WithEvents mnuRefresh As System.Windows.Forms.MenuItem
    Friend WithEvents mnuFind As System.Windows.Forms.MenuItem
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents mnuPrint As System.Windows.Forms.MenuItem
    Friend WithEvents mnuProp As System.Windows.Forms.MenuItem
    Friend WithEvents mnuRun As System.Windows.Forms.MenuItem
    Friend WithEvents ButtonsTree As LATIR2GUIControls.Buttons
    Friend WithEvents PanelButtons As System.Windows.Forms.Panel
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.tv = New System.Windows.Forms.TreeView
        Me.mnuService = New System.Windows.Forms.ContextMenu
        Me.mnuAddRoot = New System.Windows.Forms.MenuItem
        Me.mnuAdd = New System.Windows.Forms.MenuItem
        Me.mnuEdit = New System.Windows.Forms.MenuItem
        Me.mnuDel = New System.Windows.Forms.MenuItem
        Me.mnuRefresh = New System.Windows.Forms.MenuItem
        Me.mnuFind = New System.Windows.Forms.MenuItem
        Me.mnuProp = New System.Windows.Forms.MenuItem
        Me.mnuRun = New System.Windows.Forms.MenuItem
        Me.mnuPrint = New System.Windows.Forms.MenuItem
        Me.lblCaption = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.PanelButtons = New System.Windows.Forms.Panel
        Me.ButtonsTree = New LATIR2GUIControls.Buttons
        Me.Panel8 = New System.Windows.Forms.Panel
        Me.Panel9 = New System.Windows.Forms.Panel
        Me.PanelButtons.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.SuspendLayout()
        '
        'tv
        '
        Me.tv.ContextMenu = Me.mnuService
        Me.tv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tv.FullRowSelect = True
        Me.tv.HideSelection = False
        Me.tv.ImageIndex = -1
        Me.tv.Location = New System.Drawing.Point(0, 0)
        Me.tv.Name = "tv"
        Me.tv.SelectedImageIndex = -1
        Me.tv.Size = New System.Drawing.Size(768, 420)
        Me.tv.TabIndex = 0
        Me.tv.Tag = ""
        '
        'mnuService
        '
        Me.mnuService.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuAddRoot, Me.mnuAdd, Me.mnuEdit, Me.mnuDel, Me.mnuRefresh, Me.mnuFind, Me.mnuProp, Me.mnuRun, Me.mnuPrint})
        '
        'mnuAddRoot
        '
        Me.mnuAddRoot.Index = 0
        Me.mnuAddRoot.Text = "Добавить в корень"
        '
        'mnuAdd
        '
        Me.mnuAdd.Index = 1
        Me.mnuAdd.Text = "Добавить"
        '
        'mnuEdit
        '
        Me.mnuEdit.Index = 2
        Me.mnuEdit.Text = "Редактировать"
        '
        'mnuDel
        '
        Me.mnuDel.Index = 3
        Me.mnuDel.Text = "Удалить"
        '
        'mnuRefresh
        '
        Me.mnuRefresh.Index = 4
        Me.mnuRefresh.Text = "Обновить"
        '
        'mnuFind
        '
        Me.mnuFind.Index = 5
        Me.mnuFind.Text = "Поиск"
        '
        'mnuProp
        '
        Me.mnuProp.Index = 6
        Me.mnuProp.Text = "Свойства"
        '
        'mnuRun
        '
        Me.mnuRun.Index = 7
        Me.mnuRun.Text = "Открыть"
        '
        'mnuPrint
        '
        Me.mnuPrint.Index = 8
        Me.mnuPrint.Text = "Печать"
        '
        'lblCaption
        '
        Me.lblCaption.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCaption.Location = New System.Drawing.Point(0, 0)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.Size = New System.Drawing.Size(768, 22)
        Me.lblCaption.TabIndex = 18
        Me.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PanelButtons
        '
        Me.PanelButtons.Controls.Add(Me.ButtonsTree)
        Me.PanelButtons.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelButtons.Location = New System.Drawing.Point(0, 0)
        Me.PanelButtons.Name = "PanelButtons"
        Me.PanelButtons.Size = New System.Drawing.Size(768, 30)
        Me.PanelButtons.TabIndex = 20
        '
        'ButtonsTree
        '
        Me.ButtonsTree.AllowAdd = True
        Me.ButtonsTree.AllowAddRoot = True
        Me.ButtonsTree.AllowDel = True
        Me.ButtonsTree.AllowEdit = True
        Me.ButtonsTree.AllowFind = False
        Me.ButtonsTree.AllowProp = False
        Me.ButtonsTree.AllowPrint = True
        Me.ButtonsTree.AllowExport = True
        Me.ButtonsTree.AllowRefresh = True
        Me.ButtonsTree.AllowRun = True
        Me.ButtonsTree.Dock = System.Windows.Forms.DockStyle.Left
        Me.ButtonsTree.Location = New System.Drawing.Point(0, 0)
        Me.ButtonsTree.Name = "ButtonsTree"
        Me.ButtonsTree.Size = New System.Drawing.Size(776, 30)
        Me.ButtonsTree.TabIndex = 0
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.lblCaption)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel8.Location = New System.Drawing.Point(0, 30)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(768, 22)
        Me.Panel8.TabIndex = 21
        '
        'Panel9
        '
        Me.Panel9.Controls.Add(Me.tv)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel9.Location = New System.Drawing.Point(0, 52)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(768, 420)
        Me.Panel9.TabIndex = 22
        '
        'TreeView
        '
        Me.Controls.Add(Me.Panel9)
        Me.Controls.Add(Me.Panel8)
        Me.Controls.Add(Me.PanelButtons)
        Me.Name = "TreeView"
        Me.Size = New System.Drawing.Size(768, 472)
        Me.PanelButtons.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Events"
    Public Event OnTreeBeforeExpand(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs, ByRef UseDefault As Boolean)
    Public Event OnTreeAfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs, ByRef UseDefault As Boolean)
#End Region

#Region "Declarations"
    Private mAllowToolBar As Boolean
#End Region

#Region "Overloaded functions"
    Public Overloads Sub LoadLevelData(ByVal ID As System.Guid, ByVal dt As DataTable)
        MyBase.LoadLevelData(ID, dt, tv)
    End Sub
#End Region

#Region "Public Functions Properties"
    Public ReadOnly Property TreeView() As System.Windows.Forms.TreeView
        Get
            Return tv
        End Get
    End Property

    Public Property AllowToolBar() As Boolean
        Get
            Return mAllowToolBar
        End Get
        Set(ByVal Value As Boolean)
            mAllowToolBar = Value
            ButtonsTree.Visible = mAllowToolBar
            PanelButtons.Visible = mAllowToolBar
        End Set
    End Property

    Public ReadOnly Property SelectedNode() As TreeNode
        Get
            Return tv.SelectedNode
        End Get
    End Property

    Public ReadOnly Property SelectedNodeTag() As Object
        Get
            If (Not SelectedNode Is Nothing) Then
                Return SelectedNode.Tag
            End If
            Return Nothing
        End Get
    End Property

    Public Sub InitTreeColumns(ByVal ts As DataGridTableStyle)
        ' do nothng
    End Sub

#End Region

#Region "Main Service menu events"
    Private Sub mnuAddRoot_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuAddRoot.Click
        If (TreeAddRoot()) Then
            ' ...
        End If
    End Sub

    Private Sub mnuAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAdd.Click
        TreeAdd(tv)
    End Sub

    Private Sub mnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEdit.Click
        If (TreeEdit(tv)) Then
            ' ....
        End If
    End Sub

    Private Sub mnuDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDel.Click
        If (TreeDel(tv)) Then
            '....
        End If
    End Sub

    Private Sub mnuRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRefresh.Click
        If (TreeRefresh()) Then
            ' ...
        End If
    End Sub

    Private Sub mnuFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFind.Click
        If (TreeFind(tv)) Then
            ' ...
        End If
    End Sub

    Private Sub mnuRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRun.Click
        If (TreeRun(tv)) Then
            ' ...
        End If
    End Sub


    Private Sub mnuPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrint.Click
        If (TreePrint(tv)) Then
            ' ...
        End If
    End Sub

    Private Sub mnuProp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuProp.Click
        If (TreeProp(tv)) Then
            ' ...
        End If
    End Sub

#End Region

#Region "Buttons events"
    Private Sub Buttons1_OnAddRoot() Handles ButtonsTree.OnAddRoot
        mnuAddRoot_Click(Nothing, Nothing)
    End Sub

    Private Sub Buttons1_OnAdd() Handles ButtonsTree.OnAdd
        mnuAdd_Click(Nothing, Nothing)
    End Sub

    Private Sub Buttons1_OnDel() Handles ButtonsTree.OnDel
        mnuDel_Click(Nothing, Nothing)
    End Sub

    Private Sub Buttons1_OnEdit() Handles ButtonsTree.OnEdit
        mnuEdit_Click(Nothing, Nothing)
    End Sub

    Private Sub Buttons1_OnFind() Handles ButtonsTree.OnFind
        mnuFind_Click(Nothing, Nothing)
    End Sub

    Private Sub Buttons1_OnPrint() Handles ButtonsTree.OnPrint
        mnuPrint_Click(Nothing, Nothing)
    End Sub

    Private Sub Buttons1_OnExport() Handles ButtonsTree.OnExport
        mnuProp_Click(Nothing, Nothing)
    End Sub

    Private Sub Buttons1_OnRefresh() Handles ButtonsTree.OnRefresh
        mnuRefresh_Click(Nothing, Nothing)
    End Sub

    Private Sub Buttons1_OnRun() Handles ButtonsTree.OnRun
        mnuRun_Click(Nothing, Nothing)
    End Sub
#End Region

#Region "Tree View events"
    Private Sub tv_BeforeExpand(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles tv.BeforeExpand
        Dim UseDefault As Boolean
        UseDefault = True
        RaiseEvent OnTreeBeforeExpand(sender, e, UseDefault)
        If (UseDefault) Then
            BeforeExpand(sender, e)
        End If
    End Sub

    Private Sub tv_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tv.AfterSelect
        Dim UseDefault As Boolean
        UseDefault = True
        RaiseEvent OnTreeAfterSelect(sender, e, UseDefault)
        If (UseDefault) Then
            TreeSelect(e)
        End If
    End Sub
#End Region

#Region "Find Functions"
    Public Overloads Function FindNode(ByVal root As TreeNodeCollection, ByVal ID As System.Guid) As TreeNode
        Return MyBase.FindNode(root, ID)
    End Function
#End Region




End Class

