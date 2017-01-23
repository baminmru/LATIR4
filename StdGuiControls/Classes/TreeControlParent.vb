Imports LATIR2GuiManager
Imports LATIR2GUIControls

Public Class TreeControlParent
    Inherits CommonControlParent
    Implements ITreeControlInterface

    Protected mTreeFieldName As String
    Private mLabelCaption As Label
    Private mLabelPanel As Panel
    ' Public IsComplex As Boolean
    Private IgnoreSelect As Boolean


#Region "Events implementation"
    Public Event OnTreeAddRoot(ByRef OK As Boolean) Implements ITreeControlInterface.OnTreeAddRoot
    Public Event OnTreeAdd(ByRef OK As Boolean, ByVal ParentID As System.Guid) Implements ITreeControlInterface.OnTreeAdd
    Public Event OnTreeEdit(ByRef OK As Boolean, ByVal ID As System.Guid) Implements ITreeControlInterface.OnTreeEdit
    Public Event OnTreeDel(ByRef OK As Boolean, ByVal ID As System.Guid) Implements ITreeControlInterface.OnTreeDel
    Public Event OnTreeRun(ByRef OK As Boolean, ByVal ID As System.Guid, ByRef UseDefault As Boolean) Implements ITreeControlInterface.OnTreeRun
    Public Event OnTreePrint(ByRef OK As Boolean, ByRef UseDefault As Boolean) Implements ITreeControlInterface.OnTreePrint
    Public Event OnTreeProp(ByRef OK As Boolean, ByRef UseDefault As Boolean) Implements ITreeControlInterface.OnTreeProp
    Public Event OnTreeRefresh(ByRef OK As Boolean) Implements ITreeControlInterface.OnTreeRefresh
    Public Event OnTreeFind(ByRef OK As Boolean, ByRef UseDefault As Boolean) Implements ITreeControlInterface.OnTreeFind

    Public Event OnTreeGetData(ByVal Parent As System.Guid) Implements ITreeControlInterface.OnTreeGetData
    Public Event OnTreeSelect(ID As Guid) Implements ITreeControlInterface.OnTreeSelect


#End Region



#Region "Common data functions"

    Public Overloads Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal partName As String, ByVal TreeFieldName As String, ByVal ControlCaption As String)
        MyBase.Attach(gm, partName, ControlCaption, String.Empty)
        mTreeFieldName = TreeFieldName
        RaiseEvent OnTreeGetData(System.Guid.Empty)
    End Sub


    Public Sub RefreshData()
        RaiseEvent OnTreeGetData(System.Guid.Empty)
    End Sub

    Public Overridable Sub LoadLevelData(ByVal ID As System.Guid, ByVal dt As DataTable, ByRef tv As System.Windows.Forms.TreeView)
        Dim i As Integer
        Dim rootnode As TreeNode
        Dim node As TreeNode
        Dim nodeChild As TreeNode


        ' denisk begin 
        ' Checking pars
        If (dt Is Nothing) Then
            Return
        End If
        If (Not dt.Columns.Contains(Constants.FIELD_ID)) Then
            Return
        End If
        If (Not dt.Columns.Contains(mTreeFieldName)) Then
            Return
        End If
        ' denisk end

        If ID.Equals(System.Guid.Empty) Then
            tv.Nodes.Clear()
            For i = 0 To dt.Rows.Count - 1
                node = tv.Nodes.Add(dt.Rows(i).Item(mTreeFieldName))
                node.Tag = dt.Rows(i).Item(Constants.FIELD_ID)
                nodeChild = node.Nodes.Add(Constants.MSG_WAIT)
                nodeChild.Tag = Nothing
            Next
            tv.Sort()
        Else
            rootnode = FindNode(tv.Nodes, ID)
            rootnode.Nodes.Clear()
            For i = 0 To dt.Rows.Count - 1
                node = rootnode.Nodes.Add(dt.Rows(i).Item(mTreeFieldName))
                node.Tag = dt.Rows(i).Item(Constants.FIELD_ID)
                nodeChild = node.Nodes.Add(Constants.MSG_WAIT)
                nodeChild.Tag = Nothing
            Next
            tv.Sort()
        End If
    End Sub

#End Region

