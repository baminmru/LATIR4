
Imports System.Windows.Forms
Imports Microsoft.VisualBasic



''' <summary>
'''Контрол редактирования раздела Папка режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editFolder
    Inherits System.Windows.Forms.UserControl
    Implements LATIR2GUIManager.IRowEditor

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub
    private mOnInit as boolean = false
    private mChanged as boolean = false
    public event Changed() Implements LATIR2GUIManager.IRowEditor.Changed 
    Public Event Saved() Implements LATIR2GUIManager.IRowEditor.Saved
    Public Event Refreshed() Implements LATIR2GUIManager.IRowEditor.Refreshed
    Public Sub Changing()
      if not mOnInit then
        mChanged = true
        raiseevent Changed()
      end if
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

 dim iii as integer
    Friend WithEvents HolderPanel As LATIR2GUIControls.AutoPanel
Friend WithEvents lblName  as  System.Windows.Forms.Label
Friend WithEvents txtName As System.Windows.Forms.TextBox
Friend WithEvents lblFolderType  as  System.Windows.Forms.Label
Friend WithEvents cmbFolderType As System.Windows.Forms.ComboBox
Friend cmbFolderTypeDATA As DataTable
Friend cmbFolderTypeDATAROW As DataRow

<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

 Me.HolderPanel = New LATIR2GUIControls.AutoPanel
 Me.HolderPanel.SuspendLayout()
Me.SuspendLayout()
 '
'HolderPanel
'
Me.HolderPanel.AllowDrop = True
Me.HolderPanel.BackColor = System.Drawing.SystemColors.Control
Me.HolderPanel.Dock = System.Windows.Forms.DockStyle.Fill
Me.HolderPanel.Location = New System.Drawing.Point(0, 0)
Me.HolderPanel.Name = "HolderPanel"
Me.HolderPanel.Size = New System.Drawing.Size(232, 120)
Me.HolderPanel.TabIndex = 0
Me.lblName = New System.Windows.Forms.Label
Me.txtName = New System.Windows.Forms.TextBox
Me.lblFolderType = New System.Windows.Forms.Label
Me.cmbFolderType = New System.Windows.Forms.ComboBox

Me.lblName.Location = New System.Drawing.Point(20,5)
Me.lblName.name = "lblName"
Me.lblName.Size = New System.Drawing.Size(200, 20)
Me.lblName.TabIndex = 1
Me.lblName.Text = "Название"
Me.lblName.ForeColor = System.Drawing.Color.Black
Me.txtName.Location = New System.Drawing.Point(20,27)
Me.txtName.name = "txtName"
Me.txtName.Size = New System.Drawing.Size(200, 20)
Me.txtName.TabIndex = 2
Me.txtName.Text = "" 
Me.lblFolderType.Location = New System.Drawing.Point(20,52)
Me.lblFolderType.name = "lblFolderType"
Me.lblFolderType.Size = New System.Drawing.Size(200, 20)
Me.lblFolderType.TabIndex = 3
Me.lblFolderType.Text = "Тип папки"
Me.lblFolderType.ForeColor = System.Drawing.Color.Black
Me.cmbFolderType.Location = New System.Drawing.Point(20,74)
Me.cmbFolderType.name = "cmbFolderType"
Me.cmbFolderType.Size = New System.Drawing.Size(200,  20)
Me.cmbFolderType.TabIndex = 4
Me.cmbFolderType.DropDownStyle = ComboBoxStyle.DropDownList
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblFolderType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbFolderType)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editFolder"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
  Changing

end sub
private sub cmbFolderType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFolderType.SelectedIndexChanged
  on error resume next
  Changing

end sub

Public Item As STDInfoStore.STDInfoStore.Folder
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,STDInfoStore.STDInfoStore.Folder)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

