
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Генераторы режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editGENERATOR_TARGET
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
Friend WithEvents lblTargetType  as  System.Windows.Forms.Label
Friend WithEvents cmbTargetType As System.Windows.Forms.ComboBox
Friend cmbTargetTypeDATA As DataTable
Friend cmbTargetTypeDATAROW As DataRow
Friend WithEvents lblQueueName  as  System.Windows.Forms.Label
Friend WithEvents txtQueueName As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblGeneratorProgID  as  System.Windows.Forms.Label
Friend WithEvents txtGeneratorProgID As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblGeneratorStyle  as  System.Windows.Forms.Label
Friend WithEvents cmbGeneratorStyle As System.Windows.Forms.ComboBox
Friend cmbGeneratorStyleDATA As DataTable
Friend cmbGeneratorStyleDATAROW As DataRow
Friend WithEvents lblTheDevelopmentEnv  as  System.Windows.Forms.Label
Friend WithEvents cmbTheDevelopmentEnv As System.Windows.Forms.ComboBox
Friend cmbTheDevelopmentEnvDATA As DataTable
Friend cmbTheDevelopmentEnvDATAROW As DataRow

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
Me.lblTargetType = New System.Windows.Forms.Label
Me.cmbTargetType = New System.Windows.Forms.ComboBox
Me.lblQueueName = New System.Windows.Forms.Label
Me.txtQueueName = New LATIR2GuiManager.TouchTextBox
Me.lblGeneratorProgID = New System.Windows.Forms.Label
Me.txtGeneratorProgID = New LATIR2GuiManager.TouchTextBox
Me.lblGeneratorStyle = New System.Windows.Forms.Label
Me.cmbGeneratorStyle = New System.Windows.Forms.ComboBox
Me.lblTheDevelopmentEnv = New System.Windows.Forms.Label
Me.cmbTheDevelopmentEnv = New System.Windows.Forms.ComboBox

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
Me.lblTargetType.Location = New System.Drawing.Point(20,52)
Me.lblTargetType.name = "lblTargetType"
Me.lblTargetType.Size = New System.Drawing.Size(200, 20)
Me.lblTargetType.TabIndex = 3
Me.lblTargetType.Text = "Тип платформы"
Me.lblTargetType.ForeColor = System.Drawing.Color.Black
Me.cmbTargetType.Location = New System.Drawing.Point(20,74)
Me.cmbTargetType.name = "cmbTargetType"
Me.cmbTargetType.Size = New System.Drawing.Size(200,  20)
Me.cmbTargetType.TabIndex = 4
Me.cmbTargetType.DropDownStyle = ComboBoxStyle.DropDownList
Me.lblQueueName.Location = New System.Drawing.Point(20,99)
Me.lblQueueName.name = "lblQueueName"
Me.lblQueueName.Size = New System.Drawing.Size(200, 20)
Me.lblQueueName.TabIndex = 5
Me.lblQueueName.Text = "Очередь"
Me.lblQueueName.ForeColor = System.Drawing.Color.Blue
Me.txtQueueName.Location = New System.Drawing.Point(20,121)
Me.txtQueueName.name = "txtQueueName"
Me.txtQueueName.Size = New System.Drawing.Size(200, 20)
Me.txtQueueName.TabIndex = 6
Me.txtQueueName.Text = "" 
Me.lblGeneratorProgID.Location = New System.Drawing.Point(20,146)
Me.lblGeneratorProgID.name = "lblGeneratorProgID"
Me.lblGeneratorProgID.Size = New System.Drawing.Size(200, 20)
Me.lblGeneratorProgID.TabIndex = 7
Me.lblGeneratorProgID.Text = "COM класс"
Me.lblGeneratorProgID.ForeColor = System.Drawing.Color.Blue
Me.txtGeneratorProgID.Location = New System.Drawing.Point(20,168)
Me.txtGeneratorProgID.name = "txtGeneratorProgID"
Me.txtGeneratorProgID.Size = New System.Drawing.Size(200, 20)
Me.txtGeneratorProgID.TabIndex = 8
Me.txtGeneratorProgID.Text = "" 
Me.lblGeneratorStyle.Location = New System.Drawing.Point(20,193)
Me.lblGeneratorStyle.name = "lblGeneratorStyle"
Me.lblGeneratorStyle.Size = New System.Drawing.Size(200, 20)
Me.lblGeneratorStyle.TabIndex = 9
Me.lblGeneratorStyle.Text = "Вариант"
Me.lblGeneratorStyle.ForeColor = System.Drawing.Color.Blue
Me.cmbGeneratorStyle.Location = New System.Drawing.Point(20,215)
Me.cmbGeneratorStyle.name = "cmbGeneratorStyle"
Me.cmbGeneratorStyle.Size = New System.Drawing.Size(200,  20)
Me.cmbGeneratorStyle.TabIndex = 10
Me.lblTheDevelopmentEnv.Location = New System.Drawing.Point(20,240)
Me.lblTheDevelopmentEnv.name = "lblTheDevelopmentEnv"
Me.lblTheDevelopmentEnv.Size = New System.Drawing.Size(200, 20)
Me.lblTheDevelopmentEnv.TabIndex = 11
Me.lblTheDevelopmentEnv.Text = "Среда разработки"
Me.lblTheDevelopmentEnv.ForeColor = System.Drawing.Color.Blue
Me.cmbTheDevelopmentEnv.Location = New System.Drawing.Point(20,262)
Me.cmbTheDevelopmentEnv.name = "cmbTheDevelopmentEnv"
Me.cmbTheDevelopmentEnv.Size = New System.Drawing.Size(200,  20)
Me.cmbTheDevelopmentEnv.TabIndex = 12
Me.cmbTheDevelopmentEnv.DropDownStyle = ComboBoxStyle.DropDownList
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTargetType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbTargetType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblQueueName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtQueueName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblGeneratorProgID)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtGeneratorProgID)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblGeneratorStyle)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbGeneratorStyle)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTheDevelopmentEnv)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbTheDevelopmentEnv)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editGENERATOR_TARGET"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
  Changing

