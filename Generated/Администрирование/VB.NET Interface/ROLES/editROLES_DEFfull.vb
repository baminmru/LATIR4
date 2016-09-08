
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Определение роли режим:full
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editROLES_DEFfull
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
Friend WithEvents lblname  as  System.Windows.Forms.Label
Friend WithEvents txtname As System.Windows.Forms.TextBox
Friend WithEvents lblAllObjects  as  System.Windows.Forms.Label
Friend WithEvents cmbAllObjects As System.Windows.Forms.ComboBox
Friend cmbAllObjectsDATA As DataTable
Friend cmbAllObjectsDATAROW As DataRow
Friend WithEvents lblColegsObject  as  System.Windows.Forms.Label
Friend WithEvents cmbColegsObject As System.Windows.Forms.ComboBox
Friend cmbColegsObjectDATA As DataTable
Friend cmbColegsObjectDATAROW As DataRow
Friend WithEvents lblSubStructObjects  as  System.Windows.Forms.Label
Friend WithEvents cmbSubStructObjects As System.Windows.Forms.ComboBox
Friend cmbSubStructObjectsDATA As DataTable
Friend cmbSubStructObjectsDATAROW As DataRow

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
Me.lblname = New System.Windows.Forms.Label
Me.txtname = New System.Windows.Forms.TextBox
Me.lblAllObjects = New System.Windows.Forms.Label
Me.cmbAllObjects = New System.Windows.Forms.ComboBox
Me.lblColegsObject = New System.Windows.Forms.Label
Me.cmbColegsObject = New System.Windows.Forms.ComboBox
Me.lblSubStructObjects = New System.Windows.Forms.Label
Me.cmbSubStructObjects = New System.Windows.Forms.ComboBox

Me.lblname.Location = New System.Drawing.Point(20,5)
Me.lblname.name = "lblname"
Me.lblname.Size = New System.Drawing.Size(200, 20)
Me.lblname.TabIndex = 1
Me.lblname.Text = "Название"
Me.lblname.ForeColor = System.Drawing.Color.Black
Me.txtname.Location = New System.Drawing.Point(20,27)
Me.txtname.name = "txtname"
Me.txtname.Size = New System.Drawing.Size(200, 20)
Me.txtname.TabIndex = 2
Me.txtname.Text = "" 
Me.lblAllObjects.Location = New System.Drawing.Point(20,52)
Me.lblAllObjects.name = "lblAllObjects"
Me.lblAllObjects.Size = New System.Drawing.Size(200, 20)
Me.lblAllObjects.TabIndex = 3
Me.lblAllObjects.Text = "Вся фирма"
Me.lblAllObjects.ForeColor = System.Drawing.Color.Black
Me.cmbAllObjects.Location = New System.Drawing.Point(20,74)
Me.cmbAllObjects.name = "cmbAllObjects"
Me.cmbAllObjects.Size = New System.Drawing.Size(200,  20)
Me.cmbAllObjects.TabIndex = 4
Me.lblColegsObject.Location = New System.Drawing.Point(20,99)
Me.lblColegsObject.name = "lblColegsObject"
Me.lblColegsObject.Size = New System.Drawing.Size(200, 20)
Me.lblColegsObject.TabIndex = 5
Me.lblColegsObject.Text = "Объекты коллег"
Me.lblColegsObject.ForeColor = System.Drawing.Color.Black
Me.cmbColegsObject.Location = New System.Drawing.Point(20,121)
Me.cmbColegsObject.name = "cmbColegsObject"
Me.cmbColegsObject.Size = New System.Drawing.Size(200,  20)
Me.cmbColegsObject.TabIndex = 6
Me.lblSubStructObjects.Location = New System.Drawing.Point(20,146)
Me.lblSubStructObjects.name = "lblSubStructObjects"
Me.lblSubStructObjects.Size = New System.Drawing.Size(200, 20)
Me.lblSubStructObjects.TabIndex = 7
Me.lblSubStructObjects.Text = "Подчиненные подразделения"
Me.lblSubStructObjects.ForeColor = System.Drawing.Color.Black
Me.cmbSubStructObjects.Location = New System.Drawing.Point(20,168)
Me.cmbSubStructObjects.name = "cmbSubStructObjects"
Me.cmbSubStructObjects.Size = New System.Drawing.Size(200,  20)
Me.cmbSubStructObjects.TabIndex = 8
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblname)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtname)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblAllObjects)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbAllObjects)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblColegsObject)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbColegsObject)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblSubStructObjects)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbSubStructObjects)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editROLES_DEF"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtname_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtname.TextChanged
  Changing

