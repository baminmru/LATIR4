
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Отложенное событие режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editMTZ2JOB_DEF
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
Friend WithEvents lblEventDate  as  System.Windows.Forms.Label
Friend WithEvents dtpEventDate As System.Windows.Forms.DateTimePicker
Friend WithEvents lblEvenType  as  System.Windows.Forms.Label
Friend WithEvents txtEvenType As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblThruObject  as  System.Windows.Forms.Label
Friend WithEvents txtThruObject As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdThruObject As System.Windows.Forms.Button
Friend WithEvents lblThruState  as  System.Windows.Forms.Label
Friend WithEvents txtThruState As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblNextState  as  System.Windows.Forms.Label
Friend WithEvents txtNextState As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblProcessDate  as  System.Windows.Forms.Label
Friend WithEvents dtpProcessDate As System.Windows.Forms.DateTimePicker
Friend WithEvents lblProcessed  as  System.Windows.Forms.Label
Friend WithEvents cmbProcessed As System.Windows.Forms.ComboBox
Friend cmbProcessedDATA As DataTable
Friend cmbProcessedDATAROW As DataRow

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
Me.lblEventDate = New System.Windows.Forms.Label
Me.dtpEventDate = New System.Windows.Forms.DateTimePicker
Me.lblEvenType = New System.Windows.Forms.Label
Me.txtEvenType = New LATIR2GuiManager.TouchTextBox
Me.lblThruObject = New System.Windows.Forms.Label
Me.txtThruObject = New LATIR2GuiManager.TouchTextBox
Me.cmdThruObject = New System.Windows.Forms.Button
Me.lblThruState = New System.Windows.Forms.Label
Me.txtThruState = New LATIR2GuiManager.TouchTextBox
Me.lblNextState = New System.Windows.Forms.Label
Me.txtNextState = New LATIR2GuiManager.TouchTextBox
Me.lblProcessDate = New System.Windows.Forms.Label
Me.dtpProcessDate = New System.Windows.Forms.DateTimePicker
Me.lblProcessed = New System.Windows.Forms.Label
Me.cmbProcessed = New System.Windows.Forms.ComboBox

