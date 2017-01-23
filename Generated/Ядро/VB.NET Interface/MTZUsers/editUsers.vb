
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Пользователи режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editusers
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
Friend WithEvents lblfamily  as  System.Windows.Forms.Label
Friend WithEvents txtfamily As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblname  as  System.Windows.Forms.Label
Friend WithEvents txtname As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblsurname  as  System.Windows.Forms.Label
Friend WithEvents txtsurname As LATIR2GuiManager.TouchTextBox
Friend WithEvents lbllogin  as  System.Windows.Forms.Label
Friend WithEvents txtlogin As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblpassword  as  System.Windows.Forms.Label
Friend WithEvents txtpassword As LATIR2GuiManager.TouchTextBox
Friend WithEvents lbldomainame  as  System.Windows.Forms.Label
Friend WithEvents txtdomainame As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblemail  as  System.Windows.Forms.Label
Friend WithEvents txtemail As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblphone  as  System.Windows.Forms.Label
Friend WithEvents txtphone As LATIR2GuiManager.TouchTextBox
Friend WithEvents lbllocalphone  as  System.Windows.Forms.Label
Friend WithEvents txtlocalphone As LATIR2GuiManager.TouchTextBox

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
Me.lblfamily = New System.Windows.Forms.Label
Me.txtfamily = New LATIR2GuiManager.TouchTextBox
Me.lblname = New System.Windows.Forms.Label
Me.txtname = New LATIR2GuiManager.TouchTextBox
Me.lblsurname = New System.Windows.Forms.Label
Me.txtsurname = New LATIR2GuiManager.TouchTextBox
Me.lbllogin = New System.Windows.Forms.Label
Me.txtlogin = New LATIR2GuiManager.TouchTextBox
Me.lblpassword = New System.Windows.Forms.Label
Me.txtpassword = New LATIR2GuiManager.TouchTextBox
Me.lbldomainame = New System.Windows.Forms.Label
Me.txtdomainame = New LATIR2GuiManager.TouchTextBox
Me.lblemail = New System.Windows.Forms.Label
Me.txtemail = New LATIR2GuiManager.TouchTextBox
Me.lblphone = New System.Windows.Forms.Label
Me.txtphone = New LATIR2GuiManager.TouchTextBox
Me.lbllocalphone = New System.Windows.Forms.Label
Me.txtlocalphone = New LATIR2GuiManager.TouchTextBox

