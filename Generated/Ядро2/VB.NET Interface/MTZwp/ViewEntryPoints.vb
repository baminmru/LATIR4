
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics

Public Class viewEntryPoints
    Inherits System.Windows.Forms.UserControl
    Implements LATIR2GUIManager.IViewPanel
#Region " Windows Form Designer generated code "
    Public Sub New()
        MyBase.New()
        InitializeComponent()
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
    Friend WithEvents TreeView1 As LATIR2GUIControls.TreeView
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.TreeView1 = New LATIR2GUIControls.TreeView
        Me.SuspendLayout()
        '
        'TreeView1
        '
        Me.TreeView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TreeView1.Caption = ""
        Me.TreeView1.Location = New System.Drawing.Point(0, 8)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(680, 304)
        Me.TreeView1.TabIndex = 0
        '
        'view" & p.name & "
        '
        Me.Controls.Add(Me.TreeView1)
        Me.Name = "viewEntryPoints"
        Me.Size = New System.Drawing.Size(496, 288)
        Me.ResumeLayout(False)
    End Sub
#End Region


''' <summary>
'''Reference to the document, that serve control
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public item As MTZwp.MTZwp.Application
    Private mReadOnly as boolean
    Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Control initialization
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Sub Attach(ByVal docItem As LATIR2.Document.Doc_Base, ByVal gm As LATIR2GuiManager.LATIRGuiManager, byval ReadOnlyView as boolean )  Implements LATIR2GUIManager.IViewPanel.Attach
        mReadOnly = ReadOnlyView
        item = CType(docItem, MTZwp.MTZwp.Application)
        GuiManager = gm
        InitCols()
        TreeView1.Attach(gm, "EntryPoints", "Brief", "")
    End Sub


