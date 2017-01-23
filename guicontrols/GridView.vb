Imports System.IO
Imports System.Drawing
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class GridView
    Inherits GridControlParent

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        ButtonUtils.PrepareForm(ToolTip1, Me.Controls)
        ButtonsGrid.AllowFind = False
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
    Friend WithEvents gr As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents XL As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents SFD As System.Windows.Forms.SaveFileDialog
    Friend WithEvents PanelButtons As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.mnuService = New System.Windows.Forms.ContextMenu
        Me.mnuAdd = New System.Windows.Forms.MenuItem
        Me.mnuEdit = New System.Windows.Forms.MenuItem
        Me.mnuDel = New System.Windows.Forms.MenuItem
        Me.mnuRefresh = New System.Windows.Forms.MenuItem
        Me.mnuFind = New System.Windows.Forms.MenuItem
        Me.mnuProp = New System.Windows.Forms.MenuItem
        Me.mnuRun = New System.Windows.Forms.MenuItem
        Me.mnuPrint = New System.Windows.Forms.MenuItem
        Me.PanelButtons = New System.Windows.Forms.Panel
        Me.ButtonsGrid = New LATIR2GUIControls.Buttons
        Me.Panel7 = New System.Windows.Forms.Panel
        Me.gr = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.XL = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.SFD = New System.Windows.Forms.SaveFileDialog
        Me.PanelButtons.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.gr, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.ButtonsGrid.AllowExport = True
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
        'gr
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gr.DisplayLayout.Appearance = Appearance1
        Me.gr.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gr.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.gr.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gr.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.gr.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gr.DisplayLayout.GroupByBox.Prompt = "Перетащить для группировки"
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gr.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.gr.DisplayLayout.MaxColScrollRegions = 1
        Me.gr.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gr.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.gr.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.gr.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.gr.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand
        Me.gr.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free
        Me.gr.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed
        Me.gr.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gr.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.gr.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.gr.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gr.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.gr.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gr.DisplayLayout.Override.CellAppearance = Appearance8
        Me.gr.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gr.DisplayLayout.Override.CellPadding = 0
        Me.gr.DisplayLayout.Override.ColumnSizingArea = Infragistics.Win.UltraWinGrid.ColumnSizingArea.HeadersOnly
        Me.gr.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Combo
        Me.gr.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.WithOperand
        Me.gr.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.HeaderIcons
        Me.gr.DisplayLayout.Override.FixedRowIndicator = Infragistics.Win.UltraWinGrid.FixedRowIndicator.None
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.gr.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.gr.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.gr.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.gr.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.gr.DisplayLayout.Override.RowAppearance = Appearance11
        Me.gr.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.gr.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.gr.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed
        Me.gr.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.gr.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.gr.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gr.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.gr.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.gr.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gr.Location = New System.Drawing.Point(0, 0)
        Me.gr.Name = "gr"
        Me.gr.Size = New System.Drawing.Size(808, 474)
        Me.gr.TabIndex = 0
        Me.gr.Text = "UltraGrid1"
        '
        'SFD
        '
        Me.SFD.DefaultExt = "xls"
        Me.SFD.Title = "Файл для экспорта"
        '
        'GridView
        '
        Me.ContextMenu = Me.mnuService
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.PanelButtons)
        Me.Name = "GridView"
        Me.Size = New System.Drawing.Size(808, 504)
        Me.PanelButtons.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        CType(Me.gr, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Declarations"
    Private mAllowToolBar As Boolean
#End Region

#Region "Public Functions Properties"
    Public ReadOnly Property Grid() As UltraWinGrid.UltraGrid
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

    Private Sub gr_InitializeGroupByRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeGroupByRowEventArgs) Handles gr.InitializeGroupByRow
        e.Row.Description = e.Row.Column.Header.Caption.ToString() & " : " & e.Row.Value.ToString()
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
    Public Sub GVGridEdit()
        GridEdit(gr)
    End Sub
    Public Sub GVGridAdd()
        GridAdd(Nothing)
    End Sub
    Public Sub GVGridDel(ByVal ID As Guid)
        GridDel(ID)
    End Sub
    Public Sub GVGridRefresh()
        GridRefresh()
    End Sub
    Public Sub GVGridProp()
        GridProp(gr)
    End Sub
    Public Sub GVGridPrint()
        GridPrint(gr)

    End Sub
    Public Sub GVGridRun()
        GridRun(gr)
    End Sub
    Public Sub GVGridFind()
        GridFind(gr)
    End Sub



#End Region

