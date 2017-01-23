Imports System.IO
Imports System.Drawing

Public Class GridGridView
    Inherits CommonControlParent

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
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents mnuService As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuAdd As System.Windows.Forms.MenuItem
    Friend WithEvents mnuEdit As System.Windows.Forms.MenuItem
    Friend WithEvents mnuDel As System.Windows.Forms.MenuItem
    Friend WithEvents mnuChildService As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuRefresh As System.Windows.Forms.MenuItem
    Friend WithEvents mnuFInd As System.Windows.Forms.MenuItem
    Friend WithEvents mnuChAdd As System.Windows.Forms.MenuItem
    Friend WithEvents mnuChEdit As System.Windows.Forms.MenuItem
    Friend WithEvents mnuChDel As System.Windows.Forms.MenuItem
    Friend WithEvents mnuChRefresh As System.Windows.Forms.MenuItem
    Friend WithEvents mnuChFind As System.Windows.Forms.MenuItem
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents mnuProp As System.Windows.Forms.MenuItem
    Friend WithEvents mnuRun As System.Windows.Forms.MenuItem
    Friend WithEvents mnuPrint As System.Windows.Forms.MenuItem
    Friend WithEvents mnuChProp As System.Windows.Forms.MenuItem
    Friend WithEvents mnuChRun As System.Windows.Forms.MenuItem
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents GridViewMaster As LATIR2GUIControls.GridView
    Friend WithEvents GridViewChild As LATIR2GUIControls.GridView
    Friend WithEvents mnuChPrint As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.mnuService = New System.Windows.Forms.ContextMenu
        Me.mnuAdd = New System.Windows.Forms.MenuItem
        Me.mnuEdit = New System.Windows.Forms.MenuItem
        Me.mnuDel = New System.Windows.Forms.MenuItem
        Me.mnuRefresh = New System.Windows.Forms.MenuItem
        Me.mnuFInd = New System.Windows.Forms.MenuItem
        Me.mnuProp = New System.Windows.Forms.MenuItem
        Me.mnuRun = New System.Windows.Forms.MenuItem
        Me.mnuPrint = New System.Windows.Forms.MenuItem
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.GridViewMaster = New LATIR2GUIControls.GridView
        Me.GridViewChild = New LATIR2GUIControls.GridView
        Me.mnuChildService = New System.Windows.Forms.ContextMenu
        Me.mnuChAdd = New System.Windows.Forms.MenuItem
        Me.mnuChEdit = New System.Windows.Forms.MenuItem
        Me.mnuChDel = New System.Windows.Forms.MenuItem
        Me.mnuChRefresh = New System.Windows.Forms.MenuItem
        Me.mnuChFind = New System.Windows.Forms.MenuItem
        Me.mnuChProp = New System.Windows.Forms.MenuItem
        Me.mnuChRun = New System.Windows.Forms.MenuItem
        Me.mnuChPrint = New System.Windows.Forms.MenuItem
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel2.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnuService
        '
        Me.mnuService.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuAdd, Me.mnuEdit, Me.mnuDel, Me.mnuRefresh, Me.mnuFInd, Me.mnuProp, Me.mnuRun, Me.mnuPrint})
        '
        'mnuAdd
        '
        Me.mnuAdd.Index = 0
        Me.mnuAdd.Text = "Добавить"
        '
        'mnuEdit
        '
        Me.mnuEdit.Index = 1
        Me.mnuEdit.Text = "Редактировать"
        '
        'mnuDel
        '
        Me.mnuDel.Index = 2
        Me.mnuDel.Text = "Удалить"
        '
        'mnuRefresh
        '
        Me.mnuRefresh.Index = 3
        Me.mnuRefresh.Text = "Обновить"
        '
        'mnuFInd
        '
        Me.mnuFInd.Index = 4
        Me.mnuFInd.Text = "Поиск"
        '
        'mnuProp
        '
        Me.mnuProp.Index = 5
        Me.mnuProp.Text = "Настройка"
        '
        'mnuRun
        '
        Me.mnuRun.Index = 6
        Me.mnuRun.Text = "Открыть"
        '
        'mnuPrint
        '
        Me.mnuPrint.Index = 7
        Me.mnuPrint.Text = "Печать"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.SplitContainer1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(792, 496)
        Me.Panel2.TabIndex = 1
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GridViewMaster)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.GridViewChild)
        Me.SplitContainer1.Size = New System.Drawing.Size(792, 496)
        Me.SplitContainer1.SplitterDistance = 264
        Me.SplitContainer1.TabIndex = 0
        '
        'GridViewMaster
        '
        Me.GridViewMaster.AllowToolBar = True
        Me.GridViewMaster.Caption = ""
        Me.GridViewMaster.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridViewMaster.LabelCaption = Nothing
        Me.GridViewMaster.Location = New System.Drawing.Point(0, 0)
        Me.GridViewMaster.Name = "GridViewMaster"
        Me.GridViewMaster.Size = New System.Drawing.Size(792, 264)
        Me.GridViewMaster.TabIndex = 1
        '
        'GridViewChild
        '
        Me.GridViewChild.AllowToolBar = True
        Me.GridViewChild.Caption = ""
        Me.GridViewChild.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridViewChild.LabelCaption = Nothing
        Me.GridViewChild.Location = New System.Drawing.Point(0, 0)
        Me.GridViewChild.Name = "GridViewChild"
        Me.GridViewChild.Size = New System.Drawing.Size(792, 228)
        Me.GridViewChild.TabIndex = 3
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
        Me.mnuChProp.Text = "Настройка"
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
        'GridGridView
        '
        Me.Controls.Add(Me.Panel2)
        Me.Name = "GridGridView"
        Me.Size = New System.Drawing.Size(792, 496)
        Me.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Events declaration"
    Public Event OnMasterGridAdd(ByRef OK As Boolean)
    Public Event OnMasterGridRefresh()
    Public Event OnMasterGridFind(ByVal UseDefault As Boolean)
    Public Event OnMasterGridDel(ByRef OK As Boolean, ByVal ID As System.Guid)
    Public Event OnMasterGridEdit(ByRef OK As Boolean, ByVal ID As System.Guid)
    Public Event OnMasterGridProp(ByRef OK As Boolean, ByRef UseDefault As Boolean)
    Public Event OnMasterGridRun(ByRef OK As Boolean, ByVal ID As System.Guid, ByRef UseDefault As Boolean)
    Public Event OnMasterGridPrint(ByRef OK As Boolean, ByRef UseDefault As Boolean)

    Public Event OnMasterGridRowColChange(ByVal ID As System.Guid)
    Public Event OnMasterGridGetData()

    Public Event OnChildGridAdd(ByRef OK As Boolean)
    Public Event OnChildGridRefresh()
    Public Event OnChildGridFind(ByVal UseDefault As Boolean)
    Public Event OnChildGridDel(ByRef OK As Boolean, ByVal ID As System.Guid)
    Public Event OnChildGridEdit(ByRef OK As Boolean, ByVal ID As System.Guid)
    Public Event OnChildGridProp(ByRef OK As Boolean, ByRef UseDefault As Boolean)
    Public Event OnChildGridRun(ByRef OK As Boolean, ByVal ID As System.Guid, ByRef UseDefault As Boolean)
    Public Event OnChildGridPrint(ByRef OK As Boolean, ByRef UseDefault As Boolean)

    Public Event OnChildGridRowColChange(ByVal ID As System.Guid)
    Public Event OnChildGridGetData()
