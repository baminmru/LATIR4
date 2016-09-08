
Imports System.Windows.Forms
Imports Microsoft.VisualBasic



''' <summary>
'''Контрол редактирования раздела Сессия пользователя режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editthe_Session
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
Friend WithEvents lblApplicationID  as  System.Windows.Forms.Label
Friend WithEvents txtApplicationID As System.Windows.Forms.TextBox
Friend WithEvents cmdApplicationID As System.Windows.Forms.Button
Friend WithEvents cmdApplicationIDClear As System.Windows.Forms.Button
Friend WithEvents lblUserRole  as  System.Windows.Forms.Label
Friend WithEvents txtUserRole As System.Windows.Forms.TextBox
Friend WithEvents cmdUserRole As System.Windows.Forms.Button
Friend WithEvents lblClosedAt  as  System.Windows.Forms.Label
Friend WithEvents dtpClosedAt As System.Windows.Forms.DateTimePicker
Friend WithEvents lblClosed  as  System.Windows.Forms.Label
Friend WithEvents cmbClosed As System.Windows.Forms.ComboBox
Friend cmbClosedDATA As DataTable
Friend cmbClosedDATAROW As DataRow
Friend WithEvents lblUsersid  as  System.Windows.Forms.Label
Friend WithEvents txtUsersid As System.Windows.Forms.TextBox
Friend WithEvents cmdUsersid As System.Windows.Forms.Button
Friend WithEvents lblLastAccess  as  System.Windows.Forms.Label
Friend WithEvents dtpLastAccess As System.Windows.Forms.DateTimePicker
Friend WithEvents lblStartAt  as  System.Windows.Forms.Label
Friend WithEvents dtpStartAt As System.Windows.Forms.DateTimePicker
Friend WithEvents lblLang  as  System.Windows.Forms.Label
Friend WithEvents txtLang As System.Windows.Forms.TextBox
Friend WithEvents lblLogin  as  System.Windows.Forms.Label
Friend WithEvents txtLogin As System.Windows.Forms.TextBox

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
Me.lblApplicationID = New System.Windows.Forms.Label
Me.txtApplicationID = New System.Windows.Forms.TextBox
Me.cmdApplicationID = New System.Windows.Forms.Button
Me.cmdApplicationIDClear = New System.Windows.Forms.Button
Me.lblUserRole = New System.Windows.Forms.Label
Me.txtUserRole = New System.Windows.Forms.TextBox
Me.cmdUserRole = New System.Windows.Forms.Button
Me.lblClosedAt = New System.Windows.Forms.Label
Me.dtpClosedAt = New System.Windows.Forms.DateTimePicker
Me.lblClosed = New System.Windows.Forms.Label
Me.cmbClosed = New System.Windows.Forms.ComboBox
Me.lblUsersid = New System.Windows.Forms.Label
Me.txtUsersid = New System.Windows.Forms.TextBox
Me.cmdUsersid = New System.Windows.Forms.Button
Me.lblLastAccess = New System.Windows.Forms.Label
Me.dtpLastAccess = New System.Windows.Forms.DateTimePicker
Me.lblStartAt = New System.Windows.Forms.Label
Me.dtpStartAt = New System.Windows.Forms.DateTimePicker
Me.lblLang = New System.Windows.Forms.Label
Me.txtLang = New System.Windows.Forms.TextBox
Me.lblLogin = New System.Windows.Forms.Label
Me.txtLogin = New System.Windows.Forms.TextBox

