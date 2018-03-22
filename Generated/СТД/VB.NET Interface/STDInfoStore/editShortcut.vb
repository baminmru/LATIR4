
Imports System.Windows.Forms
Imports Microsoft.VisualBasic



''' <summary>
'''Контрол редактирования раздела Документы режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editShortcut
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
Friend WithEvents lblDocItem  as  System.Windows.Forms.Label
Friend WithEvents txtDocItem As System.Windows.Forms.TextBox
Friend WithEvents cmdDocItem As System.Windows.Forms.Button
Friend WithEvents lblStartMode  as  System.Windows.Forms.Label
Friend WithEvents txtStartMode As System.Windows.Forms.TextBox

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
Me.lblDocItem = New System.Windows.Forms.Label
Me.txtDocItem = New System.Windows.Forms.TextBox
Me.cmdDocItem = New System.Windows.Forms.Button
Me.lblStartMode = New System.Windows.Forms.Label
Me.txtStartMode = New System.Windows.Forms.TextBox

Me.lblDocItem.Location = New System.Drawing.Point(20,5)
Me.lblDocItem.name = "lblDocItem"
Me.lblDocItem.Size = New System.Drawing.Size(200, 20)
Me.lblDocItem.TabIndex = 1
Me.lblDocItem.Text = "Документ"
Me.lblDocItem.ForeColor = System.Drawing.Color.Black
Me.txtDocItem.Location = New System.Drawing.Point(20,27)
Me.txtDocItem.name = "txtDocItem"
Me.txtDocItem.ReadOnly = True
Me.txtDocItem.Size = New System.Drawing.Size(176, 20)
Me.txtDocItem.TabIndex = 2
Me.txtDocItem.Text = "" 
Me.cmdDocItem.Location = New System.Drawing.Point(198,27)
Me.cmdDocItem.name = "cmdDocItem"
Me.cmdDocItem.Size = New System.Drawing.Size(22, 20)
Me.cmdDocItem.TabIndex = 3
Me.cmdDocItem.Text = "..." 
Me.lblStartMode.Location = New System.Drawing.Point(20,52)
Me.lblStartMode.name = "lblStartMode"
Me.lblStartMode.Size = New System.Drawing.Size(200, 20)
Me.lblStartMode.TabIndex = 4
Me.lblStartMode.Text = "Режим"
Me.lblStartMode.ForeColor = System.Drawing.Color.Blue
Me.txtStartMode.Location = New System.Drawing.Point(20,74)
Me.txtStartMode.name = "txtStartMode"
Me.txtStartMode.Size = New System.Drawing.Size(200, 20)
Me.txtStartMode.TabIndex = 5
Me.txtStartMode.Text = "" 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblDocItem)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtDocItem)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdDocItem)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblStartMode)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtStartMode)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editShortcut"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtDocItem_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDocItem.TextChanged
  Changing

end sub
private sub cmdDocItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDocItem.Click
  on error resume next
Dim id As guid
Dim brief As String  = string.Empty
Dim OK as boolean
        OK=GuiManager.GetObjectDialog("","",id,brief)
If OK Then
    txtDocItem.Text = brief
    txtDocItem.Tag = id
End If
End Sub
private sub txtStartMode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStartMode.TextChanged
  Changing

end sub

Public Item As STDInfoStore.STDInfoStore.Shortcut
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,STDInfoStore.STDInfoStore.Shortcut)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

If Not item.DocItem Is Nothing Then
  txtDocItem.Tag = item.DocItem.id
  txtDocItem.text = item.DocItem.brief
else
  txtDocItem.Tag = System.Guid.Empty 
  txtDocItem.text = "" 
End If
txtStartMode.text = item.StartMode
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

If not txtDocItem.Tag.Equals(System.Guid.Empty) Then
   item.DocItem = GuiManager.Manager.GetInstanceObject(txtDocItem.Tag)
Else
   item.DocItem = Nothing
End If
item.StartMode = txtStartMode.text
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK = not txtDocItem.Tag.Equals(System.Guid.Empty)
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
