
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Колонка режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editViewColumn
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
Friend WithEvents lblthe_Alias  as  System.Windows.Forms.Label
Friend WithEvents txtthe_Alias As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblFromPart  as  System.Windows.Forms.Label
Friend WithEvents txtFromPart As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdFromPart As System.Windows.Forms.Button
Friend WithEvents lblField  as  System.Windows.Forms.Label
Friend WithEvents txtField As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdField As System.Windows.Forms.Button
Friend WithEvents lblAggregation  as  System.Windows.Forms.Label
Friend WithEvents cmbAggregation As System.Windows.Forms.ComboBox
Friend cmbAggregationDATA As DataTable
Friend cmbAggregationDATAROW As DataRow
Friend WithEvents lblExpression  as  System.Windows.Forms.Label
Friend WithEvents txtExpression As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblForCombo  as  System.Windows.Forms.Label
Friend WithEvents cmbForCombo As System.Windows.Forms.ComboBox
Friend cmbForComboDATA As DataTable
Friend cmbForComboDATAROW As DataRow

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
Me.lblthe_Alias = New System.Windows.Forms.Label
Me.txtthe_Alias = New LATIR2GuiManager.TouchTextBox
Me.lblFromPart = New System.Windows.Forms.Label
Me.txtFromPart = New LATIR2GuiManager.TouchTextBox
Me.cmdFromPart = New System.Windows.Forms.Button
Me.lblField = New System.Windows.Forms.Label
Me.txtField = New LATIR2GuiManager.TouchTextBox
Me.cmdField = New System.Windows.Forms.Button
Me.lblAggregation = New System.Windows.Forms.Label
Me.cmbAggregation = New System.Windows.Forms.ComboBox
Me.lblExpression = New System.Windows.Forms.Label
Me.txtExpression = New LATIR2GuiManager.TouchTextBox
Me.lblForCombo = New System.Windows.Forms.Label
Me.cmbForCombo = New System.Windows.Forms.ComboBox

