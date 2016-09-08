
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Колонки журнала режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editJournalColumn
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
Friend WithEvents lblname  as  System.Windows.Forms.Label
Friend WithEvents txtname As System.Windows.Forms.TextBox
Friend WithEvents lblColumnAlignment  as  System.Windows.Forms.Label
Friend WithEvents cmbColumnAlignment As System.Windows.Forms.ComboBox
Friend cmbColumnAlignmentDATA As DataTable
Friend cmbColumnAlignmentDATAROW As DataRow
Friend WithEvents lblColSort  as  System.Windows.Forms.Label
Friend WithEvents cmbColSort As System.Windows.Forms.ComboBox
Friend cmbColSortDATA As DataTable
Friend cmbColSortDATAROW As DataRow
Friend WithEvents lblGroupAggregation  as  System.Windows.Forms.Label
Friend WithEvents cmbGroupAggregation As System.Windows.Forms.ComboBox
Friend cmbGroupAggregationDATA As DataTable
Friend cmbGroupAggregationDATAROW As DataRow

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
Me.lblname = New System.Windows.Forms.Label
Me.txtname = New System.Windows.Forms.TextBox
Me.lblColumnAlignment = New System.Windows.Forms.Label
Me.cmbColumnAlignment = New System.Windows.Forms.ComboBox
Me.lblColSort = New System.Windows.Forms.Label
Me.cmbColSort = New System.Windows.Forms.ComboBox
Me.lblGroupAggregation = New System.Windows.Forms.Label
Me.cmbGroupAggregation = New System.Windows.Forms.ComboBox

Me.lblsequence.Location = New System.Drawing.Point(20,5)
Me.lblsequence.name = "lblsequence"
Me.lblsequence.Size = New System.Drawing.Size(200, 20)
Me.lblsequence.TabIndex = 1
Me.lblsequence.Text = "Последовательность"
Me.lblsequence.ForeColor = System.Drawing.Color.Blue
Me.txtsequence.Location = New System.Drawing.Point(20,27)
Me.txtsequence.name = "txtsequence"
Me.txtsequence.MultiLine = false
Me.txtsequence.Size = New System.Drawing.Size(200,  20)
Me.txtsequence.TabIndex = 2
Me.txtsequence.Text = "" 
Me.txtsequence.MaxLength = 15
Me.lblname.Location = New System.Drawing.Point(20,52)
Me.lblname.name = "lblname"
Me.lblname.Size = New System.Drawing.Size(200, 20)
Me.lblname.TabIndex = 3
Me.lblname.Text = "Название"
Me.lblname.ForeColor = System.Drawing.Color.Black
Me.txtname.Location = New System.Drawing.Point(20,74)
Me.txtname.name = "txtname"
Me.txtname.Size = New System.Drawing.Size(200, 20)
Me.txtname.TabIndex = 4
Me.txtname.Text = "" 
Me.lblColumnAlignment.Location = New System.Drawing.Point(20,99)
Me.lblColumnAlignment.name = "lblColumnAlignment"
Me.lblColumnAlignment.Size = New System.Drawing.Size(200, 20)
Me.lblColumnAlignment.TabIndex = 5
Me.lblColumnAlignment.Text = "Выравнивание"
Me.lblColumnAlignment.ForeColor = System.Drawing.Color.Black
Me.cmbColumnAlignment.Location = New System.Drawing.Point(20,121)
Me.cmbColumnAlignment.name = "cmbColumnAlignment"
Me.cmbColumnAlignment.Size = New System.Drawing.Size(200,  20)
Me.cmbColumnAlignment.TabIndex = 6
Me.cmbColumnAlignment.DropDownStyle = ComboBoxStyle.DropDownList
Me.lblColSort.Location = New System.Drawing.Point(20,146)
Me.lblColSort.name = "lblColSort"
Me.lblColSort.Size = New System.Drawing.Size(200, 20)
Me.lblColSort.TabIndex = 7
Me.lblColSort.Text = "Сортировка колонки"
Me.lblColSort.ForeColor = System.Drawing.Color.Black
Me.cmbColSort.Location = New System.Drawing.Point(20,168)
Me.cmbColSort.name = "cmbColSort"
Me.cmbColSort.Size = New System.Drawing.Size(200,  20)
Me.cmbColSort.TabIndex = 8
Me.cmbColSort.DropDownStyle = ComboBoxStyle.DropDownList
Me.lblGroupAggregation.Location = New System.Drawing.Point(20,193)
Me.lblGroupAggregation.name = "lblGroupAggregation"
Me.lblGroupAggregation.Size = New System.Drawing.Size(200, 20)
Me.lblGroupAggregation.TabIndex = 9
Me.lblGroupAggregation.Text = "Аггрегация при группировке"
Me.lblGroupAggregation.ForeColor = System.Drawing.Color.Black
Me.cmbGroupAggregation.Location = New System.Drawing.Point(20,215)
Me.cmbGroupAggregation.name = "cmbGroupAggregation"
Me.cmbGroupAggregation.Size = New System.Drawing.Size(200,  20)
Me.cmbGroupAggregation.TabIndex = 10
Me.cmbGroupAggregation.DropDownStyle = ComboBoxStyle.DropDownList
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblsequence)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtsequence)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblname)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtname)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblColumnAlignment)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbColumnAlignment)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblColSort)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbColSort)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblGroupAggregation)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbGroupAggregation)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editJournalColumn"
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
private sub txtname_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtname.TextChanged
  Changing

