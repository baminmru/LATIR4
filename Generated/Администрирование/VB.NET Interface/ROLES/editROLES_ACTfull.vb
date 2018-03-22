
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Разрешенные пункты меню режим:full
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editROLES_ACTfull
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
Friend WithEvents lblAccesible  as  System.Windows.Forms.Label
Friend WithEvents cmbAccesible As System.Windows.Forms.ComboBox
Friend cmbAccesibleDATA As DataTable
Friend cmbAccesibleDATAROW As DataRow
Friend WithEvents lblMenuName  as  System.Windows.Forms.Label
Friend WithEvents txtMenuName As System.Windows.Forms.TextBox
Friend WithEvents lblmenuCode  as  System.Windows.Forms.Label
Friend WithEvents txtmenuCode As System.Windows.Forms.TextBox

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
Me.lblAccesible = New System.Windows.Forms.Label
Me.cmbAccesible = New System.Windows.Forms.ComboBox
Me.lblMenuName = New System.Windows.Forms.Label
Me.txtMenuName = New System.Windows.Forms.TextBox
Me.lblmenuCode = New System.Windows.Forms.Label
Me.txtmenuCode = New System.Windows.Forms.TextBox

Me.lblAccesible.Location = New System.Drawing.Point(20,5)
Me.lblAccesible.name = "lblAccesible"
Me.lblAccesible.Size = New System.Drawing.Size(200, 20)
Me.lblAccesible.TabIndex = 1
Me.lblAccesible.Text = "Доступность"
Me.lblAccesible.ForeColor = System.Drawing.Color.Blue
Me.cmbAccesible.Location = New System.Drawing.Point(20,27)
Me.cmbAccesible.name = "cmbAccesible"
Me.cmbAccesible.Size = New System.Drawing.Size(200,  20)
Me.cmbAccesible.TabIndex = 2
Me.lblMenuName.Location = New System.Drawing.Point(20,52)
Me.lblMenuName.name = "lblMenuName"
Me.lblMenuName.Size = New System.Drawing.Size(200, 20)
Me.lblMenuName.TabIndex = 3
Me.lblMenuName.Text = "Меню"
Me.lblMenuName.ForeColor = System.Drawing.Color.Black
Me.txtMenuName.Location = New System.Drawing.Point(20,74)
Me.txtMenuName.name = "txtMenuName"
Me.txtMenuName.Size = New System.Drawing.Size(200, 20)
Me.txtMenuName.TabIndex = 4
Me.txtMenuName.Text = "" 
Me.lblmenuCode.Location = New System.Drawing.Point(20,99)
Me.lblmenuCode.name = "lblmenuCode"
Me.lblmenuCode.Size = New System.Drawing.Size(200, 20)
Me.lblmenuCode.TabIndex = 5
Me.lblmenuCode.Text = "Код пункта меню"
Me.lblmenuCode.ForeColor = System.Drawing.Color.Black
Me.txtmenuCode.Location = New System.Drawing.Point(20,121)
Me.txtmenuCode.name = "txtmenuCode"
Me.txtmenuCode.Size = New System.Drawing.Size(200, 20)
Me.txtmenuCode.TabIndex = 6
Me.txtmenuCode.Text = "" 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblAccesible)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbAccesible)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblMenuName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtMenuName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblmenuCode)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtmenuCode)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editROLES_ACT"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub cmbAccesible_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAccesible.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtMenuName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMenuName.TextChanged
  Changing

end sub
private sub txtmenuCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtmenuCode.TextChanged
  Changing

end sub

Public Item As ROLES.ROLES.ROLES_ACT
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,ROLES.ROLES.ROLES_ACT)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

cmbAccesibleData = New DataTable
cmbAccesibleData.Columns.Add("name", GetType(System.String))
cmbAccesibleData.Columns.Add("Value", GetType(System.Int32))
try
cmbAccesibleDataRow = cmbAccesibleData.NewRow
cmbAccesibleDataRow("name") = "Нет"
cmbAccesibleDataRow("Value") = 0
cmbAccesibleData.Rows.Add (cmbAccesibleDataRow)
cmbAccesibleDataRow = cmbAccesibleData.NewRow
cmbAccesibleDataRow("name") = "Да"
cmbAccesibleDataRow("Value") = 1
cmbAccesibleData.Rows.Add (cmbAccesibleDataRow)
cmbAccesible.DisplayMember = "name"
cmbAccesible.ValueMember = "Value"
cmbAccesible.DataSource = cmbAccesibleData
 cmbAccesible.SelectedValue=CInt(Item.Accesible)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
txtMenuName.text = item.MenuName
txtmenuCode.text = item.menuCode
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

   item.Accesible = cmbAccesible.SelectedValue
item.MenuName = txtMenuName.text
item.menuCode = txtmenuCode.text
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK =( txtMenuName.text <> "" ) 
if mIsOK then mIsOK =( txtmenuCode.text <> "" ) 
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
