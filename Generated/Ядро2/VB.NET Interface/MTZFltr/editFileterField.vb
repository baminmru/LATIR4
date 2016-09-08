
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Поле фильтра режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editFileterField
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
Friend WithEvents lblsequence  as  System.Windows.Forms.Label
Friend WithEvents txtsequence As System.Windows.Forms.TextBox
Friend WithEvents lblName  as  System.Windows.Forms.Label
Friend WithEvents txtName As System.Windows.Forms.TextBox
Friend WithEvents lblCaption  as  System.Windows.Forms.Label
Friend WithEvents txtCaption As System.Windows.Forms.TextBox
Friend WithEvents lblFieldType  as  System.Windows.Forms.Label
Friend WithEvents txtFieldType As System.Windows.Forms.TextBox
Friend WithEvents cmdFieldType As System.Windows.Forms.Button
Friend WithEvents lblFieldSize  as  System.Windows.Forms.Label
Friend WithEvents txtFieldSize As System.Windows.Forms.TextBox
Friend WithEvents lblRefType  as  System.Windows.Forms.Label
Friend WithEvents cmbRefType As System.Windows.Forms.ComboBox
Friend cmbRefTypeDATA As DataTable
Friend cmbRefTypeDATAROW As DataRow
Friend WithEvents lblRefToType  as  System.Windows.Forms.Label
Friend WithEvents txtRefToType As System.Windows.Forms.TextBox
Friend WithEvents cmdRefToType As System.Windows.Forms.Button
Friend WithEvents cmdRefToTypeClear As System.Windows.Forms.Button
Friend WithEvents lblRefToPart  as  System.Windows.Forms.Label
Friend WithEvents txtRefToPart As System.Windows.Forms.TextBox
Friend WithEvents cmdRefToPart As System.Windows.Forms.Button
Friend WithEvents cmdRefToPartClear As System.Windows.Forms.Button
Friend WithEvents lblValueArray  as  System.Windows.Forms.Label
Friend WithEvents cmbValueArray As System.Windows.Forms.ComboBox
Friend cmbValueArrayDATA As DataTable
Friend cmbValueArrayDATAROW As DataRow

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
Me.lblsequence = New System.Windows.Forms.Label
Me.txtsequence = New System.Windows.Forms.TextBox
Me.lblName = New System.Windows.Forms.Label
Me.txtName = New System.Windows.Forms.TextBox
Me.lblCaption = New System.Windows.Forms.Label
Me.txtCaption = New System.Windows.Forms.TextBox
Me.lblFieldType = New System.Windows.Forms.Label
Me.txtFieldType = New System.Windows.Forms.TextBox
Me.cmdFieldType = New System.Windows.Forms.Button
Me.lblFieldSize = New System.Windows.Forms.Label
Me.txtFieldSize = New System.Windows.Forms.TextBox
Me.lblRefType = New System.Windows.Forms.Label
Me.cmbRefType = New System.Windows.Forms.ComboBox
Me.lblRefToType = New System.Windows.Forms.Label
Me.txtRefToType = New System.Windows.Forms.TextBox
Me.cmdRefToType = New System.Windows.Forms.Button
Me.cmdRefToTypeClear = New System.Windows.Forms.Button
Me.lblRefToPart = New System.Windows.Forms.Label
Me.txtRefToPart = New System.Windows.Forms.TextBox
Me.cmdRefToPart = New System.Windows.Forms.Button
Me.cmdRefToPartClear = New System.Windows.Forms.Button
Me.lblValueArray = New System.Windows.Forms.Label
Me.cmbValueArray = New System.Windows.Forms.ComboBox

