
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Колонки журнала режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editjournalcolumn
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
Friend WithEvents lblname  as  System.Windows.Forms.Label
Friend WithEvents txtname As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblcolumnalignment  as  System.Windows.Forms.Label
Friend WithEvents cmbcolumnalignment As System.Windows.Forms.ComboBox
Friend cmbcolumnalignmentDATA As DataTable
Friend cmbcolumnalignmentDATAROW As DataRow
Friend WithEvents lblcolsort  as  System.Windows.Forms.Label
Friend WithEvents cmbcolsort As System.Windows.Forms.ComboBox
Friend cmbcolsortDATA As DataTable
Friend cmbcolsortDATAROW As DataRow
Friend WithEvents lblgroupaggregation  as  System.Windows.Forms.Label
Friend WithEvents cmbgroupaggregation As System.Windows.Forms.ComboBox
Friend cmbgroupaggregationDATA As DataTable
Friend cmbgroupaggregationDATAROW As DataRow

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
Me.lblname = New System.Windows.Forms.Label
Me.txtname = New LATIR2GuiManager.TouchTextBox
Me.lblcolumnalignment = New System.Windows.Forms.Label
Me.cmbcolumnalignment = New System.Windows.Forms.ComboBox
Me.lblcolsort = New System.Windows.Forms.Label
Me.cmbcolsort = New System.Windows.Forms.ComboBox
Me.lblgroupaggregation = New System.Windows.Forms.Label
Me.cmbgroupaggregation = New System.Windows.Forms.ComboBox

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
Me.lblcolumnalignment.Location = New System.Drawing.Point(20,99)
Me.lblcolumnalignment.name = "lblcolumnalignment"
Me.lblcolumnalignment.Size = New System.Drawing.Size(200, 20)
Me.lblcolumnalignment.TabIndex = 5
Me.lblcolumnalignment.Text = "Выравнивание"
Me.lblcolumnalignment.ForeColor = System.Drawing.Color.Black
Me.cmbcolumnalignment.Location = New System.Drawing.Point(20,121)
Me.cmbcolumnalignment.name = "cmbcolumnalignment"
Me.cmbcolumnalignment.Size = New System.Drawing.Size(200,  20)
Me.cmbcolumnalignment.TabIndex = 6
Me.cmbcolumnalignment.DropDownStyle = ComboBoxStyle.DropDownList
Me.lblcolsort.Location = New System.Drawing.Point(20,146)
Me.lblcolsort.name = "lblcolsort"
Me.lblcolsort.Size = New System.Drawing.Size(200, 20)
Me.lblcolsort.TabIndex = 7
Me.lblcolsort.Text = "Сортировка колонки"
Me.lblcolsort.ForeColor = System.Drawing.Color.Black
Me.cmbcolsort.Location = New System.Drawing.Point(20,168)
Me.cmbcolsort.name = "cmbcolsort"
Me.cmbcolsort.Size = New System.Drawing.Size(200,  20)
Me.cmbcolsort.TabIndex = 8
Me.cmbcolsort.DropDownStyle = ComboBoxStyle.DropDownList
Me.lblgroupaggregation.Location = New System.Drawing.Point(20,193)
Me.lblgroupaggregation.name = "lblgroupaggregation"
Me.lblgroupaggregation.Size = New System.Drawing.Size(200, 20)
Me.lblgroupaggregation.TabIndex = 9
Me.lblgroupaggregation.Text = "Аггрегация при группировке"
Me.lblgroupaggregation.ForeColor = System.Drawing.Color.Black
Me.cmbgroupaggregation.Location = New System.Drawing.Point(20,215)
Me.cmbgroupaggregation.name = "cmbgroupaggregation"
Me.cmbgroupaggregation.Size = New System.Drawing.Size(200,  20)
Me.cmbgroupaggregation.TabIndex = 10
Me.cmbgroupaggregation.DropDownStyle = ComboBoxStyle.DropDownList
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblsequence)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtsequence)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblname)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtname)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblcolumnalignment)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbcolumnalignment)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblcolsort)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbcolsort)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblgroupaggregation)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbgroupaggregation)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editjournalcolumn"
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
private sub cmbcolumnalignment_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbcolumnalignment.SelectedIndexChanged
  try
     Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmbcolsort_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbcolsort.SelectedIndexChanged
  try
     Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmbgroupaggregation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbgroupaggregation.SelectedIndexChanged
  try
     Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub

