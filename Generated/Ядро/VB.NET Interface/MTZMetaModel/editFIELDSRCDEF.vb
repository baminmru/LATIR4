
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Описание источника данных режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editFIELDSRCDEF
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
Friend WithEvents lblProvider  as  System.Windows.Forms.Label
Friend WithEvents txtProvider As System.Windows.Forms.TextBox
Friend WithEvents lblConnectionString  as  System.Windows.Forms.Label
Friend WithEvents txtConnectionString As System.Windows.Forms.TextBox
Friend WithEvents lblDataSource  as  System.Windows.Forms.Label
Friend WithEvents txtDataSource As System.Windows.Forms.TextBox
Friend WithEvents lblIDField  as  System.Windows.Forms.Label
Friend WithEvents txtIDField As System.Windows.Forms.TextBox
Friend WithEvents lblBriefString  as  System.Windows.Forms.Label
Friend WithEvents txtBriefString As System.Windows.Forms.TextBox
Friend WithEvents lblFilterString  as  System.Windows.Forms.Label
Friend WithEvents txtFilterString As System.Windows.Forms.TextBox
Friend WithEvents lblSortField  as  System.Windows.Forms.Label
Friend WithEvents txtSortField As System.Windows.Forms.TextBox
Friend WithEvents lblDescriptionString  as  System.Windows.Forms.Label
Friend WithEvents txtDescriptionString As System.Windows.Forms.TextBox
Friend WithEvents lblDontShowDialog  as  System.Windows.Forms.Label
Friend WithEvents cmbDontShowDialog As System.Windows.Forms.ComboBox
Friend cmbDontShowDialogDATA As DataTable
Friend cmbDontShowDialogDATAROW As DataRow

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
Me.lblProvider = New System.Windows.Forms.Label
Me.txtProvider = New System.Windows.Forms.TextBox
Me.lblConnectionString = New System.Windows.Forms.Label
Me.txtConnectionString = New System.Windows.Forms.TextBox
Me.lblDataSource = New System.Windows.Forms.Label
Me.txtDataSource = New System.Windows.Forms.TextBox
Me.lblIDField = New System.Windows.Forms.Label
Me.txtIDField = New System.Windows.Forms.TextBox
Me.lblBriefString = New System.Windows.Forms.Label
Me.txtBriefString = New System.Windows.Forms.TextBox
Me.lblFilterString = New System.Windows.Forms.Label
Me.txtFilterString = New System.Windows.Forms.TextBox
Me.lblSortField = New System.Windows.Forms.Label
Me.txtSortField = New System.Windows.Forms.TextBox
Me.lblDescriptionString = New System.Windows.Forms.Label
Me.txtDescriptionString = New System.Windows.Forms.TextBox
Me.lblDontShowDialog = New System.Windows.Forms.Label
Me.cmbDontShowDialog = New System.Windows.Forms.ComboBox