''' <summary>
'''Load column settings
''' </summary>
''' <remarks>
'''
''' </remarks>
    Private Sub InitCols()
        Dim ts As DataGridTableStyle
        Dim cs As DataGridTextBoxColumn

        ts = New DataGridTableStyle
        ts.MappingName = "EntryPoints"
        ts.ReadOnly = True
        ts.RowHeaderWidth = 30

        cs = New DataGridTextBoxColumn
        cs.ReadOnly = True
        cs.HeaderText = "Кратко"
        cs.MappingName = "Brief"
        cs.NullText = ""
        ts.GridColumnStyles.Add (cs)

        cs = New DataGridTextBoxColumn
        cs.ReadOnly = True
        cs.HeaderText = "Последовательность"
        cs.MappingName = "sequence"
        cs.NullText = ""
        ts.GridColumnStyles.Add (cs)

        cs = New DataGridTextBoxColumn
        cs.ReadOnly = True
        cs.HeaderText = "Название"
        cs.MappingName = "Name"
        cs.NullText = ""
        ts.GridColumnStyles.Add (cs)

        cs = New DataGridTextBoxColumn
        cs.ReadOnly = True
        cs.HeaderText = "Заголовок"
        cs.MappingName = "Caption"
        cs.NullText = ""
        ts.GridColumnStyles.Add (cs)

        cs = New DataGridTextBoxColumn
        cs.ReadOnly = True
        cs.HeaderText = "Включить в тулбар"
        cs.MappingName = "AsToolbarItem"
        cs.NullText = ""
        ts.GridColumnStyles.Add (cs)

        cs = New DataGridTextBoxColumn
        cs.ReadOnly = True
        cs.HeaderText = "Вариант действия"
        cs.MappingName = "ActionType"
        cs.NullText = ""
        ts.GridColumnStyles.Add (cs)

        cs = New DataGridTextBoxColumn
        cs.ReadOnly = True
        cs.HeaderText = "Фильтр"
        cs.MappingName = "TheFilter"
        cs.NullText = ""
        ts.GridColumnStyles.Add (cs)

        cs = New DataGridTextBoxColumn
        cs.ReadOnly = True
        cs.HeaderText = "Журнал"
        cs.MappingName = "Journal"
        cs.NullText = ""
        ts.GridColumnStyles.Add (cs)

        cs = New DataGridTextBoxColumn
        cs.ReadOnly = True
        cs.HeaderText = "Отчет"
        cs.MappingName = "Report"
        cs.NullText = ""
        ts.GridColumnStyles.Add (cs)

        cs = New DataGridTextBoxColumn
        cs.ReadOnly = True
        cs.HeaderText = "Документ"
        cs.MappingName = "Document"
        cs.NullText = ""
        ts.GridColumnStyles.Add (cs)

        cs = New DataGridTextBoxColumn
        cs.ReadOnly = True
        cs.HeaderText = "Метод"
        cs.MappingName = "Method"
        cs.NullText = ""
        ts.GridColumnStyles.Add (cs)

        cs = New DataGridTextBoxColumn
        cs.ReadOnly = True
        cs.HeaderText = "Файл картинки"
        cs.MappingName = "IconFile"
        cs.NullText = ""
        ts.GridColumnStyles.Add (cs)

        cs = New DataGridTextBoxColumn
        cs.ReadOnly = True
        cs.HeaderText = "Расширение"
        cs.MappingName = "TheExtention"
        cs.NullText = ""
        ts.GridColumnStyles.Add (cs)

        cs = New DataGridTextBoxColumn
        cs.ReadOnly = True
        cs.HeaderText = "АРМ"
        cs.MappingName = "ARM"
        cs.NullText = ""
        ts.GridColumnStyles.Add (cs)

        cs = New DataGridTextBoxColumn
        cs.ReadOnly = True
        cs.HeaderText = "Примечание"
        cs.MappingName = "TheComment"
        cs.NullText = ""
        ts.GridColumnStyles.Add (cs)

        cs = New DataGridTextBoxColumn
        cs.ReadOnly = True
        cs.HeaderText = "Тип документа"
        cs.MappingName = "ObjectType"
        cs.NullText = ""
        ts.GridColumnStyles.Add (cs)

        cs = New DataGridTextBoxColumn
        cs.ReadOnly = True
        cs.HeaderText = "Ограничения к журналу"
        cs.MappingName = "JournalFixedQuery"
        cs.NullText = ""
        ts.GridColumnStyles.Add (cs)

        cs = New DataGridTextBoxColumn
        cs.ReadOnly = True
        cs.HeaderText = "Разрешено добавление"
        cs.MappingName = "AllowAdd"
        cs.NullText = ""
        ts.GridColumnStyles.Add (cs)

        cs = New DataGridTextBoxColumn
        cs.ReadOnly = True
        cs.HeaderText = "Разрешено редактирование"
        cs.MappingName = "AllowEdit"
        cs.NullText = ""
        ts.GridColumnStyles.Add (cs)

        cs = New DataGridTextBoxColumn
        cs.ReadOnly = True
        cs.HeaderText = "Рарешено удаление"
        cs.MappingName = "AllowDel"
        cs.NullText = ""
        ts.GridColumnStyles.Add (cs)

        cs = New DataGridTextBoxColumn
        cs.ReadOnly = True
        cs.HeaderText = "Разрешен фильтр"
        cs.MappingName = "AllowFilter"
        cs.NullText = ""
        ts.GridColumnStyles.Add (cs)

        cs = New DataGridTextBoxColumn
        cs.ReadOnly = True
        cs.HeaderText = "Разрешена печать"
        cs.MappingName = "AllowPrint"
        cs.NullText = ""
        ts.GridColumnStyles.Add (cs)

        TreeView1.InitTreeColumns (ts)
    End Sub



''' <summary>
'''Load data to tree
''' </summary>
''' <remarks>
'''
''' </remarks>
    Private Sub TreeView1_GetLevelData(ByVal Parent As System.Guid) Handles TreeView1.OnTreeGetData
        Dim dt As DataTable
        Dim f As MTZwp.MTZwp.EntryPoints
        If Parent.Equals(System.Guid.Empty) Then
            dt = item.EntryPoints.GetDataTable
            TreeView1.LoadLevelData(Parent, dt)
        Else
            f = CType(item.FindRowObject("EntryPoints", Parent), MTZwp.MTZwp.EntryPoints)
            dt = f.EntryPoints.GetDataTable
            TreeView1.LoadLevelData(Parent, dt)
        End If
    End Sub


