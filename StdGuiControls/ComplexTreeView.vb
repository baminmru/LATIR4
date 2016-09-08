Imports LATIR2GUIControls

Public Class ComplexTreeView
    Inherits CommonControlParent

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        ButtonUtils.PrepareForm(ToolTip1, Me.Controls)
        TreeUtils.PrepareImageList(TreeImageList)
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
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents TreeImageList As System.Windows.Forms.ImageList
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents TreeViewControl As LATIR2GUIControls.TreeView
    Friend WithEvents GridViewControl As LATIR2GUIControls.GridView
    Friend WithEvents PanelTree As System.Windows.Forms.Panel
    Friend WithEvents ButtonsControl As LATIR2GUIControls.Buttons
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    	Me.components = New System.ComponentModel.Container
    	Me.TreeImageList = New System.Windows.Forms.ImageList(Me.components)
    	Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
    	Me.Panel1 = New System.Windows.Forms.Panel
    	Me.ButtonsControl = New LATIR2GUIControls.Buttons
    	Me.Panel2 = New System.Windows.Forms.Panel
    	Me.Splitter1 = New System.Windows.Forms.Splitter
    	Me.Panel4 = New System.Windows.Forms.Panel
    	Me.GridViewControl = New LATIR2GUIControls.GridView
    	Me.PanelTree = New System.Windows.Forms.Panel
    	Me.TreeViewControl = New LATIR2GUIControls.TreeView
    	Me.Panel1.SuspendLayout
    	Me.Panel2.SuspendLayout
    	Me.Panel4.SuspendLayout
    	Me.PanelTree.SuspendLayout
    	Me.SuspendLayout
    	'
    	'TreeImageList
    	'
    	Me.TreeImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
    	Me.TreeImageList.ImageSize = New System.Drawing.Size(16, 16)
    	Me.TreeImageList.TransparentColor = System.Drawing.Color.Transparent
    	'
    	'Panel1
    	'
    	Me.Panel1.Controls.Add(Me.ButtonsControl)
    	Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
    	Me.Panel1.Location = New System.Drawing.Point(0, 0)
    	Me.Panel1.Name = "Panel1"
    	Me.Panel1.Size = New System.Drawing.Size(848, 32)
    	Me.Panel1.TabIndex = 0
    	'
    	'ButtonsControl
    	'
    	Me.ButtonsControl.AllowAdd = true
    	Me.ButtonsControl.AllowAddRoot = false
    	Me.ButtonsControl.AllowDel = true
    	Me.ButtonsControl.AllowEdit = true
    	Me.ButtonsControl.AllowFind = true
    	Me.ButtonsControl.AllowPrint = true
    	Me.ButtonsControl.AllowProp = true
    	Me.ButtonsControl.AllowRefresh = true
    	Me.ButtonsControl.AllowRun = true
    	Me.ButtonsControl.Dock = System.Windows.Forms.DockStyle.Fill
    	Me.ButtonsControl.Location = New System.Drawing.Point(0, 0)
    	Me.ButtonsControl.Name = "ButtonsControl"
    	Me.ButtonsControl.Size = New System.Drawing.Size(848, 32)
    	Me.ButtonsControl.TabIndex = 0
    	'
    	'Panel2
    	'
    	Me.Panel2.Controls.Add(Me.Splitter1)
    	Me.Panel2.Controls.Add(Me.Panel4)
    	Me.Panel2.Controls.Add(Me.PanelTree)
    	Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
    	Me.Panel2.Location = New System.Drawing.Point(0, 32)
    	Me.Panel2.Name = "Panel2"
    	Me.Panel2.Size = New System.Drawing.Size(848, 664)
    	Me.Panel2.TabIndex = 1
    	'
    	'Splitter1
    	'
    	Me.Splitter1.BackColor = System.Drawing.SystemColors.ControlDark
    	Me.Splitter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    	Me.Splitter1.Location = New System.Drawing.Point(232, 0)
    	Me.Splitter1.Name = "Splitter1"
    	Me.Splitter1.Size = New System.Drawing.Size(8, 664)
    	Me.Splitter1.TabIndex = 2
    	Me.Splitter1.TabStop = false
    	'
    	'Panel4
    	'
    	Me.Panel4.Controls.Add(Me.GridViewControl)
    	Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
    	Me.Panel4.Location = New System.Drawing.Point(232, 0)
    	Me.Panel4.Name = "Panel4"
    	Me.Panel4.Size = New System.Drawing.Size(616, 664)
    	Me.Panel4.TabIndex = 1
    	'
    	'GridViewControl
    	'
    	Me.GridViewControl.AllowToolBar = false
    	Me.GridViewControl.Caption = Nothing
    	Me.GridViewControl.Dock = System.Windows.Forms.DockStyle.Fill
    	Me.GridViewControl.LabelCaption = Nothing
    	Me.GridViewControl.Location = New System.Drawing.Point(0, 0)
    	Me.GridViewControl.Name = "GridViewControl"
    	Me.GridViewControl.Size = New System.Drawing.Size(616, 664)
    	Me.GridViewControl.TabIndex = 0
    	'
    	'PanelTree
    	'
    	Me.PanelTree.Controls.Add(Me.TreeViewControl)
    	Me.PanelTree.Dock = System.Windows.Forms.DockStyle.Left
    	Me.PanelTree.Location = New System.Drawing.Point(0, 0)
    	Me.PanelTree.Name = "PanelTree"
    	Me.PanelTree.Size = New System.Drawing.Size(232, 664)
    	Me.PanelTree.TabIndex = 0
    	'
    	'TreeViewControl
    	'
    	Me.TreeViewControl.AllowToolBar = false
    	Me.TreeViewControl.Caption = ""
    	Me.TreeViewControl.Dock = System.Windows.Forms.DockStyle.Fill
    	Me.TreeViewControl.Location = New System.Drawing.Point(0, 0)
    	Me.TreeViewControl.Name = "TreeViewControl"
    	Me.TreeViewControl.Size = New System.Drawing.Size(232, 664)
    	Me.TreeViewControl.TabIndex = 0
    	'
    	'ComplexTreeView
    	'
    	Me.Controls.Add(Me.Panel2)
    	Me.Controls.Add(Me.Panel1)
    	Me.Name = "ComplexTreeView"
    	Me.Size = New System.Drawing.Size(848, 696)
    	Me.Panel1.ResumeLayout(false)
    	Me.Panel2.ResumeLayout(false)
    	Me.Panel4.ResumeLayout(false)
    	Me.PanelTree.ResumeLayout(false)
    	Me.ResumeLayout(false)
    End Sub