Me.lblApplicationID.Location = New System.Drawing.Point(20,5)
Me.lblApplicationID.name = "lblApplicationID"
Me.lblApplicationID.Size = New System.Drawing.Size(200, 20)
Me.lblApplicationID.TabIndex = 1
Me.lblApplicationID.Text = "Приложение"
Me.lblApplicationID.ForeColor = System.Drawing.Color.Blue
Me.txtApplicationID.Location = New System.Drawing.Point(20,27)
Me.txtApplicationID.name = "txtApplicationID"
Me.txtApplicationID.ReadOnly = True
Me.txtApplicationID.Size = New System.Drawing.Size(155, 20)
Me.txtApplicationID.TabIndex = 2
Me.txtApplicationID.Text = "" 
Me.cmdApplicationID.Location = New System.Drawing.Point(176,27)
Me.cmdApplicationID.name = "cmdApplicationID"
Me.cmdApplicationID.Size = New System.Drawing.Size(22, 20)
Me.cmdApplicationID.TabIndex = 3
Me.cmdApplicationID.Text = "..." 
Me.cmdApplicationIDClear.Location = New System.Drawing.Point(198,27)
Me.cmdApplicationIDClear.name = "cmdApplicationIDClear"
Me.cmdApplicationIDClear.Size = New System.Drawing.Size(22, 20)
Me.cmdApplicationIDClear.TabIndex = 4
Me.cmdApplicationIDClear.Text = "X" 
Me.lblUserRole.Location = New System.Drawing.Point(20,52)
Me.lblUserRole.name = "lblUserRole"
Me.lblUserRole.Size = New System.Drawing.Size(200, 20)
Me.lblUserRole.TabIndex = 5
Me.lblUserRole.Text = "Текущая роль пользователя"
Me.lblUserRole.ForeColor = System.Drawing.Color.Black
Me.txtUserRole.Location = New System.Drawing.Point(20,74)
Me.txtUserRole.name = "txtUserRole"
Me.txtUserRole.ReadOnly = True
Me.txtUserRole.Size = New System.Drawing.Size(176, 20)
Me.txtUserRole.TabIndex = 6
Me.txtUserRole.Text = "" 
Me.cmdUserRole.Location = New System.Drawing.Point(198,74)
Me.cmdUserRole.name = "cmdUserRole"
Me.cmdUserRole.Size = New System.Drawing.Size(22, 20)
Me.cmdUserRole.TabIndex = 7
Me.cmdUserRole.Text = "..." 
Me.lblClosedAt.Location = New System.Drawing.Point(20,99)
Me.lblClosedAt.name = "lblClosedAt"
Me.lblClosedAt.Size = New System.Drawing.Size(200, 20)
Me.lblClosedAt.TabIndex = 8
Me.lblClosedAt.Text = "Момент закрытия"
Me.lblClosedAt.ForeColor = System.Drawing.Color.Blue
Me.dtpClosedAt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
Me.dtpClosedAt.Location = New System.Drawing.Point(20,121)
Me.dtpClosedAt.name = "dtpClosedAt"
Me.dtpClosedAt.Size = New System.Drawing.Size(200,  20)
Me.dtpClosedAt.TabIndex =9
Me.dtpClosedAt.CustomFormat = "dd/MM/yyyy HH:mm:ss"
Me.dtpClosedAt.ShowCheckBox=True
Me.lblClosed.Location = New System.Drawing.Point(20,146)
Me.lblClosed.name = "lblClosed"
Me.lblClosed.Size = New System.Drawing.Size(200, 20)
Me.lblClosed.TabIndex = 10
Me.lblClosed.Text = "Закрыта"
Me.lblClosed.ForeColor = System.Drawing.Color.Black
Me.cmbClosed.Location = New System.Drawing.Point(20,168)
Me.cmbClosed.name = "cmbClosed"
Me.cmbClosed.Size = New System.Drawing.Size(200,  20)
Me.cmbClosed.TabIndex = 11
Me.lblUsersid.Location = New System.Drawing.Point(20,193)
Me.lblUsersid.name = "lblUsersid"
Me.lblUsersid.Size = New System.Drawing.Size(200, 20)
Me.lblUsersid.TabIndex = 12
Me.lblUsersid.Text = "Пользователь"
Me.lblUsersid.ForeColor = System.Drawing.Color.Black
Me.txtUsersid.Location = New System.Drawing.Point(20,215)
Me.txtUsersid.name = "txtUsersid"
Me.txtUsersid.ReadOnly = True
Me.txtUsersid.Size = New System.Drawing.Size(176, 20)
Me.txtUsersid.TabIndex = 13
Me.txtUsersid.Text = "" 
Me.cmdUsersid.Location = New System.Drawing.Point(198,215)
Me.cmdUsersid.name = "cmdUsersid"
Me.cmdUsersid.Size = New System.Drawing.Size(22, 20)
Me.cmdUsersid.TabIndex = 14
Me.cmdUsersid.Text = "..." 
Me.lblLastAccess.Location = New System.Drawing.Point(20,240)
Me.lblLastAccess.name = "lblLastAccess"
Me.lblLastAccess.Size = New System.Drawing.Size(200, 20)
Me.lblLastAccess.TabIndex = 15
Me.lblLastAccess.Text = "Последнее подтверждение"
Me.lblLastAccess.ForeColor = System.Drawing.Color.Blue
Me.dtpLastAccess.Format = System.Windows.Forms.DateTimePickerFormat.Custom
Me.dtpLastAccess.Location = New System.Drawing.Point(20,262)
Me.dtpLastAccess.name = "dtpLastAccess"
Me.dtpLastAccess.Size = New System.Drawing.Size(200,  20)
Me.dtpLastAccess.TabIndex =16
Me.dtpLastAccess.CustomFormat = "dd/MM/yyyy HH:mm:ss"
Me.dtpLastAccess.ShowCheckBox=True
Me.lblStartAt.Location = New System.Drawing.Point(20,287)
Me.lblStartAt.name = "lblStartAt"
Me.lblStartAt.Size = New System.Drawing.Size(200, 20)
Me.lblStartAt.TabIndex = 17
Me.lblStartAt.Text = "Момент открытия"
Me.lblStartAt.ForeColor = System.Drawing.Color.Black
Me.dtpStartAt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
Me.dtpStartAt.Location = New System.Drawing.Point(20,309)
Me.dtpStartAt.name = "dtpStartAt"
Me.dtpStartAt.Size = New System.Drawing.Size(200,  20)
Me.dtpStartAt.TabIndex =18
Me.dtpStartAt.CustomFormat = "dd/MM/yyyy HH:mm:ss"
Me.dtpStartAt.ShowCheckBox=False
Me.lblLang.Location = New System.Drawing.Point(20,334)
Me.lblLang.name = "lblLang"
Me.lblLang.Size = New System.Drawing.Size(200, 20)
Me.lblLang.TabIndex = 19
Me.lblLang.Text = "Локализация"
Me.lblLang.ForeColor = System.Drawing.Color.Blue
Me.txtLang.Location = New System.Drawing.Point(20,356)
Me.txtLang.name = "txtLang"
Me.txtLang.Size = New System.Drawing.Size(200, 20)
Me.txtLang.TabIndex = 20
Me.txtLang.Text = "" 
Me.lblLogin.Location = New System.Drawing.Point(20,381)
Me.lblLogin.name = "lblLogin"
Me.lblLogin.Size = New System.Drawing.Size(200, 20)
Me.lblLogin.TabIndex = 21
Me.lblLogin.Text = "Login"
Me.lblLogin.ForeColor = System.Drawing.Color.Blue
Me.txtLogin.Location = New System.Drawing.Point(20,403)
Me.txtLogin.name = "txtLogin"
Me.txtLogin.Size = New System.Drawing.Size(200, 20)
Me.txtLogin.TabIndex = 22
Me.txtLogin.Text = "" 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblApplicationID)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtApplicationID)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdApplicationID)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdApplicationIDClear)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblUserRole)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtUserRole)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdUserRole)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblClosedAt)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.dtpClosedAt)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblClosed)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbClosed)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblUsersid)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtUsersid)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdUsersid)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblLastAccess)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.dtpLastAccess)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblStartAt)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.dtpStartAt)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblLang)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtLang)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblLogin)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtLogin)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editthe_Session"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtApplicationID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtApplicationID.TextChanged
  Changing

