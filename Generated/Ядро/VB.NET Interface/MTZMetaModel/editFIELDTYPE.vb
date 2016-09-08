
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Тип поля режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editFIELDTYPE
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
Friend WithEvents lblTypeStyle  as  System.Windows.Forms.Label
Friend WithEvents cmbTypeStyle As System.Windows.Forms.ComboBox
Friend cmbTypeStyleDATA As DataTable
Friend cmbTypeStyleDATAROW As DataRow
Friend WithEvents lblthe_Comment  as  System.Windows.Forms.Label
Friend WithEvents txtthe_Comment As System.Windows.Forms.TextBox
Friend WithEvents lblAllowSize  as  System.Windows.Forms.Label
Friend WithEvents cmbAllowSize As System.Windows.Forms.ComboBox
Friend cmbAllowSizeDATA As DataTable
Friend cmbAllowSizeDATAROW As DataRow
Friend WithEvents lblMinimum  as  System.Windows.Forms.Label
Friend WithEvents txtMinimum As System.Windows.Forms.TextBox
Friend WithEvents lblMaximum  as  System.Windows.Forms.Label
Friend WithEvents txtMaximum As System.Windows.Forms.TextBox
Friend WithEvents lblAllowLikeSearch  as  System.Windows.Forms.Label
Friend WithEvents cmbAllowLikeSearch As System.Windows.Forms.ComboBox
Friend cmbAllowLikeSearchDATA As DataTable
Friend cmbAllowLikeSearchDATAROW As DataRow
Friend WithEvents lblGridSortType  as  System.Windows.Forms.Label
Friend WithEvents cmbGridSortType As System.Windows.Forms.ComboBox
Friend cmbGridSortTypeDATA As DataTable
Friend cmbGridSortTypeDATAROW As DataRow
Friend WithEvents lblDelayedSave  as  System.Windows.Forms.Label
Friend WithEvents cmbDelayedSave As System.Windows.Forms.ComboBox
Friend cmbDelayedSaveDATA As DataTable
Friend cmbDelayedSaveDATAROW As DataRow

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
Me.lblTypeStyle = New System.Windows.Forms.Label
Me.cmbTypeStyle = New System.Windows.Forms.ComboBox
Me.lblthe_Comment = New System.Windows.Forms.Label
Me.txtthe_Comment = New System.Windows.Forms.TextBox
Me.lblAllowSize = New System.Windows.Forms.Label
Me.cmbAllowSize = New System.Windows.Forms.ComboBox
Me.lblMinimum = New System.Windows.Forms.Label
Me.txtMinimum = New System.Windows.Forms.TextBox
Me.lblMaximum = New System.Windows.Forms.Label
Me.txtMaximum = New System.Windows.Forms.TextBox
Me.lblAllowLikeSearch = New System.Windows.Forms.Label
Me.cmbAllowLikeSearch = New System.Windows.Forms.ComboBox
Me.lblGridSortType = New System.Windows.Forms.Label
Me.cmbGridSortType = New System.Windows.Forms.ComboBox
Me.lblDelayedSave = New System.Windows.Forms.Label
Me.cmbDelayedSave = New System.Windows.Forms.ComboBox

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
Me.lblTypeStyle.Location = New System.Drawing.Point(20,52)
Me.lblTypeStyle.name = "lblTypeStyle"
Me.lblTypeStyle.Size = New System.Drawing.Size(200, 20)
Me.lblTypeStyle.TabIndex = 3
Me.lblTypeStyle.Text = "Трактовка"
Me.lblTypeStyle.ForeColor = System.Drawing.Color.Black
Me.cmbTypeStyle.Location = New System.Drawing.Point(20,74)
Me.cmbTypeStyle.name = "cmbTypeStyle"
Me.cmbTypeStyle.Size = New System.Drawing.Size(200,  20)
Me.cmbTypeStyle.TabIndex = 4
Me.cmbTypeStyle.DropDownStyle = ComboBoxStyle.DropDownList
Me.lblthe_Comment.Location = New System.Drawing.Point(20,99)
Me.lblthe_Comment.name = "lblthe_Comment"
Me.lblthe_Comment.Size = New System.Drawing.Size(200, 20)
Me.lblthe_Comment.TabIndex = 5
Me.lblthe_Comment.Text = "Описание"
Me.lblthe_Comment.ForeColor = System.Drawing.Color.Blue
Me.txtthe_Comment.Location = New System.Drawing.Point(20,121)
Me.txtthe_Comment.name = "txtthe_Comment"
Me.txtthe_Comment.MultiLine = True
Me.txtthe_Comment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtthe_Comment.Size = New System.Drawing.Size(200, 50 + 20)
Me.txtthe_Comment.TabIndex = 6
Me.txtthe_Comment.Text = "" 
Me.lblAllowSize.Location = New System.Drawing.Point(20,191)
Me.lblAllowSize.name = "lblAllowSize"
Me.lblAllowSize.Size = New System.Drawing.Size(200, 20)
Me.lblAllowSize.TabIndex = 7
Me.lblAllowSize.Text = "Нужен размер"
Me.lblAllowSize.ForeColor = System.Drawing.Color.Black
Me.cmbAllowSize.Location = New System.Drawing.Point(20,213)
Me.cmbAllowSize.name = "cmbAllowSize"
Me.cmbAllowSize.Size = New System.Drawing.Size(200,  20)
Me.cmbAllowSize.TabIndex = 8
Me.lblMinimum.Location = New System.Drawing.Point(20,238)
Me.lblMinimum.name = "lblMinimum"
Me.lblMinimum.Size = New System.Drawing.Size(200, 20)
Me.lblMinimum.TabIndex = 9
Me.lblMinimum.Text = "Минимум"
Me.lblMinimum.ForeColor = System.Drawing.Color.Blue
Me.txtMinimum.Location = New System.Drawing.Point(20,260)
Me.txtMinimum.name = "txtMinimum"
Me.txtMinimum.Size = New System.Drawing.Size(200, 20)
Me.txtMinimum.TabIndex = 10
Me.txtMinimum.Text = "" 
Me.lblMaximum.Location = New System.Drawing.Point(20,285)
Me.lblMaximum.name = "lblMaximum"
Me.lblMaximum.Size = New System.Drawing.Size(200, 20)
Me.lblMaximum.TabIndex = 11
Me.lblMaximum.Text = "Максимум"
Me.lblMaximum.ForeColor = System.Drawing.Color.Blue
Me.txtMaximum.Location = New System.Drawing.Point(20,307)
Me.txtMaximum.name = "txtMaximum"
Me.txtMaximum.Size = New System.Drawing.Size(200, 20)
Me.txtMaximum.TabIndex = 12
Me.txtMaximum.Text = "" 
Me.lblAllowLikeSearch.Location = New System.Drawing.Point(20,332)
Me.lblAllowLikeSearch.name = "lblAllowLikeSearch"
Me.lblAllowLikeSearch.Size = New System.Drawing.Size(200, 20)
Me.lblAllowLikeSearch.TabIndex = 13
Me.lblAllowLikeSearch.Text = "Поиск текста"
Me.lblAllowLikeSearch.ForeColor = System.Drawing.Color.Black
Me.cmbAllowLikeSearch.Location = New System.Drawing.Point(20,354)
Me.cmbAllowLikeSearch.name = "cmbAllowLikeSearch"
Me.cmbAllowLikeSearch.Size = New System.Drawing.Size(200,  20)
Me.cmbAllowLikeSearch.TabIndex = 14
Me.lblGridSortType.Location = New System.Drawing.Point(20,379)
Me.lblGridSortType.name = "lblGridSortType"
Me.lblGridSortType.Size = New System.Drawing.Size(200, 20)
Me.lblGridSortType.TabIndex = 15
Me.lblGridSortType.Text = "Вариант сортировки в табличном представлении"
Me.lblGridSortType.ForeColor = System.Drawing.Color.Blue
Me.cmbGridSortType.Location = New System.Drawing.Point(20,401)
Me.cmbGridSortType.name = "cmbGridSortType"
Me.cmbGridSortType.Size = New System.Drawing.Size(200,  20)
Me.cmbGridSortType.TabIndex = 16
Me.cmbGridSortType.DropDownStyle = ComboBoxStyle.DropDownList
Me.lblDelayedSave.Location = New System.Drawing.Point(230,5)
Me.lblDelayedSave.name = "lblDelayedSave"
Me.lblDelayedSave.Size = New System.Drawing.Size(200, 20)
Me.lblDelayedSave.TabIndex = 17
Me.lblDelayedSave.Text = "Отложенное сохранение"
Me.lblDelayedSave.ForeColor = System.Drawing.Color.Black
Me.cmbDelayedSave.Location = New System.Drawing.Point(230,27)
Me.cmbDelayedSave.name = "cmbDelayedSave"
Me.cmbDelayedSave.Size = New System.Drawing.Size(200,  20)
Me.cmbDelayedSave.TabIndex = 18
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTypeStyle)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbTypeStyle)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblthe_Comment)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtthe_Comment)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblAllowSize)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbAllowSize)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblMinimum)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtMinimum)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblMaximum)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtMaximum)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblAllowLikeSearch)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbAllowLikeSearch)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblGridSortType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbGridSortType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblDelayedSave)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbDelayedSave)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editFIELDTYPE"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
  Changing