#End Region

#Region "Declarations"
    Private mRootPartName As String
    Private mGridPartName As String


    Private IgnoreSelect As Boolean
#End Region

#Region "Events"
    ' получить данные для конкретного раздела от некоторого родителя
    Public Event OnTreeGetLevelData(ByVal Parent As System.Guid, ByVal PartName As String, ByVal ChildPartName As String)
    ' получить список разделов для отражения в дереве
    Public Event OnTreeGetItemParts(ByVal Parent As System.Guid, ByVal PartName As String)

    Public Event OnTreeAddRoot(ByRef OK As Boolean)
    Public Event OnTreeAdd(ByRef OK As Boolean, ByVal ParentID As System.Guid, ByVal ParentPartName As String, ByVal RowPartName As String)
    Public Event OnTreeRefresh()
    Public Event OnTreeFind(ByRef UseDefault As Boolean)
    Public Event OnTreeDel(ByRef OK As Boolean, ByVal ID As System.Guid, ByVal PartName As String)
    Public Event OnTreeEdit(ByRef OK As Boolean, ByVal ID As System.Guid, ByVal PartName As String)
    Public Event OnTreeProp(ByRef OK As Boolean, ByVal ID As System.Guid, ByVal PartName As String)

    Public Event OnGridAdd(ByRef OK As Boolean, ByVal ParentID As System.Guid)
    ' во время исполнения этого события загружаются данные раздела (SetGridData)
    Public Event OnGridRefresh(ByVal ParentID As System.Guid, ByVal ParentPartName As String, ByVal DataPartName As String)
    Public Event OnGridFind(ByRef UseDefault As Boolean)
    Public Event OnGridDel(ByRef OK As Boolean, ByVal ID As System.Guid)
    Public Event OnGridEdit(ByRef OK As Boolean, ByVal ID As System.Guid)
    Public Event OnGridProp(ByRef OK As Boolean, ByRef UseDefault As Boolean)
    Public Event OnGridRun(ByRef OK As Boolean, ByVal ID As System.Guid, ByRef UseDefault As Boolean)
    Public Event OnGridPrint(ByRef UseDefault As Boolean)
    ' во время обработки этого события надо задать список колонок (InitGridFields)
    Public Event OnGridSetup(ByVal PartName As String)
