
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Органичения разделов режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editSTRUCTRESTRICTION
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
Friend WithEvents lblStruct  as  System.Windows.Forms.Label
Friend WithEvents txtStruct As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdStruct As System.Windows.Forms.Button
Friend WithEvents lblAllowRead  as  System.Windows.Forms.Label
Friend WithEvents cmbAllowRead As System.Windows.Forms.ComboBox
Friend cmbAllowReadDATA As DataTable
Friend cmbAllowReadDATAROW As DataRow
Friend WithEvents lblAllowAdd  as  System.Windows.Forms.Label
Friend WithEvents cmbAllowAdd As System.Windows.Forms.ComboBox
Friend cmbAllowAddDATA As DataTable
Friend cmbAllowAddDATAROW As DataRow
Friend WithEvents lblAllowEdit  as  System.Windows.Forms.Label
Friend WithEvents cmbAllowEdit As System.Windows.Forms.ComboBox
Friend cmbAllowEditDATA As DataTable
Friend cmbAllowEditDATAROW As DataRow
Friend WithEvents lblAllowDelete  as  System.Windows.Forms.Label
Friend WithEvents cmbAllowDelete As System.Windows.Forms.ComboBox
Friend cmbAllowDeleteDATA As DataTable
Friend cmbAllowDeleteDATAROW As DataRow

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
Me.lblStruct = New System.Windows.Forms.Label
Me.txtStruct = New LATIR2GuiManager.TouchTextBox
Me.cmdStruct = New System.Windows.Forms.Button
Me.lblAllowRead = New System.Windows.Forms.Label
Me.cmbAllowRead = New System.Windows.Forms.ComboBox
Me.lblAllowAdd = New System.Windows.Forms.Label
Me.cmbAllowAdd = New System.Windows.Forms.ComboBox
Me.lblAllowEdit = New System.Windows.Forms.Label
Me.cmbAllowEdit = New System.Windows.Forms.ComboBox
Me.lblAllowDelete = New System.Windows.Forms.Label
Me.cmbAllowDelete = New System.Windows.Forms.ComboBox

Me.lblStruct.Location = New System.Drawing.Point(20,5)
Me.lblStruct.name = "lblStruct"
Me.lblStruct.Size = New System.Drawing.Size(200, 20)
Me.lblStruct.TabIndex = 1
Me.lblStruct.Text = "структура, доступ к которой ограничен"
Me.lblStruct.ForeColor = System.Drawing.Color.Black
Me.txtStruct.Location = New System.Drawing.Point(20,27)
Me.txtStruct.name = "txtStruct"
Me.txtStruct.ReadOnly = True
Me.txtStruct.Size = New System.Drawing.Size(176, 20)
Me.txtStruct.TabIndex = 2
Me.txtStruct.Text = "" 
Me.cmdStruct.Location = New System.Drawing.Point(198,27)
Me.cmdStruct.name = "cmdStruct"
Me.cmdStruct.Size = New System.Drawing.Size(22, 20)
Me.cmdStruct.TabIndex = 3
Me.cmdStruct.Text = "..." 
Me.lblAllowRead.Location = New System.Drawing.Point(20,52)
Me.lblAllowRead.name = "lblAllowRead"
Me.lblAllowRead.Size = New System.Drawing.Size(200, 20)
Me.lblAllowRead.TabIndex = 4
Me.lblAllowRead.Text = "Разрешен просмотр"
Me.lblAllowRead.ForeColor = System.Drawing.Color.Black
Me.cmbAllowRead.Location = New System.Drawing.Point(20,74)
Me.cmbAllowRead.name = "cmbAllowRead"
Me.cmbAllowRead.Size = New System.Drawing.Size(200,  20)
Me.cmbAllowRead.TabIndex = 5
Me.lblAllowAdd.Location = New System.Drawing.Point(20,99)
Me.lblAllowAdd.name = "lblAllowAdd"
Me.lblAllowAdd.Size = New System.Drawing.Size(200, 20)
Me.lblAllowAdd.TabIndex = 6
Me.lblAllowAdd.Text = "Разрешено добавлять"
Me.lblAllowAdd.ForeColor = System.Drawing.Color.Black
Me.cmbAllowAdd.Location = New System.Drawing.Point(20,121)
Me.cmbAllowAdd.name = "cmbAllowAdd"
Me.cmbAllowAdd.Size = New System.Drawing.Size(200,  20)
Me.cmbAllowAdd.TabIndex = 7
Me.lblAllowEdit.Location = New System.Drawing.Point(20,146)
Me.lblAllowEdit.name = "lblAllowEdit"
Me.lblAllowEdit.Size = New System.Drawing.Size(200, 20)
Me.lblAllowEdit.TabIndex = 8
Me.lblAllowEdit.Text = "Разрешено изменять"
Me.lblAllowEdit.ForeColor = System.Drawing.Color.Black
Me.cmbAllowEdit.Location = New System.Drawing.Point(20,168)
Me.cmbAllowEdit.name = "cmbAllowEdit"
Me.cmbAllowEdit.Size = New System.Drawing.Size(200,  20)
Me.cmbAllowEdit.TabIndex = 9
Me.lblAllowDelete.Location = New System.Drawing.Point(20,193)
Me.lblAllowDelete.name = "lblAllowDelete"
Me.lblAllowDelete.Size = New System.Drawing.Size(200, 20)
Me.lblAllowDelete.TabIndex = 10
Me.lblAllowDelete.Text = "Разрешено удалять"
Me.lblAllowDelete.ForeColor = System.Drawing.Color.Black
Me.cmbAllowDelete.Location = New System.Drawing.Point(20,215)
Me.cmbAllowDelete.name = "cmbAllowDelete"
Me.cmbAllowDelete.Size = New System.Drawing.Size(200,  20)
Me.cmbAllowDelete.TabIndex = 11
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblStruct)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtStruct)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdStruct)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblAllowRead)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbAllowRead)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblAllowAdd)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbAllowAdd)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblAllowEdit)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbAllowEdit)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblAllowDelete)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbAllowDelete)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editSTRUCTRESTRICTION"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtStruct_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStruct.TextChanged
  Changing

