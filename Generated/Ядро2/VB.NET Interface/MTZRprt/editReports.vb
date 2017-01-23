
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Описание режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editReports
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
Friend WithEvents lblReportFile  as  System.Windows.Forms.Label
Friend WithEvents txtReportFile As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblCaption  as  System.Windows.Forms.Label
Friend WithEvents txtCaption As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblPrepareMethod  as  System.Windows.Forms.Label
Friend WithEvents txtPrepareMethod As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdPrepareMethod As System.Windows.Forms.Button
Friend WithEvents cmdPrepareMethodClear As System.Windows.Forms.Button
Friend WithEvents lblReportType  as  System.Windows.Forms.Label
Friend WithEvents cmbReportType As System.Windows.Forms.ComboBox
Friend cmbReportTypeDATA As DataTable
Friend cmbReportTypeDATAROW As DataRow
Friend WithEvents lblTheReportExt  as  System.Windows.Forms.Label
Friend WithEvents txtTheReportExt As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdTheReportExt As System.Windows.Forms.Button
Friend WithEvents cmdTheReportExtClear As System.Windows.Forms.Button
Friend WithEvents lblReportView  as  System.Windows.Forms.Label
Friend WithEvents txtReportView As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblTheComment  as  System.Windows.Forms.Label
Friend WithEvents txtTheComment As LATIR2GuiManager.TouchTextBox

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
Me.lblReportFile = New System.Windows.Forms.Label
Me.txtReportFile = New LATIR2GuiManager.TouchTextBox
Me.lblCaption = New System.Windows.Forms.Label
Me.txtCaption = New LATIR2GuiManager.TouchTextBox
Me.lblPrepareMethod = New System.Windows.Forms.Label
Me.txtPrepareMethod = New LATIR2GuiManager.TouchTextBox
Me.cmdPrepareMethod = New System.Windows.Forms.Button
Me.cmdPrepareMethodClear = New System.Windows.Forms.Button
Me.lblReportType = New System.Windows.Forms.Label
Me.cmbReportType = New System.Windows.Forms.ComboBox
Me.lblTheReportExt = New System.Windows.Forms.Label
Me.txtTheReportExt = New LATIR2GuiManager.TouchTextBox
Me.cmdTheReportExt = New System.Windows.Forms.Button
Me.cmdTheReportExtClear = New System.Windows.Forms.Button
Me.lblReportView = New System.Windows.Forms.Label
Me.txtReportView = New LATIR2GuiManager.TouchTextBox
Me.lblTheComment = New System.Windows.Forms.Label
Me.txtTheComment = New LATIR2GuiManager.TouchTextBox

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
Me.lblReportFile.Location = New System.Drawing.Point(20,52)
Me.lblReportFile.name = "lblReportFile"
Me.lblReportFile.Size = New System.Drawing.Size(200, 20)
Me.lblReportFile.TabIndex = 3
Me.lblReportFile.Text = "Файл отчета"
Me.lblReportFile.ForeColor = System.Drawing.Color.Blue
Me.txtReportFile.Location = New System.Drawing.Point(20,74)
Me.txtReportFile.name = "txtReportFile"
Me.txtReportFile.MultiLine = True
Me.txtReportFile.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtReportFile.Size = New System.Drawing.Size(200, 50 + 20)
Me.txtReportFile.TabIndex = 4
Me.txtReportFile.Text = "" 
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
Me.lblPrepareMethod.Location = New System.Drawing.Point(20,146)
Me.lblPrepareMethod.name = "lblPrepareMethod"
Me.lblPrepareMethod.Size = New System.Drawing.Size(200, 20)
Me.lblPrepareMethod.TabIndex = 7
Me.lblPrepareMethod.Text = "Метод для формирования"
Me.lblPrepareMethod.ForeColor = System.Drawing.Color.Blue
Me.txtPrepareMethod.Location = New System.Drawing.Point(20,168)
Me.txtPrepareMethod.name = "txtPrepareMethod"
Me.txtPrepareMethod.ReadOnly = True
Me.txtPrepareMethod.Size = New System.Drawing.Size(155, 20)
Me.txtPrepareMethod.TabIndex = 8
Me.txtPrepareMethod.Text = "" 
Me.cmdPrepareMethod.Location = New System.Drawing.Point(176,168)
Me.cmdPrepareMethod.name = "cmdPrepareMethod"
Me.cmdPrepareMethod.Size = New System.Drawing.Size(22, 20)
Me.cmdPrepareMethod.TabIndex = 9
Me.cmdPrepareMethod.Text = "..." 
Me.cmdPrepareMethodClear.Location = New System.Drawing.Point(198,168)
Me.cmdPrepareMethodClear.name = "cmdPrepareMethodClear"
Me.cmdPrepareMethodClear.Size = New System.Drawing.Size(22, 20)
Me.cmdPrepareMethodClear.TabIndex = 10
Me.cmdPrepareMethodClear.Text = "X" 
Me.lblReportType.Location = New System.Drawing.Point(20,193)
Me.lblReportType.name = "lblReportType"
Me.lblReportType.Size = New System.Drawing.Size(200, 20)
Me.lblReportType.TabIndex = 11
Me.lblReportType.Text = "Тип отчета"
Me.lblReportType.ForeColor = System.Drawing.Color.Black
Me.cmbReportType.Location = New System.Drawing.Point(20,215)
Me.cmbReportType.name = "cmbReportType"
Me.cmbReportType.Size = New System.Drawing.Size(200,  20)
Me.cmbReportType.TabIndex = 12
Me.cmbReportType.DropDownStyle = ComboBoxStyle.DropDownList
Me.lblTheReportExt.Location = New System.Drawing.Point(20,240)
Me.lblTheReportExt.name = "lblTheReportExt"
Me.lblTheReportExt.Size = New System.Drawing.Size(200, 20)
Me.lblTheReportExt.TabIndex = 13
Me.lblTheReportExt.Text = "Расширение для создания отчета"
Me.lblTheReportExt.ForeColor = System.Drawing.Color.Blue
Me.txtTheReportExt.Location = New System.Drawing.Point(20,262)
Me.txtTheReportExt.name = "txtTheReportExt"
Me.txtTheReportExt.ReadOnly = True
Me.txtTheReportExt.Size = New System.Drawing.Size(155, 20)
Me.txtTheReportExt.TabIndex = 14
Me.txtTheReportExt.Text = "" 
Me.cmdTheReportExt.Location = New System.Drawing.Point(176,262)
Me.cmdTheReportExt.name = "cmdTheReportExt"
Me.cmdTheReportExt.Size = New System.Drawing.Size(22, 20)
Me.cmdTheReportExt.TabIndex = 15
Me.cmdTheReportExt.Text = "..." 
Me.cmdTheReportExtClear.Location = New System.Drawing.Point(198,262)
Me.cmdTheReportExtClear.name = "cmdTheReportExtClear"
Me.cmdTheReportExtClear.Size = New System.Drawing.Size(22, 20)
Me.cmdTheReportExtClear.TabIndex = 16
Me.cmdTheReportExtClear.Text = "X" 
Me.lblReportView.Location = New System.Drawing.Point(20,287)
Me.lblReportView.name = "lblReportView"
Me.lblReportView.Size = New System.Drawing.Size(200, 20)
Me.lblReportView.TabIndex = 17
Me.lblReportView.Text = "Базовый запрос"
Me.lblReportView.ForeColor = System.Drawing.Color.Blue
Me.txtReportView.Location = New System.Drawing.Point(20,309)
Me.txtReportView.name = "txtReportView"
Me.txtReportView.Size = New System.Drawing.Size(200, 20)
Me.txtReportView.TabIndex = 18
Me.txtReportView.Text = "" 
Me.lblTheComment.Location = New System.Drawing.Point(20,334)
Me.lblTheComment.name = "lblTheComment"
Me.lblTheComment.Size = New System.Drawing.Size(200, 20)
Me.lblTheComment.TabIndex = 19
Me.lblTheComment.Text = "Описание"
Me.lblTheComment.ForeColor = System.Drawing.Color.Blue
Me.txtTheComment.Location = New System.Drawing.Point(20,356)
Me.txtTheComment.name = "txtTheComment"
Me.txtTheComment.MultiLine = True
Me.txtTheComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtTheComment.Size = New System.Drawing.Size(200, 50 + 20)
Me.txtTheComment.TabIndex = 20
Me.txtTheComment.Text = "" 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblReportFile)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtReportFile)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblCaption)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtCaption)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblPrepareMethod)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtPrepareMethod)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdPrepareMethod)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdPrepareMethodClear)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblReportType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbReportType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTheReportExt)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTheReportExt)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdTheReportExt)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdTheReportExtClear)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblReportView)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtReportView)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTheComment)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTheComment)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editReports"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
  Changing

