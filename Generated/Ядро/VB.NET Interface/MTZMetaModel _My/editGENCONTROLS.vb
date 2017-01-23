
Imports System.Windows.Forms
Imports Microsoft.VisualBasic



''' <summary>
'''Контрол редактирования раздела Контрольные элементы режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editGENCONTROLS
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
Friend WithEvents lblControlProgID  as  System.Windows.Forms.Label
Friend WithEvents txtControlProgID As System.Windows.Forms.TextBox
Friend WithEvents lblControlClassID  as  System.Windows.Forms.Label
Friend WithEvents txtControlClassID As System.Windows.Forms.TextBox
Friend WithEvents lblVersionMajor  as  System.Windows.Forms.Label
Friend WithEvents txtVersionMajor As System.Windows.Forms.TextBox
Friend WithEvents lblVersionMinor  as  System.Windows.Forms.Label
Friend WithEvents txtVersionMinor As System.Windows.Forms.TextBox

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
Me.lblControlProgID = New System.Windows.Forms.Label
Me.txtControlProgID = New System.Windows.Forms.TextBox
Me.lblControlClassID = New System.Windows.Forms.Label
Me.txtControlClassID = New System.Windows.Forms.TextBox
Me.lblVersionMajor = New System.Windows.Forms.Label
Me.txtVersionMajor = New System.Windows.Forms.TextBox
Me.lblVersionMinor = New System.Windows.Forms.Label
Me.txtVersionMinor = New System.Windows.Forms.TextBox

Me.lblControlProgID.Location = New System.Drawing.Point(20,5)
Me.lblControlProgID.name = "lblControlProgID"
Me.lblControlProgID.Size = New System.Drawing.Size(200, 20)
Me.lblControlProgID.TabIndex = 1
Me.lblControlProgID.Text = "ProgID контрольконо элемента"
Me.lblControlProgID.ForeColor = System.Drawing.Color.Black
Me.txtControlProgID.Location = New System.Drawing.Point(20,27)
Me.txtControlProgID.name = "txtControlProgID"
Me.txtControlProgID.Size = New System.Drawing.Size(200, 20)
Me.txtControlProgID.TabIndex = 2
Me.txtControlProgID.Text = "" 
Me.lblControlClassID.Location = New System.Drawing.Point(20,52)
Me.lblControlClassID.name = "lblControlClassID"
Me.lblControlClassID.Size = New System.Drawing.Size(200, 20)
Me.lblControlClassID.TabIndex = 3
Me.lblControlClassID.Text = "Класс контрольногоэлемента"
Me.lblControlClassID.ForeColor = System.Drawing.Color.Blue
Me.txtControlClassID.Location = New System.Drawing.Point(20,74)
Me.txtControlClassID.name = "txtControlClassID"
Me.txtControlClassID.Size = New System.Drawing.Size(200, 20)
Me.txtControlClassID.TabIndex = 4
Me.txtControlClassID.Text = "" 
Me.lblVersionMajor.Location = New System.Drawing.Point(20,99)
Me.lblVersionMajor.name = "lblVersionMajor"
Me.lblVersionMajor.Size = New System.Drawing.Size(200, 20)
Me.lblVersionMajor.TabIndex = 5
Me.lblVersionMajor.Text = "Версия"
Me.lblVersionMajor.ForeColor = System.Drawing.Color.Blue
Me.txtVersionMajor.Location = New System.Drawing.Point(20,121)
Me.txtVersionMajor.name = "txtVersionMajor"
Me.txtVersionMajor.MultiLine = false
Me.txtVersionMajor.Size = New System.Drawing.Size(200,  20)
Me.txtVersionMajor.TabIndex = 6
Me.txtVersionMajor.Text = "" 
Me.txtVersionMajor.MaxLength = 15
Me.lblVersionMinor.Location = New System.Drawing.Point(20,146)
Me.lblVersionMinor.name = "lblVersionMinor"
Me.lblVersionMinor.Size = New System.Drawing.Size(200, 20)
Me.lblVersionMinor.TabIndex = 7
Me.lblVersionMinor.Text = "Подверсия"
Me.lblVersionMinor.ForeColor = System.Drawing.Color.Blue
Me.txtVersionMinor.Location = New System.Drawing.Point(20,168)
Me.txtVersionMinor.name = "txtVersionMinor"
Me.txtVersionMinor.MultiLine = false
Me.txtVersionMinor.Size = New System.Drawing.Size(200,  20)
Me.txtVersionMinor.TabIndex = 8
Me.txtVersionMinor.Text = "" 
Me.txtVersionMinor.MaxLength = 15
        Me.AutoScroll = True

 CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblControlProgID)
 CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtControlProgID)
 CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblControlClassID)
 CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtControlClassID)
 CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblVersionMajor)
 CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtVersionMajor)
 CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblVersionMinor)
 CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtVersionMinor)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editGENCONTROLS"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtControlProgID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtControlProgID.TextChanged
  Changing

end sub
private sub txtControlClassID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtControlClassID.TextChanged
  Changing

end sub
        Private Sub txtVersionMajor_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtVersionMajor.Validating
        If txtVersionMajor.Text <> "" Then
            On Error Resume Next
            If Not IsNumeric(txtVersionMajor.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtVersionMajor.Text) < -2000000000 Or Val(txtVersionMajor.Text) > 2000000000 Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        End If
    End Sub
private sub txtVersionMajor_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVersionMajor.TextChanged
  Changing

end sub
        Private Sub txtVersionMinor_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtVersionMinor.Validating
        If txtVersionMinor.Text <> "" Then
            On Error Resume Next
            If Not IsNumeric(txtVersionMinor.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtVersionMinor.Text) < -2000000000 Or Val(txtVersionMinor.Text) > 2000000000 Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        End If
    End Sub
private sub txtVersionMinor_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVersionMinor.TextChanged
  Changing

end sub

Public Item As MTZMetaModel.MTZMetaModel.GENCONTROLS
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,MTZMetaModel.MTZMetaModel.GENCONTROLS)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

txtControlProgID.text = item.ControlProgID
txtControlClassID.text = item.ControlClassID
txtVersionMajor.text = item.VersionMajor.toString()
txtVersionMinor.text = item.VersionMinor.toString()
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

item.ControlProgID = txtControlProgID.text
item.ControlClassID = txtControlClassID.text
item.VersionMajor = val(txtVersionMajor.text)
item.VersionMinor = val(txtVersionMinor.text)
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK =( txtControlProgID.text <> "" ) 
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
