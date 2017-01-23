
Imports System.Windows.Forms
Imports Microsoft.VisualBasic



''' <summary>
'''Контрол редактирования раздела Ограничения полей режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editFIELDRESTRICTION
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
Friend WithEvents lblThePart  as  System.Windows.Forms.Label
Friend WithEvents txtThePart As System.Windows.Forms.TextBox
Friend WithEvents cmdThePart As System.Windows.Forms.Button
Friend WithEvents lblTheField  as  System.Windows.Forms.Label
Friend WithEvents txtTheField As System.Windows.Forms.TextBox
Friend WithEvents cmdTheField As System.Windows.Forms.Button
Friend WithEvents lblAllowRead  as  System.Windows.Forms.Label
Friend WithEvents cmbAllowRead As System.Windows.Forms.ComboBox
Friend cmbAllowReadDATA As DataTable
Friend cmbAllowReadDATAROW As DataRow
Friend WithEvents lblAllowModify  as  System.Windows.Forms.Label
Friend WithEvents cmbAllowModify As System.Windows.Forms.ComboBox
Friend cmbAllowModifyDATA As DataTable
Friend cmbAllowModifyDATAROW As DataRow
Friend WithEvents lblMandatoryField  as  System.Windows.Forms.Label
Friend WithEvents cmbMandatoryField As System.Windows.Forms.ComboBox
Friend cmbMandatoryFieldDATA As DataTable
Friend cmbMandatoryFieldDATAROW As DataRow

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
Me.lblThePart = New System.Windows.Forms.Label
Me.txtThePart = New System.Windows.Forms.TextBox
Me.cmdThePart = New System.Windows.Forms.Button
Me.lblTheField = New System.Windows.Forms.Label
Me.txtTheField = New System.Windows.Forms.TextBox
Me.cmdTheField = New System.Windows.Forms.Button
Me.lblAllowRead = New System.Windows.Forms.Label
Me.cmbAllowRead = New System.Windows.Forms.ComboBox
Me.lblAllowModify = New System.Windows.Forms.Label
Me.cmbAllowModify = New System.Windows.Forms.ComboBox
Me.lblMandatoryField = New System.Windows.Forms.Label
Me.cmbMandatoryField = New System.Windows.Forms.ComboBox