Me.lblfamily.Location = New System.Drawing.Point(20,5)
Me.lblfamily.name = "lblfamily"
Me.lblfamily.Size = New System.Drawing.Size(200, 20)
Me.lblfamily.TabIndex = 1
Me.lblfamily.Text = "Фамилия"
Me.lblfamily.ForeColor = System.Drawing.Color.Black
Me.txtfamily.Location = New System.Drawing.Point(20,27)
Me.txtfamily.name = "txtfamily"
Me.txtfamily.Size = New System.Drawing.Size(200, 20)
Me.txtfamily.TabIndex = 2
Me.txtfamily.Text = "" 
Me.lblname.Location = New System.Drawing.Point(20,52)
Me.lblname.name = "lblname"
Me.lblname.Size = New System.Drawing.Size(200, 20)
Me.lblname.TabIndex = 3
Me.lblname.Text = "Имя"
Me.lblname.ForeColor = System.Drawing.Color.Black
Me.txtname.Location = New System.Drawing.Point(20,74)
Me.txtname.name = "txtname"
Me.txtname.Size = New System.Drawing.Size(200, 20)
Me.txtname.TabIndex = 4
Me.txtname.Text = "" 
Me.lblsurname.Location = New System.Drawing.Point(20,99)
Me.lblsurname.name = "lblsurname"
Me.lblsurname.Size = New System.Drawing.Size(200, 20)
Me.lblsurname.TabIndex = 5
Me.lblsurname.Text = "Отчество"
Me.lblsurname.ForeColor = System.Drawing.Color.Black
Me.txtsurname.Location = New System.Drawing.Point(20,121)
Me.txtsurname.name = "txtsurname"
Me.txtsurname.Size = New System.Drawing.Size(200, 20)
Me.txtsurname.TabIndex = 6
Me.txtsurname.Text = "" 
Me.lbllogin.Location = New System.Drawing.Point(20,146)
Me.lbllogin.name = "lbllogin"
Me.lbllogin.Size = New System.Drawing.Size(200, 20)
Me.lbllogin.TabIndex = 7
Me.lbllogin.Text = "Имя для входа"
Me.lbllogin.ForeColor = System.Drawing.Color.Black
Me.txtlogin.Location = New System.Drawing.Point(20,168)
Me.txtlogin.name = "txtlogin"
Me.txtlogin.Size = New System.Drawing.Size(200, 20)
Me.txtlogin.TabIndex = 8
Me.txtlogin.Text = "" 
Me.lblpassword.Location = New System.Drawing.Point(20,193)
Me.lblpassword.name = "lblpassword"
Me.lblpassword.Size = New System.Drawing.Size(200, 20)
Me.lblpassword.TabIndex = 9
Me.lblpassword.Text = "Пароль"
Me.lblpassword.ForeColor = System.Drawing.Color.Blue
Me.txtpassword.Location = New System.Drawing.Point(20,215)
Me.txtpassword.name = "txtpassword"
Me.txtpassword.Size = New System.Drawing.Size(200, 20)
Me.txtpassword.TabIndex = 10
Me.txtpassword.Text = "" 
Me.txtpassword.PasswordChar = Microsoft.VisualBasic.ChrW(42)
Me.lbldomainame.Location = New System.Drawing.Point(20,240)
Me.lbldomainame.name = "lbldomainame"
Me.lbldomainame.Size = New System.Drawing.Size(200, 20)
Me.lbldomainame.TabIndex = 11
Me.lbldomainame.Text = "Доменное имя"
Me.lbldomainame.ForeColor = System.Drawing.Color.Blue
Me.txtdomainame.Location = New System.Drawing.Point(20,262)
Me.txtdomainame.name = "txtdomainame"
Me.txtdomainame.Size = New System.Drawing.Size(200, 20)
Me.txtdomainame.TabIndex = 12
Me.txtdomainame.Text = "" 
Me.lblemail.Location = New System.Drawing.Point(20,287)
Me.lblemail.name = "lblemail"
Me.lblemail.Size = New System.Drawing.Size(200, 20)
Me.lblemail.TabIndex = 13
Me.lblemail.Text = "e-mail"
Me.lblemail.ForeColor = System.Drawing.Color.Blue
Me.txtemail.Location = New System.Drawing.Point(20,309)
Me.txtemail.name = "txtemail"
Me.txtemail.Size = New System.Drawing.Size(200, 20)
Me.txtemail.TabIndex = 14
Me.txtemail.Text = "" 
Me.lblphone.Location = New System.Drawing.Point(20,334)
Me.lblphone.name = "lblphone"
Me.lblphone.Size = New System.Drawing.Size(200, 20)
Me.lblphone.TabIndex = 15
Me.lblphone.Text = "Телефон"
Me.lblphone.ForeColor = System.Drawing.Color.Blue
Me.txtphone.Location = New System.Drawing.Point(20,356)
Me.txtphone.name = "txtphone"
Me.txtphone.Size = New System.Drawing.Size(200, 20)
Me.txtphone.TabIndex = 16
Me.txtphone.Text = "" 
Me.lbllocalphone.Location = New System.Drawing.Point(20,381)
Me.lbllocalphone.name = "lbllocalphone"
Me.lbllocalphone.Size = New System.Drawing.Size(200, 20)
Me.lbllocalphone.TabIndex = 17
Me.lbllocalphone.Text = "Местный телефон"
Me.lbllocalphone.ForeColor = System.Drawing.Color.Blue
Me.txtlocalphone.Location = New System.Drawing.Point(20,403)
Me.txtlocalphone.name = "txtlocalphone"
Me.txtlocalphone.Size = New System.Drawing.Size(200, 20)
Me.txtlocalphone.TabIndex = 18
Me.txtlocalphone.Text = "" 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblfamily)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtfamily)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblname)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtname)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblsurname)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtsurname)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lbllogin)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtlogin)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblpassword)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtpassword)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lbldomainame)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtdomainame)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblemail)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtemail)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblphone)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtphone)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lbllocalphone)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtlocalphone)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editusers"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtfamily_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtfamily.TextChanged
  Changing

end sub
private sub txtname_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtname.TextChanged
  Changing

end sub
private sub txtsurname_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsurname.TextChanged
  Changing

end sub
private sub txtlogin_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlogin.TextChanged
  Changing

end sub
private sub txtpassword_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpassword.TextChanged
  Changing

end sub
private sub txtdomainame_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdomainame.TextChanged
  Changing

end sub
private sub txtemail_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtemail.TextChanged
  Changing

end sub
private sub txtphone_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtphone.TextChanged
  Changing

end sub
private sub txtlocalphone_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlocalphone.TextChanged
  Changing

end sub

Public Item As mtzusers.mtzusers.users
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,mtzusers.mtzusers.users)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

txtfamily.text = item.family
txtname.text = item.name
txtsurname.text = item.surname
txtlogin.text = item.login
txtpassword.text = item.password
txtdomainame.text = item.domainame
txtemail.text = item.email
txtphone.text = item.phone
txtlocalphone.text = item.localphone
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

item.family = txtfamily.text
item.name = txtname.text
item.surname = txtsurname.text
item.login = txtlogin.text
item.password = txtpassword.text
item.domainame = txtdomainame.text
item.email = txtemail.text
item.phone = txtphone.text
item.localphone = txtlocalphone.text
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK =( txtfamily.text <> "" ) 
if mIsOK then mIsOK =( txtname.text <> "" ) 
if mIsOK then mIsOK =( txtsurname.text <> "" ) 
if mIsOK then mIsOK =( txtlogin.text <> "" ) 
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
