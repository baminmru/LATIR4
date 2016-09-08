
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Пользователи режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editUsers
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

 Dim iii As Integer
    Friend WithEvents HolderPanel As LATIR2GUIControls.AutoPanel
Friend WithEvents lblFamily  as  System.Windows.Forms.Label
Friend WithEvents txtFamily As System.Windows.Forms.TextBox
Friend WithEvents lblName  as  System.Windows.Forms.Label
Friend WithEvents txtName As System.Windows.Forms.TextBox
Friend WithEvents lblSurName  as  System.Windows.Forms.Label
Friend WithEvents txtSurName As System.Windows.Forms.TextBox
Friend WithEvents lblLogin  as  System.Windows.Forms.Label
Friend WithEvents txtLogin As System.Windows.Forms.TextBox
Friend WithEvents lblPassword  as  System.Windows.Forms.Label
Friend WithEvents txtPassword As System.Windows.Forms.TextBox
Friend WithEvents lblDomaiName  as  System.Windows.Forms.Label
Friend WithEvents txtDomaiName As System.Windows.Forms.TextBox
Friend WithEvents lblEMail  as  System.Windows.Forms.Label
Friend WithEvents txtEMail As System.Windows.Forms.TextBox
Friend WithEvents lblPhone  as  System.Windows.Forms.Label
Friend WithEvents txtPhone As System.Windows.Forms.TextBox
Friend WithEvents lblLocalPhone  as  System.Windows.Forms.Label
Friend WithEvents txtLocalPhone As System.Windows.Forms.TextBox

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
Me.lblFamily = New System.Windows.Forms.Label
Me.txtFamily = New System.Windows.Forms.TextBox
Me.lblName = New System.Windows.Forms.Label
Me.txtName = New System.Windows.Forms.TextBox
Me.lblSurName = New System.Windows.Forms.Label
Me.txtSurName = New System.Windows.Forms.TextBox
Me.lblLogin = New System.Windows.Forms.Label
Me.txtLogin = New System.Windows.Forms.TextBox
Me.lblPassword = New System.Windows.Forms.Label
Me.txtPassword = New System.Windows.Forms.TextBox
Me.lblDomaiName = New System.Windows.Forms.Label
Me.txtDomaiName = New System.Windows.Forms.TextBox
Me.lblEMail = New System.Windows.Forms.Label
Me.txtEMail = New System.Windows.Forms.TextBox
Me.lblPhone = New System.Windows.Forms.Label
Me.txtPhone = New System.Windows.Forms.TextBox
Me.lblLocalPhone = New System.Windows.Forms.Label
Me.txtLocalPhone = New System.Windows.Forms.TextBox

