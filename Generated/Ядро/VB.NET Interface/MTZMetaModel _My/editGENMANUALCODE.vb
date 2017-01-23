
Imports System.Windows.Forms
Imports Microsoft.VisualBasic



''' <summary>
'''Контрол редактирования раздела Ручной код режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editGENMANUALCODE
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
Friend WithEvents lblthe_Alias  as  System.Windows.Forms.Label
Friend WithEvents txtthe_Alias As System.Windows.Forms.TextBox
Friend WithEvents lblCode  as  System.Windows.Forms.Label
Friend WithEvents txtCode As System.Windows.Forms.TextBox

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
Me.lblthe_Alias = New System.Windows.Forms.Label
Me.txtthe_Alias = New System.Windows.Forms.TextBox
Me.lblCode = New System.Windows.Forms.Label
Me.txtCode = New System.Windows.Forms.TextBox

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
Me.lblthe_Alias.Location = New System.Drawing.Point(20,52)
Me.lblthe_Alias.name = "lblthe_Alias"
Me.lblthe_Alias.Size = New System.Drawing.Size(200, 20)
Me.lblthe_Alias.TabIndex = 3
Me.lblthe_Alias.Text = "Псевдоним"
Me.lblthe_Alias.ForeColor = System.Drawing.Color.Blue
Me.txtthe_Alias.Location = New System.Drawing.Point(20,74)
Me.txtthe_Alias.name = "txtthe_Alias"
Me.txtthe_Alias.Size = New System.Drawing.Size(200, 20)
Me.txtthe_Alias.TabIndex = 4
Me.txtthe_Alias.Text = "" 
Me.lblCode.Location = New System.Drawing.Point(20,99)
Me.lblCode.name = "lblCode"
Me.lblCode.Size = New System.Drawing.Size(200, 20)
Me.lblCode.TabIndex = 5
Me.lblCode.Text = "Код"
Me.lblCode.ForeColor = System.Drawing.Color.Black
Me.txtCode.Location = New System.Drawing.Point(20,121)
Me.txtCode.name = "txtCode"
Me.txtCode.MultiLine = True
Me.txtCode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtCode.Size = New System.Drawing.Size(200, 50 + 20)
Me.txtCode.TabIndex = 6
Me.txtCode.Text = "" 
        Me.AutoScroll = True

 CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblName)
 CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtName)
 CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblthe_Alias)
 CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtthe_Alias)
 CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblCode)
 CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtCode)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editGENMANUALCODE"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
  Changing

end sub
private sub txtthe_Alias_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtthe_Alias.TextChanged
  Changing

end sub
private sub txtCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCode.TextChanged
  Changing

end sub

Public Item As MTZMetaModel.MTZMetaModel.GENMANUALCODE
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,MTZMetaModel.MTZMetaModel.GENMANUALCODE)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

txtName.text = item.Name
txtthe_Alias.text = item.the_Alias
txtCode.text = item.Code
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
item.the_Alias = txtthe_Alias.text
item.Code = txtCode.text
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK =( txtName.text <> "" ) 
if mIsOK then mIsOK =( txtCode.text <> "" ) 
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
