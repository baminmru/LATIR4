Public Class frmPrintPreview
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
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
    Friend WithEvents tbPrintPreview As System.Windows.Forms.ToolBar
    Friend WithEvents PrintPreviewControl1 As System.Windows.Forms.PrintPreviewControl
    Friend WithEvents tbtnMoveUp As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbtnMoveDown As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbtnZoom100 As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbtnOnePage As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbtnTwoPages As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbtnPageSetup As System.Windows.Forms.ToolBarButton
    Friend WithEvents PageSetupDialog1 As System.Windows.Forms.PageSetupDialog
    Friend WithEvents ToolBarButton3 As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbtnPrint As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton4 As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbtnClose As System.Windows.Forms.ToolBarButton
    Friend WithEvents icons As System.Windows.Forms.ImageList
    Friend WithEvents tbtnSep1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbtnSep2 As System.Windows.Forms.ToolBarButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmPrintPreview))
        Me.tbPrintPreview = New System.Windows.Forms.ToolBar()
        Me.tbtnMoveUp = New System.Windows.Forms.ToolBarButton()
        Me.tbtnMoveDown = New System.Windows.Forms.ToolBarButton()
        Me.tbtnSep1 = New System.Windows.Forms.ToolBarButton()
        Me.tbtnZoom100 = New System.Windows.Forms.ToolBarButton()
        Me.tbtnOnePage = New System.Windows.Forms.ToolBarButton()
        Me.tbtnTwoPages = New System.Windows.Forms.ToolBarButton()
        Me.tbtnSep2 = New System.Windows.Forms.ToolBarButton()
        Me.tbtnPageSetup = New System.Windows.Forms.ToolBarButton()
        Me.ToolBarButton3 = New System.Windows.Forms.ToolBarButton()
        Me.tbtnPrint = New System.Windows.Forms.ToolBarButton()
        Me.ToolBarButton4 = New System.Windows.Forms.ToolBarButton()
        Me.tbtnClose = New System.Windows.Forms.ToolBarButton()
        Me.icons = New System.Windows.Forms.ImageList(Me.components)
        Me.PrintPreviewControl1 = New System.Windows.Forms.PrintPreviewControl()
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog()
        Me.SuspendLayout()
        '
        'tbPrintPreview
        '
        Me.tbPrintPreview.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbPrintPreview.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.tbtnMoveUp, Me.tbtnMoveDown, Me.tbtnSep1, Me.tbtnZoom100, Me.tbtnOnePage, Me.tbtnTwoPages, Me.tbtnSep2, Me.tbtnPageSetup, Me.ToolBarButton3, Me.tbtnPrint, Me.ToolBarButton4, Me.tbtnClose})
        Me.tbPrintPreview.DropDownArrows = True
        Me.tbPrintPreview.ImageList = Me.icons
        Me.tbPrintPreview.Name = "tbPrintPreview"
        Me.tbPrintPreview.ShowToolTips = True
        Me.tbPrintPreview.Size = New System.Drawing.Size(708, 25)
        Me.tbPrintPreview.TabIndex = 0
        Me.tbPrintPreview.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
        '
        'tbtnMoveUp
        '
        Me.tbtnMoveUp.ImageIndex = 0
        Me.tbtnMoveUp.Tag = "MoveUp"
        Me.tbtnMoveUp.ToolTipText = "Previous Page"
        '
        'tbtnMoveDown
        '
        Me.tbtnMoveDown.ImageIndex = 1
        Me.tbtnMoveDown.Tag = "MoveDown"
        Me.tbtnMoveDown.ToolTipText = "NextPage"
        '
        'tbtnSep1
        '
        Me.tbtnSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'tbtnZoom100
        '
        Me.tbtnZoom100.ImageIndex = 3
        Me.tbtnZoom100.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
        Me.tbtnZoom100.Tag = "Zoom100"
        Me.tbtnZoom100.ToolTipText = "Actual Size"
        '
        'tbtnOnePage
        '
        Me.tbtnOnePage.ImageIndex = 2
        Me.tbtnOnePage.Pushed = True
        Me.tbtnOnePage.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
        Me.tbtnOnePage.Tag = "OnePage"
        Me.tbtnOnePage.ToolTipText = "Best Fit"
        '
        'tbtnTwoPages
        '
        Me.tbtnTwoPages.ImageIndex = 4
        Me.tbtnTwoPages.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
        Me.tbtnTwoPages.Tag = "TwoPages"
        Me.tbtnTwoPages.ToolTipText = "Two Pages"
        '
        'tbtnSep2
        '
        Me.tbtnSep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'tbtnPageSetup
        '
        Me.tbtnPageSetup.ImageIndex = 6
        Me.tbtnPageSetup.Tag = "PageSetup"
        Me.tbtnPageSetup.Text = "Page Setup..."
        Me.tbtnPageSetup.ToolTipText = "Page Setup..."
        '
        'ToolBarButton3
        '
        Me.ToolBarButton3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'tbtnPrint
        '
        Me.tbtnPrint.ImageIndex = 5
        Me.tbtnPrint.Tag = "Print"
        Me.tbtnPrint.Text = "Print"
        '
        'ToolBarButton4
        '
        Me.ToolBarButton4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'tbtnClose
        '
        Me.tbtnClose.Tag = "Close"
        Me.tbtnClose.Text = "Close"
        '
        'icons
        '
        Me.icons.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.icons.ImageSize = New System.Drawing.Size(16, 16)
        Me.icons.ImageStream = CType(resources.GetObject("icons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.icons.TransparentColor = System.Drawing.Color.Transparent
        '
        'PrintPreviewControl1
        '
        Me.PrintPreviewControl1.AutoZoom = False
        Me.PrintPreviewControl1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.PrintPreviewControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PrintPreviewControl1.Location = New System.Drawing.Point(0, 25)
        Me.PrintPreviewControl1.Name = "PrintPreviewControl1"
        Me.PrintPreviewControl1.Size = New System.Drawing.Size(708, 393)
        Me.PrintPreviewControl1.TabIndex = 1
        Me.PrintPreviewControl1.UseAntiAlias = True
        Me.PrintPreviewControl1.Zoom = 1
        '
        'frmPrintPreview
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(708, 418)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.PrintPreviewControl1, Me.tbPrintPreview})
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPrintPreview"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmPrintPreview"
        Me.ResumeLayout(False)

    End Sub

