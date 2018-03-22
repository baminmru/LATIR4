Imports LATIR2GuiManager
Imports LATIR2
Imports System.Drawing.Printing


Public Class frmMDI
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
    Friend WithEvents mnuMetaModel As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem7 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem8 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuExit As System.Windows.Forms.MenuItem
    Friend WithEvents mnuGenerator As System.Windows.Forms.MenuItem

    Public WithEvents mnuDictionaries As System.Windows.Forms.MenuItem
    Public WithEvents mnuCreateDics As System.Windows.Forms.MenuItem
    Public WithEvents mnuRoles As System.Windows.Forms.MenuItem

    Public WithEvents mnuDocuments As System.Windows.Forms.MenuItem
    Public WithEvents mnuSwitchLang As System.Windows.Forms.MenuItem
    Public WithEvents mnuFILE As System.Windows.Forms.MenuItem
    Public WithEvents mnuDocLock As System.Windows.Forms.MenuItem
    Public WithEvents mnuDocUnlock As System.Windows.Forms.MenuItem
    Public WithEvents mnuDocSaveXML As System.Windows.Forms.MenuItem
    Public WithEvents mnuDocLoadXML As System.Windows.Forms.MenuItem
    Public WithEvents mnuGetID As System.Windows.Forms.MenuItem
    Public WithEvents mnuDocRename As System.Windows.Forms.MenuItem
    Public WithEvents mnuDocDelete As System.Windows.Forms.MenuItem
    Public WithEvents mnuDocument As System.Windows.Forms.MenuItem
    Public WithEvents mnuUniqTool As System.Windows.Forms.MenuItem
    Public WithEvents mnuUnlockAll As System.Windows.Forms.MenuItem
    Public WithEvents mnuPrepareARM As System.Windows.Forms.MenuItem
    Public WithEvents mnuARMGenerator As System.Windows.Forms.MenuItem
    Public WithEvents mnutoolS As System.Windows.Forms.MenuItem
    Public WithEvents mnuSaveDocs As System.Windows.Forms.MenuItem
    Public WithEvents mnuToolSaveDesc As System.Windows.Forms.MenuItem
    Public WithEvents mnuSaveFieldTypes As System.Windows.Forms.MenuItem
    Public WithEvents mnuSaveMethods As System.Windows.Forms.MenuItem
    Public WithEvents mnuToolLoadDesc As System.Windows.Forms.MenuItem
    Public WithEvents mnuLoadFT As System.Windows.Forms.MenuItem
    Public WithEvents mnuLoadMethods As System.Windows.Forms.MenuItem
    Public WithEvents mnuMergeObject As System.Windows.Forms.MenuItem
    Public WithEvents mnuMergeRow As System.Windows.Forms.MenuItem
    Public WithEvents mnuDelTools As System.Windows.Forms.MenuItem
    Public WithEvents mnuDelApp As System.Windows.Forms.MenuItem
    Public WithEvents mnuLoadFromXML As System.Windows.Forms.MenuItem
    Public WithEvents mnuCleanBase As System.Windows.Forms.MenuItem
    Public WithEvents mnuDataExchange As System.Windows.Forms.MenuItem
    Friend WithEvents cdlg As System.Windows.Forms.OpenFileDialog
    Friend WithEvents cdlgOpen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents cdlgSave As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents mnuFormEditTest As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem13 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem12 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem18 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem17 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem20 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem16 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem9 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem11 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuFieldCopy As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem15 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSetupModes As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem10 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSequenceTool As System.Windows.Forms.MenuItem
    Friend WithEvents mnuPartCopy As System.Windows.Forms.MenuItem
    Friend WithEvents mnuScale As MenuItem
    Friend WithEvents mnuInitDict As System.Windows.Forms.MenuItem


    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMDI))
        Me.MainMenu1 = New System.Windows.Forms.MainMenu(Me.components)
        Me.mnuFILE = New System.Windows.Forms.MenuItem()
        Me.mnuCreateDics = New System.Windows.Forms.MenuItem()
        Me.mnuInitDict = New System.Windows.Forms.MenuItem()
        Me.mnuDocuments = New System.Windows.Forms.MenuItem()
        Me.mnuDictionaries = New System.Windows.Forms.MenuItem()
        Me.MenuItem12 = New System.Windows.Forms.MenuItem()
        Me.mnuRoles = New System.Windows.Forms.MenuItem()
        Me.MenuItem18 = New System.Windows.Forms.MenuItem()
        Me.mnuMetaModel = New System.Windows.Forms.MenuItem()
        Me.mnuSwitchLang = New System.Windows.Forms.MenuItem()
        Me.MenuItem17 = New System.Windows.Forms.MenuItem()
        Me.MenuItem20 = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuDocument = New System.Windows.Forms.MenuItem()
        Me.mnuDocLock = New System.Windows.Forms.MenuItem()
        Me.mnuDocUnlock = New System.Windows.Forms.MenuItem()
        Me.mnuDocSaveXML = New System.Windows.Forms.MenuItem()
        Me.mnuDocLoadXML = New System.Windows.Forms.MenuItem()
        Me.mnuGetID = New System.Windows.Forms.MenuItem()
        Me.mnuDocRename = New System.Windows.Forms.MenuItem()
        Me.mnuDocDelete = New System.Windows.Forms.MenuItem()
        Me.mnutoolS = New System.Windows.Forms.MenuItem()
        Me.mnuUniqTool = New System.Windows.Forms.MenuItem()
        Me.mnuSetupModes = New System.Windows.Forms.MenuItem()
        Me.mnuSequenceTool = New System.Windows.Forms.MenuItem()
        Me.MenuItem10 = New System.Windows.Forms.MenuItem()
        Me.mnuUnlockAll = New System.Windows.Forms.MenuItem()
        Me.mnuPrepareARM = New System.Windows.Forms.MenuItem()
        Me.mnuGenerator = New System.Windows.Forms.MenuItem()
        Me.mnuARMGenerator = New System.Windows.Forms.MenuItem()
        Me.MenuItem11 = New System.Windows.Forms.MenuItem()
        Me.mnuFieldCopy = New System.Windows.Forms.MenuItem()
        Me.mnuPartCopy = New System.Windows.Forms.MenuItem()
        Me.MenuItem15 = New System.Windows.Forms.MenuItem()
        Me.mnuFormEditTest = New System.Windows.Forms.MenuItem()
        Me.MenuItem13 = New System.Windows.Forms.MenuItem()
        Me.mnuDataExchange = New System.Windows.Forms.MenuItem()
        Me.mnuSaveDocs = New System.Windows.Forms.MenuItem()
        Me.mnuToolSaveDesc = New System.Windows.Forms.MenuItem()
        Me.mnuSaveFieldTypes = New System.Windows.Forms.MenuItem()
        Me.mnuSaveMethods = New System.Windows.Forms.MenuItem()
        Me.mnuToolLoadDesc = New System.Windows.Forms.MenuItem()
        Me.mnuLoadFT = New System.Windows.Forms.MenuItem()
        Me.mnuLoadMethods = New System.Windows.Forms.MenuItem()
        Me.mnuMergeObject = New System.Windows.Forms.MenuItem()
        Me.mnuMergeRow = New System.Windows.Forms.MenuItem()
        Me.mnuDelTools = New System.Windows.Forms.MenuItem()
        Me.mnuDelApp = New System.Windows.Forms.MenuItem()
        Me.mnuLoadFromXML = New System.Windows.Forms.MenuItem()
        Me.mnuCleanBase = New System.Windows.Forms.MenuItem()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.MenuItem9 = New System.Windows.Forms.MenuItem()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.MenuItem3 = New System.Windows.Forms.MenuItem()
        Me.MenuItem7 = New System.Windows.Forms.MenuItem()
        Me.MenuItem4 = New System.Windows.Forms.MenuItem()
        Me.MenuItem5 = New System.Windows.Forms.MenuItem()
        Me.MenuItem6 = New System.Windows.Forms.MenuItem()
        Me.MenuItem8 = New System.Windows.Forms.MenuItem()
        Me.MenuItem16 = New System.Windows.Forms.MenuItem()
        Me.cdlg = New System.Windows.Forms.OpenFileDialog()
        Me.cdlgOpen = New System.Windows.Forms.OpenFileDialog()
        Me.cdlgSave = New System.Windows.Forms.SaveFileDialog()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.mnuScale = New System.Windows.Forms.MenuItem()
        Me.SuspendLayout()
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFILE, Me.mnuDocument, Me.mnutoolS, Me.mnuDataExchange, Me.MenuItem1, Me.MenuItem2})
        '
        'mnuFILE
        '
        Me.mnuFILE.Index = 0
        Me.mnuFILE.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuCreateDics, Me.mnuInitDict, Me.mnuDocuments, Me.mnuDictionaries, Me.MenuItem12, Me.mnuRoles, Me.MenuItem18, Me.mnuMetaModel, Me.mnuSwitchLang, Me.MenuItem17, Me.MenuItem20, Me.mnuExit})
        Me.mnuFILE.Text = "Файл"
        '
        'mnuCreateDics
        '
        Me.mnuCreateDics.Index = 0
        Me.mnuCreateDics.Text = "Создать справочники"
        '
        'mnuInitDict
        '
        Me.mnuInitDict.Index = 1
        Me.mnuInitDict.Text = "Инициализация справочника"
        '
        'mnuDocuments
        '
        Me.mnuDocuments.Index = 2
        Me.mnuDocuments.Text = "Новый документ"
        '
        'mnuDictionaries
        '
        Me.mnuDictionaries.Index = 3
        Me.mnuDictionaries.Text = "Справочники"
        '
        'MenuItem12
        '
        Me.MenuItem12.Index = 4
        Me.MenuItem12.Text = "Журнал"
        '
        'mnuRoles
        '
        Me.mnuRoles.Index = 5
        Me.mnuRoles.Text = "Роли"
        '
        'MenuItem18
        '
        Me.MenuItem18.Index = 6
        Me.MenuItem18.Text = "Пользователи"
        '
        'mnuMetaModel
        '
        Me.mnuMetaModel.Index = 7
        Me.mnuMetaModel.Text = "Метамодель"
        '
        'mnuSwitchLang
        '
        Me.mnuSwitchLang.Index = 8
        Me.mnuSwitchLang.Text = "Переключить язык"
        '
        'MenuItem17
        '
        Me.MenuItem17.Index = 9
        Me.MenuItem17.Text = "Каталог"
        '
        'MenuItem20
        '
        Me.MenuItem20.Index = 10
        Me.MenuItem20.Text = "-"
        '
        'mnuExit
        '
        Me.mnuExit.Index = 11
        Me.mnuExit.Text = "Выход"
        '
        'mnuDocument
        '
        Me.mnuDocument.Index = 1
        Me.mnuDocument.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuDocLock, Me.mnuDocUnlock, Me.mnuDocSaveXML, Me.mnuDocLoadXML, Me.mnuGetID, Me.mnuDocRename, Me.mnuDocDelete})
        Me.mnuDocument.Text = "Документ"
        Me.mnuDocument.Visible = False
        '
        'mnuDocLock
        '
        Me.mnuDocLock.Index = 0
        Me.mnuDocLock.Text = "Заблокировать"
        '
        'mnuDocUnlock
        '
        Me.mnuDocUnlock.Index = 1
        Me.mnuDocUnlock.Text = "Разблокировать"
        '
        'mnuDocSaveXML
        '
        Me.mnuDocSaveXML.Index = 2
        Me.mnuDocSaveXML.Text = "Сохранить в файл"
        '
        'mnuDocLoadXML
        '
        Me.mnuDocLoadXML.Index = 3
        Me.mnuDocLoadXML.Text = "Загрузить из файла"
        '
        'mnuGetID
        '
        Me.mnuGetID.Index = 4
        Me.mnuGetID.Text = "Получить идентификатор"
        '
        'mnuDocRename
        '
        Me.mnuDocRename.Index = 5
        Me.mnuDocRename.Text = "Переименовать"
        '
        'mnuDocDelete
        '
        Me.mnuDocDelete.Index = 6
        Me.mnuDocDelete.Text = "Удалить"
        '
        'mnutoolS
        '
        Me.mnutoolS.Index = 2
        Me.mnutoolS.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuUniqTool, Me.mnuSetupModes, Me.mnuSequenceTool, Me.MenuItem10, Me.mnuUnlockAll, Me.mnuPrepareARM, Me.mnuGenerator, Me.mnuARMGenerator, Me.MenuItem11, Me.mnuFieldCopy, Me.mnuPartCopy, Me.MenuItem15, Me.mnuScale, Me.mnuFormEditTest, Me.MenuItem13})
        Me.mnutoolS.Text = "Инструменты"
        '
        'mnuUniqTool
        '
        Me.mnuUniqTool.Index = 0
        Me.mnuUniqTool.Text = "Настройка уникальных сочетаний"
        '
        'mnuSetupModes
        '
        Me.mnuSetupModes.Index = 1
        Me.mnuSetupModes.Text = "Настройка режимов"
        '
        'mnuSequenceTool
        '
        Me.mnuSequenceTool.Index = 2
        Me.mnuSequenceTool.Text = "Последовательность полей"
        '
        'MenuItem10
        '
        Me.MenuItem10.Index = 3
        Me.MenuItem10.Text = "-"
        '
        'mnuUnlockAll
        '
        Me.mnuUnlockAll.Index = 4
        Me.mnuUnlockAll.Text = "Разблокировать объекты"
        '
        'mnuPrepareARM
        '
        Me.mnuPrepareARM.Index = 5
        Me.mnuPrepareARM.Text = "Подготовка АРМ"
        '
        'mnuGenerator
        '
        Me.mnuGenerator.Index = 6
        Me.mnuGenerator.Text = "Генератор документов"
        '
        'mnuARMGenerator
        '
        Me.mnuARMGenerator.Enabled = False
        Me.mnuARMGenerator.Index = 7
        Me.mnuARMGenerator.Text = "Генератор АРМ"
        '
        'MenuItem11
        '
        Me.MenuItem11.Index = 8
        Me.MenuItem11.Text = "-"
        '
        'mnuFieldCopy
        '
        Me.mnuFieldCopy.Index = 9
        Me.mnuFieldCopy.Text = "Копирование полей"
        '
        'mnuPartCopy
        '
        Me.mnuPartCopy.Index = 10
        Me.mnuPartCopy.Text = "Копирование разделов"
        '
        'MenuItem15
        '
        Me.MenuItem15.Index = 11
        Me.MenuItem15.Text = "-"
        '
        'mnuFormEditTest
        '
        Me.mnuFormEditTest.Index = 13
        Me.mnuFormEditTest.Text = "Тест настройки формы"
        '
        'MenuItem13
        '
        Me.MenuItem13.Index = 14
        Me.MenuItem13.Text = "MyTest"
        '
        'mnuDataExchange
        '
        Me.mnuDataExchange.Index = 3
        Me.mnuDataExchange.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuSaveDocs, Me.mnuToolSaveDesc, Me.mnuSaveFieldTypes, Me.mnuSaveMethods, Me.mnuToolLoadDesc, Me.mnuLoadFT, Me.mnuLoadMethods, Me.mnuMergeObject, Me.mnuMergeRow, Me.mnuDelTools, Me.mnuDelApp, Me.mnuLoadFromXML, Me.mnuCleanBase})
        Me.mnuDataExchange.Text = "Обмен данными"
        '
        'mnuSaveDocs
        '
        Me.mnuSaveDocs.Index = 0
        Me.mnuSaveDocs.Text = "Сохранить документы"
        '
        'mnuToolSaveDesc
        '
        Me.mnuToolSaveDesc.Index = 1
        Me.mnuToolSaveDesc.Text = "Сохранить описание типа"
        '
        'mnuSaveFieldTypes
        '
        Me.mnuSaveFieldTypes.Index = 2
        Me.mnuSaveFieldTypes.Text = "Сохранить типы полей"
        '
        'mnuSaveMethods
        '
        Me.mnuSaveMethods.Index = 3
        Me.mnuSaveMethods.Text = "Сохранить методы и процедуры"
        '
        'mnuToolLoadDesc
        '
        Me.mnuToolLoadDesc.Index = 4
        Me.mnuToolLoadDesc.Text = "Загрузить описание типа"
        '
        'mnuLoadFT
        '
        Me.mnuLoadFT.Index = 5
        Me.mnuLoadFT.Text = "Загрузить типы полей"
        '
        'mnuLoadMethods
        '
        Me.mnuLoadMethods.Index = 6
        Me.mnuLoadMethods.Text = "Загрузить  методы и процедуры"
        '
        'mnuMergeObject
        '
        Me.mnuMergeObject.Index = 7
        Me.mnuMergeObject.Text = "Замена ссылки на объект"
        '
        'mnuMergeRow
        '
        Me.mnuMergeRow.Index = 8
        Me.mnuMergeRow.Text = "Замена ссылки на раздел"
        '
        'mnuDelTools
        '
        Me.mnuDelTools.Index = 9
        Me.mnuDelTools.Text = "Удаление документов"
        '
        'mnuDelApp
        '
        Me.mnuDelApp.Index = 10
        Me.mnuDelApp.Text = "Удаление типов документов"
        '
        'mnuLoadFromXML
        '
        Me.mnuLoadFromXML.Index = 11
        Me.mnuLoadFromXML.Text = "Загрузить документ из XML"
        '
        'mnuCleanBase
        '
        Me.mnuCleanBase.Index = 12
        Me.mnuCleanBase.Text = "Очистка базы данных"
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 4
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem9})
        Me.MenuItem1.Text = "Export"
        '
        'MenuItem9
        '
        Me.MenuItem9.Index = 0
        Me.MenuItem9.Text = "Export to MySQL"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 5
        Me.MenuItem2.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem3, Me.MenuItem7, Me.MenuItem4, Me.MenuItem5, Me.MenuItem6, Me.MenuItem8, Me.MenuItem16})
        Me.MenuItem2.Text = "Window"
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
        'MenuItem16
        '
        Me.MenuItem16.Index = 6
        Me.MenuItem16.Text = "О программе"
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
        Me.Timer2.Interval = 60000
        '
        'mnuScale
        '
        Me.mnuScale.Index = 12
        Me.mnuScale.Text = "Шрифт"
        '
        'frmMDI
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(528, 334)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Menu = Me.MainMenu1
        Me.Name = "frmMDI"
        Me.Text = ".Net Administrator"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