end sub
private sub cmbTargetType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTargetType.SelectedIndexChanged
  try
     Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtQueueName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQueueName.TextChanged
  Changing

end sub
private sub txtGeneratorProgID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGeneratorProgID.TextChanged
  Changing

end sub
private sub cmbGeneratorStyle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGeneratorStyle.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmbTheDevelopmentEnv_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTheDevelopmentEnv.SelectedIndexChanged
  try
     Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub

Public Item As MTZMetaModel.MTZMetaModel.GENERATOR_TARGET
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,MTZMetaModel.MTZMetaModel.GENERATOR_TARGET)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

txtName.text = item.Name
cmbTargetTypeData = New DataTable
cmbTargetTypeData.Columns.Add("name", GetType(System.String))
cmbTargetTypeData.Columns.Add("Value", GetType(System.Int32))
try
cmbTargetTypeDataRow = cmbTargetTypeData.NewRow
cmbTargetTypeDataRow("name") = "СУБД"
cmbTargetTypeDataRow("Value") = 0
cmbTargetTypeData.Rows.Add (cmbTargetTypeDataRow)
cmbTargetTypeDataRow = cmbTargetTypeData.NewRow
cmbTargetTypeDataRow("name") = "МОДЕЛЬ"
cmbTargetTypeDataRow("Value") = 1
cmbTargetTypeData.Rows.Add (cmbTargetTypeDataRow)
cmbTargetTypeDataRow = cmbTargetTypeData.NewRow
cmbTargetTypeDataRow("name") = "Приложение"
cmbTargetTypeDataRow("Value") = 2
cmbTargetTypeData.Rows.Add (cmbTargetTypeDataRow)
cmbTargetTypeDataRow = cmbTargetTypeData.NewRow
cmbTargetTypeDataRow("name") = "Документация"
cmbTargetTypeDataRow("Value") = 3
cmbTargetTypeData.Rows.Add (cmbTargetTypeDataRow)
cmbTargetTypeDataRow = cmbTargetTypeData.NewRow
cmbTargetTypeDataRow("name") = "АРМ"
cmbTargetTypeDataRow("Value") = 4
cmbTargetTypeData.Rows.Add (cmbTargetTypeDataRow)
cmbTargetType.DisplayMember = "name"
cmbTargetType.ValueMember = "Value"
cmbTargetType.DataSource = cmbTargetTypeData
 cmbTargetType.SelectedValue=CInt(Item.TargetType)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
