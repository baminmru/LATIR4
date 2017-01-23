Imports Infragistics.Win
Imports Infragistics.Win.UltraWinTree
Imports Infragistics.Win.UltraWinGrid


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
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents TreeViewControl As LATIR2GUIControls.TreeView
    Friend WithEvents GridViewControl As LATIR2GUIControls.GridView
    Friend WithEvents XL As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents SFD As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ButtonsControl As LATIR2GUIControls.Buttons
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.TreeImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ButtonsControl = New LATIR2GUIControls.Buttons
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.TreeViewControl = New LATIR2GUIControls.TreeView
        Me.GridViewControl = New LATIR2GUIControls.GridView
        Me.XL = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.SFD = New System.Windows.Forms.SaveFileDialog
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
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
        Me.ButtonsControl.AllowAdd = True
        Me.ButtonsControl.AllowAddRoot = False
        Me.ButtonsControl.AllowDel = True
        Me.ButtonsControl.AllowEdit = True
        Me.ButtonsControl.AllowExport = True
        Me.ButtonsControl.AllowFind = True
        Me.ButtonsControl.AllowPrint = True
        Me.ButtonsControl.AllowProp = True
        Me.ButtonsControl.AllowRefresh = True
        Me.ButtonsControl.AllowRun = True
        Me.ButtonsControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonsControl.Location = New System.Drawing.Point(0, 0)
        Me.ButtonsControl.Name = "ButtonsControl"
        Me.ButtonsControl.Size = New System.Drawing.Size(848, 32)
        Me.ButtonsControl.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.SplitContainer1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 32)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(848, 664)
        Me.Panel2.TabIndex = 1
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TreeViewControl)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.GridViewControl)
        Me.SplitContainer1.Size = New System.Drawing.Size(848, 664)
        Me.SplitContainer1.SplitterDistance = 282
        Me.SplitContainer1.TabIndex = 0
        '
        'TreeViewControl
        '
        Me.TreeViewControl.AllowMenu = False
        Me.TreeViewControl.AllowToolBar = False
        Me.TreeViewControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TreeViewControl.Caption = ""
        Me.TreeViewControl.Location = New System.Drawing.Point(0, 0)
        Me.TreeViewControl.Name = "TreeViewControl"
        Me.TreeViewControl.Size = New System.Drawing.Size(282, 664)
        Me.TreeViewControl.TabIndex = 5
        '
        'GridViewControl
        '
        Me.GridViewControl.AllowToolBar = False
        Me.GridViewControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridViewControl.Caption = ""
        Me.GridViewControl.LabelCaption = Nothing
        Me.GridViewControl.Location = New System.Drawing.Point(0, 0)
        Me.GridViewControl.Name = "GridViewControl"
        Me.GridViewControl.Size = New System.Drawing.Size(562, 664)
        Me.GridViewControl.TabIndex = 7
        '
        'SFD
        '
        Me.SFD.DefaultExt = "xls"
        Me.SFD.Title = "Файл для экспорта"
        '
        'ComplexTreeView
        '
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "ComplexTreeView"
        Me.Size = New System.Drawing.Size(848, 696)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

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
        Dim rootnode As UltraTreeNode
        Dim node As UltraTreeNode

        GridViewControl.ClearCell()
        Dim nodeChild As UltraTreeNode
        If ID.Equals(System.Guid.Empty) Then

            If Not TreeViewControl.tv.ActiveNode Is Nothing Then
                Try
                    ParentID = TreeViewControl.tv.ActiveNode.Tag
                Catch ex As Exception
                    ParentID = Guid.Empty
                End Try

            End If

            TreeViewControl.tv.Nodes.Clear()

            For i = 0 To dt.Rows.Count - 1
                Try
                    node = TreeViewControl.tv.Nodes.Add()

                    node.Text = dt.Rows(i).Item(FieldName).ToString()
                    node.Tag = dt.Rows(i).Item("ID")
                    nodeChild = node.Nodes.Add()
                    nodeChild.Text = Constants.MSG_WAIT
                    nodeChild.Tag = Nothing
                Catch
                    MsgBox(Err.Description)
                End Try
            Next
            If Not ParentID.Equals(Guid.Empty) Then
                SyncTreeTo(ParentID)
                If Not TreeView.tv.ActiveNode Is Nothing Then
                    TreeView.tv.ActiveNode.Selected = True
                End If

            End If
            RaiseEvent OnGridSetup(PartName)
            SetGridData(dt)
            If Not ParentID.Equals(Guid.Empty) Then
                SyncGridTo(ParentID)
            End If
        Else
            rootnode = TreeViewControl.FindNode(TreeViewControl.tv.Nodes, ID)
            Dim j As Integer
            Dim s As String
            For j = 0 To rootnode.Nodes.Count - 1
                s = rootnode.Nodes.Item(j).Tag.ToString()
                If s.ToUpper = PartName.ToUpper Then
                    rootnode.Nodes.Item(j).Nodes.Clear()
                    For i = 0 To dt.Rows.Count - 1
                        Try
                            node = rootnode.Nodes.Item(j).Nodes.Add()
                            node.Text = dt.Rows(i).Item(FieldName).ToString()
                            node.Tag = dt.Rows(i).Item(Constants.FIELD_ID)
                            nodeChild = node.Nodes.Add()
                            nodeChild.Text = Constants.MSG_WAIT
                            nodeChild.Tag = Nothing
                        Catch
                            MsgBox(Err.Description)
                        End Try
                    Next
                    RaiseEvent OnGridSetup(PartName)
                    SetGridData(dt)
                End If
            Next
        End If
    End Sub

    Public Sub SetGridData(ByVal dt As Data.DataTable)
        On Error Resume Next
        GridViewControl.ClearCell()
        GridViewControl.SetData(dt, False)
        mGridPartName = dt.TableName
    End Sub

    Public Sub LoadItemParts(ByVal ID As System.Guid, ByVal dt As DataTable)
        Dim i As Integer
        Dim rootnode As UltraTreeNode
        Dim node As UltraTreeNode
        GridViewControl.ClearCell()
        Dim nodeChild As UltraTreeNode
        If ID.Equals(System.Guid.Empty) Then
            ' у рута не может быть разделов
            Exit Sub
        Else
            rootnode = TreeViewControl.FindNode(TreeViewControl.tv.Nodes, ID)
            If (Not rootnode Is Nothing) Then
                rootnode.Nodes.Clear()
                For i = 0 To dt.Rows.Count - 1
                    node = rootnode.Nodes.Add()
                    node.Text = dt.Rows(i).Item(Constants.FIELD_CAPTION)
                    node.Tag = dt.Rows(i).Item(Constants.FIELD_NAME)
                    nodeChild = node.Nodes.Add()
                    nodeChild.Text = Constants.MSG_WAIT
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


        For i = 0 To GridView.gr.Rows.Count - 1
            If GridView.gr.Rows.Item(i).IsDataRow Then
                If id.Equals(New Guid(GridView.gr.Rows(i).Cells(Constants.FIELD_ID).Value.ToString())) Then
                    GridView.gr.ActiveRow = GridView.gr.Rows.Item(i)
                    Exit For
                End If
            End If
        Next
    End Sub

    Private Sub SyncTreeTo(ByVal id As System.Guid)
        Dim n As UltraWinTree.UltraTreeNode
        n = TreeViewControl.FindNode(TreeViewControl.tv.Nodes, id)
        If Not n Is Nothing Then
            TreeView.tv.ActiveNode = n

        End If
    End Sub