#End Region


    Dim dt As DataTable
    Dim oID As System.Guid



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



    Private Sub mnuMetaModel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuMetaModel.Click
        'ShowDictionatyObject("STDInfoStore")
        Dim f As frmChild
        f = New frmChild
        Dim ObjTypeName As String = "MTZMetaModel.MTZMetaModel"
        Try
            dt = guiManager.Manager.Session.GetRowsExDT("INSTANCE", guiManager.Manager.Session.GetProvider.InstanceFieldList, , , "OBJTYPE='mtzmetamodel'")
            oID = New System.Guid(dt.Rows.Item(0).Item("INSTANCEID").ToString())
            Dim meta As MTZMetaModel.MTZMetaModel.Application
            meta = CType(guiManager.Manager.GetInstanceObject(oID), MTZMetaModel.MTZMetaModel.Application)
            Dim RootDllPath As String = GetSetting("LATIR4", "CFG", "SETTINGS_LATIRDLLSPATH")
            Dim Doc_GUIBase As LATIR2GuiManager.Doc_GUIBase
            Doc_GUIBase = guiManager.GetTypeGUI(meta.TypeName, RootDllPath)
            If (Not Doc_GUIBase Is Nothing) Then
                Dim obj As Object = Doc_GUIBase.GetObjectControl(String.Empty, ObjTypeName)
                f.AppendControl(obj)
                f.MdiParent = Me
                f.Attach(guiManager, meta)
                f.Show()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub






    Private Sub mnuMTZUsersDic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim f As frmChild
        f = New frmChild
        Dim ObjTypeName As String = "MTZUsers"
        dt = guiManager.Manager.Session.GetRowsExDT("INSTANCE", guiManager.Manager.Session.GetProvider.InstanceFieldList, , , "OBJTYPE='" + ObjTypeName + "'")
        oID = New Guid(dt.Rows.Item(0).Item("INSTANCEID").ToString)
        Dim ed As MTZUsers.MTZUsers.Application
        ed = CType(guiManager.Manager.GetInstanceObject(oID), MTZUsers.MTZUsers.Application)
        If (Not ed Is Nothing) Then
            Dim Doc_GUIBase As LATIR2GuiManager.Doc_GUIBase
            Doc_GUIBase = guiManager.GetTypeGUI(ed.TypeName)
            'dg.ShowForm("", ed)
            Dim objControl As Object = Nothing
            Try
                objControl = Doc_GUIBase.GetObjectControl(String.Empty, ObjTypeName)
            Catch
            End Try
            If (Not objControl Is Nothing) Then
                f.AppendControl(Doc_GUIBase.GetObjectControl(String.Empty, ObjTypeName))
                f.MdiParent = Me
                f.Attach(guiManager, ed)
                f.Show()
            Else
                MessageBox.Show("Error occured while running the form")
            End If
        End If
    End Sub

    'Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
    '    Application.Exit()
    'End Sub

    Private Sub mnuPrintPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If pDOc Is Nothing Then
            dt = guiManager.Manager.Session.GetRowsExDT("INSTANCE", guiManager.Manager.Session.GetProvider.InstanceFieldList, , , "OBJTYPE='mtzmetamodel'")
            oID = New Guid(dt.Rows.Item(0).Item("INSTANCEID").ToString)
            MyMeta = CType(guiManager.Manager.GetInstanceObject(oID), MTZMetaModel.MTZMetaModel.Application)
            pDOc = New PrintDocument
        End If
        Dim f As frmPrintPreview
        f = New frmPrintPreview
        f.MdiParent = Me

        f.Show(pDOc)
    End Sub

    Dim MyMeta As MTZMetaModel.MTZMetaModel.Application
    Dim WithEvents pDOc As System.Drawing.Printing.PrintDocument
    Private mFont As New Font("Courier New", 10)
    Private lastOT As Integer
    Private lastPT As Integer

    Private Sub pDOc_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pDOc.PrintPage
        Dim xPos As Single = e.MarginBounds.Left
        Dim yPos As Single = e.MarginBounds.Top
        Dim PWidth As Single = e.MarginBounds.Width
        Dim pHeight As Single = e.MarginBounds.Height
        Dim lineHeight As Single = mFont.GetHeight(e.Graphics)
        Dim i As Long, j As Long
        Dim pt As MTZMetaModel.MTZMetaModel.PART
        Dim ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE
        Dim s As String
        Dim rectf As RectangleF
        Dim mh As Single
        Dim mw As Single

        On Error Resume Next
        With e.Graphics
            For i = lastOT To MyMeta.OBJECTTYPE.Count

                ot = MyMeta.OBJECTTYPE.Item(i)
                If lastPT = 0 Then
                    s = ot.Name & " " & ot.the_Comment
                    rectf = New RectangleF(New PointF(xPos, yPos), .MeasureString(s, mFont, New SizeF(PWidth, pHeight), System.Drawing.StringFormat.GenericDefault, 1, 1))
                    .DrawString(s, mFont, Brushes.Black, rectf)
                    yPos += rectf.Height
                    xPos = e.MarginBounds.Left
                    s = "Описание: "
                    s = s & ot.TheComment
                    rectf = New RectangleF(New PointF(xPos, yPos), .MeasureString(s, mFont, New SizeF(PWidth, pHeight), System.Drawing.StringFormat.GenericDefault, 1, 1))
                    .DrawString(s, mFont, Brushes.Black, rectf)
                    yPos += rectf.Height
                    xPos = e.MarginBounds.Left
                    If yPos + lineHeight > pHeight Then
                        e.HasMorePages = True
                        lastOT = i
                        lastPT = 1
                        Exit For
                    End If
                    lastPT = 1
                End If

                For j = lastPT To ot.PART.Count
                    pt = ot.PART.Item(j)

                    s = ">> " & pt.Name & " " & pt.Caption
                    s = s & " " & pt.the_Comment
                    rectf = New RectangleF(New PointF(xPos, yPos), .MeasureString(s, mFont, New SizeF(PWidth, pHeight), System.Drawing.StringFormat.GenericDefault, 1, 1))
                    .DrawString(s, mFont, Brushes.Black, rectf)
                    yPos += rectf.Height
                    xPos = e.MarginBounds.Left
                    If yPos + lineHeight > pHeight Then
                        e.HasMorePages = True
                        If j < ot.PART.Count Then
                            lastOT = i
                            lastPT = j + 1
                        Else
                            lastOT = i + 1
                            lastPT = 0
                        End If
                        Exit For
                    End If
                Next
                lastPT = 0

            Next


            '.DrawString("This is another test", _
            '  mFont, Brushes.Black, xPos, yPos)

            'xPos += .MeasureString("This is another test", mFont).Width

            '.DrawString("Here's some more text", _
            '  mFont, Brushes.Black, xPos, yPos)


        End With

    End Sub

    Private Sub pDOc_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles pDOc.BeginPrint
        lastOT = 1
        lastPT = 0
    End Sub

    Private Sub mnuGenerator_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuGenerator.Click
        Dim f As frmGenerator
        f = New frmGenerator
        f.Show()
    End Sub


    Private Sub MenuItem12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim f As frmJournalViewIG
        f = New frmJournalViewIG
        f.MdiParent = Me
        f.Attach(guiManager)
        f.Show()
    End Sub



    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Public Sub mnuAddMethod_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        'Dim f As frmAddMethod
        'f = New frmAddMethod
        'f.ShowDialog()
        'f.Close()
        MsgBox("TODO")
    End Sub

    Public Sub mnuARMGenerator_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuARMGenerator.Click
        MsgBox("TODO")

        'Dim f As frmARMGEN
        'f = New frmARMGEN
        'f.ShowDialog()
        'f.Close()
    End Sub




    Public Sub mnuCleanBase_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuCleanBase.Click
        Dim f As frmCleanBaseTool
        f = New frmCleanBaseTool
        f.ShowDialog()
        f.Close()
    End Sub


    Public Sub mnuConvertSQL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        'ConvertSQL()
        'MsgBox("Преобразование завершено")
        MsgBox("TODO")
    End Sub

    Public Sub mnuCreateDics_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuCreateDics.Click
        Dim ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE
        Dim i As Integer
        Dim rs As DataTable
        For i = 1 To model.OBJECTTYPE.Count
            ot = model.OBJECTTYPE.Item(i)
            If ot.IsSingleInstance = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
                rs = Manager.Session.GetRowsDT("INSTANCE", Manager.Session.GetProvider.InstanceFieldList, , , "objtype='" & ot.Name & "'")
                If rs.Rows.Count = 0 Then
                    Manager.NewInstance(Guid.NewGuid, ot.Name, ot.the_Comment)
                End If
            End If
        Next
    End Sub

    Public Sub mnuCreateJournalByView_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        'Call JournalByView.ProcessJournal()
        MsgBox("todo")
    End Sub

    Public Sub mnuDelApp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuDelApp.Click
        frmAppDel.model = model
        frmAppDel.ShowDialog()
        Dim ma As MTZMetaModel.MTZMetaModel.MTZAPP
        If frmAppDel.OK Then
            ma = frmAppDel.Result
            KillTypes(ma)
            ma.Delete()

        End If
    End Sub

    Public Sub mnuDelTools_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuDelTools.Click
        Dim f As frmDeleteTool
        f = New frmDeleteTool
        f.ShowDialog()
        f.Close()
    End Sub

    Public Sub mnuDocRename_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuDocRename.Click
        On Error Resume Next
        Dim item As LATIR2.Document.Doc_Base
        item = GetActiveItem()
        If item Is Nothing Then Exit Sub
        Dim s As String
        'UPGRADE_WARNING: Couldn't resolve default property of object item.Name. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        s = InputBox("Введите новое название документа", "Переименовать документ", item.Name)
        If s <> "" Then
            'UPGRADE_WARNING: Couldn't resolve default property of object item.Name. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            item.Name = s
            'UPGRADE_WARNING: Couldn't resolve default property of object item.Save. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            item.Save()
        End If


    End Sub






    Public Sub mnuFastReportMaster_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        'Dim frmFR As New frmFastReportBuilder
        'frmFR.Show()
        MsgBox("todo")
    End Sub




    Public Sub mnuGetID_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuGetID.Click
        On Error GoTo bye
        Dim item As Object
        item = GetActiveItem()
        If item Is Nothing Then Exit Sub
        Dim fid As frmShowID
        fid = New frmShowID
        fid.Label1.Text = "Идентификатор документа :" & vbCrLf & item.brief
        fid.Text1.Text = item.ID.ToString()
        fid.ShowDialog()
        Exit Sub