end sub
private sub cmbTypeStyle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTypeStyle.SelectedIndexChanged
  try
     Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtthe_Comment_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtthe_Comment.TextChanged
  Changing

end sub
private sub cmbAllowSize_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAllowSize.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtMinimum_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMinimum.TextChanged
  Changing

end sub
private sub txtMaximum_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMaximum.TextChanged
  Changing

end sub
private sub cmbAllowLikeSearch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAllowLikeSearch.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmbGridSortType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGridSortType.SelectedIndexChanged
  try
     Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmbDelayedSave_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDelayedSave.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub

Public Item As MTZMetaModel.MTZMetaModel.FIELDTYPE
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,MTZMetaModel.MTZMetaModel.FIELDTYPE)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

txtName.text = item.Name
cmbTypeStyleData = New DataTable
cmbTypeStyleData.Columns.Add("name", GetType(System.String))
cmbTypeStyleData.Columns.Add("Value", GetType(System.Int32))
try
cmbTypeStyleDataRow = cmbTypeStyleData.NewRow
cmbTypeStyleDataRow("name") = "Скалярный тип"
cmbTypeStyleDataRow("Value") = 0
cmbTypeStyleData.Rows.Add (cmbTypeStyleDataRow)
cmbTypeStyleDataRow = cmbTypeStyleData.NewRow
cmbTypeStyleDataRow("name") = "Выражение"
cmbTypeStyleDataRow("Value") = 1
cmbTypeStyleData.Rows.Add (cmbTypeStyleDataRow)
cmbTypeStyleDataRow = cmbTypeStyleData.NewRow
cmbTypeStyleDataRow("name") = "Перечисление"
cmbTypeStyleDataRow("Value") = 2
cmbTypeStyleData.Rows.Add (cmbTypeStyleDataRow)
cmbTypeStyleDataRow = cmbTypeStyleData.NewRow
cmbTypeStyleDataRow("name") = "Интервал"
cmbTypeStyleDataRow("Value") = 3
cmbTypeStyleData.Rows.Add (cmbTypeStyleDataRow)
cmbTypeStyleDataRow = cmbTypeStyleData.NewRow
cmbTypeStyleDataRow("name") = "Ссылка"
cmbTypeStyleDataRow("Value") = 4
cmbTypeStyleData.Rows.Add (cmbTypeStyleDataRow)
cmbTypeStyleDataRow = cmbTypeStyleData.NewRow
cmbTypeStyleDataRow("name") = "Элемент оформления"
cmbTypeStyleDataRow("Value") = 5
cmbTypeStyleData.Rows.Add (cmbTypeStyleDataRow)
cmbTypeStyle.DisplayMember = "name"
cmbTypeStyle.ValueMember = "Value"
cmbTypeStyle.DataSource = cmbTypeStyleData
 cmbTypeStyle.SelectedValue=CInt(Item.TypeStyle)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
