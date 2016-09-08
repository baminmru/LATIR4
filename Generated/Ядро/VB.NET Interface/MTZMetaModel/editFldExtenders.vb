
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Интерфейсы расширения режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editFldExtenders
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
Friend WithEvents lblTheName  as  System.Windows.Forms.Label
Friend WithEvents txtTheName As System.Windows.Forms.TextBox
Friend WithEvents lblTargetPlatform  as  System.Windows.Forms.Label
Friend WithEvents txtTargetPlatform As System.Windows.Forms.TextBox
Friend WithEvents cmdTargetPlatform As System.Windows.Forms.Button
Friend WithEvents lblTheObject  as  System.Windows.Forms.Label
Friend WithEvents txtTheObject As System.Windows.Forms.TextBox
Friend WithEvents lblTheConfig  as  System.Windows.Forms.Label
Friend WithEvents txtTheConfig As System.Windows.Forms.TextBox

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
Me.lblTheName = New System.Windows.Forms.Label
Me.txtTheName = New System.Windows.Forms.TextBox
Me.lblTargetPlatform = New System.Windows.Forms.Label
Me.txtTargetPlatform = New System.Windows.Forms.TextBox
Me.cmdTargetPlatform = New System.Windows.Forms.Button
Me.lblTheObject = New System.Windows.Forms.Label
Me.txtTheObject = New System.Windows.Forms.TextBox
Me.lblTheConfig = New System.Windows.Forms.Label
Me.txtTheConfig = New System.Windows.Forms.TextBox

Me.lblTheName.Location = New System.Drawing.Point(20,5)
Me.lblTheName.name = "lblTheName"
Me.lblTheName.Size = New System.Drawing.Size(200, 20)
Me.lblTheName.TabIndex = 1
Me.lblTheName.Text = "Название"
Me.lblTheName.ForeColor = System.Drawing.Color.Black
Me.txtTheName.Location = New System.Drawing.Point(20,27)
Me.txtTheName.name = "txtTheName"
Me.txtTheName.Size = New System.Drawing.Size(200, 20)
Me.txtTheName.TabIndex = 2
Me.txtTheName.Text = "" 
Me.lblTargetPlatform.Location = New System.Drawing.Point(20,52)
Me.lblTargetPlatform.name = "lblTargetPlatform"
Me.lblTargetPlatform.Size = New System.Drawing.Size(200, 20)
Me.lblTargetPlatform.TabIndex = 3
Me.lblTargetPlatform.Text = "Целевая платформа"
Me.lblTargetPlatform.ForeColor = System.Drawing.Color.Black
Me.txtTargetPlatform.Location = New System.Drawing.Point(20,74)
Me.txtTargetPlatform.name = "txtTargetPlatform"
Me.txtTargetPlatform.ReadOnly = True
Me.txtTargetPlatform.Size = New System.Drawing.Size(176, 20)
Me.txtTargetPlatform.TabIndex = 4
Me.txtTargetPlatform.Text = "" 
Me.cmdTargetPlatform.Location = New System.Drawing.Point(198,74)
Me.cmdTargetPlatform.name = "cmdTargetPlatform"
Me.cmdTargetPlatform.Size = New System.Drawing.Size(22, 20)
Me.cmdTargetPlatform.TabIndex = 5
Me.cmdTargetPlatform.Text = "..." 
Me.lblTheObject.Location = New System.Drawing.Point(20,99)
Me.lblTheObject.name = "lblTheObject"
Me.lblTheObject.Size = New System.Drawing.Size(200, 20)
Me.lblTheObject.TabIndex = 6
Me.lblTheObject.Text = "Объект"
Me.lblTheObject.ForeColor = System.Drawing.Color.Black
Me.txtTheObject.Location = New System.Drawing.Point(20,121)
Me.txtTheObject.name = "txtTheObject"
Me.txtTheObject.Size = New System.Drawing.Size(200, 20)
Me.txtTheObject.TabIndex = 7
Me.txtTheObject.Text = "" 
Me.lblTheConfig.Location = New System.Drawing.Point(20,146)
Me.lblTheConfig.name = "lblTheConfig"
Me.lblTheConfig.Size = New System.Drawing.Size(200, 20)
Me.lblTheConfig.TabIndex = 8
Me.lblTheConfig.Text = "Конфиг"
Me.lblTheConfig.ForeColor = System.Drawing.Color.Blue
Me.txtTheConfig.Location = New System.Drawing.Point(20,168)
Me.txtTheConfig.name = "txtTheConfig"
Me.txtTheConfig.Size = New System.Drawing.Size(200, 20)
Me.txtTheConfig.TabIndex = 9
Me.txtTheConfig.Text = "" 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTheName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTheName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTargetPlatform)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTargetPlatform)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdTargetPlatform)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTheObject)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTheObject)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTheConfig)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTheConfig)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editFldExtenders"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtTheName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTheName.TextChanged
  Changing

end sub
private sub txtTargetPlatform_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTargetPlatform.TextChanged
  Changing

end sub
private sub cmdTargetPlatform_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTargetPlatform.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("GENERATOR_TARGET","",System.guid.Empty, id, brief) Then
          txtTargetPlatform.Tag = id
          txtTargetPlatform.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtTheObject_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTheObject.TextChanged
  Changing

end sub
private sub txtTheConfig_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTheConfig.TextChanged
  Changing

end sub

Public Item As MTZMetaModel.MTZMetaModel.FldExtenders
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,MTZMetaModel.MTZMetaModel.FldExtenders)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

txtTheName.text = item.TheName
If Not item.TargetPlatform Is Nothing Then
  txtTargetPlatform.Tag = item.TargetPlatform.id
  txtTargetPlatform.text = item.TargetPlatform.brief
else
  txtTargetPlatform.Tag = System.Guid.Empty 
  txtTargetPlatform.text = "" 
End If
txtTheObject.text = item.TheObject
txtTheConfig.text = item.TheConfig
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

item.TheName = txtTheName.text
If not txtTargetPlatform.Tag.Equals(System.Guid.Empty) Then
  item.TargetPlatform = Item.Application.FindRowObject("GENERATOR_TARGET",txtTargetPlatform.Tag)
Else
   item.TargetPlatform = Nothing
End If
item.TheObject = txtTheObject.text
item.TheConfig = txtTheConfig.text
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK =( txtTheName.text <> "" ) 
if mIsOK then mIsOK = not txtTargetPlatform.Tag.Equals(System.Guid.Empty)
if mIsOK then mIsOK =( txtTheObject.text <> "" ) 
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
