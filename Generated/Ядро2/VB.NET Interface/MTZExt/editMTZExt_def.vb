
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Описание режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editMTZExt_def
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
Friend WithEvents txtName As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblExtType  as  System.Windows.Forms.Label
Friend WithEvents cmbExtType As System.Windows.Forms.ComboBox
Friend cmbExtTypeDATA As DataTable
Friend cmbExtTypeDATAROW As DataRow
Friend WithEvents lblTheDescription  as  System.Windows.Forms.Label
Friend WithEvents txtTheDescription As LATIR2GuiManager.TouchTextBox

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
Me.txtName = New LATIR2GuiManager.TouchTextBox
Me.lblExtType = New System.Windows.Forms.Label
Me.cmbExtType = New System.Windows.Forms.ComboBox
Me.lblTheDescription = New System.Windows.Forms.Label
Me.txtTheDescription = New LATIR2GuiManager.TouchTextBox

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
Me.lblExtType.Location = New System.Drawing.Point(20,52)
Me.lblExtType.name = "lblExtType"
Me.lblExtType.Size = New System.Drawing.Size(200, 20)
Me.lblExtType.TabIndex = 3
Me.lblExtType.Text = "Тип расширения"
Me.lblExtType.ForeColor = System.Drawing.Color.Black
Me.cmbExtType.Location = New System.Drawing.Point(20,74)
Me.cmbExtType.name = "cmbExtType"
Me.cmbExtType.Size = New System.Drawing.Size(200,  20)
Me.cmbExtType.TabIndex = 4
Me.cmbExtType.DropDownStyle = ComboBoxStyle.DropDownList
Me.lblTheDescription.Location = New System.Drawing.Point(20,99)
Me.lblTheDescription.name = "lblTheDescription"
Me.lblTheDescription.Size = New System.Drawing.Size(200, 20)
Me.lblTheDescription.TabIndex = 5
Me.lblTheDescription.Text = "Описание"
Me.lblTheDescription.ForeColor = System.Drawing.Color.Blue
Me.txtTheDescription.Location = New System.Drawing.Point(20,121)
Me.txtTheDescription.name = "txtTheDescription"
Me.txtTheDescription.MultiLine = True
Me.txtTheDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtTheDescription.Size = New System.Drawing.Size(200, 50 + 20)
Me.txtTheDescription.TabIndex = 6
Me.txtTheDescription.Text = "" 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblExtType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbExtType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTheDescription)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTheDescription)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editMTZExt_def"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
  Changing

end sub
private sub cmbExtType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbExtType.SelectedIndexChanged
  try
     Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtTheDescription_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTheDescription.TextChanged
  Changing

end sub

Public Item As MTZExt.MTZExt.MTZExt_def
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,MTZExt.MTZExt.MTZExt_def)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

txtName.text = item.Name
cmbExtTypeData = New DataTable
cmbExtTypeData.Columns.Add("name", GetType(System.String))
cmbExtTypeData.Columns.Add("Value", GetType(System.Int32))
try
cmbExtTypeDataRow = cmbExtTypeData.NewRow
cmbExtTypeDataRow("name") = "StatusExt"
cmbExtTypeDataRow("Value") = 0
cmbExtTypeData.Rows.Add (cmbExtTypeDataRow)
cmbExtTypeDataRow = cmbExtTypeData.NewRow
cmbExtTypeDataRow("name") = "OnFormExt"
cmbExtTypeDataRow("Value") = 1
cmbExtTypeData.Rows.Add (cmbExtTypeDataRow)
cmbExtTypeDataRow = cmbExtTypeData.NewRow
cmbExtTypeDataRow("name") = "CustomExt"
cmbExtTypeDataRow("Value") = 2
cmbExtTypeData.Rows.Add (cmbExtTypeDataRow)
cmbExtTypeDataRow = cmbExtTypeData.NewRow
cmbExtTypeDataRow("name") = "JrnlAddExt"
cmbExtTypeDataRow("Value") = 3
cmbExtTypeData.Rows.Add (cmbExtTypeDataRow)
cmbExtTypeDataRow = cmbExtTypeData.NewRow
cmbExtTypeDataRow("name") = "JrnlRunExt"
cmbExtTypeDataRow("Value") = 4
cmbExtTypeData.Rows.Add (cmbExtTypeDataRow)
cmbExtTypeDataRow = cmbExtTypeData.NewRow
cmbExtTypeDataRow("name") = "DefaultExt"
cmbExtTypeDataRow("Value") = 5
cmbExtTypeData.Rows.Add (cmbExtTypeDataRow)
cmbExtTypeDataRow = cmbExtTypeData.NewRow
cmbExtTypeDataRow("name") = "VerifyRowExt"
cmbExtTypeDataRow("Value") = 6
cmbExtTypeData.Rows.Add (cmbExtTypeDataRow)
cmbExtTypeDataRow = cmbExtTypeData.NewRow
cmbExtTypeDataRow("name") = "CodeGenerator"
cmbExtTypeDataRow("Value") = 7
cmbExtTypeData.Rows.Add (cmbExtTypeDataRow)
cmbExtTypeDataRow = cmbExtTypeData.NewRow
cmbExtTypeDataRow("name") = "ARMGenerator"
cmbExtTypeDataRow("Value") = 8
cmbExtTypeData.Rows.Add (cmbExtTypeDataRow)
cmbExtType.DisplayMember = "name"
cmbExtType.ValueMember = "Value"
cmbExtType.DataSource = cmbExtTypeData
 cmbExtType.SelectedValue=CInt(Item.ExtType)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
txtTheDescription.text = item.TheDescription
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
   item.ExtType = cmbExtType.SelectedValue
item.TheDescription = txtTheDescription.text
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK =( txtName.text <> "" ) 
if mIsOK then mIsOK =(cmbExtType.SelectedIndex >=0)
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
