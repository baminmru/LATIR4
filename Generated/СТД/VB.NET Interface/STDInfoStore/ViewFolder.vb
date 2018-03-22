
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

  Public Class viewFolder
    Inherits System.Windows.Forms.UserControl
    Implements LATIR2GUIManager.IViewPanel

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
        MyBase.Dispose (disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    Friend WithEvents tgv As LATIR2GUIControls.TreeGridView
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.tgv = New LATIR2GUIControls.TreeGridView
        Me.SuspendLayout()
        '
        'tgv
        '
        Me.tgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tgv.Location = New System.Drawing.Point(0, 0)
        Me.tgv.name = "tgv"
        Me.tgv.Size = New System.Drawing.Size(520, 304)
        Me.tgv.TabIndex = 0
        '
        'viewFolder
        '
        Me.Controls.Add (Me.tgv)
        Me.name = "viewFolder"
        Me.Size = New System.Drawing.Size(512, 304)
        Me.ResumeLayout (False)

    End Sub

#End Region
    Public item As STDInfoStore.STDInfoStore.Application
    Public GuiManager As LATIR2GuiManager.LATIRGuiManager
    Private mReadOnly as boolean
    Public Sub Attach(ByVal docItem As LATIR2.Document.Doc_Base, ByVal gm As LATIR2GuiManager.LATIRGuiManager,byval ReadOnlyView as boolean)  Implements LATIR2GUIManager.IViewPanel.Attach
        mReadOnly = ReadOnlyView
        item = CType(docItem, STDInfoStore.STDInfoStore.Application)
        GuiManager = gm
        InitCols()
        tgv.Attach(gm, "Folder", "Brief")
        Dim ts As DataGridTableStyle
        Dim cs As DataGridTextBoxColumn


        ts = New DataGridTableStyle
        ts.MappingName = "Shortcut"
        ts.ReadOnly = True
        ts.RowHeaderWidth = 30

        cs = New DataGridTextBoxColumn
        cs.ReadOnly = True
        cs.HeaderText = "Документ"
        cs.MappingName = "DocItem"
        cs.NullText = ""
        ts.GridColumnStyles.Add (cs)
        cs = New DataGridTextBoxColumn
        cs.ReadOnly = True
        cs.HeaderText = "Режим"
        cs.MappingName = "StartMode"
        cs.NullText = ""
        ts.GridColumnStyles.Add (cs)
        tgv.InitChildFields (ts)
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
        ts.MappingName = "Folder"
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
        cs.HeaderText = "Название"
        cs.MappingName = "Name"
        cs.NullText = ""
        ts.GridColumnStyles.Add (cs)

        cs = New DataGridTextBoxColumn
        cs.ReadOnly = True
        cs.HeaderText = "Тип папки"
        cs.MappingName = "FolderType"
        cs.NullText = ""
        ts.GridColumnStyles.Add (cs)

        tgv.InitTreeColumns (ts)
    End Sub


    Private Sub tgv_GetLevelData(ByVal Parent As System.Guid) Handles tgv.OnTreeGetData
        Dim dt As DataTable
        Dim f As STDInfoStore.STDInfoStore.Folder
        If Parent.Equals(System.guid.Empty) Then
            dt = item.Folder.GetDataTable
            tgv.LoadLevelData(Parent, dt)
        Else
            f = CType(item.FindRowObject("Folder", Parent), STDInfoStore.STDInfoStore.Folder)
            dt = f.Folder.GetDataTable
            tgv.LoadLevelData(Parent, dt)
        End If
    End Sub

    Private Sub tgv_OnAddRoot(Byref OK As Boolean) Handles tgv.OnTreeAddRoot
      if not mReadOnly then
        Dim ed As STDInfoStore.STDInfoStore.Folder
        ed = item.Folder.Add
        Dim gui As LATIR2GuiManager.Doc_GUIBase
        Dim dt As DataTable
        gui = GuiManager.GetTypeGUI(ed.Application.TypeName)
        If gui.ShowPartEditForm("", CType( ed, LATIR2.Document.DocRow_Base) ) = True Then
            tgv.RefreshData()
        Else
            item.Folder.Refresh()
        End If
      End If
    End Sub

    Private Sub tgv_OnEdit(Byref OK As Boolean, ByVal ID As System.Guid) Handles tgv.OnTreeEdit
        Dim ed As STDInfoStore.STDInfoStore.Folder
        Dim gui As LATIR2GuiManager.Doc_GUIBase
        Dim edp As Object
        ed = item.FindRowObject("Folder", ID)
        if ed is nothing then exit sub
        edp =ed.parent.parent
        gui = GuiManager.GetTypeGUI(ed.Application.TypeName)
        If gui.ShowPartEditForm("", CType(ed,LATIR2.Document.DocRow_Base ),mreadonly ) = True Then
              if typeof(edp) is STDInfoStore.STDInfoStore.Folder then 
                tgv_GetLevelData(edp.id) 
              Else
                tgv.RefreshData()
              End If
        End If
    End Sub

    Private Sub tgv_OnDel(ByRef OK As Boolean, ByVal ID As System.Guid) Handles tgv.OnTreeDel
      if not mReadOnly then
        Dim ed As STDInfoStore.STDInfoStore.Folder
        Dim edp As Object
        ed = item.FindRowObject("Folder", ID)
        if ed is nothing then exit sub
        edp =ed.parent.parent
        If MsgBox("Удалить <" & ed.Brief & "> ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Удаление строки") = MsgBoxResult.Yes Then
            OK = ed.Parent.Delete(ed.ID.ToString)
            If OK Then
              if typeof(edp) is STDInfoStore.STDInfoStore.Folder then 
                tgv_GetLevelData(edp.id) 
              Else
                tgv.RefreshData()
              End If
            End If
        End If
      End If
    End Sub

    Private Sub tgv_OnAdd(ByRef OK As Boolean, ByVal ID As System.Guid) Handles tgv.OnTreeAdd
      if not mReadOnly then
        Dim ed As STDInfoStore.STDInfoStore.Folder
        Dim fs As STDInfoStore.STDInfoStore.Folder

        fs = item.FindRowObject("Folder", ID)
        ed = fs.Folder.Add()

        Dim gui As LATIR2GuiManager.Doc_GUIBase
        Dim dt As DataTable
        gui = GuiManager.GetTypeGUI(ed.Application.TypeName)
        If gui.ShowPartEditForm("", CType( ed, LATIR2.Document.DocRow_Base) ) = True Then
            tgv_GetLevelData(fs.id) 
        Else
            fs.Folder.Refresh()
        End If
      End If
    End Sub

    Private Sub tgv_OnChildRefresh(ByVal ParentID As System.Guid) Handles tgv.OnGridRefresh

        Dim fs As STDInfoStore.STDInfoStore.Folder
        fs = item.FindRowObject("Folder", ParentID)
        Dim dt As DataTable
        dt = fs.Shortcut.GetDataTable
        dt.TableName = "Shortcut"
        tgv.SetChildData (dt)
    End Sub

    Private Sub tgv_OnChildAdd(ByRef OK As Boolean, ByVal ParentID As System.Guid) Handles tgv.OnGridAdd
      if not mReadOnly then
        Dim ed As STDInfoStore.STDInfoStore.Shortcut
        Dim fs As STDInfoStore.STDInfoStore.Folder
        fs = item.FindRowObject("Folder", ParentID)
        ed = fs.Shortcut.Add()
        Dim gui As LATIR2GuiManager.Doc_GUIBase
        Dim dt As DataTable
        gui = GuiManager.GetTypeGUI(ed.Application.TypeName)
        If gui.ShowPartEditForm("", CType(ed, LATIR2.Document.DocRow_Base ) ) = True Then
            dt = fs.Shortcut.GetDataTable
            dt.TableName = "Shortcut"
            tgv.SetChildData (dt)
        Else
            fs.Shortcut.Refresh()
        End If
      End If
    End Sub

    Private Sub tgv_OnChildDel(ByRef OK As Boolean, ByVal ParentID As System.Guid, ByVal ID As System.Guid) Handles tgv.OnGridDel
      if not mReadOnly then
        Dim fs As STDInfoStore.STDInfoStore.Folder
        fs = item.FindRowObject("Folder", ParentID)
        Dim ed As STDInfoStore.STDInfoStore.Shortcut
        ed = item.FindRowObject("Shortcut", ID)
        Dim dt As DataTable
        If MsgBox("Удалить <" & ed.Brief & "> ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Удаление строки") = MsgBoxResult.Yes Then
            OK = ed.Parent.Delete(ed.ID.ToString)
            If OK Then
                dt = fs.Shortcut.GetDataTable
                dt.TableName = "Shortcut"
                tgv.SetChildData (dt)
            End If
        End If
      End If
    End Sub

    Private Sub tgv_OnChildEdit(ByRef OK As Boolean, ByVal ParentID As System.Guid, ByVal ID As System.Guid) Handles tgv.OnGridEdit
        Dim ed As STDInfoStore.STDInfoStore.Shortcut
        Dim fs As STDInfoStore.STDInfoStore.Folder
        fs = item.FindRowObject("Folder", ParentID)
        ed = item.FindRowObject("Shortcut", ID)
        Dim gui As LATIR2GuiManager.Doc_GUIBase
        Dim dt As DataTable
        gui = GuiManager.GetTypeGUI(ed.Application.TypeName)
        If gui.ShowPartEditForm("", CType(ed, LATIR2.Document.DocRow_Base ),mReadOnly ) = True Then
            dt = fs.Shortcut.GetDataTable
            dt.TableName = "Shortcut"
            tgv.SetChildData (dt)
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
