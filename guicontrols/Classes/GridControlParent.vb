Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports System.IO
Imports LATIR2GuiManager

Public Class GridControlParent
    Inherits CommonControlParent
    Implements IGridControlInterface

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
    End Sub

#End Region

#Region "Events implementation"
    Public Event OnGridAdd(ByRef OK As Boolean, ByVal ID As System.Guid) Implements IGridControlInterface.OnGridAdd
    Public Event OnGridRefresh() Implements IGridControlInterface.OnGridRefresh
    Public Event OnGridFind(ByVal UseDefault As Boolean) Implements IGridControlInterface.OnGridFind
    Public Event OnGridDel(ByRef OK As Boolean, ByVal ID As System.Guid) Implements IGridControlInterface.OnGridDel
    Public Event OnGridEdit(ByRef OK As Boolean, ByVal ID As System.Guid) Implements IGridControlInterface.OnGridEdit
    Public Event OnGridProp(ByRef OK As Boolean, ByRef UseDefault As Boolean) Implements IGridControlInterface.OnGridProp
    Public Event OnGridRun(ByRef OK As Boolean, ByVal ID As System.Guid, ByRef UseDefault As Boolean) Implements IGridControlInterface.OnGridRun
    Public Event OnGridPrint(ByRef OK As Boolean, ByRef UseDefault As Boolean) Implements IGridControlInterface.OnGridPrint

    Public Event OnGridGetData(ByVal ID As System.Guid) Implements IGridControlInterface.OnGridGetData
    Public Event OnGridRowColChange(ByVal ID As System.Guid) Implements IGridControlInterface.OnGridRowColChange
#End Region

#Region "Common data functions"
    Public Overloads Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal partName As String, ByVal ControlCaption As String)
        MyBase.Attach(gm, partName, ControlCaption, String.Empty)
        RaiseEvent OnGridGetData(System.Guid.Empty)
    End Sub
