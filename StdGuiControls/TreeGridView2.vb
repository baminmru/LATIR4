Imports System.IO
Imports System.Drawing
Imports LATIR2GUIControls

Public Class TreeGridView
    Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        ButtonUtils.PrepareForm(ToolTip1, Me.Controls)
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents mnuChildService As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuChAdd As System.Windows.Forms.MenuItem
    Friend WithEvents mnuChEdit As System.Windows.Forms.MenuItem
    Friend WithEvents mnuChDel As System.Windows.Forms.MenuItem
    Friend WithEvents mnuChRefresh As System.Windows.Forms.MenuItem
    Friend WithEvents mnuChFind As System.Windows.Forms.MenuItem
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Public WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents mnuChRun As System.Windows.Forms.MenuItem
    Friend WithEvents mnuChPrint As System.Windows.Forms.MenuItem
    Friend WithEvents mnuChProp As System.Windows.Forms.MenuItem
    Friend WithEvents TreeViewControl As LATIR2GUIControls.TreeView
    Friend WithEvents GridViewControl As LATIR2GUIControls.GridView
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TreeViewControl = New LATIR2GUIControls.TreeView
        Me.Splitter1 = New System.Windows.Forms.Splitter
        Me.mnuChildService = New System.Windows.Forms.ContextMenu
        Me.mnuChAdd = New System.Windows.Forms.MenuItem
        Me.mnuChEdit = New System.Windows.Forms.MenuItem
        Me.mnuChDel = New System.Windows.Forms.MenuItem
        Me.mnuChRefresh = New System.Windows.Forms.MenuItem
        Me.mnuChFind = New System.Windows.Forms.MenuItem
        Me.mnuChProp = New System.Windows.Forms.MenuItem
        Me.mnuChRun = New System.Windows.Forms.MenuItem
        Me.mnuChPrint = New System.Windows.Forms.MenuItem
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.GridViewControl = New LATIR2GUIControls.GridView
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TreeViewControl)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(320, 504)
        Me.Panel1.TabIndex = 20
        '
        'TreeViewControl
        '
        Me.TreeViewControl.AllowToolBar = True
        Me.TreeViewControl.Caption = Nothing
        Me.TreeViewControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeViewControl.LabelCaption = Nothing
        Me.TreeViewControl.Location = New System.Drawing.Point(0, 0)
        Me.TreeViewControl.Name = "TreeViewControl"
        Me.TreeViewControl.Size = New System.Drawing.Size(320, 504)
        Me.TreeViewControl.TabIndex = 0
        '
        'Splitter1
        '
        Me.Splitter1.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Splitter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Splitter1.Location = New System.Drawing.Point(320, 0)
        Me.Splitter1.MinExtra = 200
        Me.Splitter1.MinSize = 200
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(8, 504)
        Me.Splitter1.TabIndex = 21
        Me.Splitter1.TabStop = False
        '
        'mnuChildService
        '
        Me.mnuChildService.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuChAdd, Me.mnuChEdit, Me.mnuChDel, Me.mnuChRefresh, Me.mnuChFind, Me.mnuChProp, Me.mnuChRun, Me.mnuChPrint})
        '
        'mnuChAdd
        '
        Me.mnuChAdd.Index = 0
        Me.mnuChAdd.Text = "Добавить"
        '
        'mnuChEdit
        '
        Me.mnuChEdit.Index = 1
        Me.mnuChEdit.Text = "Редактировать"
        '
        'mnuChDel
        '
        Me.mnuChDel.Index = 2
        Me.mnuChDel.Text = "Удалить"
        '
        'mnuChRefresh
        '
        Me.mnuChRefresh.Index = 3
        Me.mnuChRefresh.Text = "Обновить"
        '
        'mnuChFind
        '
        Me.mnuChFind.Index = 4
        Me.mnuChFind.Text = "Поиск"
        '
        'mnuChProp
        '
        Me.mnuChProp.Index = 5
        Me.mnuChProp.Text = "Свойства"
        '
        'mnuChRun
        '
        Me.mnuChRun.Index = 6
        Me.mnuChRun.Text = "Открыть"
        '
        'mnuChPrint
        '
        Me.mnuChPrint.Index = 7
        Me.mnuChPrint.Text = "Печать"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GridViewControl)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(328, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(528, 504)
        Me.Panel2.TabIndex = 22
        '
        'GridViewControl
        '
        Me.GridViewControl.AllowToolBar = True
        Me.GridViewControl.Caption = Nothing
        Me.GridViewControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridViewControl.LabelCaption = Nothing
        Me.GridViewControl.Location = New System.Drawing.Point(0, 0)
        Me.GridViewControl.Name = "GridViewControl"
        Me.GridViewControl.Size = New System.Drawing.Size(528, 504)
        Me.GridViewControl.TabIndex = 0
        '
        'TreeGridView
        '
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "TreeGridView"
        Me.Size = New System.Drawing.Size(856, 504)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Declarations"
    Private mGUIManager As LATIR2GuiManager.LATIRGuiManager
    Private mPartName As String
    Private mTreeFieldName As String
#End Region

#Region "Events Declarations"


    Public Event OnTreeAddRoot(ByRef OK As Boolean)
    Public Event OnTreeAdd(ByRef OK As Boolean, ByVal ParentID As System.Guid)
    Public Event OnTreeRefresh(ByRef OK As Boolean)
    Public Event OnTreeFind(ByRef OK As Boolean, ByRef UseDefault As Boolean)
    Public Event OnTreeDel(ByRef OK As Boolean, ByVal ID As System.Guid)
    Public Event OnTreeEdit(ByRef OK As Boolean, ByVal ID As System.Guid)
    Public Event OnTreeProp(ByRef OK As Boolean, ByRef UseDefault As Boolean)
    Public Event OnTreeRun(ByRef OK As Boolean, ByVal ID As System.Guid, ByRef UseDefault As Boolean)
    Public Event OnTreePrint(ByRef ID As System.Guid, ByRef UseDefault As Boolean)

    Public Event OnTreeGetData(ByVal ID As System.Guid)
    Public Event OnTreeSelect(ByVal ID As System.Guid)

    ' Родительская запись передается для того чтобы можно было обновить иформацию
    Public Event OnGridAdd(ByRef OK As Boolean, ByVal ParentID As System.Guid)
    Public Event OnGridRefresh(ByVal ParentID As System.Guid)
    Public Event OnGridFind(ByRef UseDefault As Boolean)
    Public Event OnGridDel(ByRef OK As Boolean, ByVal ParentID As System.Guid, ByVal ID As System.Guid)
    Public Event OnGridEdit(ByRef OK As Boolean, ByVal ParentID As System.Guid, ByVal ID As System.Guid)
    Public Event OnGridRun(ByRef OK As Boolean, ByVal ID As System.Guid, ByRef UseDefault As Boolean)
    Public Event OnGridPrint(ByRef OK As Boolean, ByRef UseDefault As Boolean)
    Public Event OnGridExport(ByRef OK As Boolean, ByRef UseDefault As Boolean)

    Public Event OnGridGetData(ByVal ID As System.Guid)
#End Region

#Region "Init attach functions"
    Public Function GuiManager() As LATIR2GuiManager.LATIRGuiManager

        GuiManager = mGUIManager
    End Function

    Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal partName As String, ByVal TreeFieldName As String)
        mGUIManager = gm
        mTreeFieldName = TreeFieldName
        mPartName = partName
        ' RaiseEvent GetLevelData(System.Guid.Empty)
        TreeViewControl.Attach(gm, partName, TreeFieldName, String.Empty)

    End Sub

    ' for Grid
    Public Sub InitChildFields(ByVal ts As DataGridTableStyle)
        GridViewControl.InitFields(ts)
    End Sub

    Public Sub InitTreeColumns(ByVal ts As DataGridTableStyle)
        ' do nothng
    End Sub
