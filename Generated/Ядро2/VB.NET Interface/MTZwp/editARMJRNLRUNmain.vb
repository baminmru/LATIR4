
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Действия режим:main
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editARMJRNLRUNmain
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
Friend WithEvents lblName  as  System.Windows.Forms.Label
Friend WithEvents txtName As System.Windows.Forms.TextBox
Friend WithEvents lblTheExtention  as  System.Windows.Forms.Label
Friend WithEvents txtTheExtention As System.Windows.Forms.TextBox
Friend WithEvents cmdTheExtention As System.Windows.Forms.Button

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
Me.lblName = New System.Windows.Forms.Label
Me.txtName = New System.Windows.Forms.TextBox
Me.lblTheExtention = New System.Windows.Forms.Label
Me.txtTheExtention = New System.Windows.Forms.TextBox
Me.cmdTheExtention = New System.Windows.Forms.Button

Me.lblName.Location = New System.Drawing.Point(20,5)
Me.lblName.name = "lblName"
Me.lblName.Size = New System.Drawing.Size(200, 20)
Me.lblName.TabIndex = 1
Me.lblName.Text = "Название"
Me.lblName.ForeColor = System.Drawing.Color.Black
Me.txtName.Location = New System.Drawing.Point(20,27)
Me.txtName.name = "txtName"
Me.txtName.Size = New System.Drawing.Size(200, 20)
Me.txtName.TabIndex = 2
Me.txtName.Text = "" 
Me.lblTheExtention.Location = New System.Drawing.Point(20,52)
Me.lblTheExtention.name = "lblTheExtention"
Me.lblTheExtention.Size = New System.Drawing.Size(200, 20)
Me.lblTheExtention.TabIndex = 3
Me.lblTheExtention.Text = "Расширение"
Me.lblTheExtention.ForeColor = System.Drawing.Color.Black
Me.txtTheExtention.Location = New System.Drawing.Point(20,74)
Me.txtTheExtention.name = "txtTheExtention"
Me.txtTheExtention.ReadOnly = True
Me.txtTheExtention.Size = New System.Drawing.Size(176, 20)
Me.txtTheExtention.TabIndex = 4
Me.txtTheExtention.Text = "" 
Me.cmdTheExtention.Location = New System.Drawing.Point(198,74)
Me.cmdTheExtention.name = "cmdTheExtention"
Me.cmdTheExtention.Size = New System.Drawing.Size(22, 20)
Me.cmdTheExtention.TabIndex = 5
Me.cmdTheExtention.Text = "..." 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTheExtention)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTheExtention)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdTheExtention)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editARMJRNLRUN"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
  Changing

end sub
private sub txtTheExtention_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTheExtention.TextChanged
  Changing

end sub
private sub cmdTheExtention_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTheExtention.Click
  try
Dim id As guid
Dim brief As String  = string.Empty
Dim OK as boolean
       OK=GuiManager.GetObjectDialog("MTZExt","",id,brief)
If OK Then
    txtTheExtention.Text = brief
    txtTheExtention.Tag = id
End If
        catch ex as systm.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
End Sub

Public Item As MTZwp.MTZwp.ARMJRNLRUN
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,MTZwp.MTZwp.ARMJRNLRUN)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

txtName.text = item.Name
If Not item.TheExtention Is Nothing Then
  txtTheExtention.Tag = item.TheExtention.id
  txtTheExtention.text = item.TheExtention.brief
else
  txtTheExtention.Tag = System.Guid.Empty 
  txtTheExtention.text = "" 
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

item.Name = txtName.text
If not txtTheExtention.Tag.Equals(System.Guid.Empty) Then
   item.TheExtention = GuiManager.Manager.GetInstanceObject(txtTheExtention.Tag)
Else
   item.TheExtention = Nothing
End If
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK =( txtName.text <> "" ) 
if mIsOK then mIsOK = not txtTheExtention.Tag.Equals(System.Guid.Empty)
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
