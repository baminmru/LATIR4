
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Доступные состояния режим:main
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editROLES_DOC_STATEmain
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
Friend WithEvents lblThe_State  as  System.Windows.Forms.Label
Friend WithEvents txtThe_State As System.Windows.Forms.TextBox
Friend WithEvents cmdThe_State As System.Windows.Forms.Button
Friend WithEvents cmdThe_StateClear As System.Windows.Forms.Button
Friend WithEvents lblThe_Mode  as  System.Windows.Forms.Label
Friend WithEvents txtThe_Mode As System.Windows.Forms.TextBox
Friend WithEvents cmdThe_Mode As System.Windows.Forms.Button
Friend WithEvents cmdThe_ModeClear As System.Windows.Forms.Button
Friend WithEvents lblAllowDelete  as  System.Windows.Forms.Label
Friend WithEvents cmbAllowDelete As System.Windows.Forms.ComboBox
Friend cmbAllowDeleteDATA As DataTable
Friend cmbAllowDeleteDATAROW As DataRow
Friend WithEvents lblStateChangeDisabled  as  System.Windows.Forms.Label
Friend WithEvents cmbStateChangeDisabled As System.Windows.Forms.ComboBox
Friend cmbStateChangeDisabledDATA As DataTable
Friend cmbStateChangeDisabledDATAROW As DataRow

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
Me.lblThe_State = New System.Windows.Forms.Label
Me.txtThe_State = New System.Windows.Forms.TextBox
Me.cmdThe_State = New System.Windows.Forms.Button
Me.cmdThe_StateClear = New System.Windows.Forms.Button
Me.lblThe_Mode = New System.Windows.Forms.Label
Me.txtThe_Mode = New System.Windows.Forms.TextBox
Me.cmdThe_Mode = New System.Windows.Forms.Button
Me.cmdThe_ModeClear = New System.Windows.Forms.Button
Me.lblAllowDelete = New System.Windows.Forms.Label
Me.cmbAllowDelete = New System.Windows.Forms.ComboBox
Me.lblStateChangeDisabled = New System.Windows.Forms.Label
Me.cmbStateChangeDisabled = New System.Windows.Forms.ComboBox

Me.lblThe_State.Location = New System.Drawing.Point(20,5)
Me.lblThe_State.name = "lblThe_State"
Me.lblThe_State.Size = New System.Drawing.Size(200, 20)
Me.lblThe_State.TabIndex = 1
Me.lblThe_State.Text = "Состояние"
Me.lblThe_State.ForeColor = System.Drawing.Color.Blue
Me.txtThe_State.Location = New System.Drawing.Point(20,27)
Me.txtThe_State.name = "txtThe_State"
Me.txtThe_State.ReadOnly = True
Me.txtThe_State.Size = New System.Drawing.Size(155, 20)
Me.txtThe_State.TabIndex = 2
Me.txtThe_State.Text = "" 
Me.cmdThe_State.Location = New System.Drawing.Point(176,27)
Me.cmdThe_State.name = "cmdThe_State"
Me.cmdThe_State.Size = New System.Drawing.Size(22, 20)
Me.cmdThe_State.TabIndex = 3
Me.cmdThe_State.Text = "..." 
Me.cmdThe_StateClear.Location = New System.Drawing.Point(198,27)
Me.cmdThe_StateClear.name = "cmdThe_StateClear"
Me.cmdThe_StateClear.Size = New System.Drawing.Size(22, 20)
Me.cmdThe_StateClear.TabIndex = 4
Me.cmdThe_StateClear.Text = "X" 
Me.lblThe_Mode.Location = New System.Drawing.Point(20,52)
Me.lblThe_Mode.name = "lblThe_Mode"
Me.lblThe_Mode.Size = New System.Drawing.Size(200, 20)
Me.lblThe_Mode.TabIndex = 5
Me.lblThe_Mode.Text = "Режим"
Me.lblThe_Mode.ForeColor = System.Drawing.Color.Blue
Me.txtThe_Mode.Location = New System.Drawing.Point(20,74)
Me.txtThe_Mode.name = "txtThe_Mode"
Me.txtThe_Mode.ReadOnly = True
Me.txtThe_Mode.Size = New System.Drawing.Size(155, 20)
Me.txtThe_Mode.TabIndex = 6
Me.txtThe_Mode.Text = "" 
Me.cmdThe_Mode.Location = New System.Drawing.Point(176,74)
Me.cmdThe_Mode.name = "cmdThe_Mode"
Me.cmdThe_Mode.Size = New System.Drawing.Size(22, 20)
Me.cmdThe_Mode.TabIndex = 7
Me.cmdThe_Mode.Text = "..." 
Me.cmdThe_ModeClear.Location = New System.Drawing.Point(198,74)
Me.cmdThe_ModeClear.name = "cmdThe_ModeClear"
Me.cmdThe_ModeClear.Size = New System.Drawing.Size(22, 20)
Me.cmdThe_ModeClear.TabIndex = 8
Me.cmdThe_ModeClear.Text = "X" 
Me.lblAllowDelete.Location = New System.Drawing.Point(20,99)
Me.lblAllowDelete.name = "lblAllowDelete"
Me.lblAllowDelete.Size = New System.Drawing.Size(200, 20)
Me.lblAllowDelete.TabIndex = 9
Me.lblAllowDelete.Text = "Можно удалять"
Me.lblAllowDelete.ForeColor = System.Drawing.Color.Black
Me.cmbAllowDelete.Location = New System.Drawing.Point(20,121)
Me.cmbAllowDelete.name = "cmbAllowDelete"
Me.cmbAllowDelete.Size = New System.Drawing.Size(200,  20)
Me.cmbAllowDelete.TabIndex = 10
Me.lblStateChangeDisabled.Location = New System.Drawing.Point(20,146)
Me.lblStateChangeDisabled.name = "lblStateChangeDisabled"
Me.lblStateChangeDisabled.Size = New System.Drawing.Size(200, 20)
Me.lblStateChangeDisabled.TabIndex = 11
Me.lblStateChangeDisabled.Text = "Запрещена смена состояния"
Me.lblStateChangeDisabled.ForeColor = System.Drawing.Color.Black
Me.cmbStateChangeDisabled.Location = New System.Drawing.Point(20,168)
Me.cmbStateChangeDisabled.name = "cmbStateChangeDisabled"
Me.cmbStateChangeDisabled.Size = New System.Drawing.Size(200,  20)
Me.cmbStateChangeDisabled.TabIndex = 12
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblThe_State)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtThe_State)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdThe_State)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdThe_StateClear)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblThe_Mode)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtThe_Mode)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdThe_Mode)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdThe_ModeClear)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblAllowDelete)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbAllowDelete)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblStateChangeDisabled)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbStateChangeDisabled)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editROLES_DOC_STATE"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtThe_State_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtThe_State.TextChanged
  Changing

