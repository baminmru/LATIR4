
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Параметры режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editPARAMETERS
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
Friend WithEvents txtsequence As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblName  as  System.Windows.Forms.Label
Friend WithEvents txtName As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblCaption  as  System.Windows.Forms.Label
Friend WithEvents txtCaption As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblTypeOfParm  as  System.Windows.Forms.Label
Friend WithEvents txtTypeOfParm As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdTypeOfParm As System.Windows.Forms.Button
Friend WithEvents lblDataSize  as  System.Windows.Forms.Label
Friend WithEvents txtDataSize As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblAllowNull  as  System.Windows.Forms.Label
Friend WithEvents cmbAllowNull As System.Windows.Forms.ComboBox
Friend cmbAllowNullDATA As DataTable
Friend cmbAllowNullDATAROW As DataRow
Friend WithEvents lblOutParam  as  System.Windows.Forms.Label
Friend WithEvents cmbOutParam As System.Windows.Forms.ComboBox
Friend cmbOutParamDATA As DataTable
Friend cmbOutParamDATAROW As DataRow
Friend WithEvents lblReferenceType  as  System.Windows.Forms.Label
Friend WithEvents cmbReferenceType As System.Windows.Forms.ComboBox
Friend cmbReferenceTypeDATA As DataTable
Friend cmbReferenceTypeDATAROW As DataRow
Friend WithEvents lblRefToType  as  System.Windows.Forms.Label
Friend WithEvents txtRefToType As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdRefToType As System.Windows.Forms.Button
Friend WithEvents cmdRefToTypeClear As System.Windows.Forms.Button
Friend WithEvents lblRefToPart  as  System.Windows.Forms.Label
Friend WithEvents txtRefToPart As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdRefToPart As System.Windows.Forms.Button
Friend WithEvents cmdRefToPartClear As System.Windows.Forms.Button

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
Me.txtsequence = New LATIR2GuiManager.TouchTextBox
Me.lblName = New System.Windows.Forms.Label
Me.txtName = New LATIR2GuiManager.TouchTextBox
Me.lblCaption = New System.Windows.Forms.Label
Me.txtCaption = New LATIR2GuiManager.TouchTextBox
Me.lblTypeOfParm = New System.Windows.Forms.Label
Me.txtTypeOfParm = New LATIR2GuiManager.TouchTextBox
Me.cmdTypeOfParm = New System.Windows.Forms.Button
Me.lblDataSize = New System.Windows.Forms.Label
Me.txtDataSize = New LATIR2GuiManager.TouchTextBox
Me.lblAllowNull = New System.Windows.Forms.Label
Me.cmbAllowNull = New System.Windows.Forms.ComboBox
Me.lblOutParam = New System.Windows.Forms.Label
Me.cmbOutParam = New System.Windows.Forms.ComboBox
Me.lblReferenceType = New System.Windows.Forms.Label
Me.cmbReferenceType = New System.Windows.Forms.ComboBox
Me.lblRefToType = New System.Windows.Forms.Label
Me.txtRefToType = New LATIR2GuiManager.TouchTextBox
Me.cmdRefToType = New System.Windows.Forms.Button
Me.cmdRefToTypeClear = New System.Windows.Forms.Button
Me.lblRefToPart = New System.Windows.Forms.Label
Me.txtRefToPart = New LATIR2GuiManager.TouchTextBox
Me.cmdRefToPart = New System.Windows.Forms.Button
Me.cmdRefToPartClear = New System.Windows.Forms.Button

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
Me.lblName.Text = "Имя"
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
Me.lblCaption.ForeColor = System.Drawing.Color.Black
Me.txtCaption.Location = New System.Drawing.Point(20,121)
Me.txtCaption.name = "txtCaption"
Me.txtCaption.Size = New System.Drawing.Size(200, 20)
Me.txtCaption.TabIndex = 6
Me.txtCaption.Text = "" 
Me.lblTypeOfParm.Location = New System.Drawing.Point(20,146)
Me.lblTypeOfParm.name = "lblTypeOfParm"
Me.lblTypeOfParm.Size = New System.Drawing.Size(200, 20)
Me.lblTypeOfParm.TabIndex = 7
Me.lblTypeOfParm.Text = "Тип данных"
Me.lblTypeOfParm.ForeColor = System.Drawing.Color.Black
Me.txtTypeOfParm.Location = New System.Drawing.Point(20,168)
Me.txtTypeOfParm.name = "txtTypeOfParm"
Me.txtTypeOfParm.ReadOnly = True
Me.txtTypeOfParm.Size = New System.Drawing.Size(176, 20)
Me.txtTypeOfParm.TabIndex = 8
Me.txtTypeOfParm.Text = "" 
Me.cmdTypeOfParm.Location = New System.Drawing.Point(198,168)
Me.cmdTypeOfParm.name = "cmdTypeOfParm"
Me.cmdTypeOfParm.Size = New System.Drawing.Size(22, 20)
Me.cmdTypeOfParm.TabIndex = 9
Me.cmdTypeOfParm.Text = "..." 
Me.lblDataSize.Location = New System.Drawing.Point(20,193)
Me.lblDataSize.name = "lblDataSize"
Me.lblDataSize.Size = New System.Drawing.Size(200, 20)
Me.lblDataSize.TabIndex = 10
Me.lblDataSize.Text = "Размер"
Me.lblDataSize.ForeColor = System.Drawing.Color.Blue
Me.txtDataSize.Location = New System.Drawing.Point(20,215)
Me.txtDataSize.name = "txtDataSize"
Me.txtDataSize.MultiLine = false
Me.txtDataSize.Size = New System.Drawing.Size(200,  20)
Me.txtDataSize.TabIndex = 11
Me.txtDataSize.Text = "" 
Me.txtDataSize.MaxLength = 15
Me.lblAllowNull.Location = New System.Drawing.Point(20,240)
Me.lblAllowNull.name = "lblAllowNull"
Me.lblAllowNull.Size = New System.Drawing.Size(200, 20)
Me.lblAllowNull.TabIndex = 12
Me.lblAllowNull.Text = "Можно не задавать"
Me.lblAllowNull.ForeColor = System.Drawing.Color.Black
Me.cmbAllowNull.Location = New System.Drawing.Point(20,262)
Me.cmbAllowNull.name = "cmbAllowNull"
Me.cmbAllowNull.Size = New System.Drawing.Size(200,  20)
Me.cmbAllowNull.TabIndex = 13
Me.lblOutParam.Location = New System.Drawing.Point(20,287)
Me.lblOutParam.name = "lblOutParam"
Me.lblOutParam.Size = New System.Drawing.Size(200, 20)
Me.lblOutParam.TabIndex = 14
Me.lblOutParam.Text = "Возвращает значение"
Me.lblOutParam.ForeColor = System.Drawing.Color.Black
Me.cmbOutParam.Location = New System.Drawing.Point(20,309)
Me.cmbOutParam.name = "cmbOutParam"
Me.cmbOutParam.Size = New System.Drawing.Size(200,  20)
Me.cmbOutParam.TabIndex = 15
Me.lblReferenceType.Location = New System.Drawing.Point(20,334)
Me.lblReferenceType.name = "lblReferenceType"
Me.lblReferenceType.Size = New System.Drawing.Size(200, 20)
Me.lblReferenceType.TabIndex = 16
Me.lblReferenceType.Text = "Тип ссылки"
Me.lblReferenceType.ForeColor = System.Drawing.Color.Black
Me.cmbReferenceType.Location = New System.Drawing.Point(20,356)
Me.cmbReferenceType.name = "cmbReferenceType"
Me.cmbReferenceType.Size = New System.Drawing.Size(200,  20)
Me.cmbReferenceType.TabIndex = 17
Me.cmbReferenceType.DropDownStyle = ComboBoxStyle.DropDownList
Me.lblRefToType.Location = New System.Drawing.Point(20,381)
Me.lblRefToType.name = "lblRefToType"
Me.lblRefToType.Size = New System.Drawing.Size(200, 20)
Me.lblRefToType.TabIndex = 18
Me.lblRefToType.Text = "Ссылка на тип"
Me.lblRefToType.ForeColor = System.Drawing.Color.Blue
Me.txtRefToType.Location = New System.Drawing.Point(20,403)
Me.txtRefToType.name = "txtRefToType"
Me.txtRefToType.ReadOnly = True
Me.txtRefToType.Size = New System.Drawing.Size(155, 20)
Me.txtRefToType.TabIndex = 19
Me.txtRefToType.Text = "" 
Me.cmdRefToType.Location = New System.Drawing.Point(176,403)
Me.cmdRefToType.name = "cmdRefToType"
Me.cmdRefToType.Size = New System.Drawing.Size(22, 20)
Me.cmdRefToType.TabIndex = 20
Me.cmdRefToType.Text = "..." 
Me.cmdRefToTypeClear.Location = New System.Drawing.Point(198,403)
Me.cmdRefToTypeClear.name = "cmdRefToTypeClear"
Me.cmdRefToTypeClear.Size = New System.Drawing.Size(22, 20)
Me.cmdRefToTypeClear.TabIndex = 21
Me.cmdRefToTypeClear.Text = "X" 
Me.lblRefToPart.Location = New System.Drawing.Point(230,5)
Me.lblRefToPart.name = "lblRefToPart"
Me.lblRefToPart.Size = New System.Drawing.Size(200, 20)
Me.lblRefToPart.TabIndex = 22
Me.lblRefToPart.Text = "Ссылка на раздел"
Me.lblRefToPart.ForeColor = System.Drawing.Color.Blue
Me.txtRefToPart.Location = New System.Drawing.Point(230,27)
Me.txtRefToPart.name = "txtRefToPart"
Me.txtRefToPart.ReadOnly = True
Me.txtRefToPart.Size = New System.Drawing.Size(155, 20)
Me.txtRefToPart.TabIndex = 23
Me.txtRefToPart.Text = "" 
Me.cmdRefToPart.Location = New System.Drawing.Point(386,27)
Me.cmdRefToPart.name = "cmdRefToPart"
Me.cmdRefToPart.Size = New System.Drawing.Size(22, 20)
Me.cmdRefToPart.TabIndex = 24
Me.cmdRefToPart.Text = "..." 
Me.cmdRefToPartClear.Location = New System.Drawing.Point(408,27)
Me.cmdRefToPartClear.name = "cmdRefToPartClear"
Me.cmdRefToPartClear.Size = New System.Drawing.Size(22, 20)
Me.cmdRefToPartClear.TabIndex = 25
Me.cmdRefToPartClear.Text = "X" 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblsequence)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtsequence)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblCaption)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtCaption)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTypeOfParm)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTypeOfParm)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdTypeOfParm)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblDataSize)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtDataSize)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblAllowNull)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbAllowNull)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblOutParam)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbOutParam)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblReferenceType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbReferenceType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblRefToType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtRefToType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdRefToType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdRefToTypeClear)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblRefToPart)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtRefToPart)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdRefToPart)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdRefToPartClear)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editPARAMETERS"
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
private sub txtTypeOfParm_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTypeOfParm.TextChanged
  Changing