Me.lblFamily.Location = New System.Drawing.Point(20,5)
Me.lblFamily.name = "lblFamily"
Me.lblFamily.Size = New System.Drawing.Size(200, 20)
Me.lblFamily.TabIndex = 1
Me.lblFamily.Text = "Фамилия"
Me.lblFamily.ForeColor = System.Drawing.Color.Black
Me.txtFamily.Location = New System.Drawing.Point(20,27)
Me.txtFamily.name = "txtFamily"
Me.txtFamily.Size = New System.Drawing.Size(200, 20)
Me.txtFamily.TabIndex = 2
Me.txtFamily.Text = "" 
Me.lblName.Location = New System.Drawing.Point(20,52)
Me.lblName.name = "lblName"
Me.lblName.Size = New System.Drawing.Size(200, 20)
Me.lblName.TabIndex = 3
Me.lblName.Text = "Имя"
Me.lblName.ForeColor = System.Drawing.Color.Black
Me.txtName.Location = New System.Drawing.Point(20,74)
Me.txtName.name = "txtName"
Me.txtName.Size = New System.Drawing.Size(200, 20)
Me.txtName.TabIndex = 4
Me.txtName.Text = "" 
Me.lblSurName.Location = New System.Drawing.Point(20,99)
Me.lblSurName.name = "lblSurName"
Me.lblSurName.Size = New System.Drawing.Size(200, 20)
Me.lblSurName.TabIndex = 5
Me.lblSurName.Text = "Отчество"
Me.lblSurName.ForeColor = System.Drawing.Color.Black
Me.txtSurName.Location = New System.Drawing.Point(20,121)
Me.txtSurName.name = "txtSurName"
Me.txtSurName.Size = New System.Drawing.Size(200, 20)
Me.txtSurName.TabIndex = 6
Me.txtSurName.Text = "" 
Me.lblLogin.Location = New System.Drawing.Point(20,146)
Me.lblLogin.name = "lblLogin"
Me.lblLogin.Size = New System.Drawing.Size(200, 20)
Me.lblLogin.TabIndex = 7
Me.lblLogin.Text = "Имя для входа"
Me.lblLogin.ForeColor = System.Drawing.Color.Black
Me.txtLogin.Location = New System.Drawing.Point(20,168)
Me.txtLogin.name = "txtLogin"
Me.txtLogin.Size = New System.Drawing.Size(200, 20)
Me.txtLogin.TabIndex = 8
Me.txtLogin.Text = "" 
Me.lblPassword.Location = New System.Drawing.Point(20,193)
Me.lblPassword.name = "lblPassword"
Me.lblPassword.Size = New System.Drawing.Size(200, 20)
Me.lblPassword.TabIndex = 9
Me.lblPassword.Text = "Пароль"
Me.lblPassword.ForeColor = System.Drawing.Color.Blue
Me.txtPassword.Location = New System.Drawing.Point(20,215)
Me.txtPassword.name = "txtPassword"
Me.txtPassword.Size = New System.Drawing.Size(200, 20)
Me.txtPassword.TabIndex = 10
Me.txtPassword.Text = "" 
Me.txtPassword.PasswordChar = Microsoft.VisualBasic.ChrW(42)
Me.lblDomaiName.Location = New System.Drawing.Point(20,240)
Me.lblDomaiName.name = "lblDomaiName"
Me.lblDomaiName.Size = New System.Drawing.Size(200, 20)
Me.lblDomaiName.TabIndex = 11
Me.lblDomaiName.Text = "Доменное имя"
Me.lblDomaiName.ForeColor = System.Drawing.Color.Blue
Me.txtDomaiName.Location = New System.Drawing.Point(20,262)
Me.txtDomaiName.name = "txtDomaiName"
Me.txtDomaiName.Size = New System.Drawing.Size(200, 20)
Me.txtDomaiName.TabIndex = 12
Me.txtDomaiName.Text = "" 
Me.lblEMail.Location = New System.Drawing.Point(20,287)
Me.lblEMail.name = "lblEMail"
Me.lblEMail.Size = New System.Drawing.Size(200, 20)
Me.lblEMail.TabIndex = 13
Me.lblEMail.Text = "e-mail"
Me.lblEMail.ForeColor = System.Drawing.Color.Blue
Me.txtEMail.Location = New System.Drawing.Point(20,309)
Me.txtEMail.name = "txtEMail"
Me.txtEMail.Size = New System.Drawing.Size(200, 20)
Me.txtEMail.TabIndex = 14
Me.txtEMail.Text = "" 
Me.lblPhone.Location = New System.Drawing.Point(20,334)
Me.lblPhone.name = "lblPhone"
Me.lblPhone.Size = New System.Drawing.Size(200, 20)
Me.lblPhone.TabIndex = 15
Me.lblPhone.Text = "Телефон"
Me.lblPhone.ForeColor = System.Drawing.Color.Blue
Me.txtPhone.Location = New System.Drawing.Point(20,356)
Me.txtPhone.name = "txtPhone"
Me.txtPhone.Size = New System.Drawing.Size(200, 20)
Me.txtPhone.TabIndex = 16
Me.txtPhone.Text = "" 
Me.lblLocalPhone.Location = New System.Drawing.Point(20,381)
Me.lblLocalPhone.name = "lblLocalPhone"
Me.lblLocalPhone.Size = New System.Drawing.Size(200, 20)
Me.lblLocalPhone.TabIndex = 17
Me.lblLocalPhone.Text = "Местный телефон"
Me.lblLocalPhone.ForeColor = System.Drawing.Color.Blue
Me.txtLocalPhone.Location = New System.Drawing.Point(20,403)
Me.txtLocalPhone.name = "txtLocalPhone"
Me.txtLocalPhone.Size = New System.Drawing.Size(200, 20)
Me.txtLocalPhone.TabIndex = 18
Me.txtLocalPhone.Text = "" 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblFamily)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtFamily)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblSurName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtSurName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblLogin)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtLogin)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblPassword)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtPassword)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblDomaiName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtDomaiName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblEMail)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtEMail)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblPhone)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtPhone)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblLocalPhone)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtLocalPhone)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editUsers"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtFamily_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFamily.TextChanged
  Changing

end sub
private sub txtName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
  Changing

end sub
private sub txtSurName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSurName.TextChanged
  Changing

end sub
private sub txtLogin_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLogin.TextChanged
  Changing

end sub
private sub txtPassword_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPassword.TextChanged
  Changing

end sub
private sub txtDomaiName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDomaiName.TextChanged
  Changing

end sub
private sub txtEMail_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEMail.TextChanged
  Changing

end sub
private sub txtPhone_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPhone.TextChanged
  Changing

end sub
private sub txtLocalPhone_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLocalPhone.TextChanged
  Changing

end sub

Public Item As MTZUsers.MTZUsers.Users
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,MTZUsers.MTZUsers.Users)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

txtFamily.text = item.Family
txtName.text = item.Name
txtSurName.text = item.SurName
txtLogin.text = item.Login
txtPassword.text = item.Password
txtDomaiName.text = item.DomaiName
txtEMail.text = item.EMail
txtPhone.text = item.Phone
txtLocalPhone.text = item.LocalPhone
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

item.Family = txtFamily.text
item.Name = txtName.text
item.SurName = txtSurName.text
item.Login = txtLogin.text
item.Password = txtPassword.text
item.DomaiName = txtDomaiName.text
item.EMail = txtEMail.text
item.Phone = txtPhone.text
item.LocalPhone = txtLocalPhone.text
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK =( txtFamily.text <> "" ) 
if mIsOK then mIsOK =( txtName.text <> "" ) 
if mIsOK then mIsOK =( txtSurName.text <> "" ) 
if mIsOK then mIsOK =( txtLogin.text <> "" ) 
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