end sub
private sub cmdThe_State_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThe_State.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("OBJSTATUS","",System.guid.Empty, id, brief) Then
          txtThe_State.Tag = id
          txtThe_State.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmdThe_StateClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThe_StateClear.Click
  try
          txtThe_State.Tag = Guid.Empty
          txtThe_State.text = ""
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtThe_Mode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtThe_Mode.TextChanged
  Changing

end sub
private sub cmdThe_Mode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThe_Mode.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("OBJECTMODE","",System.guid.Empty, id, brief) Then
          txtThe_Mode.Tag = id
          txtThe_Mode.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmdThe_ModeClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThe_ModeClear.Click
  try
          txtThe_Mode.Tag = Guid.Empty
          txtThe_Mode.text = ""
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmbAllowDelete_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAllowDelete.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmbStateChangeDisabled_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbStateChangeDisabled.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub

Public Item As ROLES.ROLES.ROLES_DOC_STATE
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,ROLES.ROLES.ROLES_DOC_STATE)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

If Not item.The_State Is Nothing Then
  txtThe_State.Tag = item.The_State.id
  txtThe_State.text = item.The_State.brief
else
  txtThe_State.Tag = System.Guid.Empty 
  txtThe_State.text = "" 
End If
If Not item.The_Mode Is Nothing Then
  txtThe_Mode.Tag = item.The_Mode.id
  txtThe_Mode.text = item.The_Mode.brief
else
  txtThe_Mode.Tag = System.Guid.Empty 
  txtThe_Mode.text = "" 
End If
cmbAllowDeleteData = New DataTable
cmbAllowDeleteData.Columns.Add("name", GetType(System.String))
cmbAllowDeleteData.Columns.Add("Value", GetType(System.Int32))
try
cmbAllowDeleteDataRow = cmbAllowDeleteData.NewRow
cmbAllowDeleteDataRow("name") = "Да"
cmbAllowDeleteDataRow("Value") = -1
cmbAllowDeleteData.Rows.Add (cmbAllowDeleteDataRow)
cmbAllowDeleteDataRow = cmbAllowDeleteData.NewRow
cmbAllowDeleteDataRow("name") = "Нет"
cmbAllowDeleteDataRow("Value") = 0
cmbAllowDeleteData.Rows.Add (cmbAllowDeleteDataRow)
cmbAllowDelete.DisplayMember = "name"
cmbAllowDelete.ValueMember = "Value"
cmbAllowDelete.DataSource = cmbAllowDeleteData
 cmbAllowDelete.SelectedValue=CInt(Item.AllowDelete)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
cmbStateChangeDisabledData = New DataTable
cmbStateChangeDisabledData.Columns.Add("name", GetType(System.String))
cmbStateChangeDisabledData.Columns.Add("Value", GetType(System.Int32))
try
cmbStateChangeDisabledDataRow = cmbStateChangeDisabledData.NewRow
cmbStateChangeDisabledDataRow("name") = "Да"
cmbStateChangeDisabledDataRow("Value") = -1
cmbStateChangeDisabledData.Rows.Add (cmbStateChangeDisabledDataRow)
cmbStateChangeDisabledDataRow = cmbStateChangeDisabledData.NewRow
cmbStateChangeDisabledDataRow("name") = "Нет"
cmbStateChangeDisabledDataRow("Value") = 0
cmbStateChangeDisabledData.Rows.Add (cmbStateChangeDisabledDataRow)
cmbStateChangeDisabled.DisplayMember = "name"
cmbStateChangeDisabled.ValueMember = "Value"
cmbStateChangeDisabled.DataSource = cmbStateChangeDisabledData
 cmbStateChangeDisabled.SelectedValue=CInt(Item.StateChangeDisabled)
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

If not txtThe_State.Tag.Equals(System.Guid.Empty) Then
  item.The_State = Item.Application.FindRowObject("OBJSTATUS",txtThe_State.Tag)
Else
   item.The_State = Nothing
End If
If not txtThe_Mode.Tag.Equals(System.Guid.Empty) Then
  item.The_Mode = Item.Application.FindRowObject("OBJECTMODE",txtThe_Mode.Tag)
Else
   item.The_Mode = Nothing
End If
   item.AllowDelete = cmbAllowDelete.SelectedValue
   item.StateChangeDisabled = cmbStateChangeDisabled.SelectedValue
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK =(cmbAllowDelete.SelectedIndex >=0)
if mIsOK then mIsOK =(cmbStateChangeDisabled.SelectedIndex >=0)
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