bye:

    End Sub

    Public Sub mnuInstallGenerator_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        MsgBox("todo")
        '        On Error GoTo Error_Detected
        '        Dim objInstall As MTZ_Install.Application
        '        objInstall = GetDictionary("MTZ_Install")

        '        '    Dim ii As Long
        '        '    Dim jj As Long
        '        '    For ii = 1 To objInstall.MTZ_Inst_Section.Count
        '        '        For jj = 1 To objInstall.MTZ_Inst_Section.item(ii).MTZ_Inst_Sec_Files.Count
        '        '            Dim objFile As MTZ_Inst_Sec_Files
        '        '            Set objFile = objInstall.MTZ_Inst_Section.item(ii).MTZ_Inst_Sec_Files.item(jj)
        '        '            If UCase(Left(objFile.TheSource, 6)) = UCase("c:\mtz") Then
        '        '                objFile.TheSource = Replace(objFile.TheSource, "C:\MTZ", "%MTZDIR%", , , vbTextCompare)
        '        '                objFile.Save
        '        '            End If
        '        '        Next
        '        '    Next
        '        '
        '        '    Exit Sub

        '        If objInstall.MTZ_Inst_Section.Count <= 0 Or objInstall.MTZ_Inst_Build.Count <= 0 Then
        '            MsgBox("Нет данных")
        '            Exit Sub
        '        End If
        '        Dim objBuild As MTZ_Install.MTZ_Inst_Build
        '        Dim ID As String
        '        Dim Brief As String=""
        '        If Manager.GetReferenceDialogEx2("MTZ_Inst_Build", ID, brief) Then
        '            ID = VB.Left(ID, 38)
        '            objBuild = objInstall.FindRowObject("MTZ_Inst_Build", ID)
        '            If objBuild Is Nothing Then
        '                MsgBox("Ошибка получения билда")
        '                Exit Sub
        '            End If

        '            'Get SaveFile
        '            'UPGRADE_WARNING: The CommonDialog CancelError property is not supported in Visual Basic .NET. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8B377936-3DF7-4745-AA26-DD00FA5B9BE1"'
        '            cdlg.CancelError = True
        '            'UPGRADE_WARNING: Filter has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        '            cdlgOpen.Filter = "Документ NSI|*.NSI"
        '            cdlgSave.Filter = "Документ NSI|*.NSI"
        '            cdlgOpen.DefaultExt = "NSI"
        '            cdlgSave.DefaultExt = "NSI"
        '            cdlgOpen.FileName = objBuild.PRODUCT_NAME & ".NSI"
        '            cdlgSave.FileName = objBuild.PRODUCT_NAME & ".NSI"
        '            'UPGRADE_WARNING: FileOpenConstants constant FileOpenConstants.cdlOFNHideReadOnly was upgraded to OpenFileDialog.ShowReadOnly which has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"'
        '            cdlgOpen.CheckPathExists = True
        '            cdlgSave.CheckPathExists = True
        '            'UPGRADE_WARNING: MSComDlg.CommonDialog property cdlg.Flags was upgraded to cdlgOpen.ShowReadOnly which has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"'
        '            'UPGRADE_WARNING: FileOpenConstants constant FileOpenConstants.cdlOFNHideReadOnly was upgraded to OpenFileDialog.ShowReadOnly which has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"'
        '            cdlgOpen.ShowReadOnly = False
        '            'UPGRADE_WARNING: MSComDlg.CommonDialog property cdlg.Flags was upgraded to cdlgSave.OverwritePrompt which has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"'
        '            cdlgSave.OverwritePrompt = True 'cdlOFNFileMustExist
        '            cdlgSave.ShowDialog()
        '            cdlgOpen.FileName = cdlgSave.FileName



        '            PrepareInstall(objBuild, (cdlgOpen.FileName)) '"c:\Inst.nsi"
        '            ShellExecute(0, "open", cdlgOpen.FileName, "", "", 0)
        '            MsgBox("Done!")
        '        End If
        'Error_Detected:
    End Sub

    Public Sub mnuLoadFromXML_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuLoadFromXML.Click
        On Error GoTo bye
        Dim fn As String

        cdlgOpen.Filter = "Документ XML |*.XML"
        cdlgSave.Filter = "Документ XML |*.XML"
        cdlgOpen.DefaultExt = "XML"
        cdlgSave.DefaultExt = "XML"

        cdlgOpen.ShowReadOnly = False
        'UPGRADE_WARNING: MSComDlg.CommonDialog property cdlg.Flags was upgraded to cdlgOpen.CheckFileExists which has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"'
        cdlgOpen.CheckFileExists = True
        cdlgOpen.CheckPathExists = True
        cdlgSave.CheckPathExists = True
        cdlgOpen.ShowDialog()
        cdlgSave.FileName = cdlgOpen.FileName
        fn = cdlgOpen.FileName
        Dim xdom As System.Xml.XmlDocument

        Dim ID As Guid
        Dim drs As LATIR2.Document.Doc_Base
        'UPGRADE_NOTE: Name was upgraded to Name_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        Dim Name_Renamed As String
        'UPGRADE_NOTE: TypeName was upgraded to TypeName_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        Dim TypeName_Renamed As String
        If fn <> "" Then

            xdom = New System.Xml.XmlDocument
            xdom.Load(fn)

            ID = New Guid(xdom.LastChild.FirstChild.Attributes.GetNamedItem("ID").Value)

            TypeName_Renamed = xdom.LastChild.FirstChild.Attributes.GetNamedItem("TYPENAME").Value
            Name_Renamed = TypeName_Renamed

            'try if new format
            Name_Renamed = xdom.LastChild.FirstChild.Attributes.GetNamedItem("NAME").Value

            drs = Manager.GetInstanceObject(ID)
            If drs Is Nothing Then
                Manager.NewInstance(ID, TypeName_Renamed, Name_Renamed)
            End If

            drs = Manager.GetInstanceObject(ID)
            If Not drs Is Nothing Then

                drs.LockResource(True)

                drs.AutoLoadPart = True
                'UPGRADE_WARNING: Couldn't resolve default property of object drs.WorkOffline. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'

                'UPGRADE_WARNING: Couldn't resolve default property of object drs.XMLLoad. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                drs.XMLLoad(xdom.LastChild, 0)
                drs.BatchUpdate()
                'UPGRADE_WARNING: Couldn't resolve default property of object drs.UnLockResource. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                drs.UnLockResource()
            End If
            'UPGRADE_NOTE: Object xdom may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            xdom = Nothing
            MsgBox("Документ загружен удачно!", MsgBoxStyle.OkOnly)
        End If