#End Region

#Region "Init, attach etc"

    Public Overloads Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal MasterPartName As String, ByVal ChildPartName As String, ByVal MasterControlCaption As String, ByVal ChildControlCaption As String)
        GridViewMaster.Attach(gm, MasterPartName, MasterControlCaption)
        GridViewChild.Attach(gm, ChildPartName, ChildControlCaption)
    End Sub

    Public Sub InitFieldsMaster(ByVal ts As DataGridTableStyle)
        GridViewMaster.InitFields(ts)
    End Sub

    Public Sub SetDataMaster(ByVal dt As Data.DataTable)
        GridViewMaster.SetData(dt)
        GridViewChild_OnGridRefresh()
    End Sub

    Public Sub InitFieldsChild(ByVal ts As DataGridTableStyle)
        GridViewChild.InitFields(ts)
    End Sub

    Public Sub SetDataChild(ByVal dt As Data.DataTable)
        GridViewChild.SetData(dt, True)
    End Sub

#End Region

    Public Function GetMasterID() As System.Guid
        If (Not GridViewMaster.gr Is Nothing) Then
            If Not GridViewMaster.gr.ActiveRow Is Nothing Then
                If GridViewMaster.gr.ActiveRow.IsDataRow Then
                    Return New Guid(GridViewMaster.gr.ActiveRow.Cells(Constants.FIELD_ID).Value.ToString())
                End If
            End If
        End If
        Return System.Guid.Empty
    End Function