#End Region

#Region "Load Data functions"
    Public Sub SetChildData(ByVal dt As Data.DataTable)
        GridViewControl.SetData(dt, True)
    End Sub


    Public Sub LoadLevelData(ByVal ID As System.Guid, ByVal dt As DataTable)
        TreeViewControl.LoadLevelData(ID, dt)
    End Sub

    Public Sub RefreshData()
        TreeViewControl.Refresh()
    End Sub

#End Region

    Private ReadOnly Property tv() As System.Windows.Forms.TreeView
        Get
            Return TreeViewControl.TreeView
        End Get
    End Property

#Region "TreeView Events"

    Private Sub TreeViewControl_OnTreeAfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs, ByRef UseDefault As Boolean) Handles TreeViewControl.OnTreeAfterSelect
        GridViewControl_OnGridRefresh()
    End Sub
    Private Sub TreeViewControl_GetLevelData(ByVal Parent As System.Guid) Handles TreeViewControl.OnTreeGetData
        RaiseEvent OnTreeGetData(Parent)
    End Sub

    Private Sub TreeViewControl_OnTreeAdd(ByRef OK As Boolean, ByVal ID As System.Guid) Handles TreeViewControl.OnTreeAdd
        RaiseEvent OnTreeAdd(OK, ID)
    End Sub

    Private Sub TreeViewControl_OnTreeAddRoot(ByRef OK As Boolean) Handles TreeViewControl.OnTreeAddRoot
        RaiseEvent OnTreeAddRoot(OK)
    End Sub

    Private Sub TreeViewControl_OnTreeDel(ByRef OK As Boolean, ByVal ID As System.Guid) Handles TreeViewControl.OnTreeDel
        RaiseEvent OnTreeDel(OK, ID)
    End Sub

    Private Sub TreeViewControl_OnTreeEdit(ByRef OK As Boolean, ByVal ID As System.Guid) Handles TreeViewControl.OnTreeEdit
        RaiseEvent OnTreeEdit(OK, ID)
    End Sub

    Private Sub TreeViewControl_OnTreeFind(ByRef OK As Boolean, ByRef UseDefault As Boolean) Handles TreeViewControl.OnTreeFind
        RaiseEvent OnTreeFind(OK, UseDefault)
    End Sub

    Private Sub TreeViewControl_OnTreePrint(ByRef OK As Boolean, ByRef UseDefault As Boolean) Handles TreeViewControl.OnTreePrint
        RaiseEvent OnTreeFind(OK, UseDefault)
    End Sub

    Private Sub TreeViewControl_OnTreeProp(ByRef OK As Boolean, ByRef UseDefault As Boolean) Handles TreeViewControl.OnTreeProp
        RaiseEvent OnTreeProp(OK, UseDefault)
    End Sub

    Private Sub TreeViewControl_OnTreeRefresh(ByRef OK As Boolean) Handles TreeViewControl.OnTreeRefresh
        RaiseEvent OnTreeRefresh(OK)
    End Sub

    Private Sub TreeViewControl_OnTreeRun(ByRef OK As Boolean, ByVal ID As System.Guid, ByRef UseDefault As Boolean) Handles TreeViewControl.OnTreeRun
        RaiseEvent OnTreeRun(OK, ID, UseDefault)
    End Sub

    Private Sub TreeViewControl_OnTreeSelect(ByVal ID As System.Guid) Handles TreeViewControl.OnTreeSelect
        RaiseEvent OnTreeSelect(ID)
        GridViewControl_OnGridRefresh()

    End Sub