end sub
private sub txtReportFile_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtReportFile.TextChanged
  Changing

end sub
private sub txtCaption_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCaption.TextChanged
  Changing

end sub
private sub txtPrepareMethod_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPrepareMethod.TextChanged
  Changing

end sub
private sub cmdPrepareMethod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrepareMethod.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("SHAREDMETHOD","",System.guid.Empty, id, brief) Then
          txtPrepareMethod.Tag = id
          txtPrepareMethod.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmdPrepareMethodClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrepareMethodClear.Click
  try
          txtPrepareMethod.Tag = Guid.Empty
          txtPrepareMethod.text = ""
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmbReportType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbReportType.SelectedIndexChanged
  try
     Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtTheReportExt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTheReportExt.TextChanged
  Changing

end sub
private sub cmdTheReportExt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTheReportExt.Click
  try
Dim id As guid
Dim brief As String  = string.Empty
Dim OK as boolean
       OK=GuiManager.GetObjectDialog("MTZExt","",id,brief)
If OK Then
    txtTheReportExt.Text = brief
    txtTheReportExt.Tag = id
End If
        catch ex as system.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
End Sub
private sub txtReportView_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtReportView.TextChanged
  Changing

end sub
private sub txtTheComment_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTheComment.TextChanged
  Changing

end sub