#End Region




    Protected Overrides Sub OnClosed(ByVal e As System.EventArgs)
        'mParentForm.WindowState = Me.WindowState

        'If Me.WindowState = FormWindowState.Normal Then
        '    mParentForm.Bounds = Me.Bounds
        'End If
        'mParentForm.Show()
    End Sub

    Private Sub tbPrintPreview_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbPrintPreview.ButtonClick
        Select Case (e.Button.Tag.ToString())
            Case "MoveUp"
                Me.PrintPreviewControl1.StartPage = Me.PrintPreviewControl1.StartPage - 1
            Case "MoveDown"
                Me.PrintPreviewControl1.StartPage = Me.PrintPreviewControl1.StartPage + 1
            Case "Zoom100"
                Me.tbtnOnePage.Pushed = False
                Me.tbtnTwoPages.Pushed = False
                Me.PrintPreviewControl1.AutoZoom = False
                Me.PrintPreviewControl1.Zoom = 1
            Case "OnePage"
                Me.tbtnZoom100.Pushed = False
                Me.tbtnTwoPages.Pushed = False
                Me.PrintPreviewControl1.AutoZoom = True
                Me.PrintPreviewControl1.Rows = 1
                Me.PrintPreviewControl1.Columns = 1
            Case "TwoPages"
                Me.tbtnOnePage.Pushed = False
                Me.tbtnZoom100.Pushed = False
                Me.PrintPreviewControl1.AutoZoom = True
                Me.PrintPreviewControl1.Rows = 1
                Me.PrintPreviewControl1.Columns = 2
            Case "PageSetup"
                Me.PageSetupDialog1.Document = Me.PrintPreviewControl1.Document
                If Me.PageSetupDialog1.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
                    Dim doc As System.Drawing.Printing.PrintDocument
                    doc = Me.PrintPreviewControl1.Document
                    Me.PrintPreviewControl1.Document = doc
                End If
            Case "Print"
                Me.PrintPreviewControl1.Document.Print()
                Me.Close()
            Case "Close"
                Me.Close()
        End Select
    End Sub
    Public Overloads Sub Show(ByVal printDocument As System.Drawing.Printing.PrintDocument)
        Me.PrintPreviewControl1.Document = printDocument
        Me.PrintPreviewControl1.AutoZoom = True
        Me.Text = "Print Preview - " & printDocument.DocumentName
        'If mParentForm.WindowState = FormWindowState.Normal Then
        '    Bounds = mParentForm.Bounds
        'Else
        '    Me.WindowState = mParentForm.WindowState
        'End If
        'MainForm.Hide()
        Me.Show()
    End Sub


    Public Overloads Function ShowDialog(ByVal printDocument As System.Drawing.Printing.PrintDocument) As DialogResult
        Me.PrintPreviewControl1.Document = printDocument
        Me.PrintPreviewControl1.AutoZoom = True
        Me.Text = "Print Preview - " & printDocument.DocumentName
        'If mParentForm.WindowState = FormWindowState.Normal Then
        '    Bounds = mParentForm.Bounds
        'Else
        '    Me.WindowState = mParentForm.WindowState
        'End If
        'MainForm.Hide()
        Return Me.ShowDialog()
    End Function
End Class
