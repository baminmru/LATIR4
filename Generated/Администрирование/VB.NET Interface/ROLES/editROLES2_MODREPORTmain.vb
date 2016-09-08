
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Действия и отчеты режим:main
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editROLES2_MODREPORTmain
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
Friend WithEvents txtName As System.Windows.Forms.TextBox
Friend WithEvents lblAllowAction  as  System.Windows.Forms.Label
Friend WithEvents cmbAllowAction As System.Windows.Forms.ComboBox
Friend cmbAllowActionDATA As DataTable
Friend cmbAllowActionDATAROW As DataRow
Friend WithEvents lblCaption  as  System.Windows.Forms.Label
Friend WithEvents txtCaption As System.Windows.Forms.TextBox
Friend WithEvents lblSequence  as  System.Windows.Forms.Label
Friend WithEvents txtSequence As System.Windows.Forms.TextBox
Friend WithEvents lblTheIcon  as  System.Windows.Forms.Label
Friend WithEvents txtTheIcon As System.Windows.Forms.TextBox
Friend WithEvents lblIsReport  as  System.Windows.Forms.Label
Friend WithEvents cmbIsReport As System.Windows.Forms.ComboBox
Friend cmbIsReportDATA As DataTable
Friend cmbIsReportDATAROW As DataRow
Friend WithEvents lblselectType  as  System.Windows.Forms.Label
Friend WithEvents txtselectType As System.Windows.Forms.TextBox

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
Me.txtName = New System.Windows.Forms.TextBox
Me.lblAllowAction = New System.Windows.Forms.Label
Me.cmbAllowAction = New System.Windows.Forms.ComboBox
Me.lblCaption = New System.Windows.Forms.Label
Me.txtCaption = New System.Windows.Forms.TextBox
Me.lblSequence = New System.Windows.Forms.Label
Me.txtSequence = New System.Windows.Forms.TextBox
Me.lblTheIcon = New System.Windows.Forms.Label
Me.txtTheIcon = New System.Windows.Forms.TextBox
Me.lblIsReport = New System.Windows.Forms.Label
Me.cmbIsReport = New System.Windows.Forms.ComboBox
Me.lblselectType = New System.Windows.Forms.Label
Me.txtselectType = New System.Windows.Forms.TextBox

Me.lblName.Location = New System.Drawing.Point(20,5)
Me.lblName.name = "lblName"
Me.lblName.Size = New System.Drawing.Size(200, 20)
Me.lblName.TabIndex = 1
Me.lblName.Text = "Код"
Me.lblName.ForeColor = System.Drawing.Color.Black
Me.txtName.Location = New System.Drawing.Point(20,27)
Me.txtName.name = "txtName"
Me.txtName.Size = New System.Drawing.Size(200, 20)
Me.txtName.TabIndex = 2
Me.txtName.Text = "" 
Me.lblAllowAction.Location = New System.Drawing.Point(20,52)
Me.lblAllowAction.name = "lblAllowAction"
Me.lblAllowAction.Size = New System.Drawing.Size(200, 20)
Me.lblAllowAction.TabIndex = 3
Me.lblAllowAction.Text = "Разрешен"
Me.lblAllowAction.ForeColor = System.Drawing.Color.Black
Me.cmbAllowAction.Location = New System.Drawing.Point(20,74)
Me.cmbAllowAction.name = "cmbAllowAction"
Me.cmbAllowAction.Size = New System.Drawing.Size(200,  20)
Me.cmbAllowAction.TabIndex = 4
Me.lblCaption.Location = New System.Drawing.Point(20,99)
Me.lblCaption.name = "lblCaption"
Me.lblCaption.Size = New System.Drawing.Size(200, 20)
Me.lblCaption.TabIndex = 5
Me.lblCaption.Text = "Надпись"
Me.lblCaption.ForeColor = System.Drawing.Color.Black
Me.txtCaption.Location = New System.Drawing.Point(20,121)
Me.txtCaption.name = "txtCaption"
Me.txtCaption.Size = New System.Drawing.Size(200, 20)
Me.txtCaption.TabIndex = 6
Me.txtCaption.Text = "" 
Me.lblSequence.Location = New System.Drawing.Point(20,146)
Me.lblSequence.name = "lblSequence"
Me.lblSequence.Size = New System.Drawing.Size(200, 20)
Me.lblSequence.TabIndex = 7
Me.lblSequence.Text = "№ п/п"
Me.lblSequence.ForeColor = System.Drawing.Color.Black
Me.txtSequence.Location = New System.Drawing.Point(20,168)
Me.txtSequence.name = "txtSequence"
Me.txtSequence.MultiLine = false
Me.txtSequence.Size = New System.Drawing.Size(200,  20)
Me.txtSequence.TabIndex = 8
Me.txtSequence.Text = "" 
Me.txtSequence.MaxLength = 15
Me.lblTheIcon.Location = New System.Drawing.Point(20,193)
Me.lblTheIcon.name = "lblTheIcon"
Me.lblTheIcon.Size = New System.Drawing.Size(200, 20)
Me.lblTheIcon.TabIndex = 9
Me.lblTheIcon.Text = "Иконка"
Me.lblTheIcon.ForeColor = System.Drawing.Color.Blue
Me.txtTheIcon.Location = New System.Drawing.Point(20,215)
Me.txtTheIcon.name = "txtTheIcon"
Me.txtTheIcon.Size = New System.Drawing.Size(200, 20)
Me.txtTheIcon.TabIndex = 10
Me.txtTheIcon.Text = "" 
Me.lblIsReport.Location = New System.Drawing.Point(20,240)
Me.lblIsReport.name = "lblIsReport"
Me.lblIsReport.Size = New System.Drawing.Size(200, 20)
Me.lblIsReport.TabIndex = 11
Me.lblIsReport.Text = "Это отчет"
Me.lblIsReport.ForeColor = System.Drawing.Color.Black
Me.cmbIsReport.Location = New System.Drawing.Point(20,262)
Me.cmbIsReport.name = "cmbIsReport"
Me.cmbIsReport.Size = New System.Drawing.Size(200,  20)
Me.cmbIsReport.TabIndex = 12
Me.lblselectType.Location = New System.Drawing.Point(20,287)
Me.lblselectType.name = "lblselectType"
Me.lblselectType.Size = New System.Drawing.Size(200, 20)
Me.lblselectType.TabIndex = 13
Me.lblselectType.Text = "Вариант выбора"
Me.lblselectType.ForeColor = System.Drawing.Color.Blue
Me.txtselectType.Location = New System.Drawing.Point(20,309)
Me.txtselectType.name = "txtselectType"
Me.txtselectType.MultiLine = false
Me.txtselectType.Size = New System.Drawing.Size(200,  20)
Me.txtselectType.TabIndex = 14
Me.txtselectType.Text = "" 
Me.txtselectType.MaxLength = 15
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblAllowAction)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbAllowAction)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblCaption)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtCaption)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblSequence)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtSequence)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTheIcon)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTheIcon)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblIsReport)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbIsReport)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblselectType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtselectType)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editROLES2_MODREPORT"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
  Changing