Public Item As MTZRprt.MTZRprt.Reports
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,MTZRprt.MTZRprt.Reports)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

txtName.text = item.Name
txtReportFile.text = item.ReportFile
txtCaption.text = item.Caption
If Not item.PrepareMethod Is Nothing Then
  txtPrepareMethod.Tag = item.PrepareMethod.id
  txtPrepareMethod.text = item.PrepareMethod.brief
else
  txtPrepareMethod.Tag = System.Guid.Empty 
  txtPrepareMethod.text = "" 
End If
cmbReportTypeData = New DataTable
cmbReportTypeData.Columns.Add("name", GetType(System.String))
cmbReportTypeData.Columns.Add("Value", GetType(System.Int32))
try
cmbReportTypeDataRow = cmbReportTypeData.NewRow
cmbReportTypeDataRow("name") = "Таблица"
cmbReportTypeDataRow("Value") = 0
cmbReportTypeData.Rows.Add (cmbReportTypeDataRow)
cmbReportTypeDataRow = cmbReportTypeData.NewRow
cmbReportTypeDataRow("name") = "Двумерная матрица"
cmbReportTypeDataRow("Value") = 1
cmbReportTypeData.Rows.Add (cmbReportTypeDataRow)
cmbReportTypeDataRow = cmbReportTypeData.NewRow
cmbReportTypeDataRow("name") = "Только расчет"
cmbReportTypeDataRow("Value") = 2
cmbReportTypeData.Rows.Add (cmbReportTypeDataRow)
cmbReportTypeDataRow = cmbReportTypeData.NewRow
cmbReportTypeDataRow("name") = "Экспорт по WORD шаблону"
cmbReportTypeDataRow("Value") = 3
cmbReportTypeData.Rows.Add (cmbReportTypeDataRow)
cmbReportTypeDataRow = cmbReportTypeData.NewRow
cmbReportTypeDataRow("name") = "Экспорт по Excel шаблону"
cmbReportTypeDataRow("Value") = 4
cmbReportTypeData.Rows.Add (cmbReportTypeDataRow)
cmbReportType.DisplayMember = "name"
cmbReportType.ValueMember = "Value"
cmbReportType.DataSource = cmbReportTypeData
 cmbReportType.SelectedValue=CInt(Item.ReportType)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
If Not item.TheReportExt Is Nothing Then
  txtTheReportExt.Tag = item.TheReportExt.id
  txtTheReportExt.text = item.TheReportExt.brief
else
  txtTheReportExt.Tag = System.Guid.Empty 
  txtTheReportExt.text = "" 
End If
txtReportView.text = item.ReportView
txtTheComment.text = item.TheComment
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
item.ReportFile = txtReportFile.text
item.Caption = txtCaption.text
If not txtPrepareMethod.Tag.Equals(System.Guid.Empty) Then
  item.PrepareMethod = Item.Application.FindRowObject("SHAREDMETHOD",txtPrepareMethod.Tag)
Else
   item.PrepareMethod = Nothing
End If
   item.ReportType = cmbReportType.SelectedValue
If not txtTheReportExt.Tag.Equals(System.Guid.Empty) Then
   item.TheReportExt = GuiManager.Manager.GetInstanceObject(txtTheReportExt.Tag)
Else
   item.TheReportExt = Nothing
End If
item.ReportView = txtReportView.text
item.TheComment = txtTheComment.text
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK =( txtName.text <> "" ) 
if mIsOK then mIsOK =(cmbReportType.SelectedIndex >=0)
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