#End Region

#Region "Properties"
    Public Property AllowTreeToolBar() As Boolean
        Get
            Return TreeViewControl.AllowToolBar
        End Get
        Set(ByVal Value As Boolean)
            TreeViewControl.AllowToolBar = Value
        End Set
    End Property

    Public Property AllowGridToolBar() As Boolean
        Get
            Return GridViewControl.AllowToolBar
        End Get
        Set(ByVal Value As Boolean)
            GridViewControl.AllowToolBar = Value
        End Set
    End Property

    Public ReadOnly Property GridView() As GridView
        Get
            Return GridViewControl
        End Get
    End Property

    Public ReadOnly Property TreeView() As TreeView
        Get
            Return TreeViewControl
        End Get
    End Property
#End Region

#Region "Sub, functions"
    Public Shadows Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal MasterPartName As String, ByVal TreeFieldName As String, ByVal MasterControlCaption As String, ByVal ChildControlCaption As String)
        mRootPartName = MasterPartName
        TreeViewControl.Attach(gm, MasterPartName, TreeFieldName, MasterControlCaption)
        ' GridView.Attach(gm, ChildPartName, ChildControlCaption)
        RaiseEvent OnTreeGetLevelData(System.Guid.Empty, MasterPartName, "")
    End Sub


    Public Overloads Sub TreeLoadData(ByVal ID As System.Guid, ByVal PartName As String, ByVal FieldName As String, ByVal dt As DataTable)
        Dim i As Integer
        Dim rootnode As TreeNode
        Dim node As TreeNode
        Dim prevID As Guid = Guid.Empty

        If Not TreeView.SelectedNode Is Nothing Then
            If (TypeOf (TreeView.tv.SelectedNode.Tag) Is System.Guid) Then
                prevID = TreeView.tv.SelectedNode.Tag
            End If
        End If


        GridViewControl.ClearCell()
        Dim nodeChild As TreeNode
        If ID.Equals(System.Guid.Empty) Then
            TreeViewControl.tv.Nodes.Clear()
            For i = 0 To dt.Rows.Count - 1
                node = TreeViewControl.tv.Nodes.Add(dt.Rows(i).Item(FieldName))
                node.Tag = dt.Rows(i).Item("ID")
                nodeChild = node.Nodes.Add(Constants.MSG_WAIT)
                nodeChild.Tag = Nothing
            Next
            RaiseEvent OnGridSetup(PartName)
            ' dt.TableName = PartName
            SetGridData(dt)
        Else
            rootnode = TreeViewControl.FindNode(TreeViewControl.tv.Nodes, ID)
            Dim j As Integer
            Dim s As String
            For j = 0 To rootnode.Nodes.Count - 1
                On Error Resume Next
                s = rootnode.Nodes.Item(j).Tag
                If s.ToUpper = PartName.ToUpper Then
                    rootnode.Nodes.Item(j).Nodes.Clear()
                    For i = 0 To dt.Rows.Count - 1
                        node = rootnode.Nodes.Item(j).Nodes.Add(dt.Rows(i).Item(FieldName))
                        node.Tag = dt.Rows(i).Item(Constants.FIELD_ID)
                        nodeChild = node.Nodes.Add(Constants.MSG_WAIT)
                        nodeChild.Tag = Nothing
                    Next
                    RaiseEvent OnGridSetup(PartName)
                    ' dt.TableName = PartName
                    SetGridData(dt)
                End If
            Next
        End If

        If Not prevID.Equals(Guid.Empty) Then
            SyncTreeTo(prevID)
        End If


    End Sub

    Public Sub SetGridData(ByVal dt As Data.DataTable)
        On Error Resume Next

        GridViewControl.ClearCell()
        mGridPartName = dt.TableName
        GridViewControl.SetData(dt, True)

        'GridViewControl.gr.Refresh()
    End Sub

    Public Sub LoadItemParts(ByVal ID As System.Guid, ByVal dt As DataTable)
        Dim i As Integer
        Dim rootnode As TreeNode
        Dim node As TreeNode
        GridViewControl.ClearCell()
        Dim nodeChild As TreeNode
        If ID.Equals(System.Guid.Empty) Then
            ' у рута не может быть разделов
            Exit Sub
        Else
            rootnode = TreeViewControl.FindNode(TreeViewControl.tv.Nodes, ID)
            If (Not rootnode Is Nothing) Then
                rootnode.Nodes.Clear()
                For i = 0 To dt.Rows.Count - 1
                    node = rootnode.Nodes.Add(dt.Rows(i).Item(Constants.FIELD_CAPTION))
                    node.Tag = dt.Rows(i).Item(Constants.FIELD_NAME)
                    node.ImageIndex = 1
                    node.SelectedImageIndex = 1
                    nodeChild = node.Nodes.Add(Constants.MSG_WAIT)
                    nodeChild.Tag = Nothing
                Next
            End If
        End If
    End Sub


    Public Sub RefreshData()
        RaiseEvent OnTreeGetLevelData(System.Guid.Empty, String.Empty, mRootPartName)
    End Sub


    Private Sub SyncGridTo(ByVal id As System.Guid)
        Dim dt As DataTable, i As Integer
        dt = GridView.gr.DataSource
        For i = 0 To dt.DefaultView.Count - 1
            If id.Equals(dt.DefaultView.Item(i).Item(Constants.FIELD_ID)) Then
                GridView.gr.ClearSelection()
                GridView.gr.Rows(i).Selected = True
                GridView.gr.FirstDisplayedScrollingRowIndex = i
                Exit For
            End If
        Next
    End Sub

    Private Sub SyncTreeTo(ByVal id As System.Guid)
        Dim n As TreeNode
        n = TreeViewControl.FindNode(TreeViewControl.tv.Nodes, id)
        If Not n Is Nothing Then
            TreeView.tv.SelectedNode = n
        End If
    End Sub