#End Region

#Region "Tree events"


    Private needPart As String
    Private parentPart As String
    Private ParentID As System.Guid

    Private Sub TreeViewControl_OnTreeAfterSelect(ByVal sender As Object, ByVal Node As Object, ByRef UseDefault As Boolean) Handles TreeViewControl.OnTreeAfterSelect
        Dim n As UltraTreeNode
        'Dim needPart As String
        'Dim parentPart As String
        'Dim ParentID As System.Guid

        UseDefault = False

        If IgnoreSelect Then Exit Sub

        Dim oldC As Cursor
        oldC = Cursor
        Cursor = Cursors.WaitCursor
        GridViewControl.ClearCell()
        n = Node
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

    Private Sub TreeViewControl_OnTreeBeforeExpand(ByVal sender As Object, ByVal Node As Object, ByRef UseDefault As Boolean) Handles TreeViewControl.OnTreeBeforeExpand
        Dim nn As UltraTreeNode
        Dim id As Guid

        UseDefault = False

        nn = Node
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
        Dim n As UltraTreeNode
        Dim needPart As String
        Dim parentPart As String
        Dim ParentID As System.Guid
        Dim OK As Boolean

        n = TreeViewControl.tv.ActiveNode
        If n Is Nothing Then
            ParentID = System.Guid.Empty
            parentPart = String.Empty
            needPart = mRootPartName
            RaiseEvent OnTreeAddRoot(OK)
            Exit Sub
        End If

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
        Dim OK As Boolean = False
        Try
            RaiseEvent OnTreeEdit(OK, New Guid(GridViewControl.gr.ActiveRow.Cells(Constants.FIELD_ID).Value.ToString()), mGridPartName)
            'If Not OK Then
            '    GridViewControl.GVGridEdit()
            'End If
        Catch
        End Try
    End Sub


    Private Sub ButtonsControl_OnDel() Handles ButtonsControl.OnDel
        Dim dt As DataTable
        dt = GridViewControl.gr.DataSource
        If dt.Rows.Count = 0 Then Exit Sub
        Dim OK As Boolean = False
        RaiseEvent OnTreeDel(OK, New Guid(GridViewControl.gr.ActiveRow.Cells(Constants.FIELD_ID).Value.ToString()), mGridPartName)
        'If Not OK Then
        '    GridViewControl.GVGridDel(New Guid(GridViewControl.gr.ActiveRow.Cells(Constants.FIELD_ID).Value.ToString()))
        'End If
    End Sub


    Private Sub ButtonsControl_OnRefresh() Handles ButtonsControl.OnRefresh
        RaiseEvent OnTreeGetLevelData(System.Guid.Empty, String.Empty, mRootPartName)
    End Sub

