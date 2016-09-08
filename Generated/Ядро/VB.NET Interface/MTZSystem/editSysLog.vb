
Imports System.Windows.Forms
Imports Microsoft.VisualBasic



''' <summary>
'''Контрол редактирования раздела Журнал событий режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editSysLog
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
Friend WithEvents lblTheSession  as  System.Windows.Forms.Label
Friend WithEvents txtTheSession As System.Windows.Forms.TextBox
Friend WithEvents cmdTheSession As System.Windows.Forms.Button
Friend WithEvents lblthe_Resource  as  System.Windows.Forms.Label
Friend WithEvents txtthe_Resource As System.Windows.Forms.TextBox
Friend WithEvents lblLogStructID  as  System.Windows.Forms.Label
Friend WithEvents txtLogStructID As System.Windows.Forms.TextBox
Friend WithEvents lblVERB  as  System.Windows.Forms.Label
Friend WithEvents txtVERB As System.Windows.Forms.TextBox
Friend WithEvents lblLogInstanceID  as  System.Windows.Forms.Label
Friend WithEvents txtLogInstanceID As System.Windows.Forms.TextBox

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
Me.lblTheSession = New System.Windows.Forms.Label
Me.txtTheSession = New System.Windows.Forms.TextBox
Me.cmdTheSession = New System.Windows.Forms.Button
Me.lblthe_Resource = New System.Windows.Forms.Label
Me.txtthe_Resource = New System.Windows.Forms.TextBox
Me.lblLogStructID = New System.Windows.Forms.Label
Me.txtLogStructID = New System.Windows.Forms.TextBox
Me.lblVERB = New System.Windows.Forms.Label
Me.txtVERB = New System.Windows.Forms.TextBox
Me.lblLogInstanceID = New System.Windows.Forms.Label
Me.txtLogInstanceID = New System.Windows.Forms.TextBox

Me.lblTheSession.Location = New System.Drawing.Point(20,5)
Me.lblTheSession.name = "lblTheSession"
Me.lblTheSession.Size = New System.Drawing.Size(200, 20)
Me.lblTheSession.TabIndex = 1
Me.lblTheSession.Text = "Сессия"
Me.lblTheSession.ForeColor = System.Drawing.Color.Black
Me.txtTheSession.Location = New System.Drawing.Point(20,27)
Me.txtTheSession.name = "txtTheSession"
Me.txtTheSession.ReadOnly = True
Me.txtTheSession.Size = New System.Drawing.Size(176, 20)
Me.txtTheSession.TabIndex = 2
Me.txtTheSession.Text = "" 
Me.cmdTheSession.Location = New System.Drawing.Point(198,27)
Me.cmdTheSession.name = "cmdTheSession"
Me.cmdTheSession.Size = New System.Drawing.Size(22, 20)
Me.cmdTheSession.TabIndex = 3
Me.cmdTheSession.Text = "..." 
Me.lblthe_Resource.Location = New System.Drawing.Point(20,52)
Me.lblthe_Resource.name = "lblthe_Resource"
Me.lblthe_Resource.Size = New System.Drawing.Size(200, 20)
Me.lblthe_Resource.TabIndex = 4
Me.lblthe_Resource.Text = "Ресурс"
Me.lblthe_Resource.ForeColor = System.Drawing.Color.Black
Me.txtthe_Resource.Location = New System.Drawing.Point(20,74)
Me.txtthe_Resource.name = "txtthe_Resource"
Me.txtthe_Resource.Size = New System.Drawing.Size(200, 20)
Me.txtthe_Resource.TabIndex = 5
Me.txtthe_Resource.Text = "" 
Me.lblLogStructID.Location = New System.Drawing.Point(20,99)
Me.lblLogStructID.name = "lblLogStructID"
Me.lblLogStructID.Size = New System.Drawing.Size(200, 20)
Me.lblLogStructID.TabIndex = 6
Me.lblLogStructID.Text = "Раздел с которым происхоит действие"
Me.lblLogStructID.ForeColor = System.Drawing.Color.Black
Me.txtLogStructID.Location = New System.Drawing.Point(20,121)
Me.txtLogStructID.name = "txtLogStructID"
Me.txtLogStructID.Size = New System.Drawing.Size(200, 20)
Me.txtLogStructID.TabIndex = 7
Me.txtLogStructID.Text = "" 
Me.lblVERB.Location = New System.Drawing.Point(20,146)
Me.lblVERB.name = "lblVERB"
Me.lblVERB.Size = New System.Drawing.Size(200, 20)
Me.lblVERB.TabIndex = 8
Me.lblVERB.Text = "Действие"
Me.lblVERB.ForeColor = System.Drawing.Color.Black
Me.txtVERB.Location = New System.Drawing.Point(20,168)
Me.txtVERB.name = "txtVERB"
Me.txtVERB.Size = New System.Drawing.Size(200, 20)
Me.txtVERB.TabIndex = 9
Me.txtVERB.Text = "" 
Me.lblLogInstanceID.Location = New System.Drawing.Point(20,193)
Me.lblLogInstanceID.name = "lblLogInstanceID"
Me.lblLogInstanceID.Size = New System.Drawing.Size(200, 20)
Me.lblLogInstanceID.TabIndex = 10
Me.lblLogInstanceID.Text = "Идентификатор документа"
Me.lblLogInstanceID.ForeColor = System.Drawing.Color.Blue
Me.txtLogInstanceID.Location = New System.Drawing.Point(20,215)
Me.txtLogInstanceID.name = "txtLogInstanceID"
Me.txtLogInstanceID.Size = New System.Drawing.Size(200, 20)
Me.txtLogInstanceID.TabIndex = 11
Me.txtLogInstanceID.Text = "" 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTheSession)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTheSession)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdTheSession)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblthe_Resource)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtthe_Resource)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblLogStructID)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtLogStructID)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblVERB)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtVERB)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblLogInstanceID)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtLogInstanceID)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editSysLog"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtTheSession_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTheSession.TextChanged
  Changing

