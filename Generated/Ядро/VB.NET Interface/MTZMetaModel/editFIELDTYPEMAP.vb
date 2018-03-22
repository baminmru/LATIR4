
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Отображение режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editFIELDTYPEMAP
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
Friend WithEvents lblTarget  as  System.Windows.Forms.Label
Friend WithEvents txtTarget As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdTarget As System.Windows.Forms.Button
Friend WithEvents lblStoageType  as  System.Windows.Forms.Label
Friend WithEvents txtStoageType As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblFixedSize  as  System.Windows.Forms.Label
Friend WithEvents txtFixedSize As LATIR2GuiManager.TouchTextBox

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
Me.lblTarget = New System.Windows.Forms.Label
Me.txtTarget = New LATIR2GuiManager.TouchTextBox
Me.cmdTarget = New System.Windows.Forms.Button
Me.lblStoageType = New System.Windows.Forms.Label
Me.txtStoageType = New LATIR2GuiManager.TouchTextBox
Me.lblFixedSize = New System.Windows.Forms.Label
Me.txtFixedSize = New LATIR2GuiManager.TouchTextBox

Me.lblTarget.Location = New System.Drawing.Point(20,5)
Me.lblTarget.name = "lblTarget"
Me.lblTarget.Size = New System.Drawing.Size(200, 20)
Me.lblTarget.TabIndex = 1
Me.lblTarget.Text = "Платформа"
Me.lblTarget.ForeColor = System.Drawing.Color.Black
Me.txtTarget.Location = New System.Drawing.Point(20,27)
Me.txtTarget.name = "txtTarget"
Me.txtTarget.ReadOnly = True
Me.txtTarget.Size = New System.Drawing.Size(176, 20)
Me.txtTarget.TabIndex = 2
Me.txtTarget.Text = "" 
Me.cmdTarget.Location = New System.Drawing.Point(198,27)
Me.cmdTarget.name = "cmdTarget"
Me.cmdTarget.Size = New System.Drawing.Size(22, 20)
Me.cmdTarget.TabIndex = 3
Me.cmdTarget.Text = "..." 
Me.lblStoageType.Location = New System.Drawing.Point(20,52)
Me.lblStoageType.name = "lblStoageType"
Me.lblStoageType.Size = New System.Drawing.Size(200, 20)
Me.lblStoageType.TabIndex = 4
Me.lblStoageType.Text = "Тип хранения"
Me.lblStoageType.ForeColor = System.Drawing.Color.Black
Me.txtStoageType.Location = New System.Drawing.Point(20,74)
Me.txtStoageType.name = "txtStoageType"
Me.txtStoageType.Size = New System.Drawing.Size(200, 20)
Me.txtStoageType.TabIndex = 5
Me.txtStoageType.Text = "" 
Me.lblFixedSize.Location = New System.Drawing.Point(20,99)
Me.lblFixedSize.name = "lblFixedSize"
Me.lblFixedSize.Size = New System.Drawing.Size(200, 20)
Me.lblFixedSize.TabIndex = 6
Me.lblFixedSize.Text = "Размер"
Me.lblFixedSize.ForeColor = System.Drawing.Color.Blue
Me.txtFixedSize.Location = New System.Drawing.Point(20,121)
Me.txtFixedSize.name = "txtFixedSize"
Me.txtFixedSize.MultiLine = false
Me.txtFixedSize.Size = New System.Drawing.Size(200,  20)
Me.txtFixedSize.TabIndex = 7
Me.txtFixedSize.Text = "" 
Me.txtFixedSize.MaxLength = 15
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTarget)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTarget)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdTarget)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblStoageType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtStoageType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblFixedSize)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtFixedSize)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editFIELDTYPEMAP"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtTarget_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTarget.TextChanged
  Changing

end sub
private sub cmdTarget_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTarget.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("GENERATOR_TARGET","",System.guid.Empty, id, brief) Then
          txtTarget.Tag = id
          txtTarget.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtStoageType_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStoageType.TextChanged
  Changing

end sub
        Private Sub txtFixedSize_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtFixedSize.Validating
        If txtFixedSize.Text <> "" Then
            try
            If Not IsNumeric(txtFixedSize.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtFixedSize.Text) < -2000000000 Or Val(txtFixedSize.Text) > 2000000000 Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
            Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtFixedSize_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFixedSize.TextChanged
  Changing

end sub

Public Item As MTZMetaModel.MTZMetaModel.FIELDTYPEMAP
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,MTZMetaModel.MTZMetaModel.FIELDTYPEMAP)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

If Not item.Target Is Nothing Then
  txtTarget.Tag = item.Target.id
  txtTarget.text = item.Target.brief
else
  txtTarget.Tag = System.Guid.Empty 
  txtTarget.text = "" 
End If
txtStoageType.text = item.StoageType
txtFixedSize.text = item.FixedSize.toString()
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

If not txtTarget.Tag.Equals(System.Guid.Empty) Then
  item.Target = Item.Application.FindRowObject("GENERATOR_TARGET",txtTarget.Tag)
Else
   item.Target = Nothing
End If
item.StoageType = txtStoageType.text
item.FixedSize = val(txtFixedSize.text)
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK = not txtTarget.Tag.Equals(System.Guid.Empty)
if mIsOK then mIsOK =( txtStoageType.text <> "" ) 
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
