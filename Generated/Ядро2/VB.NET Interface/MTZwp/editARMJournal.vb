
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Поведение журналов режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editARMJournal
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
Friend WithEvents lblTheJournal  as  System.Windows.Forms.Label
Friend WithEvents txtTheJournal As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdTheJournal As System.Windows.Forms.Button

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
Me.lblTheJournal = New System.Windows.Forms.Label
Me.txtTheJournal = New LATIR2GuiManager.TouchTextBox
Me.cmdTheJournal = New System.Windows.Forms.Button

Me.lblTheJournal.Location = New System.Drawing.Point(20,5)
Me.lblTheJournal.name = "lblTheJournal"
Me.lblTheJournal.Size = New System.Drawing.Size(200, 20)
Me.lblTheJournal.TabIndex = 1
Me.lblTheJournal.Text = "Журнал"
Me.lblTheJournal.ForeColor = System.Drawing.Color.Black
Me.txtTheJournal.Location = New System.Drawing.Point(20,27)
Me.txtTheJournal.name = "txtTheJournal"
Me.txtTheJournal.ReadOnly = True
Me.txtTheJournal.Size = New System.Drawing.Size(176, 20)
Me.txtTheJournal.TabIndex = 2
Me.txtTheJournal.Text = "" 
Me.cmdTheJournal.Location = New System.Drawing.Point(198,27)
Me.cmdTheJournal.name = "cmdTheJournal"
Me.cmdTheJournal.Size = New System.Drawing.Size(22, 20)
Me.cmdTheJournal.TabIndex = 3
Me.cmdTheJournal.Text = "..." 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTheJournal)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTheJournal)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdTheJournal)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editARMJournal"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtTheJournal_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTheJournal.TextChanged
  Changing

end sub
private sub cmdTheJournal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTheJournal.Click
  try
Dim id As guid
Dim brief As String  = string.Empty
Dim OK as boolean
       OK=GuiManager.GetObjectDialog("MTZJrnl","",id,brief)
If OK Then
    txtTheJournal.Text = brief
    txtTheJournal.Tag = id
End If
        catch ex as system.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
End Sub

Public Item As MTZwp.MTZwp.ARMJournal
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,MTZwp.MTZwp.ARMJournal)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

If Not item.TheJournal Is Nothing Then
  txtTheJournal.Tag = item.TheJournal.id
  txtTheJournal.text = item.TheJournal.brief
else
  txtTheJournal.Tag = System.Guid.Empty 
  txtTheJournal.text = "" 
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

If not txtTheJournal.Tag.Equals(System.Guid.Empty) Then
   item.TheJournal = GuiManager.Manager.GetInstanceObject(txtTheJournal.Tag)
Else
   item.TheJournal = Nothing
End If
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK = not txtTheJournal.Tag.Equals(System.Guid.Empty)
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