end sub
private sub cmdApplicationID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApplicationID.Click
  on error resume next
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("WorkPlace","",System.guid.Empty, id, brief) Then
          txtApplicationID.Tag = id
          txtApplicationID.text = brief
        End If
end sub
private sub cmdApplicationIDClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApplicationIDClear.Click
  on error resume next
          txtApplicationID.Tag = Guid.Empty
          txtApplicationID.text = ""
end sub
private sub txtUserRole_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUserRole.TextChanged
  Changing

end sub
private sub cmdUserRole_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUserRole.Click
  on error resume next
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("Groups","",System.guid.Empty, id, brief) Then
          txtUserRole.Tag = id
          txtUserRole.text = brief
        End If
end sub
private sub dtpClosedAt_Change(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpClosedAt.ValueChanged
  Changing 

end sub
private sub cmbClosed_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbClosed.SelectedIndexChanged
  on error resume next
  Changing

end sub
private sub txtUsersid_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUsersid.TextChanged
  Changing

end sub
private sub cmdUsersid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUsersid.Click
  on error resume next
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("Users","",System.guid.Empty, id, brief) Then
          txtUsersid.Tag = id
          txtUsersid.text = brief
        End If
end sub
private sub dtpLastAccess_Change(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpLastAccess.ValueChanged
  Changing 

end sub
private sub dtpStartAt_Change(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpStartAt.ValueChanged
  Changing 

end sub
private sub txtLang_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLang.TextChanged
  Changing

end sub
private sub txtLogin_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLogin.TextChanged
  Changing

end sub

Public Item As MTZSystem.MTZSystem.the_Session
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,MTZSystem.MTZSystem.the_Session)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

If Not item.ApplicationID Is Nothing Then
  txtApplicationID.Tag = item.ApplicationID.id
  txtApplicationID.text = item.ApplicationID.brief
else
  txtApplicationID.Tag = System.Guid.Empty 
  txtApplicationID.text = "" 
End If
If Not item.UserRole Is Nothing Then
  txtUserRole.Tag = item.UserRole.id
  txtUserRole.text = item.UserRole.brief
else
  txtUserRole.Tag = System.Guid.Empty 
  txtUserRole.text = "" 
End If
dtpClosedAt.value = System.DateTime.Now
if item.ClosedAt <> System.DateTime.MinValue then
 dtpClosedAt.value = item.ClosedAt
else
 dtpClosedAt.value = System.DateTime.today
end if
cmbClosedData = New DataTable
cmbClosedData.Columns.Add("name", GetType(System.String))
cmbClosedData.Columns.Add("Value", GetType(System.Int32))
On Error Resume Next
cmbClosedDataRow = cmbClosedData.NewRow
cmbClosedDataRow("name") = "Нет"
cmbClosedDataRow("Value") = 0
cmbClosedData.Rows.Add (cmbClosedDataRow)
cmbClosedDataRow = cmbClosedData.NewRow
cmbClosedDataRow("name") = "Да"
cmbClosedDataRow("Value") = 1
cmbClosedData.Rows.Add (cmbClosedDataRow)
cmbClosed.DisplayMember = "name"
cmbClosed.ValueMember = "Value"
cmbClosed.DataSource = cmbClosedData
 cmbClosed.SelectedValue=CInt(Item.Closed)
If Not item.Usersid Is Nothing Then
  txtUsersid.Tag = item.Usersid.id
  txtUsersid.text = item.Usersid.brief
else
  txtUsersid.Tag = System.Guid.Empty 
  txtUsersid.text = "" 
End If
dtpLastAccess.value = System.DateTime.Now
if item.LastAccess <> System.DateTime.MinValue then
 dtpLastAccess.value = item.LastAccess
else
 dtpLastAccess.value = System.DateTime.today
end if
dtpStartAt.value = System.DateTime.Now
if item.StartAt <> System.DateTime.MinValue then
 dtpStartAt.value = item.StartAt
end if
txtLang.text = item.Lang
txtLogin.text = item.Login
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

If not txtApplicationID.Tag.Equals(System.Guid.Empty) Then
  item.ApplicationID = Item.Application.FindRowObject("WorkPlace",txtApplicationID.Tag)
Else
   item.ApplicationID = Nothing
End If
If not txtUserRole.Tag.Equals(System.Guid.Empty) Then
  item.UserRole = Item.Application.FindRowObject("Groups",txtUserRole.Tag)
Else
   item.UserRole = Nothing
End If
  if  dtpClosedAt.value=System.DateTime.MinValue then
    item.ClosedAt = System.DateTime.MinValue
  else
    item.ClosedAt = dtpClosedAt.value
  end if
   item.Closed = cmbClosed.SelectedValue
If not txtUsersid.Tag.Equals(System.Guid.Empty) Then
  item.Usersid = Item.Application.FindRowObject("Users",txtUsersid.Tag)
Else
   item.Usersid = Nothing
End If
  if  dtpLastAccess.value=System.DateTime.MinValue then
    item.LastAccess = System.DateTime.MinValue
  else
    item.LastAccess = dtpLastAccess.value
  end if
  if  dtpStartAt.value=System.DateTime.MinValue then
    item.StartAt = System.DateTime.MinValue
  else
    item.StartAt = dtpStartAt.value
  end if
item.Lang = txtLang.text
item.Login = txtLogin.text
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK = not txtUserRole.Tag.Equals(System.Guid.Empty)
if mIsOK then mIsOK =(cmbClosed.SelectedIndex >=0)
if mIsOK then mIsOK = not txtUsersid.Tag.Equals(System.Guid.Empty)
if mIsOK then mIsOK = (dtpStartAt.value <> nothing)
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