Me.lblsequence.Location = New System.Drawing.Point(20,5)
Me.lblsequence.name = "lblsequence"
Me.lblsequence.Size = New System.Drawing.Size(200, 20)
Me.lblsequence.TabIndex = 1
Me.lblsequence.Text = "Последовательность"
Me.lblsequence.ForeColor = System.Drawing.Color.Black
Me.txtsequence.Location = New System.Drawing.Point(20,27)
Me.txtsequence.name = "txtsequence"
Me.txtsequence.MultiLine = false
Me.txtsequence.Size = New System.Drawing.Size(200,  20)
Me.txtsequence.TabIndex = 2
Me.txtsequence.Text = "" 
Me.txtsequence.MaxLength = 15
Me.lblName.Location = New System.Drawing.Point(20,52)
Me.lblName.name = "lblName"
Me.lblName.Size = New System.Drawing.Size(200, 20)
Me.lblName.TabIndex = 3
Me.lblName.Text = "Название"
Me.lblName.ForeColor = System.Drawing.Color.Black
Me.txtName.Location = New System.Drawing.Point(20,74)
Me.txtName.name = "txtName"
Me.txtName.Size = New System.Drawing.Size(200, 20)
Me.txtName.TabIndex = 4
Me.txtName.Text = "" 
Me.lblCaption.Location = New System.Drawing.Point(20,99)
Me.lblCaption.name = "lblCaption"
Me.lblCaption.Size = New System.Drawing.Size(200, 20)
Me.lblCaption.TabIndex = 5
Me.lblCaption.Text = "Заголовок"
Me.lblCaption.ForeColor = System.Drawing.Color.Blue
Me.txtCaption.Location = New System.Drawing.Point(20,121)
Me.txtCaption.name = "txtCaption"
Me.txtCaption.Size = New System.Drawing.Size(200, 20)
Me.txtCaption.TabIndex = 6
Me.txtCaption.Text = "" 
Me.lblFieldType.Location = New System.Drawing.Point(20,146)
Me.lblFieldType.name = "lblFieldType"
Me.lblFieldType.Size = New System.Drawing.Size(200, 20)
Me.lblFieldType.TabIndex = 7
Me.lblFieldType.Text = "Тип поля"
Me.lblFieldType.ForeColor = System.Drawing.Color.Black
Me.txtFieldType.Location = New System.Drawing.Point(20,168)
Me.txtFieldType.name = "txtFieldType"
Me.txtFieldType.ReadOnly = True
Me.txtFieldType.Size = New System.Drawing.Size(176, 20)
Me.txtFieldType.TabIndex = 8
Me.txtFieldType.Text = "" 
Me.cmdFieldType.Location = New System.Drawing.Point(198,168)
Me.cmdFieldType.name = "cmdFieldType"
Me.cmdFieldType.Size = New System.Drawing.Size(22, 20)
Me.cmdFieldType.TabIndex = 9
Me.cmdFieldType.Text = "..." 
Me.lblFieldSize.Location = New System.Drawing.Point(20,193)
Me.lblFieldSize.name = "lblFieldSize"
Me.lblFieldSize.Size = New System.Drawing.Size(200, 20)
Me.lblFieldSize.TabIndex = 10
Me.lblFieldSize.Text = "Размер"
Me.lblFieldSize.ForeColor = System.Drawing.Color.Blue
Me.txtFieldSize.Location = New System.Drawing.Point(20,215)
Me.txtFieldSize.name = "txtFieldSize"
Me.txtFieldSize.MultiLine = false
Me.txtFieldSize.Size = New System.Drawing.Size(200,  20)
Me.txtFieldSize.TabIndex = 11
Me.txtFieldSize.Text = "" 
Me.txtFieldSize.MaxLength = 15
Me.lblRefType.Location = New System.Drawing.Point(20,240)
Me.lblRefType.name = "lblRefType"
Me.lblRefType.Size = New System.Drawing.Size(200, 20)
Me.lblRefType.TabIndex = 12
Me.lblRefType.Text = "Тип ссылки"
Me.lblRefType.ForeColor = System.Drawing.Color.Blue
Me.cmbRefType.Location = New System.Drawing.Point(20,262)
Me.cmbRefType.name = "cmbRefType"
Me.cmbRefType.Size = New System.Drawing.Size(200,  20)
Me.cmbRefType.TabIndex = 13
Me.cmbRefType.DropDownStyle = ComboBoxStyle.DropDownList
Me.lblRefToType.Location = New System.Drawing.Point(20,287)
Me.lblRefToType.name = "lblRefToType"
Me.lblRefToType.Size = New System.Drawing.Size(200, 20)
Me.lblRefToType.TabIndex = 14
Me.lblRefToType.Text = "Тип, куда ссылаемся"
Me.lblRefToType.ForeColor = System.Drawing.Color.Blue
Me.txtRefToType.Location = New System.Drawing.Point(20,309)
Me.txtRefToType.name = "txtRefToType"
Me.txtRefToType.ReadOnly = True
Me.txtRefToType.Size = New System.Drawing.Size(155, 20)
Me.txtRefToType.TabIndex = 15
Me.txtRefToType.Text = "" 
Me.cmdRefToType.Location = New System.Drawing.Point(176,309)
Me.cmdRefToType.name = "cmdRefToType"
Me.cmdRefToType.Size = New System.Drawing.Size(22, 20)
Me.cmdRefToType.TabIndex = 16
Me.cmdRefToType.Text = "..." 
Me.cmdRefToTypeClear.Location = New System.Drawing.Point(198,309)
Me.cmdRefToTypeClear.name = "cmdRefToTypeClear"
Me.cmdRefToTypeClear.Size = New System.Drawing.Size(22, 20)
Me.cmdRefToTypeClear.TabIndex = 17
Me.cmdRefToTypeClear.Text = "X" 
Me.lblRefToPart.Location = New System.Drawing.Point(20,334)
Me.lblRefToPart.name = "lblRefToPart"
Me.lblRefToPart.Size = New System.Drawing.Size(200, 20)
Me.lblRefToPart.TabIndex = 18
Me.lblRefToPart.Text = "Раздел, куда ссылаемся"
Me.lblRefToPart.ForeColor = System.Drawing.Color.Blue
Me.txtRefToPart.Location = New System.Drawing.Point(20,356)
Me.txtRefToPart.name = "txtRefToPart"
Me.txtRefToPart.ReadOnly = True
Me.txtRefToPart.Size = New System.Drawing.Size(155, 20)
Me.txtRefToPart.TabIndex = 19
Me.txtRefToPart.Text = "" 
Me.cmdRefToPart.Location = New System.Drawing.Point(176,356)
Me.cmdRefToPart.name = "cmdRefToPart"
Me.cmdRefToPart.Size = New System.Drawing.Size(22, 20)
Me.cmdRefToPart.TabIndex = 20
Me.cmdRefToPart.Text = "..." 
Me.cmdRefToPartClear.Location = New System.Drawing.Point(198,356)
Me.cmdRefToPartClear.name = "cmdRefToPartClear"
Me.cmdRefToPartClear.Size = New System.Drawing.Size(22, 20)
Me.cmdRefToPartClear.TabIndex = 21
Me.cmdRefToPartClear.Text = "X" 
Me.lblValueArray.Location = New System.Drawing.Point(20,381)
Me.lblValueArray.name = "lblValueArray"
Me.lblValueArray.Size = New System.Drawing.Size(200, 20)
Me.lblValueArray.TabIndex = 22
Me.lblValueArray.Text = "Массив значений"
Me.lblValueArray.ForeColor = System.Drawing.Color.Black
Me.cmbValueArray.Location = New System.Drawing.Point(20,403)
Me.cmbValueArray.name = "cmbValueArray"
Me.cmbValueArray.Size = New System.Drawing.Size(200,  20)
Me.cmbValueArray.TabIndex = 23
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblsequence)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtsequence)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblCaption)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtCaption)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblFieldType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtFieldType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdFieldType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblFieldSize)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtFieldSize)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblRefType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbRefType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblRefToType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtRefToType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdRefToType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdRefToTypeClear)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblRefToPart)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtRefToPart)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdRefToPart)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdRefToPartClear)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblValueArray)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbValueArray)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editFileterField"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

        Private Sub txtsequence_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtsequence.Validating
        If txtsequence.Text <> "" Then
            try
            If Not IsNumeric(txtsequence.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtsequence.Text) < -2000000000 Or Val(txtsequence.Text) > 2000000000 Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
            Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtsequence_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsequence.TextChanged
  Changing

