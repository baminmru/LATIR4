
Imports System.Windows.Forms
Imports Microsoft.VisualBasic



''' <summary>
'''Контрол редактирования раздела Описание режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editInfoStoreDef
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
Friend WithEvents lblTheGroup  as  System.Windows.Forms.Label
Friend WithEvents txtTheGroup As System.Windows.Forms.TextBox
Friend WithEvents cmdTheGroup As System.Windows.Forms.Button
Friend WithEvents cmdTheGroupClear As System.Windows.Forms.Button
Friend WithEvents lblName  as  System.Windows.Forms.Label
Friend WithEvents txtName As System.Windows.Forms.TextBox
Friend WithEvents lblInfoStoreType  as  System.Windows.Forms.Label
Friend WithEvents cmbInfoStoreType As System.Windows.Forms.ComboBox
Friend cmbInfoStoreTypeDATA As DataTable
Friend cmbInfoStoreTypeDATAROW As DataRow
Friend WithEvents lblTheUser  as  System.Windows.Forms.Label
Friend WithEvents txtTheUser As System.Windows.Forms.TextBox
Friend WithEvents cmdTheUser As System.Windows.Forms.Button
Friend WithEvents cmdTheUserClear As System.Windows.Forms.Button

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
Me.lblTheGroup = New System.Windows.Forms.Label
Me.txtTheGroup = New System.Windows.Forms.TextBox
Me.cmdTheGroup = New System.Windows.Forms.Button
Me.cmdTheGroupClear = New System.Windows.Forms.Button
Me.lblName = New System.Windows.Forms.Label
Me.txtName = New System.Windows.Forms.TextBox
Me.lblInfoStoreType = New System.Windows.Forms.Label
Me.cmbInfoStoreType = New System.Windows.Forms.ComboBox
Me.lblTheUser = New System.Windows.Forms.Label
Me.txtTheUser = New System.Windows.Forms.TextBox
Me.cmdTheUser = New System.Windows.Forms.Button
Me.cmdTheUserClear = New System.Windows.Forms.Button

Me.lblTheGroup.Location = New System.Drawing.Point(20,5)
Me.lblTheGroup.name = "lblTheGroup"
Me.lblTheGroup.Size = New System.Drawing.Size(200, 20)
Me.lblTheGroup.TabIndex = 1
Me.lblTheGroup.Text = "Группа"
Me.lblTheGroup.ForeColor = System.Drawing.Color.Blue
Me.txtTheGroup.Location = New System.Drawing.Point(20,27)
Me.txtTheGroup.name = "txtTheGroup"
Me.txtTheGroup.ReadOnly = True
Me.txtTheGroup.Size = New System.Drawing.Size(155, 20)
Me.txtTheGroup.TabIndex = 2
Me.txtTheGroup.Text = "" 
Me.cmdTheGroup.Location = New System.Drawing.Point(176,27)
Me.cmdTheGroup.name = "cmdTheGroup"
Me.cmdTheGroup.Size = New System.Drawing.Size(22, 20)
Me.cmdTheGroup.TabIndex = 3
Me.cmdTheGroup.Text = "..." 
Me.cmdTheGroupClear.Location = New System.Drawing.Point(198,27)
Me.cmdTheGroupClear.name = "cmdTheGroupClear"
Me.cmdTheGroupClear.Size = New System.Drawing.Size(22, 20)
Me.cmdTheGroupClear.TabIndex = 4
Me.cmdTheGroupClear.Text = "X" 
Me.lblName.Location = New System.Drawing.Point(20,52)
Me.lblName.name = "lblName"
Me.lblName.Size = New System.Drawing.Size(200, 20)
Me.lblName.TabIndex = 5
Me.lblName.Text = "Название"
Me.lblName.ForeColor = System.Drawing.Color.Black
Me.txtName.Location = New System.Drawing.Point(20,74)
Me.txtName.name = "txtName"
Me.txtName.Size = New System.Drawing.Size(200, 20)
Me.txtName.TabIndex = 6
Me.txtName.Text = "" 
Me.lblInfoStoreType.Location = New System.Drawing.Point(20,99)
Me.lblInfoStoreType.name = "lblInfoStoreType"
Me.lblInfoStoreType.Size = New System.Drawing.Size(200, 20)
Me.lblInfoStoreType.TabIndex = 7
Me.lblInfoStoreType.Text = "Тип каталога"
Me.lblInfoStoreType.ForeColor = System.Drawing.Color.Black
Me.cmbInfoStoreType.Location = New System.Drawing.Point(20,121)
Me.cmbInfoStoreType.name = "cmbInfoStoreType"
Me.cmbInfoStoreType.Size = New System.Drawing.Size(200,  20)
Me.cmbInfoStoreType.TabIndex = 8
Me.cmbInfoStoreType.DropDownStyle = ComboBoxStyle.DropDownList
Me.lblTheUser.Location = New System.Drawing.Point(20,146)
Me.lblTheUser.name = "lblTheUser"
Me.lblTheUser.Size = New System.Drawing.Size(200, 20)
Me.lblTheUser.TabIndex = 9
Me.lblTheUser.Text = "Пользователь"
Me.lblTheUser.ForeColor = System.Drawing.Color.Blue
Me.txtTheUser.Location = New System.Drawing.Point(20,168)
Me.txtTheUser.name = "txtTheUser"
Me.txtTheUser.ReadOnly = True
Me.txtTheUser.Size = New System.Drawing.Size(155, 20)
Me.txtTheUser.TabIndex = 10
Me.txtTheUser.Text = "" 
Me.cmdTheUser.Location = New System.Drawing.Point(176,168)
Me.cmdTheUser.name = "cmdTheUser"
Me.cmdTheUser.Size = New System.Drawing.Size(22, 20)
Me.cmdTheUser.TabIndex = 11
Me.cmdTheUser.Text = "..." 
Me.cmdTheUserClear.Location = New System.Drawing.Point(198,168)
Me.cmdTheUserClear.name = "cmdTheUserClear"
Me.cmdTheUserClear.Size = New System.Drawing.Size(22, 20)
Me.cmdTheUserClear.TabIndex = 12
Me.cmdTheUserClear.Text = "X" 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTheGroup)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTheGroup)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdTheGroup)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdTheGroupClear)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblInfoStoreType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbInfoStoreType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTheUser)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTheUser)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdTheUser)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdTheUserClear)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editInfoStoreDef"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtTheGroup_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTheGroup.TextChanged
  Changing