bye:
    End Sub

    Public Sub mnuLoadFT_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuLoadFT.Click
        Dim f As frmLoadFT
        f = New frmLoadFT
        f.ShowDialog()
        f.Close()
    End Sub

    Public Sub mnuLoadMethods_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuLoadMethods.Click
        Dim f As frmLoadMTD
        f = New frmLoadMTD
        f.ShowDialog()
        f.Close()
    End Sub



    Public Sub mnuMakeFile_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)

        'frmPackGen.ShowDialog()
        'Exit Sub

        MsgBox("todo")

    End Sub


    Private Function W2OEM(ByVal s As String) As String

        Dim es As String
        es = Space(Len(s))
        Call CharToOem(s, es)
        W2OEM = es
    End Function

    Public Sub mnuMakeFR_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        'Dim f As frmMakeFR
        'f = New frmMakeFR
        'f.ShowDialog()
        'f.Close()
        ''UPGRADE_NOTE: Object f may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        'f = Nothing

        MsgBox("todo")
    End Sub

    Public Sub mnuMakeFRAppPhil_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        'On Error GoTo bye
        'Dim fn As String
        'Dim fp As String
        'Dim objObject As MTZMetaModel.OBJECTTYPE
        'Dim IDv As String
        'Dim Briefv As String
        'If Not Manager.GetReferenceDialogEx3("MTZAPP", IDv, Briefv) Then
        '    Exit Sub
        'End If
        'IDv = VB.Left(IDv, 38)
        'Dim mtzApp As MTZMetaModel.MTZAPP
        'Dim oMetaModel As MTZMetaModel.Application
        'mtzApp = MyUser.Application.FindRowObject("MTZAPP", IDv)
        'oMetaModel = mtzApp.Application
        'fp = GetPath("Путь для отчётов", Me.Handle.ToInt32)
        'Dim i As Integer
        'If fp <> "" Then
        '    For i = 1 To oMetaModel.objectType.Count
        '        'UPGRADE_WARNING: Couldn't resolve default property of object oMetaModel.objectType.item(i).package.ID. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        If oMetaModel.objectType.item(i).package.ID = IDv Then
        '            objObject = oMetaModel.objectType.item(i)
        '            fn = fp & objObject.Name & ".fr3"
        '            MakeSingleFRForView(fn, objObject, True)
        '        End If
        '    Next
        '    MsgBox("Завершено!")
        'End If

        MsgBox("todo")