txtName.text = item.Name
cmbFolderTypeData = New DataTable
cmbFolderTypeData.Columns.Add("name", GetType(System.String))
cmbFolderTypeData.Columns.Add("Value", GetType(System.Int32))
On Error Resume Next
cmbFolderTypeDataRow = cmbFolderTypeData.NewRow
cmbFolderTypeDataRow("name") = "cls__"
cmbFolderTypeDataRow("Value") = 0
cmbFolderTypeData.Rows.Add (cmbFolderTypeDataRow)
cmbFolderTypeDataRow = cmbFolderTypeData.NewRow
cmbFolderTypeDataRow("name") = "Входящие"
cmbFolderTypeDataRow("Value") = 1
cmbFolderTypeData.Rows.Add (cmbFolderTypeDataRow)
cmbFolderTypeDataRow = cmbFolderTypeData.NewRow
cmbFolderTypeDataRow("name") = "Исходящие"
cmbFolderTypeDataRow("Value") = 2
cmbFolderTypeData.Rows.Add (cmbFolderTypeDataRow)
cmbFolderTypeDataRow = cmbFolderTypeData.NewRow
cmbFolderTypeDataRow("name") = "Удаленные"
cmbFolderTypeDataRow("Value") = 3
cmbFolderTypeData.Rows.Add (cmbFolderTypeDataRow)
cmbFolderTypeDataRow = cmbFolderTypeData.NewRow
cmbFolderTypeDataRow("name") = "Журнал"
cmbFolderTypeDataRow("Value") = 4
cmbFolderTypeData.Rows.Add (cmbFolderTypeDataRow)
cmbFolderTypeDataRow = cmbFolderTypeData.NewRow
cmbFolderTypeDataRow("name") = "Календарь"
cmbFolderTypeDataRow("Value") = 5
cmbFolderTypeData.Rows.Add (cmbFolderTypeDataRow)
cmbFolderTypeDataRow = cmbFolderTypeData.NewRow
cmbFolderTypeDataRow("name") = "Отправленные"
cmbFolderTypeDataRow("Value") = 6
cmbFolderTypeData.Rows.Add (cmbFolderTypeDataRow)
cmbFolderTypeDataRow = cmbFolderTypeData.NewRow
cmbFolderTypeDataRow("name") = "Черновики"
cmbFolderTypeDataRow("Value") = 7
cmbFolderTypeData.Rows.Add (cmbFolderTypeDataRow)
cmbFolderTypeDataRow = cmbFolderTypeData.NewRow
cmbFolderTypeDataRow("name") = "В работе"
cmbFolderTypeDataRow("Value") = 8
cmbFolderTypeData.Rows.Add (cmbFolderTypeDataRow)
cmbFolderTypeDataRow = cmbFolderTypeData.NewRow
cmbFolderTypeDataRow("name") = "Отложенные"
cmbFolderTypeDataRow("Value") = 9
cmbFolderTypeData.Rows.Add (cmbFolderTypeDataRow)
cmbFolderTypeDataRow = cmbFolderTypeData.NewRow
cmbFolderTypeDataRow("name") = "Завершенные"
cmbFolderTypeDataRow("Value") = 10
cmbFolderTypeData.Rows.Add (cmbFolderTypeDataRow)
cmbFolderType.DisplayMember = "name"
cmbFolderType.ValueMember = "Value"
cmbFolderType.DataSource = cmbFolderTypeData
 cmbFolderType.SelectedValue=CInt(Item.FolderType)
        mOnInit = false
  raiseevent Refreshed()
end sub


''' <summary>
'''Сохранения данных в полях объекта
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Save() Implements LATIR2GUIManager.IRowEditor.Save
  if mRowReadOnly =false then

item.Name = txtName.text
   item.FolderType = cmbFolderType.SelectedValue
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK =( txtName.text <> "" ) 
if mIsOK then mIsOK =(cmbFolderType.SelectedIndex >=0)
 return mIsOK
end function
Public function IsChanged() as boolean Implements LATIR2GUIManager.IRowEditor.IsChanged
 return mChanged
end function
Public Sub SetupPanel()
    HolderPanel.SetupPanel()
End Sub
Public Overridable Function GetMaxX() As Double
    Return HolderPanel.GetMaxX()
End Function
Public Overridable Function GetMaxY() As Double
    Return HolderPanel.GetMaxY()
End Function
end class