txtthe_Comment.text = item.the_Comment
cmbAllowSizeData = New DataTable
cmbAllowSizeData.Columns.Add("name", GetType(System.String))
cmbAllowSizeData.Columns.Add("Value", GetType(System.Int32))
try
cmbAllowSizeDataRow = cmbAllowSizeData.NewRow
cmbAllowSizeDataRow("name") = "Да"
cmbAllowSizeDataRow("Value") = -1
cmbAllowSizeData.Rows.Add (cmbAllowSizeDataRow)
cmbAllowSizeDataRow = cmbAllowSizeData.NewRow
cmbAllowSizeDataRow("name") = "Нет"
cmbAllowSizeDataRow("Value") = 0
cmbAllowSizeData.Rows.Add (cmbAllowSizeDataRow)
cmbAllowSize.DisplayMember = "name"
cmbAllowSize.ValueMember = "Value"
cmbAllowSize.DataSource = cmbAllowSizeData
 cmbAllowSize.SelectedValue=CInt(Item.AllowSize)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
txtMinimum.text = item.Minimum
txtMaximum.text = item.Maximum
cmbAllowLikeSearchData = New DataTable
cmbAllowLikeSearchData.Columns.Add("name", GetType(System.String))
cmbAllowLikeSearchData.Columns.Add("Value", GetType(System.Int32))
try
cmbAllowLikeSearchDataRow = cmbAllowLikeSearchData.NewRow
cmbAllowLikeSearchDataRow("name") = "Да"
cmbAllowLikeSearchDataRow("Value") = -1
cmbAllowLikeSearchData.Rows.Add (cmbAllowLikeSearchDataRow)
cmbAllowLikeSearchDataRow = cmbAllowLikeSearchData.NewRow
cmbAllowLikeSearchDataRow("name") = "Нет"
cmbAllowLikeSearchDataRow("Value") = 0
cmbAllowLikeSearchData.Rows.Add (cmbAllowLikeSearchDataRow)
cmbAllowLikeSearch.DisplayMember = "name"
cmbAllowLikeSearch.ValueMember = "Value"
cmbAllowLikeSearch.DataSource = cmbAllowLikeSearchData
 cmbAllowLikeSearch.SelectedValue=CInt(Item.AllowLikeSearch)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