end sub
private sub cmdTypeOfParm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTypeOfParm.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("FIELDTYPE","",System.guid.Empty, id, brief) Then
          txtTypeOfParm.Tag = id
          txtTypeOfParm.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
        Private Sub txtDataSize_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDataSize.Validating
        If txtDataSize.Text <> "" Then
            try
            If Not IsNumeric(txtDataSize.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtDataSize.Text) < -2000000000 Or Val(txtDataSize.Text) > 2000000000 Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
            Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtDataSize_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDataSize.TextChanged
  Changing

end sub
private sub cmbAllowNull_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAllowNull.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmbOutParam_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOutParam.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmbReferenceType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbReferenceType.SelectedIndexChanged
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

Public Item As MTZMetaModel.MTZMetaModel.PARAMETERS
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,MTZMetaModel.MTZMetaModel.PARAMETERS)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

txtsequence.text = item.sequence.toString()
txtName.text = item.Name
txtCaption.text = item.Caption
If Not item.TypeOfParm Is Nothing Then
  txtTypeOfParm.Tag = item.TypeOfParm.id
  txtTypeOfParm.text = item.TypeOfParm.brief
else
  txtTypeOfParm.Tag = System.Guid.Empty 
  txtTypeOfParm.text = "" 
End If
txtDataSize.text = item.DataSize.toString()
cmbAllowNullData = New DataTable
cmbAllowNullData.Columns.Add("name", GetType(System.String))
cmbAllowNullData.Columns.Add("Value", GetType(System.Int32))
try
cmbAllowNullDataRow = cmbAllowNullData.NewRow
cmbAllowNullDataRow("name") = "Да"
cmbAllowNullDataRow("Value") = -1
cmbAllowNullData.Rows.Add (cmbAllowNullDataRow)
cmbAllowNullDataRow = cmbAllowNullData.NewRow
cmbAllowNullDataRow("name") = "Нет"
cmbAllowNullDataRow("Value") = 0
cmbAllowNullData.Rows.Add (cmbAllowNullDataRow)
cmbAllowNull.DisplayMember = "name"
cmbAllowNull.ValueMember = "Value"
cmbAllowNull.DataSource = cmbAllowNullData
 cmbAllowNull.SelectedValue=CInt(Item.AllowNull)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