bye:
    End Sub

    Public Sub mnuMakeFRPhil_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        'On Error GoTo bye
        'Dim fn As String
        'Dim objObject As MTZMetaModel.OBJECTTYPE
        'Dim IDv As String
        'Dim Briefv As String
        'If Not Manager.GetReferenceDialogEx3("OBJECTTYPE", IDv, Briefv) Then
        '    Exit Sub
        'End If
        'IDv = VB.Left(IDv, 38)
        'objObject = MyUser.Application.FindRowObject("OBJECTTYPE", IDv)
        ''UPGRADE_WARNING: The CommonDialog CancelError property is not supported in Visual Basic .NET. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8B377936-3DF7-4745-AA26-DD00FA5B9BE1"'
        'cdlg.CancelError = True
        ''UPGRADE_WARNING: Filter has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        'cdlgOpen.Filter = "Документ FastReport |*.fr3"
        'cdlgSave.Filter = "Документ FastReport |*.fr3"
        'cdlgOpen.DefaultExt = "fr3"
        'cdlgSave.DefaultExt = "fr3"
        'cdlgOpen.FileName = objObject.Name
        'cdlgSave.FileName = objObject.Name
        ''objObject.Name
        ''cdlg.FileName = App.path & "\" & item.ID & ".xml"
        'cdlgOpen.CheckPathExists = True
        'cdlgSave.CheckPathExists = True '+ cdlOFNHideReadOnly + cdlOFNFileMustExist
        'cdlgSave.ShowDialog()
        'cdlgOpen.FileName = cdlgSave.FileName
        'fn = cdlgOpen.FileName
        'Dim fn2 As String
        'If fn <> "" Then
        '    If MsgBox("Вставить кастом шапку?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        '        'UPGRADE_WARNING: Filter has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        '        cdlgOpen.Filter = "Кстом шапка |*.txt"
        '        cdlgSave.Filter = "Кстом шапка |*.txt"
        '        cdlgOpen.DefaultExt = "txt"
        '        cdlgSave.DefaultExt = "txt"
        '        'UPGRADE_WARNING: FileOpenConstants constant FileOpenConstants.cdlOFNHideReadOnly was upgraded to OpenFileDialog.ShowReadOnly which has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"'
        '        'UPGRADE_WARNING: MSComDlg.CommonDialog property cdlg.Flags was upgraded to cdlgOpen.ShowReadOnly which has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"'
        '        'UPGRADE_WARNING: FileOpenConstants constant FileOpenConstants.cdlOFNHideReadOnly was upgraded to OpenFileDialog.ShowReadOnly which has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"'
        '        cdlgOpen.ShowReadOnly = False
        '        'UPGRADE_WARNING: MSComDlg.CommonDialog property cdlg.Flags was upgraded to cdlgOpen.CheckFileExists which has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"'
        '        cdlgOpen.CheckFileExists = True
        '        cdlgOpen.CheckPathExists = True
        '        cdlgSave.CheckPathExists = True
        '        cdlgOpen.ShowDialog()
        '        cdlgSave.FileName = cdlgOpen.FileName
        '        fn2 = cdlgOpen.FileName
        '        MakeSingleFRForView(fn, objObject, , , , , fn2)
        '    Else
        '        MakeSingleFRForView(fn, objObject)
        '    End If
        '    MsgBox("Завершено!")
        'End If

        MsgBox("todo")

bye:
    End Sub

    Public Sub mnuMakeFRPhilViews_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        'On Error GoTo bye
        'Dim fn As String
        'Dim objObject As MTZMetaModel.OBJECTTYPE
        'Dim IDv As String
        'Dim Briefv As String
        'If Not Manager.GetReferenceDialogEx3("OBJECTTYPE", IDv, Briefv) Then
        '    Exit Sub
        'End If
        'IDv = VB.Left(IDv, 38)
        'objObject = MyUser.Application.FindRowObject("OBJECTTYPE", IDv)
        ''UPGRADE_WARNING: The CommonDialog CancelError property is not supported in Visual Basic .NET. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8B377936-3DF7-4745-AA26-DD00FA5B9BE1"'
        'cdlg.CancelError = True
        ''UPGRADE_WARNING: Filter has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        'cdlgOpen.Filter = "Документ FastReport |*.fr3"
        'cdlgSave.Filter = "Документ FastReport |*.fr3"
        'cdlgOpen.DefaultExt = "fr3"
        'cdlgSave.DefaultExt = "fr3"
        'cdlgOpen.FileName = objObject.Name
        'cdlgSave.FileName = objObject.Name
        ''objObject.Name
        ''cdlg.FileName = App.path & "\" & item.ID & ".xml"
        'cdlgOpen.CheckPathExists = True
        'cdlgSave.CheckPathExists = True '+ cdlOFNHideReadOnly + cdlOFNFileMustExist
        'cdlgSave.ShowDialog()
        'cdlgOpen.FileName = cdlgSave.FileName
        'fn = cdlgOpen.FileName
        'If fn <> "" Then
        '    MakeSingleFRForView(fn, objObject, , True)
        '    MsgBox("Завершено!")
        'End If
        MsgBox("todo")