Me.lblThePart.Location = New System.Drawing.Point(20,5)
Me.lblThePart.name = "lblThePart"
Me.lblThePart.Size = New System.Drawing.Size(200, 20)
Me.lblThePart.TabIndex = 1
Me.lblThePart.Text = "Структура, которой принадлежит поле"
Me.lblThePart.ForeColor = System.Drawing.Color.Black
Me.txtThePart.Location = New System.Drawing.Point(20,27)
Me.txtThePart.name = "txtThePart"
Me.txtThePart.ReadOnly = True
Me.txtThePart.Size = New System.Drawing.Size(176, 20)
Me.txtThePart.TabIndex = 2
Me.txtThePart.Text = "" 
Me.cmdThePart.Location = New System.Drawing.Point(198,27)
Me.cmdThePart.name = "cmdThePart"
Me.cmdThePart.Size = New System.Drawing.Size(22, 20)
Me.cmdThePart.TabIndex = 3
Me.cmdThePart.Text = "..." 
Me.lblTheField.Location = New System.Drawing.Point(20,52)
Me.lblTheField.name = "lblTheField"
Me.lblTheField.Size = New System.Drawing.Size(200, 20)
Me.lblTheField.TabIndex = 4
Me.lblTheField.Text = "Поле, на которое накладывается ограничение"
Me.lblTheField.ForeColor = System.Drawing.Color.Black
Me.txtTheField.Location = New System.Drawing.Point(20,74)
Me.txtTheField.name = "txtTheField"
Me.txtTheField.ReadOnly = True
Me.txtTheField.Size = New System.Drawing.Size(176, 20)
Me.txtTheField.TabIndex = 5
Me.txtTheField.Text = "" 
Me.cmdTheField.Location = New System.Drawing.Point(198,74)
Me.cmdTheField.name = "cmdTheField"
Me.cmdTheField.Size = New System.Drawing.Size(22, 20)
Me.cmdTheField.TabIndex = 6
Me.cmdTheField.Text = "..." 
Me.lblAllowRead.Location = New System.Drawing.Point(20,99)
Me.lblAllowRead.name = "lblAllowRead"
Me.lblAllowRead.Size = New System.Drawing.Size(200, 20)
Me.lblAllowRead.TabIndex = 7
Me.lblAllowRead.Text = "Разрешен просмотр"
Me.lblAllowRead.ForeColor = System.Drawing.Color.Black
Me.cmbAllowRead.Location = New System.Drawing.Point(20,121)
Me.cmbAllowRead.name = "cmbAllowRead"
Me.cmbAllowRead.Size = New System.Drawing.Size(200,  20)
Me.cmbAllowRead.TabIndex = 8
Me.lblAllowModify.Location = New System.Drawing.Point(20,146)
Me.lblAllowModify.name = "lblAllowModify"
Me.lblAllowModify.Size = New System.Drawing.Size(200, 20)
Me.lblAllowModify.TabIndex = 9
Me.lblAllowModify.Text = "Разрешена модификация"
Me.lblAllowModify.ForeColor = System.Drawing.Color.Black
Me.cmbAllowModify.Location = New System.Drawing.Point(20,168)
Me.cmbAllowModify.name = "cmbAllowModify"
Me.cmbAllowModify.Size = New System.Drawing.Size(200,  20)
Me.cmbAllowModify.TabIndex = 10
Me.lblMandatoryField.Location = New System.Drawing.Point(20,193)
Me.lblMandatoryField.name = "lblMandatoryField"
Me.lblMandatoryField.Size = New System.Drawing.Size(200, 20)
Me.lblMandatoryField.TabIndex = 11
Me.lblMandatoryField.Text = "Обязательное поле"
Me.lblMandatoryField.ForeColor = System.Drawing.Color.Blue
Me.cmbMandatoryField.Location = New System.Drawing.Point(20,215)
Me.cmbMandatoryField.name = "cmbMandatoryField"
Me.cmbMandatoryField.Size = New System.Drawing.Size(200,  20)
Me.cmbMandatoryField.TabIndex = 12
Me.cmbMandatoryField.DropDownStyle = ComboBoxStyle.DropDownList
        Me.AutoScroll = True

 CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblThePart)
 CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtThePart)
 CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdThePart)
 CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTheField)
 CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTheField)
 CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdTheField)
 CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblAllowRead)
 CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbAllowRead)
 CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblAllowModify)
 CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbAllowModify)
 CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblMandatoryField)
 CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbMandatoryField)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editFIELDRESTRICTION"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtThePart_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtThePart.TextChanged
  Changing

end sub
private sub cmdThePart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThePart.Click
  on error resume next
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("PART","",System.guid.Empty, id, brief) Then
          txtThePart.Tag = id
          txtThePart.text = brief
        End If
end sub
private sub txtTheField_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTheField.TextChanged
  Changing

end sub
private sub cmdTheField_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTheField.Click
  on error resume next
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("FIELD","",System.guid.Empty, id, brief) Then
          txtTheField.Tag = id
          txtTheField.text = brief
        End If
end sub
private sub cmbAllowRead_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAllowRead.SelectedValueChanged
  on error resume next
  Changing

end sub
private sub cmbAllowModify_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAllowModify.SelectedValueChanged
  on error resume next
  Changing

end sub
private sub cmbMandatoryField_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMandatoryField.SelectedValueChanged
  on error resume next
  Changing

end sub

Public Item As MTZMetaModel.MTZMetaModel.FIELDRESTRICTION
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,MTZMetaModel.MTZMetaModel.FIELDRESTRICTION)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

If Not item.ThePart Is Nothing Then
  txtThePart.Tag = item.ThePart.id
  txtThePart.text = item.ThePart.brief
else
  txtThePart.Tag = System.Guid.Empty 
  txtThePart.text = "" 
End If
If Not item.TheField Is Nothing Then
  txtTheField.Tag = item.TheField.id
  txtTheField.text = item.TheField.brief
else
  txtTheField.Tag = System.Guid.Empty 
  txtTheField.text = "" 
