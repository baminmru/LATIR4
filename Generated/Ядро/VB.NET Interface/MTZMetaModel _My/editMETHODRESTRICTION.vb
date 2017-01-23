
Imports System.Windows.Forms
Imports Microsoft.VisualBasic



''' <summary>
'''Контрол редактирования раздела Ограничения методов режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editMETHODRESTRICTION
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
Friend WithEvents lblPart  as  System.Windows.Forms.Label
Friend WithEvents txtPart As System.Windows.Forms.TextBox
Friend WithEvents cmdPart As System.Windows.Forms.Button
Friend WithEvents cmdPartClear As System.Windows.Forms.Button
Friend WithEvents lblMethod  as  System.Windows.Forms.Label
Friend WithEvents txtMethod As System.Windows.Forms.TextBox
Friend WithEvents cmdMethod As System.Windows.Forms.Button
Friend WithEvents lblIsRestricted  as  System.Windows.Forms.Label
Friend WithEvents cmbIsRestricted As System.Windows.Forms.ComboBox
Friend cmbIsRestrictedDATA As DataTable
Friend cmbIsRestrictedDATAROW As DataRow

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
Me.lblPart = New System.Windows.Forms.Label
Me.txtPart = New System.Windows.Forms.TextBox
Me.cmdPart = New System.Windows.Forms.Button
Me.cmdPartClear = New System.Windows.Forms.Button
Me.lblMethod = New System.Windows.Forms.Label
Me.txtMethod = New System.Windows.Forms.TextBox
Me.cmdMethod = New System.Windows.Forms.Button
Me.lblIsRestricted = New System.Windows.Forms.Label
Me.cmbIsRestricted = New System.Windows.Forms.ComboBox

Me.lblPart.Location = New System.Drawing.Point(20,5)
Me.lblPart.name = "lblPart"
Me.lblPart.Size = New System.Drawing.Size(200, 20)
Me.lblPart.TabIndex = 1
Me.lblPart.Text = "Структура, которой принадлежит метод"
Me.lblPart.ForeColor = System.Drawing.Color.Blue
Me.txtPart.Location = New System.Drawing.Point(20,27)
Me.txtPart.name = "txtPart"
Me.txtPart.ReadOnly = True
Me.txtPart.Size = New System.Drawing.Size(155, 20)
Me.txtPart.TabIndex = 2
Me.txtPart.Text = "" 
Me.cmdPart.Location = New System.Drawing.Point(176,27)
Me.cmdPart.name = "cmdPart"
Me.cmdPart.Size = New System.Drawing.Size(22, 20)
Me.cmdPart.TabIndex = 3
Me.cmdPart.Text = "..." 
Me.cmdPartClear.Location = New System.Drawing.Point(198,27)
Me.cmdPartClear.name = "cmdPartClear"
Me.cmdPartClear.Size = New System.Drawing.Size(22, 20)
Me.cmdPartClear.TabIndex = 4
Me.cmdPartClear.Text = "X" 
Me.lblMethod.Location = New System.Drawing.Point(20,52)
Me.lblMethod.name = "lblMethod"
Me.lblMethod.Size = New System.Drawing.Size(200, 20)
Me.lblMethod.TabIndex = 5
Me.lblMethod.Text = "Метод"
Me.lblMethod.ForeColor = System.Drawing.Color.Black
Me.txtMethod.Location = New System.Drawing.Point(20,74)
Me.txtMethod.name = "txtMethod"
Me.txtMethod.ReadOnly = True
Me.txtMethod.Size = New System.Drawing.Size(176, 20)
Me.txtMethod.TabIndex = 6
Me.txtMethod.Text = "" 
Me.cmdMethod.Location = New System.Drawing.Point(198,74)
Me.cmdMethod.name = "cmdMethod"
Me.cmdMethod.Size = New System.Drawing.Size(22, 20)
Me.cmdMethod.TabIndex = 7
Me.cmdMethod.Text = "..." 
Me.lblIsRestricted.Location = New System.Drawing.Point(20,99)
Me.lblIsRestricted.name = "lblIsRestricted"
Me.lblIsRestricted.Size = New System.Drawing.Size(200, 20)
Me.lblIsRestricted.TabIndex = 8
Me.lblIsRestricted.Text = "Запрещено использовать"
Me.lblIsRestricted.ForeColor = System.Drawing.Color.Black
Me.cmbIsRestricted.Location = New System.Drawing.Point(20,121)
Me.cmbIsRestricted.name = "cmbIsRestricted"
Me.cmbIsRestricted.Size = New System.Drawing.Size(200,  20)
Me.cmbIsRestricted.TabIndex = 9
        Me.AutoScroll = True

 CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblPart)
 CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtPart)
 CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdPart)
 CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdPartClear)
 CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblMethod)
 CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtMethod)
 CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdMethod)
 CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblIsRestricted)
 CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbIsRestricted)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editMETHODRESTRICTION"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtPart_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPart.TextChanged
  Changing