bye:
    End Sub

    Public Sub mnuMergeObject_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuMergeObject.Click
        Dim f As frmMergeObjTool
        f = New frmMergeObjTool
        f.ShowDialog()
        f.Close()
        'UPGRADE_NOTE: Object f may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        f = Nothing
    End Sub

    Public Sub mnuMergeRow_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuMergeRow.Click
        Dim f As frmMergeRowTool
        f = New frmMergeRowTool
        f.ShowDialog()
        f.Close()
        'UPGRADE_NOTE: Object f may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        f = Nothing
    End Sub



    Public Sub mnuOraclecnv_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        'ConvertORA()
        'MsgBox("Преобразование завершено")
        MsgBox("todo")
    End Sub

    Public Sub mnuPrepareARM_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuPrepareARM.Click
        Dim f As frmSmartArm
        f = New frmSmartArm
        f.ShowDialog()
    End Sub

    Public Sub mnuRoles_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuRoles.Click
        Dim f As frmJournalViewIG
        f = New frmJournalViewIG
        f.MdiParent = Me
        f.Attach(guiManager)
        f.Show()

        'Dim rs As ADODB.Recordset
        'Dim ID As String
        'Set rs = Manager.ListInstances("", "ROLES")
        'Set frmRoles.rs = rs
        'Set frmRoles.Manager = Manager
        'Set frmRoles.Session = Session
        'frmRoles.Show

        'journal = model.Manager.GetInstanceObject("{DB8F8C01-D05A-44B6-B80C-16A6B7AA65D6}")

        'If Not journal Is Nothing Then
        '    Manager.LockInstanceObject(journal.ID)

        '    fRole = New frmJournalShow
        '    fRole.jv.set_journal(journal)
        '    fRole.jv.AllowAdd = True
        '    fRole.jv.AllowDel = True
        '    fRole.jv.AllowFilter = False

        '    fRole.Text = journal.Name
        '    fRole.Show()
        '    'UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        '    fRole.jv.CtlRefresh()
        'Else
        '    'Set frmRoles.Manager = Manager
        '    'Set frmRoles.Session = Session
        '    'frmRoles.Show
        'End If
    End Sub

    Public Sub mnuSaveDocs_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuSaveDocs.Click
        Dim f As frmSaveTool
        f = New frmSaveTool
        f.ShowDialog()
        f.Close()
    End Sub

    Public Sub mnuSaveFieldTypes_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuSaveFieldTypes.Click
        Dim f As frmSaveFT
        f = New frmSaveFT
        f.ShowDialog()
        f.Close()
        'UPGRADE_NOTE: Object f may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        f = Nothing
    End Sub

    Public Sub mnuSaveMethods_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuSaveMethods.Click
        Dim f As frmSaveMTD
        f = New frmSaveMTD
        f.ShowDialog()
        f.Close()
        'UPGRADE_NOTE: Object f may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        f = Nothing
    End Sub



    Public Sub mnuSetupModes_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        'Dim f As frmSetMode 'Tools
        'f = frmSetMode ' Tools
        'f.Show() 'vbModal

        MsgBox("todo")

    End Sub

    Public Sub mnuSetupState_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        'frmStateTool.Show()
        MsgBox("todo")
    End Sub



    Public Sub mnuSort_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        'frmSortFieldOrObj.ShowDialog()
        MsgBox("todo")
    End Sub

    Public Sub mnuSwitchLang_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuSwitchLang.Click
        'UPGRADE_NOTE: pv was upgraded to pv_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        Dim pv_Renamed As Object
        Dim IDv As Guid
        Dim Briefv As String

        If Not guiManager.GetReferenceDialog("LocalizeInfo", "", Guid.Empty, IDv, Briefv) Then

            Exit Sub
        End If


        pv_Renamed = model.Application.FindRowObject("LocalizeInfo", IDv)
        If pv_Renamed Is Nothing Then Exit Sub
        'UPGRADE_WARNING: Couldn't resolve default property of object pv_Renamed.LangShort. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Manager.Session.Language = pv_Renamed.LangShort
        'Session.GetData ("update the_session set Lang='" + pv.LangShort + "' where the_sessionid='" + Session.sessionid + "'")
        MsgBox("Язык - " & Manager.Session.Language)

    End Sub



    Public Sub mnuToolLoadDesc_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuToolLoadDesc.Click
        Dim f As frmLoadDesc
        f = New frmLoadDesc
        f.ShowDialog()
        f.Close()
    End Sub

    Public Sub mnuToolSaveDesc_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuToolSaveDesc.Click
        Dim f As frmSaveDesc
        f = New frmSaveDesc
        f.ShowDialog()
        f.Close()
    End Sub

    Public Sub mnuUniqTool_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuUniqTool.Click
        Dim f As frmUniqueTool
        f = New frmUniqueTool
        f.ShowDialog()
        f.Close()
    End Sub

    Public Sub mnuUnlockAll_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuUnlockAll.Click

        Dim v As LATIR2.NamedValues
        If MsgBox("Будут отменены все блокировки документов." & vbCrLf & "Разблокировать документы ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ВНИМАНИЕ") = MsgBoxResult.Yes Then
            On Error GoTo bye

            Call Manager.Session.GetData("AdminUnlockAll")
        End If
        Exit Sub