''' <summary>
'''Обслуживание добавления в корневой элемент
''' </summary>
''' <remarks>
'''
''' </remarks>
    Private Sub TreeView1_OnAddRoot(Byref OK As Boolean) Handles TreeView1.OnTreeAddRoot
      if not mReadOnly then
        Dim ed As MTZwp.MTZwp.EntryPoints
        ed = item.EntryPoints.Add
        Dim gui As LATIR2GuiManager.Doc_GUIBase
        Dim dt As DataTable
        gui = GuiManager.GetTypeGUI(ed.Application.TypeName)
        If gui.ShowPartEditForm("", CType(ed, LATIR2.Document.DocRow_Base )) = True Then
            TreeView1.RefreshData()
        Else
            item.EntryPoints.Refresh()
        End If
      End If
    End Sub


''' <summary>
'''Обслуживание редактирования
''' </summary>
''' <remarks>
'''
''' </remarks>
    Private Sub gv_OnEdit(Byref OK As Boolean, ByVal ID As System.Guid) Handles TreeView1.OnTreeEdit
        Dim ed As MTZwp.MTZwp.EntryPoints
        ed = item.FindRowObject("EntryPoints", ID)
        Dim gui As LATIR2GuiManager.Doc_GUIBase
        gui = GuiManager.GetTypeGUI(ed.Application.TypeName)
        If gui.ShowPartEditForm("", CType(ed, LATIR2.Document.DocRow_Base ), mReadOnly) = True Then
            if Typeof(ed.parent.parent) is MTZwp.MTZwp.EntryPoints then
              TreeView1_GetLevelData(ed.parent.parent.id) 
            else
              TreeView1.RefreshData()
            end if
        End If
    End Sub


''' <summary>
'''Обслуживание удаления
''' </summary>
''' <remarks>
'''
''' </remarks>
    Private Sub gv_OnDel(Byref OK As Boolean, ByVal ID As System.Guid) Handles TreeView1.OnTreeDel
      if not mReadOnly then
        Dim ed As MTZwp.MTZwp.EntryPoints
        Dim edp As Object
        ed = item.FindRowObject("EntryPoints", ID)
        if ed  is nothing then exit sub
        edp=ed.parent.parent
        If MsgBox("Удалить <" & ed.Brief & "> ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Удаление строки") = MsgBoxResult.Yes Then
            OK = ed.Parent.Delete(ed.ID.ToString)
            If OK Then
              if Typeof(edp) is MTZwp.MTZwp.EntryPoints then
               TreeView1_GetLevelData(edp.id) 
             else
                TreeView1.RefreshData()
              end if
            End If
        End If
      End If
    End Sub


''' <summary>
'''Обслуживание добавления в уровень дерева
''' </summary>
''' <remarks>
'''
''' </remarks>
    Private Sub gv_OnAdd(Byref OK As Boolean, ByVal ID As System.Guid) Handles TreeView1.OnTreeAdd
      if not mReadOnly then
        Dim ed As MTZwp.MTZwp.EntryPoints
        Dim fs As MTZwp.MTZwp.EntryPoints
        fs = item.FindRowObject("EntryPoints", ID)
        ed = fs.EntryPoints.Add()
        Dim gui As LATIR2GuiManager.Doc_GUIBase
        Dim dt As DataTable
        gui = GuiManager.GetTypeGUI(ed.Application.TypeName)
        If gui.ShowPartEditForm("", CType(ed,LATIR2.Document.DocRow_Base) ) = True Then
            if Typeof(ed.parent.parent) is MTZwp.MTZwp.EntryPoints then
              TreeView1_GetLevelData(ed.parent.parent.id) 
            else
              TreeView1.RefreshData()
            end if
        Else
            item.EntryPoints.Refresh()
        End If
      End If
    End Sub
 Public Function Save(ByVal Sielent As Boolean, ByVal NoError As Boolean) As Boolean Implements LATIR2GUIManager.IViewPanel.Save
     Return true
 End Function
 Public Function IsOK() As Boolean Implements LATIR2GUIManager.IViewPanel.IsOK
     Return true
 End Function
 Public Function IsChanged() As Boolean Implements LATIR2GUIManager.IViewPanel.IsChanged
     Return false
 End Function
 Public Function Verify(ByVal NoError As Boolean) As Boolean Implements LATIR2GUIManager.IViewPanel.Verify
     Return true
 End Function
End Class