Me.lblsequence.Location = New System.Drawing.Point(20,5)
Me.lblsequence.name = "lblsequence"
Me.lblsequence.Size = New System.Drawing.Size(200, 20)
Me.lblsequence.TabIndex = 1
Me.lblsequence.Text = "№"
Me.lblsequence.ForeColor = System.Drawing.Color.Blue
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
Me.lblthe_Alias.Location = New System.Drawing.Point(20,99)
Me.lblthe_Alias.name = "lblthe_Alias"
Me.lblthe_Alias.Size = New System.Drawing.Size(200, 20)
Me.lblthe_Alias.TabIndex = 5
Me.lblthe_Alias.Text = "Псвдоним"
Me.lblthe_Alias.ForeColor = System.Drawing.Color.Black
Me.txtthe_Alias.Location = New System.Drawing.Point(20,121)
Me.txtthe_Alias.name = "txtthe_Alias"
Me.txtthe_Alias.Size = New System.Drawing.Size(200, 20)
Me.txtthe_Alias.TabIndex = 6
Me.txtthe_Alias.Text = "" 
Me.lblFromPart.Location = New System.Drawing.Point(20,146)
Me.lblFromPart.name = "lblFromPart"
Me.lblFromPart.Size = New System.Drawing.Size(200, 20)
Me.lblFromPart.TabIndex = 7
Me.lblFromPart.Text = "Раздел"
Me.lblFromPart.ForeColor = System.Drawing.Color.Black
Me.txtFromPart.Location = New System.Drawing.Point(20,168)
Me.txtFromPart.name = "txtFromPart"
Me.txtFromPart.ReadOnly = True
Me.txtFromPart.Size = New System.Drawing.Size(176, 20)
Me.txtFromPart.TabIndex = 8
Me.txtFromPart.Text = "" 
Me.cmdFromPart.Location = New System.Drawing.Point(198,168)
Me.cmdFromPart.name = "cmdFromPart"
Me.cmdFromPart.Size = New System.Drawing.Size(22, 20)
Me.cmdFromPart.TabIndex = 9
Me.cmdFromPart.Text = "..." 
Me.lblField.Location = New System.Drawing.Point(20,193)
Me.lblField.name = "lblField"
Me.lblField.Size = New System.Drawing.Size(200, 20)
Me.lblField.TabIndex = 10
Me.lblField.Text = "Поле"
Me.lblField.ForeColor = System.Drawing.Color.Black
Me.txtField.Location = New System.Drawing.Point(20,215)
Me.txtField.name = "txtField"
Me.txtField.ReadOnly = True
Me.txtField.Size = New System.Drawing.Size(176, 20)
Me.txtField.TabIndex = 11
Me.txtField.Text = "" 
Me.cmdField.Location = New System.Drawing.Point(198,215)
Me.cmdField.name = "cmdField"
Me.cmdField.Size = New System.Drawing.Size(22, 20)
Me.cmdField.TabIndex = 12
Me.cmdField.Text = "..." 
Me.lblAggregation.Location = New System.Drawing.Point(20,240)
Me.lblAggregation.name = "lblAggregation"
Me.lblAggregation.Size = New System.Drawing.Size(200, 20)
Me.lblAggregation.TabIndex = 13
Me.lblAggregation.Text = "Агрегация"
Me.lblAggregation.ForeColor = System.Drawing.Color.Black
Me.cmbAggregation.Location = New System.Drawing.Point(20,262)
Me.cmbAggregation.name = "cmbAggregation"
Me.cmbAggregation.Size = New System.Drawing.Size(200,  20)
Me.cmbAggregation.TabIndex = 14
Me.cmbAggregation.DropDownStyle = ComboBoxStyle.DropDownList
Me.lblExpression.Location = New System.Drawing.Point(20,287)
Me.lblExpression.name = "lblExpression"
Me.lblExpression.Size = New System.Drawing.Size(200, 20)
Me.lblExpression.TabIndex = 15
Me.lblExpression.Text = "Формула"
Me.lblExpression.ForeColor = System.Drawing.Color.Blue
Me.txtExpression.Location = New System.Drawing.Point(20,309)
Me.txtExpression.name = "txtExpression"
Me.txtExpression.MultiLine = True
Me.txtExpression.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtExpression.Size = New System.Drawing.Size(200, 50 + 20)
Me.txtExpression.TabIndex = 16
Me.txtExpression.Text = "" 
Me.lblForCombo.Location = New System.Drawing.Point(20,379)
Me.lblForCombo.name = "lblForCombo"
Me.lblForCombo.Size = New System.Drawing.Size(200, 20)
Me.lblForCombo.TabIndex = 17
Me.lblForCombo.Text = "Для комбо"
Me.lblForCombo.ForeColor = System.Drawing.Color.Black
Me.cmbForCombo.Location = New System.Drawing.Point(20,401)
Me.cmbForCombo.name = "cmbForCombo"
Me.cmbForCombo.Size = New System.Drawing.Size(200,  20)
Me.cmbForCombo.TabIndex = 18
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblsequence)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtsequence)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblthe_Alias)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtthe_Alias)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblFromPart)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtFromPart)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdFromPart)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblField)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtField)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdField)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblAggregation)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbAggregation)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblExpression)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtExpression)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblForCombo)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbForCombo)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editViewColumn"
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
private sub txtthe_Alias_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtthe_Alias.TextChanged
  Changing

end sub
private sub txtFromPart_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFromPart.TextChanged
  Changing

end sub
private sub cmdFromPart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFromPart.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("PART","",System.guid.Empty, id, brief) Then
          txtFromPart.Tag = id
          txtFromPart.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtField_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtField.TextChanged
  Changing

end sub
private sub cmdField_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdField.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("FIELD","",item.application.ID, id, brief) Then
          txtField.Tag = id
          txtField.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmbAggregation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAggregation.SelectedIndexChanged
  try
     Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtExpression_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtExpression.TextChanged
  Changing

end sub
private sub cmbForCombo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbForCombo.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub

Public Item As MTZMetaModel.MTZMetaModel.ViewColumn
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,MTZMetaModel.MTZMetaModel.ViewColumn)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

txtsequence.text = item.sequence.toString()
txtName.text = item.Name
txtthe_Alias.text = item.the_Alias
If Not item.FromPart Is Nothing Then
  txtFromPart.Tag = item.FromPart.id
  txtFromPart.text = item.FromPart.brief
else
  txtFromPart.Tag = System.Guid.Empty 
  txtFromPart.text = "" 