end sub
private sub cmdStruct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStruct.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("PART","",System.guid.Empty, id, brief) Then
          txtStruct.Tag = id
          txtStruct.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmbAllowRead_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAllowRead.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmbAllowAdd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAllowAdd.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmbAllowEdit_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAllowEdit.SelectedIndexChanged
  try
  Changing

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

Public Item As MTZMetaModel.MTZMetaModel.STRUCTRESTRICTION
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,MTZMetaModel.MTZMetaModel.STRUCTRESTRICTION)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

If Not item.Struct Is Nothing Then
  txtStruct.Tag = item.Struct.id
  txtStruct.text = item.Struct.brief
else
  txtStruct.Tag = System.Guid.Empty 
  txtStruct.text = "" 
End If
cmbAllowReadData = New DataTable
cmbAllowReadData.Columns.Add("name", GetType(System.String))
cmbAllowReadData.Columns.Add("Value", GetType(System.Int32))
try
cmbAllowReadDataRow = cmbAllowReadData.NewRow
cmbAllowReadDataRow("name") = "Да"
cmbAllowReadDataRow("Value") = -1
cmbAllowReadData.Rows.Add (cmbAllowReadDataRow)
cmbAllowReadDataRow = cmbAllowReadData.NewRow
cmbAllowReadDataRow("name") = "Нет"
cmbAllowReadDataRow("Value") = 0
cmbAllowReadData.Rows.Add (cmbAllowReadDataRow)
cmbAllowRead.DisplayMember = "name"
cmbAllowRead.ValueMember = "Value"
cmbAllowRead.DataSource = cmbAllowReadData
 cmbAllowRead.SelectedValue=CInt(Item.AllowRead)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
cmbAllowAddData = New DataTable
cmbAllowAddData.Columns.Add("name", GetType(System.String))
cmbAllowAddData.Columns.Add("Value", GetType(System.Int32))
try
cmbAllowAddDataRow = cmbAllowAddData.NewRow
cmbAllowAddDataRow("name") = "Да"
cmbAllowAddDataRow("Value") = -1
cmbAllowAddData.Rows.Add (cmbAllowAddDataRow)
cmbAllowAddDataRow = cmbAllowAddData.NewRow
cmbAllowAddDataRow("name") = "Нет"
cmbAllowAddDataRow("Value") = 0
cmbAllowAddData.Rows.Add (cmbAllowAddDataRow)
cmbAllowAdd.DisplayMember = "name"
cmbAllowAdd.ValueMember = "Value"
cmbAllowAdd.DataSource = cmbAllowAddData
 cmbAllowAdd.SelectedValue=CInt(Item.AllowAdd)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
cmbAllowEditData = New DataTable
cmbAllowEditData.Columns.Add("name", GetType(System.String))
cmbAllowEditData.Columns.Add("Value", GetType(System.Int32))
try
cmbAllowEditDataRow = cmbAllowEditData.NewRow
cmbAllowEditDataRow("name") = "Да"
cmbAllowEditDataRow("Value") = -1
cmbAllowEditData.Rows.Add (cmbAllowEditDataRow)
cmbAllowEditDataRow = cmbAllowEditData.NewRow
cmbAllowEditDataRow("name") = "Нет"
cmbAllowEditDataRow("Value") = 0
cmbAllowEditData.Rows.Add (cmbAllowEditDataRow)
cmbAllowEdit.DisplayMember = "name"
cmbAllowEdit.ValueMember = "Value"
cmbAllowEdit.DataSource = cmbAllowEditData
 cmbAllowEdit.SelectedValue=CInt(Item.AllowEdit)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
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

If not txtStruct.Tag.Equals(System.Guid.Empty) Then
  item.Struct = Item.Application.FindRowObject("PART",txtStruct.Tag)
Else
   item.Struct = Nothing
End If
   item.AllowRead = cmbAllowRead.SelectedValue
   item.AllowAdd = cmbAllowAdd.SelectedValue
   item.AllowEdit = cmbAllowEdit.SelectedValue
   item.AllowDelete = cmbAllowDelete.SelectedValue
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK = not txtStruct.Tag.Equals(System.Guid.Empty)
if mIsOK then mIsOK =(cmbAllowRead.SelectedIndex >=0)
if mIsOK then mIsOK =(cmbAllowAdd.SelectedIndex >=0)
if mIsOK then mIsOK =(cmbAllowEdit.SelectedIndex >=0)
if mIsOK then mIsOK =(cmbAllowDelete.SelectedIndex >=0)
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
