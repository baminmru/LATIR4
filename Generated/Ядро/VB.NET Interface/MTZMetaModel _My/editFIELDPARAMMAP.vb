
Imports System.Windows.Forms
Imports Microsoft.VisualBasic



''' <summary>
'''Контрол редактирования раздела Отображение параметров режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editFIELDPARAMMAP
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

 dim iii as integer
    Friend WithEvents HolderPanel As LATIR2GUIControls.AutoPanel
Friend WithEvents lblFieldName  as  System.Windows.Forms.Label
Friend WithEvents txtFieldName As System.Windows.Forms.TextBox
Friend WithEvents lblParamName  as  System.Windows.Forms.Label
Friend WithEvents txtParamName As System.Windows.Forms.TextBox
Friend WithEvents lblNoEdit  as  System.Windows.Forms.Label
Friend WithEvents cmbNoEdit As System.Windows.Forms.ComboBox
Friend cmbNoEditDATA As DataTable
Friend cmbNoEditDATAROW As DataRow

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
Me.lblFieldName = New System.Windows.Forms.Label
Me.txtFieldName = New System.Windows.Forms.TextBox
Me.lblParamName = New System.Windows.Forms.Label
Me.txtParamName = New System.Windows.Forms.TextBox
Me.lblNoEdit = New System.Windows.Forms.Label
Me.cmbNoEdit = New System.Windows.Forms.ComboBox

Me.lblFieldName.Location = New System.Drawing.Point(20,5)
Me.lblFieldName.name = "lblFieldName"
Me.lblFieldName.Size = New System.Drawing.Size(200, 20)
Me.lblFieldName.TabIndex = 1
Me.lblFieldName.Text = "Поле (значение)"
Me.lblFieldName.ForeColor = System.Drawing.Color.Black
Me.txtFieldName.Location = New System.Drawing.Point(20,27)
Me.txtFieldName.name = "txtFieldName"
Me.txtFieldName.Size = New System.Drawing.Size(200, 20)
Me.txtFieldName.TabIndex = 2
Me.txtFieldName.Text = "" 
Me.lblParamName.Location = New System.Drawing.Point(20,52)
Me.lblParamName.name = "lblParamName"
Me.lblParamName.Size = New System.Drawing.Size(200, 20)
Me.lblParamName.TabIndex = 3
Me.lblParamName.Text = "Параметр"
Me.lblParamName.ForeColor = System.Drawing.Color.Black
Me.txtParamName.Location = New System.Drawing.Point(20,74)
Me.txtParamName.name = "txtParamName"
Me.txtParamName.Size = New System.Drawing.Size(200, 20)
Me.txtParamName.TabIndex = 4
Me.txtParamName.Text = "" 
Me.lblNoEdit.Location = New System.Drawing.Point(20,99)
Me.lblNoEdit.name = "lblNoEdit"
Me.lblNoEdit.Size = New System.Drawing.Size(200, 20)
Me.lblNoEdit.TabIndex = 5
Me.lblNoEdit.Text = "Редактировать параметр нельзя"
Me.lblNoEdit.ForeColor = System.Drawing.Color.Black
Me.cmbNoEdit.Location = New System.Drawing.Point(20,121)
Me.cmbNoEdit.name = "cmbNoEdit"
Me.cmbNoEdit.Size = New System.Drawing.Size(200,  20)
Me.cmbNoEdit.TabIndex = 6
        Me.AutoScroll = True

 CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblFieldName)
 CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtFieldName)
 CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblParamName)
 CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtParamName)
 CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblNoEdit)
 CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbNoEdit)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editFIELDPARAMMAP"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtFieldName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFieldName.TextChanged
  Changing

end sub
private sub txtParamName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtParamName.TextChanged
  Changing

end sub
private sub cmbNoEdit_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNoEdit.SelectedValueChanged
  on error resume next
  Changing

end sub

Public Item As MTZMetaModel.MTZMetaModel.FIELDPARAMMAP
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,MTZMetaModel.MTZMetaModel.FIELDPARAMMAP)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

txtFieldName.text = item.FieldName
txtParamName.text = item.ParamName
cmbNoEditData = New DataTable
cmbNoEditData.Columns.Add("name", GetType(System.String))
cmbNoEditData.Columns.Add("Value", GetType(System.Int32))
On Error Resume Next
cmbNoEditDataRow = cmbNoEditData.NewRow
cmbNoEditDataRow("name") = "Да"
cmbNoEditDataRow("Value") = -1
cmbNoEditData.Rows.Add (cmbNoEditDataRow)
cmbNoEditDataRow = cmbNoEditData.NewRow
cmbNoEditDataRow("name") = "Нет"
cmbNoEditDataRow("Value") = 0
cmbNoEditData.Rows.Add (cmbNoEditDataRow)
cmbNoEdit.DisplayMember = "name"
cmbNoEdit.ValueMember = "Value"
cmbNoEdit.DataSource = cmbNoEditData
 cmbNoEdit.SelectedValue=CInt(Item.NoEdit)
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

item.FieldName = txtFieldName.text
item.ParamName = txtParamName.Text
            Item.NoEdit = cmbNoEdit.SelectedValue
        End if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK =( txtFieldName.text <> "" ) 
if mIsOK then mIsOK =( txtParamName.text <> "" ) 
if mIsOK then mIsOK =(cmbNoEdit.SelectedIndex >=0)
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
