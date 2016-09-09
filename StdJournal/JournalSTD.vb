﻿Imports MTZJrnl.MTZJrnl
Imports LATIR2
Imports LATIR2GuiManager

Public Class JournalViewSTD
    Inherits System.Windows.Forms.UserControl

#Region "Definitions"

    ''' <summary>
    ''' Designer variable used to keep track of non-visual components.
    ''' </summary>
    Private components As System.ComponentModel.IContainer
    Private mGuiManager As LATIR2GuiManager.LATIRGuiManager
    Private mjDef As MTZJrnl.MTZJrnl.Application
    Private JDataTable As DataTable
    Friend WithEvents RefreshTimer As System.Windows.Forms.Timer
    Friend WithEvents CtlMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRun As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnufilter As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuNoFilter As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRefresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSetup As System.Windows.Forms.ToolStripMenuItem


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


    Private mParentForm As System.Windows.Forms.Form
    Private LastCheckDate As DateTime
    Private WithEvents gv As System.Windows.Forms.DataGridView
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip

    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents Panel1 As Panel
    Friend WithEvents cmdExport As Button
    Friend WithEvents cmdSetup As Button
    Friend WithEvents cmdRefresh As Button
    Friend WithEvents cmdPrint As Button
    Friend WithEvents cmdRun As Button
    Friend WithEvents cmdClearFilter As Button
    Friend WithEvents cmdFilter As Button
    Friend WithEvents cmdEdit As Button
    Friend WithEvents cmdAdd As Button
    Friend WithEvents cmdDel As Button
    Private mFilter As JFilters

    'Private Class JFilter
    '    Public Name As String
    '    Public FilterString As String
    'End Class

    'Private Class IDHolder
    '    Public Id As System.Guid
    '    Public N1 As String
    '    Public N2 As String
    'End Class

#End Region
#Region "Designer"

    ''' <summary>
    ''' Disposes resources used by the control.
    ''' </summary>
    ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If components IsNot Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        mFilter = New JFilters
        AllowFilter = False
    End Sub

    Protected Overrides Sub Finalize()
        mFilter = Nothing
        JDataTable = Nothing
        MyBase.Finalize()
    End Sub


    ''' <summary>
    ''' This method is required for Windows Forms designer support.
    ''' Do not change the method contents inside the source code editor. The Forms designer might
    ''' not be able to load this method if it was changed manually.
    ''' </summary>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(JournalViewSTD))
        Me.RefreshTimer = New System.Windows.Forms.Timer(Me.components)
        Me.CtlMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuAdd = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRun = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnufilter = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuNoFilter = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRefresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSetup = New System.Windows.Forms.ToolStripMenuItem()
        Me.gv = New System.Windows.Forms.DataGridView()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdExport = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.cmdSetup = New System.Windows.Forms.Button()
        Me.cmdRefresh = New System.Windows.Forms.Button()
        Me.cmdPrint = New System.Windows.Forms.Button()
        Me.cmdRun = New System.Windows.Forms.Button()
        Me.cmdClearFilter = New System.Windows.Forms.Button()
        Me.cmdFilter = New System.Windows.Forms.Button()
        Me.cmdEdit = New System.Windows.Forms.Button()
        Me.cmdAdd = New System.Windows.Forms.Button()
        Me.cmdDel = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CtlMenu.SuspendLayout()
        CType(Me.gv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'RefreshTimer
        '
        Me.RefreshTimer.Interval = 10000
        '
        'CtlMenu
        '
        Me.CtlMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAdd, Me.mnuEdit, Me.mnuDelete, Me.mnuRun, Me.mnuPrint, Me.mnufilter, Me.mnuNoFilter, Me.mnuRefresh, Me.mnuSetup})
        Me.CtlMenu.Name = "CtlMenu"
        Me.CtlMenu.ShowItemToolTips = False
        Me.CtlMenu.Size = New System.Drawing.Size(167, 202)
        '
        'mnuAdd
        '
        Me.mnuAdd.Name = "mnuAdd"
        Me.mnuAdd.Size = New System.Drawing.Size(166, 22)
        Me.mnuAdd.Text = "Создать"
        '
        'mnuEdit
        '
        Me.mnuEdit.Name = "mnuEdit"
        Me.mnuEdit.Size = New System.Drawing.Size(166, 22)
        Me.mnuEdit.Text = "Изменить"
        '
        'mnuDelete
        '
        Me.mnuDelete.Name = "mnuDelete"
        Me.mnuDelete.Size = New System.Drawing.Size(166, 22)
        Me.mnuDelete.Text = "Удалить"
        '
        'mnuRun
        '
        Me.mnuRun.Name = "mnuRun"
        Me.mnuRun.Size = New System.Drawing.Size(166, 22)
        Me.mnuRun.Text = "Открыть"
        '
        'mnuPrint
        '
        Me.mnuPrint.Name = "mnuPrint"
        Me.mnuPrint.Size = New System.Drawing.Size(166, 22)
        Me.mnuPrint.Text = "Печать"
        Me.mnuPrint.Visible = False
        '
        'mnufilter
        '
        Me.mnufilter.Name = "mnufilter"
        Me.mnufilter.Size = New System.Drawing.Size(166, 22)
        Me.mnufilter.Text = "Фильтр"
        Me.mnufilter.Visible = False
        '
        'mnuNoFilter
        '
        Me.mnuNoFilter.Name = "mnuNoFilter"
        Me.mnuNoFilter.Size = New System.Drawing.Size(166, 22)
        Me.mnuNoFilter.Text = "Отмена фильтра"
        '
        'mnuRefresh
        '
        Me.mnuRefresh.Name = "mnuRefresh"
        Me.mnuRefresh.Size = New System.Drawing.Size(166, 22)
        Me.mnuRefresh.Text = "Обновить"
        '
        'mnuSetup
        '
        Me.mnuSetup.Name = "mnuSetup"
        Me.mnuSetup.Size = New System.Drawing.Size(166, 22)
        Me.mnuSetup.Text = "Настроить"
        Me.mnuSetup.Visible = False
        '
        'gv
        '
        Me.gv.AllowUserToAddRows = False
        Me.gv.AllowUserToDeleteRows = False
        Me.gv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.gv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.gv.ContextMenuStrip = Me.CtlMenu
        Me.gv.Location = New System.Drawing.Point(0, 44)
        Me.gv.Name = "gv"
        Me.gv.ReadOnly = True
        Me.gv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gv.Size = New System.Drawing.Size(575, 278)
        Me.gv.TabIndex = 3
        Me.gv.Text = "gv"
        '
        'cmdExport
        '
        Me.cmdExport.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cmdExport.ImageKey = "xl.ico"
        Me.cmdExport.ImageList = Me.ImageList1
        Me.cmdExport.Location = New System.Drawing.Point(230, 8)
        Me.cmdExport.Name = "cmdExport"
        Me.cmdExport.Size = New System.Drawing.Size(27, 24)
        Me.cmdExport.TabIndex = 9
        Me.cmdExport.TabStop = False
        Me.cmdExport.Text = "&Э"
        Me.ToolTip1.SetToolTip(Me.cmdExport, "Экспорт")
        Me.cmdExport.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "box16.ico")
        Me.ImageList1.Images.SetKeyName(1, "card.ico")
        Me.ImageList1.Images.SetKeyName(2, "config_.ico")
        Me.ImageList1.Images.SetKeyName(3, "delete_.ico")
        Me.ImageList1.Images.SetKeyName(4, "DictSource2.ico")
        Me.ImageList1.Images.SetKeyName(5, "DictSource.ico")
        Me.ImageList1.Images.SetKeyName(6, "docchange.ICO")
        Me.ImageList1.Images.SetKeyName(7, "docdelete.ico")
        Me.ImageList1.Images.SetKeyName(8, "docdelete_.ico")
        Me.ImageList1.Images.SetKeyName(9, "DocJSource.ico")
        Me.ImageList1.Images.SetKeyName(10, "doclock.ico")
        Me.ImageList1.Images.SetKeyName(11, "docsave.ico")
        Me.ImageList1.Images.SetKeyName(12, "docSECURe_.ICO")
        Me.ImageList1.Images.SetKeyName(13, "docunlock.ICO")
        Me.ImageList1.Images.SetKeyName(14, "fileopen_.ico")
        Me.ImageList1.Images.SetKeyName(15, "filter_.ICO")
        Me.ImageList1.Images.SetKeyName(16, "find_.ico")
        Me.ImageList1.Images.SetKeyName(17, "printpreview_.ico")
        Me.ImageList1.Images.SetKeyName(18, "new_.ico")
        Me.ImageList1.Images.SetKeyName(19, "newroot_.ico")
        Me.ImageList1.Images.SetKeyName(20, "nofilter_.ICO")
        Me.ImageList1.Images.SetKeyName(21, "printpreview_.ico")
        Me.ImageList1.Images.SetKeyName(22, "imageopen.ico")
        Me.ImageList1.Images.SetKeyName(23, "imageopen_.ico")
        Me.ImageList1.Images.SetKeyName(24, "mailopen_.ico")
        Me.ImageList1.Images.SetKeyName(25, "new_.ico")
        Me.ImageList1.Images.SetKeyName(26, "newroot_.ico")
        Me.ImageList1.Images.SetKeyName(27, "nofilter_.ICO")
        Me.ImageList1.Images.SetKeyName(28, "switch_.ico")
        Me.ImageList1.Images.SetKeyName(29, "printpreview_.ico")
        Me.ImageList1.Images.SetKeyName(30, "prop_.ico")
        Me.ImageList1.Images.SetKeyName(31, "refopen.ico")
        Me.ImageList1.Images.SetKeyName(32, "refresh_.ico")
        Me.ImageList1.Images.SetKeyName(33, "run_.ico")
        Me.ImageList1.Images.SetKeyName(34, "save_.ico")
        Me.ImageList1.Images.SetKeyName(35, "Удалить.ico")
        Me.ImageList1.Images.SetKeyName(36, "Удалить.ico")
        Me.ImageList1.Images.SetKeyName(37, "Движение.ico")
        Me.ImageList1.Images.SetKeyName(38, "Добавить группу.ico")
        Me.ImageList1.Images.SetKeyName(39, "Документ.ico")
        Me.ImageList1.Images.SetKeyName(40, "Журнал.ico")
        Me.ImageList1.Images.SetKeyName(41, "Копировать.ico")
        Me.ImageList1.Images.SetKeyName(42, "На уровень вверх.ico")
        Me.ImageList1.Images.SetKeyName(43, "На уровень вниз.ico")
        Me.ImageList1.Images.SetKeyName(44, "Обновить.ico")
        Me.ImageList1.Images.SetKeyName(45, "Подчиненный справочник.ico")
        Me.ImageList1.Images.SetKeyName(46, "Редактировать.ico")
        Me.ImageList1.Images.SetKeyName(47, "Создать.ico")
        Me.ImageList1.Images.SetKeyName(48, "Сортировка.ico")
        Me.ImageList1.Images.SetKeyName(49, "Сохранить2.ico")
        Me.ImageList1.Images.SetKeyName(50, "Сохранить.ico")
        Me.ImageList1.Images.SetKeyName(51, "Справочник.ico")
        Me.ImageList1.Images.SetKeyName(52, "xl.ico")
        '
        'cmdSetup
        '
        Me.cmdSetup.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cmdSetup.ImageIndex = 41
        Me.cmdSetup.ImageList = Me.ImageList1
        Me.cmdSetup.Location = New System.Drawing.Point(198, 8)
        Me.cmdSetup.Name = "cmdSetup"
        Me.cmdSetup.Size = New System.Drawing.Size(27, 24)
        Me.cmdSetup.TabIndex = 8
        Me.cmdSetup.TabStop = False
        Me.cmdSetup.Text = "&Н"
        Me.ToolTip1.SetToolTip(Me.cmdSetup, "Настроить")
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cmdRefresh.ImageIndex = 44
        Me.cmdRefresh.ImageList = Me.ImageList1
        Me.cmdRefresh.Location = New System.Drawing.Point(136, 8)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(27, 24)
        Me.cmdRefresh.TabIndex = 7
        Me.cmdRefresh.TabStop = False
        Me.cmdRefresh.Text = "&О"
        Me.ToolTip1.SetToolTip(Me.cmdRefresh, "Обновить")
        '
        'cmdPrint
        '
        Me.cmdPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cmdPrint.ImageIndex = 40
        Me.cmdPrint.ImageList = Me.ImageList1
        Me.cmdPrint.Location = New System.Drawing.Point(168, 8)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(27, 24)
        Me.cmdPrint.TabIndex = 6
        Me.cmdPrint.TabStop = False
        Me.cmdPrint.Text = "&П"
        Me.ToolTip1.SetToolTip(Me.cmdPrint, "Печать")
        '
        'cmdRun
        '
        Me.cmdRun.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cmdRun.ImageIndex = 37
        Me.cmdRun.ImageList = Me.ImageList1
        Me.cmdRun.Location = New System.Drawing.Point(104, 8)
        Me.cmdRun.Name = "cmdRun"
        Me.cmdRun.Size = New System.Drawing.Size(27, 24)
        Me.cmdRun.TabIndex = 5
        Me.cmdRun.TabStop = False
        Me.cmdRun.Text = "&В"
        Me.ToolTip1.SetToolTip(Me.cmdRun, "Выполнить")
        '
        'cmdClearFilter
        '
        Me.cmdClearFilter.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cmdClearFilter.ImageIndex = 27
        Me.cmdClearFilter.ImageList = Me.ImageList1
        Me.cmdClearFilter.Location = New System.Drawing.Point(295, 8)
        Me.cmdClearFilter.Name = "cmdClearFilter"
        Me.cmdClearFilter.Size = New System.Drawing.Size(27, 24)
        Me.cmdClearFilter.TabIndex = 4
        Me.cmdClearFilter.TabStop = False
        Me.cmdClearFilter.Text = "&Б"
        Me.ToolTip1.SetToolTip(Me.cmdClearFilter, "Без фильтра")
        '
        'cmdFilter
        '
        Me.cmdFilter.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cmdFilter.ImageIndex = 15
        Me.cmdFilter.ImageList = Me.ImageList1
        Me.cmdFilter.Location = New System.Drawing.Point(263, 8)
        Me.cmdFilter.Name = "cmdFilter"
        Me.cmdFilter.Size = New System.Drawing.Size(27, 24)
        Me.cmdFilter.TabIndex = 3
        Me.cmdFilter.TabStop = False
        Me.cmdFilter.Text = "&Ф"
        Me.ToolTip1.SetToolTip(Me.cmdFilter, "Фильтр")
        '
        'cmdEdit
        '
        Me.cmdEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cmdEdit.ImageIndex = 46
        Me.cmdEdit.ImageList = Me.ImageList1
        Me.cmdEdit.Location = New System.Drawing.Point(40, 8)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(27, 24)
        Me.cmdEdit.TabIndex = 2
        Me.cmdEdit.TabStop = False
        Me.cmdEdit.Text = "&И"
        Me.ToolTip1.SetToolTip(Me.cmdEdit, "Изменить")
        '
        'cmdAdd
        '
        Me.cmdAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdAdd.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cmdAdd.ImageKey = "Создать.ico"
        Me.cmdAdd.ImageList = Me.ImageList1
        Me.cmdAdd.Location = New System.Drawing.Point(8, 8)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(27, 24)
        Me.cmdAdd.TabIndex = 1
        Me.cmdAdd.TabStop = False
        Me.cmdAdd.Text = "&С"
        Me.cmdAdd.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.ToolTip1.SetToolTip(Me.cmdAdd, "Создать")
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'cmdDel
        '
        Me.cmdDel.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cmdDel.ImageIndex = 35
        Me.cmdDel.ImageList = Me.ImageList1
        Me.cmdDel.Location = New System.Drawing.Point(72, 8)
        Me.cmdDel.Name = "cmdDel"
        Me.cmdDel.Size = New System.Drawing.Size(27, 24)
        Me.cmdDel.TabIndex = 0
        Me.cmdDel.TabStop = False
        Me.cmdDel.Text = "&У"
        Me.ToolTip1.SetToolTip(Me.cmdDel, "Удалить")
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.DefaultExt = "xls"
        Me.SaveFileDialog1.Title = "Файл для экспорта"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cmdExport)
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
        Me.Panel1.Size = New System.Drawing.Size(575, 38)
        Me.Panel1.TabIndex = 4
        '
        'JournalViewSTD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.gv)
        Me.Name = "JournalViewSTD"
        Me.Size = New System.Drawing.Size(575, 322)
        Me.CtlMenu.ResumeLayout(False)
        CType(Me.gv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Grid setup"

    Private m_NoStateColumn As Boolean
    Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal jdef As MTZJrnl.MTZJrnl.Application, ByVal parentForm As System.Windows.Forms.Form, Optional ByVal NoStateColumn As Boolean = True)
        mGuiManager = gm
        mjDef = jdef
        m_NoStateColumn = True
        mParentForm = parentForm
        CreateFromDef()
        RefreshData()
        RefreshTimer.Enabled = True
    End Sub

    Private Sub CreateFromDef()
        Dim dc As DataColumn

        Dim js As Long, idx As Long
        Dim rs As DataTable
        Dim JC As MTZJrnl.MTZJrnl.JournalColumn

again:
        On Error Resume Next


        If mjDef Is Nothing Then Exit Sub

        Dim column As System.Windows.Forms.DataGridViewColumn


        JDataTable = New DataTable
        JDataTable.Columns.Add("ID", GetType(System.Guid))
        JDataTable.Columns.Add("InstanceID", GetType(System.Guid))
        JDataTable.Columns.Add("ViewBase", GetType(System.String))
        JDataTable.Columns.Add("StatusName", GetType(System.String))





        gv.DataSource = Nothing
        gv.AutoGenerateColumns = False
        gv.Columns.Clear()


        Dim st_c As New DataGridViewCellStyle
        Dim st_r As New DataGridViewCellStyle
        Dim st_l As New DataGridViewCellStyle
        st_c.Alignment = DataGridViewContentAlignment.MiddleCenter
        st_l.Alignment = DataGridViewContentAlignment.MiddleLeft
        st_r.Alignment = DataGridViewContentAlignment.MiddleRight



        With gv
            column = New DataGridViewTextBoxColumn()
            column.HeaderText = "ID"
            column.Visible = False
            column.ValueType = GetType(System.Guid)
            column.Name = "ID"
            column.DataPropertyName = "ID"
            .Columns.Add(column)

            column = New DataGridViewTextBoxColumn()
            column.HeaderText = "InstanceID"
            column.Name = "InstanceID"
            column.DataPropertyName = "InstanceID"
            column.Visible = False
            column.ValueType = GetType(System.Guid)
            .Columns.Add(column)


            column = New DataGridViewTextBoxColumn()
            column.HeaderText = "ViewBase"
            column.Visible = False
            column.ValueType = GetType(System.String)
            column.Name = "ViewBase"
            column.DataPropertyName = "ViewBase"

            column.DefaultCellStyle = st_c
            column.HeaderCell.Style = st_c
            .Columns.Add(column)


            column = New DataGridViewTextBoxColumn()
            column.HeaderText = "Состояние"
            column.ValueType = GetType(System.String)
            column.Name = "StatusName"
            column.DataPropertyName = "StatusName"
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            If m_NoStateColumn Then column.Visible = False
            column.DefaultCellStyle = st_c
            column.HeaderCell.Style = st_c

            .Columns.Add(column)

            mjDef.JournalColumn.Sort = "sequence"

            For js = 1 To mjDef.JournalColumn.Count
                JC = mjDef.JournalColumn.Item(js)

                column = New DataGridViewTextBoxColumn()
                column.HeaderText = JC.name
                column.Name = JC.name
                column.DataPropertyName = JC.name
                column.DefaultCellStyle = st_c
                column.HeaderCell.Style = st_c



                If JC.ColSort = enumColumnSortType.ColumnSortType_As_Date Then
                    JDataTable.Columns.Add(JC.name, GetType(System.DateTime))
                    column.ValueType = GetType(System.DateTime)
                    column.DefaultCellStyle = st_r
                End If
                If JC.ColSort = enumColumnSortType.ColumnSortType_As_Numeric Then
                    JDataTable.Columns.Add(JC.name, GetType(System.Double))
                    column.ValueType = GetType(System.Double)
                    column.DefaultCellStyle = st_r
                End If
                If JC.ColSort = enumColumnSortType.ColumnSortType_As_String Then
                    JDataTable.Columns.Add(JC.name, GetType(System.String))
                    column.ValueType = GetType(System.String)
                    column.DefaultCellStyle = st_l
                End If

                .Columns.Add(column)

            Next



        End With


        Exit Sub



    End Sub





    Public Sub RefreshData()

        If mjDef Is Nothing Then Exit Sub
        On Error GoTo bye
        If inRefresh Then Exit Sub
        inRefresh = True

        Dim cnt As Long

        Dim js As Long, idx As Long, i As Int64, j As Int64
        Dim rs As DataTable
        Dim JCS As MTZJrnl.MTZJrnl.JColumnSource
        Dim JC As MTZJrnl.MTZJrnl.JournalColumn
        Dim jsrc As MTZJrnl.MTZJrnl.JournalSrc
        Dim fltr As JFilter
        Dim lid As System.Guid, rid As Guid, vb As String = ""
        On Error Resume Next
        GetRowInfo(lid, rid, vb)



        LastCheckDate = mjDef.Session.GetServerTime()
        JDataTable.Rows.Clear()


        For js = 1 To mjDef.JournalSrc.Count
            jsrc = mjDef.JournalSrc.Item(js)

            fltr = Nothing
            On Error Resume Next
            fltr = CType(Filters.Item(jsrc.ViewAlias), JFilter)
            On Error GoTo bye
            If mjDef.Session.Language <> "" Then
                If Not fltr Is Nothing Then
                    rs = mjDef.Session.GetRowsDT("v_" & jsrc.ViewAlias + "_" + mjDef.Session.Language, "*", , , fltr.FilterString)
                Else
                    rs = mjDef.Session.GetRowsDT("v_" & jsrc.ViewAlias + "_" + mjDef.Session.Language, "*")
                End If
            Else
                If Not fltr Is Nothing Then
                    rs = mjDef.Session.GetRowsDT("v_" & jsrc.ViewAlias, "*", , , fltr.FilterString)
                Else
                    rs = mjDef.Session.GetRowsDT("v_" & jsrc.ViewAlias, "*")
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
                    dr("StatusName") = rs.Rows(k).Item("StatusName")
                    JDataTable.Rows.Add(dr)
                Next
            End If

        Next

        JDataTable.TableName = "Journal" & CType(mjDef.Journal.Item(1), Journal).the_Alias

        gv.DataSource = JDataTable




        If Not rid.Equals(Guid.Empty) Then
            FindRowByFiled("ID", rid)

        ElseIf JDataTable.Rows.Count > 0 Then

            FindRowByFiled("ID", JDataTable.Rows(0)("ID"))
        End If


        inRefresh = False

        Exit Sub
bye:

        MsgBox(Err.Description, MsgBoxStyle.Critical And MsgBoxStyle.OkOnly, "Обновление журнала")
        inRefresh = False
    End Sub
#End Region


    Private Function FindRowByFiled(ByVal FieldName As String, ByVal Value As Object) As System.Windows.Forms.DataGridViewRow
        Dim row As System.Windows.Forms.DataGridViewRow
        row = FindRowByFiledInCol(gv.Rows, FieldName, Value)
        If Not row Is Nothing Then
            gv.ClearSelection()
            row.Selected = True
        End If
        Return row
    End Function

    Private Function FindRowByFiledInCol(ByVal Rows As DataGridViewRowCollection, ByVal FieldName As String, ByVal Value As Object) As System.Windows.Forms.DataGridViewRow
        Dim i As Integer, j As Integer
        Dim row As System.Windows.Forms.DataGridViewRow

        For i = 0 To Rows.Count - 1
            ' If Rows(i).IsDataRow Then
            If Rows(i).Cells(FieldName).Value.Equals(Value) Then
                Return Rows(i)
            End If
            'ElseIf Rows(i).IsGroupByRow Then
            'Rows(i).Expanded = True
            'For j = 0 To Rows(i).ChildBands.Count - 1
            '    row = FindRowByFiledInCol(Rows(i).ChildBands(j).Rows, FieldName, Value)
            '    If Not row Is Nothing Then
            '        Return row
            '    End If
            'Next
            'End If
        Next

        Return Nothing
    End Function


#Region "Properties"

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
                cmdFilter.Visible = True
            Else
                cmdFilter.Enabled = False
                cmdFilter.Visible = False
            End If
            mnufilter.Visible = cmdFilter.Enabled

            If V Then
                cmdClearFilter.Enabled = True
                cmdClearFilter.Visible = True
            Else
                cmdClearFilter.Enabled = False
                cmdClearFilter.Visible = False
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


#End Region



#Region "Commad behavor"




    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        Dim UseDefault As Boolean = True, RefreshJV As Boolean = False
        Dim InstanceID As System.Guid, RowID As System.Guid
        Dim ViewBase As String = String.Empty
        If Not gv.SelectedRows Is Nothing AndAlso gv.SelectedRows.Count = 1 Then
            GetRowInfo(InstanceID, RowID, ViewBase)
            RaiseEvent JVOnPrint(InstanceID, RowID, ViewBase, UseDefault)
            If UseDefault Then
                'gv.PrintPreview()

            End If
        End If
    End Sub





    Private Sub GetRowInfo(ByRef InstanceID As System.Guid, ByRef RowID As System.Guid, ByRef ViewBase As String)

        Dim UGRow As DataGridViewRow
        Try
            UGRow = gv.CurrentRow
        Catch ex As Exception
            UGRow = Nothing
        End Try

        InstanceID = System.Guid.Empty
        RowID = System.Guid.Empty
        ViewBase = ""

        Try
            If Not UGRow Is Nothing Then

                RowID = New Guid(UGRow.Cells("ID").Value.ToString())
                InstanceID = New Guid(UGRow.Cells("InstanceID").Value.ToString())
                ViewBase = UGRow.Cells("ViewBase").Value.ToString()

            End If
        Catch
        End Try
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Dim UseDefault As Boolean = True, RefreshJV As Boolean = True
        RaiseEvent JVOnAdd(UseDefault, RefreshJV)
        If RefreshJV Then
            RefreshData()
        End If
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        Dim UseDefault As Boolean = True, RefreshJV As Boolean = True
        Dim InstanceID As System.Guid, RowID As System.Guid
        Dim ViewBase As String = String.Empty
        If Not gv.CurrentRow Is Nothing Then
            GetRowInfo(InstanceID, RowID, ViewBase)
            RaiseEvent JVOnEdit(InstanceID, RowID, ViewBase, UseDefault, RefreshJV)
            If RefreshJV Then
                RefreshData()
            End If
        End If
    End Sub

    Private Sub cmdDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDel.Click
        Dim UseDefault As Boolean = True, RefreshJV As Boolean = True
        Dim InstanceID As System.Guid, RowID As System.Guid
        Dim ViewBase As String = String.Empty
        If Not gv.CurrentRow Is Nothing Then
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
        If Not gv.CurrentRow Is Nothing Then
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


    Private Sub gv_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim UseDefault As Boolean = True, RefreshJV As Boolean = False
        Dim InstanceID As System.Guid, RowID As System.Guid
        Dim ViewBase As String = String.Empty
        If Not gv.CurrentRow Is Nothing Then
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

    Private Sub cmdRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        RefreshData()
    End Sub

    Private Sub mnuAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuAdd.Click
        cmdAdd_Click(sender, e)
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
        RefreshData()
    End Sub

    Private Sub mnuRun_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuRun.Click
        cmdRun_Click(sender, e)
    End Sub


    'Private Sub mnuSetup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuSetup.Click
    '    cmdSetup_Click(sender, e)
    'End Sub



#End Region



    Private Sub JournalViewIG_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        gv.SetBounds(0, Panel1.Height, Panel1.Width, MyBase.ClientRectangle.Height - Panel1.Height)
    End Sub

    Private Sub gv_AfterRowActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv.CellEnter
        Dim InstanceID As System.Guid, RowID As System.Guid
        Dim ViewBase As String = String.Empty
        If Not gv.CurrentRow Is Nothing Then
            GetRowInfo(InstanceID, RowID, ViewBase)
            RaiseEvent JVOnRowChange(InstanceID, RowID, ViewBase)
        End If
    End Sub
    Private inRefresh As Boolean

    Private Sub RefreshTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshTimer.Tick

        'RefreshData()
    End Sub

    Private Sub gv_DoubleClickRow(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles gv.CellDoubleClick
        'cmdRun_Click(sender, e)
        Dim UseDefault As Boolean = True, RefreshJV As Boolean = False
        Dim InstanceID As System.Guid, RowID As System.Guid
        Dim ViewBase As String = String.Empty
        If Not gv.CurrentRow Is Nothing Then
            GetRowInfo(InstanceID, RowID, ViewBase)
            RaiseEvent JVOnDblClick(InstanceID, RowID, ViewBase, UseDefault, RefreshJV)
            If UseDefault Then
                If cmdRun.Enabled Then
                    cmdRun_Click(sender, e)
                ElseIf cmdEdit.Enabled Then
                    cmdEdit_Click(sender, e)
                End If
            End If
            If RefreshJV Then
                RefreshData()
            End If
        End If
    End Sub




    Private Sub cmdExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExport.Click
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            'UltraGridExcelExporter1.Export(gv, SaveFileDialog1.FileName)
        End If
    End Sub

    Public ReadOnly Property Filters() As JFilters
        Get
            Return mFilter
        End Get
    End Property

    Private Sub CtlMenu_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles CtlMenu.Opening

    End Sub


End Class