end sub
private sub cmbAllowAction_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAllowAction.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtCaption_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCaption.TextChanged
  Changing

end sub
        Private Sub txtSequence_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtSequence.Validating
        If txtSequence.Text <> "" Then
            try
            If Not IsNumeric(txtSequence.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtSequence.Text) < -2000000000 Or Val(txtSequence.Text) > 2000000000 Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
            Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtSequence_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSequence.TextChanged
  Changing

end sub
private sub txtTheIcon_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTheIcon.TextChanged
  Changing

end sub
private sub cmbIsReport_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbIsReport.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
        Private Sub txtselectType_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtselectType.Validating
        If txtselectType.Text <> "" Then
            try
            If Not IsNumeric(txtselectType.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtselectType.Text) < -2000000000 Or Val(txtselectType.Text) > 2000000000 Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
            Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtselectType_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtselectType.TextChanged
  Changing

end sub

Public Item As ROLES.ROLES.ROLES2_MODREPORT
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,ROLES.ROLES.ROLES2_MODREPORT)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

txtName.text = item.Name
cmbAllowActionData = New DataTable
cmbAllowActionData.Columns.Add("name", GetType(System.String))
cmbAllowActionData.Columns.Add("Value", GetType(System.Int32))
try
cmbAllowActionDataRow = cmbAllowActionData.NewRow
cmbAllowActionDataRow("name") = "Да"
cmbAllowActionDataRow("Value") = -1
cmbAllowActionData.Rows.Add (cmbAllowActionDataRow)
cmbAllowActionDataRow = cmbAllowActionData.NewRow
cmbAllowActionDataRow("name") = "Нет"
cmbAllowActionDataRow("Value") = 0
cmbAllowActionData.Rows.Add (cmbAllowActionDataRow)
cmbAllowAction.DisplayMember = "name"
cmbAllowAction.ValueMember = "Value"
cmbAllowAction.DataSource = cmbAllowActionData
 cmbAllowAction.SelectedValue=CInt(Item.AllowAction)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
txtCaption.text = item.Caption
txtSequence.text = item.Sequence.toString()
txtTheIcon.text = item.TheIcon
cmbIsReportData = New DataTable
cmbIsReportData.Columns.Add("name", GetType(System.String))
cmbIsReportData.Columns.Add("Value", GetType(System.Int32))
try
cmbIsReportDataRow = cmbIsReportData.NewRow
cmbIsReportDataRow("name") = "Да"
cmbIsReportDataRow("Value") = -1
cmbIsReportData.Rows.Add (cmbIsReportDataRow)
cmbIsReportDataRow = cmbIsReportData.NewRow
cmbIsReportDataRow("name") = "Нет"
cmbIsReportDataRow("Value") = 0
cmbIsReportData.Rows.Add (cmbIsReportDataRow)
cmbIsReport.DisplayMember = "name"
cmbIsReport.ValueMember = "Value"
cmbIsReport.DataSource = cmbIsReportData
 cmbIsReport.SelectedValue=CInt(Item.IsReport)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
txtselectType.text = item.selectType.toString()
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
   item.AllowAction = cmbAllowAction.SelectedValue
item.Caption = txtCaption.text
item.Sequence = val(txtSequence.text)
item.TheIcon = txtTheIcon.text
   item.IsReport = cmbIsReport.SelectedValue
item.selectType = val(txtselectType.text)
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK =( txtName.text <> "" ) 
if mIsOK then mIsOK =(cmbAllowAction.SelectedIndex >=0)
if mIsOK then mIsOK =( txtCaption.text <> "" ) 
if mIsOK then mIsOK =( txtSequence.text <> "" ) 
if mIsOK then mIsOK =(cmbIsReport.SelectedIndex >=0)
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