Public Item As mtzjrnl.mtzjrnl.journalcolumn
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,mtzjrnl.mtzjrnl.journalcolumn)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

txtsequence.text = item.sequence.toString()
txtname.text = item.name
cmbcolumnalignmentData = New DataTable
cmbcolumnalignmentData.Columns.Add("name", GetType(System.String))
cmbcolumnalignmentData.Columns.Add("Value", GetType(System.Int32))
try
cmbcolumnalignmentDataRow = cmbcolumnalignmentData.NewRow
cmbcolumnalignmentDataRow("name") = "Left Top"
cmbcolumnalignmentDataRow("Value") = 0
cmbcolumnalignmentData.Rows.Add (cmbcolumnalignmentDataRow)
cmbcolumnalignmentDataRow = cmbcolumnalignmentData.NewRow
cmbcolumnalignmentDataRow("name") = "Left Center"
cmbcolumnalignmentDataRow("Value") = 1
cmbcolumnalignmentData.Rows.Add (cmbcolumnalignmentDataRow)
cmbcolumnalignmentDataRow = cmbcolumnalignmentData.NewRow
cmbcolumnalignmentDataRow("name") = "Left Bottom"
cmbcolumnalignmentDataRow("Value") = 2
cmbcolumnalignmentData.Rows.Add (cmbcolumnalignmentDataRow)
cmbcolumnalignmentDataRow = cmbcolumnalignmentData.NewRow
cmbcolumnalignmentDataRow("name") = "Center Top"
cmbcolumnalignmentDataRow("Value") = 3
cmbcolumnalignmentData.Rows.Add (cmbcolumnalignmentDataRow)
cmbcolumnalignmentDataRow = cmbcolumnalignmentData.NewRow
cmbcolumnalignmentDataRow("name") = "Center Center"
cmbcolumnalignmentDataRow("Value") = 4
cmbcolumnalignmentData.Rows.Add (cmbcolumnalignmentDataRow)
cmbcolumnalignmentDataRow = cmbcolumnalignmentData.NewRow
cmbcolumnalignmentDataRow("name") = "Center Bottom"
cmbcolumnalignmentDataRow("Value") = 5
cmbcolumnalignmentData.Rows.Add (cmbcolumnalignmentDataRow)
cmbcolumnalignmentDataRow = cmbcolumnalignmentData.NewRow
cmbcolumnalignmentDataRow("name") = "Right Top"
cmbcolumnalignmentDataRow("Value") = 6
cmbcolumnalignmentData.Rows.Add (cmbcolumnalignmentDataRow)
cmbcolumnalignmentDataRow = cmbcolumnalignmentData.NewRow
cmbcolumnalignmentDataRow("name") = "Right Center"
cmbcolumnalignmentDataRow("Value") = 7
cmbcolumnalignmentData.Rows.Add (cmbcolumnalignmentDataRow)
cmbcolumnalignmentDataRow = cmbcolumnalignmentData.NewRow
cmbcolumnalignmentDataRow("name") = "Right Bottom"
cmbcolumnalignmentDataRow("Value") = 8
cmbcolumnalignmentData.Rows.Add (cmbcolumnalignmentDataRow)
cmbcolumnalignment.DisplayMember = "name"
cmbcolumnalignment.ValueMember = "Value"
cmbcolumnalignment.DataSource = cmbcolumnalignmentData
 cmbcolumnalignment.SelectedValue=CInt(Item.columnalignment)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