End If
cmbAllowReadData = New DataTable
cmbAllowReadData.Columns.Add("name", GetType(System.String))
cmbAllowReadData.Columns.Add("Value", GetType(System.Int32))
On Error Resume Next
cmbAllowReadDataRow = cmbAllowReadData.NewRow
cmbAllowReadDataRow("name") = "Да"
cmbAllowReadDataRow("Value") = -1
cmbAllowReadData.Rows.Add (cmbAllowReadDataRow)
cmbAllowReadDataRow = cmbAllowReadData.NewRow
cmbAllowReadDataRow("name") = "Нет"
cmbAllowReadDataRow("Value") = 0
cmbAllowReadData.Rows.Add (cmbAllowReadDataRow)
cmbAllowRead.DisplayMember = "name"
cmbAllowRead.ValueMember = "Value"
cmbAllowRead.DataSource = cmbAllowReadData
 cmbAllowRead.SelectedValue=CInt(Item.AllowRead)
cmbAllowModifyData = New DataTable
cmbAllowModifyData.Columns.Add("name", GetType(System.String))
cmbAllowModifyData.Columns.Add("Value", GetType(System.Int32))
On Error Resume Next
cmbAllowModifyDataRow = cmbAllowModifyData.NewRow
cmbAllowModifyDataRow("name") = "Да"
cmbAllowModifyDataRow("Value") = -1
cmbAllowModifyData.Rows.Add (cmbAllowModifyDataRow)
cmbAllowModifyDataRow = cmbAllowModifyData.NewRow
cmbAllowModifyDataRow("name") = "Нет"
cmbAllowModifyDataRow("Value") = 0
cmbAllowModifyData.Rows.Add (cmbAllowModifyDataRow)
cmbAllowModify.DisplayMember = "name"
cmbAllowModify.ValueMember = "Value"
cmbAllowModify.DataSource = cmbAllowModifyData
 cmbAllowModify.SelectedValue=CInt(Item.AllowModify)
cmbMandatoryFieldData = New DataTable
cmbMandatoryFieldData.Columns.Add("name", GetType(System.String))
cmbMandatoryFieldData.Columns.Add("Value", GetType(System.Int32))
On Error Resume Next
cmbMandatoryFieldDataRow = cmbMandatoryFieldData.NewRow
cmbMandatoryFieldDataRow("name") = "Не существенно"
cmbMandatoryFieldDataRow("Value") = -1
cmbMandatoryFieldData.Rows.Add (cmbMandatoryFieldDataRow)
cmbMandatoryFieldDataRow = cmbMandatoryFieldData.NewRow
cmbMandatoryFieldDataRow("name") = "Нет"
cmbMandatoryFieldDataRow("Value") = 0
cmbMandatoryFieldData.Rows.Add (cmbMandatoryFieldDataRow)
cmbMandatoryFieldDataRow = cmbMandatoryFieldData.NewRow
cmbMandatoryFieldDataRow("name") = "Да"
cmbMandatoryFieldDataRow("Value") = 1
cmbMandatoryFieldData.Rows.Add (cmbMandatoryFieldDataRow)
cmbMandatoryField.DisplayMember = "name"
cmbMandatoryField.ValueMember = "Value"
cmbMandatoryField.DataSource = cmbMandatoryFieldData
 cmbMandatoryField.SelectedValue=CInt(Item.MandatoryField)
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

If not txtThePart.Tag.Equals(System.Guid.Empty) Then
  item.ThePart = Item.Application.FindRowObject("PART",txtThePart.Tag)
Else
   item.ThePart = Nothing
End If
If not txtTheField.Tag.Equals(System.Guid.Empty) Then
  item.TheField = Item.Application.FindRowObject("FIELD",txtTheField.Tag)
Else
   item.TheField = Nothing
End If
            Item.AllowRead = cmbAllowRead.SelectedValue
            Item.AllowModify = cmbAllowModify.SelectedValue
            Item.MandatoryField = cmbMandatoryField.SelectedValue
        End if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK = not txtThePart.Tag.Equals(System.Guid.Empty)
if mIsOK then mIsOK = not txtTheField.Tag.Equals(System.Guid.Empty)
if mIsOK then mIsOK =(cmbAllowRead.SelectedIndex >=0)
if mIsOK then mIsOK =(cmbAllowModify.SelectedIndex >=0)
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
