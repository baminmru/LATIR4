
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Зачения режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editENUMITEM
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
Friend WithEvents lblNameValue  as  System.Windows.Forms.Label
Friend WithEvents txtNameValue As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblNameInCode  as  System.Windows.Forms.Label
Friend WithEvents txtNameInCode As LATIR2GuiManager.TouchTextBox

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
Me.lblNameValue = New System.Windows.Forms.Label
Me.txtNameValue = New LATIR2GuiManager.TouchTextBox
Me.lblNameInCode = New System.Windows.Forms.Label
Me.txtNameInCode = New LATIR2GuiManager.TouchTextBox

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
Me.lblNameValue.Location = New System.Drawing.Point(20,52)
Me.lblNameValue.name = "lblNameValue"
Me.lblNameValue.Size = New System.Drawing.Size(200, 20)
Me.lblNameValue.TabIndex = 3
Me.lblNameValue.Text = "Значение"
Me.lblNameValue.ForeColor = System.Drawing.Color.Black
Me.txtNameValue.Location = New System.Drawing.Point(20,74)
Me.txtNameValue.name = "txtNameValue"
Me.txtNameValue.MultiLine = false
Me.txtNameValue.Size = New System.Drawing.Size(200,  20)
Me.txtNameValue.TabIndex = 4
Me.txtNameValue.Text = "" 
Me.txtNameValue.MaxLength = 15
Me.lblNameInCode.Location = New System.Drawing.Point(20,99)
Me.lblNameInCode.name = "lblNameInCode"
Me.lblNameInCode.Size = New System.Drawing.Size(200, 20)
Me.lblNameInCode.TabIndex = 5
Me.lblNameInCode.Text = "Название в коде"
Me.lblNameInCode.ForeColor = System.Drawing.Color.Blue
Me.txtNameInCode.Location = New System.Drawing.Point(20,121)
Me.txtNameInCode.name = "txtNameInCode"
Me.txtNameInCode.Size = New System.Drawing.Size(200, 20)
Me.txtNameInCode.TabIndex = 6
Me.txtNameInCode.Text = "" 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblNameValue)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtNameValue)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblNameInCode)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtNameInCode)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editENUMITEM"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
  Changing

end sub
        Private Sub txtNameValue_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtNameValue.Validating
        If txtNameValue.Text <> "" Then
            try
            If Not IsNumeric(txtNameValue.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtNameValue.Text) < -2000000000 Or Val(txtNameValue.Text) > 2000000000 Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
            Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtNameValue_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNameValue.TextChanged
  Changing

end sub
private sub txtNameInCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNameInCode.TextChanged
  Changing

end sub

Public Item As MTZMetaModel.MTZMetaModel.ENUMITEM
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,MTZMetaModel.MTZMetaModel.ENUMITEM)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

txtName.text = item.Name
txtNameValue.text = item.NameValue.toString()
txtNameInCode.text = item.NameInCode
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
item.NameValue = val(txtNameValue.text)
item.NameInCode = txtNameInCode.text
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK =( txtName.text <> "" ) 
if mIsOK then mIsOK =( txtNameValue.text <> "" ) 
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