txtQueueName.text = item.QueueName
txtGeneratorProgID.text = item.GeneratorProgID
cmbGeneratorStyleData = New DataTable
cmbGeneratorStyleData.Columns.Add("name", GetType(System.String))
cmbGeneratorStyleData.Columns.Add("Value", GetType(System.Int32))
try
cmbGeneratorStyleDataRow = cmbGeneratorStyleData.NewRow
cmbGeneratorStyleDataRow("name") = "Один тип"
cmbGeneratorStyleDataRow("Value") = 0
cmbGeneratorStyleData.Rows.Add (cmbGeneratorStyleDataRow)
cmbGeneratorStyleDataRow = cmbGeneratorStyleData.NewRow
cmbGeneratorStyleDataRow("name") = "Все типы сразу"
cmbGeneratorStyleDataRow("Value") = 1
cmbGeneratorStyleData.Rows.Add (cmbGeneratorStyleDataRow)
cmbGeneratorStyle.DisplayMember = "name"
cmbGeneratorStyle.ValueMember = "Value"
cmbGeneratorStyle.DataSource = cmbGeneratorStyleData
 cmbGeneratorStyle.SelectedValue=CInt(Item.GeneratorStyle)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
cmbTheDevelopmentEnvData = New DataTable
cmbTheDevelopmentEnvData.Columns.Add("name", GetType(System.String))
cmbTheDevelopmentEnvData.Columns.Add("Value", GetType(System.Int32))
try
cmbTheDevelopmentEnvDataRow = cmbTheDevelopmentEnvData.NewRow
cmbTheDevelopmentEnvDataRow("name") = "VB6"
cmbTheDevelopmentEnvDataRow("Value") = 0
cmbTheDevelopmentEnvData.Rows.Add (cmbTheDevelopmentEnvDataRow)
cmbTheDevelopmentEnvDataRow = cmbTheDevelopmentEnvData.NewRow
cmbTheDevelopmentEnvDataRow("name") = "DOTNET"
cmbTheDevelopmentEnvDataRow("Value") = 1
cmbTheDevelopmentEnvData.Rows.Add (cmbTheDevelopmentEnvDataRow)
cmbTheDevelopmentEnvDataRow = cmbTheDevelopmentEnvData.NewRow
cmbTheDevelopmentEnvDataRow("name") = "JAVA"
cmbTheDevelopmentEnvDataRow("Value") = 2
cmbTheDevelopmentEnvData.Rows.Add (cmbTheDevelopmentEnvDataRow)
cmbTheDevelopmentEnvDataRow = cmbTheDevelopmentEnvData.NewRow
cmbTheDevelopmentEnvDataRow("name") = "OTHER"
cmbTheDevelopmentEnvDataRow("Value") = 3
cmbTheDevelopmentEnvData.Rows.Add (cmbTheDevelopmentEnvDataRow)
cmbTheDevelopmentEnv.DisplayMember = "name"
cmbTheDevelopmentEnv.ValueMember = "Value"
cmbTheDevelopmentEnv.DataSource = cmbTheDevelopmentEnvData
 cmbTheDevelopmentEnv.SelectedValue=CInt(Item.TheDevelopmentEnv)
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
   item.TargetType = cmbTargetType.SelectedValue
item.QueueName = txtQueueName.text
item.GeneratorProgID = txtGeneratorProgID.text
   item.GeneratorStyle = cmbGeneratorStyle.SelectedValue
   item.TheDevelopmentEnv = cmbTheDevelopmentEnv.SelectedValue
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK =( txtName.text <> "" ) 
if mIsOK then mIsOK =(cmbTargetType.SelectedIndex >=0)
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
