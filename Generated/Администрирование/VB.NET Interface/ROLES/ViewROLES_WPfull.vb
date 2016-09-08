
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics

Imports LATIR2GuiManager
Public Class viewROLES_WPfull
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
        MyBase.Dispose(disposing)
    End Sub
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    Friend WithEvents gv As LATIR2GUIControls.GridGridView
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.gv = New LATIR2GUIControls.GridGridView
        Me.SuspendLayout()
        '
        'gv
        '
        Me.gv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gv.Caption = ""
        Me.gv.Location = New System.Drawing.Point(0, 0)
        Me.gv.Name = "gv"
        Me.gv.Size = New System.Drawing.Size(424, 392)
        Me.gv.TabIndex = 0
        '
        'viewROLES_WPfull
        '
        Me.Controls.Add(Me.gv)
        Me.Name = "viewROLES_WPfull"
        Me.Size = New System.Drawing.Size(424, 392)
        Me.ResumeLayout(False)
    End Sub
#End Region
    Public item As ROLES.ROLES.Application
    Public GuiManager As LATIR2GuiManager.LATIRGuiManager
    Private mReadOnly as boolean
    Public Sub Attach(ByVal docItem As LATIR2.Document.Doc_Base, ByVal gm As LATIR2GuiManager.LATIRGuiManager,byval ReadOnlyView as boolean )  Implements LATIR2GUIManager.IViewPanel.Attach
        mReadOnly = ReadOnlyView
        item = CType(docItem, ROLES.ROLES.Application)
        GuiManager = gm
        Init()
    End Sub
    Public Sub Init()
        Dim ts As DataGridTableStyle
        Dim cs As DataGridTextBoxColumn
        Dim dt As DataTable
        Dim i As Integer
        dt = item.ROLES_WP.GetDataTable()
        dt.TableName = "ROLES_WP"
        ts = New DataGridTableStyle
        ts.MappingName = "ROLES_WP"
        ts.ReadOnly = True
        ts.RowHeaderWidth = 30
        cs = New DataGridTextBoxColumn
        ' TextBoxColumn
        cs.ReadOnly = True
        cs.HeaderText = "Приложение"
        cs.MappingName = "WP"
        cs.NullText = ""
        ts.GridColumnStyles.Add(cs)
        gv.InitFieldsMaster(ts)
        ts = New DataGridTableStyle
        ts.MappingName = "ROLES_ACT"
        ts.ReadOnly = True
        ts.RowHeaderWidth = 30
        cs = New DataGridTextBoxColumn
        ' TextBoxColumn
        cs.ReadOnly = True
        cs.HeaderText = "Доступность"
        cs.MappingName = "Accesible"
        cs.NullText = ""
        ts.GridColumnStyles.Add(cs)
        cs = New DataGridTextBoxColumn
        ' TextBoxColumn
        cs.ReadOnly = True
        cs.HeaderText = "Меню"
        cs.MappingName = "MenuName"
        cs.NullText = ""
        ts.GridColumnStyles.Add(cs)
        cs = New DataGridTextBoxColumn
        ' TextBoxColumn
        cs.ReadOnly = True
        cs.HeaderText = "Код пункта меню"
        cs.MappingName = "menuCode"
        cs.NullText = ""
        ts.GridColumnStyles.Add(cs)
        gv.InitFieldsChild(ts)
        gv.SetDataMaster(dt)
    End Sub
    Private Sub gv_OnEdit(ByRef OK As Boolean, ByVal ID As System.Guid) Handles gv.OnMasterGridEdit
        Dim ed As ROLES.ROLES.ROLES_WP
        ed = item.FindRowObject("ROLES_WP", ID)
        Dim gui As Doc_GUIBase
        gui = GuiManager.GetTypeGUI(ed.Application.TypeName)
        If gui.ShowPartEditForm("full", CType(ed, LATIR2.Document.DocRow_Base ),mReadOnly ) = True Then
            Dim dt As DataTable
            dt = item.ROLES_WP.GetDataTable()
            dt.TableName = "ROLES_WP"
            gv.SetDataMaster(dt)
        End If
    End Sub
    Private Sub gv_OnDel(ByRef OK As Boolean, ByVal ID As System.Guid) Handles gv.OnMasterGridDel
      if not mReadOnly then
        Dim ed As ROLES.ROLES.ROLES_WP
        ed = item.FindRowObject("ROLES_WP", ID)
        If MsgBox("Удалить <" & ed.Brief & "> ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Удаление строки") = MsgBoxResult.Yes Then
            OK = ed.Parent.Delete(ed.ID.ToString)
            If OK Then
                Dim dt As DataTable
                'item.ROLES_WP.Refresh()
                dt = item.ROLES_WP.GetDataTable()
                dt.TableName = "ROLES_WP"
                gv.SetDataMaster(dt)
            End If
        End If
      End If
    End Sub
    Private Sub gv_OnAdd(ByRef OK As Boolean) Handles gv.OnMasterGridAdd
      if not mReadOnly then
        Dim ed As ROLES.ROLES.ROLES_WP
        ed = item.ROLES_WP.Add
        Dim gui As Doc_GUIBase
        Dim dt As DataTable
        gui = GuiManager.GetTypeGUI(ed.Application.TypeName)
        If gui.ShowPartEditForm("full", CType(ed, LATIR2.Document.DocRow_Base )) = True Then
            dt = item.ROLES_WP.GetDataTable()
            dt.TableName = "ROLES_WP"
            gv.SetDataMaster(dt)
        Else
            item.ROLES_WP.Refresh()
        End If
      End If
    End Sub
    Private Sub gv_OnRefresh() Handles gv.OnMasterGridRefresh
        Dim dt As DataTable
        item.ROLES_WP.Refresh()
        dt = item.ROLES_WP.GetDataTable()
        dt.TableName = "ROLES_WP"
        gv.SetDataMaster(dt)
    End Sub
    Private Sub gv_OnChildRefresh() Handles gv.OnChildGridRefresh
        Dim ed As ROLES.ROLES.ROLES_WP
        ed = item.FindRowObject("ROLES_WP", gv.GetMasterID)
        Dim dt As DataTable
        If Not ed Is Nothing Then
            dt = ed.ROLES_ACT.GetDataTable
        Else
            dt = New DataTable
        End If
        dt.TableName = "ROLES_ACT"
        gv.SetDataChild(dt)
    End Sub
    Private Sub gv_OnChildDel(ByRef OK As Boolean, ByVal ID As System.Guid) Handles gv.OnChildGridDel
      if not mReadOnly then
        Dim parent As ROLES.ROLES.ROLES_WP
        parent = item.FindRowObject("ROLES_WP", gv.GetMasterID)
        Dim ed As ROLES.ROLES.ROLES_ACT
        ed = item.FindRowObject("ROLES_ACT", ID)
        If MsgBox("Удалить <" & ed.Brief & "> ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Удаление строки") = MsgBoxResult.Yes Then
            OK = ed.Parent.Delete(ed.ID.ToString)
            If OK Then
                Dim dt As DataTable
                'parent.ROLES_WP.Refresh()
                dt = parent.ROLES_ACT.GetDataTable()
                dt.TableName = "ROLES_ACT"
                gv.SetDataChild(dt)
            End If
        End If
      End If
    End Sub
    Private Sub gv_OnChildEdit(ByRef OK As Boolean, ByVal ID As System.Guid) Handles gv.OnChildGridEdit
        Dim parent As ROLES.ROLES.ROLES_WP
        parent = item.FindRowObject("ROLES_WP", gv.GetMasterID)
        Dim ed As ROLES.ROLES.ROLES_ACT
        ed = item.FindRowObject("ROLES_ACT", ID)
        Dim gui As Doc_GUIBase
        gui = GuiManager.GetTypeGUI(ed.Application.TypeName)
        If gui.ShowPartEditForm("full", CType(ed, LATIR2.Document.DocRow_Base ),mreadonly) = True Then
            Dim dt As DataTable
            'parent.ROLES_WP.Refresh()
            dt = parent.ROLES_ACT.GetDataTable()
            dt.TableName = "ROLES_ACT"
            gv.SetDataChild(dt)
        End If
    End Sub
    Private Sub gv_OnChildAdd(Byref OK As Boolean) Handles gv.OnChildGridAdd
      if not mReadOnly then
        Dim parent As ROLES.ROLES.ROLES_WP
        parent = item.FindRowObject("ROLES_WP", gv.GetMasterID)
        Dim ed As ROLES.ROLES.ROLES_ACT
        ed = parent.ROLES_ACT.Add
        Dim gui As Doc_GUIBase
        gui = GuiManager.GetTypeGUI(ed.Application.TypeName)
        If gui.ShowPartEditForm("full", CType(ed, LATIR2.Document.DocRow_Base ) ) = True Then
            Dim dt As DataTable
            'parent.ROLES_WP.Refresh()
            dt = parent.ROLES_ACT.GetDataTable()
            dt.TableName = "ROLES_ACT"
            gv.SetDataChild(dt)
        Else
            parent.ROLES_ACT.Refresh()
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