bye:
        MsgBox(Err.Description)

    End Sub







    Private inTimer2 As Boolean = False

    Private Sub Timer2_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Timer2.Tick
        If inTimer2 Then Exit Sub
        inTimer2 = True

        If Not Manager.Session.SessionID.Equals(Guid.Empty) Then
            Dim nv As NamedValues = New NamedValues
            nv.Add("CURSESSION", Manager.Session.GetProvider.ID2Param(Manager.Session.SessionID), Manager.Session.GetProvider.ID2DbType, Manager.Session.GetProvider.ID2Size)
            Try
                Manager.Session.Exec("SessionTouch", nv)
            Catch ex As Exception

            End Try

            If Not GetActiveItem() Is Nothing Then
                mnuDocument.Visible = True
            Else
                mnuDocument.Visible = False
            End If
        End If
        inTimer2 = False

    End Sub



    Private Function Notabs(ByVal s As String) As String
        Notabs = Replace(Replace(Replace(Replace(s, vbTab, " "), vbCrLf, " "), vbCr, " "), vbLf, " ")
    End Function



    Public Sub mnuDictionaries_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuDictionaries.Click
        Dim f As frmDicList
        f = New frmDicList
        f.model = model
        f.ShowDialog()
        Dim ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE
        Dim rs As DataTable
        Dim o1 As LATIR2.Document.Doc_Base, o2 As LATIR2GuiManager.Doc_GUIBase
        Dim ID As Guid
        If f.OK Then
            ot = model.FindRowObject("OBJECTTYPE", New Guid(f.Result))
            rs = Manager.Session.GetRowsDT("INSTANCE", guiManager.Manager.Session.GetProvider.InstanceFieldList, , , "objtype='" & ot.Name & "'")
            If rs.Rows.Count = 0 Then
                ID = Guid.NewGuid
                Manager.NewInstance(ID, ot.Name, ot.the_Comment)
            Else
                ID = New Guid(rs.Rows(0)("InstanceID").ToString)
            End If

            o1 = Manager.GetInstanceObject(ID)
            If o1 Is Nothing Then
                MsgBox("Отсутствует объектная библиотека для типа:" & ot.the_Comment, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            o2 = guiManager.GetTypeGUI(o1.TypeName)
            If o2 Is Nothing Then
                MsgBox("Отсутствует интерфейсный компонент для типа:" & ot.the_Comment, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            'UPGRADE_WARNING: Couldn't resolve default property of object o2.Show. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            o2.ShowForm("", o1)
        End If
    End Sub

    Public Sub mnuDocuments_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuDocuments.Click
        frmDocList.model = model
        frmDocList.ShowDialog()
        Dim ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE
        Dim rs As DataTable
        Dim o1 As LATIR2.Document.Doc_Base, o2 As LATIR2GuiManager.Doc_GUIBase
        Dim ID As Guid
        If frmDocList.OK Then
            ot = model.OBJECTTYPE.Item(frmDocList.Result)
            ID = Guid.NewGuid
            Manager.NewInstance(ID, ot.Name, ot.the_Comment & " " & Now)
            o1 = Manager.GetInstanceObject(ID)
            If o1 Is Nothing Then
                MsgBox("Отсутствует объектная библиотека для типа:" & ot.the_Comment, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            o2 = guiManager.GetTypeGUI(o1.TypeName)
            If o2 Is Nothing Then
                MsgBox("Отсутствует интерфейсный компонент для типа:" & ot.the_Comment, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            o2.ShowForm("", o1)
        End If
    End Sub



    Public Sub mnuSetupJ_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        'frmJouralList.model = model
        'frmJouralList.ShowDialog()
        'If frmJouralList.OK Then
        '    journal = model.Manager.GetInstanceObject(frmJouralList.Result)
        '    frmJournalConfig.JournalDef1.set_model(model)
        '    frmJournalConfig.JournalDef1.set_journal(journal)
        '    frmJournalConfig.ShowDialog()
        '    frmJournalConfig.Close()
        'End If
        MsgBox("todo")
    End Sub

    Public Sub mnuDocDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuDocDelete.Click
        On Error GoTo bye
        Dim item As LATIR2.Document.Doc_Base
        item = GetActiveItem()
        If item Is Nothing Then Exit Sub
        If MsgBox("Удалить документ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            item.UnLockResource()

            item.Manager.DeleteInstance(item)

            item.Manager.FreeInstanceObject(item.ID)
            Me.ActiveMdiChild.Close()
        End If
        Exit Sub
bye:
        MsgBox(Err.Description, MsgBoxStyle.Critical, "Ошибка при удалении")
    End Sub

    Public Sub mnuDocLoadXML_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuDocLoadXML.Click
        On Error Resume Next
        Dim item As LATIR2.Document.Doc_Base
        item = GetActiveItem()
        If item Is Nothing Then Exit Sub

        Dim fn As String
        Dim xdom As System.Xml.XmlDocument

        On Error GoTo bye

        cdlgOpen.Filter = "Документ XML |*.XML"
        cdlgSave.Filter = "Документ XML |*.XML"
        cdlgOpen.DefaultExt = "XML"
        cdlgSave.DefaultExt = "XML"
        'UPGRADE_WARNING: Couldn't resolve default property of object item.ID. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        cdlgOpen.FileName = My.Application.Info.DirectoryPath & "\" & item.ID.ToString() & ".xml"
        cdlgSave.FileName = My.Application.Info.DirectoryPath & "\" & item.ID.ToString() & ".xml"
        'UPGRADE_WARNING: FileOpenConstants constant FileOpenConstants.cdlOFNHideReadOnly was upgraded to OpenFileDialog.ShowReadOnly which has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"'
        'UPGRADE_WARNING: MSComDlg.CommonDialog property cdlg.Flags was upgraded to cdlgOpen.ShowReadOnly which has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"'
        'UPGRADE_WARNING: FileOpenConstants constant FileOpenConstants.cdlOFNHideReadOnly was upgraded to OpenFileDialog.ShowReadOnly which has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"'
        cdlgOpen.ShowReadOnly = False
        'UPGRADE_WARNING: MSComDlg.CommonDialog property cdlg.Flags was upgraded to cdlgOpen.CheckFileExists which has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"'
        cdlgOpen.CheckFileExists = True
        cdlgOpen.CheckPathExists = True
        cdlgSave.CheckPathExists = True
        cdlgOpen.ShowDialog()
        cdlgSave.FileName = cdlgOpen.FileName
        fn = cdlgOpen.FileName

        xdom = New System.Xml.XmlDocument
        xdom.Load(fn)
        'UPGRADE_WARNING: Couldn't resolve default property of object item.XMLLoad. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        item.XMLLoad(xdom.LastChild, 1)
        'UPGRADE_WARNING: Couldn't resolve default property of object item.WorkOffline. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'

        'UPGRADE_WARNING: Couldn't resolve default property of object item.BatchUpdate. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        item.BatchUpdate()
        'UPGRADE_NOTE: Object xdom may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        xdom = Nothing
bye:
    End Sub

    Public Sub mnuDocLock_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuDocLock.Click
        On Error Resume Next
        Dim item As LATIR2.Document.Doc_Base
        item = GetActiveItem()
        If item Is Nothing Then Exit Sub

        item.LockResource(True)


    End Sub

    Public Sub mnuDocSaveXML_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuDocSaveXML.Click
        On Error Resume Next
        Dim item As LATIR2.Document.Doc_Base
        item = GetActiveItem()
        If item Is Nothing Then Exit Sub

        'UPGRADE_WARNING: Couldn't resolve default property of object item.SecureStyleID. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: Couldn't resolve default property of object item.Application. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Dim fn As String
        Dim xdom As System.Xml.XmlDocument
        If item.Application.Session.CheckRight(item.SecureStyleID.ToString(), "XMLSAVE") Then

            On Error GoTo bye

            cdlgOpen.Filter = "Документ XML|*.XML"
            cdlgSave.Filter = "Документ XML|*.XML"
            cdlgOpen.DefaultExt = "XML"
            cdlgSave.DefaultExt = "XML"
            'UPGRADE_WARNING: Couldn't resolve default property of object item.ID. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            cdlgOpen.FileName = My.Application.Info.DirectoryPath & "\" & item.ID.ToString & ".xml"
            cdlgSave.FileName = My.Application.Info.DirectoryPath & "\" & item.ID.ToString & ".xml"
            'UPGRADE_WARNING: FileOpenConstants constant FileOpenConstants.cdlOFNHideReadOnly was upgraded to OpenFileDialog.ShowReadOnly which has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"'
            cdlgOpen.CheckPathExists = True
            cdlgSave.CheckPathExists = True
            'UPGRADE_WARNING: MSComDlg.CommonDialog property cdlg.Flags was upgraded to cdlgOpen.ShowReadOnly which has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"'
            'UPGRADE_WARNING: FileOpenConstants constant FileOpenConstants.cdlOFNHideReadOnly was upgraded to OpenFileDialog.ShowReadOnly which has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"'
            cdlgOpen.ShowReadOnly = False
            'UPGRADE_WARNING: MSComDlg.CommonDialog property cdlg.Flags was upgraded to cdlgSave.OverwritePrompt which has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"'
            cdlgSave.OverwritePrompt = True 'cdlOFNFileMustExist
            cdlgSave.ShowDialog()
            cdlgOpen.FileName = cdlgSave.FileName
            fn = cdlgOpen.FileName
            item.LockResource(True)

            xdom = New System.Xml.XmlDocument
            xdom.LoadXml("<root></root>")
            'UPGRADE_WARNING: Couldn't resolve default property of object item.XMLSave. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            item.XMLSave(xdom.LastChild, xdom)
            xdom.Save(fn)

        End If
bye:
    End Sub



    Public Sub mnuDocUnlock_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuDocUnlock.Click
        On Error Resume Next
        Dim item As LATIR2.Document.Doc_Base
        item = GetActiveItem()
        If item Is Nothing Then Exit Sub
        'UPGRADE_WARNING: Couldn't resolve default property of object item.IsLocked. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        If item.IsLocked Then
            'UPGRADE_WARNING: Couldn't resolve default property of object item.UnLockResource. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            item.UnLockResource()
        Else
            MsgBox("Объект не заблокирован", MsgBoxStyle.Information)
        End If

    End Sub

    Private Function GetActiveItem() As Object
        On Error Resume Next

        If Not Me.ActiveMdiChild Is Nothing Then
            If TypeName(Me.ActiveMdiChild) = "frmChild" Then
                'UPGRADE_ISSUE: Control item could not be resolved because it was within the generic namespace ActiveMDIChild. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                GetActiveItem = CType(Me.ActiveMdiChild, frmChild).Item
            End If
        End If
    End Function

    Private Sub KillTypes(ByRef item As MTZMetaModel.MTZMetaModel.MTZAPP)
        Dim ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE
        Dim mapp As MTZMetaModel.MTZMetaModel.Application
        Dim i As Integer
        mapp = item.Application
        On Error GoTo bye
tryagain:
        mapp.OBJECTTYPE.Refresh()
        For i = 1 To mapp.OBJECTTYPE.Count
            ot = mapp.OBJECTTYPE.Item(i)

            If ot.Package.ID.Equals(item.ID) Then
                ot.Delete()
            End If
        Next
bye:
    End Sub

    Private Sub frmMDI_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not Manager Is Nothing Then
            If Not Manager.Session Is Nothing Then
                Manager.Session.Logout()
            End If
        End If
    End Sub



    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''


    Private Sub frmMDI_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Manager = New LATIR2.Manager
        guiManager = New LATIR2GuiManager.LATIRGuiManager
        guiManager.Attach(Manager)
        LATIR2GuiManager.LATIRGuiManager.ScaleForm(Me)

        Dim username As String = GetSetting("LATIRADMIN", "SETTING", "UID", "")
        Dim sitename As String = GetSetting("LATIRADMIN", "SETTING", "SITE", "")
        If Not guiManager.Login(username, sitename) Then
            Application.Exit()
            Return
        End If
        SaveSetting("LATIRADMIN", "SETTING", "UID", username)
        SaveSetting("LATIRADMIN", "SETTING", "SITE", sitename)

        Dim dt As DataTable, oID As Guid
        dt = guiManager.Manager.Session.GetRowsExDT("INSTANCE", guiManager.Manager.Session.GetProvider.InstanceFieldList, , , "OBJTYPE='mtzmetamodel'")
        oID = New System.Guid(dt.Rows.Item(0).Item("INSTANCEID").ToString())
        model = CType(guiManager.Manager.GetInstanceObject(oID), MTZMetaModel.MTZMetaModel.Application)

        Me.Text = Application.ProductName & " :: " & sitename
        Timer2.Enabled = True
        Me.WindowState = FormWindowState.Maximized
    End Sub


    Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
        Application.Exit()
    End Sub

    Private Sub mnuFormEditTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFormEditTest.Click
        Dim f As testForm
        f = New testForm

        f.ShowDialog()
        f.Close()
        f = Nothing
    End Sub

    Private Sub MenuItem13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem13.Click
        Dim f As frmTest1
        f = New frmTest1
        f.ShowDialog()
        f = Nothing
    End Sub



    Private Sub MenuItem12_Click_1(sender As System.Object, e As System.EventArgs) Handles MenuItem12.Click
        Dim f As frmJournalViewIG
        f = New frmJournalViewIG
        f.MdiParent = Me
        f.Attach(guiManager)
        f.Show()

    End Sub

    Private Sub MenuItem17_Click(sender As System.Object, e As System.EventArgs) Handles MenuItem17.Click
        Dim f As frmChild
        f = New frmChild
        Dim ObjTypeName As String = "STDInfoStore"
        dt = guiManager.Manager.Session.GetRowsExDT("INSTANCE", guiManager.Manager.Session.GetProvider.InstanceFieldList, , , "OBJTYPE='" + ObjTypeName + "'")
        If dt.Rows.Count > 0 Then
            oID = New Guid(dt.Rows.Item(0).Item("INSTANCEID").ToString)
            Dim ed As MTZUsers.MTZUsers.Application
            ed = CType(guiManager.Manager.GetInstanceObject(oID), MTZUsers.MTZUsers.Application)
            If (Not ed Is Nothing) Then
                Dim Doc_GUIBase As LATIR2GuiManager.Doc_GUIBase
                Doc_GUIBase = guiManager.GetTypeGUI(ed.TypeName)
                'dg.ShowForm("", ed)
                Dim objControl As Object = Nothing
                Try
                    objControl = Doc_GUIBase.GetObjectControl(String.Empty, ObjTypeName)
                Catch
                End Try
                If (Not objControl Is Nothing) Then
                    f.AppendControl(Doc_GUIBase.GetObjectControl(String.Empty, ObjTypeName))
                    f.MdiParent = Me
                    f.Attach(guiManager, ed)
                    f.Show()
                Else
                    MessageBox.Show("Error occured while running the form")
                End If
            End If
        Else
            MsgBox("Нет ни одного каталога")
        End If
    End Sub

    Private Sub MenuItem18_Click(sender As System.Object, e As System.EventArgs) Handles MenuItem18.Click
        Dim f As frmChild
        f = New frmChild
        Dim ObjTypeName As String = "MTZUsers"
        dt = guiManager.Manager.Session.GetRowsExDT("INSTANCE", guiManager.Manager.Session.GetProvider.InstanceFieldList, , , "OBJTYPE='" + ObjTypeName + "'")
        oID = New Guid(dt.Rows.Item(0).Item("INSTANCEID").ToString)
        Dim ed As MTZUsers.MTZUsers.Application
        ed = CType(guiManager.Manager.GetInstanceObject(oID), MTZUsers.MTZUsers.Application)
        If (Not ed Is Nothing) Then
            Dim Doc_GUIBase As LATIR2GuiManager.Doc_GUIBase
            Doc_GUIBase = guiManager.GetTypeGUI(ed.TypeName)
            'dg.ShowForm("", ed)
            Dim objControl As Object = Nothing
            Try
                objControl = Doc_GUIBase.GetObjectControl(String.Empty, ObjTypeName)
            Catch
            End Try
            If (Not objControl Is Nothing) Then
                f.AppendControl(Doc_GUIBase.GetObjectControl(String.Empty, ObjTypeName))
                f.MdiParent = Me
                f.Attach(guiManager, ed)
                f.Show()
            Else
                MessageBox.Show("Error occured while running the form")
            End If
        End If
    End Sub

    Private Sub MenuItem16_Click(sender As System.Object, e As System.EventArgs) Handles MenuItem16.Click
        Dim f As frmAbout
        f = New frmAbout
        f.ShowDialog()
        f.Close()
    End Sub

    Private Sub mnuInitDict_Click(sender As System.Object, e As System.EventArgs) Handles mnuInitDict.Click
        frmDicList.model = model
        frmDicList.ShowDialog()
        Dim ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE
        Dim rs As DataTable
        Dim o1 As LATIR2.Document.Doc_Base, o2 As LATIR2GuiManager.Doc_GUIBase
        Dim ID As Guid
        If frmDicList.OK Then
            ot = model.FindRowObject("OBJECTTYPE", New Guid(frmDicList.Result))
            rs = Manager.Session.GetRowsDT("INSTANCE", guiManager.Manager.Session.GetProvider.InstanceFieldList, , , "objtype='" & ot.Name & "'")
            If rs.Rows.Count = 0 Then
                ID = Guid.NewGuid
                Manager.NewInstance(ID, ot.Name, ot.the_Comment)
            Else
                ID = New Guid(rs.Rows(0)("InstanceID").ToString)
            End If

            o1 = Manager.GetInstanceObject(ID)
            If o1 Is Nothing Then
                MsgBox("Отсутствует объектная библиотека для типа:" & ot.the_Comment, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
                Exit Sub
            End If

            Dim i As Integer
            Dim j As Integer
            Dim k As Integer
            Dim p As MTZMetaModel.MTZMetaModel.PART
            Dim fld As MTZMetaModel.MTZMetaModel.FIELD
            Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE
            Dim needload As Boolean
            Dim cb As LATIR2.Document.DocCollection_Base = Nothing

            For i = 1 To ot.PART.Count

                p = ot.PART.Item(i)
                needload = False

                For j = 1 To o1.CountOfParts
                    cb = o1.GetDocCollection_Base(j)
                    If cb.ChildPartName = p.Name Then
                        If cb.Count = 0 Or cb.Count = 10 Then
                            needload = True
                            Exit For
                        End If
                    End If

                Next
                If needload And Not cb Is Nothing Then
                    For k = 1 To 10
                        Dim row As LATIR2.Document.DocRow_Base
                        Dim s As String
                        Dim l As Integer
                        If cb.Count = 10 Then
                            row = cb.Item(k)
                        Else
                            row = cb.Add
                        End If


                        For l = 1 To row.Count

                            For j = 1 To p.FIELD.Count
                                fld = p.FIELD.Item(j)
                                If fld.Name = row.FieldNameByID(l) Then


                                    ft = fld.FieldType
                                    If ft.Name = "String" Then
                                        s = p.Caption & " " & k.ToString
                                        If s.Length > fld.DataSize Then
                                            s = s.Substring(0, fld.DataSize)
                                        End If
                                        row.Value(l) = s
                                    End If
                                End If

                            Next
                        Next

                        row.Save()

                    Next

                End If

            Next
        End If
    End Sub


    Private Sub MenuItem9_Click(sender As System.Object, e As System.EventArgs) Handles MenuItem9.Click
        Dim f As frmExportToMySQL
        f = New frmExportToMySQL
        f.ShowDialog()
        f.Close()
        f = Nothing
    End Sub

    Private Sub mnuFieldCopy_Click(sender As System.Object, e As System.EventArgs) Handles mnuFieldCopy.Click
        Dim frm As frmFieldCopy
        frm = New frmFieldCopy
        frm.ShowDialog()
        frm.Close()
        frm = Nothing

    End Sub

    Private Sub mnuSetupModes_Click_1(sender As System.Object, e As System.EventArgs) Handles mnuSetupModes.Click
        Dim f As frmModeSetup
        f = New frmModeSetup
        f.ShowDialog()
        f.Close()
        f = Nothing

    End Sub

    Private Sub mnuSequenceTool_Click(sender As System.Object, e As System.EventArgs) Handles mnuSequenceTool.Click
        Dim f As frmSequenceTool
        f = New frmSequenceTool
        f.ShowDialog()
        f.Close()
        f = Nothing
    End Sub


    Private Sub mnuPartCopy_Click(sender As System.Object, e As System.EventArgs) Handles mnuPartCopy.Click
        Dim frm As frmPartCopy
        frm = New frmPartCopy
        frm.ShowDialog()
        frm.Close()
        frm = Nothing

    End Sub

    Private Sub mnuScale_Click(sender As Object, e As EventArgs) Handles mnuScale.Click
        Dim f As frmScale
        f = New frmScale
        f.ShowDialog()

    End Sub
End Class
