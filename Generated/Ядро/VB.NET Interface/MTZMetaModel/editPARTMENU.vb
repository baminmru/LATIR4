
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Методы раздела режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editPARTMENU
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
Friend WithEvents lblCaption  as  System.Windows.Forms.Label
Friend WithEvents txtCaption As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblToolTip  as  System.Windows.Forms.Label
Friend WithEvents txtToolTip As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblthe_Action  as  System.Windows.Forms.Label
Friend WithEvents txtthe_Action As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdthe_Action As System.Windows.Forms.Button
Friend WithEvents cmdthe_ActionClear As System.Windows.Forms.Button
Friend WithEvents lblIsMenuItem  as  System.Windows.Forms.Label
Friend WithEvents cmbIsMenuItem As System.Windows.Forms.ComboBox
Friend cmbIsMenuItemDATA As DataTable
Friend cmbIsMenuItemDATAROW As DataRow
Friend WithEvents lblIsToolBarButton  as  System.Windows.Forms.Label
Friend WithEvents cmbIsToolBarButton As System.Windows.Forms.ComboBox
Friend cmbIsToolBarButtonDATA As DataTable
Friend cmbIsToolBarButtonDATAROW As DataRow
Friend WithEvents lblHotKey  as  System.Windows.Forms.Label
Friend WithEvents txtHotKey As LATIR2GuiManager.TouchTextBox

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
Me.lblCaption = New System.Windows.Forms.Label
Me.txtCaption = New LATIR2GuiManager.TouchTextBox
Me.lblToolTip = New System.Windows.Forms.Label
Me.txtToolTip = New LATIR2GuiManager.TouchTextBox
Me.lblthe_Action = New System.Windows.Forms.Label
Me.txtthe_Action = New LATIR2GuiManager.TouchTextBox
Me.cmdthe_Action = New System.Windows.Forms.Button
Me.cmdthe_ActionClear = New System.Windows.Forms.Button
Me.lblIsMenuItem = New System.Windows.Forms.Label
Me.cmbIsMenuItem = New System.Windows.Forms.ComboBox
Me.lblIsToolBarButton = New System.Windows.Forms.Label
Me.cmbIsToolBarButton = New System.Windows.Forms.ComboBox
Me.lblHotKey = New System.Windows.Forms.Label
Me.txtHotKey = New LATIR2GuiManager.TouchTextBox

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
Me.lblCaption.Location = New System.Drawing.Point(20,52)
Me.lblCaption.name = "lblCaption"
Me.lblCaption.Size = New System.Drawing.Size(200, 20)
Me.lblCaption.TabIndex = 3
Me.lblCaption.Text = "Заголовок"
Me.lblCaption.ForeColor = System.Drawing.Color.Blue
Me.txtCaption.Location = New System.Drawing.Point(20,74)
Me.txtCaption.name = "txtCaption"
Me.txtCaption.Size = New System.Drawing.Size(200, 20)
Me.txtCaption.TabIndex = 4
Me.txtCaption.Text = "" 
Me.lblToolTip.Location = New System.Drawing.Point(20,99)
Me.lblToolTip.name = "lblToolTip"
Me.lblToolTip.Size = New System.Drawing.Size(200, 20)
Me.lblToolTip.TabIndex = 5
Me.lblToolTip.Text = "Подсказка"
Me.lblToolTip.ForeColor = System.Drawing.Color.Blue
Me.txtToolTip.Location = New System.Drawing.Point(20,121)
Me.txtToolTip.name = "txtToolTip"
Me.txtToolTip.Size = New System.Drawing.Size(200, 20)
Me.txtToolTip.TabIndex = 6
Me.txtToolTip.Text = "" 
Me.lblthe_Action.Location = New System.Drawing.Point(20,146)
Me.lblthe_Action.name = "lblthe_Action"
Me.lblthe_Action.Size = New System.Drawing.Size(200, 20)
Me.lblthe_Action.TabIndex = 7
Me.lblthe_Action.Text = "Метод"
Me.lblthe_Action.ForeColor = System.Drawing.Color.Blue
Me.txtthe_Action.Location = New System.Drawing.Point(20,168)
Me.txtthe_Action.name = "txtthe_Action"
Me.txtthe_Action.ReadOnly = True
Me.txtthe_Action.Size = New System.Drawing.Size(155, 20)
Me.txtthe_Action.TabIndex = 8
Me.txtthe_Action.Text = "" 
Me.cmdthe_Action.Location = New System.Drawing.Point(176,168)
Me.cmdthe_Action.name = "cmdthe_Action"
Me.cmdthe_Action.Size = New System.Drawing.Size(22, 20)
Me.cmdthe_Action.TabIndex = 9
Me.cmdthe_Action.Text = "..." 
Me.cmdthe_ActionClear.Location = New System.Drawing.Point(198,168)
Me.cmdthe_ActionClear.name = "cmdthe_ActionClear"
Me.cmdthe_ActionClear.Size = New System.Drawing.Size(22, 20)
Me.cmdthe_ActionClear.TabIndex = 10
Me.cmdthe_ActionClear.Text = "X" 
Me.lblIsMenuItem.Location = New System.Drawing.Point(20,193)
Me.lblIsMenuItem.name = "lblIsMenuItem"
Me.lblIsMenuItem.Size = New System.Drawing.Size(200, 20)
Me.lblIsMenuItem.TabIndex = 11
Me.lblIsMenuItem.Text = "Включать в меню"
Me.lblIsMenuItem.ForeColor = System.Drawing.Color.Black
Me.cmbIsMenuItem.Location = New System.Drawing.Point(20,215)
Me.cmbIsMenuItem.name = "cmbIsMenuItem"
Me.cmbIsMenuItem.Size = New System.Drawing.Size(200,  20)
Me.cmbIsMenuItem.TabIndex = 12
Me.lblIsToolBarButton.Location = New System.Drawing.Point(20,240)
Me.lblIsToolBarButton.name = "lblIsToolBarButton"
Me.lblIsToolBarButton.Size = New System.Drawing.Size(200, 20)
Me.lblIsToolBarButton.TabIndex = 13
Me.lblIsToolBarButton.Text = "В тулбар"
Me.lblIsToolBarButton.ForeColor = System.Drawing.Color.Black
Me.cmbIsToolBarButton.Location = New System.Drawing.Point(20,262)
Me.cmbIsToolBarButton.name = "cmbIsToolBarButton"
Me.cmbIsToolBarButton.Size = New System.Drawing.Size(200,  20)
Me.cmbIsToolBarButton.TabIndex = 14
Me.lblHotKey.Location = New System.Drawing.Point(20,287)
Me.lblHotKey.name = "lblHotKey"
Me.lblHotKey.Size = New System.Drawing.Size(200, 20)
Me.lblHotKey.TabIndex = 15
Me.lblHotKey.Text = "Горячая клавиша"
Me.lblHotKey.ForeColor = System.Drawing.Color.Blue
Me.txtHotKey.Location = New System.Drawing.Point(20,309)
Me.txtHotKey.name = "txtHotKey"
Me.txtHotKey.Size = New System.Drawing.Size(200, 20)
Me.txtHotKey.TabIndex = 16
Me.txtHotKey.Text = "" 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblCaption)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtCaption)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblToolTip)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtToolTip)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblthe_Action)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtthe_Action)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdthe_Action)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdthe_ActionClear)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblIsMenuItem)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbIsMenuItem)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblIsToolBarButton)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbIsToolBarButton)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblHotKey)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtHotKey)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editPARTMENU"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
  Changing

