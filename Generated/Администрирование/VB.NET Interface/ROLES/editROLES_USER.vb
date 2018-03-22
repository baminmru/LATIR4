
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Пользователи режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editROLES_USER
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
Friend WithEvents lblTheUser  as  System.Windows.Forms.Label
Friend WithEvents txtTheUser As System.Windows.Forms.TextBox
Friend WithEvents cmdTheUser As System.Windows.Forms.Button

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
Me.lblTheUser = New System.Windows.Forms.Label
Me.txtTheUser = New System.Windows.Forms.TextBox
Me.cmdTheUser = New System.Windows.Forms.Button

Me.lblTheUser.Location = New System.Drawing.Point(20,5)
Me.lblTheUser.name = "lblTheUser"
Me.lblTheUser.Size = New System.Drawing.Size(200, 20)
Me.lblTheUser.TabIndex = 1
Me.lblTheUser.Text = "Пользователь"
Me.lblTheUser.ForeColor = System.Drawing.Color.Black
Me.txtTheUser.Location = New System.Drawing.Point(20,27)
Me.txtTheUser.name = "txtTheUser"
Me.txtTheUser.ReadOnly = True
Me.txtTheUser.Size = New System.Drawing.Size(176, 20)
Me.txtTheUser.TabIndex = 2
Me.txtTheUser.Text = "" 
Me.cmdTheUser.Location = New System.Drawing.Point(198,27)
Me.cmdTheUser.name = "cmdTheUser"
Me.cmdTheUser.Size = New System.Drawing.Size(22, 20)
Me.cmdTheUser.TabIndex = 3
Me.cmdTheUser.Text = "..." 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTheUser)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTheUser)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdTheUser)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editROLES_USER"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtTheUser_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTheUser.TextChanged
  Changing

end sub
private sub cmdTheUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTheUser.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("Users","",System.guid.Empty, id, brief) Then
          txtTheUser.Tag = id
          txtTheUser.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub

Public Item As ROLES.ROLES.ROLES_USER
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,ROLES.ROLES.ROLES_USER)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

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

if mIsOK then mIsOK = not txtTheUser.Tag.Equals(System.Guid.Empty)
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
