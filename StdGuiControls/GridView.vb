Imports System.IO
Imports System.Drawing
Imports System.Drawing.Printing
Imports SpreadsheetLight
Imports DocumentFormat.OpenXml


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
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents mnuExport As MenuItem
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
        Me.mnuExport = New System.Windows.Forms.MenuItem()
        Me.mnuProp = New System.Windows.Forms.MenuItem()
        Me.mnuRun = New System.Windows.Forms.MenuItem()
        Me.mnuPrint = New System.Windows.Forms.MenuItem()
        Me.PanelButtons = New System.Windows.Forms.Panel()
        Me.ButtonsGrid = New LATIR2GUIControls.Buttons()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
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
        Me.mnuService.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuAdd, Me.mnuEdit, Me.mnuDel, Me.mnuRefresh, Me.mnuFind, Me.mnuExport, Me.mnuProp, Me.mnuRun, Me.mnuPrint})
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
        'mnuExport
        '
        Me.mnuExport.Index = 5
        Me.mnuExport.Text = "Экспорт"
        '
        'mnuProp
        '
        Me.mnuProp.Index = 6
        Me.mnuProp.Text = "Свойства"
        '
        'mnuRun
        '
        Me.mnuRun.Index = 7
        Me.mnuRun.Text = "Открыть"
        '
        'mnuPrint
        '
        Me.mnuPrint.Index = 8
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
        Me.ButtonsGrid.AllowFind = False
        Me.ButtonsGrid.AllowPrint = True
        Me.ButtonsGrid.AllowProp = False
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
        'PrintDocument1
        '
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
            If Not gr.CurrentCell Is Nothing Then
                If gr.CurrentCell.RowIndex >= 0 Then
                    If (GridDel(dt.DefaultView.Item(gr.CurrentCell.RowIndex).Item(Constants.FIELD_ID))) Then
                        '...
                    End If
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
        If (GridEdit(gr)) Then
            '...
        End If
    End Sub
    Public Sub PrintPreview()
        Dim printDialog As PrintPreviewDialog = New PrintPreviewDialog
        Dim sz As New SizeF(2.0, 2.0)

        printDialog.Scale(sz)
        'PrintDocument1.DefaultPageSettings.PaperSize =  New System.Drawing.Printing.PaperSize()
        PrintDocument1.DefaultPageSettings.Landscape = True
        printDialog.WindowState = FormWindowState.Maximized

        printDialog.Document = PrintDocument1
        printDialog.ShowDialog()

    End Sub
    Private Sub mnuPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrint.Click
        If (GridPrint(gr)) Then
            PrintPreview()
        End If
    End Sub

    Public Sub ExportGrid()
        SaveFileDialog1.CheckPathExists = True
        SaveFileDialog1.DefaultExt = "xlsx"
        SaveFileDialog1.Filter = "Excel|*.xlsx"
        SaveFileDialog1.OverwritePrompt = True
        SaveFileDialog1.Title = "Сохранение в файл"

        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim SLD As SLDocument
            SLD = New SLDocument

            Dim row As Integer

            Dim col As Integer
            Dim hstyle As SLStyle

            Dim cstyle As SLStyle
            hstyle = SLD.CreateStyle()
            hstyle.Font.FontSize = 15
            hstyle.Font.Bold = True
            hstyle.Font.Underline = Spreadsheet.UnderlineValues.Single

            Dim border As SLBorder
            border = SLD.CreateBorder()
            border.BottomBorder.BorderStyle = Spreadsheet.BorderStyleValues.Thin
            border.BottomBorder.Color = Color.Black

            border.LeftBorder.BorderStyle = Spreadsheet.BorderStyleValues.Thin
            border.LeftBorder.Color = Color.Black
            hstyle.Border = border


            cstyle = SLD.CreateStyle()
            cstyle.Font.FontSize = 12
            ' cstyle.Font.Bold = True
            ' cstyle.Font.Underline = Spreadsheet.UnderlineValues.Single

            Dim border2 As SLBorder
            border2 = SLD.CreateBorder()
            border2.BottomBorder.BorderStyle = Spreadsheet.BorderStyleValues.Dashed
            border2.BottomBorder.Color = Color.Black

            border2.LeftBorder.BorderStyle = Spreadsheet.BorderStyleValues.Dashed
            border2.LeftBorder.Color = Color.Black
            cstyle.Border = border2

            'Dim cell As SLCell
            'Dim sp As SLCellPoint

            Dim cols(gr.Columns.Count) As Integer
            Dim visibleCount As Integer = 0


            For col = 0 To gr.Columns.Count - 1
                If gr.Columns.Item(col).Visible = True Then
                    cols(visibleCount) = col
                    visibleCount += 1
                End If
            Next


            For col = 0 To visibleCount - 1

                Try
                    SLD.SetCellValue(1, col + 1, gr.Columns.Item(cols(col)).HeaderText)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

                SLD.SetCellStyle(1, col + 1, hstyle)
                'sp = New SLCellPoint(1, col)
                'cell = SLD.GetCells(sp)
                SLD.SetColumnWidth(col + 1, gr.Columns.Item(cols(col)).Width / 8)


            Next

            For row = 0 To gr.Rows.Count - 1
                For col = 0 To visibleCount - 1
                    'Try

                    '    If IsDate(gr.Rows.Item(row).Cells.Item(cols(col)).Value) Then
                    '        If gr.Rows.Item(row).Cells.Item(cols(col)).Value.Equals(DateTime.MinValue) Then
                    '            SLD.SetCellValue(row + 2, col + 1, "")
                    '        Else
                    '            SLD.SetCellValue(row + 2, col + 1, gr.Rows.Item(row).Cells.Item(cols(col)).Value.ToString())
                    '        End If
                    '    Else
                    '        SLD.SetCellValue(row + 2, col + 1, gr.Rows.Item(row).Cells.Item(cols(col)).Value.ToString())
                    '    End If


                    'Catch ex As Exception
                    '    MsgBox(ex.Message)
                    'End Try

                    Try

                        If IsDate(gr.Rows.Item(row).Cells.Item(cols(col)).Value) Then
                            Dim d As DateTime
                            d = gr.Rows.Item(row).Cells.Item(cols(col)).Value

                            If d.Equals(DateTime.MinValue) Then
                                SLD.SetCellValue(row + 2, col + 1, "")
                            Else

                                If d.Hour = 0 And d.Minute = 0 And d.Second = 0 Then
                                    SLD.SetCellValue(row + 2, col + 1, d.ToString("dd/MM/yyyy"))
                                Else
                                    SLD.SetCellValue(row + 2, col + 1, d.ToString("dd/MM/yyyy HH:mm:ss"))
                                End If
                            End If
                        Else
                            SLD.SetCellValue(row + 2, col + 1, gr.Rows.Item(row).Cells.Item(cols(col)).Value.ToString())
                        End If


                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try

                    SLD.SetCellStyle(row + 2, col + 1, cstyle)
                    'sp = New SLCellPoint(row + 2, col)
                    'cell = SLD.GetCells(sp)
                Next
            Next

            'cell = ws.Cells(0, 0)
            'cell.Value = Caption
            'cell.Style = hstyle

            SLD.SaveAs(SaveFileDialog1.FileName)
            'outworkbook.Save()
            'wb.ReleaseLock()
            MsgBox("Файл сохранен")
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

    Private Sub ButtonsGrid_OnExport() Handles ButtonsGrid.OnExport
        mnuExport_Click(Nothing, Nothing)
    End Sub

    Private Sub ButtonsGrid_OnRefresh() Handles ButtonsGrid.OnRefresh
        mnuRefresh_Click(Nothing, Nothing)
    End Sub

    Private Sub ButtonsGrid_OnRun() Handles ButtonsGrid.OnRun
        mnuRun_Click(Nothing, Nothing)
    End Sub