#Region "Grid Events"

    Private Sub gr_DoubleClickCell(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles gr.DoubleClickCell
        GridRun(gr)
    End Sub
    Private Sub gr_InitializePrintPreview(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelablePrintPreviewEventArgs) Handles gr.InitializePrintPreview

        ' Set the zomm level to 100 % in the print preview.
        e.PrintPreviewSettings.Zoom = 1.0

        ' Set the location and size of the print preview dialog.
        e.PrintPreviewSettings.DialogLeft = SystemInformation.WorkingArea.X
        e.PrintPreviewSettings.DialogTop = SystemInformation.WorkingArea.Y
        e.PrintPreviewSettings.DialogWidth = SystemInformation.WorkingArea.Width
        e.PrintPreviewSettings.DialogHeight = SystemInformation.WorkingArea.Height

        ' Horizontally fit everything in a signle page.
        e.DefaultLogicalPageLayoutInfo.FitWidthToPages = 1

        ' Set up the header and the footer.
        e.DefaultLogicalPageLayoutInfo.PageHeader = "Grid default print"
        e.DefaultLogicalPageLayoutInfo.PageHeaderHeight = 40
        e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.FontData.SizeInPoints = 14
        e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.TextHAlign = HAlign.Center
        e.DefaultLogicalPageLayoutInfo.PageHeaderBorderStyle = UIElementBorderStyle.Solid

        ' Use <#> token in the string to designate page numbers.
        e.DefaultLogicalPageLayoutInfo.PageFooter = "Page <#>."
        e.DefaultLogicalPageLayoutInfo.PageFooterHeight = 40
        e.DefaultLogicalPageLayoutInfo.PageFooterAppearance.TextHAlign = HAlign.Right
        e.DefaultLogicalPageLayoutInfo.PageFooterAppearance.FontData.Italic = DefaultableBoolean.True
        e.DefaultLogicalPageLayoutInfo.PageFooterBorderStyle = UIElementBorderStyle.Solid

        ' Set the ClippingOverride to Yes.
        e.DefaultLogicalPageLayoutInfo.ClippingOverride = ClippingOverride.Yes

        ' Set the document name through the PrintDocument which returns a PrintDocument object.
        e.PrintDocument.DocumentName = "Grid default print"

    End Sub

    Private Sub gr_AfterRowActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles gr.AfterRowActivate
        If gr.ActiveRow.IsDataRow Then
            'MsgBox("RC" + gr.ActiveRow.Cells(Constants.FIELD_ID).Value.ToString())
            RowColChange(New Guid(gr.ActiveRow.Cells(Constants.FIELD_ID).Value.ToString()))
        End If
    End Sub

    Private Sub gr_AfterSelectChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs) Handles gr.AfterSelectChange
        If gr.ActiveRow.IsDataRow Then
            'MsgBox("RC" + gr.ActiveRow.Cells(Constants.FIELD_ID).Value.ToString())
            RowColChange(New Guid(gr.ActiveRow.Cells(Constants.FIELD_ID).Value.ToString()))
        End If
    End Sub


    'Private Sub gr_AfterSelectChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs) Handles gr.AfterSelectChange
    '    If gr.ActiveRow.IsDataRow Then
    '        MsgBox("RC" + gr.ActiveRow.Cells(Constants.FIELD_ID).Value.ToString())
    '        RowColChange(New Guid(gr.ActiveRow.Cells(Constants.FIELD_ID).Value.ToString()))
    '    End If
    'End Sub



    'Private Sub gr_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gr.MouseUp

    'End Sub

    Private Sub gr_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gr.MouseUp
        If e.Button = System.Windows.Forms.MouseButtons.Right Then
            Dim pos As System.Drawing.Point
            pos = New System.Drawing.Point
            pos.X = e.X
            pos.Y = e.Y
            Try
                gr.ContextMenu.Show(gr, pos) '   .ContextMenu.Show(gr, pos)
            Catch
            End Try
        End If
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

        If Not gr.ActiveRow Is Nothing Then
            If gr.ActiveRow.IsDataRow Then
                If (GridDel(New Guid(gr.ActiveRow.Cells(LATIR2GUIControls.Constants.FIELD_ID).Value.ToString()))) Then

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

    Private Sub ButtonsGrid_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonsGrid.Load

    End Sub

  
    
    Private Sub ButtonsGrid_OnExport() Handles ButtonsGrid.OnExport
        If SFD.ShowDialog() = DialogResult.OK Then
            XL.Export(gr, SFD.FileName)
        End If
    End Sub
End Class