end sub
private sub cmbColumnAlignment_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbColumnAlignment.SelectedIndexChanged
  try
     Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmbColSort_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbColSort.SelectedIndexChanged
  try
     Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmbGroupAggregation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGroupAggregation.SelectedIndexChanged
  try
     Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub

Public Item As MTZJrnl.MTZJrnl.JournalColumn
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,MTZJrnl.MTZJrnl.JournalColumn)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

txtsequence.text = item.sequence.toString()
txtname.text = item.name
cmbColumnAlignmentData = New DataTable
cmbColumnAlignmentData.Columns.Add("name", GetType(System.String))
cmbColumnAlignmentData.Columns.Add("Value", GetType(System.Int32))
try
cmbColumnAlignmentDataRow = cmbColumnAlignmentData.NewRow
cmbColumnAlignmentDataRow("name") = "Left Top"
cmbColumnAlignmentDataRow("Value") = 0
cmbColumnAlignmentData.Rows.Add (cmbColumnAlignmentDataRow)
cmbColumnAlignmentDataRow = cmbColumnAlignmentData.NewRow
cmbColumnAlignmentDataRow("name") = "Left Center"
cmbColumnAlignmentDataRow("Value") = 1
cmbColumnAlignmentData.Rows.Add (cmbColumnAlignmentDataRow)
cmbColumnAlignmentDataRow = cmbColumnAlignmentData.NewRow
cmbColumnAlignmentDataRow("name") = "Left Bottom"
cmbColumnAlignmentDataRow("Value") = 2
cmbColumnAlignmentData.Rows.Add (cmbColumnAlignmentDataRow)
cmbColumnAlignmentDataRow = cmbColumnAlignmentData.NewRow
cmbColumnAlignmentDataRow("name") = "Center Top"
cmbColumnAlignmentDataRow("Value") = 3
cmbColumnAlignmentData.Rows.Add (cmbColumnAlignmentDataRow)
cmbColumnAlignmentDataRow = cmbColumnAlignmentData.NewRow
cmbColumnAlignmentDataRow("name") = "Center Center"
cmbColumnAlignmentDataRow("Value") = 4
cmbColumnAlignmentData.Rows.Add (cmbColumnAlignmentDataRow)
cmbColumnAlignmentDataRow = cmbColumnAlignmentData.NewRow
cmbColumnAlignmentDataRow("name") = "Center Bottom"
cmbColumnAlignmentDataRow("Value") = 5
cmbColumnAlignmentData.Rows.Add (cmbColumnAlignmentDataRow)
cmbColumnAlignmentDataRow = cmbColumnAlignmentData.NewRow
cmbColumnAlignmentDataRow("name") = "Right Top"
cmbColumnAlignmentDataRow("Value") = 6
cmbColumnAlignmentData.Rows.Add (cmbColumnAlignmentDataRow)
cmbColumnAlignmentDataRow = cmbColumnAlignmentData.NewRow
cmbColumnAlignmentDataRow("name") = "Right Center"
cmbColumnAlignmentDataRow("Value") = 7
cmbColumnAlignmentData.Rows.Add (cmbColumnAlignmentDataRow)
cmbColumnAlignmentDataRow = cmbColumnAlignmentData.NewRow
cmbColumnAlignmentDataRow("name") = "Right Bottom"
cmbColumnAlignmentDataRow("Value") = 8
cmbColumnAlignmentData.Rows.Add (cmbColumnAlignmentDataRow)
cmbColumnAlignment.DisplayMember = "name"
cmbColumnAlignment.ValueMember = "Value"
cmbColumnAlignment.DataSource = cmbColumnAlignmentData
 cmbColumnAlignment.SelectedValue=CInt(Item.ColumnAlignment)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