#End Region

    Private CurTableStyle As DataGridTableStyle



    Private Sub ApplyFields(ByRef gr As UltraGrid)
        Dim cs As DataGridColumnStyle
        Dim column As Infragistics.Win.UltraWinGrid.UltraGridColumn
        Dim i As Integer
        If gr.DisplayLayout.Bands(0).Columns.Count = 0 Then Return

        gr.DisplayLayout.Scrollbars = Scrollbars.Both
        gr.DisplayLayout.Override.WrapHeaderText = DefaultableBoolean.True
        gr.DisplayLayout.BorderStyle = UIElementBorderStyle.Solid
        gr.DisplayLayout.Override.BorderStyleRow = UIElementBorderStyle.Solid
        gr.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.Solid
        gr.DisplayLayout.Override.BorderStyleHeader = UIElementBorderStyle.Solid



        With gr.DisplayLayout.Bands(0)



            For i = 0 To .Columns.Count - 1
                .Columns.Item(i).Hidden = True
                .Columns.Item(i).ExcludeFromColumnChooser = ExcludeFromColumnChooser.True
            Next

            column = Nothing
            Try
                column = .Columns.Item("ID")
                column.ExcludeFromColumnChooser = ExcludeFromColumnChooser.True
            Catch
            End Try
            If column Is Nothing Then
                column = .Columns.Add("ID")
                column.DataType = GetType(System.Guid)
                column.Key = "ID"
                column.ExcludeFromColumnChooser = ExcludeFromColumnChooser.True

            End If

            column.Header.Caption = "ID"
            column.Hidden = True


            If (CurTableStyle Is Nothing) Then Return
            For i = 0 To CurTableStyle.GridColumnStyles.Count - 1
                cs = CurTableStyle.GridColumnStyles.Item(i)

                column = Nothing
                Try
                    column = .Columns.Item(cs.MappingName)
                Catch
                End Try


                If column Is Nothing Then
                    column = .Columns.Add(cs.MappingName)
                    column.Key = cs.MappingName
                End If

                column.Header.Caption = cs.HeaderText
                column.Hidden = False
                column.ExcludeFromColumnChooser = ExcludeFromColumnChooser.False
                'column.CellActivation = Activation.ActivateOnly
                column.CellActivation = Activation.NoEdit
            Next

        End With


    End Sub

    Public Sub InitFields(ByVal ts As DataGridTableStyle, ByRef gr As UltraGrid)

        CurTableStyle = ts
        ApplyFields(gr)
      
    End Sub

    Protected Sub ClearCell(ByRef gr As UltraGrid)
        gr.DataSource = Nothing

        'On Error Resume Next
        'Dim myGridTextBox As UltraGridTextBox
        'Dim myColumnTextColumn As UltraGridTextBoxColumn = Nothing
        'If gr.TableStyles.Contains(MyBase.PartName) Then
        '    If gr.TableStyles.Item(MyBase.PartName).GridColumnStyles.Contains(gr.CurrentCell.ColumnNumber) Then
        '        myColumnTextColumn = CType(gr.TableStyles(MyBase.PartName).GridColumnStyles(gr.CurrentCell.ColumnNumber), UltraGridTextBoxColumn)
        '    End If
        'End If
        'If Not myColumnTextColumn Is Nothing Then
        '    myGridTextBox = CType(myColumnTextColumn.TextBox, _
        '    UltraGridTextBox)
        '    If Not myGridTextBox Is Nothing Then
        '        myGridTextBox.Visible = False
        '    End If
        'End If
    End Sub


    Private Sub GetRowInfo(ByRef gr As UltraGrid, ByRef RowID As System.Guid)

        Dim UGRow As UltraGridRow
        UGRow = gr.ActiveRow()
        RowID = System.Guid.Empty
 
        Try
            If Not UGRow Is Nothing Then
                If UGRow.IsDataRow = True Then
                    RowID = New Guid(UGRow.Cells("ID").Value.ToString())
                End If
            End If
        Catch
        End Try
    End Sub

    Public Sub SetData(ByVal dt As Data.DataTable, ByRef gr As UltraGrid, Optional ByVal IsChild As Boolean = False)
        Try
            'Dim myGridTextBox As UltraGridTextBox
            'Dim myColumnTextColumn As UltraGridTextBoxColumn

            If (dt Is Nothing) Then
                Return
            End If


            Dim rid As Guid = Guid.Empty

            GetRowInfo(gr, rid)

            gr.DataSource = dt
            ApplyFields(gr)


            gr.Refresh()

            Dim lpath As String
            Try
                lpath = GetSetting("MTZ", "CONFIG", "LAYOUTS", My.Application.Info.DirectoryPath & "\Layouts\")
                If File.Exists(lpath & "\" & CurTableStyle.MappingName & ".ugl") Then
                    gr.DisplayLayout.Load(lpath & "\" & CurTableStyle.MappingName & ".ugl")
                End If
            Catch ex As SystemException
                'MsgBox(ex.Message)
            End Try

            If Not rid.Equals(Guid.Empty) Then
                FindRowByFiled(gr, "ID", rid)
            ElseIf dt.Rows.Count > 0 Then
                FindRowByFiled(gr, "ID", dt.Rows(0)("ID"))
            End If

            If (IsChild) Then
                'gr.DataSource = dt
                'gr.Refresh()
                gr.Invalidate()
            End If

            'Dim lpath As String
            'Try
            '    lpath = GetSetting("MTZ", "CONFIG", "LAYOUTS", My.Application.Info.DirectoryPath & "\Layouts\")
            '    If File.Exists(lpath & "\" & CurTableStyle.MappingName & ".ugl") Then
            '        gr.DisplayLayout.Load(lpath & "\" & CurTableStyle.MappingName & ".ugl")
            '    End If
            'Catch ex As SystemException
            '    'MsgBox(ex.Message)
            'End Try
        Catch
        End Try
    End Sub


    'Public Function FindRowByFiled(ByRef gr As UltraGrid, ByVal FieldName As String, ByVal Value As Object) As Infragistics.Win.UltraWinGrid.UltraGridRow

    '    Dim row As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing
    '    Try
    '        row = FindRowByFiledInCol(gr.DisplayLayout.Rows, FieldName, Value)
    '    Catch
    '    End Try
    '    If Not row Is Nothing Then
    '        row.Activate()
    '    End If

    '    Return row

    'End Function

    'Private Function FindRowByFiledInCol(ByVal Rows As Infragistics.Win.UltraWinGrid.RowsCollection, ByVal FieldName As String, ByVal Value As Object) As Infragistics.Win.UltraWinGrid.UltraGridRow
    '    Dim i As Integer, j As Integer
    '    Dim row As Infragistics.Win.UltraWinGrid.UltraGridRow

    '    For i = 0 To Rows.Count - 1
    '        If Rows(i).IsDataRow Then
    '            If Rows(i).Cells(FieldName).Value.Equals(Value) Then
    '                Return Rows(i)
    '            End If
    '        ElseIf Rows(i).IsGroupByRow Then
    '            Rows(i).ExpandAll()
    '            For j = 0 To Rows(i).ChildBands.Count - 1
    '                row = FindRowByFiledInCol(Rows(i).ChildBands(j).Rows, FieldName, Value)
    '                If Not row Is Nothing Then
    '                    Return row
    '                End If
    '            Next
    '        End If
    '    Next

    '    Return Nothing
    'End Function


    Private Function FindRowByFiled(ByRef gr As UltraGrid, ByVal FieldName As String, ByVal Value As Object) As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim row As Infragistics.Win.UltraWinGrid.UltraGridRow
        row = FindRowByFiledInCol(gr.DisplayLayout.Rows, FieldName, Value)
        If Not row Is Nothing Then
            row.Activate()
        End If
        Return row
    End Function

    Private Function FindRowByFiledInCol(ByVal Rows As Infragistics.Win.UltraWinGrid.RowsCollection, ByVal FieldName As String, ByVal Value As Object) As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim i As Integer, j As Integer
        Dim row As Infragistics.Win.UltraWinGrid.UltraGridRow

        For i = 0 To Rows.Count - 1
            If Rows(i).IsDataRow Then
                If Rows(i).Cells(FieldName).Value.Equals(Value) Then
                    Return Rows(i)
                End If
            ElseIf Rows(i).IsGroupByRow Then
                Rows(i).Expanded = True
                For j = 0 To Rows(i).ChildBands.Count - 1
                    row = FindRowByFiledInCol(Rows(i).ChildBands(j).Rows, FieldName, Value)
                    If Not row Is Nothing Then
                        Return row
                    End If
                Next
            End If
        Next

        Return Nothing
    End Function


    Protected Sub RowColChange(ByRef ID As System.Guid)
        RaiseEvent OnGridRowColChange(ID)
    End Sub

    Protected Function GridAdd(ByVal ID As System.Guid) As Boolean
        Dim OK As Boolean
        RaiseEvent OnGridAdd(OK, ID)
        Return OK
    End Function

    Protected Function GridEdit(ByVal gr As UltraGrid) As Boolean
        Dim dt As DataTable
        dt = gr.DataSource
        If dt.Rows.Count > 0 Then
            If Not gr.ActiveRow Is Nothing Then
                If gr.ActiveRow.IsDataRow Then
                    Dim OK As Boolean
                    RaiseEvent OnGridEdit(OK, New Guid(gr.ActiveRow.Cells(Constants.FIELD_ID).Value.ToString()))
                    Return OK
                End If
            End If
        End If
    End Function

    Protected Function GridDel(ByVal ID As System.Guid) As Boolean
        Dim OK As Boolean
        RaiseEvent OnGridDel(OK, ID)
        Return OK
    End Function

    Protected Function GridFind(ByVal gr As UltraGrid) As Boolean
        'Dim UseDefault As Boolean
        'UseDefault = True
        'RaiseEvent OnGridFind(UseDefault)
        'If (UseDefault) Then
        '    Dim f As frmFind
        '    f = New frmFind
        '    f.ShowDialog()
        '    If f.DialogResult = DialogResult.OK Then
        '        Dim SearchString As String
        '        SearchString = f.txtFind.Text.Trim()
        '        If f.txtFind.Text <> String.Empty Then
        '            Dim i As Integer
        '            Dim dt As DataTable
        '            dt = gr.DataSource
        '            Dim OldSort As String
        '            OldSort = dt.DefaultView.Sort
        '            dt.DefaultView.Sort = gr.TableStyles.Item(0).GridColumnStyles.Item(gr.CurrentCell.ColumnNumber).MappingName()
        '            i = dt.DefaultView.Find(f.txtFind.Text)
        '            If i >= 0 Then
        '                gr.CurrentRowIndex = i
        '                gr.Select(gr.CurrentRowIndex)
        '                gr.Focus()
        '            End If
        '            If (OldSort <> String.Empty) Then
        '                dt.DefaultView.Sort = OldSort
        '            End If
        '        End If
        '    End If
        '    f = Nothing

        'End If
    End Function

    Protected Function GridProp(ByVal gr As UltraGrid) As Boolean
        Dim UseDefault As Boolean
        Dim OK As Boolean
        UseDefault = True
        RaiseEvent OnGridProp(OK, UseDefault)
        'If (UseDefault) Then
        '    Dim frm As PropertyGridForm
        '    frm = New PropertyGridForm
        '    frm.SelectedObject = gr.DisplayLayout.Bands(0)
        '    If (frm.ShowDialog() = DialogResult.OK) Then
        '        ' Save...
        '    End If
        'End If
        gr.ShowColumnChooser("�������")
        Dim lpath As String
        Try
            lpath = GetSetting("MTZ", "CONFIG", "LAYOUTS", My.Application.Info.DirectoryPath & "\Layouts\")
            gr.DisplayLayout.Save(lpath & "\" & CurTableStyle.MappingName & ".ugl")
        Catch
        End Try
        Return UseDefault
    End Function


    Protected Function GridRefresh() As Boolean
        RaiseEvent OnGridRefresh()
    End Function

    Protected Function GridPrint(ByVal gr As UltraGrid) As Boolean
        Dim UseDefault As Boolean
        Dim OK As Boolean
        UseDefault = True
        RaiseEvent OnGridPrint(OK, UseDefault)
        If (UseDefault) Then
            gr.PrintPreview()
        End If
    End Function



    Protected Function GridRun(ByVal gr As UltraGrid) As Boolean
        Dim UseDefault As Boolean
        Dim OK As Boolean
        UseDefault = True
        Dim ID As System.Guid
        Dim dt As DataTable
        dt = gr.DataSource
        If dt.Rows.Count > 0 Then
            If Not gr.ActiveRow Is Nothing Then
                If gr.ActiveRow.IsDataRow = True Then
                    ID = New Guid(gr.ActiveRow.Cells(Constants.FIELD_ID).Value.ToString())
                    RaiseEvent OnGridRun(OK, ID, UseDefault)
                    If (UseDefault) Then
                        GridEdit(gr)
                    End If
                End If
            End If
        End If
    End Function

End Class