Me.lblProvider.Location = New System.Drawing.Point(20,5)
Me.lblProvider.name = "lblProvider"
Me.lblProvider.Size = New System.Drawing.Size(200, 20)
Me.lblProvider.TabIndex = 1
Me.lblProvider.Text = "Провайдер"
Me.lblProvider.ForeColor = System.Drawing.Color.Blue
Me.txtProvider.Location = New System.Drawing.Point(20,27)
Me.txtProvider.name = "txtProvider"
Me.txtProvider.Size = New System.Drawing.Size(200, 20)
Me.txtProvider.TabIndex = 2
Me.txtProvider.Text = "" 
Me.lblConnectionString.Location = New System.Drawing.Point(20,52)
Me.lblConnectionString.name = "lblConnectionString"
Me.lblConnectionString.Size = New System.Drawing.Size(200, 20)
Me.lblConnectionString.TabIndex = 3
Me.lblConnectionString.Text = "Строка соединения с источником"
Me.lblConnectionString.ForeColor = System.Drawing.Color.Blue
Me.txtConnectionString.Location = New System.Drawing.Point(20,74)
Me.txtConnectionString.name = "txtConnectionString"
Me.txtConnectionString.Size = New System.Drawing.Size(200, 20)
Me.txtConnectionString.TabIndex = 4
Me.txtConnectionString.Text = "" 
Me.lblDataSource.Location = New System.Drawing.Point(20,99)
Me.lblDataSource.name = "lblDataSource"
Me.lblDataSource.Size = New System.Drawing.Size(200, 20)
Me.lblDataSource.TabIndex = 5
Me.lblDataSource.Text = "Источник данных"
Me.lblDataSource.ForeColor = System.Drawing.Color.Black
Me.txtDataSource.Location = New System.Drawing.Point(20,121)
Me.txtDataSource.name = "txtDataSource"
Me.txtDataSource.Size = New System.Drawing.Size(200, 20)
Me.txtDataSource.TabIndex = 6
Me.txtDataSource.Text = "" 
Me.lblIDField.Location = New System.Drawing.Point(20,146)
Me.lblIDField.name = "lblIDField"
Me.lblIDField.Size = New System.Drawing.Size(200, 20)
Me.lblIDField.TabIndex = 7
Me.lblIDField.Text = "ID"
Me.lblIDField.ForeColor = System.Drawing.Color.Blue
Me.txtIDField.Location = New System.Drawing.Point(20,168)
Me.txtIDField.name = "txtIDField"
Me.txtIDField.Size = New System.Drawing.Size(200, 20)
Me.txtIDField.TabIndex = 8
Me.txtIDField.Text = "" 
Me.lblBriefString.Location = New System.Drawing.Point(20,193)
Me.lblBriefString.name = "lblBriefString"
Me.lblBriefString.Size = New System.Drawing.Size(200, 20)
Me.lblBriefString.TabIndex = 9
Me.lblBriefString.Text = "Источник краткой информации"
Me.lblBriefString.ForeColor = System.Drawing.Color.Blue
Me.txtBriefString.Location = New System.Drawing.Point(20,215)
Me.txtBriefString.name = "txtBriefString"
Me.txtBriefString.Size = New System.Drawing.Size(200, 20)
Me.txtBriefString.TabIndex = 10
Me.txtBriefString.Text = "" 
Me.lblFilterString.Location = New System.Drawing.Point(20,240)
Me.lblFilterString.name = "lblFilterString"
Me.lblFilterString.Size = New System.Drawing.Size(200, 20)
Me.lblFilterString.TabIndex = 11
Me.lblFilterString.Text = "Фильтр источника данных"
Me.lblFilterString.ForeColor = System.Drawing.Color.Blue
Me.txtFilterString.Location = New System.Drawing.Point(20,262)
Me.txtFilterString.name = "txtFilterString"
Me.txtFilterString.Size = New System.Drawing.Size(200, 20)
Me.txtFilterString.TabIndex = 12
Me.txtFilterString.Text = "" 
Me.lblSortField.Location = New System.Drawing.Point(20,287)
Me.lblSortField.name = "lblSortField"
Me.lblSortField.Size = New System.Drawing.Size(200, 20)
Me.lblSortField.TabIndex = 13
Me.lblSortField.Text = "Сортировка источника данных"
Me.lblSortField.ForeColor = System.Drawing.Color.Blue
Me.txtSortField.Location = New System.Drawing.Point(20,309)
Me.txtSortField.name = "txtSortField"
Me.txtSortField.Size = New System.Drawing.Size(200, 20)
Me.txtSortField.TabIndex = 14
Me.txtSortField.Text = "" 
Me.lblDescriptionString.Location = New System.Drawing.Point(20,334)
Me.lblDescriptionString.name = "lblDescriptionString"
Me.lblDescriptionString.Size = New System.Drawing.Size(200, 20)
Me.lblDescriptionString.TabIndex = 15
Me.lblDescriptionString.Text = "Примечания"
Me.lblDescriptionString.ForeColor = System.Drawing.Color.Blue
Me.txtDescriptionString.Location = New System.Drawing.Point(20,356)
Me.txtDescriptionString.name = "txtDescriptionString"
Me.txtDescriptionString.MultiLine = True
Me.txtDescriptionString.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtDescriptionString.Size = New System.Drawing.Size(200, 50 + 20)
Me.txtDescriptionString.TabIndex = 16
Me.txtDescriptionString.Text = "" 
Me.lblDontShowDialog.Location = New System.Drawing.Point(230,5)
Me.lblDontShowDialog.name = "lblDontShowDialog"
Me.lblDontShowDialog.Size = New System.Drawing.Size(200, 20)
Me.lblDontShowDialog.TabIndex = 17
Me.lblDontShowDialog.Text = "Не показывать форму выбора"
Me.lblDontShowDialog.ForeColor = System.Drawing.Color.Blue
Me.cmbDontShowDialog.Location = New System.Drawing.Point(230,27)
Me.cmbDontShowDialog.name = "cmbDontShowDialog"
Me.cmbDontShowDialog.Size = New System.Drawing.Size(200,  20)
Me.cmbDontShowDialog.TabIndex = 18
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblProvider)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtProvider)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblConnectionString)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtConnectionString)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblDataSource)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtDataSource)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblIDField)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtIDField)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblBriefString)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtBriefString)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblFilterString)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtFilterString)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblSortField)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtSortField)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblDescriptionString)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtDescriptionString)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblDontShowDialog)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbDontShowDialog)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editFIELDSRCDEF"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtProvider_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProvider.TextChanged
  Changing

