
Imports System.Windows.Forms
Imports Microsoft.VisualBasic



''' <summary>
'''Контрол редактирования раздела Формулы режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editRPTFormula
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
Friend WithEvents lblName  as  System.Windows.Forms.Label
Friend WithEvents txtName As System.Windows.Forms.TextBox
Friend WithEvents lblCode  as  System.Windows.Forms.Label
Friend WithEvents txtCode As System.Windows.Forms.TextBox
Friend WithEvents lblPlatform  as  System.Windows.Forms.Label
Friend WithEvents txtPlatform As System.Windows.Forms.TextBox
Friend WithEvents cmdPlatform As System.Windows.Forms.Button
Friend WithEvents cmdPlatformClear As System.Windows.Forms.Button

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
Me.lblCode = New System.Windows.Forms.Label
Me.txtCode = New System.Windows.Forms.TextBox
Me.lblPlatform = New System.Windows.Forms.Label
Me.txtPlatform = New System.Windows.Forms.TextBox
Me.cmdPlatform = New System.Windows.Forms.Button
Me.cmdPlatformClear = New System.Windows.Forms.Button

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
Me.lblCode.Location = New System.Drawing.Point(20,52)
Me.lblCode.name = "lblCode"
Me.lblCode.Size = New System.Drawing.Size(200, 20)
Me.lblCode.TabIndex = 3
Me.lblCode.Text = "Выражение"
Me.lblCode.ForeColor = System.Drawing.Color.Blue
Me.txtCode.Location = New System.Drawing.Point(20,74)
Me.txtCode.name = "txtCode"
Me.txtCode.MultiLine = True
Me.txtCode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtCode.Size = New System.Drawing.Size(200, 50 + 20)
Me.txtCode.TabIndex = 4
Me.txtCode.Text = "" 
Me.lblPlatform.Location = New System.Drawing.Point(20,144)
Me.lblPlatform.name = "lblPlatform"
Me.lblPlatform.Size = New System.Drawing.Size(200, 20)
Me.lblPlatform.TabIndex = 5
Me.lblPlatform.Text = "Платформа"
Me.lblPlatform.ForeColor = System.Drawing.Color.Blue
Me.txtPlatform.Location = New System.Drawing.Point(20,166)
Me.txtPlatform.name = "txtPlatform"
Me.txtPlatform.ReadOnly = True
Me.txtPlatform.Size = New System.Drawing.Size(155, 20)
Me.txtPlatform.TabIndex = 6
Me.txtPlatform.Text = "" 
Me.cmdPlatform.Location = New System.Drawing.Point(176,166)
Me.cmdPlatform.name = "cmdPlatform"
Me.cmdPlatform.Size = New System.Drawing.Size(22, 20)
Me.cmdPlatform.TabIndex = 7
Me.cmdPlatform.Text = "..." 
Me.cmdPlatformClear.Location = New System.Drawing.Point(198,166)
Me.cmdPlatformClear.name = "cmdPlatformClear"
Me.cmdPlatformClear.Size = New System.Drawing.Size(22, 20)
Me.cmdPlatformClear.TabIndex = 8
Me.cmdPlatformClear.Text = "X" 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblCode)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtCode)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblPlatform)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtPlatform)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdPlatform)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdPlatformClear)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editRPTFormula"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
  Changing

end sub
private sub txtCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCode.TextChanged
  Changing

end sub
private sub txtPlatform_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPlatform.TextChanged
  Changing

end sub
private sub cmdPlatform_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPlatform.Click
  on error resume next
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("GENERATOR_TARGET","",System.guid.Empty, id, brief) Then
          txtPlatform.Tag = id
          txtPlatform.text = brief
        End If
end sub
private sub cmdPlatformClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPlatformClear.Click
  on error resume next
          txtPlatform.Tag = Guid.Empty
          txtPlatform.text = ""
end sub

Public Item As MTZRprt.MTZRprt.RPTFormula
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,MTZRprt.MTZRprt.RPTFormula)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

txtName.text = item.Name
txtCode.text = item.Code
If Not item.Platform Is Nothing Then
  txtPlatform.Tag = item.Platform.id
  txtPlatform.text = item.Platform.brief
else
  txtPlatform.Tag = System.Guid.Empty 
  txtPlatform.text = "" 
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
item.Code = txtCode.text
If not txtPlatform.Tag.Equals(System.Guid.Empty) Then
  item.Platform = Item.Application.FindRowObject("GENERATOR_TARGET",txtPlatform.Tag)
Else
   item.Platform = Nothing
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