end sub
private sub cmdPart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPart.Click
  on error resume next
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("PART","",System.guid.Empty, id, brief) Then
          txtPart.Tag = id
          txtPart.text = brief
        End If
end sub
private sub cmdPartClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPartClear.Click
  on error resume next
          txtPart.Tag = Guid.Empty
          txtPart.text = ""
end sub
private sub txtMethod_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMethod.TextChanged
  Changing

end sub
private sub cmdMethod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMethod.Click
  on error resume next
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("SHAREDMETHOD","",System.guid.Empty, id, brief) Then
          txtMethod.Tag = id
          txtMethod.text = brief
        End If
end sub
private sub cmbIsRestricted_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbIsRestricted.SelectedValueChanged
  on error resume next
  Changing

end sub

Public Item As MTZMetaModel.MTZMetaModel.METHODRESTRICTION
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,MTZMetaModel.MTZMetaModel.METHODRESTRICTION)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

If Not item.Part Is Nothing Then
  txtPart.Tag = item.Part.id
  txtPart.text = item.Part.brief
else
  txtPart.Tag = System.Guid.Empty 
  txtPart.text = "" 
End If
If Not item.Method Is Nothing Then
  txtMethod.Tag = item.Method.id
  txtMethod.text = item.Method.brief
else
  txtMethod.Tag = System.Guid.Empty 
  txtMethod.text = "" 
End If
cmbIsRestrictedData = New DataTable
cmbIsRestrictedData.Columns.Add("name", GetType(System.String))
cmbIsRestrictedData.Columns.Add("Value", GetType(System.Int32))
On Error Resume Next
cmbIsRestrictedDataRow = cmbIsRestrictedData.NewRow
cmbIsRestrictedDataRow("name") = "Да"
cmbIsRestrictedDataRow("Value") = -1
cmbIsRestrictedData.Rows.Add (cmbIsRestrictedDataRow)
cmbIsRestrictedDataRow = cmbIsRestrictedData.NewRow
cmbIsRestrictedDataRow("name") = "Нет"
cmbIsRestrictedDataRow("Value") = 0
cmbIsRestrictedData.Rows.Add (cmbIsRestrictedDataRow)
cmbIsRestricted.DisplayMember = "name"
cmbIsRestricted.ValueMember = "Value"
cmbIsRestricted.DataSource = cmbIsRestrictedData
 cmbIsRestricted.SelectedValue=CInt(Item.IsRestricted)
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

If not txtPart.Tag.Equals(System.Guid.Empty) Then
  item.Part = Item.Application.FindRowObject("PART",txtPart.Tag)
Else
   item.Part = Nothing
End If
If not txtMethod.Tag.Equals(System.Guid.Empty) Then
  item.Method = Item.Application.FindRowObject("SHAREDMETHOD",txtMethod.Tag)
Else
   item.Method = Nothing
End If
            Item.IsRestricted = cmbIsRestricted.SelectedValue
        End if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK = not txtMethod.Tag.Equals(System.Guid.Empty)
if mIsOK then mIsOK =(cmbIsRestricted.SelectedIndex >=0)
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
