Imports LATIR2GuiManager
Imports LATIR2
Imports System.Drawing.Printing


Public Class frmMainB2
    Inherits System.Windows.Forms.Form


    Private Declare Function OemToChar Lib "user32" Alias "OemToCharA" (ByVal lpszSrc As String, ByVal lpszDst As String) As Integer
    Private Declare Function CharToOem Lib "user32" Alias "CharToOemA" (ByVal lpszSrc As String, ByVal lpszDst As String) As Integer


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
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem7 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem8 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuExit As System.Windows.Forms.MenuItem



    Public WithEvents mnuFILE As System.Windows.Forms.MenuItem
    Friend WithEvents cdlg As System.Windows.Forms.OpenFileDialog
    Friend WithEvents cdlgOpen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents cdlgSave As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents MenuItem20 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem9 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuB2Searcher As System.Windows.Forms.MenuItem
    Friend WithEvents mnuGenAgencyMS As System.Windows.Forms.MenuItem
    Friend WithEvents mnuMakeExtJSMy As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAddUnique As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCompress As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem15 As System.Windows.Forms.MenuItem


    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMainB2))
        Me.MainMenu1 = New System.Windows.Forms.MainMenu(Me.components)
        Me.mnuFILE = New System.Windows.Forms.MenuItem()
        Me.MenuItem20 = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.MenuItem9 = New System.Windows.Forms.MenuItem()
        Me.MenuItem15 = New System.Windows.Forms.MenuItem()
        Me.mnuMakeExtJSMy = New System.Windows.Forms.MenuItem()
        Me.mnuB2Searcher = New System.Windows.Forms.MenuItem()
        Me.mnuGenAgencyMS = New System.Windows.Forms.MenuItem()
        Me.mnuAddUnique = New System.Windows.Forms.MenuItem()
        Me.mnuCompress = New System.Windows.Forms.MenuItem()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.MenuItem3 = New System.Windows.Forms.MenuItem()
        Me.MenuItem7 = New System.Windows.Forms.MenuItem()
        Me.MenuItem4 = New System.Windows.Forms.MenuItem()
        Me.MenuItem5 = New System.Windows.Forms.MenuItem()
        Me.MenuItem6 = New System.Windows.Forms.MenuItem()
        Me.MenuItem8 = New System.Windows.Forms.MenuItem()

        Me.cdlg = New System.Windows.Forms.OpenFileDialog()
        Me.cdlgOpen = New System.Windows.Forms.OpenFileDialog()
        Me.cdlgSave = New System.Windows.Forms.SaveFileDialog()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFILE, Me.MenuItem9, Me.MenuItem2})
        '
        'mnuFILE
        '
        Me.mnuFILE.Index = 0
        Me.mnuFILE.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem20, Me.mnuExit})
        Me.mnuFILE.Text = "Файл"
        '
        'MenuItem20
        '
        Me.MenuItem20.Index = 0
        Me.MenuItem20.Text = "-"
        '
        'mnuExit
        '
        Me.mnuExit.Index = 1
        Me.mnuExit.Text = "Выход"
        '
        'MenuItem9
        '
        Me.MenuItem9.Index = 1
        Me.MenuItem9.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem15, Me.mnuMakeExtJSMy, Me.mnuB2Searcher, Me.mnuGenAgencyMS, Me.mnuAddUnique, Me.mnuCompress})
        Me.MenuItem9.Text = "Генерация JS + PHP"
        '
        'MenuItem15
        '
        Me.MenuItem15.Index = 0
        Me.MenuItem15.Text = "Генератор Ext JS"
        Me.MenuItem15.Visible = False
        '
        'mnuMakeExtJSMy
        '
        Me.mnuMakeExtJSMy.Index = 1
        Me.mnuMakeExtJSMy.Text = "Генератор ExtJS MySQL"
        '
        'mnuB2Searcher
        '
        Me.mnuB2Searcher.Index = 2
        Me.mnuB2Searcher.Text = "Генератор поисковых форм MySQL"
        Me.mnuB2Searcher.Visible = False
        '
        'mnuGenAgencyMS
        '
        Me.mnuGenAgencyMS.Index = 3
        Me.mnuGenAgencyMS.Text = "Генератор поисковых форм MSSQL"
        Me.mnuGenAgencyMS.Visible = False
        '
        'mnuAddUnique
        '
        Me.mnuAddUnique.Index = 4
        Me.mnuAddUnique.Text = "Подключить уникальность"
        '
        'mnuCompress
        '
        Me.mnuCompress.Index = 5
        Me.mnuCompress.Text = "Сжать скрипты"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 2
        Me.MenuItem2.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem3, Me.MenuItem7, Me.MenuItem4, Me.MenuItem5, Me.MenuItem6, Me.MenuItem8})
        Me.MenuItem2.Text = "Window"
        Me.MenuItem2.Visible = False
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 0
        Me.MenuItem3.MdiList = True
        Me.MenuItem3.Text = "List"
        '
        'MenuItem7
        '
        Me.MenuItem7.Index = 1
        Me.MenuItem7.Text = "-"
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 2
        Me.MenuItem4.Text = "Cascade"
        '
        'MenuItem5
        '
        Me.MenuItem5.Index = 3
        Me.MenuItem5.Text = "Tile horizontal"
        '
        'MenuItem6
        '
        Me.MenuItem6.Index = 4
        Me.MenuItem6.Text = "Tile vertical"
        '
        'MenuItem8
        '
        Me.MenuItem8.Index = 5
        Me.MenuItem8.Text = "Arrange icons"
        '
        'tabMan
        '
      
        'cdlg
        '
        Me.cdlg.FileName = "OpenFileDialog1"
        '
        'cdlgOpen
        '
        Me.cdlgOpen.FileName = "OpenFileDialog1"
        '
        'Timer2
        '
        Me.Timer2.Interval = 2000
        '
        'frmMainB2
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(528, 334)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Menu = Me.MainMenu1
        Me.Name = "frmMainB2"
        Me.Text = "Генератор JS+PHP для ExtJS6 "
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub MenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem4.Click
        Me.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade)

    End Sub

    Private Sub MenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem5.Click
        Me.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal)

    End Sub

    Private Sub MenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem6.Click
        Me.LayoutMdi(System.Windows.Forms.MdiLayout.TileVertical)
    End Sub

    Private Sub MenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem8.Click
        Me.LayoutMdi(System.Windows.Forms.MdiLayout.ArrangeIcons)
    End Sub



    Private Function W2OEM(ByVal s As String) As String
        Dim es As String
        es = Space(Len(s))
        Call CharToOem(s, es)
        W2OEM = es
    End Function

    Private inTimer2 As Boolean = False

    Private Sub Timer2_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Timer2.Tick
        If inTimer2 Then Exit Sub
        inTimer2 = True
        On Error Resume Next
        Manager.Session.Exec("SessionTouch", New LATIR2.NamedValues)
        inTimer2 = False

    End Sub



    Private Function Notabs(ByVal s As String) As String
        Notabs = Replace(Replace(Replace(Replace(s, vbTab, " "), vbCrLf, " "), vbCr, " "), vbLf, " ")
    End Function





    Private Sub frmMDI_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Manager = New LATIR2.Manager
        guiManager = New LATIR2GuiManager.LATIRGuiManager
        guiManager.Attach(Manager)
        Dim username As String = GetSetting("BP3GEN", "SETTING", "UID", "")
        Dim sitename As String = GetSetting("BP3GEN", "SETTING", "SITE", "")
        If Not guiManager.Login(username, sitename) Then
            Application.Exit()
            Return
        End If
        SaveSetting("BP3GEN", "SETTING", "UID", username)
        SaveSetting("BP3GEN", "SETTING", "SITE", sitename)


        Dim dt As DataTable, oID As Guid
        dt = guiManager.Manager.Session.GetRowsExDT("INSTANCE", guiManager.Manager.Session.GetProvider.InstanceFieldList, , , "OBJTYPE='MTZMetaModel'")
        oID = New System.Guid(dt.Rows.Item(0).Item("INSTANCEID").ToString())
        model = CType(guiManager.Manager.GetInstanceObject(oID), MTZMetaModel.MTZMetaModel.Application)
        Me.Text = "Генератор JS+PHP для ExtJS6 " & " :: " & sitename
        Timer2.Enabled = True
    End Sub


    Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
        Application.Exit()
    End Sub



    'Private Sub MenuItem15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem15.Click
    '    Dim F As ExtJSMaker
    '    F = New ExtJSMaker
    '    F.ShowDialog()
    '    F = Nothing
    'End Sub


   

    

    Private Sub mnuMakeExtJSMy_Click(sender As System.Object, e As System.EventArgs) Handles mnuMakeExtJSMy.Click
        Dim F As ExtJSMakerMYSQL
        F = New ExtJSMakerMYSQL
        F.ShowDialog()
        F = Nothing
    End Sub


    Private Sub mnuAddUnique_Click(sender As System.Object, e As System.EventArgs) Handles mnuAddUnique.Click
        Dim f As frmSetUnique
        f = New frmSetUnique

        f.ShowDialog()
    End Sub

    Private Sub mnuCompress_Click(sender As System.Object, e As System.EventArgs) Handles mnuCompress.Click
        Dim f As jsCompressor
        f = New jsCompressor
        f.ShowDialog()
        f = Nothing
    End Sub
End Class
