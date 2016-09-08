Imports System.IO
Imports System.Drawing

Public Class GridView
    Inherits GridControlParent

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
    Friend WithEvents gr As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents mnuService As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuAdd As System.Windows.Forms.MenuItem
    Friend WithEvents mnuEdit As System.Windows.Forms.MenuItem
    Friend WithEvents mnuDel As System.Windows.Forms.MenuItem
    Friend WithEvents mnuRefresh As System.Windows.Forms.MenuItem
    Friend WithEvents mnuFind As System.Windows.Forms.MenuItem
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ButtonsGrid As LATIR2GUIControls.Buttons
    Friend WithEvents mnuProp As System.Windows.Forms.MenuItem
    Friend WithEvents mnuRun As System.Windows.Forms.MenuItem
    Friend WithEvents mnuPrint As System.Windows.Forms.MenuItem
    Friend WithEvents PanelButtons As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gr = New System.Windows.Forms.DataGridView()
        Me.mnuService = New System.Windows.Forms.ContextMenu()
        Me.mnuAdd = New System.Windows.Forms.MenuItem()
        Me.mnuEdit = New System.Windows.Forms.MenuItem()
        Me.mnuDel = New System.Windows.Forms.MenuItem()
        Me.mnuRefresh = New System.Windows.Forms.MenuItem()
        Me.mnuFind = New System.Windows.Forms.MenuItem()
        Me.mnuProp = New System.Windows.Forms.MenuItem()
        Me.mnuRun = New System.Windows.Forms.MenuItem()
        Me.mnuPrint = New System.Windows.Forms.MenuItem()
        Me.PanelButtons = New System.Windows.Forms.Panel()
        Me.ButtonsGrid = New LATIR2GUIControls.Buttons()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.gr, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelButtons.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.SuspendLayout()
        '
        'gr
        '
        Me.gr.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.gr.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gr.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gr.ColumnHeadersHeight = 60
        Me.gr.ContextMenu = Me.mnuService
        Me.gr.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gr.Location = New System.Drawing.Point(0, 0)
        Me.gr.Name = "gr"
        Me.gr.ReadOnly = True
        Me.gr.RowHeadersWidth = 10
        Me.gr.Size = New System.Drawing.Size(808, 474)
        Me.gr.TabIndex = 0
        '
        'mnuService
        '
        Me.mnuService.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuAdd, Me.mnuEdit, Me.mnuDel, Me.mnuRefresh, Me.mnuFind, Me.mnuProp, Me.mnuRun, Me.mnuPrint})
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
        'mnuFind
        '
        Me.mnuFind.Index = 4
        Me.mnuFind.Text = "Поиск"
        '
        'mnuProp
        '
        Me.mnuProp.Index = 5
        Me.mnuProp.Text = "Свойства"
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
        'PanelButtons
        '
        Me.PanelButtons.Controls.Add(Me.ButtonsGrid)
        Me.PanelButtons.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelButtons.Location = New System.Drawing.Point(0, 0)
        Me.PanelButtons.Name = "PanelButtons"
        Me.PanelButtons.Size = New System.Drawing.Size(808, 30)
        Me.PanelButtons.TabIndex = 13
        '
        'ButtonsGrid
        '
        Me.ButtonsGrid.AllowAdd = True
        Me.ButtonsGrid.AllowAddRoot = False
        Me.ButtonsGrid.AllowDel = True
        Me.ButtonsGrid.AllowEdit = True
        Me.ButtonsGrid.AllowFind = True
        Me.ButtonsGrid.AllowPrint = True
        Me.ButtonsGrid.AllowProp = True
        Me.ButtonsGrid.AllowRefresh = True
        Me.ButtonsGrid.AllowRun = True
        Me.ButtonsGrid.Dock = System.Windows.Forms.DockStyle.Left
        Me.ButtonsGrid.Location = New System.Drawing.Point(0, 0)
        Me.ButtonsGrid.Name = "ButtonsGrid"
        Me.ButtonsGrid.Size = New System.Drawing.Size(920, 30)
        Me.ButtonsGrid.TabIndex = 0
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.gr)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(0, 30)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(808, 474)
        Me.Panel7.TabIndex = 14
        '
        'GridView
        '
        Me.ContextMenu = Me.mnuService
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.PanelButtons)
        Me.Name = "GridView"
        Me.Size = New System.Drawing.Size(808, 504)
        CType(Me.gr, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelButtons.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Declarations"
    Private mAllowToolBar As Boolean
#End Region

#Region "Public Functions Properties"
    Public ReadOnly Property Grid() As System.Windows.Forms.DataGridView
        Get
            Return gr
        End Get
    End Property

    Public Overloads Sub InitFields(ByVal ts As DataGridTableStyle)
        MyBase.InitFields(ts, gr)
    End Sub

    Public Overloads Sub SetData(ByVal dt As DataTable, Optional ByVal IsChild As Boolean = False)
        MyBase.SetData(dt, gr, IsChild)
    End Sub

    Public Overloads Sub ClearCell()
        MyBase.ClearCell(gr)
    End Sub

    Public Property AllowToolBar() As Boolean
        Get
            Return mAllowToolBar
        End Get
        Set(ByVal Value As Boolean)
            mAllowToolBar = Value
            ButtonsGrid.Visible = mAllowToolBar
            PanelButtons.Visible = mAllowToolBar
        End Set
    End Property

#End Region

#Region "Grid Events"
    Private Sub gr_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gr.CurrentCellChanged
        Try
            If (Not gr.CurrentCell Is Nothing) Then
                RowColChange(New Guid(gr.Rows.Item(gr.CurrentCell.RowIndex).Cells.Item("ID").Value.ToString()))
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub gr_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gr.MouseUp
        If e.Button = System.Windows.Forms.MouseButtons.Right Then
            Dim pos As System.Drawing.Point
            pos = New System.Drawing.Point
            pos.X = e.X
            pos.Y = e.Y
            gr.ContextMenu.Show(gr, pos)
        End If
    End Sub

    Private Sub gr_DoubleClick(sender As Object, e As EventArgs) Handles gr.DoubleClick
        GridEdit(gr)
    End Sub
#End Region

#Region "Main Service Menu Events"
    Private Sub mnuAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAdd.Click
        If (GridAdd(Nothing)) Then
            '...
        End If
    End Sub

    Private Sub mnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEdit.Click
        If (GridEdit(gr)) Then
            '...
        End If
    End Sub

    Private Sub mnuDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDel.Click
        Dim dt As DataTable
        dt = gr.DataSource
        If dt.Rows.Count > 0 Then
            If gr.CurrentCell.RowIndex >= 0 Then
                If (GridDel(dt.DefaultView.Item(gr.CurrentCell.RowIndex).Item(Constants.FIELD_ID))) Then
                    '...
                End If
            End If
        End If
    End Sub

    Private Sub mnuFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFind.Click
        If (GridFind(gr)) Then
            ' ...
        End If
    End Sub

    Private Sub mnuRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuRefresh.Click
        If (GridRefresh()) Then
            ' ...
        End If
    End Sub

    Private Sub mnuProp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuProp.Click
        If (GridProp(gr)) Then
            ' ...
        End If
    End Sub

    Private Sub mnuPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrint.Click
        If (GridPrint(gr)) Then
            ' ...
        End If
    End Sub

    Private Sub mnuRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRun.Click
        If (GridRun(gr)) Then
            ' ...
        End If
    End Sub
#End Region

#Region "Buttons Grid Events"
    Private Sub ButtonsGrid_OnAdd() Handles ButtonsGrid.OnAdd
        mnuAdd_Click(Nothing, Nothing)
    End Sub

    Private Sub ButtonsGrid_OnDel() Handles ButtonsGrid.OnDel
        mnuDel_Click(Nothing, Nothing)
    End Sub

    Private Sub ButtonsGrid_OnEdit() Handles ButtonsGrid.OnEdit
        mnuEdit_Click(Nothing, Nothing)
    End Sub

    Private Sub ButtonsGrid_OnFind() Handles ButtonsGrid.OnFind
        mnuFind_Click(Nothing, Nothing)
    End Sub

    Private Sub ButtonsGrid_OnPrint() Handles ButtonsGrid.OnPrint
        mnuPrint_Click(Nothing, Nothing)
    End Sub

    Private Sub ButtonsGrid_OnProp() Handles ButtonsGrid.OnProp
        mnuProp_Click(Nothing, Nothing)
    End Sub

    Private Sub ButtonsGrid_OnRefresh() Handles ButtonsGrid.OnRefresh
        mnuRefresh_Click(Nothing, Nothing)
    End Sub

    Private Sub ButtonsGrid_OnRun() Handles ButtonsGrid.OnRun
        mnuRun_Click(Nothing, Nothing)
    End Sub


#End Region

End Class