cmbGridSortTypeData = New DataTable
cmbGridSortTypeData.Columns.Add("name", GetType(System.String))
cmbGridSortTypeData.Columns.Add("Value", GetType(System.Int32))
try
cmbGridSortTypeDataRow = cmbGridSortTypeData.NewRow
cmbGridSortTypeDataRow("name") = "As String"
cmbGridSortTypeDataRow("Value") = 0
cmbGridSortTypeData.Rows.Add (cmbGridSortTypeDataRow)
cmbGridSortTypeDataRow = cmbGridSortTypeData.NewRow
cmbGridSortTypeDataRow("name") = "As Numeric"
cmbGridSortTypeDataRow("Value") = 1
cmbGridSortTypeData.Rows.Add (cmbGridSortTypeDataRow)
cmbGridSortTypeDataRow = cmbGridSortTypeData.NewRow
cmbGridSortTypeDataRow("name") = "As Date"
cmbGridSortTypeDataRow("Value") = 2
cmbGridSortTypeData.Rows.Add (cmbGridSortTypeDataRow)
cmbGridSortType.DisplayMember = "name"
cmbGridSortType.ValueMember = "Value"
cmbGridSortType.DataSource = cmbGridSortTypeData
 cmbGridSortType.SelectedValue=CInt(Item.GridSortType)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
cmbDelayedSaveData = New DataTable
cmbDelayedSaveData.Columns.Add("name", GetType(System.String))
cmbDelayedSaveData.Columns.Add("Value", GetType(System.Int32))
try
cmbDelayedSaveDataRow = cmbDelayedSaveData.NewRow
cmbDelayedSaveDataRow("name") = "Да"
cmbDelayedSaveDataRow("Value") = -1
cmbDelayedSaveData.Rows.Add (cmbDelayedSaveDataRow)
cmbDelayedSaveDataRow = cmbDelayedSaveData.NewRow
cmbDelayedSaveDataRow("name") = "Нет"
cmbDelayedSaveDataRow("Value") = 0
cmbDelayedSaveData.Rows.Add (cmbDelayedSaveDataRow)
cmbDelayedSave.DisplayMember = "name"
cmbDelayedSave.ValueMember = "Value"
cmbDelayedSave.DataSource = cmbDelayedSaveData
 cmbDelayedSave.SelectedValue=CInt(Item.DelayedSave)
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

item.Name = txtName.text
   item.TypeStyle = cmbTypeStyle.SelectedValue
item.the_Comment = txtthe_Comment.text
   item.AllowSize = cmbAllowSize.SelectedValue
item.Minimum = txtMinimum.text
item.Maximum = txtMaximum.text
   item.AllowLikeSearch = cmbAllowLikeSearch.SelectedValue
   item.GridSortType = cmbGridSortType.SelectedValue
   item.DelayedSave = cmbDelayedSave.SelectedValue
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK =( txtName.text <> "" ) 
if mIsOK then mIsOK =(cmbTypeStyle.SelectedIndex >=0)
if mIsOK then mIsOK =(cmbAllowSize.SelectedIndex >=0)
if mIsOK then mIsOK =(cmbAllowLikeSearch.SelectedIndex >=0)
if mIsOK then mIsOK =(cmbDelayedSave.SelectedIndex >=0)
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
