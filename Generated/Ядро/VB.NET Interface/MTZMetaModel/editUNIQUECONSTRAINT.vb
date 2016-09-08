
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Ограничение уникальности режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editUNIQUECONSTRAINT
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
Friend WithEvents lblPerParent  as  System.Windows.Forms.Label
Friend WithEvents cmbPerParent As System.Windows.Forms.ComboBox
Friend cmbPerParentDATA As DataTable
Friend cmbPerParentDATAROW As DataRow
Friend WithEvents lblTheComment  as  System.Windows.Forms.Label
Friend WithEvents txtTheComment As System.Windows.Forms.TextBox

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
Me.lblPerParent = New System.Windows.Forms.Label
Me.cmbPerParent = New System.Windows.Forms.ComboBox
Me.lblTheComment = New System.Windows.Forms.Label
Me.txtTheComment = New System.Windows.Forms.TextBox

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
Me.lblPerParent.Location = New System.Drawing.Point(20,52)
Me.lblPerParent.name = "lblPerParent"
Me.lblPerParent.Size = New System.Drawing.Size(200, 20)
Me.lblPerParent.TabIndex = 3
Me.lblPerParent.Text = "По родителю"
Me.lblPerParent.ForeColor = System.Drawing.Color.Black
Me.cmbPerParent.Location = New System.Drawing.Point(20,74)
Me.cmbPerParent.name = "cmbPerParent"
Me.cmbPerParent.Size = New System.Drawing.Size(200,  20)
Me.cmbPerParent.TabIndex = 4
Me.lblTheComment.Location = New System.Drawing.Point(20,99)
Me.lblTheComment.name = "lblTheComment"
Me.lblTheComment.Size = New System.Drawing.Size(200, 20)
Me.lblTheComment.TabIndex = 5
Me.lblTheComment.Text = "Описание"
Me.lblTheComment.ForeColor = System.Drawing.Color.Blue
Me.txtTheComment.Location = New System.Drawing.Point(20,121)
Me.txtTheComment.name = "txtTheComment"
Me.txtTheComment.MultiLine = True
Me.txtTheComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtTheComment.Size = New System.Drawing.Size(200, 50 + 20)
Me.txtTheComment.TabIndex = 6
Me.txtTheComment.Text = "" 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblPerParent)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbPerParent)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTheComment)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTheComment)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editUNIQUECONSTRAINT"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
  Changing

end sub
private sub cmbPerParent_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPerParent.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtTheComment_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTheComment.TextChanged
  Changing

end sub

Public Item As MTZMetaModel.MTZMetaModel.UNIQUECONSTRAINT
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,MTZMetaModel.MTZMetaModel.UNIQUECONSTRAINT)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

txtName.text = item.Name
cmbPerParentData = New DataTable
cmbPerParentData.Columns.Add("name", GetType(System.String))
cmbPerParentData.Columns.Add("Value", GetType(System.Int32))
try
cmbPerParentDataRow = cmbPerParentData.NewRow
cmbPerParentDataRow("name") = "Да"
cmbPerParentDataRow("Value") = -1
cmbPerParentData.Rows.Add (cmbPerParentDataRow)
cmbPerParentDataRow = cmbPerParentData.NewRow
cmbPerParentDataRow("name") = "Нет"
cmbPerParentDataRow("Value") = 0
cmbPerParentData.Rows.Add (cmbPerParentDataRow)
cmbPerParent.DisplayMember = "name"
cmbPerParent.ValueMember = "Value"
cmbPerParent.DataSource = cmbPerParentData
 cmbPerParent.SelectedValue=CInt(Item.PerParent)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
txtTheComment.text = item.TheComment
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
   item.PerParent = cmbPerParent.SelectedValue
item.TheComment = txtTheComment.text
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK =( txtName.text <> "" ) 
if mIsOK then mIsOK =(cmbPerParent.SelectedIndex >=0)
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
