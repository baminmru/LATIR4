Imports Janus.Windows.Common
Imports Janus.Windows.GridEX
Imports MTZJrnl.MTZJrnl

Public Class JournalView
    Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        
    End Sub

    'UserControl1 overrides dispose to clean up the component list.
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
    Friend WithEvents jgr As Janus.Windows.GridEX.GridEX
    Friend WithEvents cmdDel As System.Windows.Forms.Button
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents cmdEdit As System.Windows.Forms.Button
    Friend WithEvents cmdFilter As System.Windows.Forms.Button
    Friend WithEvents cmdClearFilter As System.Windows.Forms.Button
    Friend WithEvents RefreshTimer As System.Windows.Forms.Timer
    Friend WithEvents CtlMenu As System.Windows.Forms.ContextMenu
    Friend WithEvents cmdRun As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents mnuAdd As System.Windows.Forms.MenuItem
    Friend WithEvents mnuEdit As System.Windows.Forms.MenuItem
    Friend WithEvents mnuRun As System.Windows.Forms.MenuItem
    Friend WithEvents mnuPrint As System.Windows.Forms.MenuItem
    Friend WithEvents mnufilter As System.Windows.Forms.MenuItem
    Friend WithEvents mnuNoFilter As System.Windows.Forms.MenuItem
    Friend WithEvents mnuRefresh As System.Windows.Forms.MenuItem
    Friend WithEvents mnuDelete As System.Windows.Forms.MenuItem
    Friend WithEvents cmdSetup As System.Windows.Forms.Button


    Private WithEvents mColumnsMenu As ContextMenu
    Private WithEvents mmnuSortAscending As MenuItem
    Private WithEvents mmnuSortDescending As MenuItem
    Private WithEvents mmnuGroupColumn As MenuItem
    Private WithEvents mmnuGroupByBox As MenuItem
    Private WithEvents mmnuHideColumn As MenuItem
    Private WithEvents mmnuFieldChooser As MenuItem
    Private WithEvents mmnuCustomizeView As MenuItem
    Friend WithEvents mnuSep As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSep2 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSep3 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSetup As System.Windows.Forms.MenuItem

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container
    Me.Panel1 = New System.Windows.Forms.Panel
    Me.cmdSetup = New System.Windows.Forms.Button
    Me.cmdRefresh = New System.Windows.Forms.Button
    Me.cmdPrint = New System.Windows.Forms.Button
    Me.cmdRun = New System.Windows.Forms.Button
    Me.cmdClearFilter = New System.Windows.Forms.Button
    Me.cmdFilter = New System.Windows.Forms.Button
    Me.cmdEdit = New System.Windows.Forms.Button
    Me.cmdAdd = New System.Windows.Forms.Button
    Me.cmdDel = New System.Windows.Forms.Button
    Me.jgr = New Janus.Windows.GridEX.GridEX
    Me.CtlMenu = New System.Windows.Forms.ContextMenu
    Me.mnuAdd = New System.Windows.Forms.MenuItem
    Me.mnuEdit = New System.Windows.Forms.MenuItem
    Me.mnuDelete = New System.Windows.Forms.MenuItem
    Me.mnuRun = New System.Windows.Forms.MenuItem
    Me.mnuPrint = New System.Windows.Forms.MenuItem
    Me.mnufilter = New System.Windows.Forms.MenuItem
    Me.mnuNoFilter = New System.Windows.Forms.MenuItem
    Me.mnuRefresh = New System.Windows.Forms.MenuItem
    Me.mnuSetup = New System.Windows.Forms.MenuItem
    Me.RefreshTimer = New System.Windows.Forms.Timer(Me.components)
    Me.mnuSep = New System.Windows.Forms.MenuItem
    Me.mnuSep2 = New System.Windows.Forms.MenuItem
    Me.mnuSep3 = New System.Windows.Forms.MenuItem
    Me.mColumnsMenu = New System.Windows.Forms.ContextMenu
    Me.mmnuSortAscending = New System.Windows.Forms.MenuItem
    Me.mmnuSortDescending = New System.Windows.Forms.MenuItem
    Me.mmnuHideColumn = New System.Windows.Forms.MenuItem
    Me.mmnuGroupColumn = New System.Windows.Forms.MenuItem
    Me.mmnuGroupByBox = New System.Windows.Forms.MenuItem
    Me.mmnuFieldChooser = New System.Windows.Forms.MenuItem
    Me.mmnuCustomizeView = New System.Windows.Forms.MenuItem
    Me.Panel1.SuspendLayout()
    CType(Me.jgr, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Panel1
    '
    Me.Panel1.Controls.Add(Me.cmdSetup)
    Me.Panel1.Controls.Add(Me.cmdRefresh)
    Me.Panel1.Controls.Add(Me.cmdPrint)
    Me.Panel1.Controls.Add(Me.cmdRun)
    Me.Panel1.Controls.Add(Me.cmdClearFilter)
    Me.Panel1.Controls.Add(Me.cmdFilter)
    Me.Panel1.Controls.Add(Me.cmdEdit)
    Me.Panel1.Controls.Add(Me.cmdAdd)
    Me.Panel1.Controls.Add(Me.cmdDel)
    Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
    Me.Panel1.Location = New System.Drawing.Point(0, 0)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(440, 64)
    Me.Panel1.TabIndex = 0
    '
    'cmdSetup
    '
    Me.cmdSetup.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.cmdSetup.Location = New System.Drawing.Point(304, 32)
    Me.cmdSetup.Name = "cmdSetup"
    Me.cmdSetup.Size = New System.Drawing.Size(80, 24)
    Me.cmdSetup.TabIndex = 8
    Me.cmdSetup.Text = "Настроить"
    '
    'cmdRefresh
    '
    Me.cmdRefresh.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.cmdRefresh.Location = New System.Drawing.Point(304, 8)
    Me.cmdRefresh.Name = "cmdRefresh"
    Me.cmdRefresh.Size = New System.Drawing.Size(80, 24)
    Me.cmdRefresh.TabIndex = 7
    Me.cmdRefresh.Text = "Обновить"
    '
    'cmdPrint
    '
    Me.cmdPrint.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.cmdPrint.Location = New System.Drawing.Point(8, 32)
    Me.cmdPrint.Name = "cmdPrint"
    Me.cmdPrint.Size = New System.Drawing.Size(72, 24)
    Me.cmdPrint.TabIndex = 6
    Me.cmdPrint.Text = "Печать"
    '
    'cmdRun
    '
    Me.cmdRun.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.cmdRun.Location = New System.Drawing.Point(224, 8)
    Me.cmdRun.Name = "cmdRun"
    Me.cmdRun.Size = New System.Drawing.Size(80, 24)
    Me.cmdRun.TabIndex = 5
    Me.cmdRun.Text = "Выполнить"
    '
    'cmdClearFilter
    '
    Me.cmdClearFilter.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.cmdClearFilter.Location = New System.Drawing.Point(152, 32)
    Me.cmdClearFilter.Name = "cmdClearFilter"
    Me.cmdClearFilter.Size = New System.Drawing.Size(152, 24)
    Me.cmdClearFilter.TabIndex = 4
    Me.cmdClearFilter.Text = "Отмена фильтра"
    '
    'cmdFilter
    '
    Me.cmdFilter.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.cmdFilter.Location = New System.Drawing.Point(80, 32)
    Me.cmdFilter.Name = "cmdFilter"
    Me.cmdFilter.Size = New System.Drawing.Size(72, 24)
    Me.cmdFilter.TabIndex = 3
    Me.cmdFilter.Text = "Фильтр"
    '
    'cmdEdit
    '
    Me.cmdEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.cmdEdit.Location = New System.Drawing.Point(80, 8)
    Me.cmdEdit.Name = "cmdEdit"
    Me.cmdEdit.Size = New System.Drawing.Size(72, 24)
    Me.cmdEdit.TabIndex = 2
    Me.cmdEdit.Text = "Изменить"
    '
    'cmdAdd
    '
    Me.cmdAdd.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.cmdAdd.Location = New System.Drawing.Point(8, 8)
    Me.cmdAdd.Name = "cmdAdd"
    Me.cmdAdd.Size = New System.Drawing.Size(72, 24)
    Me.cmdAdd.TabIndex = 1
    Me.cmdAdd.Text = "Создать"
    '
    'cmdDel
    '
    Me.cmdDel.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.cmdDel.Location = New System.Drawing.Point(152, 8)
    Me.cmdDel.Name = "cmdDel"
    Me.cmdDel.Size = New System.Drawing.Size(72, 24)
    Me.cmdDel.TabIndex = 0
    Me.cmdDel.Text = "Удалить"
    '
    'jgr
    '
    Me.jgr.BackColor = System.Drawing.SystemColors.Control
    Me.jgr.BorderStyle = Janus.Windows.GridEX.BorderStyle.Flat
    Me.jgr.CalendarNoneText = "-"
    Me.jgr.CalendarTodayText = "Сегодня"
    Me.jgr.Cursor = System.Windows.Forms.Cursors.Default
    Me.jgr.Dock = System.Windows.Forms.DockStyle.Fill
    Me.jgr.GroupByBoxInfoText = "Перетащите колонку для группировки"
    Me.jgr.InvalidValueAction = Janus.Windows.GridEX.InvalidValueAction.DiscardChanges
    Me.jgr.Location = New System.Drawing.Point(0, 64)
    Me.jgr.Name = "jgr"
    Me.jgr.Size = New System.Drawing.Size(440, 224)
    Me.jgr.TabIndex = 1
    '
    'CtlMenu
    '
    Me.CtlMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuAdd, Me.mnuEdit, Me.mnuDelete, Me.mnuRun, Me.mnuPrint, Me.mnufilter, Me.mnuNoFilter, Me.mnuRefresh, Me.mnuSetup})
    '
    'mnuAdd
    '
    Me.mnuAdd.Index = 0
    Me.mnuAdd.Text = "Создать"
    '
    'mnuEdit
    '
    Me.mnuEdit.Index = 1
    Me.mnuEdit.Text = "Изменить"
    '
    'mnuDelete
    '
    Me.mnuDelete.Index = 2
    Me.mnuDelete.Text = "Удалить"
    '
    'mnuRun
    '
    Me.mnuRun.Index = 3
    Me.mnuRun.Text = "Открыть"
    '
    'mnuPrint
    '
    Me.mnuPrint.Index = 4
    Me.mnuPrint.Text = "Печать"
    '
    'mnufilter
    '
    Me.mnufilter.Index = 5
    Me.mnufilter.Text = "Фильтр"
    '
    'mnuNoFilter
    '
    Me.mnuNoFilter.Index = 6
    Me.mnuNoFilter.Text = "Отмена фильтра"
    '
    'mnuRefresh
    '
    Me.mnuRefresh.Index = 7
    Me.mnuRefresh.Text = "Обновить"
    '
    'mnuSetup
    '
    Me.mnuSetup.Index = 8
    Me.mnuSetup.Text = "Настроить"
    '
    'mnuSep
    '
    Me.mnuSep.Index = 3
    Me.mnuSep.Text = "-"
    '
    'mnuSep2
    '
    Me.mnuSep2.Index = 6
    Me.mnuSep2.Text = "-"
    '
    'mnuSep3
    '
    Me.mnuSep3.Index = 8
    Me.mnuSep3.Text = "-"
    '
    'mColumnsMenu
    '
    Me.mColumnsMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mmnuSortAscending, Me.mmnuSortDescending, Me.mmnuHideColumn, Me.mnuSep, Me.mmnuGroupColumn, Me.mmnuGroupByBox, Me.mnuSep2, Me.mmnuFieldChooser, Me.mnuSep3, Me.mmnuCustomizeView})
    '
    'mmnuSortAscending
    '
    Me.mmnuSortAscending.Index = 0
    Me.mmnuSortAscending.Text = "По возрастанию"
    '
    'mmnuSortDescending
    '
    Me.mmnuSortDescending.Index = 1
    Me.mmnuSortDescending.Text = "По убыванию"
    '
    'mmnuHideColumn
    '
    Me.mmnuHideColumn.Index = 2
    Me.mmnuHideColumn.Text = "Скрыть колонку"
    '
    'mmnuGroupColumn
    '
    Me.mmnuGroupColumn.Index = 4
    Me.mmnuGroupColumn.Text = "Группировать по"
    '
    'mmnuGroupByBox
    '
    Me.mmnuGroupByBox.Index = 5
    Me.mmnuGroupByBox.Text = "Поле группировки"
    '
    'mmnuFieldChooser
    '
    Me.mmnuFieldChooser.Index = 7
    Me.mmnuFieldChooser.Text = "Выбор полей"
    '
    'mmnuCustomizeView
    '
    Me.mmnuCustomizeView.Index = 9
    Me.mmnuCustomizeView.Text = "Настроить"
    '
    'JournalView
    '
    Me.Controls.Add(Me.jgr)
    Me.Controls.Add(Me.Panel1)
    Me.Name = "JournalView"
    Me.Size = New System.Drawing.Size(440, 288)
    Me.Panel1.ResumeLayout(False)
    CType(Me.jgr, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region

    Private mColumnClicked As GridEXColumn
    Private mGuiManager As LATIRGuiManager.LATIRGuiManager
    Private mjDef As MTZJrnl.MTZJrnl.Application
    Private JDataTable As DataTable
    'Private ViewMap As Collection
    Public Event JVOnPrint(ByVal InstanceID As System.Guid, ByVal RowID As System.Guid, ByVal ViewBase As String, ByRef UseDefault As Boolean)
    Public Event JVOnFilter(ByRef UseDefault As Boolean)
    Public Event JVOnClearFilter(ByRef UseDefault As Boolean)
    Public Event JVOnSetup(ByRef UseDefault As Boolean)
    Public Event JVOnAdd(ByRef UseDefault As Boolean, ByRef Refesh As Boolean)
    Public Event JVOnEdit(ByVal InstanceID As System.Guid, ByVal RowID As System.Guid, ByVal ViewBase As String, ByRef UseDefault As Boolean, ByRef Refesh As Boolean)
    Public Event JVOnRun(ByVal InstanceID As System.Guid, ByVal RowID As System.Guid, ByVal ViewBase As String, ByRef UseDefault As Boolean, ByRef Refesh As Boolean)
    Public Event JVOnDel(ByVal InstanceID As System.Guid, ByVal RowID As System.Guid, ByVal ViewBase As String, ByRef UseDefault As Boolean, ByRef Refesh As Boolean)
    Public Event JVOnRowChange(ByVal InstanceID As System.Guid, ByVal RowID As System.Guid, ByVal ViewBase As String)
    Public Event JVOnDblClick(ByVal InstanceID As System.Guid, ByVal RowID As System.Guid, ByVal ViewBase As String, ByRef UseDefault As Boolean, ByRef Refesh As Boolean)
    Public Event JVOnRefresh(ByRef UseDefault As Boolean)


    Public Function GetLayoutDataPath() As String
        Dim di As System.IO.DirectoryInfo = New System.IO.DirectoryInfo(System.Windows.Forms.Application.ExecutablePath).Parent
        Dim strLayoutPath As String = di.FullName & "\LayoutData"
        Dim LayoutDi As System.IO.DirectoryInfo = New System.IO.DirectoryInfo(strLayoutPath)
        If Not LayoutDi.Exists Then
            di.CreateSubdirectory("LayoutData")
        End If
        Return LayoutDi.FullName
    End Function

    Private mParentForm As System.Windows.Forms.Form
    Public Sub Attach(ByVal gm As LATIRGuiManager.LATIRGuiManager, ByVal jdef As MTZJrnl.MTZJrnl.Application, ByVal parentForm As System.Windows.Forms.Form)
        mGuiManager = gm
        mjDef = jdef
        mParentForm = parentForm
        CreateFromDef()
        RefreshData()
    End Sub


    Private Sub SaveGridLayout(ByVal name As String)
        Dim strLayoutPath As String
        strLayoutPath = GetLayoutDataPath()
        Try
            Dim stream As System.IO.FileStream = New System.IO.FileStream(strLayoutPath & "\" & name & ".gxl", IO.FileMode.Create)
            jgr.SaveLayoutFile(stream)
            stream.Close()
        Catch
        End Try
    End Sub

    Private Sub LoadGridLayout(ByVal name As String)
        Dim strLayoutPath As String
        strLayoutPath = GetLayoutDataPath()
        Dim fi As System.IO.FileInfo = New System.IO.FileInfo(strLayoutPath & "\" & name & ".gxl")
        If fi.Exists Then
            Try
                If Not jgr.CurrentLayout Is Nothing Then
                    jgr.Update()
                End If
                Dim stream As System.IO.FileStream = New System.IO.FileStream(fi.FullName, IO.FileMode.Open)
                jgr.LoadLayoutFile(stream)
                stream.Close()
            Catch exc As Exception
                MessageBox.Show(exc.ToString())
            End Try
        End If
    End Sub


    Private Sub CreateFromDef(Optional ByVal NoLoad As Boolean = False)
        Dim dc As DataColumn

        Dim js As Long, idx As Long
        'Dim pv As MTZMetaModel.PARTVIEW
        'Dim part As MTZMetaModel.part
        Dim rs As DataTable
        Dim JC As JournalColumn
        Dim table As GridEXTable
        Dim column As GridEXColumn
        Dim layout As GridEXLayout
again:
        On Error Resume Next


        If mjDef Is Nothing Then Exit Sub

        jgr.Reset()
        jgr.AllowAddNew = InheritableBoolean.False
        jgr.AllowEdit = InheritableBoolean.False
        jgr.AllowDelete = InheritableBoolean.False
        jgr.AllowDrop = False
        jgr.AllowRemoveColumns = InheritableBoolean.False
        jgr.AlternatingColors = True
        jgr.AutoEdit = False


        'Defining Product table layout
        table = New GridEXTable

        JDataTable = New DataTable

        JDataTable.Columns.Add("ID", GetType(System.Guid))
        JDataTable.Columns.Add("InstanceID", GetType(System.Guid))
        JDataTable.Columns.Add("ViewBase", GetType(System.String))

        For js = 1 To mjDef.JournalColumn.Count
            JC = mjDef.JournalColumn.Item(js)
            'JC.ColSort = enumColumnSortType.ColumnSortType_As_Date

            column = table.Columns.Add(JC.name())
            column.DataMember = JC.name()
            column.Caption = JC.name()
            column.ColumnType = ColumnType.Text
            column.CellToolTipText = JC.name
            'column.SortKey 

            If JC.ColSort = enumColumnSortType.ColumnSortType_As_Date Then
                JDataTable.Columns.Add(JC.name(), GetType(System.DateTime))
            End If
            If JC.ColSort = enumColumnSortType.ColumnSortType_As_Numeric Then
                JDataTable.Columns.Add(JC.name(), GetType(System.Double))
            End If
            If JC.ColSort = enumColumnSortType.ColumnSortType_As_String Then
                JDataTable.Columns.Add(JC.name(), GetType(System.String))
            End If

            If JC.GroupAggregation = enumAggregationType.AggregationType_AVG Then column.AggregateFunction = AggregateFunction.Average
            If JC.GroupAggregation = enumAggregationType.AggregationType_COUNT Then column.AggregateFunction = AggregateFunction.Count
            If JC.GroupAggregation = enumAggregationType.AggregationType_MAX Then column.AggregateFunction = AggregateFunction.Max
            If JC.GroupAggregation = enumAggregationType.AggregationType_MIN Then column.AggregateFunction = AggregateFunction.Min
            If JC.GroupAggregation = enumAggregationType.AggregationType_none Then column.AggregateFunction = AggregateFunction.None
            If JC.GroupAggregation = enumAggregationType.AggregationType_SUM Then column.AggregateFunction = AggregateFunction.Sum

            If JC.ColumnAlignment = enumVHAlignment.VHAlignment_Center_Bottom Then column.TextAlignment = TextAlignment.Center
            If JC.ColumnAlignment = enumVHAlignment.VHAlignment_Center_Top Then column.TextAlignment = TextAlignment.Center
            If JC.ColumnAlignment = enumVHAlignment.VHAlignment_Center_Center Then column.TextAlignment = TextAlignment.Center
            If JC.ColumnAlignment = enumVHAlignment.VHAlignment_Left_Bottom Then column.TextAlignment = TextAlignment.Near
            If JC.ColumnAlignment = enumVHAlignment.VHAlignment_Left_Top Then column.TextAlignment = TextAlignment.Near
            If JC.ColumnAlignment = enumVHAlignment.VHAlignment_Left_Center Then column.TextAlignment = TextAlignment.Near
            If JC.ColumnAlignment = enumVHAlignment.VHAlignment_Right_Bottom Then column.TextAlignment = TextAlignment.Far
            If JC.ColumnAlignment = enumVHAlignment.VHAlignment_Right_Top Then column.TextAlignment = TextAlignment.Far
            If JC.ColumnAlignment = enumVHAlignment.VHAlignment_Right_Center Then column.TextAlignment = TextAlignment.Far
        Next

        ' лишняя колонка для отображения состояния
        column = table.Columns.Add("Состояние")
        column.DataMember = "Состояние"
        column.Caption = "Состояние"
        column.ColumnType = ColumnType.Text
        column.CellToolTipText = "Состояние"


        jgr.RootTable = table

        layout = jgr.GetLayout()

        layout.Key = "Journal" & CType(mjDef.Journal.Item(1), Journal).the_Alias
        jgr.Layouts.Add(layout)


        jgr.CurrentLayout = jgr.Layouts("Journal" & CType(mjDef.Journal.Item(1), Journal).the_Alias)
        On Error Resume Next

        'ViewMap = Nothing
        'ViewMap = New Collection

        Dim jsrc As JournalSrc
        Dim partid As String
        Dim i As Integer

        'Dim idh As idholder
        'For js = 1 To mjDef.JournalSrc.Count
        '    jsrc = mjDef.JournalSrc.Item(js)

        '    rs = mjDef.Session.GetRowsDT("partview", "", "", "partviewid='" & jsrc.PartView.ToString() & "'")
        '    For i = 0 To rs.Rows.Count
        '        partid = rs.Rows(i).Item("parentstructrowid")
        '        rs = mjDef.Session.GetRowsDT("part", "", "", "partid='" & partid & "'")
        '        If Not rs Is Nothing Then
        '            idh = New idholder
        '            idh.Id = jsrc.PartView
        '            idh.N1 = jsrc.ViewAlias
        '            idh.N2 = rs.Rows(i).Item("Name")
        '            ViewMap.Add(idh, idh.Id.ToString())
        '        End If
        '    Next
        'Next

        On Error GoTo bye
        If NoLoad = False Then
            LoadGridLayout("Journal" & CType(mjDef.Journal.Item(1), Journal).the_Alias)
            Exit Sub
        End If
        Exit Sub
bye:
        NoLoad = True
        GoTo again

    End Sub
    Private LastCheckDate As DateTime
    Private Filter As Collection

    Private Class JFilter
        Public Name As String
        Public FilterString As String
    End Class

    Public Sub RefreshData()
        If mjDef Is Nothing Then Exit Sub
        On Error GoTo bye


        Dim cnt As Long

        Dim js As Long, idx As Long, i As Long, j As Long
        Dim rs As DataTable
        Dim JCS As MTZJrnl.MTZJrnl.JColumnSource
        Dim JC As MTZJrnl.MTZJrnl.JournalColumn
        Dim jsrc As MTZJrnl.MTZJrnl.JournalSrc
        Dim fltr As JFilter

        LastCheckDate = mjDef.Session.GetServerTime()
        JDataTable.Rows.Clear()

        For js = 1 To mjDef.JournalSrc.Count
            jsrc = mjDef.JournalSrc.Item(js)

            fltr = Nothing
            On Error Resume Next
            fltr = Filter.Item(jsrc.ViewAlias)
            On Error GoTo bye
            If mjDef.Session.Language <> "" Then
                If Not fltr Is Nothing Then
                    rs = mjDef.Session.GetRowsDT("v_" & jsrc.ViewAlias + "_" + mjDef.Session.Language, , , fltr.FilterString)
                Else
                    rs = mjDef.Session.GetRowsDT("v_" & jsrc.ViewAlias + "_" + mjDef.Session.Language)
                End If
            Else
                If Not fltr Is Nothing Then
                    rs = mjDef.Session.GetRowsDT("v_" & jsrc.ViewAlias, , , fltr.FilterString)
                Else
                    rs = mjDef.Session.GetRowsDT("v_" & jsrc.ViewAlias)
                End If
            End If
            
            fltr = Nothing

            If Not rs Is Nothing Then
                On Error Resume Next
                Dim dr As DataRow
                Dim k As Integer
                For k = 0 To rs.Rows.Count - 1
                    dr = JDataTable.NewRow
                    On Error Resume Next
                    dr("ID") = rs.Rows(k).Item("id")
                    dr("Instanceid") = rs.Rows(k).Item("InstanceID")
                    dr("ViewBase") = rs.Rows(k).Item("ViewBase")


                    For i = 1 To mjDef.JournalColumn.Count
                        JC = mjDef.JournalColumn.Item(i)
                        For j = 1 To JC.JColumnSource.Count
                            JCS = JC.JColumnSource.Item(j)
                            If JCS.SrcPartView.ID.Equals(jsrc.ID) Then
                                If JC.ColSort = enumColumnSortType.ColumnSortType_As_Date Then
                                    dr(JC.name) = CType(rs.Rows(k).Item(JCS.ViewField), System.DateTime)
                                End If
                                If JC.ColSort = enumColumnSortType.ColumnSortType_As_Numeric Then
                                    dr(JC.name) = CType(rs.Rows(k).Item(JCS.ViewField), Double)
                                End If
                                If JC.ColSort = enumColumnSortType.ColumnSortType_As_String Then
                                    dr(JC.name) = CType(rs.Rows(k).Item(JCS.ViewField), System.String)
                                End If


                            End If
                        Next
                    Next
                    dr("Состояние") = rs.Rows(k).Item("StatusName")
                    JDataTable.Rows.Add(dr)
                Next
            End If

        Next

        JDataTable.TableName = "Journal" & CType(mjDef.Journal.Item(1), Journal).the_Alias

        jgr.DataSource = JDataTable


        Exit Sub
bye:
        'Stop
        'Resume
        MsgBox(Err.Description, vbCritical + vbOKOnly, "Обновление журнала")
    End Sub
    Private Class IDHolder
        Public Id As System.Guid
        Public N1 As String
        Public N2 As String
    End Class


    Public Property AutoRefresh() As Boolean
        Get
            Return RefreshTimer.Enabled
        End Get
        Set(ByVal v As Boolean)
            If v Then
                If Not mjDef Is Nothing Then
                    RefreshTimer.Enabled = v
                End If
            Else
                RefreshTimer.Enabled = v
            End If
        End Set
    End Property



    Public Property AllowAdd() As Boolean
        Get
            Return cmdAdd.Enabled
        End Get
        Set(ByVal V As Boolean)
            If V Then
                cmdAdd.Enabled = True
            Else
                cmdAdd.Enabled = False
            End If
            mnuAdd.Visible = cmdAdd.Enabled
        End Set
    End Property



    Public Property AllowFilter() As Boolean
        Get
            Return cmdFilter.Enabled
        End Get
        Set(ByVal V As Boolean)
            If V Then
                cmdFilter.Enabled = True
            Else
                cmdFilter.Enabled = False
            End If
            mnufilter.Visible = cmdFilter.Enabled

            If V Then
                cmdClearFilter.Enabled = True
            Else
                cmdClearFilter.Enabled = False
            End If
            mnuNoFilter.Visible = cmdClearFilter.Enabled
        End Set
    End Property


    Public Property AllowEdit() As Boolean
        Get
            Return cmdEdit.Enabled
        End Get
        Set(ByVal V As Boolean)
            If V Then
                cmdEdit.Enabled = True
            Else
                cmdEdit.Enabled = False
            End If
            mnuEdit.Visible = cmdEdit.Enabled
        End Set
    End Property



    Public Property AllowDel() As Boolean
        Get
            Return cmdDel.Enabled
        End Get
        Set(ByVal Value As Boolean)
            If Value Then
                cmdDel.Enabled = True
            Else
                cmdDel.Enabled = False
            End If
            mnuDelete.Visible = cmdDel.Enabled
        End Set
    End Property





    Public Property AllowRun() As Boolean
        Get
            Return cmdRun.Enabled
        End Get
        Set(ByVal V As Boolean)
            If V Then
                cmdRun.Enabled = True
            Else
                cmdRun.Enabled = False
            End If
            mnuRun.Visible = cmdRun.Enabled
        End Set
    End Property







    'Public Sub ClearFilter()
    '    m_Filter = Nothing
    '    m_Filter = New JFilters
    'End Sub


    'Public Function Filter() As JFilters
    '    If m_Filter Is Nothing Then
    '        m_Filter = New JFilters
    '    End If
    '    Filter = m_Filter
    'End Function





    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        Dim UseDefault As Boolean = True
        RaiseEvent JVOnRefresh(UseDefault)
        If UseDefault Then
            RefreshData()
        End If
    End Sub

    Public Sub GridEX_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles jgr.MouseUp
        If e.Button = System.Windows.Forms.MouseButtons.Right Then
            If jgr.HitTest(e.X, e.Y) = GridArea.ColumnHeader Then
                mColumnClicked = jgr.ColumnFromPoint(e.X, e.Y)
                If Not mColumnClicked Is Nothing Then
                    Me.mColumnsMenu.Show(Me.jgr, New Point(e.X, e.Y))
                End If
            End If
            If jgr.HitTest(e.X, e.Y) = GridArea.Cell Then
                'mColumnClicked = jgr.ColumnFromPoint(e.X, e.Y)
                'If Not mColumnClicked Is Nothing Then
                Me.CtlMenu.Show(Me.jgr, New Point(e.X, e.Y))
                'End If
            End If
        End If
    End Sub
    Public Sub ShowFormatConditions()
        Dim dialog As frmFormatConditions = New frmFormatConditions
        dialog.ShowFormatConditionsForm(jgr.RootTable)
    End Sub
    Public Sub ShowViewSummary()
        Dim dialog As frmViewSummary = New frmViewSummary
        If dialog.ShowDialog(jgr, mParentForm, Me) = System.Windows.Forms.DialogResult.OK Then
            SaveGridLayout("Journal" & CType(mjDef.Journal.Item(1), Journal).the_Alias)
        End If
    End Sub
    Public Sub ShowFields()
        Dim dialog As frmShowFields = New frmShowFields
        dialog.ShowDialog(jgr, mParentForm)
    End Sub
    Public Sub ShowGroupBy()
        Dim dialog As frmGroupBy = New frmGroupBy
        dialog.ShowDialog(jgr, mParentForm)
    End Sub
    Public Sub ShowSort()
        Dim dialog As frmSort = New frmSort
        dialog.ShowDialog(jgr, mParentForm)
    End Sub
    Public Sub ShowFormatView()
        If jgr.View = View.TableView Then
            Dim dialog As frmFormatView
            dialog = New frmFormatView
            dialog.ShowDialog(jgr, mParentForm)
        Else
            Dim cardDialog As frmFormatCardView = New frmFormatCardView
            cardDialog.ShowDialog(jgr, mParentForm)
        End If
    End Sub






    Private Sub mColumnMenu_PopUp(ByVal sender As Object, ByVal e As EventArgs) Handles mColumnsMenu.Popup
        Me.mmnuSortAscending.Checked = (mColumnClicked.SortOrder = SortOrder.Ascending)
        Me.mmnuSortDescending.Checked = (mColumnClicked.SortOrder = SortOrder.Descending)
        If mColumnClicked.Group Is Nothing Then
            mmnuGroupColumn.Text = "Группировать по полю"
        Else
            mmnuGroupColumn.Text = "Исключить из группировки"
        End If
        mmnuGroupByBox.Checked = jgr.GroupByBoxVisible
        If jgr.View = View.TableView Then
            mmnuGroupByBox.Visible = True
        Else
            mmnuGroupByBox.Visible = False
        End If
    End Sub
    Private Sub mnuSortAscending_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mmnuSortAscending.Click
        If Not mColumnClicked.Group Is Nothing Then
            mColumnClicked.Group.SortOrder = Janus.Windows.GridEX.SortOrder.Ascending
        ElseIf Not mColumnClicked.SortKey Is Nothing Then
            mColumnClicked.SortKey.SortOrder = Janus.Windows.GridEX.SortOrder.Ascending
        Else
            mColumnClicked.Table.SortKeys.Clear()
            mColumnClicked.Table.SortKeys.Add(New GridEXSortKey(mColumnClicked, SortOrder.Ascending))
        End If
    End Sub
    Private Sub mnuSortDescending_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mmnuSortDescending.Click
        If Not mColumnClicked.Group Is Nothing Then
            mColumnClicked.Group.SortOrder = SortOrder.Descending
        ElseIf Not mColumnClicked.SortKey Is Nothing Then
            mColumnClicked.SortKey.SortOrder = SortOrder.Descending
        Else
            mColumnClicked.Table.SortKeys.Clear()
            mColumnClicked.Table.SortKeys.Add(New GridEXSortKey(mColumnClicked, SortOrder.Descending))
        End If
    End Sub
    Private Sub mnuGroupColumn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mmnuGroupColumn.Click
        If mColumnClicked.Group Is Nothing Then
            mColumnClicked.Table.Groups.Add(New GridEXGroup(mColumnClicked))
        Else
            mColumnClicked.Table.Groups.Remove(mColumnClicked.Group)
        End If
    End Sub
    Private Sub mnuGroupByBox_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mmnuGroupByBox.Click
        jgr.GroupByBoxVisible = Not jgr.GroupByBoxVisible
    End Sub
    Private Sub mnuHideColumn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mmnuHideColumn.Click
        mColumnClicked.Visible = False
    End Sub
    Private Sub mnuFieldChooser_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mmnuFieldChooser.Click
        jgr.ShowFieldChooser()
    End Sub
    Private Sub mnuCustomizeView_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mmnuCustomizeView.Click
        Me.ShowViewSummary()
    End Sub

    Private Sub cmdSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSetup.Click
        Dim UseDefault As Boolean = True
        RaiseEvent JVOnSetup(UseDefault)
        If UseDefault Then
            Me.ShowViewSummary()
        End If

    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        Dim UseDefault As Boolean = True, RefreshJV As Boolean = False
        Dim InstanceID As System.Guid, RowID As System.Guid
        Dim ViewBase As String = String.Empty
        If jgr.Row >= 0 Then
            GetRowInfo(InstanceID, RowID, ViewBase)
            RaiseEvent JVOnPrint(InstanceID, RowID, ViewBase, UseDefault)
            If UseDefault Then
                Dim prdoc As Janus.Windows.GridEX.GridEXPrintDocument
                prdoc = New Janus.Windows.GridEX.GridEXPrintDocument
                prdoc.CardColumnsPerPage = 2
                prdoc.DocumentName = mjDef.Name
                prdoc.ExpandFarColumn = True
                prdoc.FitColumns = Janus.Windows.GridEX.FitColumnsMode.NoFit
                prdoc.GridEX = jgr
                prdoc.PageFooterCenter = ""
                prdoc.PageFooterLeft = ""
                prdoc.PageFooterRight = ""
                prdoc.PageHeaderCenter = mjDef.Name
                prdoc.PageHeaderFormatStyle.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                prdoc.PageHeaderLeft = ""
                prdoc.PageHeaderRight = ""
                prdoc.PrintBackgroundImage = False
                prdoc.PrintCellBackground = False
                prdoc.PrintCollapsedRows = True
                prdoc.PrintHierarchical = False
                Dim pd As System.Drawing.Printing.PrintDocument
                pd = prdoc
                Dim pp As New frmPrintPreview
                pp.ShowDialog(pd)
            End If
        End If
    End Sub

    Private Sub GetRowInfo(ByRef InstanceID As System.Guid, ByRef RowID As System.Guid, ByRef ViewBase As String)
        Dim dv As DataRowView
        If jgr.Row >= 0 Then
            dv = CType(jgr.GetRow().DataRow, System.Data.DataRowView)
            InstanceID = dv.Item("InstanceID")
            RowID = dv.Item("ID")
            ViewBase = dv.Item("ViewBase")
        Else
            InstanceID = System.Guid.Empty
            RowID = System.Guid.Empty
            ViewBase = ""
        End If
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Dim UseDefault As Boolean = True, RefreshJV As Boolean = False
        RaiseEvent JVOnAdd(UseDefault, RefreshJV)
        If RefreshJV Then
            RefreshData()
        End If
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        Dim UseDefault As Boolean = True, RefreshJV As Boolean = False
        Dim InstanceID As System.Guid, RowID As System.Guid
        Dim ViewBase As String = String.Empty
        If jgr.Row >= 0 Then
            GetRowInfo(InstanceID, RowID, ViewBase)
            RaiseEvent JVOnEdit(InstanceID, RowID, ViewBase, UseDefault, RefreshJV)
            If RefreshJV Then
                RefreshData()
            End If
        End If
    End Sub

    Private Sub cmdDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDel.Click
        Dim UseDefault As Boolean = True, RefreshJV As Boolean = False
        Dim InstanceID As System.Guid, RowID As System.Guid
        Dim ViewBase As String = String.Empty
        If jgr.Row >= 0 Then
            GetRowInfo(InstanceID, RowID, ViewBase)
            RaiseEvent JVOnDel(InstanceID, RowID, ViewBase, UseDefault, RefreshJV)
            If RefreshJV Then
                RefreshData()
            End If
        End If
    End Sub

    Private Sub cmdRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRun.Click
        Dim UseDefault As Boolean = True, RefreshJV As Boolean = False
        Dim InstanceID As System.Guid, RowID As System.Guid
        Dim ViewBase As String = String.Empty
        If jgr.Row >= 0 Then
            GetRowInfo(InstanceID, RowID, ViewBase)
            RaiseEvent JVOnRun(InstanceID, RowID, ViewBase, UseDefault, RefreshJV)
            If UseDefault Then
                If cmdEdit.Enabled Then
                    cmdEdit_Click(sender, e)
                End If
            End If
            If RefreshJV Then
                RefreshData()
            End If
        End If
    End Sub


    Private Sub jgr_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles jgr.DoubleClick
        Dim UseDefault As Boolean = True, RefreshJV As Boolean = False
        Dim InstanceID As System.Guid, RowID As System.Guid
        Dim ViewBase As String = String.Empty
        If jgr.Row >= 0 Then
            GetRowInfo(InstanceID, RowID, ViewBase)
            RaiseEvent JVOnDblClick(InstanceID, RowID, ViewBase, UseDefault, RefreshJV)
            If UseDefault Then
                If cmdRun.Enabled Then
                    cmdRun_Click(sender, e)
                End If
            End If
            If RefreshJV Then
                RefreshData()
            End If
        End If
    End Sub

    Private Sub cmdFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilter.Click
        Dim UseDefault As Boolean = True
        RaiseEvent JVOnFilter(UseDefault)
        If UseDefault Then
            RefreshData()
        End If
    End Sub

    Private Sub cmdClearFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearFilter.Click
        Dim UseDefault As Boolean = True
        RaiseEvent JVOnClearFilter(UseDefault)
        If UseDefault Then
            RefreshData()
        End If
    End Sub

    Private Sub jgr_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles jgr.CurrentCellChanged
        Dim InstanceID As System.Guid, RowID As System.Guid
        Dim ViewBase As String = String.Empty
        If jgr.Row >= 0 Then
            GetRowInfo(InstanceID, RowID, ViewBase)
            RaiseEvent JVOnRowChange(InstanceID, RowID, ViewBase)
        End If
    End Sub

    Private Sub mnuAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuAdd.Click
        cmdAdd_Click(sender, e)
    End Sub

    Private Sub CtlMenu_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CtlMenu.Popup

    End Sub

    Private Sub mnuDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuDelete.Click
        cmdDel_Click(sender, e)
    End Sub

    Private Sub mnuEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuEdit.Click
        cmdEdit_Click(sender, e)
    End Sub

    Private Sub mnufilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnufilter.Click
        cmdFilter_Click(sender, e)
    End Sub

    Private Sub mnuNoFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuNoFilter.Click
        cmdClearFilter_Click(sender, e)
    End Sub

    Private Sub mnuPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuPrint.Click
        cmdPrint_Click(sender, e)
    End Sub

    Private Sub mnuRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuRefresh.Click
        cmdRefresh_Click(sender, e)
    End Sub

    Private Sub mnuRun_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuRun.Click
        cmdRun_Click(sender, e)
    End Sub

   
    Private Sub mnuSetup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuSetup.Click
        cmdSetup_Click(sender, e)
    End Sub

    Private Sub JournalView_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged 

    End Sub
End Class

