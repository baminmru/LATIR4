
Imports System.Windows.Forms
Imports Microsoft.VisualBasic



''' <summary>
'''Контрол редактирования раздела Разрешенные переходы режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editNEXTSTATE
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
Friend WithEvents lblTheState  as  System.Windows.Forms.Label
Friend WithEvents txtTheState As System.Windows.Forms.TextBox
Friend WithEvents cmdTheState As System.Windows.Forms.Button

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
Me.lblTheState = New System.Windows.Forms.Label
Me.txtTheState = New System.Windows.Forms.TextBox
Me.cmdTheState = New System.Windows.Forms.Button

Me.lblTheState.Location = New System.Drawing.Point(20,5)
Me.lblTheState.name = "lblTheState"
Me.lblTheState.Size = New System.Drawing.Size(200, 20)
Me.lblTheState.TabIndex = 1
Me.lblTheState.Text = "Разрешенное состояние"
Me.lblTheState.ForeColor = System.Drawing.Color.Black
Me.txtTheState.Location = New System.Drawing.Point(20,27)
Me.txtTheState.name = "txtTheState"
Me.txtTheState.ReadOnly = True
Me.txtTheState.Size = New System.Drawing.Size(176, 20)
Me.txtTheState.TabIndex = 2
Me.txtTheState.Text = "" 
Me.cmdTheState.Location = New System.Drawing.Point(198,27)
Me.cmdTheState.name = "cmdTheState"
Me.cmdTheState.Size = New System.Drawing.Size(22, 20)
Me.cmdTheState.TabIndex = 3
Me.cmdTheState.Text = "..." 
        Me.AutoScroll = True

 CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTheState)
 CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTheState)
 CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdTheState)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editNEXTSTATE"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtTheState_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTheState.TextChanged
  Changing

end sub
private sub cmdTheState_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTheState.Click
  on error resume next
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("OBJSTATUS","",System.guid.Empty, id, brief) Then
          txtTheState.Tag = id
          txtTheState.text = brief
        End If
end sub

Public Item As MTZMetaModel.MTZMetaModel.NEXTSTATE
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,MTZMetaModel.MTZMetaModel.NEXTSTATE)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

If Not item.TheState Is Nothing Then
  txtTheState.Tag = item.TheState.id
  txtTheState.text = item.TheState.brief
else
  txtTheState.Tag = System.Guid.Empty 
  txtTheState.text = "" 
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

If not txtTheState.Tag.Equals(System.Guid.Empty) Then
  item.TheState = Item.Application.FindRowObject("OBJSTATUS",txtTheState.Tag)
Else
   item.TheState = Nothing
End If
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK = not txtTheState.Tag.Equals(System.Guid.Empty)
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
