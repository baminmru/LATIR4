
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Представление режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editPARTVIEW
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
Friend WithEvents lblthe_Alias  as  System.Windows.Forms.Label
Friend WithEvents txtthe_Alias As System.Windows.Forms.TextBox
Friend WithEvents lblForChoose  as  System.Windows.Forms.Label
Friend WithEvents cmbForChoose As System.Windows.Forms.ComboBox
Friend cmbForChooseDATA As DataTable
Friend cmbForChooseDATAROW As DataRow
Friend WithEvents lblFilterField0  as  System.Windows.Forms.Label
Friend WithEvents txtFilterField0 As System.Windows.Forms.TextBox
Friend WithEvents lblFilterField1  as  System.Windows.Forms.Label
Friend WithEvents txtFilterField1 As System.Windows.Forms.TextBox
Friend WithEvents lblFilterField2  as  System.Windows.Forms.Label
Friend WithEvents txtFilterField2 As System.Windows.Forms.TextBox
Friend WithEvents lblFilterField3  as  System.Windows.Forms.Label
Friend WithEvents txtFilterField3 As System.Windows.Forms.TextBox

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
Me.lblthe_Alias = New System.Windows.Forms.Label
Me.txtthe_Alias = New System.Windows.Forms.TextBox
Me.lblForChoose = New System.Windows.Forms.Label
Me.cmbForChoose = New System.Windows.Forms.ComboBox
Me.lblFilterField0 = New System.Windows.Forms.Label
Me.txtFilterField0 = New System.Windows.Forms.TextBox
Me.lblFilterField1 = New System.Windows.Forms.Label
Me.txtFilterField1 = New System.Windows.Forms.TextBox
Me.lblFilterField2 = New System.Windows.Forms.Label
Me.txtFilterField2 = New System.Windows.Forms.TextBox
Me.lblFilterField3 = New System.Windows.Forms.Label
Me.txtFilterField3 = New System.Windows.Forms.TextBox

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
Me.lblthe_Alias.Location = New System.Drawing.Point(20,52)
Me.lblthe_Alias.name = "lblthe_Alias"
Me.lblthe_Alias.Size = New System.Drawing.Size(200, 20)
Me.lblthe_Alias.TabIndex = 3
Me.lblthe_Alias.Text = "Псевдоним"
Me.lblthe_Alias.ForeColor = System.Drawing.Color.Black
Me.txtthe_Alias.Location = New System.Drawing.Point(20,74)
Me.txtthe_Alias.name = "txtthe_Alias"
Me.txtthe_Alias.Size = New System.Drawing.Size(200, 20)
Me.txtthe_Alias.TabIndex = 4
Me.txtthe_Alias.Text = "" 
Me.lblForChoose.Location = New System.Drawing.Point(20,99)
Me.lblForChoose.name = "lblForChoose"
Me.lblForChoose.Size = New System.Drawing.Size(200, 20)
Me.lblForChoose.TabIndex = 5
Me.lblForChoose.Text = "Для поиска"
Me.lblForChoose.ForeColor = System.Drawing.Color.Black
Me.cmbForChoose.Location = New System.Drawing.Point(20,121)
Me.cmbForChoose.name = "cmbForChoose"
Me.cmbForChoose.Size = New System.Drawing.Size(200,  20)
Me.cmbForChoose.TabIndex = 6
Me.lblFilterField0.Location = New System.Drawing.Point(20,146)
Me.lblFilterField0.name = "lblFilterField0"
Me.lblFilterField0.Size = New System.Drawing.Size(200, 20)
Me.lblFilterField0.TabIndex = 7
Me.lblFilterField0.Text = "Поле - фильтр 0"
Me.lblFilterField0.ForeColor = System.Drawing.Color.Blue
Me.txtFilterField0.Location = New System.Drawing.Point(20,168)
Me.txtFilterField0.name = "txtFilterField0"
Me.txtFilterField0.Size = New System.Drawing.Size(200, 20)
Me.txtFilterField0.TabIndex = 8
Me.txtFilterField0.Text = "" 
Me.lblFilterField1.Location = New System.Drawing.Point(20,193)
Me.lblFilterField1.name = "lblFilterField1"
Me.lblFilterField1.Size = New System.Drawing.Size(200, 20)
Me.lblFilterField1.TabIndex = 9
Me.lblFilterField1.Text = "Поле - фильтр 1"
Me.lblFilterField1.ForeColor = System.Drawing.Color.Blue
Me.txtFilterField1.Location = New System.Drawing.Point(20,215)
Me.txtFilterField1.name = "txtFilterField1"
Me.txtFilterField1.Size = New System.Drawing.Size(200, 20)
Me.txtFilterField1.TabIndex = 10
Me.txtFilterField1.Text = "" 
Me.lblFilterField2.Location = New System.Drawing.Point(20,240)
Me.lblFilterField2.name = "lblFilterField2"
Me.lblFilterField2.Size = New System.Drawing.Size(200, 20)
Me.lblFilterField2.TabIndex = 11
Me.lblFilterField2.Text = "Поле - фильтр 2"
Me.lblFilterField2.ForeColor = System.Drawing.Color.Blue
Me.txtFilterField2.Location = New System.Drawing.Point(20,262)
Me.txtFilterField2.name = "txtFilterField2"
Me.txtFilterField2.Size = New System.Drawing.Size(200, 20)
Me.txtFilterField2.TabIndex = 12
Me.txtFilterField2.Text = "" 
Me.lblFilterField3.Location = New System.Drawing.Point(20,287)
Me.lblFilterField3.name = "lblFilterField3"
Me.lblFilterField3.Size = New System.Drawing.Size(200, 20)
Me.lblFilterField3.TabIndex = 13
Me.lblFilterField3.Text = "Поле - фильтр 3"
Me.lblFilterField3.ForeColor = System.Drawing.Color.Blue
Me.txtFilterField3.Location = New System.Drawing.Point(20,309)
Me.txtFilterField3.name = "txtFilterField3"
Me.txtFilterField3.Size = New System.Drawing.Size(200, 20)
Me.txtFilterField3.TabIndex = 14
Me.txtFilterField3.Text = "" 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblthe_Alias)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtthe_Alias)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblForChoose)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbForChoose)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblFilterField0)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtFilterField0)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblFilterField1)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtFilterField1)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblFilterField2)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtFilterField2)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblFilterField3)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtFilterField3)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editPARTVIEW"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
  Changing