#End Region

#Region "Tree events"


    Private Sub TreeViewControl_OnTreeAfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs, ByRef UseDefault As Boolean) Handles TreeViewControl.OnTreeAfterSelect
        Dim n As TreeNode
        Dim needPart As String
        Dim parentPart As String
        Dim ParentID As System.Guid

        UseDefault = False

        If IgnoreSelect Then Exit Sub

        Dim oldC As Cursor
        oldC = Cursor
        Cursor = Cursors.WaitCursor
        GridViewControl.ClearCell()
        n = e.Node
        If (TypeOf (n.Tag) Is System.Guid) Then
            If n.Parent Is Nothing Then
                ParentID = System.Guid.Empty
                parentPart = String.Empty
                needPart = mRootPartName
                RaiseEvent OnGridSetup(needPart)
                RaiseEvent OnGridRefresh(ParentID, parentPart, needPart)
                SyncGridTo(n.Tag)
            Else
                ParentID = n.Parent.Parent.Tag
                If n.Parent.Parent.Parent Is Nothing Then
                    parentPart = mRootPartName
                Else
                    parentPart = n.Parent.Parent.Parent.Tag
                End If
                needPart = n.Parent.Tag
                RaiseEvent OnGridSetup(needPart)
                RaiseEvent OnGridRefresh(ParentID, parentPart, needPart)
                SyncGridTo(n.Tag)
            End If
        End If
        If (TypeOf (n.Tag) Is System.String) Then
            ParentID = n.Parent.Tag
            If n.Parent.Parent Is Nothing Then
                parentPart = mRootPartName
            Else
                parentPart = n.Parent.Parent.Tag
            End If
            needPart = n.Tag
            RaiseEvent OnGridSetup(needPart)
            RaiseEvent OnGridRefresh(ParentID, parentPart, needPart)
        End If
        Cursor = oldC
    End Sub

    Private Sub TreeViewControl_OnTreeBeforeExpand(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs, ByRef UseDefault As Boolean) Handles TreeViewControl.OnTreeBeforeExpand
        Dim nn As TreeNode
        Dim id As Guid

        UseDefault = False

        nn = e.Node
        If nn.Tag Is Nothing Then Exit Sub
        If nn.Nodes.Count = 1 And nn.Nodes.Item(0).Tag Is Nothing Then
            If (TypeOf (nn.Tag) Is System.Guid) Then
                id = nn.Tag
                nn.Nodes.Clear()
                If nn.Parent Is Nothing Then
                    RaiseEvent OnTreeGetItemParts(id, mRootPartName)
                Else
                    RaiseEvent OnTreeGetItemParts(id, nn.Parent.Tag)
                End If
            End If
            If TypeOf (nn.Tag) Is System.String Then
                nn.Nodes.Clear()
                If nn.Parent Is Nothing Then
                    Exit Sub
                Else
                    If nn.Parent.Parent Is Nothing Then
                        id = nn.Parent.Tag
                        RaiseEvent OnTreeGetLevelData(id, mRootPartName, nn.Tag)
                    Else
                        id = nn.Parent.Tag
                        RaiseEvent OnTreeGetLevelData(id, nn.Parent.Parent.Tag, nn.Tag)
                    End If
                End If
            End If
        End If
    End Sub