end sub
private sub cmdTheGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTheGroup.Click
  on error resume next
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("Groups","",System.guid.Empty, id, brief) Then
          txtTheGroup.Tag = id
          txtTheGroup.text = brief
        End If
end sub
private sub cmdTheGroupClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTheGroupClear.Click
  on error resume next
          txtTheGroup.Tag = Guid.Empty
          txtTheGroup.text = ""
end sub
private sub txtName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
  Changing

end sub
private sub cmbInfoStoreType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbInfoStoreType.SelectedIndexChanged
  on error resume next
  Changing

end sub
private sub txtTheUser_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTheUser.TextChanged
  Changing

end sub
private sub cmdTheUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTheUser.Click
  on error resume next
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("Users","",System.guid.Empty, id, brief) Then
          txtTheUser.Tag = id
          txtTheUser.text = brief
        End If
end sub
private sub cmdTheUserClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTheUserClear.Click
  on error resume next
          txtTheUser.Tag = Guid.Empty
          txtTheUser.text = ""
end sub

Public Item As STDInfoStore.STDInfoStore.InfoStoreDef
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,STDInfoStore.STDInfoStore.InfoStoreDef)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

If Not item.TheGroup Is Nothing Then
  txtTheGroup.Tag = item.TheGroup.id
  txtTheGroup.text = item.TheGroup.brief
else
  txtTheGroup.Tag = System.Guid.Empty 
  txtTheGroup.text = "" 
End If
txtName.text = item.Name
cmbInfoStoreTypeData = New DataTable
cmbInfoStoreTypeData.Columns.Add("name", GetType(System.String))
cmbInfoStoreTypeData.Columns.Add("Value", GetType(System.Int32))
On Error Resume Next
cmbInfoStoreTypeDataRow = cmbInfoStoreTypeData.NewRow
cmbInfoStoreTypeDataRow("name") = " Общий"
cmbInfoStoreTypeDataRow("Value") = 0
cmbInfoStoreTypeData.Rows.Add (cmbInfoStoreTypeDataRow)
cmbInfoStoreTypeDataRow = cmbInfoStoreTypeData.NewRow
cmbInfoStoreTypeDataRow("name") = "Персональный"
cmbInfoStoreTypeDataRow("Value") = 1
cmbInfoStoreTypeData.Rows.Add (cmbInfoStoreTypeDataRow)
cmbInfoStoreTypeDataRow = cmbInfoStoreTypeData.NewRow
cmbInfoStoreTypeDataRow("name") = "Групповой"
cmbInfoStoreTypeDataRow("Value") = 2
cmbInfoStoreTypeData.Rows.Add (cmbInfoStoreTypeDataRow)
cmbInfoStoreType.DisplayMember = "name"
cmbInfoStoreType.ValueMember = "Value"
cmbInfoStoreType.DataSource = cmbInfoStoreTypeData
 cmbInfoStoreType.SelectedValue=CInt(Item.InfoStoreType)
If Not item.TheUser Is Nothing Then
  txtTheUser.Tag = item.TheUser.id
  txtTheUser.text = item.TheUser.brief
else
  txtTheUser.Tag = System.Guid.Empty 
  txtTheUser.text = "" 
End If
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

If not txtTheGroup.Tag.Equals(System.Guid.Empty) Then
  item.TheGroup = Item.Application.FindRowObject("Groups",txtTheGroup.Tag)
Else
   item.TheGroup = Nothing
End If
item.Name = txtName.text
   item.InfoStoreType = cmbInfoStoreType.SelectedValue
If not txtTheUser.Tag.Equals(System.Guid.Empty) Then
  item.TheUser = Item.Application.FindRowObject("Users",txtTheUser.Tag)
Else
   item.TheUser = Nothing
End If
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK =( txtName.text <> "" ) 
if mIsOK then mIsOK =(cmbInfoStoreType.SelectedIndex >=0)
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