end sub
private sub txtthe_Alias_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtthe_Alias.TextChanged
  Changing

end sub
private sub cmbForChoose_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbForChoose.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtFilterField0_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFilterField0.TextChanged
  Changing

end sub
private sub txtFilterField1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFilterField1.TextChanged
  Changing

end sub
private sub txtFilterField2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFilterField2.TextChanged
  Changing

end sub
private sub txtFilterField3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFilterField3.TextChanged
  Changing

end sub

Public Item As MTZMetaModel.MTZMetaModel.PARTVIEW
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,MTZMetaModel.MTZMetaModel.PARTVIEW)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

txtName.text = item.Name
txtthe_Alias.text = item.the_Alias
cmbForChooseData = New DataTable
cmbForChooseData.Columns.Add("name", GetType(System.String))
cmbForChooseData.Columns.Add("Value", GetType(System.Int32))
try
cmbForChooseDataRow = cmbForChooseData.NewRow
cmbForChooseDataRow("name") = "Да"
cmbForChooseDataRow("Value") = -1
cmbForChooseData.Rows.Add (cmbForChooseDataRow)
cmbForChooseDataRow = cmbForChooseData.NewRow
cmbForChooseDataRow("name") = "Нет"
cmbForChooseDataRow("Value") = 0
cmbForChooseData.Rows.Add (cmbForChooseDataRow)
cmbForChoose.DisplayMember = "name"
cmbForChoose.ValueMember = "Value"
cmbForChoose.DataSource = cmbForChooseData
 cmbForChoose.SelectedValue=CInt(Item.ForChoose)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
txtFilterField0.text = item.FilterField0
txtFilterField1.text = item.FilterField1
txtFilterField2.text = item.FilterField2
txtFilterField3.text = item.FilterField3
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
item.the_Alias = txtthe_Alias.text
   item.ForChoose = cmbForChoose.SelectedValue
item.FilterField0 = txtFilterField0.text
item.FilterField1 = txtFilterField1.text
item.FilterField2 = txtFilterField2.text
item.FilterField3 = txtFilterField3.text
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK =( txtName.text <> "" ) 
if mIsOK then mIsOK =( txtthe_Alias.text <> "" ) 
if mIsOK then mIsOK =(cmbForChoose.SelectedIndex >=0)
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
