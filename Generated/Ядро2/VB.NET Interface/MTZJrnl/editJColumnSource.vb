
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Состав колонки режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editJColumnSource
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
Friend WithEvents lblSrcPartView  as  System.Windows.Forms.Label
Friend WithEvents txtSrcPartView As System.Windows.Forms.TextBox
Friend WithEvents cmdSrcPartView As System.Windows.Forms.Button
Friend WithEvents lblViewField  as  System.Windows.Forms.Label
Friend WithEvents txtViewField As System.Windows.Forms.TextBox

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
Me.lblSrcPartView = New System.Windows.Forms.Label
Me.txtSrcPartView = New System.Windows.Forms.TextBox
Me.cmdSrcPartView = New System.Windows.Forms.Button
Me.lblViewField = New System.Windows.Forms.Label
Me.txtViewField = New System.Windows.Forms.TextBox

Me.lblSrcPartView.Location = New System.Drawing.Point(20,5)
Me.lblSrcPartView.name = "lblSrcPartView"
Me.lblSrcPartView.Size = New System.Drawing.Size(200, 20)
Me.lblSrcPartView.TabIndex = 1
Me.lblSrcPartView.Text = "Представление"
Me.lblSrcPartView.ForeColor = System.Drawing.Color.Black
Me.txtSrcPartView.Location = New System.Drawing.Point(20,27)
Me.txtSrcPartView.name = "txtSrcPartView"
Me.txtSrcPartView.ReadOnly = True
Me.txtSrcPartView.Size = New System.Drawing.Size(176, 20)
Me.txtSrcPartView.TabIndex = 2
Me.txtSrcPartView.Text = "" 
Me.cmdSrcPartView.Location = New System.Drawing.Point(198,27)
Me.cmdSrcPartView.name = "cmdSrcPartView"
Me.cmdSrcPartView.Size = New System.Drawing.Size(22, 20)
Me.cmdSrcPartView.TabIndex = 3
Me.cmdSrcPartView.Text = "..." 
Me.lblViewField.Location = New System.Drawing.Point(20,52)
Me.lblViewField.name = "lblViewField"
Me.lblViewField.Size = New System.Drawing.Size(200, 20)
Me.lblViewField.TabIndex = 4
Me.lblViewField.Text = "Поле представления"
Me.lblViewField.ForeColor = System.Drawing.Color.Black
Me.txtViewField.Location = New System.Drawing.Point(20,74)
Me.txtViewField.name = "txtViewField"
Me.txtViewField.Size = New System.Drawing.Size(200, 20)
Me.txtViewField.TabIndex = 5
Me.txtViewField.Text = "" 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblSrcPartView)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtSrcPartView)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdSrcPartView)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblViewField)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtViewField)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editJColumnSource"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtSrcPartView_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSrcPartView.TextChanged
  Changing

end sub
private sub cmdSrcPartView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSrcPartView.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("JournalSrc","",item.application.ID, id, brief) Then
          txtSrcPartView.Tag = id
          txtSrcPartView.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtViewField_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtViewField.TextChanged
  Changing

end sub

Public Item As MTZJrnl.MTZJrnl.JColumnSource
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,MTZJrnl.MTZJrnl.JColumnSource)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

If Not item.SrcPartView Is Nothing Then
  txtSrcPartView.Tag = item.SrcPartView.id
  txtSrcPartView.text = item.SrcPartView.brief
else
  txtSrcPartView.Tag = System.Guid.Empty 
  txtSrcPartView.text = "" 
End If
txtViewField.text = item.ViewField
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

If not txtSrcPartView.Tag.Equals(System.Guid.Empty) Then
  item.SrcPartView = Item.Application.FindRowObject("JournalSrc",txtSrcPartView.Tag)
Else
   item.SrcPartView = Nothing
End If
item.ViewField = txtViewField.text
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK = not txtSrcPartView.Tag.Equals(System.Guid.Empty)
if mIsOK then mIsOK =( txtViewField.text <> "" ) 
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
