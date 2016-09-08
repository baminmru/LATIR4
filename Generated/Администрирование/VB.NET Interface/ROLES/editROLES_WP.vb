
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Доступные приложения режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editROLES_WP
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
Friend WithEvents lblWP  as  System.Windows.Forms.Label
Friend WithEvents txtWP As System.Windows.Forms.TextBox
Friend WithEvents cmdWP As System.Windows.Forms.Button

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
Me.lblWP = New System.Windows.Forms.Label
Me.txtWP = New System.Windows.Forms.TextBox
Me.cmdWP = New System.Windows.Forms.Button

Me.lblWP.Location = New System.Drawing.Point(20,5)
Me.lblWP.name = "lblWP"
Me.lblWP.Size = New System.Drawing.Size(200, 20)
Me.lblWP.TabIndex = 1
Me.lblWP.Text = "Приложение"
Me.lblWP.ForeColor = System.Drawing.Color.Black
Me.txtWP.Location = New System.Drawing.Point(20,27)
Me.txtWP.name = "txtWP"
Me.txtWP.ReadOnly = True
Me.txtWP.Size = New System.Drawing.Size(176, 20)
Me.txtWP.TabIndex = 2
Me.txtWP.Text = "" 
Me.cmdWP.Location = New System.Drawing.Point(198,27)
Me.cmdWP.name = "cmdWP"
Me.cmdWP.Size = New System.Drawing.Size(22, 20)
Me.cmdWP.TabIndex = 3
Me.cmdWP.Text = "..." 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblWP)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtWP)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdWP)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editROLES_WP"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtWP_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtWP.TextChanged
  Changing

end sub
private sub cmdWP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWP.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("WorkPlace","",System.guid.Empty, id, brief) Then
          txtWP.Tag = id
          txtWP.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub

Public Item As ROLES.ROLES.ROLES_WP
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,ROLES.ROLES.ROLES_WP)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

If Not item.WP Is Nothing Then
  txtWP.Tag = item.WP.id
  txtWP.text = item.WP.brief
else
  txtWP.Tag = System.Guid.Empty 
  txtWP.text = "" 
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

If not txtWP.Tag.Equals(System.Guid.Empty) Then
  item.WP = Item.Application.FindRowObject("WorkPlace",txtWP.Tag)
Else
   item.WP = Nothing
End If
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK = not txtWP.Tag.Equals(System.Guid.Empty)
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