end sub
private sub txtConnectionString_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtConnectionString.TextChanged
  Changing

end sub
private sub txtDataSource_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDataSource.TextChanged
  Changing

end sub
private sub txtIDField_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIDField.TextChanged
  Changing

end sub
private sub txtBriefString_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBriefString.TextChanged
  Changing

end sub
private sub txtFilterString_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFilterString.TextChanged
  Changing

end sub
private sub txtSortField_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSortField.TextChanged
  Changing

end sub
private sub txtDescriptionString_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDescriptionString.TextChanged
  Changing

end sub
private sub cmbDontShowDialog_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDontShowDialog.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub

Public Item As MTZMetaModel.MTZMetaModel.FIELDSRCDEF
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,MTZMetaModel.MTZMetaModel.FIELDSRCDEF)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

txtProvider.text = item.Provider
txtConnectionString.text = item.ConnectionString
txtDataSource.text = item.DataSource
txtIDField.text = item.IDField
txtBriefString.text = item.BriefString
txtFilterString.text = item.FilterString
txtSortField.text = item.SortField
txtDescriptionString.text = item.DescriptionString
cmbDontShowDialogData = New DataTable
cmbDontShowDialogData.Columns.Add("name", GetType(System.String))
cmbDontShowDialogData.Columns.Add("Value", GetType(System.Int32))
try
cmbDontShowDialogDataRow = cmbDontShowDialogData.NewRow
cmbDontShowDialogDataRow("name") = "Нет"
cmbDontShowDialogDataRow("Value") = 0
cmbDontShowDialogData.Rows.Add (cmbDontShowDialogDataRow)
cmbDontShowDialogDataRow = cmbDontShowDialogData.NewRow
cmbDontShowDialogDataRow("name") = "Да"
cmbDontShowDialogDataRow("Value") = 1
cmbDontShowDialogData.Rows.Add (cmbDontShowDialogDataRow)
cmbDontShowDialog.DisplayMember = "name"
cmbDontShowDialog.ValueMember = "Value"
cmbDontShowDialog.DataSource = cmbDontShowDialogData
 cmbDontShowDialog.SelectedValue=CInt(Item.DontShowDialog)
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

item.Provider = txtProvider.text
item.ConnectionString = txtConnectionString.text
item.DataSource = txtDataSource.text
item.IDField = txtIDField.text
item.BriefString = txtBriefString.text
item.FilterString = txtFilterString.text
item.SortField = txtSortField.text
item.DescriptionString = txtDescriptionString.text
   item.DontShowDialog = cmbDontShowDialog.SelectedValue
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK =( txtDataSource.text <> "" ) 
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