end sub
private sub cmbAllObjects_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAllObjects.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmbColegsObject_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbColegsObject.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmbSubStructObjects_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSubStructObjects.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub

Public Item As ROLES.ROLES.ROLES_DEF
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,ROLES.ROLES.ROLES_DEF)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

txtname.text = item.name
cmbAllObjectsData = New DataTable
cmbAllObjectsData.Columns.Add("name", GetType(System.String))
cmbAllObjectsData.Columns.Add("Value", GetType(System.Int32))
try
cmbAllObjectsDataRow = cmbAllObjectsData.NewRow
cmbAllObjectsDataRow("name") = "Да"
cmbAllObjectsDataRow("Value") = -1
cmbAllObjectsData.Rows.Add (cmbAllObjectsDataRow)
cmbAllObjectsDataRow = cmbAllObjectsData.NewRow
cmbAllObjectsDataRow("name") = "Нет"
cmbAllObjectsDataRow("Value") = 0
cmbAllObjectsData.Rows.Add (cmbAllObjectsDataRow)
cmbAllObjects.DisplayMember = "name"
cmbAllObjects.ValueMember = "Value"
cmbAllObjects.DataSource = cmbAllObjectsData
 cmbAllObjects.SelectedValue=CInt(Item.AllObjects)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
cmbColegsObjectData = New DataTable
cmbColegsObjectData.Columns.Add("name", GetType(System.String))
cmbColegsObjectData.Columns.Add("Value", GetType(System.Int32))
try
cmbColegsObjectDataRow = cmbColegsObjectData.NewRow
cmbColegsObjectDataRow("name") = "Да"
cmbColegsObjectDataRow("Value") = -1
cmbColegsObjectData.Rows.Add (cmbColegsObjectDataRow)
cmbColegsObjectDataRow = cmbColegsObjectData.NewRow
cmbColegsObjectDataRow("name") = "Нет"
cmbColegsObjectDataRow("Value") = 0
cmbColegsObjectData.Rows.Add (cmbColegsObjectDataRow)
cmbColegsObject.DisplayMember = "name"
cmbColegsObject.ValueMember = "Value"
cmbColegsObject.DataSource = cmbColegsObjectData
 cmbColegsObject.SelectedValue=CInt(Item.ColegsObject)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
cmbSubStructObjectsData = New DataTable
cmbSubStructObjectsData.Columns.Add("name", GetType(System.String))
cmbSubStructObjectsData.Columns.Add("Value", GetType(System.Int32))
try
cmbSubStructObjectsDataRow = cmbSubStructObjectsData.NewRow
cmbSubStructObjectsDataRow("name") = "Да"
cmbSubStructObjectsDataRow("Value") = -1
cmbSubStructObjectsData.Rows.Add (cmbSubStructObjectsDataRow)
cmbSubStructObjectsDataRow = cmbSubStructObjectsData.NewRow
cmbSubStructObjectsDataRow("name") = "Нет"
cmbSubStructObjectsDataRow("Value") = 0
cmbSubStructObjectsData.Rows.Add (cmbSubStructObjectsDataRow)
cmbSubStructObjects.DisplayMember = "name"
cmbSubStructObjects.ValueMember = "Value"
cmbSubStructObjects.DataSource = cmbSubStructObjectsData
 cmbSubStructObjects.SelectedValue=CInt(Item.SubStructObjects)
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

item.name = txtname.text
   item.AllObjects = cmbAllObjects.SelectedValue
   item.ColegsObject = cmbColegsObject.SelectedValue
   item.SubStructObjects = cmbSubStructObjects.SelectedValue
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK =( txtname.text <> "" ) 
if mIsOK then mIsOK =(cmbAllObjects.SelectedIndex >=0)
if mIsOK then mIsOK =(cmbColegsObject.SelectedIndex >=0)
if mIsOK then mIsOK =(cmbSubStructObjects.SelectedIndex >=0)
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