cmbColSortData = New DataTable
cmbColSortData.Columns.Add("name", GetType(System.String))
cmbColSortData.Columns.Add("Value", GetType(System.Int32))
try
cmbColSortDataRow = cmbColSortData.NewRow
cmbColSortDataRow("name") = "As String"
cmbColSortDataRow("Value") = 0
cmbColSortData.Rows.Add (cmbColSortDataRow)
cmbColSortDataRow = cmbColSortData.NewRow
cmbColSortDataRow("name") = "As Numeric"
cmbColSortDataRow("Value") = 1
cmbColSortData.Rows.Add (cmbColSortDataRow)
cmbColSortDataRow = cmbColSortData.NewRow
cmbColSortDataRow("name") = "As Date"
cmbColSortDataRow("Value") = 2
cmbColSortData.Rows.Add (cmbColSortDataRow)
cmbColSort.DisplayMember = "name"
cmbColSort.ValueMember = "Value"
cmbColSort.DataSource = cmbColSortData
 cmbColSort.SelectedValue=CInt(Item.ColSort)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
cmbGroupAggregationData = New DataTable
cmbGroupAggregationData.Columns.Add("name", GetType(System.String))
cmbGroupAggregationData.Columns.Add("Value", GetType(System.Int32))
try
cmbGroupAggregationDataRow = cmbGroupAggregationData.NewRow
cmbGroupAggregationDataRow("name") = "none"
cmbGroupAggregationDataRow("Value") = 0
cmbGroupAggregationData.Rows.Add (cmbGroupAggregationDataRow)
cmbGroupAggregationDataRow = cmbGroupAggregationData.NewRow
cmbGroupAggregationDataRow("name") = "AVG"
cmbGroupAggregationDataRow("Value") = 1
cmbGroupAggregationData.Rows.Add (cmbGroupAggregationDataRow)
cmbGroupAggregationDataRow = cmbGroupAggregationData.NewRow
cmbGroupAggregationDataRow("name") = "COUNT"
cmbGroupAggregationDataRow("Value") = 2
cmbGroupAggregationData.Rows.Add (cmbGroupAggregationDataRow)
cmbGroupAggregationDataRow = cmbGroupAggregationData.NewRow
cmbGroupAggregationDataRow("name") = "SUM"
cmbGroupAggregationDataRow("Value") = 3
cmbGroupAggregationData.Rows.Add (cmbGroupAggregationDataRow)
cmbGroupAggregationDataRow = cmbGroupAggregationData.NewRow
cmbGroupAggregationDataRow("name") = "MIN"
cmbGroupAggregationDataRow("Value") = 4
cmbGroupAggregationData.Rows.Add (cmbGroupAggregationDataRow)
cmbGroupAggregationDataRow = cmbGroupAggregationData.NewRow
cmbGroupAggregationDataRow("name") = "MAX"
cmbGroupAggregationDataRow("Value") = 5
cmbGroupAggregationData.Rows.Add (cmbGroupAggregationDataRow)
cmbGroupAggregationDataRow = cmbGroupAggregationData.NewRow
cmbGroupAggregationDataRow("name") = "CUSTOM"
cmbGroupAggregationDataRow("Value") = 6
cmbGroupAggregationData.Rows.Add (cmbGroupAggregationDataRow)
cmbGroupAggregation.DisplayMember = "name"
cmbGroupAggregation.ValueMember = "Value"
cmbGroupAggregation.DataSource = cmbGroupAggregationData
 cmbGroupAggregation.SelectedValue=CInt(Item.GroupAggregation)
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
item.name = txtname.text
   item.ColumnAlignment = cmbColumnAlignment.SelectedValue
   item.ColSort = cmbColSort.SelectedValue
   item.GroupAggregation = cmbGroupAggregation.SelectedValue
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK =( txtname.text <> "" ) 
if mIsOK then mIsOK =(cmbColumnAlignment.SelectedIndex >=0)
if mIsOK then mIsOK =(cmbColSort.SelectedIndex >=0)
if mIsOK then mIsOK =(cmbGroupAggregation.SelectedIndex >=0)
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