#End Region

#Region "print support"
    Dim strFormat As StringFormat
    Dim arrColumnLefts As ArrayList = New ArrayList
    Dim arrColumnWidths As ArrayList = New ArrayList
    Dim iCellHeight As Integer = 0
    Dim iTotalWidth As Integer = 0
    Dim iRow As Integer = 0
    Dim bFirstPage As Boolean = False
    Dim bNewPage As Boolean = False
    Dim iHeaderHeight As Integer = 0

    Private Sub printDocument1_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PrintDocument1.BeginPrint
        Try
            strFormat = New StringFormat
            strFormat.Alignment = StringAlignment.Near
            strFormat.LineAlignment = StringAlignment.Center
            strFormat.Trimming = StringTrimming.EllipsisCharacter
            arrColumnLefts.Clear()
            arrColumnWidths.Clear()
            iCellHeight = 0
            iRow = 0
            bFirstPage = True
            bNewPage = True
            ' Calculating Total Widths
            iTotalWidth = 0
            For Each dgvGridCol As DataGridViewColumn In gr.Columns
                If dgvGridCol.Visible = True Then
                    iTotalWidth = (iTotalWidth + dgvGridCol.Width)
                End If

            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub printDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Try
            'Set the left margin
            Dim iLeftMargin As Integer = e.MarginBounds.Left
            'Set the top margin
            Dim iTopMargin As Integer = e.MarginBounds.Top
            Dim pw As Double
            'Whether more pages have to print or not
            Dim bMorePagesToPrint As Boolean = False
            Dim iTmpWidth As Integer = 0
            pw = CType(e.MarginBounds.Width, Double)
            'pw = CType(e.PageBounds.Width, Double)

            'For the first page to print set the cell width and header height
            If bFirstPage Then
                For Each GridCol As DataGridViewColumn In gr.Columns
                    If GridCol.Visible = True Then
                        iTmpWidth = CType(System.Math.Floor(CType(GridCol.Width, Double) / CType(iTotalWidth, Double) * CType(pw, Double)), Integer)
                        iHeaderHeight = (CType(e.Graphics.MeasureString(GridCol.HeaderText, GridCol.InheritedStyle.Font, iTmpWidth).Height, Integer) + 11)

                        ' Save width and height of headres
                        arrColumnLefts.Add(iLeftMargin)
                        arrColumnWidths.Add(iTmpWidth)
                        iLeftMargin = (iLeftMargin + iTmpWidth)
                    End If

                Next
            End If

            'Loop till all the grid rows not get printed

            While (iRow _
                        <= (gr.Rows.Count - 1))
                Dim GridRow As DataGridViewRow = gr.Rows(iRow)
                'Set the cell height
                iCellHeight = (GridRow.Height + 5)
                Dim iCount As Integer = 0
                'Check whether the current page settings allo more rows to print
                If (iTopMargin + iCellHeight >= (e.MarginBounds.Height + e.MarginBounds.Top)) Then
                    bNewPage = True
                    bFirstPage = False
                    bMorePagesToPrint = True
                    Exit While
                Else
                    If bNewPage Then

                        'Draw Columns                 
                        iTopMargin = e.MarginBounds.Top
                        For Each GridCol As DataGridViewColumn In gr.Columns
                            If GridCol.Visible = True Then
                                e.Graphics.FillRectangle(New SolidBrush(Color.LightGray), New Rectangle(CType(arrColumnLefts(iCount), Integer), iTopMargin, CType(arrColumnWidths(iCount), Integer), iHeaderHeight))
                                e.Graphics.DrawRectangle(Pens.Black, New Rectangle(CType(arrColumnLefts(iCount), Integer), iTopMargin, CType(arrColumnWidths(iCount), Integer), iHeaderHeight))
                                e.Graphics.DrawString(GridCol.HeaderText, GridCol.InheritedStyle.Font, New SolidBrush(GridCol.InheritedStyle.ForeColor), New RectangleF(CType(arrColumnLefts(iCount), Integer), iTopMargin, CType(arrColumnWidths(iCount), Integer), iHeaderHeight), strFormat)
                                iCount = (iCount + 1)
                            End If
                        Next
                        bNewPage = False
                        iTopMargin = (iTopMargin + iHeaderHeight)
                    End If

                    iCount = 0
                    'Draw Columns Contents                
                    For Each Cel As DataGridViewCell In GridRow.Cells
                        If Cel.OwningColumn.Visible = True Then
                            If (Not (Cel.Value) Is Nothing) Then
                                e.Graphics.DrawString(Cel.Value.ToString, Cel.InheritedStyle.Font, New SolidBrush(Cel.InheritedStyle.ForeColor), New RectangleF(CType(arrColumnLefts(iCount), Integer), CType(iTopMargin, Single), CType(arrColumnWidths(iCount), Integer), CType(iCellHeight, Single)), strFormat)
                            End If

                            'Drawing Cells Borders 
                            e.Graphics.DrawRectangle(Pens.Black, New Rectangle(CType(arrColumnLefts(iCount), Integer), iTopMargin, CType(arrColumnWidths(iCount), Integer), iCellHeight))
                            iCount = (iCount + 1)
                        End If

                    Next
                End If

                iRow = (iRow + 1)
                iTopMargin = (iTopMargin + iCellHeight)

            End While

            'If more lines exist, print another page.
            If bMorePagesToPrint Then
                e.HasMorePages = True
            Else
                e.HasMorePages = False
            End If

        Catch exc As Exception
            MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub mnuExport_Click(sender As Object, e As EventArgs) Handles mnuExport.Click
        ExportGrid()
    End Sub

    Private Sub ButtonsGrid_OnProp() Handles ButtonsGrid.OnProp
        mnuProp_Click(Nothing, Nothing)
    End Sub

    Private Sub ButtonsGrid_Load(sender As Object, e As EventArgs) Handles ButtonsGrid.Load

    End Sub

#End Region


End Class