#Region "Tree functions "

    Protected Sub TreeSelect(ByVal e As System.Windows.Forms.TreeViewEventArgs)
        Dim id As Guid
        If (TypeOf (e.Node.Tag) Is System.Guid) Then
            id = e.Node.Tag
            RaiseEvent OnTreeSelect(id)
        End If

    End Sub


    Protected Sub BeforeExpand(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs)
        Dim CheckNode As TreeNode
        Dim id As Guid
        CheckNode = e.Node
        If CheckNode.Nodes.Count > 0 And CheckNode.Nodes.Item(0).Tag Is Nothing Then
            CheckNode.Nodes.Clear()
            If (TypeOf (CheckNode.Tag) Is System.Guid) Then
                id = CheckNode.Tag
                RaiseEvent OnTreeGetData(id)
            End If
        End If
    End Sub


    Protected Function TreeRefresh() As Boolean
        Dim OK As Boolean
        Try
            RaiseEvent OnTreeGetData(System.Guid.Empty)
        Catch
            OK = False
        End Try
        Return OK
    End Function

    Protected Function TreeFind(ByRef tv As System.Windows.Forms.TreeView) As Boolean
        Dim OK As Boolean
        OK = True
        Dim UseDefault As Boolean
        UseDefault = True
        RaiseEvent OnTreeFind(OK, UseDefault)
        If UseDefault Then
            Dim f As frmFind
            Dim n As TreeNode
            f = New frmFind
            f.ShowDialog()
            If f.DialogResult = DialogResult.OK Then
                Dim SearchString As String
                SearchString = f.txtFind.Text.Trim
                If SearchString <> String.Empty Then
                    n = FindNodeByName(tv.Nodes, SearchString)
                    If Not n Is Nothing Then
                        tv.SelectedNode = n
                        tv.Focus()
                        f = Nothing
                        Return True
                    Else
                        f = Nothing
                        Return False
                    End If
                End If
            End If
            f = Nothing
        End If
        Return False
    End Function

    Protected Function TreeRun(ByRef tv As System.Windows.Forms.TreeView) As Boolean
        If Not tv.SelectedNode Is Nothing Then
            Dim UseDefault As Boolean
            UseDefault = True
            Dim OK As Boolean
            OK = True
            RaiseEvent OnTreeRun(OK, tv.SelectedNode.Tag, UseDefault)
            If (UseDefault) Then
                TreeEdit(tv)
            End If
        End If
    End Function

    Protected Function TreePrint(ByRef tv As System.Windows.Forms.TreeView) As Boolean
        If Not tv.SelectedNode Is Nothing Then
            Dim UseDefault As Boolean
            UseDefault = True
            Dim OK As Boolean
            OK = False
            RaiseEvent OnTreePrint(OK, UseDefault)
            If (UseDefault) Then
                ' Реакция по умолчанию.
            End If
        End If
    End Function


    Protected Function TreeAdd(ByRef tv As System.Windows.Forms.TreeView) As Boolean
        If Not tv.SelectedNode Is Nothing Then
            Dim OK As Boolean
            RaiseEvent OnTreeAdd(OK, tv.SelectedNode.Tag)
            Return OK
        End If
    End Function


    Protected Function TreeAddRoot() As Boolean
        Dim OK As Boolean
        RaiseEvent OnTreeAddRoot(OK)
        Return OK
    End Function

    Protected Function TreeEdit(ByRef tv As System.Windows.Forms.TreeView) As Boolean
        If Not tv.SelectedNode Is Nothing Then
            Dim OK As Boolean
            RaiseEvent OnTreeEdit(OK, tv.SelectedNode.Tag)
            Return OK
        End If
    End Function

    Protected Function TreeDel(ByRef tv As System.Windows.Forms.TreeView) As Boolean
        If Not tv.SelectedNode Is Nothing Then
            Dim OK As Boolean
            RaiseEvent OnTreeDel(OK, tv.SelectedNode.Tag)
            Return OK
        End If
    End Function

    Protected Function TreeProp(ByRef tv As System.Windows.Forms.TreeView) As Boolean
        Dim OK As Boolean
        Dim UseDefault As Boolean
        UseDefault = True
        RaiseEvent OnTreeProp(OK, UseDefault)
        If (UseDefault) Then
            ' ...
        End If
        Return OK
    End Function
#End Region

#Region "Find functions"
    Protected Function FindNode(ByVal root As TreeNodeCollection, ByVal ID As System.Guid) As TreeNode
        Dim CheckNode As TreeNode
        Dim i As Integer
        Dim Result As TreeNode
        Dim CheckGuid As System.Guid

        For i = 0 To root.Count - 1
            CheckNode = root(i)
            If Not CheckNode.Tag Is Nothing Then
                If (TypeOf (CheckNode.Tag) Is System.Guid) Then
                    CheckGuid = CheckNode.Tag
                    If CheckGuid.Equals(ID) Then
                        Result = CheckNode
                        Return Result
                    End If
                End If
            End If
            'If Not CheckNode.IsExpanded Then
            '    CheckNode.Expand()
            '    CheckNode.Collapse()
            'End If
            Result = FindNode(CheckNode.Nodes, ID)
            If Not Result Is Nothing Then
                Return Result
            End If
        Next
        Return Nothing
    End Function


    Protected Function FindNodeByName(ByVal root As TreeNodeCollection, ByVal Name As String) As TreeNode
        Dim CheckNode As TreeNode
        Dim i As Integer
        Dim result As TreeNode

        For i = 0 To root.Count - 1
            CheckNode = root(i)
            If Not CheckNode.Tag Is Nothing Then
                If CheckNode.Text.ToLower() = Name.ToLower() Then
                    result = CheckNode
                    Return result
                End If
            End If
            If Not CheckNode.IsExpanded Then
                CheckNode.Expand()
                CheckNode.Collapse()
            End If
            result = FindNodeByName(CheckNode.Nodes, Name)
            If Not result Is Nothing Then
                Return result
            End If
        Next
        Return Nothing
    End Function
#End Region

End Class
