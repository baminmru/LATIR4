Imports Infragistics.Win
Imports Infragistics.Win.UltraWinTree
Imports LATIR2GuiManager

Public Class TreeControlParent
    Inherits CommonControlParent
    Implements ITreeControlInterface
    Protected mTreeFieldName As String
    Private mLabelCaption As Label
    Private mLabelPanel As Panel
    ' Public IsComplex As Boolean
    Private IgnoreSelect As Boolean
    Private CurTableStyle As DataGridTableStyle


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
    Public Event OnTreeSelect(ByVal ID As System.Guid) Implements ITreeControlInterface.OnTreeSelect

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

    Public Sub InitTreeColumns(ByVal ts As DataGridTableStyle)
        CurTableStyle = ts
    End Sub

    Public Overridable Sub LoadLevelData(ByVal ID As System.Guid, ByVal dt As DataTable, ByRef tv As UltraTree)
        Dim i As Integer
        Dim j As Integer
        Dim rootnode As UltraTreeNode
        Dim node As UltraTreeNode
        Dim nodeChild As UltraTreeNode

        Dim rootColumnSet As UltraTreeColumnSet = tv.ColumnSettings.RootColumnSet
        Dim cs As DataGridColumnStyle

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

            ' Set the ViewStyle property to 'Grid'
            tv.ViewStyle = ViewStyle.OutlookExpress

            ' Add a column for each DataColumn in the dt to the RootColumnSet's
            ' Columns collection, using the DataColumn's 'ColumnName' property as the
            ' key for the corresponding UltraTreeNodeColumn.

            If Not CurTableStyle Is Nothing Then
                rootColumnSet.Columns.Clear()
                For i = 0 To CurTableStyle.GridColumnStyles.Count - 1
                    Dim column As UltraTreeNodeColumn

                    cs = CurTableStyle.GridColumnStyles.Item(i)
                    column = rootColumnSet.Columns.Add(cs.MappingName)
                    column.Key = cs.MappingName
                    column.AutoSizeMode = ColumnAutoSizeMode.None
                    column.AllowSorting = DefaultableBoolean.True
                    column.AllowMoving = Infragistics.Win.Layout.GridBagLayoutAllowMoving.AllowAll
                    column.CellWrapText = DefaultableBoolean.False
                    column.ShowSortIndicators = DefaultableBoolean.True
                    column.LayoutInfo.PreferredCellSize = New Size(150, 18)

                    If cs.MappingName = mTreeFieldName Then
                        column.CanShowExpansionIndicator = DefaultableBoolean.True
                        column.LayoutInfo.PreferredCellSize = New Size(300, 18)

                    Else
                        column.CanShowExpansionIndicator = DefaultableBoolean.False
                    End If

                    If cs.MappingName = Constants.FIELD_ID Then
                        column.Visible = False
                    End If
                    column.Text = cs.HeaderText
                    column.NullText = ""

                Next
            End If
            Dim columnSettings As UltraTreeColumnSettings = tv.ColumnSettings


            columnSettings.AutoFitColumns = AutoFitColumns.None


            columnSettings.ShowSortIndicators = DefaultableBoolean.True




            ' ''For Each dataColumn In dt.Columns
            ' ''    Dim column As UltraTreeNodeColumn = rootColumnSet.Columns.Add(dataColumn.ColumnName)
            ' ''    ' Store a reference to the underlying DataColumn in the Tag property.
            ' ''    column.Tag = dataColumn

            ' ''    ' Set AllowMoving to 'AllowAll', so that the end user
            ' ''    ' can drag the column to a different location.
            ' ''    'column.AllowMoving = GridBagLayoutAllowMoving.AllowAll

            ' ''    ' Set AllowSorting to True, so that the end user
            ' ''    ' can sort the nodes collections associated with
            ' ''    ' this column by clicking on its header.
            ' ''    column.AllowSorting = DefaultableBoolean.True

            ' ''    ' Set AutoSizeMode to 'VisibleNodes', so that the end user
            ' ''    ' can auto-size the column by double-clicking on the right
            ' ''    ' edge of its header.
            ' ''    column.AutoSizeMode = ColumnAutoSizeMode.VisibleNodes

            ' ''    ' Set CanShowExpansionIndicator to True for the string columns,
            ' ''    ' so that cells in the column can show the expansion indicator
            ' ''    ' when the ViewStyle is 'OutlookExpress'.
            ' ''    If dataColumn.ColumnName = mTreeFieldName Then
            ' ''        column.CanShowExpansionIndicator = DefaultableBoolean.True
            ' ''    Else
            ' ''        column.CanShowExpansionIndicator = DefaultableBoolean.False
            ' ''    End If

            ' ''    If dataColumn.ColumnName = Constants.FIELD_ID Then
            ' ''        column.Visible = False
            ' ''    End If

            ' ''    '' Use the column's CellAppearance to change the color of
            ' ''    '' the text displayed by the cells in the 'CompanyName' column.
            ' ''    'If column.Key = "CompanyName" Then

            ' ''    '    column.CellAppearance.BackColor = Color.LightBlue
            ' ''    '    column.CellAppearance.BackColor2 = Color.CornflowerBlue
            ' ''    '    column.CellAppearance.BackGradientStyle = GradientStyle.Horizontal
            ' ''    '    column.CellAppearance.ForeColor = Color.DarkBlue
            ' ''    'End If

            ' ''    ' Set CellWrapText to False to prevent text from
            ' ''    ' wrapping to additional lines.
            ' ''    column.CellWrapText = DefaultableBoolean.False

            ' ''    ' Set the DataType property to the DataType of the associated DataColumn
            ' ''    column.DataType = dataColumn.DataType

            ' ''    ' Use an EditorWithText embeddable editor to render the cell data
            ' ''    'column.Editor = New EditorWithText()


            ' ''    ' Assign the current culture to the FormatProvider property.
            ' ''    column.FormatProvider = System.Globalization.CultureInfo.CurrentCulture

            ' ''    ' Set the ForeColor property of the HeaderAppearance
            ' ''    column.HeaderAppearance.ForeColor = SystemColors.ControlDark

            ' ''    ' Set the NullText property to "[NULL]"
            ' ''    column.NullText = ""

            ' ''    ' Show sort indicators for all columns
            ' ''    column.ShowSortIndicators = DefaultableBoolean.True



            ' ''Next

            ' Add a node for each DataRow in the table




            For i = 0 To dt.Rows.Count - 1
                Try
                    node = tv.Nodes.Add()
                    node.Text = dt.Rows(i).Item(mTreeFieldName).ToString()
                    node.Tag = dt.Rows(i).Item(Constants.FIELD_ID)
                    nodeChild = node.Nodes.Add()
                    nodeChild.Text = Constants.MSG_WAIT
                    nodeChild.Tag = Nothing
                    If Not CurTableStyle Is Nothing Then
                        For j = 0 To CurTableStyle.GridColumnStyles.Count - 1
                            Dim column As UltraTreeNodeColumn
                            cs = CurTableStyle.GridColumnStyles.Item(j)
                            column = rootColumnSet.Columns.Item(cs.MappingName)
                            Dim val As Object = dt.Rows(i)(cs.MappingName)
                            node.SetCellValue(rootColumnSet.Columns(cs.MappingName), val)
                        Next
                    End If
                Catch
                    MsgBox(Err.Description)
                End Try
            Next
            tv.RefreshSort(tv.Nodes)
        Else
            rootnode = FindNode(tv.Nodes, ID)
            rootnode.Nodes.Clear()
            For i = 0 To dt.Rows.Count - 1
                Try
                    node = rootnode.Nodes.Add()
                    node.Text = dt.Rows(i).Item(mTreeFieldName).ToString()
                    node.Tag = dt.Rows(i).Item(Constants.FIELD_ID)
                    nodeChild = node.Nodes.Add()
                    nodeChild.Text = Constants.MSG_WAIT
                    nodeChild.Tag = Nothing
                    If Not CurTableStyle Is Nothing Then
                        For j = 0 To CurTableStyle.GridColumnStyles.Count - 1
                            Dim column As UltraTreeNodeColumn
                            cs = CurTableStyle.GridColumnStyles.Item(j)
                            column = rootColumnSet.Columns.Item(cs.MappingName)
                            Dim val As Object = dt.Rows(i)(cs.MappingName)
                            node.SetCellValue(rootColumnSet.Columns(cs.MappingName), val)
                        Next
                    End If

                Catch
                    MsgBox(Err.Description)
                End Try
            Next
            tv.RefreshSort(rootnode.Nodes, False)
        End If

    End Sub

