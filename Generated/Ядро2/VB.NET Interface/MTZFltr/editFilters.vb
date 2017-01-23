
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Фильтр режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editFilters
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
Friend WithEvents txtName As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblTheCaption  as  System.Windows.Forms.Label
Friend WithEvents txtTheCaption As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblTheComment  as  System.Windows.Forms.Label
Friend WithEvents txtTheComment As LATIR2GuiManager.TouchTextBox

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
Me.txtName = New LATIR2GuiManager.TouchTextBox
Me.lblTheCaption = New System.Windows.Forms.Label
Me.txtTheCaption = New LATIR2GuiManager.TouchTextBox
Me.lblTheComment = New System.Windows.Forms.Label
Me.txtTheComment = New LATIR2GuiManager.TouchTextBox

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
Me.lblTheCaption.Location = New System.Drawing.Point(20,52)
Me.lblTheCaption.name = "lblTheCaption"
Me.lblTheCaption.Size = New System.Drawing.Size(200, 20)
Me.lblTheCaption.TabIndex = 3
Me.lblTheCaption.Text = "Заголовок"
Me.lblTheCaption.ForeColor = System.Drawing.Color.Blue
Me.txtTheCaption.Location = New System.Drawing.Point(20,74)
Me.txtTheCaption.name = "txtTheCaption"
Me.txtTheCaption.Size = New System.Drawing.Size(200, 20)
Me.txtTheCaption.TabIndex = 4
Me.txtTheCaption.Text = "" 
Me.lblTheComment.Location = New System.Drawing.Point(20,99)
Me.lblTheComment.name = "lblTheComment"
Me.lblTheComment.Size = New System.Drawing.Size(200, 20)
Me.lblTheComment.TabIndex = 5
Me.lblTheComment.Text = "Описание"
Me.lblTheComment.ForeColor = System.Drawing.Color.Blue
Me.txtTheComment.Location = New System.Drawing.Point(20,121)
Me.txtTheComment.name = "txtTheComment"
Me.txtTheComment.MultiLine = True
Me.txtTheComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtTheComment.Size = New System.Drawing.Size(200, 50 + 20)
Me.txtTheComment.TabIndex = 6
Me.txtTheComment.Text = "" 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTheCaption)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTheCaption)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTheComment)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTheComment)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editFilters"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
  Changing

end sub
private sub txtTheCaption_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTheCaption.TextChanged
  Changing

end sub
private sub txtTheComment_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTheComment.TextChanged
  Changing

end sub

Public Item As MTZFltr.MTZFltr.Filters
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,MTZFltr.MTZFltr.Filters)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

txtName.text = item.Name
txtTheCaption.text = item.TheCaption
txtTheComment.text = item.TheComment
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
item.TheCaption = txtTheCaption.text
item.TheComment = txtTheComment.text
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
