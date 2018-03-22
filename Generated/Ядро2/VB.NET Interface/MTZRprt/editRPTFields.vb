
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Поля секции режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editRPTFields
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
Friend WithEvents lblFieldType  as  System.Windows.Forms.Label
Friend WithEvents txtFieldType As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdFieldType As System.Windows.Forms.Button
Friend WithEvents lblFieldSize  as  System.Windows.Forms.Label
Friend WithEvents txtFieldSize As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblCaption  as  System.Windows.Forms.Label
Friend WithEvents txtCaption As LATIR2GuiManager.TouchTextBox

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
Me.lblFieldType = New System.Windows.Forms.Label
Me.txtFieldType = New LATIR2GuiManager.TouchTextBox
Me.cmdFieldType = New System.Windows.Forms.Button
Me.lblFieldSize = New System.Windows.Forms.Label
Me.txtFieldSize = New LATIR2GuiManager.TouchTextBox
Me.lblCaption = New System.Windows.Forms.Label
Me.txtCaption = New LATIR2GuiManager.TouchTextBox

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
Me.lblFieldType.Location = New System.Drawing.Point(20,52)
Me.lblFieldType.name = "lblFieldType"
Me.lblFieldType.Size = New System.Drawing.Size(200, 20)
Me.lblFieldType.TabIndex = 3
Me.lblFieldType.Text = "Тип поля"
Me.lblFieldType.ForeColor = System.Drawing.Color.Black
Me.txtFieldType.Location = New System.Drawing.Point(20,74)
Me.txtFieldType.name = "txtFieldType"
Me.txtFieldType.ReadOnly = True
Me.txtFieldType.Size = New System.Drawing.Size(176, 20)
Me.txtFieldType.TabIndex = 4
Me.txtFieldType.Text = "" 
Me.cmdFieldType.Location = New System.Drawing.Point(198,74)
Me.cmdFieldType.name = "cmdFieldType"
Me.cmdFieldType.Size = New System.Drawing.Size(22, 20)
Me.cmdFieldType.TabIndex = 5
Me.cmdFieldType.Text = "..." 
Me.lblFieldSize.Location = New System.Drawing.Point(20,99)
Me.lblFieldSize.name = "lblFieldSize"
Me.lblFieldSize.Size = New System.Drawing.Size(200, 20)
Me.lblFieldSize.TabIndex = 6
Me.lblFieldSize.Text = "Размер"
Me.lblFieldSize.ForeColor = System.Drawing.Color.Blue
Me.txtFieldSize.Location = New System.Drawing.Point(20,121)
Me.txtFieldSize.name = "txtFieldSize"
Me.txtFieldSize.MultiLine = false
Me.txtFieldSize.Size = New System.Drawing.Size(200,  20)
Me.txtFieldSize.TabIndex = 7
Me.txtFieldSize.Text = "" 
Me.txtFieldSize.MaxLength = 15
Me.lblCaption.Location = New System.Drawing.Point(20,146)
Me.lblCaption.name = "lblCaption"
Me.lblCaption.Size = New System.Drawing.Size(200, 20)
Me.lblCaption.TabIndex = 8
Me.lblCaption.Text = "Заголовок"
Me.lblCaption.ForeColor = System.Drawing.Color.Blue
Me.txtCaption.Location = New System.Drawing.Point(20,168)
Me.txtCaption.name = "txtCaption"
Me.txtCaption.Size = New System.Drawing.Size(200, 20)
Me.txtCaption.TabIndex = 9
Me.txtCaption.Text = "" 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblFieldType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtFieldType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdFieldType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblFieldSize)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtFieldSize)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblCaption)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtCaption)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editRPTFields"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
  Changing

end sub
private sub txtFieldType_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFieldType.TextChanged
  Changing

end sub
private sub cmdFieldType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFieldType.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("FIELDTYPE","",System.guid.Empty, id, brief) Then
          txtFieldType.Tag = id
          txtFieldType.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
        Private Sub txtFieldSize_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtFieldSize.Validating
        If txtFieldSize.Text <> "" Then
            try
            If Not IsNumeric(txtFieldSize.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtFieldSize.Text) < -2000000000 Or Val(txtFieldSize.Text) > 2000000000 Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
            Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtFieldSize_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFieldSize.TextChanged
  Changing

end sub
private sub txtCaption_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCaption.TextChanged
  Changing

end sub

Public Item As MTZRprt.MTZRprt.RPTFields
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,MTZRprt.MTZRprt.RPTFields)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

txtName.text = item.Name
If Not item.FieldType Is Nothing Then
  txtFieldType.Tag = item.FieldType.id
  txtFieldType.text = item.FieldType.brief
else
  txtFieldType.Tag = System.Guid.Empty 
  txtFieldType.text = "" 
End If
txtFieldSize.text = item.FieldSize.toString()
txtCaption.text = item.Caption
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
If not txtFieldType.Tag.Equals(System.Guid.Empty) Then
  item.FieldType = Item.Application.FindRowObject("FIELDTYPE",txtFieldType.Tag)
Else
   item.FieldType = Nothing
End If
item.FieldSize = val(txtFieldSize.text)
item.Caption = txtCaption.text
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK =( txtName.text <> "" ) 
if mIsOK then mIsOK = not txtFieldType.Tag.Equals(System.Guid.Empty)
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
