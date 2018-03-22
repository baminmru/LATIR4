
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Доступные действия режим:full
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editROLES_OPERATIONSfull
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
Friend WithEvents lblinfo  as  System.Windows.Forms.Label
Friend WithEvents txtinfo As System.Windows.Forms.TextBox
Friend WithEvents lblAllowAction  as  System.Windows.Forms.Label
Friend WithEvents cmbAllowAction As System.Windows.Forms.ComboBox
Friend cmbAllowActionDATA As DataTable
Friend cmbAllowActionDATAROW As DataRow
Friend WithEvents lblName  as  System.Windows.Forms.Label
Friend WithEvents txtName As System.Windows.Forms.TextBox

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
Me.lblinfo = New System.Windows.Forms.Label
Me.txtinfo = New System.Windows.Forms.TextBox
Me.lblAllowAction = New System.Windows.Forms.Label
Me.cmbAllowAction = New System.Windows.Forms.ComboBox
Me.lblName = New System.Windows.Forms.Label
Me.txtName = New System.Windows.Forms.TextBox

Me.lblinfo.Location = New System.Drawing.Point(20,5)
Me.lblinfo.name = "lblinfo"
Me.lblinfo.Size = New System.Drawing.Size(200, 20)
Me.lblinfo.TabIndex = 1
Me.lblinfo.Text = "Описание"
Me.lblinfo.ForeColor = System.Drawing.Color.Black
Me.txtinfo.Location = New System.Drawing.Point(20,27)
Me.txtinfo.name = "txtinfo"
Me.txtinfo.Size = New System.Drawing.Size(200, 20)
Me.txtinfo.TabIndex = 2
Me.txtinfo.Text = "" 
Me.lblAllowAction.Location = New System.Drawing.Point(20,52)
Me.lblAllowAction.name = "lblAllowAction"
Me.lblAllowAction.Size = New System.Drawing.Size(200, 20)
Me.lblAllowAction.TabIndex = 3
Me.lblAllowAction.Text = "Разрешено"
Me.lblAllowAction.ForeColor = System.Drawing.Color.Black
Me.cmbAllowAction.Location = New System.Drawing.Point(20,74)
Me.cmbAllowAction.name = "cmbAllowAction"
Me.cmbAllowAction.Size = New System.Drawing.Size(200,  20)
Me.cmbAllowAction.TabIndex = 4
Me.lblName.Location = New System.Drawing.Point(20,99)
Me.lblName.name = "lblName"
Me.lblName.Size = New System.Drawing.Size(200, 20)
Me.lblName.TabIndex = 5
Me.lblName.Text = "Код"
Me.lblName.ForeColor = System.Drawing.Color.Black
Me.txtName.Location = New System.Drawing.Point(20,121)
Me.txtName.name = "txtName"
Me.txtName.Size = New System.Drawing.Size(200, 20)
Me.txtName.TabIndex = 6
Me.txtName.Text = "" 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblinfo)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtinfo)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblAllowAction)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbAllowAction)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtName)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editROLES_OPERATIONS"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtinfo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtinfo.TextChanged
  Changing

end sub
private sub cmbAllowAction_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAllowAction.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
  Changing

end sub

Public Item As ROLES.ROLES.ROLES_OPERATIONS
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,ROLES.ROLES.ROLES_OPERATIONS)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

txtinfo.text = item.info
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
txtName.text = item.Name
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

item.info = txtinfo.text
   item.AllowAction = cmbAllowAction.SelectedValue
item.Name = txtName.text
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK =( txtinfo.text <> "" ) 
if mIsOK then mIsOK =(cmbAllowAction.SelectedIndex >=0)
if mIsOK then mIsOK =( txtName.text <> "" ) 
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