cmbOutParamData = New DataTable
cmbOutParamData.Columns.Add("name", GetType(System.String))
cmbOutParamData.Columns.Add("Value", GetType(System.Int32))
try
cmbOutParamDataRow = cmbOutParamData.NewRow
cmbOutParamDataRow("name") = "Да"
cmbOutParamDataRow("Value") = -1
cmbOutParamData.Rows.Add (cmbOutParamDataRow)
cmbOutParamDataRow = cmbOutParamData.NewRow
cmbOutParamDataRow("name") = "Нет"
cmbOutParamDataRow("Value") = 0
cmbOutParamData.Rows.Add (cmbOutParamDataRow)
cmbOutParam.DisplayMember = "name"
cmbOutParam.ValueMember = "Value"
cmbOutParam.DataSource = cmbOutParamData
 cmbOutParam.SelectedValue=CInt(Item.OutParam)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
cmbReferenceTypeData = New DataTable
cmbReferenceTypeData.Columns.Add("name", GetType(System.String))
cmbReferenceTypeData.Columns.Add("Value", GetType(System.Int32))
try
cmbReferenceTypeDataRow = cmbReferenceTypeData.NewRow
cmbReferenceTypeDataRow("name") = "Скалярное поле ( не ссылка)"
cmbReferenceTypeDataRow("Value") = 0
cmbReferenceTypeData.Rows.Add (cmbReferenceTypeDataRow)
cmbReferenceTypeDataRow = cmbReferenceTypeData.NewRow
cmbReferenceTypeDataRow("name") = "На объект "
cmbReferenceTypeDataRow("Value") = 1
cmbReferenceTypeData.Rows.Add (cmbReferenceTypeDataRow)
cmbReferenceTypeDataRow = cmbReferenceTypeData.NewRow
cmbReferenceTypeDataRow("name") = "На строку раздела"
cmbReferenceTypeDataRow("Value") = 2
cmbReferenceTypeData.Rows.Add (cmbReferenceTypeDataRow)
cmbReferenceTypeDataRow = cmbReferenceTypeData.NewRow
cmbReferenceTypeDataRow("name") = "На источник данных"
cmbReferenceTypeDataRow("Value") = 3
cmbReferenceTypeData.Rows.Add (cmbReferenceTypeDataRow)
cmbReferenceType.DisplayMember = "name"
cmbReferenceType.ValueMember = "Value"
cmbReferenceType.DataSource = cmbReferenceTypeData
 cmbReferenceType.SelectedValue=CInt(Item.ReferenceType)
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
If not txtTypeOfParm.Tag.Equals(System.Guid.Empty) Then
  item.TypeOfParm = Item.Application.FindRowObject("FIELDTYPE",txtTypeOfParm.Tag)
Else
   item.TypeOfParm = Nothing
End If
item.DataSize = val(txtDataSize.text)
   item.AllowNull = cmbAllowNull.SelectedValue
   item.OutParam = cmbOutParam.SelectedValue
   item.ReferenceType = cmbReferenceType.SelectedValue
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
if mIsOK then mIsOK =( txtCaption.text <> "" ) 
if mIsOK then mIsOK = not txtTypeOfParm.Tag.Equals(System.Guid.Empty)
if mIsOK then mIsOK =(cmbAllowNull.SelectedIndex >=0)
if mIsOK then mIsOK =(cmbOutParam.SelectedIndex >=0)
if mIsOK then mIsOK =(cmbReferenceType.SelectedIndex >=0)
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