Me.lblEventDate.Location = New System.Drawing.Point(20,5)
Me.lblEventDate.name = "lblEventDate"
Me.lblEventDate.Size = New System.Drawing.Size(200, 20)
Me.lblEventDate.TabIndex = 1
Me.lblEventDate.Text = "Отложено до"
Me.lblEventDate.ForeColor = System.Drawing.Color.Black
Me.dtpEventDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
Me.dtpEventDate.Location = New System.Drawing.Point(20,27)
Me.dtpEventDate.name = "dtpEventDate"
Me.dtpEventDate.Size = New System.Drawing.Size(200,  20)
Me.dtpEventDate.TabIndex =2
Me.dtpEventDate.CustomFormat = "dd/MM/yyyy HH:mm:ss"
Me.dtpEventDate.ShowCheckBox=False
Me.lblEvenType.Location = New System.Drawing.Point(20,52)
Me.lblEvenType.name = "lblEvenType"
Me.lblEvenType.Size = New System.Drawing.Size(200, 20)
Me.lblEvenType.TabIndex = 3
Me.lblEvenType.Text = "Тип события"
Me.lblEvenType.ForeColor = System.Drawing.Color.Black
Me.txtEvenType.Location = New System.Drawing.Point(20,74)
Me.txtEvenType.name = "txtEvenType"
Me.txtEvenType.Size = New System.Drawing.Size(200, 20)
Me.txtEvenType.TabIndex = 4
Me.txtEvenType.Text = "" 
Me.lblThruObject.Location = New System.Drawing.Point(20,99)
Me.lblThruObject.name = "lblThruObject"
Me.lblThruObject.Size = New System.Drawing.Size(200, 20)
Me.lblThruObject.TabIndex = 5
Me.lblThruObject.Text = "Объект - причина события"
Me.lblThruObject.ForeColor = System.Drawing.Color.Black
Me.txtThruObject.Location = New System.Drawing.Point(20,121)
Me.txtThruObject.name = "txtThruObject"
Me.txtThruObject.ReadOnly = True
Me.txtThruObject.Size = New System.Drawing.Size(176, 20)
Me.txtThruObject.TabIndex = 6
Me.txtThruObject.Text = "" 
Me.cmdThruObject.Location = New System.Drawing.Point(198,121)
Me.cmdThruObject.name = "cmdThruObject"
Me.cmdThruObject.Size = New System.Drawing.Size(22, 20)
Me.cmdThruObject.TabIndex = 7
Me.cmdThruObject.Text = "..." 
Me.lblThruState.Location = New System.Drawing.Point(20,146)
Me.lblThruState.name = "lblThruState"
Me.lblThruState.Size = New System.Drawing.Size(200, 20)
Me.lblThruState.TabIndex = 8
Me.lblThruState.Text = "Состояние - причина"
Me.lblThruState.ForeColor = System.Drawing.Color.Blue
Me.txtThruState.Location = New System.Drawing.Point(20,168)
Me.txtThruState.name = "txtThruState"
Me.txtThruState.Size = New System.Drawing.Size(200, 20)
Me.txtThruState.TabIndex = 9
Me.txtThruState.Text = "" 
Me.lblNextState.Location = New System.Drawing.Point(20,193)
Me.lblNextState.name = "lblNextState"
Me.lblNextState.Size = New System.Drawing.Size(200, 20)
Me.lblNextState.TabIndex = 10
Me.lblNextState.Text = "Состояние после обработки"
Me.lblNextState.ForeColor = System.Drawing.Color.Blue
Me.txtNextState.Location = New System.Drawing.Point(20,215)
Me.txtNextState.name = "txtNextState"
Me.txtNextState.Size = New System.Drawing.Size(200, 20)
Me.txtNextState.TabIndex = 11
Me.txtNextState.Text = "" 
Me.lblProcessDate.Location = New System.Drawing.Point(20,240)
Me.lblProcessDate.name = "lblProcessDate"
Me.lblProcessDate.Size = New System.Drawing.Size(200, 20)
Me.lblProcessDate.TabIndex = 12
Me.lblProcessDate.Text = "Момент обработки"
Me.lblProcessDate.ForeColor = System.Drawing.Color.Blue
Me.dtpProcessDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
Me.dtpProcessDate.Location = New System.Drawing.Point(20,262)
Me.dtpProcessDate.name = "dtpProcessDate"
Me.dtpProcessDate.Size = New System.Drawing.Size(200,  20)
Me.dtpProcessDate.TabIndex =13
Me.dtpProcessDate.CustomFormat = "dd/MM/yyyy HH:mm:ss"
Me.dtpProcessDate.ShowCheckBox=True
Me.lblProcessed.Location = New System.Drawing.Point(20,287)
Me.lblProcessed.name = "lblProcessed"
Me.lblProcessed.Size = New System.Drawing.Size(200, 20)
Me.lblProcessed.TabIndex = 14
Me.lblProcessed.Text = "Обработан"
Me.lblProcessed.ForeColor = System.Drawing.Color.Black
Me.cmbProcessed.Location = New System.Drawing.Point(20,309)
Me.cmbProcessed.name = "cmbProcessed"
Me.cmbProcessed.Size = New System.Drawing.Size(200,  20)
Me.cmbProcessed.TabIndex = 15
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblEventDate)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.dtpEventDate)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblEvenType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtEvenType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblThruObject)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtThruObject)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdThruObject)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblThruState)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtThruState)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblNextState)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtNextState)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblProcessDate)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.dtpProcessDate)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblProcessed)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbProcessed)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editMTZ2JOB_DEF"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub dtpEventDate_Change(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpEventDate.ValueChanged
  Changing 

end sub
private sub txtEvenType_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEvenType.TextChanged
  Changing

