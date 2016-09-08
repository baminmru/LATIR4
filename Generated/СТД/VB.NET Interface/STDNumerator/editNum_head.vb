
Imports System.Windows.Forms
Imports Microsoft.VisualBasic



''' <summary>
'''Контрол редактирования раздела Описание режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editNum_head
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
Friend WithEvents lblName  as  System.Windows.Forms.Label
Friend WithEvents txtName As System.Windows.Forms.TextBox
Friend WithEvents lblShema  as  System.Windows.Forms.Label
Friend WithEvents cmbShema As System.Windows.Forms.ComboBox
Friend cmbShemaDATA As DataTable
Friend cmbShemaDATAROW As DataRow

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
Me.lblShema = New System.Windows.Forms.Label
Me.cmbShema = New System.Windows.Forms.ComboBox

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
Me.lblShema.Location = New System.Drawing.Point(20,52)
Me.lblShema.name = "lblShema"
Me.lblShema.Size = New System.Drawing.Size(200, 20)
Me.lblShema.TabIndex = 3
Me.lblShema.Text = "Схема нумерации"
Me.lblShema.ForeColor = System.Drawing.Color.Black
Me.cmbShema.Location = New System.Drawing.Point(20,74)
Me.cmbShema.name = "cmbShema"
Me.cmbShema.Size = New System.Drawing.Size(200,  20)
Me.cmbShema.TabIndex = 4
Me.cmbShema.DropDownStyle = ComboBoxStyle.DropDownList
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblShema)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbShema)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editNum_head"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
  Changing

end sub
private sub cmbShema_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbShema.SelectedIndexChanged
  on error resume next
  Changing

end sub

Public Item As STDNumerator.STDNumerator.Num_head
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,STDNumerator.STDNumerator.Num_head)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

txtName.text = item.Name
cmbShemaData = New DataTable
cmbShemaData.Columns.Add("name", GetType(System.String))
cmbShemaData.Columns.Add("Value", GetType(System.Int32))
On Error Resume Next
cmbShemaDataRow = cmbShemaData.NewRow
cmbShemaDataRow("name") = "Единая зона"
cmbShemaDataRow("Value") = 0
cmbShemaData.Rows.Add (cmbShemaDataRow)
cmbShemaDataRow = cmbShemaData.NewRow
cmbShemaDataRow("name") = "По году"
cmbShemaDataRow("Value") = 1
cmbShemaData.Rows.Add (cmbShemaDataRow)
cmbShemaDataRow = cmbShemaData.NewRow
cmbShemaDataRow("name") = "По кварталу"
cmbShemaDataRow("Value") = 2
cmbShemaData.Rows.Add (cmbShemaDataRow)
cmbShemaDataRow = cmbShemaData.NewRow
cmbShemaDataRow("name") = "По месяцу"
cmbShemaDataRow("Value") = 3
cmbShemaData.Rows.Add (cmbShemaDataRow)
cmbShemaDataRow = cmbShemaData.NewRow
cmbShemaDataRow("name") = "По дню"
cmbShemaDataRow("Value") = 4
cmbShemaData.Rows.Add (cmbShemaDataRow)
cmbShemaDataRow = cmbShemaData.NewRow
cmbShemaDataRow("name") = "Произвольные зоны"
cmbShemaDataRow("Value") = 10
cmbShemaData.Rows.Add (cmbShemaDataRow)
cmbShema.DisplayMember = "name"
cmbShema.ValueMember = "Value"
cmbShema.DataSource = cmbShemaData
 cmbShema.SelectedValue=CInt(Item.Shema)
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
   item.Shema = cmbShema.SelectedValue
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK =( txtName.text <> "" ) 
if mIsOK then mIsOK =(cmbShema.SelectedIndex >=0)
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