#End Region

#Region "Buttons events"
    Private Sub ButtonsControl_OnAdd() Handles ButtonsControl.OnAdd
        Dim n As TreeNode
        Dim needPart As String
        Dim parentPart As String
        Dim ParentID As System.Guid
        Dim OK As Boolean

        n = TreeViewControl.tv.SelectedNode
        If n Is Nothing Then Exit Sub
        If (TypeOf (n.Tag) Is System.Guid) Then
            If n.Parent Is Nothing Then
                ParentID = System.Guid.Empty
                parentPart = String.Empty
                needPart = mRootPartName
                RaiseEvent OnTreeAddRoot(OK)
            Else
                ParentID = n.Parent.Parent.Tag
                If n.Parent.Parent.Parent Is Nothing Then
                    parentPart = mRootPartName
                Else
                    parentPart = n.Parent.Parent.Parent.Tag
                End If
                needPart = n.Parent.Tag
                RaiseEvent OnTreeAdd(OK, ParentID, parentPart, needPart)
            End If
        End If
        If (TypeOf (n.Tag) Is System.String) Then
            ParentID = n.Parent.Tag
            If n.Parent.Parent Is Nothing Then
                parentPart = mRootPartName
            Else
                parentPart = n.Parent.Parent.Tag
            End If
            needPart = n.Tag
            RaiseEvent OnTreeAdd(OK, ParentID, parentPart, needPart)
        End If
    End Sub

    Private Sub ButtonsControl_OnEdit() Handles ButtonsControl.OnEdit
        Dim dt As DataTable
        dt = GridViewControl.gr.DataSource
        If dt.Rows.Count = 0 Then Exit Sub
        Dim OK As Boolean
        If Not GridViewControl.gr.CurrentCell Is Nothing Then
            RaiseEvent OnTreeEdit(OK, dt.DefaultView.Item(GridViewControl.gr.CurrentCell.RowIndex).Item(Constants.FIELD_ID), mGridPartName)
            If OK Then
                '...
            End If
        Else
            If GridViewControl.gr.SelectedRows.Count > 0 Then
                RaiseEvent OnTreeEdit(OK, dt.DefaultView.Item(GridViewControl.gr.SelectedRows.Item(0).Index).Item(Constants.FIELD_ID), mGridPartName)
                If OK Then
                    '...
                End If
            End If
        End If
    End Sub


    Private Sub ButtonsControl_OnDel() Handles ButtonsControl.OnDel
        Dim dt As DataTable
        dt = GridViewControl.gr.DataSource
        If dt.Rows.Count = 0 Then Exit Sub
        Dim OK As Boolean
        RaiseEvent OnTreeDel(OK, dt.DefaultView.Item(GridViewControl.gr.CurrentCell.RowIndex).Item(Constants.FIELD_ID), mGridPartName)
        If OK Then
            '...
        End If
    End Sub


    Private Sub ButtonsControl_OnRefresh() Handles ButtonsControl.OnRefresh
        RaiseEvent OnTreeGetLevelData(System.Guid.Empty, String.Empty, mRootPartName)
    End Sub