end sub
private sub txtCaption_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCaption.TextChanged
  Changing

end sub
private sub txtToolTip_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtToolTip.TextChanged
  Changing

end sub
private sub txtthe_Action_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtthe_Action.TextChanged
  Changing

end sub
private sub cmdthe_Action_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdthe_Action.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("SHAREDMETHOD","",System.guid.Empty, id, brief) Then
          txtthe_Action.Tag = id
          txtthe_Action.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmdthe_ActionClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdthe_ActionClear.Click
  try
          txtthe_Action.Tag = Guid.Empty
          txtthe_Action.text = ""
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmbIsMenuItem_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbIsMenuItem.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmbIsToolBarButton_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbIsToolBarButton.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtHotKey_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHotKey.TextChanged
  Changing

end sub

Public Item As MTZMetaModel.MTZMetaModel.PARTMENU
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,MTZMetaModel.MTZMetaModel.PARTMENU)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

txtName.text = item.Name
txtCaption.text = item.Caption
txtToolTip.text = item.ToolTip
If Not item.the_Action Is Nothing Then
  txtthe_Action.Tag = item.the_Action.id
  txtthe_Action.text = item.the_Action.brief
else
  txtthe_Action.Tag = System.Guid.Empty 
  txtthe_Action.text = "" 