end sub
private sub txtThruObject_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtThruObject.TextChanged
  Changing

end sub
private sub cmdThruObject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThruObject.Click
  try
Dim id As guid
Dim brief As String  = string.Empty
Dim OK as boolean
        OK=GuiManager.GetObjectDialog("","",id,brief)
If OK Then
    txtThruObject.Text = brief
    txtThruObject.Tag = id
End If
        catch ex as system.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
End Sub
private sub txtThruState_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtThruState.TextChanged
  Changing

end sub
private sub txtNextState_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNextState.TextChanged
  Changing

end sub
private sub dtpProcessDate_Change(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpProcessDate.ValueChanged
  Changing 

end sub
private sub cmbProcessed_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProcessed.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub

Public Item As MTZ2JOB.MTZ2JOB.MTZ2JOB_DEF
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,MTZ2JOB.MTZ2JOB.MTZ2JOB_DEF)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

dtpEventDate.value = System.DateTime.Now
if item.EventDate <> System.DateTime.MinValue then
  try
     dtpEventDate.value = item.EventDate
  catch
   dtpEventDate.value = System.DateTime.MinValue
  end try
end if
txtEvenType.text = item.EvenType
If Not item.ThruObject Is Nothing Then
  txtThruObject.Tag = item.ThruObject.id
  txtThruObject.text = item.ThruObject.brief
else
  txtThruObject.Tag = System.Guid.Empty 
  txtThruObject.text = "" 
End If
txtThruState.text = item.ThruState.ToString()
txtNextState.text = item.NextState.ToString()
dtpProcessDate.value = System.DateTime.Now
if item.ProcessDate <> System.DateTime.MinValue then
  try
     dtpProcessDate.value = item.ProcessDate
  catch
   dtpProcessDate.value = System.DateTime.MinValue
  end try
else
   dtpProcessDate.value = System.DateTime.Today
   dtpProcessDate.Checked =false
end if
cmbProcessedData = New DataTable
cmbProcessedData.Columns.Add("name", GetType(System.String))
cmbProcessedData.Columns.Add("Value", GetType(System.Int32))
try
cmbProcessedDataRow = cmbProcessedData.NewRow
cmbProcessedDataRow("name") = "Да"
cmbProcessedDataRow("Value") = -1
cmbProcessedData.Rows.Add (cmbProcessedDataRow)
cmbProcessedDataRow = cmbProcessedData.NewRow
cmbProcessedDataRow("name") = "Нет"
cmbProcessedDataRow("Value") = 0
cmbProcessedData.Rows.Add (cmbProcessedDataRow)
cmbProcessed.DisplayMember = "name"
cmbProcessed.ValueMember = "Value"
cmbProcessed.DataSource = cmbProcessedData
 cmbProcessed.SelectedValue=CInt(Item.Processed)
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

  try
    item.EventDate = dtpEventDate.value
  catch
    item.EventDate = System.DateTime.MinValue
  end try
item.EvenType = txtEvenType.text
If not txtThruObject.Tag.Equals(System.Guid.Empty) Then
   item.ThruObject = GuiManager.Manager.GetInstanceObject(txtThruObject.Tag)
Else
   item.ThruObject = Nothing
End If
item.ThruState = new System.Guid(txtThruState.text)
item.NextState = new System.Guid(txtNextState.text)
  if dtpProcessDate.checked=false then
       item.ProcessDate = System.DateTime.MinValue
  else 
  try
    item.ProcessDate = dtpProcessDate.value
  catch
    item.ProcessDate = System.DateTime.MinValue
  end try
  end if
   item.Processed = cmbProcessed.SelectedValue
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK = (dtpEventDate.value <> System.DateTime.MinValue)
if mIsOK then mIsOK =( txtEvenType.text <> "" ) 
if mIsOK then mIsOK = not txtThruObject.Tag.Equals(System.Guid.Empty)
if mIsOK then mIsOK =(cmbProcessed.SelectedIndex >=0)
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