#End Region


    Private Sub GridViewControl_OnGridAdd(ByRef OK As Boolean, ByVal ID As System.Guid) Handles GridViewControl.OnGridAdd
        RaiseEvent OnGridAdd(OK, ID)
        If OK = False Then 
        	ButtonsControl_OnAdd()
        End If
    End Sub


    Private Sub GridViewControl_OnGridDel(ByRef OK As Boolean, ByVal ID As System.Guid) Handles GridViewControl.OnGridDel
        RaiseEvent OnGridDel(OK, ID)
        If OK = False Then 
        	ButtonsControl_OnDel()
        End If
    End Sub

    Private Sub GridViewControl_OnGridEdit(ByRef OK As Boolean, ByVal ID As System.Guid) Handles GridViewControl.OnGridEdit
        RaiseEvent OnGridEdit(OK, ID)
        If OK = False Then 
        	ButtonsControl_OnEdit()
        End If
    End Sub

    Private Sub GridViewControl_OnGridFind(ByVal UseDefault As Boolean) Handles GridViewControl.OnGridFind
        RaiseEvent OnGridFind(UseDefault)
    End Sub

    Private Sub GridViewControl_OnGridPrint(ByRef OK As Boolean, ByRef UseDefault As Boolean) Handles GridViewControl.OnGridPrint
        RaiseEvent OnGridPrint(UseDefault)
    End Sub

    Private Sub GridViewControl_OnGridProp(ByRef OK As Boolean, ByRef UseDefault As Boolean) Handles GridViewControl.OnGridProp
        RaiseEvent OnGridProp(OK, UseDefault)
        If OK = False Then 
        	ButtonsControl_OnEdit()
        End If
    End Sub

    Private Sub GridViewControl_OnGridRefresh() Handles GridViewControl.OnGridRefresh
        RaiseEvent OnGridSetup(mRootPartName)
        RaiseEvent OnGridRefresh(System.Guid.Empty, String.Empty, mRootPartName)
        ButtonsControl_OnRefresh()
    End Sub

    Private Sub GridViewControl_OnGridRun(ByRef OK As Boolean, ByVal ID As System.Guid, ByRef UseDefault As Boolean) Handles GridViewControl.OnGridRun
        RaiseEvent OnGridRun(OK, ID, UseDefault)
        If OK = False Then 
        	ButtonsControl_OnEdit()
        End If
    End Sub

   
End Class