End If
If Not item.Field Is Nothing Then
  txtField.Tag = item.Field.id
  txtField.text = item.Field.brief
else
  txtField.Tag = System.Guid.Empty 
  txtField.text = "" 
End If
cmbAggregationData = New DataTable
cmbAggregationData.Columns.Add("name", GetType(System.String))
cmbAggregationData.Columns.Add("Value", GetType(System.Int32))
try
cmbAggregationDataRow = cmbAggregationData.NewRow
cmbAggregationDataRow("name") = "none"
cmbAggregationDataRow("Value") = 0
cmbAggregationData.Rows.Add (cmbAggregationDataRow)
cmbAggregationDataRow = cmbAggregationData.NewRow
cmbAggregationDataRow("name") = "AVG"
cmbAggregationDataRow("Value") = 1
cmbAggregationData.Rows.Add (cmbAggregationDataRow)
cmbAggregationDataRow = cmbAggregationData.NewRow
cmbAggregationDataRow("name") = "COUNT"
cmbAggregationDataRow("Value") = 2
cmbAggregationData.Rows.Add (cmbAggregationDataRow)
cmbAggregationDataRow = cmbAggregationData.NewRow
cmbAggregationDataRow("name") = "SUM"
cmbAggregationDataRow("Value") = 3
cmbAggregationData.Rows.Add (cmbAggregationDataRow)
cmbAggregationDataRow = cmbAggregationData.NewRow
cmbAggregationDataRow("name") = "MIN"
cmbAggregationDataRow("Value") = 4
cmbAggregationData.Rows.Add (cmbAggregationDataRow)
cmbAggregationDataRow = cmbAggregationData.NewRow
cmbAggregationDataRow("name") = "MAX"
cmbAggregationDataRow("Value") = 5
cmbAggregationData.Rows.Add (cmbAggregationDataRow)
cmbAggregationDataRow = cmbAggregationData.NewRow
cmbAggregationDataRow("name") = "CUSTOM"
cmbAggregationDataRow("Value") = 6
cmbAggregationData.Rows.Add (cmbAggregationDataRow)
cmbAggregation.DisplayMember = "name"
cmbAggregation.ValueMember = "Value"
cmbAggregation.DataSource = cmbAggregationData
 cmbAggregation.SelectedValue=CInt(Item.Aggregation)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
txtExpression.text = item.Expression
cmbForComboData = New DataTable
cmbForComboData.Columns.Add("name", GetType(System.String))
cmbForComboData.Columns.Add("Value", GetType(System.Int32))
try
cmbForComboDataRow = cmbForComboData.NewRow
cmbForComboDataRow("name") = "Да"
cmbForComboDataRow("Value") = -1
cmbForComboData.Rows.Add (cmbForComboDataRow)
cmbForComboDataRow = cmbForComboData.NewRow
cmbForComboDataRow("name") = "Нет"
cmbForComboDataRow("Value") = 0
cmbForComboData.Rows.Add (cmbForComboDataRow)
cmbForCombo.DisplayMember = "name"
cmbForCombo.ValueMember = "Value"
cmbForCombo.DataSource = cmbForComboData
 cmbForCombo.SelectedValue=CInt(Item.ForCombo)
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
item.the_Alias = txtthe_Alias.text
If not txtFromPart.Tag.Equals(System.Guid.Empty) Then
  item.FromPart = Item.Application.FindRowObject("PART",txtFromPart.Tag)
Else
   item.FromPart = Nothing
End If
If not txtField.Tag.Equals(System.Guid.Empty) Then
  item.Field = Item.Application.FindRowObject("FIELD",txtField.Tag)
Else
   item.Field = Nothing
End If
   item.Aggregation = cmbAggregation.SelectedValue
item.Expression = txtExpression.text
   item.ForCombo = cmbForCombo.SelectedValue
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK =( txtName.text <> "" ) 
if mIsOK then mIsOK =( txtthe_Alias.text <> "" ) 
if mIsOK then mIsOK = not txtFromPart.Tag.Equals(System.Guid.Empty)
if mIsOK then mIsOK = not txtField.Tag.Equals(System.Guid.Empty)
if mIsOK then mIsOK =(cmbAggregation.SelectedIndex >=0)
if mIsOK then mIsOK =(cmbForCombo.SelectedIndex >=0)
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