end sub
private sub txtName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
  Changing

end sub
private sub txtCaption_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCaption.TextChanged
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
private sub cmbRefType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRefType.SelectedIndexChanged
  try
     Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtRefToType_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRefToType.TextChanged
  Changing

end sub
private sub cmdRefToType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefToType.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("OBJECTTYPE","",System.guid.Empty, id, brief) Then
          txtRefToType.Tag = id
          txtRefToType.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmdRefToTypeClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefToTypeClear.Click
  try
          txtRefToType.Tag = Guid.Empty
          txtRefToType.text = ""
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtRefToPart_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRefToPart.TextChanged
  Changing

end sub
private sub cmdRefToPart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefToPart.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("PART","",System.guid.Empty, id, brief) Then
          txtRefToPart.Tag = id
          txtRefToPart.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmdRefToPartClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefToPartClear.Click
  try
          txtRefToPart.Tag = Guid.Empty
          txtRefToPart.text = ""
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmbValueArray_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbValueArray.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub

Public Item As MTZFltr.MTZFltr.FileterField
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,MTZFltr.MTZFltr.FileterField)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

txtsequence.text = item.sequence.toString()
txtName.text = item.Name
txtCaption.text = item.Caption
If Not item.FieldType Is Nothing Then
  txtFieldType.Tag = item.FieldType.id
  txtFieldType.text = item.FieldType.brief