#End Region

    Private Sub GridViewControl_OnGridAdd(ByRef OK As Boolean, ByVal ID As System.Guid) Handles GridViewControl.OnGridAdd
        Dim ParentID As System.Guid
        If (Not TreeViewControl.SelectedNodeTag Is Nothing) Then
            If (TypeOf (TreeViewControl.SelectedNodeTag) Is System.Guid) Then
                ParentID = TreeViewControl.SelectedNodeTag
                RaiseEvent OnGridAdd(OK, ParentID)
            End If
        End If

    End Sub

    Private Sub GridViewControl_OnGridDel(ByRef OK As Boolean, ByVal ID As System.Guid) Handles GridViewControl.OnGridDel
        Dim ParentID As System.Guid
        If (Not TreeViewControl.SelectedNodeTag Is Nothing) Then
            If (TypeOf (TreeViewControl.SelectedNodeTag) Is System.Guid) Then
                ParentID = TreeViewControl.SelectedNodeTag
                RaiseEvent OnGridDel(OK, ParentID, ID)
            End If
        End If
    End Sub

    Private Sub GridViewControl_OnGridEdit(ByRef OK As Boolean, ByVal ID As System.Guid) Handles GridViewControl.OnGridEdit
        Dim ParentID As System.Guid
        If (Not TreeViewControl.SelectedNodeTag Is Nothing) Then
            If (TypeOf (TreeViewControl.SelectedNodeTag) Is System.Guid) Then
                ParentID = TreeViewControl.SelectedNodeTag
                RaiseEvent OnGridEdit(OK, ParentID, ID)
            End If
        End If
    End Sub

    Private Sub GridViewControl_OnGridFind(ByVal UseDefault As Boolean) Handles GridViewControl.OnGridFind
        RaiseEvent OnGridFind(UseDefault)
    End Sub

    Private Sub GridViewControl_OnGridGetData(ByVal ID As System.Guid) Handles GridViewControl.OnGridGetData
        RaiseEvent OnGridGetData(ID)
    End Sub

    Private Sub GridViewControl_OnGridPrint(ByRef OK As Boolean, ByRef UseDefault As Boolean) Handles GridViewControl.OnGridPrint
        RaiseEvent OnGridPrint(OK, UseDefault)
    End Sub

    Private Sub GridViewControl_OnGridExport(ByRef OK As Boolean, ByRef UseDefault As Boolean) Handles GridViewControl.OnGridExport
        RaiseEvent OnGridExport(OK, UseDefault)
    End Sub

    Private Sub GridViewControl_OnGridRefresh() Handles GridViewControl.OnGridRefresh
        Dim ParentID As System.Guid
        If (Not TreeViewControl.SelectedNodeTag Is Nothing) Then
            If (TypeOf (TreeViewControl.SelectedNodeTag) Is System.Guid) Then
                ParentID = TreeViewControl.SelectedNodeTag
                RaiseEvent OnGridRefresh(ParentID)
            End If
        End If
    End Sub

    Private Sub GridViewControl_OnGridRowColChange(ByVal ID As System.Guid) Handles GridViewControl.OnGridRowColChange

    End Sub

    Private Sub GridViewControl_OnGridRun(ByRef OK As Boolean, ByVal ID As System.Guid, ByRef UseDefault As Boolean) Handles GridViewControl.OnGridRun
        RaiseEvent OnGridRun(OK, ID, UseDefault)
    End Sub

    Private Sub TreeViewControl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TreeViewControl.Load

    End Sub
End Class