End If
cmbIsMenuItemData = New DataTable
cmbIsMenuItemData.Columns.Add("name", GetType(System.String))
cmbIsMenuItemData.Columns.Add("Value", GetType(System.Int32))
try
cmbIsMenuItemDataRow = cmbIsMenuItemData.NewRow
cmbIsMenuItemDataRow("name") = "Да"
cmbIsMenuItemDataRow("Value") = -1
cmbIsMenuItemData.Rows.Add (cmbIsMenuItemDataRow)
cmbIsMenuItemDataRow = cmbIsMenuItemData.NewRow
cmbIsMenuItemDataRow("name") = "Нет"
cmbIsMenuItemDataRow("Value") = 0
cmbIsMenuItemData.Rows.Add (cmbIsMenuItemDataRow)
cmbIsMenuItem.DisplayMember = "name"
cmbIsMenuItem.ValueMember = "Value"
cmbIsMenuItem.DataSource = cmbIsMenuItemData
 cmbIsMenuItem.SelectedValue=CInt(Item.IsMenuItem)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
cmbIsToolBarButtonData = New DataTable
cmbIsToolBarButtonData.Columns.Add("name", GetType(System.String))
cmbIsToolBarButtonData.Columns.Add("Value", GetType(System.Int32))
try
cmbIsToolBarButtonDataRow = cmbIsToolBarButtonData.NewRow
cmbIsToolBarButtonDataRow("name") = "Да"
cmbIsToolBarButtonDataRow("Value") = -1
cmbIsToolBarButtonData.Rows.Add (cmbIsToolBarButtonDataRow)
cmbIsToolBarButtonDataRow = cmbIsToolBarButtonData.NewRow
cmbIsToolBarButtonDataRow("name") = "Нет"
cmbIsToolBarButtonDataRow("Value") = 0
cmbIsToolBarButtonData.Rows.Add (cmbIsToolBarButtonDataRow)
cmbIsToolBarButton.DisplayMember = "name"
cmbIsToolBarButton.ValueMember = "Value"
cmbIsToolBarButton.DataSource = cmbIsToolBarButtonData
 cmbIsToolBarButton.SelectedValue=CInt(Item.IsToolBarButton)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
txtHotKey.text = item.HotKey
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
item.Caption = txtCaption.text
item.ToolTip = txtToolTip.text
If not txtthe_Action.Tag.Equals(System.Guid.Empty) Then
  item.the_Action = Item.Application.FindRowObject("SHAREDMETHOD",txtthe_Action.Tag)
Else
   item.the_Action = Nothing
End If
   item.IsMenuItem = cmbIsMenuItem.SelectedValue
   item.IsToolBarButton = cmbIsToolBarButton.SelectedValue
item.HotKey = txtHotKey.text
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK =( txtName.text <> "" ) 
if mIsOK then mIsOK =(cmbIsMenuItem.SelectedIndex >=0)
if mIsOK then mIsOK =(cmbIsToolBarButton.SelectedIndex >=0)
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