else
  txtFieldType.Tag = System.Guid.Empty 
  txtFieldType.text = "" 
End If
txtFieldSize.text = item.FieldSize.toString()
cmbRefTypeData = New DataTable
cmbRefTypeData.Columns.Add("name", GetType(System.String))
cmbRefTypeData.Columns.Add("Value", GetType(System.Int32))
try
cmbRefTypeDataRow = cmbRefTypeData.NewRow
cmbRefTypeDataRow("name") = "Скалярное поле ( не ссылка)"
cmbRefTypeDataRow("Value") = 0
cmbRefTypeData.Rows.Add (cmbRefTypeDataRow)
cmbRefTypeDataRow = cmbRefTypeData.NewRow
cmbRefTypeDataRow("name") = "На объект "
cmbRefTypeDataRow("Value") = 1
cmbRefTypeData.Rows.Add (cmbRefTypeDataRow)
cmbRefTypeDataRow = cmbRefTypeData.NewRow
cmbRefTypeDataRow("name") = "На строку раздела"
cmbRefTypeDataRow("Value") = 2
cmbRefTypeData.Rows.Add (cmbRefTypeDataRow)
cmbRefTypeDataRow = cmbRefTypeData.NewRow
cmbRefTypeDataRow("name") = "На источник данных"
cmbRefTypeDataRow("Value") = 3
cmbRefTypeData.Rows.Add (cmbRefTypeDataRow)
cmbRefType.DisplayMember = "name"
cmbRefType.ValueMember = "Value"
cmbRefType.DataSource = cmbRefTypeData
 cmbRefType.SelectedValue=CInt(Item.RefType)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
If Not item.RefToType Is Nothing Then
  txtRefToType.Tag = item.RefToType.id
  txtRefToType.text = item.RefToType.brief
else
  txtRefToType.Tag = System.Guid.Empty 
  txtRefToType.text = "" 
End If
If Not item.RefToPart Is Nothing Then
  txtRefToPart.Tag = item.RefToPart.id
  txtRefToPart.text = item.RefToPart.brief
else
  txtRefToPart.Tag = System.Guid.Empty 
  txtRefToPart.text = "" 
End If
cmbValueArrayData = New DataTable
cmbValueArrayData.Columns.Add("name", GetType(System.String))
cmbValueArrayData.Columns.Add("Value", GetType(System.Int32))
try
cmbValueArrayDataRow = cmbValueArrayData.NewRow
cmbValueArrayDataRow("name") = "Да"
cmbValueArrayDataRow("Value") = -1
cmbValueArrayData.Rows.Add (cmbValueArrayDataRow)
cmbValueArrayDataRow = cmbValueArrayData.NewRow
cmbValueArrayDataRow("name") = "Нет"
cmbValueArrayDataRow("Value") = 0
cmbValueArrayData.Rows.Add (cmbValueArrayDataRow)
cmbValueArray.DisplayMember = "name"
cmbValueArray.ValueMember = "Value"
cmbValueArray.DataSource = cmbValueArrayData
 cmbValueArray.SelectedValue=CInt(Item.ValueArray)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
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

item.sequence = val(txtsequence.text)
item.Name = txtName.text
item.Caption = txtCaption.text
If not txtFieldType.Tag.Equals(System.Guid.Empty) Then
  item.FieldType = Item.Application.FindRowObject("FIELDTYPE",txtFieldType.Tag)
Else
   item.FieldType = Nothing
End If
item.FieldSize = val(txtFieldSize.text)
   item.RefType = cmbRefType.SelectedValue
If not txtRefToType.Tag.Equals(System.Guid.Empty) Then
  item.RefToType = Item.Application.FindRowObject("OBJECTTYPE",txtRefToType.Tag)
Else
   item.RefToType = Nothing
End If
If not txtRefToPart.Tag.Equals(System.Guid.Empty) Then
  item.RefToPart = Item.Application.FindRowObject("PART",txtRefToPart.Tag)
Else
   item.RefToPart = Nothing
End If
   item.ValueArray = cmbValueArray.SelectedValue
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK =( txtsequence.text <> "" ) 
if mIsOK then mIsOK =( txtName.text <> "" ) 
if mIsOK then mIsOK = not txtFieldType.Tag.Equals(System.Guid.Empty)
if mIsOK then mIsOK =(cmbValueArray.SelectedIndex >=0)
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