#End Region


    Private Sub GridViewControl_OnGridAdd(ByRef OK As Boolean, ByVal ID As System.Guid) Handles GridViewControl.OnGridAdd
        RaiseEvent OnGridAdd(OK, ID)
        If OK = False Then
            ButtonsControl_OnAdd()
            Try
                SyncTreeTo(ParentID)
            Catch ex As Exception

            End Try
            Try
                RaiseEvent OnGridSetup(needPart)
            Catch ex As Exception

            End Try
            Try
                RaiseEvent OnGridRefresh(ParentID, parentPart, needPart)
            Catch ex As Exception

            End Try
            Try
                SyncGridTo(ID)
            Catch ex As Exception

            End Try
        End If

       
    End Sub


    Private Sub GridViewControl_OnGridDel(ByRef OK As Boolean, ByVal ID As System.Guid) Handles GridViewControl.OnGridDel
        RaiseEvent OnGridDel(OK, ID)
        If OK = False Then
            ButtonsControl_OnDel()
            Try
                SyncTreeTo(ParentID)
            Catch ex As Exception

            End Try

            Try
                RaiseEvent OnGridSetup(needPart)
            Catch ex As Exception

            End Try
            Try
                RaiseEvent OnGridRefresh(ParentID, parentPart, needPart)
            Catch ex As Exception

            End Try
        End If

    End Sub

    Private Sub GridViewControl_OnGridEdit(ByRef OK As Boolean, ByVal ID As System.Guid) Handles GridViewControl.OnGridEdit
        RaiseEvent OnGridEdit(OK, ID)
        If OK = False Then
            ButtonsControl_OnEdit()

            Try
                SyncTreeTo(ParentID)
            Catch ex As Exception

            End Try

            Try
                RaiseEvent OnGridSetup(needPart)
            Catch ex As Exception

            End Try
            Try
                RaiseEvent OnGridRefresh(ParentID, parentPart, needPart)
            Catch ex As Exception

            End Try
            Try
                SyncGridTo(ID)
            Catch ex As Exception

            End Try
        End If
      

    End Sub

    Private Sub GridViewControl_OnGridFind(ByVal UseDefault As Boolean) Handles GridViewControl.OnGridFind
        RaiseEvent OnGridFind(UseDefault)
        'If UseDefault Then

        'End If
    End Sub

    Private Sub GridViewControl_OnGridPrint(ByRef OK As Boolean, ByRef UseDefault As Boolean) Handles GridViewControl.OnGridPrint
        RaiseEvent OnGridPrint(UseDefault)
    End Sub

    Private Sub GridViewControl_OnGridProp(ByRef OK As Boolean, ByRef UseDefault As Boolean) Handles GridViewControl.OnGridProp
        RaiseEvent OnGridProp(OK, UseDefault)
        'If OK = False Then
        '    ButtonsControl_OnEdit()
        'End If
    End Sub

    Private Sub GridViewControl_OnGridRefresh() Handles GridViewControl.OnGridRefresh
        RaiseEvent OnGridSetup(mRootPartName)
        RaiseEvent OnGridRefresh(System.Guid.Empty, String.Empty, mRootPartName)
        ButtonsControl_OnRefresh()
    End Sub

    Private Sub GridViewControl_OnGridRun(ByRef OK As Boolean, ByVal ID As System.Guid, ByRef UseDefault As Boolean) Handles GridViewControl.OnGridRun
        RaiseEvent OnGridRun(OK, ID, UseDefault)
        'If UseDefault Then
        '    If OK = False Then
        '        ButtonsControl_OnEdit()
        '    End If
        'End If
    End Sub


    Private Sub ButtonsControl_OnPrint() Handles ButtonsControl.OnPrint
        GridViewControl.GVGridPrint()
    End Sub

    Private Sub ButtonsControl_OnFind() Handles ButtonsControl.OnFind
        GridViewControl.GVGridFind()
    End Sub

    Private Sub ButtonsControl_OnProp() Handles ButtonsControl.OnProp
        GridViewControl.GVGridProp()
    End Sub

    Private Sub ButtonsControl_OnRun() Handles ButtonsControl.OnRun
        GridViewControl.GVGridRun()

    End Sub

    Private Sub ButtonsControl_OnExport() Handles ButtonsControl.OnExport
        If SFD.ShowDialog() = DialogResult.OK Then
            XL.Export(GridViewControl.Grid, SFD.FileName)
        End If
    End Sub

    Private Sub ButtonsControl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonsControl.Load

    End Sub

    Private Sub GridViewControl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridViewControl.Load

    End Sub

    Private Sub TreeViewControl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TreeViewControl.Load

    End Sub

    Private Sub ButtonsControl_RightToLeftChanged(sender As Object, e As System.EventArgs) Handles ButtonsControl.RightToLeftChanged

    End Sub
End Class