end sub
private sub cmdTheSession_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTheSession.Click
  on error resume next
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("the_Session","",System.guid.Empty, id, brief) Then
          txtTheSession.Tag = id
          txtTheSession.text = brief
        End If
end sub
private sub txtthe_Resource_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtthe_Resource.TextChanged
  Changing

end sub
private sub txtLogStructID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLogStructID.TextChanged
  Changing

end sub
private sub txtVERB_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVERB.TextChanged
  Changing

end sub
private sub txtLogInstanceID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLogInstanceID.TextChanged
  Changing

end sub

Public Item As MTZSystem.MTZSystem.SysLog
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,MTZSystem.MTZSystem.SysLog)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

If Not item.TheSession Is Nothing Then
  txtTheSession.Tag = item.TheSession.id
  txtTheSession.text = item.TheSession.brief
else
  txtTheSession.Tag = System.Guid.Empty 
  txtTheSession.text = "" 
End If
txtthe_Resource.text = item.the_Resource
txtLogStructID.text = item.LogStructID
txtVERB.text = item.VERB
txtLogInstanceID.text = item.LogInstanceID.ToString()
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

If not txtTheSession.Tag.Equals(System.Guid.Empty) Then
  item.TheSession = Item.Application.FindRowObject("the_Session",txtTheSession.Tag)
Else
   item.TheSession = Nothing
End If
item.the_Resource = txtthe_Resource.text
item.LogStructID = txtLogStructID.text
item.VERB = txtVERB.text
item.LogInstanceID = new System.Guid(txtLogInstanceID.text)
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK = not txtTheSession.Tag.Equals(System.Guid.Empty)
if mIsOK then mIsOK =( txtthe_Resource.text <> "" ) 
if mIsOK then mIsOK =( txtLogStructID.text <> "" ) 
if mIsOK then mIsOK =( txtVERB.text <> "" ) 
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