#End Region

#Region "Tree functions "

    Protected Sub TreeSelect(ByVal Node As Object)
        RaiseEvent OnTreeSelect(Node)
    End Sub


    Protected Sub BeforeExpand(ByVal sender As Object, ByVal CheckNode As UltraTreeNode)
        Dim id As Guid
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

    Protected Function TreeFind(ByRef tv As UltraTree) As Boolean
        Dim OK As Boolean
        OK = True
        Dim UseDefault As Boolean
        UseDefault = True
        RaiseEvent OnTreeFind(OK, UseDefault)
        If UseDefault Then
            Dim f As frmFind
            Dim n As UltraTreeNode
            f = New frmFind
            f.ShowDialog()
            If f.DialogResult = DialogResult.OK Then
                Dim SearchString As String
                SearchString = f.txtFind.Text.Trim
                If SearchString <> String.Empty Then
                    n = FindNodeByName(tv.Nodes, SearchString)
                    If Not n Is Nothing Then
                        tv.ActiveNode = n
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

    Protected Function TreeRun(ByRef tv As UltraTree) As Boolean
        If Not tv.ActiveNode Is Nothing Then
            Dim UseDefault As Boolean
            UseDefault = True
            Dim OK As Boolean
            OK = True
            RaiseEvent OnTreeRun(OK, tv.ActiveNode.Tag, UseDefault)
            If (UseDefault) Then
                TreeEdit(tv)
            End If
        End If
    End Function

    Protected Function TreePrint(ByRef tv As UltraTree) As Boolean
        If Not tv.ActiveNode Is Nothing Then
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


    Protected Function TreeAdd(ByRef tv As UltraTree) As Boolean
        If Not tv.ActiveNode Is Nothing Then
            Dim OK As Boolean
            RaiseEvent OnTreeAdd(OK, tv.ActiveNode.Tag)
            Return OK
        End If
    End Function


    Protected Function TreeAddRoot() As Boolean
        Dim OK As Boolean
        RaiseEvent OnTreeAddRoot(OK)
        Return OK
    End Function

    Protected Function TreeEdit(ByRef tv As UltraTree) As Boolean
        If Not tv.ActiveNode Is Nothing Then
            Dim OK As Boolean
            RaiseEvent OnTreeEdit(OK, tv.ActiveNode.Tag)
            Return OK
        End If
    End Function

    Protected Function TreeDel(ByRef tv As UltraTree) As Boolean
        If Not tv.ActiveNode Is Nothing Then
            Dim OK As Boolean
            RaiseEvent OnTreeDel(OK, tv.ActiveNode.Tag)
            Return OK
        End If
    End Function

    Protected Function TreeProp(ByRef tv As UltraTree) As Boolean
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
    Protected Function FindNode(ByVal root As TreeNodesCollection, ByVal ID As System.Guid) As UltraTreeNode
        Dim CheckNode As UltraTreeNode
        Dim i As Integer
        Dim Result As UltraTreeNode
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


    Protected Function FindNodeByName(ByVal root As UltraWinTree.TreeNodesCollection, ByVal Name As String) As UltraTreeNode
        Dim CheckNode As UltraTreeNode
        Dim i As Integer
        Dim result As UltraTreeNode

        For i = 0 To root.Count - 1
            CheckNode = root.Item(i)
            If Not CheckNode.Tag Is Nothing Then
                If CheckNode.Text.ToLower() = Name.ToLower() Then
                    result = CheckNode
                    Return result
                End If
            End If
            If Not CheckNode.Expanded Then
                CheckNode.Expanded = True
                CheckNode.Expanded = False
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
