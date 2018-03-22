
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Поля ограничения режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editCONSTRAINTFIELD
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
Friend WithEvents lblTheField  as  System.Windows.Forms.Label
Friend WithEvents txtTheField As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdTheField As System.Windows.Forms.Button

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
Me.lblTheField = New System.Windows.Forms.Label
Me.txtTheField = New LATIR2GuiManager.TouchTextBox
Me.cmdTheField = New System.Windows.Forms.Button

Me.lblTheField.Location = New System.Drawing.Point(20,5)
Me.lblTheField.name = "lblTheField"
Me.lblTheField.Size = New System.Drawing.Size(200, 20)
Me.lblTheField.TabIndex = 1
Me.lblTheField.Text = "Поле"
Me.lblTheField.ForeColor = System.Drawing.Color.Black
Me.txtTheField.Location = New System.Drawing.Point(20,27)
Me.txtTheField.name = "txtTheField"
Me.txtTheField.ReadOnly = True
Me.txtTheField.Size = New System.Drawing.Size(176, 20)
Me.txtTheField.TabIndex = 2
Me.txtTheField.Text = "" 
Me.cmdTheField.Location = New System.Drawing.Point(198,27)
Me.cmdTheField.name = "cmdTheField"
Me.cmdTheField.Size = New System.Drawing.Size(22, 20)
Me.cmdTheField.TabIndex = 3
Me.cmdTheField.Text = "..." 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTheField)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTheField)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdTheField)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editCONSTRAINTFIELD"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtTheField_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTheField.TextChanged
  Changing

end sub
private sub cmdTheField_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTheField.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("FIELD","",System.guid.Empty, id, brief) Then
          txtTheField.Tag = id
          txtTheField.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub

Public Item As MTZMetaModel.MTZMetaModel.CONSTRAINTFIELD
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,MTZMetaModel.MTZMetaModel.CONSTRAINTFIELD)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

If Not item.TheField Is Nothing Then
  txtTheField.Tag = item.TheField.id
  txtTheField.text = item.TheField.brief
else
  txtTheField.Tag = System.Guid.Empty 
  txtTheField.text = "" 
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

If not txtTheField.Tag.Equals(System.Guid.Empty) Then
  item.TheField = Item.Application.FindRowObject("FIELD",txtTheField.Tag)
Else
   item.TheField = Nothing
End If
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK = not txtTheField.Tag.Equals(System.Guid.Empty)
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
