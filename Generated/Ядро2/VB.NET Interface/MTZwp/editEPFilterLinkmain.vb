
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Привязка фильтра режим:main
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editEPFilterLinkmain
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
Friend WithEvents lblRowSource  as  System.Windows.Forms.Label
Friend WithEvents txtRowSource As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblTheExpression  as  System.Windows.Forms.Label
Friend WithEvents txtTheExpression As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblFilterField  as  System.Windows.Forms.Label
Friend WithEvents txtFilterField As LATIR2GuiManager.TouchTextBox

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
Me.lblRowSource = New System.Windows.Forms.Label
Me.txtRowSource = New LATIR2GuiManager.TouchTextBox
Me.lblTheExpression = New System.Windows.Forms.Label
Me.txtTheExpression = New LATIR2GuiManager.TouchTextBox
Me.lblFilterField = New System.Windows.Forms.Label
Me.txtFilterField = New LATIR2GuiManager.TouchTextBox

Me.lblRowSource.Location = New System.Drawing.Point(20,5)
Me.lblRowSource.name = "lblRowSource"
Me.lblRowSource.Size = New System.Drawing.Size(200, 20)
Me.lblRowSource.TabIndex = 1
Me.lblRowSource.Text = "Источник"
Me.lblRowSource.ForeColor = System.Drawing.Color.Black
Me.txtRowSource.Location = New System.Drawing.Point(20,27)
Me.txtRowSource.name = "txtRowSource"
Me.txtRowSource.Size = New System.Drawing.Size(200, 20)
Me.txtRowSource.TabIndex = 2
Me.txtRowSource.Text = "" 
Me.lblTheExpression.Location = New System.Drawing.Point(20,52)
Me.lblTheExpression.name = "lblTheExpression"
Me.lblTheExpression.Size = New System.Drawing.Size(200, 20)
Me.lblTheExpression.TabIndex = 3
Me.lblTheExpression.Text = "Выражение"
Me.lblTheExpression.ForeColor = System.Drawing.Color.Black
Me.txtTheExpression.Location = New System.Drawing.Point(20,74)
Me.txtTheExpression.name = "txtTheExpression"
Me.txtTheExpression.MultiLine = True
Me.txtTheExpression.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtTheExpression.Size = New System.Drawing.Size(200, 50 + 20)
Me.txtTheExpression.TabIndex = 4
Me.txtTheExpression.Text = "" 
Me.lblFilterField.Location = New System.Drawing.Point(20,144)
Me.lblFilterField.name = "lblFilterField"
Me.lblFilterField.Size = New System.Drawing.Size(200, 20)
Me.lblFilterField.TabIndex = 5
Me.lblFilterField.Text = "Поле фильтра"
Me.lblFilterField.ForeColor = System.Drawing.Color.Blue
Me.txtFilterField.Location = New System.Drawing.Point(20,166)
Me.txtFilterField.name = "txtFilterField"
Me.txtFilterField.Size = New System.Drawing.Size(200, 20)
Me.txtFilterField.TabIndex = 6
Me.txtFilterField.Text = "" 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblRowSource)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtRowSource)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTheExpression)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTheExpression)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblFilterField)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtFilterField)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editEPFilterLink"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtRowSource_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRowSource.TextChanged
  Changing

end sub
private sub txtTheExpression_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTheExpression.TextChanged
  Changing

end sub
private sub txtFilterField_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFilterField.TextChanged
  Changing

end sub

Public Item As MTZwp.MTZwp.EPFilterLink
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,MTZwp.MTZwp.EPFilterLink)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

txtRowSource.text = item.RowSource
txtTheExpression.text = item.TheExpression
txtFilterField.text = item.FilterField
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

item.RowSource = txtRowSource.text
item.TheExpression = txtTheExpression.text
item.FilterField = txtFilterField.text
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK =( txtRowSource.text <> "" ) 
if mIsOK then mIsOK =( txtTheExpression.text <> "" ) 
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