#Region "Main Events"
    Private Sub GridViewMaster_OnGridEdit(ByRef OK As Boolean, ByVal ID As System.Guid) Handles GridViewMaster.OnGridEdit
        RaiseEvent OnMasterGridEdit(OK, ID)
    End Sub

    Private Sub GridViewMaster_OnGridAdd(ByRef OK As Boolean, ByVal ID As System.Guid) Handles GridViewMaster.OnGridAdd
        RaiseEvent OnMasterGridAdd(OK)
    End Sub

    Private Sub GridViewMaster_OnGridDel(ByRef OK As Boolean, ByVal ID As System.Guid) Handles GridViewMaster.OnGridDel
        RaiseEvent OnMasterGridDel(OK, ID)
    End Sub

    Private Sub GridViewMaster_OnGridFind(ByVal UseDefault As Boolean) Handles GridViewMaster.OnGridFind
        RaiseEvent OnMasterGridFind(UseDefault)
    End Sub

    Private Sub GridViewMaster_OnGridGetData(ByVal ID As System.Guid) Handles GridViewMaster.OnGridGetData
        RaiseEvent OnMasterGridGetData()
    End Sub

    Private Sub GridViewMaster_OnGridPrint(ByRef OK As Boolean, ByRef UseDefault As Boolean) Handles GridViewMaster.OnGridPrint
        RaiseEvent OnMasterGridPrint(OK, UseDefault)
    End Sub

    Private Sub GridViewMaster_OnGridProp(ByRef OK As Boolean, ByRef UseDefault As Boolean) Handles GridViewMaster.OnGridProp
        RaiseEvent OnMasterGridProp(OK, UseDefault)
    End Sub

    Private Sub GridViewMaster_OnGridRefresh() Handles GridViewMaster.OnGridRefresh
        RaiseEvent OnMasterGridRefresh()
    End Sub

    Private Sub GridViewMaster_OnGridRowColChange(ByVal ID As System.Guid) Handles GridViewMaster.OnGridRowColChange
        'Dim dt As DataTable
        'dt = GridViewMaster.gr.DataSource
        Dim oldC As Cursor
        oldC = Cursor
        Cursor = Cursors.WaitCursor
        GridViewChild_OnGridRefresh()
        Cursor = oldC
    End Sub

    Private Sub GridViewMaster_OnGridRun(ByRef OK As Boolean, ByVal ID As System.Guid, ByRef UseDefault As Boolean) Handles GridViewMaster.OnGridRun
        RaiseEvent OnMasterGridRun(OK, ID, UseDefault)
    End Sub
#End Region

#Region "Child Events"
    Private Sub GridViewChild_OnGridAdd(ByRef OK As Boolean, ByVal ParentID As System.Guid) Handles GridViewChild.OnGridAdd
        RaiseEvent OnChildGridAdd(OK)
    End Sub

    Private Sub GridViewChild_OnGridDel(ByRef OK As Boolean, ByVal ID As System.Guid) Handles GridViewChild.OnGridDel
        RaiseEvent OnChildGridDel(OK, ID)
    End Sub

    Private Sub GridViewChild_OnGridEdit(ByRef OK As Boolean, ByVal ID As System.Guid) Handles GridViewChild.OnGridEdit
        RaiseEvent OnChildGridEdit(OK, ID)
    End Sub

    Private Sub GridViewChild_OnGridFind(ByVal UseDefault As Boolean) Handles GridViewChild.OnGridFind
        RaiseEvent OnChildGridFind(UseDefault)
    End Sub

    Private Sub GridViewChild_OnGridGetData(ByVal ID As System.Guid) Handles GridViewChild.OnGridGetData
        RaiseEvent OnChildGridGetData()
    End Sub

    Private Sub GridViewChild_OnGridPrint(ByRef OK As Boolean, ByRef UseDefault As Boolean) Handles GridViewChild.OnGridPrint
        RaiseEvent OnChildGridPrint(OK, UseDefault)
    End Sub

    Private Sub GridViewChild_OnGridProp(ByRef OK As Boolean, ByRef UseDefault As Boolean) Handles GridViewChild.OnGridProp
        RaiseEvent OnChildGridProp(OK, UseDefault)
    End Sub

    Private Sub GridViewChild_OnGridRefresh() Handles GridViewChild.OnGridRefresh
        Try
            RaiseEvent OnChildGridRefresh()
        Catch
        End Try
    End Sub

    Private Sub GridViewChild_OnGridRowColChange(ByVal ID As System.Guid) Handles GridViewChild.OnGridRowColChange
        RaiseEvent OnChildGridRowColChange(ID)
    End Sub

    Private Sub GridViewChild_OnGridRun(ByRef OK As Boolean, ByVal ID As System.Guid, ByRef UseDefault As Boolean) Handles GridViewChild.OnGridRun
        RaiseEvent OnChildGridRun(OK, ID, UseDefault)
    End Sub
#End Region

    Private Sub GridViewMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridViewMaster.Load

    End Sub
End Class