cmbcolsortData = New DataTable
cmbcolsortData.Columns.Add("name", GetType(System.String))
cmbcolsortData.Columns.Add("Value", GetType(System.Int32))
try
cmbcolsortDataRow = cmbcolsortData.NewRow
cmbcolsortDataRow("name") = "As String"
cmbcolsortDataRow("Value") = 0
cmbcolsortData.Rows.Add (cmbcolsortDataRow)
cmbcolsortDataRow = cmbcolsortData.NewRow
cmbcolsortDataRow("name") = "As Numeric"
cmbcolsortDataRow("Value") = 1
cmbcolsortData.Rows.Add (cmbcolsortDataRow)
cmbcolsortDataRow = cmbcolsortData.NewRow
cmbcolsortDataRow("name") = "As Date"
cmbcolsortDataRow("Value") = 2
cmbcolsortData.Rows.Add (cmbcolsortDataRow)
cmbcolsort.DisplayMember = "name"
cmbcolsort.ValueMember = "Value"
cmbcolsort.DataSource = cmbcolsortData
 cmbcolsort.SelectedValue=CInt(Item.colsort)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
cmbgroupaggregationData = New DataTable
cmbgroupaggregationData.Columns.Add("name", GetType(System.String))
cmbgroupaggregationData.Columns.Add("Value", GetType(System.Int32))
try
cmbgroupaggregationDataRow = cmbgroupaggregationData.NewRow
cmbgroupaggregationDataRow("name") = "none"
cmbgroupaggregationDataRow("Value") = 0
cmbgroupaggregationData.Rows.Add (cmbgroupaggregationDataRow)
cmbgroupaggregationDataRow = cmbgroupaggregationData.NewRow
cmbgroupaggregationDataRow("name") = "AVG"
cmbgroupaggregationDataRow("Value") = 1
cmbgroupaggregationData.Rows.Add (cmbgroupaggregationDataRow)
cmbgroupaggregationDataRow = cmbgroupaggregationData.NewRow
cmbgroupaggregationDataRow("name") = "COUNT"
cmbgroupaggregationDataRow("Value") = 2
cmbgroupaggregationData.Rows.Add (cmbgroupaggregationDataRow)
cmbgroupaggregationDataRow = cmbgroupaggregationData.NewRow
cmbgroupaggregationDataRow("name") = "SUM"
cmbgroupaggregationDataRow("Value") = 3
cmbgroupaggregationData.Rows.Add (cmbgroupaggregationDataRow)
cmbgroupaggregationDataRow = cmbgroupaggregationData.NewRow
cmbgroupaggregationDataRow("name") = "MIN"
cmbgroupaggregationDataRow("Value") = 4
cmbgroupaggregationData.Rows.Add (cmbgroupaggregationDataRow)
cmbgroupaggregationDataRow = cmbgroupaggregationData.NewRow
cmbgroupaggregationDataRow("name") = "MAX"
cmbgroupaggregationDataRow("Value") = 5
cmbgroupaggregationData.Rows.Add (cmbgroupaggregationDataRow)
cmbgroupaggregationDataRow = cmbgroupaggregationData.NewRow
cmbgroupaggregationDataRow("name") = "CUSTOM"
cmbgroupaggregationDataRow("Value") = 6
cmbgroupaggregationData.Rows.Add (cmbgroupaggregationDataRow)
cmbgroupaggregation.DisplayMember = "name"
cmbgroupaggregation.ValueMember = "Value"
cmbgroupaggregation.DataSource = cmbgroupaggregationData
 cmbgroupaggregation.SelectedValue=CInt(Item.groupaggregation)
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
   item.columnalignment = cmbcolumnalignment.SelectedValue
   item.colsort = cmbcolsort.SelectedValue
   item.groupaggregation = cmbgroupaggregation.SelectedValue
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK =( txtname.text <> "" ) 
if mIsOK then mIsOK =(cmbcolumnalignment.SelectedIndex >=0)
if mIsOK then mIsOK =(cmbcolsort.SelectedIndex >=0)
if mIsOK then mIsOK =(cmbgroupaggregation.SelectedIndex >=0)
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
